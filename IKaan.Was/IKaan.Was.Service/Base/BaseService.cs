using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Base
{
	public static class BaseService
	{
		/// <summary>
		/// GetList
		/// 데이터 리스트 가져오기
		/// </summary>
		/// <param name="request">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
				if (request.Data == null && request.SqlId.IsNullOrEmpty())
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data.GetType() == typeof(List<WasRequest>))
				{
					list = (request.Data as List<WasRequest>);
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in (request.Data as List<WasRequest>))
				{
					(req.Parameter as DataMap).SetValue("CreateBy", request.User.UserId);
					(req.Parameter as DataMap).SetValue("CreateByName", request.User.UserName);
					req.Data = DaoFactory.Instance.QueryForList<DataMap>(req.SqlId, (req.Parameter as DataMap));
				}

				if (isOneRequest)
				{
					request.Data = list;
				}
				else
				{
					request = list[0];
				}
				
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		/// <summary>
		/// GetData
		/// 데이터 한건 가져오기
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest GetData(WasRequest request)
		{
			try
			{
				if (request.Data == null && request.SqlId.IsNullOrEmpty())
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data.GetType() == typeof(List<WasRequest>))
				{
					list = (request.Data as List<WasRequest>);
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in list)
				{
					(req.Parameter as DataMap).SetValue("CreateBy", request.User.UserId);
					(req.Parameter as DataMap).SetValue("CreateByName", request.User.UserName);
					req.Data = DaoFactory.Instance.QueryForObject<DataMap>(req.SqlId, (req.Parameter as DataMap));
				}

				if (isOneRequest)
				{
					request.Data = list;
				}
				else
				{
					request = list[0];
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		/// <summary>
		/// Save
		/// 데이터 저장(Insert, Update)
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest Save(WasRequest request)
		{
			bool isTran = false;
			string keyField = string.Empty;
			object keyValue = null;
			bool isKey = false;

			try
			{
				if (request.Data == null && request.SqlId.IsNullOrEmpty())
					throw new Exception("처리요청이 없습니다.");

				if (request.IsTransaction)
				{
					DaoFactory.Instance.BeginTransaction();
					isTran = true;
				}

				try
				{
					bool isOneRequest = true;
					List<WasRequest> list = new List<WasRequest>();
					if (request.Data.GetType() == typeof(List<WasRequest>))
					{
						list = (request.Data as List<WasRequest>);
						isOneRequest = false;
					}
					else
					{
						list.Add(request);
					}

					foreach (WasRequest data in list)
					{
						if (data.Data == null)
							continue;

						IList<DataMap> datalist = null;

						if (data.Data.GetType() == typeof(DataMap))
						{
							datalist = new List<DataMap>();
							datalist.Add((data.Data as DataMap));
						}
						else
						{
							continue;
						}

						foreach (DataMap map in datalist)
						{
							map.SetValue("CreateBy", request.User.UserId);
							map.SetValue("CreateByName", request.User.UserName);

							if (isKey &&
								data.Master.IsMaster == false &&
								keyField.ToStringNullToEmpty() != "" &&
								keyValue.ToStringNullToEmpty() != "")
							{
								map.SetValue(keyField, keyValue);
							}

							if (map.GetValue("RowState").ToStringNullToEmpty() == "INSERT")
							{
								keyValue = DaoFactory.Instance.Insert(string.Format("Insert{0}", data.SqlId), map);
							}
							else if (map.GetValue("RowState").ToStringNullToEmpty() == "UPDATE")
							{
								DaoFactory.Instance.Update(string.Format("Update{0}", data.SqlId), map);
								if (data.Master.KeyField.ToStringNullToEmpty() != "")
									keyValue = map.GetValue(data.Master.KeyField);
							}
							else if (map.GetValue("RowState").ToStringNullToEmpty() == "DELETE")
							{
								DaoFactory.Instance.Update(string.Format("Delete{0}", data.SqlId), map);
								if (data.Master.KeyField.ToStringNullToEmpty() != "")
									keyValue = map.GetValue(data.Master.KeyField);
							}
							else if (map.GetValue("RowState").ToStringNullToEmpty() == "UPSERT")
							{
								DaoFactory.Instance.Insert(string.Format("Upsert{0}", data.SqlId), map);
								if (data.Master.KeyField.ToStringNullToEmpty() != "")
									keyValue = map.GetValue(data.Master.KeyField);
							}

							if (data.Master.IsMaster &&
								data.Master.KeyField.ToStringNullToEmpty() != "")
							{
								isKey = true;
								keyField = data.Master.KeyField;
							}
						}
						data.Result.ReturnValue = keyValue;
						data.Result.ReturnMessage = "SUCCESS";
					}

					if (isOneRequest)
					{
						request.Data = list;
					}
					else
					{
						request = list[0];
					}

					if (request.IsTransaction && isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch(Exception ex)
				{
					if (request.IsTransaction && isTran)
						DaoFactory.Instance.RollBackTransaction();

					throw new Exception(ex.Message);
				}
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		/// <summary>
		/// Delete
		/// 데이터 삭제(Delete)
		/// </summary>
		/// <param name="req">WasRequest</param>
		/// <returns>WasRequest</returns>
		public static WasRequest Delete(WasRequest request)
		{
			try
			{
				if (request.Data == null && request.SqlId.IsNullOrEmpty())
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data.GetType() == typeof(List<WasRequest>))
				{
					list = (request.Data as List<WasRequest>);
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in list)
				{
					DataMap parameter = null;
					if (req.Data == null)
						continue;
					if (req.Data.GetType() == typeof(DataMap))
						parameter = (req.Data as DataMap);
					else
						continue;

					parameter.SetValue("CreateBy", req.User.UserId);
					parameter.SetValue("CreateByName", req.User.UserName);
					var map = DaoFactory.Instance.QueryForObject<DataMap>(string.Format("Select{0}", req.SqlId), parameter);
					if (map != null)
					{
						DaoFactory.Instance.Insert("Delete{0}", parameter);
					}
				}

				if (isOneRequest)
				{
					request.Data = list;
				}
				else
				{
					request = list[0];
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest ProcedureCall(WasRequest request)
		{
			try
			{
				if (request.Data == null && request.SqlId.IsNullOrEmpty())
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data.GetType() == typeof(List<WasRequest>))
				{
					list = (request.Data as List<WasRequest>);
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in list)
				{
					if (req.Parameter == null)
						req.Parameter = new DataMap();
					(req.Parameter as DataMap).SetValue("CreateBy", req.User.UserId);
					(req.Parameter as DataMap).SetValue("CreateByName", req.User.UserName);
					DaoFactory.Instance.QueryForObject<int>(req.SqlId, (req.Parameter as DataMap));
				}

				if (isOneRequest)
				{
					request.Data = list;
				}
				else
				{
					request = list[0];
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}
	}
}
