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
	public static class BizServicePartial
	{
		public static DepartmentModel GetDepartment(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var department = DaoFactory.InstanceBiz.QueryForObject<DepartmentModel>("SelectDepartment", parameter);
				if (department != null)
				{
					//부서이력
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					IList<DepartmentHistoryModel> history = DaoFactory.InstanceBiz.QueryForList<DepartmentHistoryModel>("SelectDepartmentHistList", parameter);
					department.Histories = history;

					//발령정보
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					IList<AppointmentModel> appointments = DaoFactory.InstanceBiz.QueryForList<AppointmentModel>("SelectAppointmentList", parameter);
					department.Appointments = appointments;
				}
				req.Data = department;
				req.Result.Count = 1;
				return department;
			}
			catch
			{
				throw;
			}
		}

		public static EmployeeModel GetEmployee(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var employee = DaoFactory.InstanceBiz.QueryForObject<EmployeeModel>("SelectEmployee", parameter);
				if (employee != null)
				{
					//발령정보 가져오기
					parameter = new DataMap() { { "EmployeeID", employee.ID } };
					IList<AppointmentModel> appointments = DaoFactory.InstanceBiz.QueryForList<AppointmentModel>("SelectAppointmentList", parameter);
					employee.Appointments = appointments;
				}
				req.Data = employee;
				req.Result.Count = 1;
				return employee;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveDepartment(this WasRequest req)
		{
			try
			{
				var department = req.Data.JsonToAnyType<DepartmentModel>();
				department = req.SaveData<DepartmentModel>(department);
				if (department != null)
				{
					var parameter = new DataMap()
					{
						{ "DepartmentID", department.ID },
						{ "StartDate", department.StartDate }
					};

					DepartmentHistoryModel equal = DaoFactory.InstanceBiz.QueryForObject<DepartmentHistoryModel>("SelectDepartmentHistEqual", parameter);
					if (equal != null)
					{
						//시작일이 동일한 경우 업데이트한다.
						equal.Name = department.Name;
						equal.ParentID = department.ParentID;
						equal.ManagerID = department.ManagerID;
						equal.UpdatedBy = req.User.UserId;
						equal.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateDepartmentHist", equal);
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						DepartmentHistoryModel before = DaoFactory.InstanceBiz.QueryForObject<DepartmentHistoryModel>("SelectDepartmentHistBefore", parameter);
						if (before != null)
						{
							before.EndDate = department.StartDate.Value.AddDays(-1);
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateDepartmentHistBefore", before);
						}

						//새로운 이력을 저장한다.
						var history = new DepartmentHistoryModel()
						{
							DepartmentID = department.ID,
							Name = department.Name,
							ParentID = department.ParentID,
							ManagerID = department.ManagerID,
							StartDate = department.StartDate,
							EndDate = null,
							CreatedBy = req.User.UserId,
							CreatedByName = req.User.UserName
						};
						DaoFactory.InstanceBiz.Insert("InsertDepartmentHist", history);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = department.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveEmployee(this WasRequest req)
		{
			try
			{
				var employee = req.Data.JsonToAnyType<EmployeeModel>();

				if (employee != null)
				{
					employee = req.SaveData<EmployeeModel>(employee);

					req.Result.Count = 1;
					req.Result.ReturnValue = employee.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveAppointment(this WasRequest req)
		{
			try
			{
				object id = null;
				var appointment = req.Data.JsonToAnyType<AppointmentModel>();
				if (appointment != null)
				{
					var parameter = new DataMap()
					{
						{ "EmployeeID", appointment.EmployeeID },
						{ "StartDate", appointment.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentDuplicate", parameter);
					if (dup != null)
					{
						if (appointment.ID == null)
						{
							throw new Exception("동일한 일자에 등록된 내역이 존재합니다.");
						}
						else
						{
							if (appointment.ID != dup.ID)
								throw new Exception("동일한 일자에 등록된 내역이 존재합니다.");

							appointment.UpdatedBy = req.User.UserId;
							appointment.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAppointment", appointment);
							id = appointment.ID;
						}
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						var before = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentBefore", parameter);
						if (before != null)
						{
							before.EndDate = appointment.StartDate.Value.AddDays(-1);
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAppointmentBefore", before);
						}

						//이후에 등록된 이력이 존재하는 경우 종료일을 이후 등록된 내역의 시작일 (-1)일로 설정한다.
						AppointmentModel after = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentAfter", parameter);
						if (after != null)
						{
							appointment.EndDate = after.StartDate.Value.AddDays(-1);
						}

						if (appointment.ID == null)
						{
							appointment.CreatedBy = req.User.UserId;
							appointment.CreatedByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertAppointment", appointment);
						}
						else
						{
							appointment.UpdatedBy = req.User.UserId;
							appointment.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAppointment", appointment);
							id = appointment.ID;
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = id;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCategory(this WasRequest req)
		{
			var model = req.SaveData<CategoryModel>();
			int? parentID = null;
			List<int?> catlist = new List<int?>();

			catlist.Add(model.ID);
			parentID = model.ParentID;
			while (parentID != null)
			{
				catlist.Add(parentID);
				var model2 = DaoFactory.InstanceBiz.QueryForObject<CategoryModel>("SelectCategory", new DataMap() { { "ID", parentID } });
				if (model2 != null && model2.ParentID != null)
					parentID = model2.ParentID;
				else
					parentID = null;
			}

			DataMap map = new DataMap();
			map.SetValue("ID", model.ID);
			for (int i = 0; i < catlist.Count; i++)
			{
				map.SetValue("Category" + (i + 1).ToString(), catlist[i]);
			}
			DaoFactory.InstanceBiz.Update("UpdateCategoryLevel", map);
		}

		public static void SaveInfoNoticeItem(this WasRequest req, InfoNoticeModel model)
		{
			try
			{
				foreach (var data in model.Items)
				{
					if (data.InfoNoticeID == null)
					{
						data.InfoNoticeID = model.ID;
					}
					req.SaveSubData<InfoNoticeItemModel>(data, false);
				}
			}
			catch
			{
				throw;
			}
		}

		public static IList<ProductModel> GetProductList(DataMap parameter)
		{
			return DaoFactory.InstanceBiz.QueryForList<ProductModel>("SelectProductList", parameter);
		}

		public static ProductModel GetProductData(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var Product = DaoFactory.InstanceBiz.QueryForObject<ProductModel>("SelectProduct", parameter);
				if (Product != null)
				{
					parameter = new DataMap()
					{
						{ "ProductID", Product.ID },
						{ "CategoryID", Product.CategoryID }
					};

					//상품상세
					Product.Description = DaoFactory.InstanceBiz.QueryForObject<ProductDescriptionModel>("SelectProductDescription", parameter);
					if (Product.Description == null)
						Product.Description = new ProductDescriptionModel();

					//상품 이미지
					Product.Images = DaoFactory.InstanceBiz.QueryForList<ProductImageModel>("SelectProductImageList", parameter);
					if (Product.Images == null)
						Product.Images = new List<ProductImageModel>();

					//상품 옵션
					Product.Items = DaoFactory.InstanceBiz.QueryForList<ProductItemModel>("SelectProductItemList", parameter);
					if (Product.Items == null)
						Product.Items = new List<ProductItemModel>();

					//정보고시
					Product.InfoNotices = DaoFactory.InstanceBiz.QueryForList<ProductInfoNoticeModel>("SelectProductInfoNoticeByCategory", parameter);
					if (Product.InfoNotices == null)
						Product.InfoNotices = new List<ProductInfoNoticeModel>();

					//상품속성
					Product.Attributes = DaoFactory.InstanceBiz.QueryForList<ProductAttributeModel>("SelectProductAttributeList", parameter);
					if (Product.Attributes == null)
						Product.Attributes = new List<ProductAttributeModel>();
				}
				req.Data = Product;
				req.Result.Count = 1;
				return Product;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveProduct(this WasRequest req)
		{
			try
			{
				ProductModel model = req.Data.JsonToAnyType<ProductModel>();

				if (model != null)
				{
					#region 상품 기본정보 저장
					if (model.ID.IsNullOrEmpty())
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertProduct", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateProduct", model);
					}
					#endregion

					#region 상품상세정보
					ProductDescriptionModel detail = DaoFactory.InstanceBiz.QueryForObject<ProductDescriptionModel>("SelectProductDetailList", new DataMap() { { "ProductID", model.ID } });
					if (detail == null)
					{
						model.Description.ProductID = model.ID;
						model.Description.CreatedBy = req.User.UserId;
						model.Description.CreatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Insert("InsertProductDetail", model.Description);
					}
					else
					{
						model.Description.UpdatedBy = req.User.UserId;
						model.Description.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateProductDetail", model.Description);
					}
					#endregion

					#region 품목정보
					if (model.Items != null && model.Items.Count > 0)
					{
						foreach (ProductItemModel item in model.Items)
						{
							if (item.ID.IsNullOrEmpty())
							{
								item.ProductID = model.ID;
								item.CreatedBy = req.User.UserId;
								item.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertProductItem", item);
							}
							else
							{
								ProductItemModel old = DaoFactory.InstanceBiz.QueryForObject<ProductItemModel>("SelectProductItem", new DataMap() { { "ID", item.ID } });
								if (old != null)
								{
									if (old.Option1Type != item.Option1Type ||
										old.Option1Name != item.Option1Name ||
										old.Option2Type != item.Option2Type ||
										old.Option2Name != item.Option2Name)
									{
										item.UpdatedBy = req.User.UserId;
										item.UpdatedByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateProductItem", item);
									}
								}
							}
						}
					}
					#endregion

					#region 속성저장
					if (model.Attributes != null && model.Attributes.Count > 0)
					{
						foreach (ProductAttributeModel attr in model.Attributes)
						{
							if (attr.ID.IsNullOrEmpty())
							{
								attr.ProductID = model.ID;
								attr.CreatedBy = req.User.UserId;
								attr.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertProductAttribute", attr);
							}
							else
							{
								ProductAttributeModel old = DaoFactory.InstanceBiz.QueryForObject<ProductAttributeModel>("SelectProductAttribute", new DataMap() { { "ID", attr.ID } });
								if (old != null)
								{
									if (attr.AttributeName.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteProductAttribute", new DataMap() { { "ID", attr.ID } });
									}
									else
									{
										if (old.AttributeTypeID != attr.AttributeTypeID ||
											old.AttributeID != attr.AttributeID ||
											old.AttributeName != attr.AttributeName)
										{
											attr.UpdatedBy = req.User.UserId;
											attr.UpdatedByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateProductAttribute", attr);
										}
									}
								}
							}
						}
					}
					#endregion

					#region 정보고시저장
					if (model.InfoNotices != null && model.InfoNotices.Count > 0)
					{
						foreach (var info in model.InfoNotices)
						{
							if (info.ID.IsNullOrEmpty())
							{
								if (info.InfoNoticeValue.IsNullOrEmpty() == false)
								{
									info.ProductID = model.ID;
									info.CreatedBy = req.User.UserId;
									info.CreatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Insert("InsertProductInfoNotice", info);
								}
							}
							else
							{
								var old = DaoFactory.InstanceBiz.QueryForObject<ProductInfoNoticeModel>("SelectProductInfoNotice", new DataMap() { { "ID", info.ID } });

								if (old != null)
								{
									//정보고시값이 없으면 삭제한다.
									if (info.InfoNoticeValue.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteProductInfoNotice", new DataMap() { { "ID", info.ID } });
									}
									else
									{
										if (old.InfoNoticeItemID != info.InfoNoticeItemID ||
											old.InfoNoticeValue != info.InfoNoticeValue)
										{
											info.UpdatedBy = req.User.UserId;
											info.UpdatedByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateProductInfoNotice", info);
										}
									}
								}
							}
						}
					}
					#endregion
				}

				req.Result.ReturnValue = model.ID;
				req.Result.Count = 1;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveProductImage(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ProductModel>();

				if (model != null)
				{
					#region 이미지
					if (model.Images != null && model.Images.Count > 0)
					{
						foreach (var image in model.Images)
						{
							if (image.ID.IsNullOrEmpty())
							{
								image.ProductID = model.ID;
								image.CreatedBy = req.User.UserId;
								image.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertProductImage", image);
							}
							else
							{
								var old = DaoFactory.InstanceBiz.QueryForObject<ProductImageModel>("SelectProductImage", new DataMap() { { "ID", image.ID } });
								if (old != null)
								{
									if (old.ImageType != image.ImageType ||
										old.ImageGroup != image.ImageGroup ||
										old.ImageID != image.ImageID)
									{
										image.UpdatedBy = req.User.UserId;
										image.UpdatedByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateProductImage", image);
									}
								}
							}
						}
					}
					#endregion
				}

				req.Result.ReturnValue = model.ID;
				req.Result.Count = 1;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static WasRequest SavePersonImageUrl(WasRequest request)
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
						foreach (var req in list)
						{
							if (req.Data == null)
								throw new Exception("저장할 데이터가 존재하지 않습니다.");

							var parameter = req.Data.JsonToAnyType<DataMap>();
							DaoFactory.InstanceBiz.Update("UpdatePersonImageUrl", parameter);
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

		public static ChannelModel GetChannelData(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var channel = DaoFactory.InstanceBiz.QueryForObject<ChannelModel>("SelectChannel", parameter);
				if (channel != null)
				{
					//채널, 브랜드 매핑
					channel.Brands = DaoFactory.InstanceBiz.QueryForList<ChannelBrandModel>("SelectChannelBrandList", parameter);
					if (channel.Brands == null)
						channel.Brands = new List<ChannelBrandModel>();

					//거래처, 채널 매핑
					channel.Customers = DaoFactory.InstanceBiz.QueryForList<CustomerChannelModel>("SelectCustomerChannelList", parameter);
					if (channel.Customers == null)
						channel.Customers = new List<CustomerChannelModel>();

					//채널, 설정 매핑
					var channelSettingList = DaoFactory.InstanceBiz.QueryForList<ChannelSettingModel>("SelectChannelSettingList", parameter);
					if (channelSettingList == null || channelSettingList.Count == 0)
						channel.Setting = new ChannelSettingModel();
					else
						channel.Setting = channelSettingList[0];
				}
				req.Data = channel;
				req.Result.Count = 1;
				return channel;
			}
			catch
			{
				throw;
			}

		}

		public static BusinessModel GetBusiness(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var business = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectBusiness", parameter);
				if (business != null)
				{
					//주소
					parameter = new DataMap() { { "ID", business.AddressID } };
					business.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", parameter);
					if (business.Address == null)
						business.Address = new AddressModel();

					//거래처목록
					parameter = new DataMap() { { "BusinessID", business.ID } };
					business.Links = DaoFactory.InstanceBiz.QueryForList<BusinessLinksModel>("SelectBusinessLinks", parameter);
					if (business.Links == null)
						business.Links = new List<BusinessLinksModel>();
				}
				req.Data = business;
				req.Result.Count = 1;
				return business;
			}
			catch
			{
				throw;
			}
		}

		public static CustomerModel GetCustomer(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				CustomerModel customer = DaoFactory.InstanceBiz.QueryForObject<CustomerModel>("SelectCustomer", parameter);
				if (customer != null)
				{
					parameter = new DataMap() { { "CustomerID", customer.ID } };

					//주소
					customer.Addresses = DaoFactory.InstanceBiz.QueryForList<CustomerAddressModel>("SelectCustomerAddressList", parameter);
					if (customer.Addresses == null)
						customer.Addresses = new List<CustomerAddressModel>();

					//계좌
					customer.BankAccounts = DaoFactory.InstanceBiz.QueryForList<CustomerBankAccountModel>("SelectCustomerBankList", parameter);
					if (customer.BankAccounts == null)
						customer.BankAccounts = new List<CustomerBankAccountModel>();

					//사업자
					customer.Businesses = DaoFactory.InstanceBiz.QueryForList<CustomerBusinessModel>("SelectCustomerBusinessList", parameter);
					if (customer.Businesses == null)
						customer.Businesses = new List<CustomerBusinessModel>();

					//브랜드
					customer.Brands = DaoFactory.InstanceBiz.QueryForList<CustomerBrandModel>("SelectCustomerBrandList", parameter);
					if (customer.Brands == null)
						customer.Brands = new List<CustomerBrandModel>();

					//채널
					customer.Channels = DaoFactory.InstanceBiz.QueryForList<CustomerChannelModel>("SelectCustomerChannelList", parameter);
					if (customer.Channels == null)
						customer.Channels = new List<CustomerChannelModel>();
				}
				req.Data = customer;
				req.Result.Count = 1;
				return customer;
			}
			catch
			{
				throw;
			}
		}

		public static SearchBrandModel GetSearchBrand(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var brand = DaoFactory.InstanceBiz.QueryForObject<SearchBrandModel>("SelectSearchBrand", parameter);
				if (brand != null)
				{
					parameter = new DataMap() { { "SearchBrandID", brand.ID } };

					//주소
					brand.Activities = DaoFactory.InstanceBiz.QueryForList<SearchBrandActivityModel>("SelectSearchBrandActivityList", parameter);
					if (brand.Activities == null)
						brand.Activities = new List<SearchBrandActivityModel>();
				}
				req.Data = brand;
				req.Result.Count = 1;
				return brand;
			}
			catch
			{
				throw;
			}
		}

		public static CustomerBusinessModel GetCustomerBusiness(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var customer = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusiness", parameter);
				if (customer != null)
				{
					//사업자
					parameter = new DataMap() { { "ID", customer.BusinessID } };
					customer.Business = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectBusiness", parameter);

					//주소
					if (customer.Business != null)
					{
						parameter = new DataMap() { { "ID", customer.Business.AddressID } };
						customer.Business.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", parameter);
					}
				}
				req.Data = customer;
				req.Result.Count = 1;
				return customer;
			}
			catch
			{
				throw;
			}
		}

		public static CustomerAddressModel GetCustomerAddress(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var customer = DaoFactory.InstanceBiz.QueryForObject<CustomerAddressModel>("SelectCustomerAddress", parameter);
				req.Data = customer;
				req.Result.Count = 1;
				return customer;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveBrand(this WasRequest req)
		{
			try
			{
				var brand = req.Data.JsonToAnyType<BrandModel>();
				brand = req.SaveData<BrandModel>(brand);

				if (brand != null)
				{
					req.Result.Count = 1;
					req.Result.ReturnValue = brand.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}
		
		public static void SaveChannel(this WasRequest req)
		{
			try
			{
				var channel = req.Data.JsonToAnyType<ChannelModel>();
				channel = req.SaveData<ChannelModel>(channel);

				if (channel != null)
				{
					var settingList = DaoFactory.InstanceBiz.QueryForList<ChannelSettingModel>("SelectChannelSettingList", new DataMap() { { "ChannelID", channel.ID } });
					if (settingList == null || settingList.Count == 0)
					{
						channel.Setting.ChannelID = channel.ID;
						channel.Setting.CreatedBy = req.User.UserId;
						channel.Setting.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelSetting", channel.Setting);
						channel.Setting.ID = id.ToIntegerNullToNull();
					}
					else
					{
						channel.Setting.ID = settingList[0].ID;
						channel.Setting.UpdatedBy = req.User.UserId;
						channel.Setting.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateChannelSetting", channel.Setting);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = channel.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveChannelBrand(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ChannelBrandModel>();
				if (model != null)
				{
					DataMap parameter = new DataMap()
					{
						{ "ChannelID", model.ChannelID },
						{ "BrandID", model.BrandID },
						{ "StartDate", model.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<ChannelBrandModel>("SelectChannelBrandDuplicate", parameter);
					if (dup != null)
					{
						if (model.ID.IsNullOrDefault())
						{
							throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");
						}
						else
						{
							if (model.ID != dup.ID)
								throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");
						}
					}

					var before = DaoFactory.InstanceBiz.QueryForObject<ChannelBrandModel>("SelectChannelBrandBefore", parameter);
					if (before != null)
					{
						before.EndDate = model.StartDate.Value.AddDays(-1);
						before.UpdatedBy = req.User.UserId;
						before.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateChannelBrand", before);
					}

					var after = DaoFactory.InstanceBiz.QueryForObject<ChannelBrandModel>("SelectChannelBrandAfter", parameter);
					if (after != null)
					{
						model.EndDate = after.StartDate.Value.AddDays(-1);
					}
					else
					{
						model.EndDate = null;
					}

					if (model.ID.IsNullOrDefault())
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelBrand", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateChannelBrand", model);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = model.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerContact(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CustomerContactModel>();
				if (model != null)
				{
					var contact = new ContactModel()
					{
						ID = model.ContactID,
						Name = model.ContactName,
						ContactType = "C",
						Email = model.Email,
						PhoneNo = model.PhoneNo,
						MobileNo = model.MobileNo,
						FaxNo = model.FaxNo
					};

					object contactID = null;

					if (contact.ID == null)
					{
						contact.CreatedBy = req.User.UserId;
						contact.CreatedByName = req.User.UserName;

						contactID = DaoFactory.InstanceBiz.Insert("InsertContact", contact);
					}
					else
					{
						contact.UpdatedBy = req.User.UserId;
						contact.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateContact", contact);
						contactID = contact.ID;
					}

					model.ContactID = contactID.ToIntegerNullToNull();

					if (model.ID == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						contactID = DaoFactory.InstanceBiz.Insert("InsertCustomerContact", model);
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateCustomerContact", model);
						contactID = model.ID;
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = contactID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerManager(this WasRequest req)
		{
			try
			{
				object id = null;
				var manager = req.Data.JsonToAnyType<CustomerManagerModel>();
				if (manager != null)
				{
					DataMap map = new DataMap()
					{
						{ "CustomerID", manager.CustomerID },
						{ "StartDate", manager.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<PartnerManagerModel>("SelectCustomerManagerDuplicate", map);
					if (dup != null)
					{
						if (manager.ID == null)
						{
							throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");
						}
						else
						{
							if (manager.ID != dup.ID)
								throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");

							manager.UpdatedBy = req.User.UserId;
							manager.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateCustomerManager", manager);
							id = manager.ID;
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<PartnerManagerModel>("SelectCustomerManagerBefore", map);
						if (before != null)
						{
							before.EndDate = manager.StartDate.Value.AddDays(-1);
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateCustomerManagerEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<PartnerManagerModel>("SelectCustomerManagerAfter", map);
						if (after != null)
						{
							manager.EndDate = after.StartDate.Value.AddDays(-1);
						}
						else
						{
							manager.EndDate = null;
						}

						if (manager.ID != null)
						{
							manager.UpdatedBy = req.User.UserId;
							manager.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateCustomerManager", manager);
							id = manager.ID;
						}
						else
						{
							manager.CreatedBy = req.User.UserId;
							manager.CreatedByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertChannelManager", manager);
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = id;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveBusiness(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<BusinessModel>();
				if (model != null)
				{
					if (model.Address != null)
					{
						if (model.AddressID.IsNullOrDefault())
						{
							if (model.Address.PostalCode.IsNullOrEmpty() == false)
							{
								model.Address.CreatedBy = req.User.UserId;
								model.Address.CreatedByName = req.User.UserName;

								object id = DaoFactory.InstanceBiz.Insert("InsertAddress", model.Address);
								model.AddressID = id.ToIntegerNullToNull();
							}
						}
						else
						{
							model.Address.UpdatedBy = req.User.UserId;
							model.Address.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAddress", model.Address);
						}
					}

					if (model.ID.IsNullOrDefault())
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertBusiness", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBusiness", model);
					}

					req.Result.ReturnValue = model.ID;
					req.Result.Count = 1;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomer(this WasRequest req)
		{
			try
			{
				var customer = req.Data.JsonToAnyType<CustomerModel>();
				customer = req.SaveData<CustomerModel>(customer);

				if (customer != null)
				{
					//거래처 주소
					if (customer.Addresses != null && customer.Addresses.Count > 0)
					{
						foreach (var data in customer.Addresses)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerAddress", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerAddress", data);
								}
							}
						}
					}

					//거래처 계좌정보
					if (customer.BankAccounts != null && customer.BankAccounts.Count > 0)
					{
						foreach (var data in customer.BankAccounts)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerBankAccount", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerBankAccount", data);
								}
							}
						}
					}

					//거래처 브랜드
					if (customer.Brands != null && customer.Brands.Count > 0)
					{
						foreach (var data in customer.Brands)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerBrand", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerBrand", data);
								}
							}
						}
					}

					//거래처 채널
					if (customer.Channels != null && customer.Channels.Count > 0)
					{
						foreach (var data in customer.Channels)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerChannel", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerChannel", data);
								}
							}
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = customer.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerBusiness(this WasRequest req)
		{
			try
			{
				object customerId = null;
				object addressId = null;
				object businessId = null;

				var customer = req.Data.JsonToAnyType<CustomerBusinessModel>();
				if (customer != null)
				{
					if (customer.Business != null)
					{
						if (customer.Business.Address != null)
						{
							if (customer.Business.AddressID.IsNullOrDefault())
							{
								customer.Business.Address.CreatedBy = req.User.UserId;
								customer.Business.Address.CreatedByName = req.User.UserName;

								addressId = DaoFactory.InstanceBiz.Insert("InsertAddress", customer.Business.Address);
								customer.Business.Address.ID = addressId.ToIntegerNullToNull();
								customer.Business.AddressID = customer.Business.Address.ID;
							}
							else
							{
								customer.Business.Address.ID = customer.Business.AddressID;
								customer.Business.Address.UpdatedBy = req.User.UserId;
								customer.Business.Address.UpdatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Update("UpdateAddress", customer.Business.Address);
							}
						}

						if (customer.BusinessID.IsNullOrDefault())
						{
							customer.Business.CreatedBy = req.User.UserId;
							customer.Business.CreatedByName = req.User.UserName;

							businessId = DaoFactory.InstanceBiz.Insert("InsertBusiness", customer.Business);
							customer.Business.ID = businessId.ToIntegerNullToNull();
							customer.BusinessID = customer.Business.ID;
						}
						else
						{
							customer.Business.UpdatedBy = req.User.UserId;
							customer.Business.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBusiness", customer.Business);
						}
					}

					//시작일, 종료일 이력을 체크하여 저장한다.
					//이력이 변경되는 건인 경우에는 직전 이력의 종료일을 -1로 설정한다.
					//직후 이력이 존재하는 경우에는 저장하는 데이터의 종료일을 직후 이력의 시작일 -1로 설정한다.
					var map = new DataMap()
					{
						{ "CustomerID", customer.CustomerID },
						{ "StartDate", customer.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusinessDuplicate", map);
					if (dup != null)
					{
						if (customer.ID.IsNullOrDefault())
						{
							throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");
						}
						else
						{
							if (customer.ID != dup.ID)
								throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");

							customer.UpdatedBy = req.User.UserId;
							customer.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateCustomerBusiness", customer);
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusinessBefore", map);
						if (before != null)
						{
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;
							before.EndDate = customer.StartDate.Value.AddDays(-1);

							DaoFactory.InstanceBiz.Update("UpdateCustomerBusinessEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusinessAfter", map);
						if (after != null)
						{
							customer.EndDate = after.StartDate.Value.AddDays(-1);
						}

						if (customer.ID.IsNullOrDefault())
						{
							customer.CreatedBy = req.User.UserId;
							customer.CreatedByName = req.User.UserName;

							customerId = DaoFactory.InstanceBiz.Insert("InsertCustomerBusiness", customer);
							customer.ID = customerId.ToIntegerNullToNull();
						}
						else
						{
							customer.UpdatedBy = req.User.UserId;
							customer.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateCustomerBusiness", customer);
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = customer.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerAddress(this WasRequest req)
		{
			try
			{
				object customerId = null;
				object addressId = null;

				var customer = req.Data.JsonToAnyType<CustomerAddressModel>();
				if (customer != null)
				{
					if (customer.AddressID.IsNullOrDefault())
					{
						if (customer.Address.PostalCode.IsNullOrEmpty() == false)
						{
							var address = new AddressModel()
							{
								PostalCode = customer.Address.PostalCode,
								Country = customer.Address.Country,
								City = customer.Address.City,
								StateProvince = customer.Address.StateProvince,
								AddressLine1 = customer.Address.AddressLine1,
								AddressLine2 = customer.Address.AddressLine2,
								CreatedBy = req.User.UserId,
								CreatedByName = req.User.UserName
							};

							addressId = DaoFactory.InstanceBiz.Insert("InsertAddress", address);
							customer.AddressID = addressId.ToIntegerNullToNull();
						}
					}
					else
					{
						var address = new AddressModel()
						{
							ID = customer.AddressID,
							PostalCode = customer.Address.PostalCode,
							Country = customer.Address.Country,
							City = customer.Address.City,
							StateProvince = customer.Address.StateProvince,
							AddressLine1 = customer.Address.AddressLine1,
							AddressLine2 = customer.Address.AddressLine2,
							UpdatedBy = req.User.UserId,
							UpdatedByName = req.User.UserName
						};

						DaoFactory.InstanceBiz.Update("UpdateAddress", address);
					}

					if (customer.ID.IsNullOrDefault())
					{
						customer.CreatedBy = req.User.UserId;
						customer.CreatedByName = req.User.UserName;

						customerId = DaoFactory.InstanceBiz.Insert("InsertCustomerAddress", customer);
						customer.ID = customerId.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdatedBy = req.User.UserId;
						customer.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateCustomerAddress", customer);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = customer.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerBankAccount(this WasRequest req)
		{
			try
			{
				object id = null;

				var customer = req.Data.JsonToAnyType<CustomerBankAccountModel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreatedBy = req.User.UserId;
						customer.CreatedByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertCustomerBankAccount", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdatedBy = req.User.UserId;
						customer.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateCustomerBankAccount", customer);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = customer.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerBrand(this WasRequest req)
		{
			try
			{
				object id = null;

				var customer = req.Data.JsonToAnyType<CustomerBrandModel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreatedBy = req.User.UserId;
						customer.CreatedByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertCustomerBrand", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdatedBy = req.User.UserId;
						customer.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateCustomerBrand", customer);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = customer.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveCustomerChannel(this WasRequest req)
		{
			try
			{
				object id = null;

				var customer = req.Data.JsonToAnyType<CustomerChannelModel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreatedBy = req.User.UserId;
						customer.CreatedByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertCustomerChannel", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdatedBy = req.User.UserId;
						customer.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateCustomerChannel", customer);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = customer.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveOrderSumByChannel(this WasRequest req)
		{
			try
			{
				int count = 0;
				var model = req.Data.JsonToAnyType<OrderSumByChannelModel>();
				if (model != null)
				{
					if (model.OrderSumList != null && model.OrderSumList.Count > 0)
					{
						foreach (var line in model.OrderSumList)
						{
							line.ChannelID = model.ChannelID;
							line.OrderDate = model.OrderDate;

							DataMap map = new DataMap()
							{
								{ "ChannelID", line.ChannelID },
								{ "BrandID", line.BrandID },
								{ "OrderDate", line.OrderDate }
							};

							var dup = DaoFactory.InstanceBiz.QueryForObject<OrderSumModel>("SelectOrderSumDuplicate", map);
							if (dup == null)
							{
								if (line.OrderQty != 0 || line.OrderAmt != 0)
								{
									line.CreatedBy = req.User.UserId;
									line.CreatedByName = req.User.UserName;

									object id = DaoFactory.InstanceBiz.Insert("InsertOrderSum", line);
									line.ID = id.ToIntegerNullToNull();
									count++;
								}
							}
							else
							{
								if (line.OrderQty != dup.OrderQty || line.OrderAmt != dup.OrderAmt)
								{
									if (line.ID.IsNullOrDefault())
										line.ID = dup.ID;

									line.UpdatedBy = req.User.UserId;
									line.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateOrderSum", line);
									count++;
								}
							}
						}
					}

					req.Result.Count = count;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SaveOrderSumByBrand(this WasRequest req)
		{
			try
			{
				int count = 0;
				OrderSumByBrandModel model = req.Data.JsonToAnyType<OrderSumByBrandModel>();
				if (model != null)
				{
					if (model.OrderSumList != null && model.OrderSumList.Count > 0)
					{
						foreach (var line in model.OrderSumList)
						{
							line.BrandID = model.BrandID;
							line.OrderDate = model.OrderDate;

							DataMap map = new DataMap()
							{
								{ "ChannelID", line.ChannelID },
								{ "BrandID", line.BrandID },
								{ "OrderDate", line.OrderDate }
							};

							var dup = DaoFactory.InstanceBiz.QueryForObject<OrderSumModel>("SelectOrderSumDuplicate", map);
							if (dup == null)
							{
								if (line.OrderQty != 0 || line.OrderAmt != 0)
								{
									line.CreatedBy = req.User.UserId;
									line.CreatedByName = req.User.UserName;

									object id = DaoFactory.InstanceBiz.Insert("InsertOrderSum", line);
									line.ID = id.ToIntegerNullToNull();
									count++;
								}
							}
							else
							{
								if (line.OrderQty != dup.OrderQty || line.OrderAmt != dup.OrderAmt)
								{
									if (line.ID.IsNullOrDefault())
										line.ID = dup.ID;

									line.UpdatedBy = req.User.UserId;
									line.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateOrderSum", line);
									count++;
								}
							}
						}
					}

					req.Result.Count = count;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}
		
	}
}
