using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.BIZ.BM;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.BIZ
{
	public static class BMService
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
						case "BMBrand":
							req.SetList<BMBrand>();
							break;
						case "BMChannel":
							req.SetList<BMChannel>();
							break;
						case "BMSearchBrand":
							req.SetList<BMSearchBrand>();
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
						case "BMBrand":
							req.SetData<BMBrand>();
							(req.Data as BMBrand).BrandImage = req.GetList<BMBrandImage>();
							break;
						case "BMChannel":
							req.SetData<BMChannel>();
							(req.Data as BMChannel).ChannelBrand = req.GetList<BMChannelBrand>();
							(req.Data as BMChannel).ChannelCustomer = req.GetList<BMCustomerChannel>();
							break;
						case "BMSearchBrand":
							req.SetData<BMSearchBrand>();
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
					DaoFactory.InstanceBiz.BeginTransaction();
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
								case "BMBrand":
									var brand = req.SaveData<BMBrand>();
									if (brand != null)
									{
										req.SaveBrandImage(brand);
									}
									break;
								case "BMChannel":
									var channel = req.SaveData<BMChannel>();
									if (channel != null)
									{
										req.SaveChannelBrand(channel);
										req.SaveChannelCustomer(channel);
									}
									break;
								case "BMBrandImage":
									req.SaveData<BMBrandImage>();
									break;
								case "BMSearchBrand":
									req.SaveData<BMSearchBrand>();
									break;
							}
						}
					}

					if (isTran)
						DaoFactory.InstanceBiz.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceBiz.RollBackTransaction();

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
					DaoFactory.InstanceBiz.BeginTransaction();
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
						DaoFactory.InstanceBiz.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceBiz.RollBackTransaction();

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

		private static void SaveBrandImage(this WasRequest req, BMBrand model)
		{
			try
			{
				foreach (var data in model.BrandImage)
				{
					if (data.BrandID == null)
					{
						data.BrandID = model.ID;
					}
					req.SaveSubData<BMBrandImage>(data, false);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveCustomerBrand(this WasRequest req, BMBrand model)
		{
			try
			{
				foreach (var data in model.BrandCustomer)
				{
					if (data.BrandID == null)
					{
						data.BrandID = model.ID;
					}
					req.SaveSubData<BMBrandImage>(data, false);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveChannelBrand(this WasRequest req, BMChannel model)
		{
			try
			{
				foreach (var data in model.ChannelBrand)
				{
					if (data.ChannelID == null)
					{
						data.ChannelID = model.ID;
					}
					req.SaveSubData<BMChannelBrand>(data, false);
				}
			}
			catch
			{
				throw;
			}
		}

		private static void SaveChannelCustomer(this WasRequest req, BMChannel model)
		{
			try
			{
				foreach (var data in model.ChannelCustomer)
				{
					if (data.ChannelID == null)
					{
						data.ChannelID = model.ID;
					}
					req.SaveSubData<BMCustomerChannel>(data, false);
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
