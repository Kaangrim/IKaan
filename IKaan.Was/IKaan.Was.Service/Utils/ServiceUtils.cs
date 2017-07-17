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
		public static WasRequest SetList<T>(this WasRequest req)
		{
			var data = req.GetList<T>(req.SqlId);
			req.Data = data;
			req.Result.Count = (data == null) ? 0 : data.Count;
			return req;
		}
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
			var data = DaoFactory.Instance.QueryForObject<T>(sqlId, parameter);
			return data;
		}

		public static IList<T> GetList<T>(this WasRequest req, string sqlId = null)
		{
			if (sqlId.IsNullOrEmpty() || sqlId.Replace("Select", "").IsNullOrEmpty())
				sqlId = string.Concat(req.SqlId, typeof(T).Name, "List");
			var parameter = req.Parameter.JsonToAnyType<DataMap>();
			var data = DaoFactory.Instance.QueryForList<T>(sqlId, parameter);
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
					id = DaoFactory.Instance.Insert(string.Concat(req.SqlId, req.ModelName), model);
				}
				else
				{
					((IModelBase)model).UpdateBy = req.User.UserId;
					((IModelBase)model).UpdateByName = req.User.UserName;
					DaoFactory.Instance.Update(string.Concat(req.SqlId, req.ModelName), model);
					id = ((IModelBase)model).ID;
				}
				req.Result.ReturnValue = id;
				return (T)model;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveSubData<T>(this WasRequest req, object data)
		{
			try
			{
				var rm = DaoFactory.Instance.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "ByReference"), data);
				if (rm == null || ((IModelBase)rm).ID == null)
				{
					if (((IModelBase)data).Checked == "Y")
					{
						((IModelBase)data).CreateBy = req.User.UserId;
						((IModelBase)data).CreateByName = req.User.UserName;
						DaoFactory.Instance.Insert(string.Concat("Insert", data.GetType().Name), data);
					}
				}
				else
				{
					((IModelBase)data).ID = ((IModelBase)rm).ID;
					((IModelBase)data).UpdateBy = req.User.UserId;
					((IModelBase)data).UpdateByName = req.User.UserName;
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
				var rm = DaoFactory.Instance.QueryForObject<T>(string.Concat("Select", typeof(T).Name, "ByReference"), data);
				if (rm != null && ((IModelBase)rm).ID != null)
				{
					DataMap parameter = new DataMap() { { "ID", ((IModelBase)rm).ID } };
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
