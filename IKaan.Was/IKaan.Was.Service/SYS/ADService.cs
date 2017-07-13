using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.SYS.AD;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.SYS
{
	public static class ADService
	{
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
				{
					throw new Exception("처리요청이 없습니다.");
				}

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
					switch (req.ModelName)
					{
						case "ADSystem":
							req.SetList<ADSystem>();
							break;
						case "ADServer":
							req.SetList<ADServer>();
							break;
						case "ADDatabase":
							req.SetList<ADDatabase>();
							break;
						case "ADSchema":
							req.SetList<ADSchema>();
							break;
						case "ADTable":
							req.SetList<ADTable>();
							break;
						case "ADColumn":
							req.SetList<ADColumn>();
							break;
					}
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
				{
					throw new Exception("처리요청이 없습니다.");
				}

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

				var parameter = request.Parameter.JsonToAnyType<DataMap>();

				foreach (WasRequest req in list)
				{
					switch (req.ModelName)
					{
						case "ADSystem":
							req.SetData<ADSystem>();
							break;
						case "ADServer":
							req.SetData<ADServer>();
							break;
						case "ADDatabase":
							req.SetData<ADDatabase>();
							break;
						case "ADSchema":
							req.SetData<ADSchema>();
							break;
						case "ADTable":
							req.SetData<ADTable>();
							break;
						case "ADColumn":
							req.SetData<ADColumn>();
							break;
					}
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
				if (request.Data.GetType() == typeof(List<WasRequest>))
				{
					list = (request.Data as List<WasRequest>);
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
					object table_id = null;
					object column_id = null;

					//테이블
					if (list.Count > 0)
					{
						if (list[0].Data == null)
							throw new Exception("저장할 데이터가 존재하지 않습니다.");

						ADTable data = list[0].Data as ADTable;						

						if (data.ID.IsNullOrEmpty())
						{
							data.CreateBy = request.User.UserId;
							data.CreateByName = request.User.UserName;
							table_id = DaoFactory.Instance.Insert("InsertADTables", data);
						}
						else
						{
							data.UpdateBy = request.User.UserId;
							data.UpdateByName = request.User.UserName;
							DaoFactory.Instance.Update("UpdateADTables", data);
							table_id = data.ID;
						}
						list[0].Error.Number = 0;
						list[0].Error.Message = "SUCCESS";
						list[0].Result.ReturnValue = table_id;
					}

					//컬럼
					if (list.Count > 1)
					{						
						if (list[1].Data != null && list[1].Data.GetType()==typeof(List<ADColumn>))
						{
							foreach (ADColumn col in (list[1].Data as IList<ADColumn>))
							{
								if (col.ID.IsNullOrEmpty())
								{
									col.CreateBy = request.User.UserId;
									col.CreateByName = request.User.UserName;
									column_id = DaoFactory.Instance.Insert("InsertADColumns", col);
								}
								else
								{
									col.UpdateBy = request.User.UserId;
									col.UpdateByName = request.User.UserName;
									DaoFactory.Instance.Update("UpdateADColumn", col);
									column_id = col.ID;
								}
							}
							list[1].Error.Number = 0;
							list[1].Error.Message = "SUCCESS";
							list[1].Result.ReturnValue = column_id;
						}
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

		public static WasRequest Delete(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				DaoFactory.Instance.BeginTransaction();
				isTran = true;

				try
				{
					foreach (DataMap map in request.Data as List<DataMap>)
					{
						DaoFactory.Instance.Delete("DeleteColumnByTable", map);
						DaoFactory.Instance.Delete("DeleteADTable", map);
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

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest DeleteColumn(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				DaoFactory.Instance.BeginTransaction();
				isTran = true;

				try
				{
					foreach (DataMap map in request.Data as List<DataMap>)
					{
						DaoFactory.Instance.Delete("DeleteColumn", map);
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
