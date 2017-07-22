using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base;
using IKaan.Model.Was;
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
				sqlId = string.Concat(req.SqlId, typeof(T).Name);

			var parameter = req.Parameter.JsonToAnyType<DataMap>();
			T data = default(T);

			if (req.ServiceId.StartsWith("L"))
				data = DaoFactory.InstanceLib.QueryForObject<T>(sqlId, parameter);
			else if (req.ServiceId.StartsWith("B"))
				data = DaoFactory.InstanceBiz.QueryForObject<T>(sqlId, parameter);
			else
				data = DaoFactory.Instance.QueryForObject<T>(sqlId, parameter);

			return data;
		}

		public static IList<T> GetList<T>(this WasRequest req, string sqlId = null)
		{
			if (sqlId.IsNullOrEmpty() || sqlId.Replace("Select", "").IsNullOrEmpty())
				sqlId = string.Concat(req.SqlId, typeof(T).Name, "List");
			var parameter = req.Parameter.JsonToAnyType<DataMap>();

			IList<T> data = null;

			if (req.ServiceId.StartsWith("L"))
				data = DaoFactory.InstanceLib.QueryForList<T>(sqlId, parameter);
			else if (req.ServiceId.StartsWith("B"))
				data = DaoFactory.InstanceBiz.QueryForList<T>(sqlId, parameter);
			else
				data = DaoFactory.Instance.QueryForList<T>(sqlId, parameter);

			return data;
		}

		public static T SaveData<T>(this WasRequest req)
		{
			try
			{
				object id = null;
				var model = req.Data.JsonToAnyType<T>();
				if (req.SqlId.Equals("Insert") || ((IModelBase)model).ID == default(int))
				{
					((IModelBase)model).CreateBy = req.User.UserId;
					((IModelBase)model).CreateByName = req.User.UserName;
					if (req.ServiceId.StartsWith("L"))
						id = DaoFactory.InstanceLib.Insert(string.Concat(req.SqlId, req.ModelName), model);
					else if (req.ServiceId.StartsWith("B"))
						id = DaoFactory.InstanceBiz.Insert(string.Concat(req.SqlId, req.ModelName), model);
					else
						id = DaoFactory.Instance.Insert(string.Concat(req.SqlId, req.ModelName), model);
					((IModelBase)model).ID = id.ToIntegerNullToNull();
				}
				else
				{
					((IModelBase)model).UpdateBy = req.User.UserId;
					((IModelBase)model).UpdateByName = req.User.UserName;
					if (req.ServiceId.StartsWith("L"))
						DaoFactory.InstanceLib.Update(string.Concat(req.SqlId, req.ModelName), model);
					else if (req.ServiceId.StartsWith("B"))
						DaoFactory.InstanceBiz.Update(string.Concat(req.SqlId, req.ModelName), model);
					else
						DaoFactory.Instance.Update(string.Concat(req.SqlId, req.ModelName), model);
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

				if (existsChecked)
				{
					if (req.ServiceId.StartsWith("L"))
						rm = DaoFactory.InstanceLib.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "Exists"), data);
					else if (req.ServiceId.StartsWith("B"))
						rm = DaoFactory.InstanceBiz.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "Exists"), data);
					else
						rm = DaoFactory.Instance.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "Exists"), data);
				}

				if (rm == null || ((IModelBase)rm).ID == null)
				{
					if (((IModelBase)data).Checked == "Y")
					{
						((IModelBase)data).CreateBy = req.User.UserId;
						((IModelBase)data).CreateByName = req.User.UserName;

						if (req.ServiceId.StartsWith("L"))
							DaoFactory.InstanceLib.Insert(string.Concat("Insert", data.GetType().Name), data);
						else if (req.ServiceId.StartsWith("B"))
							DaoFactory.InstanceBiz.Insert(string.Concat("Insert", data.GetType().Name), data);
						else
							DaoFactory.Instance.Insert(string.Concat("Insert", data.GetType().Name), data);
					}
				}
				else
				{
					((IModelBase)data).ID = ((IModelBase)rm).ID;
					((IModelBase)data).UpdateBy = req.User.UserId;
					((IModelBase)data).UpdateByName = req.User.UserName;

					if (req.ServiceId.StartsWith("L"))
						DaoFactory.InstanceLib.Update(string.Concat("Update", data.GetType().Name), data);
					else if (req.ServiceId.StartsWith("B"))
						DaoFactory.InstanceBiz.Update(string.Concat("Update", data.GetType().Name), data);
					else
						DaoFactory.Instance.Update(string.Concat("Update", data.GetType().Name), data);
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

				if (req.ServiceId.StartsWith("L"))
					rm = DaoFactory.InstanceLib.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "Exists"), data);
				else if (req.ServiceId.StartsWith("B"))
					rm = DaoFactory.InstanceBiz.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "Exists"), data);
				else
					rm = DaoFactory.Instance.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "Exists"), data);

				if (rm != null && ((IModelBase)rm).ID != null)
				{
					DataMap parameter = new DataMap() { { "ID", ((IModelBase)rm).ID } };

					if (req.ServiceId.StartsWith("L"))
						DaoFactory.InstanceLib.Delete(string.Concat("Delete", data.GetType().Name), parameter);
					else if (req.ServiceId.StartsWith("B"))
						DaoFactory.InstanceBiz.Delete(string.Concat("Delete", data.GetType().Name), parameter);
					else
						DaoFactory.Instance.Delete(string.Concat("Delete", data.GetType().Name), parameter);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
