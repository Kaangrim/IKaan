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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				DepartmentModel department = DaoFactory.InstanceBiz.QueryForObject<DepartmentModel>("SelectDepartment", parameter);
				if (department != null)
				{
					//부서이력
					parameter = new DataMap() { { "DepartmentID", department.ID } };
					IList<DepartmentHistModel> history = DaoFactory.InstanceBiz.QueryForList<DepartmentHistModel>("SelectDepartmentHistList", parameter);
					department.History = history;

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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				EmployeeModel employee = DaoFactory.InstanceBiz.QueryForObject<EmployeeModel>("SelectEmployee", parameter);
				if (employee != null)
				{
					//사람정보 가져오기
					parameter = new DataMap() { { "ID", employee.PersonID } };
					PersonModel person = DaoFactory.InstanceBiz.QueryForObject<PersonModel>("SelectPerson", parameter);
					employee.Person = person;

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
				DepartmentModel department = req.Data.JsonToAnyType<DepartmentModel>();
				department = req.SaveData<DepartmentModel>(department);
				if (department != null)
				{
					DataMap parameter = new DataMap()
					{
						{ "DepartmentID", department.ID },
						{ "StartDate", department.StartDate }
					};

					DepartmentHistModel equal = DaoFactory.InstanceBiz.QueryForObject<DepartmentHistModel>("SelectDepartmentHistEqual", parameter);
					if (equal != null)
					{
						//시작일이 동일한 경우 업데이트한다.
						equal.DepartmentName = department.DepartmentName;
						equal.ParentID = department.ParentID;
						equal.ManagerID = department.ManagerID;
						equal.UpdateBy = req.User.UserId;
						equal.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateDepartmentHist", equal);
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						DepartmentHistModel before = DaoFactory.InstanceBiz.QueryForObject<DepartmentHistModel>("SelectDepartmentHistBefore", parameter);
						if (before != null)
						{
							before.EndDate = department.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateDepartmentHistBefore", before);
						}

						//새로운 이력을 저장한다.
						DepartmentHistModel history = new DepartmentHistModel()
						{
							DepartmentID = department.ID,
							DepartmentName = department.DepartmentName,
							ParentID = department.ParentID,
							ManagerID = department.ManagerID,
							StartDate = department.StartDate,
							EndDate = null,
							CreateBy = req.User.UserId,
							CreateByName = req.User.UserName
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
				object personID = null;
				EmployeeModel employee = req.Data.JsonToAnyType<EmployeeModel>();

				if (employee != null)
				{
					if (employee.Person != null)
					{
						if (employee.PersonID != null)
						{
							employee.Person.ID = employee.PersonID;
							employee.Person.UpdateBy = req.User.UserId;
							employee.Person.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdatePerson", employee.Person);
							personID = employee.PersonID;
						}
						else
						{
							employee.Person.PersonType = "E";
							employee.Person.CreateBy = req.User.UserId;
							employee.Person.CreateByName = req.User.UserName;

							personID = DaoFactory.InstanceBiz.Insert("InsertPerson", employee.Person);
						}
					}

					employee.PersonID = personID.ToIntegerNullToNull();
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
				AppointmentModel appointment = req.Data.JsonToAnyType<AppointmentModel>();
				if (appointment != null)
				{
					DataMap parameter = new DataMap()
					{
						{ "EmployeeID", appointment.EmployeeID },
						{ "StartDate", appointment.StartDate }
					};

					AppointmentModel dup = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentDuplicate", parameter);
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

							appointment.UpdateBy = req.User.UserId;
							appointment.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAppointment", appointment);
							id = appointment.ID;
						}
					}
					else
					{
						//동일 시작일의 데이터가 없는 경우
						//직전 이력을 찾아서 종료일을 변경한 후 새로운 이력을 저장한다.
						AppointmentModel before = DaoFactory.InstanceBiz.QueryForObject<AppointmentModel>("SelectAppointmentBefore", parameter);
						if (before != null)
						{
							before.EndDate = appointment.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

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
							appointment.CreateBy = req.User.UserId;
							appointment.CreateByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertAppointment", appointment);
						}
						else
						{
							appointment.UpdateBy = req.User.UserId;
							appointment.UpdateByName = req.User.UserName;

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
			CategoryModel model = req.SaveData<CategoryModel>();
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

		public static IList<GoodsModel> GetGoodsList(DataMap parameter)
		{
			return DaoFactory.InstanceBiz.QueryForList<GoodsModel>("SelectGoodsList", parameter);
		}

		public static GoodsModel GetGoodsData(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				GoodsModel goods = DaoFactory.InstanceBiz.QueryForObject<GoodsModel>("SelectGoods", parameter);
				if (goods != null)
				{
					parameter = new DataMap()
					{
						{ "GoodsID", goods.ID },
						{ "CategoryID", goods.CategoryID }
					};

					//상품상세
					goods.Detail = DaoFactory.InstanceBiz.QueryForObject<GoodsDetailModel>("SelectGoodsDetail", parameter);
					if (goods.Detail == null)
						goods.Detail = new GoodsDetailModel();

					//상품 이미지
					goods.Image = DaoFactory.InstanceBiz.QueryForList<GoodsImageModel>("SelectGoodsImageList", parameter);
					if (goods.Image == null)
						goods.Image = new List<GoodsImageModel>();

					//상품 옵션
					goods.Item = DaoFactory.InstanceBiz.QueryForList<GoodsItemModel>("SelectGoodsItemList", parameter);
					if (goods.Item == null)
						goods.Item = new List<GoodsItemModel>();

					//정보고시
					goods.InfoNotice = DaoFactory.InstanceBiz.QueryForList<GoodsInfoNoticeModel>("SelectGoodsInfoNoticeByCategory", parameter);
					if (goods.InfoNotice == null)
						goods.InfoNotice = new List<GoodsInfoNoticeModel>();

					//상품속성
					goods.Attribute = DaoFactory.InstanceBiz.QueryForList<GoodsAttributeModel>("SelectGoodsAttributeList", parameter);
					if (goods.Attribute == null)
						goods.Attribute = new List<GoodsAttributeModel>();
				}
				req.Data = goods;
				req.Result.Count = 1;
				return goods;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveGoods(this WasRequest req)
		{
			try
			{
				GoodsModel model = req.Data.JsonToAnyType<GoodsModel>();

				if (model != null)
				{
					#region 상품 기본정보 저장
					if (model.ID.IsNullOrEmpty())
					{
						model.CreateBy = req.User.UserId;
						model.CreateByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertGoods", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdateBy = req.User.UserId;
						model.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateGoods", model);
					}
					#endregion

					#region 상품상세정보
					GoodsDetailModel detail = DaoFactory.InstanceBiz.QueryForObject<GoodsDetailModel>("SelectGoodsDetailList", new DataMap() { { "GoodsID", model.ID } });
					if (detail == null)
					{
						model.Detail.GoodsID = model.ID;
						model.Detail.CreateBy = req.User.UserId;
						model.Detail.CreateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Insert("InsertGoodsDetail", model.Detail);
					}
					else
					{
						model.Detail.UpdateBy = req.User.UserId;
						model.Detail.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateGoodsDetail", model.Detail);
					}
					#endregion

					#region 품목정보
					if (model.Item != null && model.Item.Count > 0)
					{
						foreach (GoodsItemModel item in model.Item)
						{
							if (item.ID.IsNullOrEmpty())
							{
								item.GoodsID = model.ID;
								item.CreateBy = req.User.UserId;
								item.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertGoodsItem", item);
							}
							else
							{
								GoodsItemModel old = DaoFactory.InstanceBiz.QueryForObject<GoodsItemModel>("SelectGoodsItem", new DataMap() { { "ID", item.ID } });
								if (old != null)
								{
									if (old.Option1Type != item.Option1Type ||
										old.Option1Name != item.Option1Name ||
										old.Option2Type != item.Option2Type ||
										old.Option2Name != item.Option2Name)
									{
										item.UpdateBy = req.User.UserId;
										item.UpdateByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateGoodsItem", item);
									}
								}
							}
						}
					}
					#endregion

					#region 속성저장
					if (model.Attribute != null && model.Attribute.Count > 0)
					{
						foreach (GoodsAttributeModel attr in model.Attribute)
						{
							if (attr.ID.IsNullOrEmpty())
							{
								attr.GoodsID = model.ID;
								attr.CreateBy = req.User.UserId;
								attr.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertGoodsAttribute", attr);
							}
							else
							{
								GoodsAttributeModel old = DaoFactory.InstanceBiz.QueryForObject<GoodsAttributeModel>("SelectGoodsAttribute", new DataMap() { { "ID", attr.ID } });
								if (old != null)
								{
									if (attr.AttrName.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteGoodsAttribute", new DataMap() { { "ID", attr.ID } });
									}
									else
									{
										if (old.AttrType != attr.AttrType ||
											old.AttrCode != attr.AttrCode ||
											old.AttrName != attr.AttrName)
										{
											attr.UpdateBy = req.User.UserId;
											attr.UpdateByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateGoodsAttribute", attr);
										}
									}
								}
							}
						}
					}
					#endregion

					#region 정보고시저장
					if (model.InfoNotice != null && model.InfoNotice.Count > 0)
					{
						foreach (GoodsInfoNoticeModel info in model.InfoNotice)
						{
							if (info.ID.IsNullOrEmpty())
							{
								if (info.InfoNoticeValue.IsNullOrEmpty() == false)
								{
									info.GoodsID = model.ID;
									info.CreateBy = req.User.UserId;
									info.CreateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Insert("InsertGoodsInfoNotice", info);
								}
							}
							else
							{
								GoodsInfoNoticeModel old = DaoFactory.InstanceBiz.QueryForObject<GoodsInfoNoticeModel>("SelectGoodsInfoNotice", new DataMap() { { "ID", info.ID } });

								if (old != null)
								{
									//정보고시값이 없으면 삭제한다.
									if (info.InfoNoticeValue.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteGoodsInfoNotice", new DataMap() { { "ID", info.ID } });
									}
									else
									{
										if (old.InfoNoticeItemID != info.InfoNoticeItemID ||
											old.InfoNoticeValue != info.InfoNoticeValue)
										{
											info.UpdateBy = req.User.UserId;
											info.UpdateByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateGoodsInfoNotice", info);
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

		public static void SaveGoodsImage(this WasRequest req)
		{
			try
			{
				GoodsModel model = req.Data.JsonToAnyType<GoodsModel>();

				if (model != null)
				{
					#region 이미지
					if (model.Image != null && model.Image.Count > 0)
					{
						foreach (GoodsImageModel image in model.Image)
						{
							if (image.ID.IsNullOrEmpty())
							{
								image.GoodsID = model.ID;
								image.CreateBy = req.User.UserId;
								image.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertGoodsImage", image);
							}
							else
							{
								GoodsImageModel old = DaoFactory.InstanceBiz.QueryForObject<GoodsImageModel>("SelectGoodsImage", new DataMap() { { "ID", image.ID } });
								if (old != null)
								{
									if (old.ImageType != image.ImageType ||
										old.ImageGroup != image.ImageGroup ||
										old.ImageUrl != image.ImageUrl)
									{
										image.UpdateBy = req.User.UserId;
										image.UpdateByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateGoodsImage", image);
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
						foreach (WasRequest req in list)
						{
							if (req.Data == null)
								throw new Exception("저장할 데이터가 존재하지 않습니다.");

							DataMap parameter = req.Data.JsonToAnyType<DataMap>();
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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				ChannelModel channel = DaoFactory.InstanceBiz.QueryForObject<ChannelModel>("SelectChannel", parameter);
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

					//채널, 연락처 매핑
					channel.Contacts = DaoFactory.InstanceBiz.QueryForList<ChannelContactModel>("SelectChannelContactList", parameter);
					if (channel.Contacts == null)
						channel.Contacts = new List<ChannelContactModel>();

					//채널, 매니저 매핑
					channel.Managers = DaoFactory.InstanceBiz.QueryForList<ChannelManagerModel>("SelectChannelManagerList", parameter);
					if (channel.Managers == null)
						channel.Managers = new List<ChannelManagerModel>();

					//채널, 설정 매핑
					IList<ChannelSettingModel> channelSettingList = DaoFactory.InstanceBiz.QueryForList<ChannelSettingModel>("SelectChannelSettingList", parameter);
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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BusinessModel business = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectBusiness", parameter);
				if (business != null)
				{
					//주소
					parameter = new DataMap() { { "ID", business.AddressID } };
					business.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", parameter);
					if (business.Address == null)
						business.Address = new AddressModel();

					//거래처목록
					parameter = new DataMap() { { "BusinessID", business.ID } };
					business.Customers = DaoFactory.InstanceBiz.QueryForList<CustomerBusinessModel>("SelectCustomerBusinessList", parameter);
					if (business.Customers == null)
						business.Customers = new List<CustomerBusinessModel>();
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
					customer.AddressList = DaoFactory.InstanceBiz.QueryForList<CustomerAddressModel>("SelectCustomerAddressList", parameter);
					if (customer.AddressList == null)
						customer.AddressList = new List<CustomerAddressModel>();

					//계좌
					customer.BankList = DaoFactory.InstanceBiz.QueryForList<CustomerBankModel>("SelectCustomerBankList", parameter);
					if (customer.BankList == null)
						customer.BankList = new List<CustomerBankModel>();

					//사업자
					customer.BusinessList = DaoFactory.InstanceBiz.QueryForList<CustomerBusinessModel>("SelectCustomerBusinessList", parameter);
					if (customer.BusinessList == null)
						customer.BusinessList = new List<CustomerBusinessModel>();

					//브랜드
					customer.BrandList = DaoFactory.InstanceBiz.QueryForList<CustomerBrandModel>("SelectCustomerBrandList", parameter);
					if (customer.BrandList == null)
						customer.BrandList = new List<CustomerBrandModel>();

					//채널
					customer.ChannelList = DaoFactory.InstanceBiz.QueryForList<CustomerChannelModel>("SelectCustomerChannelList", parameter);
					if (customer.ChannelList == null)
						customer.ChannelList = new List<CustomerChannelModel>();
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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				SearchBrandModel brand = DaoFactory.InstanceBiz.QueryForObject<SearchBrandModel>("SelectSearchBrand", parameter);
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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				CustomerBusinessModel customer = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusiness", parameter);
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
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				CustomerAddressModel customer = DaoFactory.InstanceBiz.QueryForObject<CustomerAddressModel>("SelectCustomerAddress", parameter);
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
				BrandModel brand = req.Data.JsonToAnyType<BrandModel>();
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

		public static void SaveBrandContact(this WasRequest req)
		{
			try
			{
				BrandContactModel contact = req.Data.JsonToAnyType<BrandContactModel>();
				if (contact != null)
				{
					PersonModel person = new PersonModel()
					{
						ID = contact.PersonID,
						PersonName = contact.PersonName,
						PersonType = "B",
						Email = contact.Email,
						PhoneNo1 = contact.PhoneNo1,
						PhoneNo2 = contact.PhoneNo2,
						FaxNo = contact.FaxNo
					};

					object contactID = null;
					object personID = null;

					if (person.ID == null)
					{
						person.CreateBy = req.User.UserId;
						person.CreateByName = req.User.UserName;

						personID = DaoFactory.InstanceBiz.Insert("InsertPerson", person);
					}
					else
					{
						person.UpdateBy = req.User.UserId;
						person.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdatePerson", person);
						personID = person.ID;
					}

					contact.PersonID = personID.ToIntegerNullToNull();

					if (contact.ID == null)
					{
						contact.CreateBy = req.User.UserId;
						contact.CreateByName = req.User.UserName;

						contactID = DaoFactory.InstanceBiz.Insert("InsertBrandContact", contact);
					}
					else
					{
						contact.UpdateBy = req.User.UserId;
						contact.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBrandContact", contact);
						contactID = contact.ID;
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

		public static void SaveBrandManager(this WasRequest req)
		{
			try
			{
				object id = null;
				BrandManagerModel manager = req.Data.JsonToAnyType<BrandManagerModel>();
				if (manager != null)
				{
					DataMap map = new DataMap()
					{
						{ "BrandID", manager.BrandID },
						{ "StartDate", manager.StartDate }
					};

					BrandManagerModel dup = DaoFactory.InstanceBiz.QueryForObject<BrandManagerModel>("SelectBrandManagerDuplicate", map);
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

							manager.UpdateBy = req.User.UserId;
							manager.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBrandManager", manager);
							id = manager.ID;
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<BrandManagerModel>("SelectBrandManagerBefore", map);
						if (before != null)
						{
							before.EndDate = manager.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBrandManagerEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<BrandManagerModel>("SelectBrandManagerAfter", map);
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
							manager.UpdateBy = req.User.UserId;
							manager.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBrandManager", manager);
							id = manager.ID;
						}
						else
						{
							manager.CreateBy = req.User.UserId;
							manager.CreateByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertBrandManager", manager);
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

		public static void SaveChannel(this WasRequest req)
		{
			try
			{
				ChannelModel channel = req.Data.JsonToAnyType<ChannelModel>();
				channel = req.SaveData<ChannelModel>(channel);

				if (channel != null)
				{
					IList<ChannelSettingModel> settingList = DaoFactory.InstanceBiz.QueryForList<ChannelSettingModel>("SelectChannelSettingList", new DataMap() { { "ChannelID", channel.ID } });
					if (settingList == null || settingList.Count == 0)
					{
						channel.Setting.ChannelID = channel.ID;
						channel.Setting.CreateBy = req.User.UserId;
						channel.Setting.CreateByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelSetting", channel.Setting);
						channel.Setting.ID = id.ToIntegerNullToNull();
					}
					else
					{
						channel.Setting.ID = settingList[0].ID;
						channel.Setting.UpdateBy = req.User.UserId;
						channel.Setting.UpdateByName = req.User.UserName;
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
				ChannelBrandModel model = req.Data.JsonToAnyType<ChannelBrandModel>();
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
						before.UpdateBy = req.User.UserId;
						before.UpdateByName = req.User.UserName;

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
						model.CreateBy = req.User.UserId;
						model.CreateByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelBrand", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdateBy = req.User.UserId;
						model.UpdateByName = req.User.UserName;

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

		public static void SaveChannelContact(this WasRequest req)
		{
			try
			{
				ChannelContactModel contact = req.Data.JsonToAnyType<ChannelContactModel>();
				if (contact != null)
				{
					PersonModel person = new PersonModel()
					{
						ID = contact.PersonID,
						PersonName = contact.PersonName,
						PersonType = "C",
						Email = contact.Email,
						PhoneNo1 = contact.PhoneNo1,
						PhoneNo2 = contact.PhoneNo2,
						FaxNo = contact.FaxNo
					};

					object contactID = null;
					object personID = null;

					if (person.ID == null)
					{
						person.CreateBy = req.User.UserId;
						person.CreateByName = req.User.UserName;

						personID = DaoFactory.InstanceBiz.Insert("InsertPerson", person);
					}
					else
					{
						person.UpdateBy = req.User.UserId;
						person.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdatePerson", person);
						personID = person.ID;
					}

					contact.PersonID = personID.ToIntegerNullToNull();

					if (contact.ID == null)
					{
						contact.CreateBy = req.User.UserId;
						contact.CreateByName = req.User.UserName;

						contactID = DaoFactory.InstanceBiz.Insert("InsertChannelContact", contact);
					}
					else
					{
						contact.UpdateBy = req.User.UserId;
						contact.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateChannelContact", contact);
						contactID = contact.ID;
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

		public static void SaveChannelManager(this WasRequest req)
		{
			try
			{
				object id = null;
				ChannelManagerModel manager = req.Data.JsonToAnyType<ChannelManagerModel>();
				if (manager != null)
				{
					DataMap map = new DataMap()
					{
						{ "ChannelID", manager.ChannelID },
						{ "StartDate", manager.StartDate }
					};

					BrandManagerModel dup = DaoFactory.InstanceBiz.QueryForObject<BrandManagerModel>("SelectChannelManagerDuplicate", map);
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

							manager.UpdateBy = req.User.UserId;
							manager.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateChannelManager", manager);
							id = manager.ID;
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<BrandManagerModel>("SelectChannelManagerBefore", map);
						if (before != null)
						{
							before.EndDate = manager.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateChannelManagerEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<BrandManagerModel>("SelectChannelManagerAfter", map);
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
							manager.UpdateBy = req.User.UserId;
							manager.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateChannelManager", manager);
							id = manager.ID;
						}
						else
						{
							manager.CreateBy = req.User.UserId;
							manager.CreateByName = req.User.UserName;

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
				BusinessModel model = req.Data.JsonToAnyType<BusinessModel>();
				if (model != null)
				{
					if (model.Address != null)
					{
						if (model.AddressID.IsNullOrDefault())
						{
							if (model.Address.PostalCode.IsNullOrEmpty() == false)
							{
								model.Address.CreateBy = req.User.UserId;
								model.Address.CreateByName = req.User.UserName;

								object id = DaoFactory.InstanceBiz.Insert("InsertAddress", model.Address);
								model.AddressID = id.ToIntegerNullToNull();
							}
						}
						else
						{
							model.Address.UpdateBy = req.User.UserId;
							model.Address.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateAddress", model.Address);
						}
					}

					if (model.ID.IsNullOrDefault())
					{
						model.CreateBy = req.User.UserId;
						model.CreateByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertBusiness", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdateBy = req.User.UserId;
						model.UpdateByName = req.User.UserName;

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
				CustomerModel customer = req.Data.JsonToAnyType<CustomerModel>();
				customer = req.SaveData<CustomerModel>(customer);

				if (customer != null)
				{
					//거래처 주소
					if (customer.AddressList != null && customer.AddressList.Count > 0)
					{
						foreach (var data in customer.AddressList)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreateBy = req.User.UserId;
								data.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerAddress", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerAddress", data);
								}
							}
						}
					}

					//거래처 계좌정보
					if (customer.BankList != null && customer.BankList.Count > 0)
					{
						foreach (var data in customer.BankList)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreateBy = req.User.UserId;
								data.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerBank", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerBank", data);
								}
							}
						}
					}

					//거래처 브랜드
					if (customer.BrandList != null && customer.BrandList.Count > 0)
					{
						foreach (var data in customer.BrandList)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreateBy = req.User.UserId;
								data.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerBrand", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateCustomerBrand", data);
								}
							}
						}
					}

					//거래처 채널
					if (customer.ChannelList != null && customer.ChannelList.Count > 0)
					{
						foreach (var data in customer.ChannelList)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.CustomerID = customer.ID;
								data.CreateBy = req.User.UserId;
								data.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertCustomerChannel", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

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

				CustomerBusinessModel customer = req.Data.JsonToAnyType<CustomerBusinessModel>();
				if (customer != null)
				{
					if (customer.Business != null)
					{
						if (customer.Business.Address != null)
						{
							if (customer.Business.AddressID.IsNullOrDefault())
							{
								customer.Business.Address.CreateBy = req.User.UserId;
								customer.Business.Address.CreateByName = req.User.UserName;

								addressId = DaoFactory.InstanceBiz.Insert("InsertAddress", customer.Business.Address);
								customer.Business.Address.ID = addressId.ToIntegerNullToNull();
								customer.Business.AddressID = customer.Business.Address.ID;
							}
							else
							{
								customer.Business.Address.ID = customer.Business.AddressID;
								customer.Business.Address.UpdateBy = req.User.UserId;
								customer.Business.Address.UpdateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Update("UpdateAddress", customer.Business.Address);
							}
						}

						if (customer.BusinessID.IsNullOrDefault())
						{
							customer.Business.CreateBy = req.User.UserId;
							customer.Business.CreateByName = req.User.UserName;

							businessId = DaoFactory.InstanceBiz.Insert("InsertBusiness", customer.Business);
							customer.Business.ID = businessId.ToIntegerNullToNull();
							customer.BusinessID = customer.Business.ID;
						}
						else
						{
							customer.Business.UpdateBy = req.User.UserId;
							customer.Business.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBusiness", customer.Business);
						}
					}

					//시작일, 종료일 이력을 체크하여 저장한다.
					//이력이 변경되는 건인 경우에는 직전 이력의 종료일을 -1로 설정한다.
					//직후 이력이 존재하는 경우에는 저장하는 데이터의 종료일을 직후 이력의 시작일 -1로 설정한다.
					DataMap map = new DataMap()
					{
						{ "CustomerID", customer.CustomerID },
						{ "StartDate", customer.StartDate }
					};

					CustomerBusinessModel dup = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusinessDuplicate", map);
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

							customer.UpdateBy = req.User.UserId;
							customer.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateCustomerBusiness", customer);
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusinessBefore", map);
						if (before != null)
						{
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;
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
							customer.CreateBy = req.User.UserId;
							customer.CreateByName = req.User.UserName;

							customerId = DaoFactory.InstanceBiz.Insert("InsertCustomerBusiness", customer);
							customer.ID = customerId.ToIntegerNullToNull();
						}
						else
						{
							customer.UpdateBy = req.User.UserId;
							customer.UpdateByName = req.User.UserName;

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

				CustomerAddressModel customer = req.Data.JsonToAnyType<CustomerAddressModel>();
				if (customer != null)
				{
					if (customer.AddressID.IsNullOrDefault())
					{
						if (customer.PostalCode.IsNullOrEmpty() == false)
						{
							AddressModel address = new AddressModel()
							{
								PostalCode = customer.PostalCode,
								Country = customer.Country,
								City = customer.City,
								StateProvince = customer.StateProvince,
								AddressLine1 = customer.AddressLine1,
								AddressLine2 = customer.AddressLine2,
								CreateBy = req.User.UserId,
								CreateByName = req.User.UserName
							};

							addressId = DaoFactory.InstanceBiz.Insert("InsertAddress", address);
							customer.AddressID = addressId.ToIntegerNullToNull();
						}
					}
					else
					{
						AddressModel address = new AddressModel()
						{
							ID = customer.AddressID,
							PostalCode = customer.PostalCode,
							Country = customer.Country,
							City = customer.City,
							StateProvince = customer.StateProvince,
							AddressLine1 = customer.AddressLine1,
							AddressLine2 = customer.AddressLine2,
							UpdateBy = req.User.UserId,
							UpdateByName = req.User.UserName
						};

						DaoFactory.InstanceBiz.Update("UpdateAddress", address);
					}

					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						customerId = DaoFactory.InstanceBiz.Insert("InsertCustomerAddress", customer);
						customer.ID = customerId.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

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

		public static void SaveCustomerBank(this WasRequest req)
		{
			try
			{
				object id = null;

				CustomerBankModel customer = req.Data.JsonToAnyType<CustomerBankModel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertCustomerBank", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateCustomerBank", customer);
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

				CustomerBrandModel customer = req.Data.JsonToAnyType<CustomerBrandModel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertCustomerBrand", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

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

				CustomerChannelModel customer = req.Data.JsonToAnyType<CustomerChannelModel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertCustomerChannel", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

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
				OrderSumByChannelModel model = req.Data.JsonToAnyType<OrderSumByChannelModel>();
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
									line.CreateBy = req.User.UserId;
									line.CreateByName = req.User.UserName;

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

									line.UpdateBy = req.User.UserId;
									line.UpdateByName = req.User.UserName;

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
									line.CreateBy = req.User.UserId;
									line.CreateByName = req.User.UserName;

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

									line.UpdateBy = req.User.UserId;
									line.UpdateByName = req.User.UserName;

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
