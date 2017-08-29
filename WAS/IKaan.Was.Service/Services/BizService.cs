using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Biz;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Services
{
	public static class BizService
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
					switch (req.ModelName.Replace("Model",""))
					{
						case "Appointment":
							req.SetList<AppointmentModel>();
							break;
						case "Department":
							req.SetList<DepartmentModel>();
							break;
						case "Employee":
							req.SetList<EmployeeModel>();
							break;
						case "Category":
							req.SetList<CategoryModel>();
							break;
						case "InfoNotice":
							req.SetList<InfoNoticeModel>();
							break;
						case "Goods":
							req.SetList<GoodsModel>();
							break;
						case "GoodsInfoNotice":
							req.SetList<GoodsInfoNoticeModel>();
							break;
						case "Address":
							req.SetList<AddressModel>();
							break;
						case "Business":
							req.SetList<BusinessModel>();
							break;
						case "Brand":
							req.SetList<BrandModel>();
							break;
						case "Channel":
							req.SetList<ChannelModel>();
							break;
						case "ChannelSetting":
							req.SetList<ChannelSettingModel>();
							break;
						case "SearchBrand":
							req.SetList<SearchBrandModel>();
							break;
						case "Customer":
							req.SetList<CustomerModel>();
							break;
						case "OrderSum":
							req.SetList<OrderSumModel>();
							break;
						case "OrderSumSales":
							req.SetList<OrderSumSalesModel>();
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
					switch (req.ModelName.Replace("Model",""))
					{
						case "Appointment":
							req.SetData<AppointmentModel>();
							break;
						case "Department":
							req.GetDepartment();
							break;
						case "Employee":
							req.GetEmployee();
							break;
						case "Category":
							req.SetData<CategoryModel>();
							break;
						case "InfoNotice":
							req.SetData<InfoNoticeModel>();
							(req.Data as InfoNoticeModel).Items = req.GetList<InfoNoticeItemModel>();
							break;
						case "Goods":
							req.GetGoodsData();
							break;
						case "Address":
							req.SetData<AddressModel>();
							break;
						case "Business":
							req.GetBusiness();
							break;
						case "Brand":
							req.SetData<BrandModel>();
							(req.Data as BrandModel).Images = req.GetList<BrandImageModel>();
							(req.Data as BrandModel).Customers = req.GetList<CustomerBrandModel>();
							(req.Data as BrandModel).Channels = req.GetList<ChannelBrandModel>();
							(req.Data as BrandModel).Contacts = req.GetList<BrandContactModel>();
							(req.Data as BrandModel).Managers = req.GetList<BrandManagerModel>();
							break;
						case "BrandContact":
							req.SetData<BrandContactModel>();
							break;
						case "BrandManager":
							req.SetData<BrandManagerModel>();
							break;
						case "Channel":
							req.GetChannelData();
							break;
						case "ChannelBrand":
							req.SetData<ChannelBrandModel>();
							break;
						case "ChannelContact":
							req.SetData<ChannelContactModel>();
							break;
						case "ChannelManager":
							req.SetData<ChannelManagerModel>();
							break;
						case "ChannelSetting":
							req.SetData<ChannelSettingModel>();
							break;
						case "SearchBrand":
							req.GetSearchBrand();
							break;
						case "SearchBrandActivity":
							req.SetData<SearchBrandActivityModel>();
							break;
						case "Customer":
							req.GetCustomer();
							break;
						case "CustomerBusiness":
							req.GetCustomerBusiness();
							break;
						case "CustomerAddress":
							req.GetCustomerAddress();
							break;
						case "CustomerBank":
							req.SetData<CustomerBankModel>();
							break;
						case "CustomerBrand":
							req.SetData<CustomerBrandModel>();
							break;
						case "CustomerChannel":
							req.SetData<CustomerChannelModel>();
							break;
						case "OrderSum":
							req.SetData<OrderSumModel>();
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

							switch (req.ModelName.Replace("Model",""))
							{
								case "Appointment":
									req.SaveAppointment();
									break;
								case "Department":
									req.SaveDepartment();
									break;
								case "Employee":
									req.SaveEmployee();
									break;
								case "Category":
									req.SaveCategory();
									break;
								case "InfoNotice":
									var infoNotice = req.SaveData<InfoNoticeModel>();
									if (infoNotice != null)
										req.SaveInfoNoticeItem(infoNotice);
									break;
								case "Goods":
									req.SaveGoods();
									break;
								case "GoodsImage":
									req.SaveGoodsImage();
									break;
								case "Business":
									req.SaveBusiness();
									break;
								case "Brand":
									req.SaveBrand();
									break;
								case "BrandImage":
									req.SaveData<BrandImageModel>();
									break;
								case "BrandContact":
									req.SaveBrandContact();
									break;
								case "BrandManager":
									req.SaveBrandManager();
									break;
								case "Channel":
									req.SaveChannel();
									break;
								case "ChannelBrand":
									req.SaveChannelBrand();
									break;
								case "ChannelContact":
									req.SaveChannelContact();
									break;
								case "ChannelManager":
									req.SaveChannelManager();
									break;
								case "SearchBrand":
									req.SaveData<SearchBrandModel>();
									break;
								case "SearchBrandActivity":
									req.SaveData<SearchBrandActivityModel>();
									break;
								case "Customer":
									req.SaveCustomer();
									break;
								case "CustomerBusiness":
									req.SaveCustomerBusiness();
									break;
								case "CustomerAddress":
									req.SaveCustomerAddress();
									break;
								case "CustomerBank":
									req.SaveCustomerBank();
									break;
								case "CustomerBrand":
									req.SaveCustomerBrand();
									break;
								case "CustomerChannel":
									req.SaveCustomerChannel();
									break;
								case "OrderSumByChannel":
									req.SaveOrderSumByChannel();
									break;
								case "OrderSumByBrand":
									req.SaveOrderSumByBrand();
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
						DaoFactory.InstanceBiz.Delete(req.SqlId, map);
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
	}
}
