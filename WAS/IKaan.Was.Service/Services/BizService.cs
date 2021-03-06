﻿using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Catalog.Category;
using IKaan.Model.Biz.Catalog.Product;
using IKaan.Model.Biz.Master.Attribute;
using IKaan.Model.Biz.Master.Brand;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Company;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.InfoNotice;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Model.Biz.Organization;
using IKaan.Model.Biz.Sales.Analysis;
using IKaan.Model.Biz.Sales.Order;
using IKaan.Model.Biz.Search;
using IKaan.Model.Common.Was;
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
						case "CategoryItem":
							req.SetList<CategoryItemModel>();
							break;
						case "InfoNotice":
							req.SetList<InfoNoticeModel>();
							break;
						case "Product":
							req.SetList<ProductModel>();
							break;
						case "ProductInfoNotice":
							req.SetList<ProductInfoNoticeModel>();
							break;
						case "Address":
							req.SetList<AddressModel>();
							break;
						case "Attribute":
							req.SetList<AttributeModel>();
							break;
						case "AttributeType":
							req.SetList<AttributeTypeModel>();
							break;
						case "Business":
							req.SetList<BusinessModel>();
							break;
						case "Contact":
							req.SetList<ContactModel>();
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
						case "Partner":
							req.SetList<PartnerModel>();
							break;
						case "ChannelOrder":
							req.SetList<ChannelOrderModel>();
							break;
						case "ChannelOrderCancel":
							req.SetList<ChannelOrderCancelModel>();
							break;
						case "ChannelOrderReturn":
							req.SetList<ChannelOrderReturnModel>();
							break;
						case "Order":
							req.SetList<OrderModel>();
							break;
						case "OrderList":
							req.SetList<OrderListModel>();
							break;
						case "OrderItem":
							req.SetList<OrderItemModel>();
							break;
						case "OrderNote":
							req.SetList<OrderNoteModel>();
							break;
						case "OrderSum":
							req.SetList<OrderSumModel>();
							break;
						case "OrderSumSales":
							req.SetList<OrderSumSalesModel>();
							break;
						case "Store":
							req.SetList<StoreModel>();
							break;
						case "Company":
							req.SetList<CompanyModel>();
							break;
						case "CompanyAddress":
							req.SetList<CompanyAddressModel>();
							break;
						case "CompanyBankAccount":
							req.SetList<CompanyBankAccountModel>();
							break;
						case "CustomerBankAccount":
							req.SetList<CustomerBankAccountModel>();
							break;
						case "CompanyBusiness":
							req.SetList<CompanyBusinessModel>();
							break;
						case "CompanyContact":
							req.SetList<CompanyContactModel>();
							break;
						case "CompanyStore":
							req.SetList<CompanyStoreModel>();
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
						case "CategoryItem":
							req.SetData<CategoryItemModel>();
							break;
						case "InfoNotice":
							req.SetData<InfoNoticeModel>();
							(req.Data as InfoNoticeModel).Items = req.GetList<InfoNoticeItemModel>();
							break;
						case "Product":
							req.GetProductData();
							break;
						case "Attribute":
							req.SetData<AttributeModel>();
							break;
						case "AttributeType":
							req.SetData<AttributeTypeModel>();
							break;
						case "Address":
							req.SetData<AddressModel>();
							break;
						case "Business":
							req.GetBusiness();
							break;
						case "Contact":
							req.SetData<ContactModel>();
							break;
						case "Brand":
							req.GetBrand();
							break;
						case "BrandImage":
							req.GetBrandImage();
							break;
						case "Channel":
							req.GetChannel();
							break;
						case "ChannelBrand":
							req.SetData<ChannelBrandModel>();
							break;
						case "ChannelSetting":
							req.SetData<ChannelSettingModel>();
							break;
						case "Store":
							req.GetStore();
							break;
						case "Company":
							req.GetCompany();
							break;
						case "CompanyAddress":
							req.GetCompanyAddress();
							break;
						case "CompanyBankAccount":
							req.GetCompanyBankAccount();
							break;
						case "CompanyBusiness":
							req.GetCompanyBusiness();
							break;
						case "CompanyContact":
							req.GetCompanyContact();
							break;
						case "CompanyStore":
							req.SetData<CompanyStoreModel>();
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
						case "CustomerBrand":
							req.SetData<CustomerBrandModel>();
							break;
						case "CustomerChannel":
							req.SetData<CustomerChannelModel>();
							break;
						case "CustomerContact":
							req.SetData<CustomerContactModel>();
							break;
						case "CustomerStore":
							req.SetData<CustomerStoreModel>();
							break;
						case "CustomerManager":
							req.SetData<CustomerManagerModel>();
							break;
						case "CustomerBankAccount":
							req.GetCustomerBankAccount();
							break;
						case "Partner":
							req.GetPartner();
							break;
						case "PartnerBusiness":
							req.GetPartnerBusiness();
							break;
						case "PartnerAddress":
							req.GetPartnerAddress();
							break;
						case "PartnerBrand":
							req.SetData<PartnerBrandModel>();
							break;
						case "PartnerChannel":
							req.SetData<PartnerChannelModel>();
							break;
						case "PartnerContact":
							req.SetData<PartnerContactModel>();
							break;
						case "PartnerStore":
							req.SetData<PartnerStoreModel>();
							break;
						case "PartnerManager":
							req.SetData<PartnerManagerModel>();
							break;
						case "PartnerBankAccount":
							req.GetPartnerBankAccount();
							break;
						case "ChannelOrder":
							req.SetData<ChannelOrderModel>();
							break;
						case "ChannelOrderCancel":
							req.SetData<ChannelOrderCancelModel>();
							break;
						case "ChannelOrderReturn":
							req.SetData<ChannelOrderReturnModel>();
							break;
						case "Order":
							req.GetOrder();
							break;
						case "OrderItem":
							req.SetData<OrderItemModel>();
							break;
						case "OrderNote":
							req.SetData<OrderNoteModel>();
							break;
						case "OrderSum":
							req.SetData<OrderSumModel>();
							break;
						case "SearchBrand":
							req.GetSearchBrand();
							break;
						case "SearchBrandActivity":
							req.SetData<SearchBrandActivityModel>();
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
								case "CategoryItem":
									req.SaveCategoryItem();
									break;
								case "InfoNotice":
									var infoNotice = req.SaveData<InfoNoticeModel>();
									if (infoNotice != null)
										req.SaveInfoNoticeItem(infoNotice);
									break;
								case "Product":
									req.SaveProduct();
									break;
								case "ProductImage":
									req.SaveProductImage();
									break;
								case "Attribute":
									req.SaveData<AttributeModel>();
									break;
								case "AttributeType":
									req.SaveData<AttributeTypeModel>();
									break;
								case "Address":
									req.SaveData<AddressModel>();
									break;
								case "Business":
									req.SaveBusiness();
									break;
								case "Contact":
									req.SaveData<ContactModel>();
									break;
								case "Brand":
									req.SaveBrand();
									break;
								case "BrandImage":
									req.SaveBrandImage();
									break;
								case "Channel":
									req.SaveChannel();
									break;
								case "ChannelBrand":
									req.SaveChannelBrand();
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
								case "CustomerBankAccount":
									req.SaveCustomerBankAccount();
									break;
								case "CustomerBrand":
									req.SaveCustomerBrand();
									break;
								case "CustomerChannel":
									req.SaveCustomerChannel();
									break;
								case "CustomerContact":
									req.SaveCustomerContact();
									break;
								case "CustomerManager":
									req.SaveCustomerManager();
									break;
								case "CustomerStore":
									req.SaveCustomerStore();
									break;
								case "Partner":
									req.SavePartner();
									break;
								case "vBusiness":
									req.SavePartnerBusiness();
									break;
								case "PartnerAddress":
									req.SavePartnerAddress();
									break;
								case "PartnerBankAccount":
									req.SavePartnerBankAccount();
									break;
								case "PartnerBrand":
									req.SavePartnerBrand();
									break;
								case "PartnerChannel":
									req.SavePartnerChannel();
									break;
								case "PartnerContact":
									req.SavePartnerContact();
									break;
								case "PartnerManager":
									req.SavePartnerManager();
									break;
								case "PartnerStore":
									req.SavePartnerStore();
									break;
								case "ChannelOrder":
									if (req.SqlId.Equals("UpdateChannelOrderBrand"))
									{
										req.SaveChannelOrderBrand();
									}
									else if (req.SqlId.Equals("InsertChannelOrderToBizOrder"))
									{
										req.SaveChannelOrderToBizOrder();
									}
									else
									{
										req.SaveChannelOrder();
									}
									break;
								case "ChannelOrderCancel":
									req.SaveChannelOrderCancel();
									break;
								case "ChannelOrderReturn":
									req.SaveChannelOrderReturn();
									break;
								case "Order":
									req.SaveOrder();
									break;
								case "OrderItem":
									req.SaveData<OrderItemModel>();
									break;
								case "OrderNote":
									req.SaveData<OrderNoteModel>();
									break;
								case "OrderSumByChannel":
									req.SaveOrderSumByChannel();
									break;
								case "OrderSumByBrand":
									req.SaveOrderSumByBrand();
									break;
								case "Store":
									req.SaveStore();
									break;
								case "Company":
									req.SaveCompany();
									break;
								case "CompanyAddress":
									req.SaveCompanyAddress();
									break;
								case "CompanyBankAccount":
									req.SaveCompanyBankAccount();
									break;
								case "CompanyBusiness":
									req.SaveCompanyBusiness();
									break;
								case "CompanyContact":
									req.SaveCompanyContact();
									break;
								case "CompanyStore":
									req.SaveCompanyStore();
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
						if (req.SqlId == "DeleteCompanyAddress")
						{
							req.DeleteCompanyAddress();
						}
						else if (req.SqlId == "DeleteOrder")
						{
							req.DeleteOrder();
						}
						else
						{
							DaoFactory.InstanceBiz.Delete(req.SqlId, map);
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
	}
}
