using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base;
using IKaan.Model.Base.Common;
using IKaan.Model.Common.Was;
using IKaan.Model.Live;
using IKaan.Was.Core.Mappers;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Common
{
	public static class FileUploadService
	{
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
				if (request == null || request.SqlId.IsNullOrEmpty())
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in list)
				{
					(req.Parameter as DataMap).SetValue("CreatedBy", request.User.UserId);
					(req.Parameter as DataMap).SetValue("CreatedByName", request.User.UserName);
					req.Data = DaoFactory.Instance.QueryForList<FileUploadModel>("SelectFileUploadList", (req.Parameter as DataMap));
				}

				if (isOneRequest)
				{
					request = list[0];					
				}
				else
				{
					request.Data = list;
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

		public static WasRequest GetData(WasRequest request)
		{
			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in list)
				{
					(req.Parameter as DataMap).SetValue("CreatedBy", request.User.UserId);
					(req.Parameter as DataMap).SetValue("CreatedByName", request.User.UserName);
					req.Data = DaoFactory.Instance.QueryForObject<FileUploadModel>("SelectFileUpload", (req.Parameter as DataMap));
				}

				if (isOneRequest)
				{
					request = list[0];					
				}
				else
				{
					request.Data = list;
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

		public static WasRequest Save(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				if (request.IsTransaction)
				{
					DaoFactory.Instance.BeginTransaction();
					isTran = true;
				}

				try
				{
					//테이블
					if (list.Count > 0)
					{
						foreach (WasRequest req in list)
						{
							if (req.Data == null)
								throw new Exception("저장할 데이터가 존재하지 않습니다.");

							var model = req.Data.JsonToAnyType<FileUploadModel>();
							if (model.ID == null)
							{
								model.CreatedBy = req.User.UserId;
								model.CreatedByName = req.User.UserName;
								object id = DaoFactory.Instance.Insert("InsertFileUpload", model);
								model.ID = id.ToIntegerNullToNull();
							}
							else
							{
								model.UpdatedBy = req.User.UserId;
								model.UpdatedByName = req.User.UserName;
								DaoFactory.Instance.Update("UpdateFileUpload", model);
							}

							if (model.UploadData != null && model.UploadType.IsNullOrEmpty() == false)
							{
								var parameter = req.Parameter.JsonToAnyType<DataMap>();
								switch (model.UploadType)
								{
									case "ChannelOrder":
										req.SaveChannelOrder(model, parameter);
										break;
									case "ChannelOrderCancel":
										break;
									case "ChannelOrderReturn":
										break;
									case "ChannelAccount":
										break;
								}
							}

							req.Result.Count = 1;
							req.Result.ReturnValue = model.ID;
							req.Error.Number = 0;
						}
					}

					if (request.IsTransaction && isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (request.IsTransaction && isTran)
						DaoFactory.Instance.RollBackTransaction();

					throw new Exception(ex.Message);
				}

				if (isOneRequest)
				{
					request = list[0];
				}
				else
				{
					request.Data = list;
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

		public static WasRequest Delete(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				DaoFactory.Instance.BeginTransaction();
				isTran = true;

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.Instance.Delete("DeleteFileUpload", map);
					}

					if (isTran)
						DaoFactory.Instance.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.Instance.RollBackTransaction();

					throw new Exception(ex.Message);
				}

				if (isOneRequest)
				{
					request = list[0];					
				}
				else
				{
					request.Data = list;
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
