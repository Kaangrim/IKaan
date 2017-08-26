using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Base;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Utils
{
	public static class ServiceUtils
	{
		/// <summary>
		/// T형식의 모델에 리스트 데이터를 담아서 WasRequest로 반환한다.
		/// </summary>
		/// <typeparam name="T">모델형식</typeparam>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest SetList<T>(this WasRequest req)
		{
			var data = req.GetList<T>(req.SqlId);
			req.Data = data;
			req.Result.Count = (data == null) ? 0 : data.Count;
			return req;
		}

		/// <summary>
		/// T형식의 모델에 단일 데이터를 담아서 WasRequest로 반환한다.
		/// </summary>
		/// <typeparam name="T">모델형식</typeparam>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest SetData<T>(this WasRequest req)
		{
			var data = req.GetData<T>();
			req.Data = data;
			req.Result.Count = (data == null || ((IModelBase)data).ID == default(int) || ((IModelBase)data).ID.ToStringNullToEmpty().IsNullOrEmpty()) ? 0 : 1;
			return req;
		}


		public static T GetData<T>(this WasRequest req, string sqlId = null)
		{
			if (sqlId.IsNullOrEmpty())
				sqlId = string.Concat(req.SqlId, typeof(T).Name.Replace("Model", ""));

			var parameter = req.Parameter.JsonToAnyType<DataMap>();
			T data = default(T);

			if (req.ServiceId.StartsWith("Biz"))
				data = DaoFactory.InstanceBiz.QueryForObject<T>(sqlId, parameter);
			else if (req.ServiceId.StartsWith("Scrap"))
				data = DaoFactory.InstanceScrap.QueryForObject<T>(sqlId, parameter);
			else
				data = DaoFactory.Instance.QueryForObject<T>(sqlId, parameter);

			return data;
		}

		public static IList<T> GetList<T>(this WasRequest req, string sqlId = null)
		{
			string modelName = typeof(T).Name.Replace("Model", "");
			if (sqlId.IsNullOrEmpty() || sqlId.Replace("Select", "").IsNullOrEmpty())
				sqlId = string.Concat(req.SqlId, modelName, "List");
			var parameter = req.Parameter.JsonToAnyType<DataMap>();

			IList<T> data = new List<T>();

			if (req.ServiceId.StartsWith("Biz"))
				data = DaoFactory.InstanceBiz.QueryForList<T>(sqlId, parameter);
			else if (req.ServiceId.StartsWith("Scrap"))
				data = DaoFactory.InstanceScrap.QueryForList<T>(sqlId, parameter);
			else
				data = DaoFactory.Instance.QueryForList<T>(sqlId, parameter);

			return data;
		}

		public static T SaveData<T>(this WasRequest req, object data = null)
		{
			try
			{
				object id = null;
				string modelName = req.ModelName.Replace("Model", "");
				var model = req.Data.JsonToAnyType<T>();
				if (data != null)
					model = (T)data;

				if (req.SqlId.Equals("Insert") || ((IModelBase)model).ID == default(int))
				{
					((IModelBase)model).CreateBy = req.User.UserId;
					((IModelBase)model).CreateByName = req.User.UserName;

					if (req.ServiceId.StartsWith("Biz"))
						id = DaoFactory.InstanceBiz.Insert(string.Concat(req.SqlId, modelName), model);
					else if (req.ServiceId.StartsWith("Scrap"))
						id = DaoFactory.InstanceScrap.Insert(string.Concat(req.SqlId, modelName), model);
					else
						id = DaoFactory.Instance.Insert(string.Concat(req.SqlId, modelName), model);
					((IModelBase)model).ID = id.ToIntegerNullToNull();
				}
				else
				{
					((IModelBase)model).UpdateBy = req.User.UserId;
					((IModelBase)model).UpdateByName = req.User.UserName;

					if (req.ServiceId.StartsWith("Biz"))
						DaoFactory.InstanceBiz.Update(string.Concat(req.SqlId, modelName), model);
					else if (req.ServiceId.StartsWith("Scrap"))
						DaoFactory.InstanceScrap.Update(string.Concat(req.SqlId, modelName), model);
					else
						DaoFactory.Instance.Update(string.Concat(req.SqlId, modelName), model);
					id = ((IModelBase)model).ID;
				}
				req.Result.ReturnValue = id;
				return model;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveSubData<T>(this WasRequest req, object data, bool existsChecked = true)
		{
			try
			{
				T rm = default(T);
				string modelName = typeof(T).Name.Replace("Model", "");

				if (existsChecked)
				{
					if (req.ServiceId.StartsWith("Biz"))
						rm = DaoFactory.InstanceBiz.QueryForObject<T>(string.Concat("Select", modelName, "Exists"), data);
					else if (req.ServiceId.StartsWith("Scrap"))
						rm = DaoFactory.InstanceScrap.QueryForObject<T>(string.Concat("Select", modelName, "Exists"), data);
					else
						rm = DaoFactory.Instance.QueryForObject<T>(string.Concat("Select", modelName, "Exists"), data);
				}

				if (rm == null || ((IModelBase)rm).ID == null)
				{
					if (((IModelBase)data).Checked == "Y")
					{
						((IModelBase)data).CreateBy = req.User.UserId;
						((IModelBase)data).CreateByName = req.User.UserName;

						if (req.ServiceId.StartsWith("Biz"))
							DaoFactory.InstanceBiz.Insert(string.Concat("Insert", modelName), data);
						else if (req.ServiceId.StartsWith("Scrap"))
							DaoFactory.InstanceScrap.Insert(string.Concat("Insert", modelName), data);
						else
							DaoFactory.Instance.Insert(string.Concat("Insert", modelName), data);
					}
				}
				else
				{
					((IModelBase)data).ID = ((IModelBase)rm).ID;
					((IModelBase)data).UpdateBy = req.User.UserId;
					((IModelBase)data).UpdateByName = req.User.UserName;

					if (req.ServiceId.StartsWith("Biz"))
						DaoFactory.InstanceBiz.Update(string.Concat("Update", modelName), data);
					else if (req.ServiceId.StartsWith("Scrap"))
						DaoFactory.InstanceScrap.Update(string.Concat("Update", modelName), data);
					else
						DaoFactory.Instance.Update(string.Concat("Update", modelName), data);
				}
			}
			catch
			{
				throw;
			}
		}
		
		public static void DeleteSubData<T>(this WasRequest req, object data)
		{
			try
			{
				T rm = default(T);
				string modelName = typeof(T).Name.Replace("Model", "");

				if (req.ServiceId.StartsWith("Biz"))
					rm = DaoFactory.InstanceBiz.QueryForObject<T>(string.Concat("Select", modelName, "Exists"), data);
				else if (req.ServiceId.StartsWith("Scrap"))
					rm = DaoFactory.InstanceScrap.QueryForObject<T>(string.Concat("Select", modelName, "Exists"), data);
				else
					rm = DaoFactory.Instance.QueryForObject<T>(string.Concat("Select", modelName, "Exists"), data);

				if (rm != null && ((IModelBase)rm).ID != null)
				{
					DataMap parameter = new DataMap() { { "ID", ((IModelBase)rm).ID } };

					if (req.ServiceId.StartsWith("Biz"))
						DaoFactory.InstanceBiz.Delete(string.Concat("Delete", modelName), parameter);
					else if (req.ServiceId.StartsWith("Scrap"))
						DaoFactory.InstanceScrap.Delete(string.Concat("Delete", modelName), parameter);
					else
						DaoFactory.Instance.Delete(string.Concat("Delete", modelName), parameter);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
