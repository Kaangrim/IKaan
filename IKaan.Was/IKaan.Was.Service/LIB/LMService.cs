using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.LIB.LM;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.LIB
{
	public static class LMService
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
						case "LMBrand":
							req.SetList<LMBrand>();
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
						case "LMBrand":
							req.SetData<LMBrand>();
							(req.Data as LMBrand).BrandImage = req.GetList<LMBrandImage>();
							(req.Data as LMBrand).CustomerBrand = req.GetList<LMCustomerBrand>();
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
					DaoFactory.InstanceLib.BeginTransaction();
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

							switch (req.ModelName)
							{
								case "LMBrand":
									var model = req.SaveData<LMBrand>();

									break;
							}
						}
					}

					if (isTran)
						DaoFactory.InstanceLib.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceLib.RollBackTransaction();

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

				if (request.IsTransaction)
				{
					DaoFactory.InstanceLib.BeginTransaction();
					isTran = true;
				}

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.InstanceLib.Delete(req.SqlId, map);
					}

					if (isTran)
						DaoFactory.InstanceLib.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceLib.RollBackTransaction();

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

		private static void SaveBrandImage(this WasRequest req, List<LMBrandImage> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.BrandID == null)
					{
						data.BrandID = req.Result.ReturnValue.ToIntegerNullToNull();
					}					
					req.SaveSubData<LMBrandImage>(data);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveCustomerBrand(this WasRequest req, List<LMCustomerBrand> list)
		{
			try
			{
				foreach (var data in list)
				{
					if (data.BrandID == null)
					{
						data.BrandID = model.ID;
					}
					req.SaveSubData<LMBrandImage>(data);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
