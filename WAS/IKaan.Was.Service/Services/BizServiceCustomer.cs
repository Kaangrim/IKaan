using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceCustomer
	{
		public static CustomerModel GetCustomer(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CustomerModel>("SelectCustomer", parameter);
				if (model != null)
				{
					parameter = new DataMap() { { "CustomerID", model.ID } };

					//현재 사업자 정보
					model.CurrentBusiness = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectCustomerBusinessCurrent", parameter);
					if (model.CurrentBusiness == null)
						model.CurrentBusiness = new BusinessModel();

					if (model.CurrentBusiness.AddressID != null)
					{
						model.CurrentBusiness.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", new DataMap() { { "ID", model.CurrentBusiness.AddressID } });
						if (model.CurrentBusiness.Address == null)
							model.CurrentBusiness.Address = new AddressModel();
					}

					//주소
					model.Addresses = DaoFactory.InstanceBiz.QueryForList<CustomerAddressModel>("SelectCustomerAddressList", parameter);
					if (model.Addresses == null)
						model.Addresses = new List<CustomerAddressModel>();

					//계좌
					model.BankAccounts = DaoFactory.InstanceBiz.QueryForList<CustomerBankAccountModel>("SelectCustomerBankAccountList", parameter);
					if (model.BankAccounts == null)
						model.BankAccounts = new List<CustomerBankAccountModel>();

					//사업자
					model.Businesses = DaoFactory.InstanceBiz.QueryForList<CustomerBusinessModel>("SelectCustomerBusinessList", parameter);
					if (model.Businesses == null)
						model.Businesses = new List<CustomerBusinessModel>();

					//브랜드
					model.Brands = DaoFactory.InstanceBiz.QueryForList<CustomerBrandModel>("SelectCustomerBrandList", parameter);
					if (model.Brands == null)
						model.Brands = new List<CustomerBrandModel>();

					//채널
					model.Channels = DaoFactory.InstanceBiz.QueryForList<CustomerChannelModel>("SelectCustomerChannelList", parameter);
					if (model.Channels == null)
						model.Channels = new List<CustomerChannelModel>();

					//담당자
					model.Contacts = DaoFactory.InstanceBiz.QueryForList<CustomerContactModel>("SelectCustomerContactList", parameter);
					if (model.Contacts == null)
						model.Contacts = new List<CustomerContactModel>();

					//매니저
					model.Managers = DaoFactory.InstanceBiz.QueryForList<CustomerManagerModel>("SelectCustomerManagerList", parameter);
					if (model.Managers == null)
						model.Managers = new List<CustomerManagerModel>();
				}
				req.Data = model;
				req.Result.Count = 1;
				return model;
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
				var model = DaoFactory.InstanceBiz.QueryForObject<CustomerBusinessModel>("SelectCustomerBusiness", parameter);
				if (model != null)
				{
					//사업자
					model.Business = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectBusiness", new DataMap() { { "ID", model.BusinessID } });
					if (model.Business == null)
						model.Business = new BusinessModel();

					//주소
					model.Business.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", new DataMap() { { "ID", model.Business.AddressID } });
					if (model.Business.Address == null)
						model.Business.Address = new AddressModel();

					//이미지
					model.Business.Image = DaoFactory.InstanceBiz.QueryForObject<ImageModel>("SelectImage", new DataMap() { { "ID", model.Business.ImageID } });
					if (model.Business.Image == null)
						model.Business.Image = new ImageModel();

				}
				req.Data = model;
				req.Result.Count = 1;
				return model;
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

		public static CustomerContactModel GetCustomerContact(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CustomerContactModel>("SelectCustomerContact", parameter);
				if (model != null)
				{
					//담당자
					model.Contact = DaoFactory.InstanceBiz.QueryForObject<ContactModel>("SelectContact", new DataMap() { { "ID", model.ContactID } });
					if (model.Contact == null)
						model.Contact = new ContactModel();

				}
				req.Data = model;
				req.Result.Count = 1;
				return model;
			}
			catch
			{
				throw;
			}
		}

		public static CustomerBankAccountModel GetCustomerBankAccount(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CustomerBankAccountModel>("SelectCustomerBankAccount", parameter);
				if (model != null)
				{
					//계좌정보
					model.Image = DaoFactory.InstanceBiz.QueryForObject<ImageModel>("SelectImage", new DataMap() { { "ID", model.ImageID } });
					if (model.Image == null)
						model.Image = new ImageModel();

				}
				req.Data = model;
				req.Result.Count = 1;
				return model;
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

						var imageID = customer.Business.ImageID;
						if (Regex.IsMatch(customer.Business.Image.RowState.ToStringNullToEmpty().ToUpper(), "INSERT|UPDATE"))
						{
							if (imageID == null)
							{
								customer.Business.Image.CreatedBy = req.User.UserId;
								customer.Business.Image.CreatedByName = req.User.UserName;
								var id = DaoFactory.InstanceBiz.Insert("InsertImage", customer.Business.Image);
								customer.Business.Image.ID = id.ToIntegerNullToNull();
								customer.Business.ImageID = id.ToIntegerNullToNull();
							}
							else
							{
								customer.Business.Image.ID = customer.Business.ImageID;
								customer.Business.Image.UpdatedBy = req.User.UserId;
								customer.Business.Image.UpdatedByName = req.User.UserName;
								DaoFactory.InstanceBiz.Update("UpdateImage", customer.Business.Image);
							}
						}
						else if (customer.Business.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
						{
							customer.Business.ImageID = null;
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

							if (imageID != null && customer.Business.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
							{
								DaoFactory.InstanceBiz.Delete("DeleteImage", new DataMap() { { "ID", imageID } });
							}
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
				var model = req.Data.JsonToAnyType<CustomerBankAccountModel>();
				var bankaccount = new BankAccountModel()
				{
					Name = model.BankAccountName,
					BankName = model.BankName,
					AccountNo = model.AccountNo,
					Depositor = model.Depositor,
					ImageID = model.ImageID
				};

				var imageID = model.ImageID;
				if (Regex.IsMatch(model.Image.RowState.ToStringNullToEmpty().ToUpper(), "INSERT|UPDATE"))
				{
					if (imageID == null)
					{
						model.Image.CreatedBy = req.User.UserId;
						model.Image.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertImage", model.Image);
						model.Image.ID = id.ToIntegerNullToNull();
						model.ImageID = id.ToIntegerNullToNull();
						bankaccount.ImageID = id.ToIntegerNullToNull();
					}
					else
					{
						model.Image.ID = model.ImageID;
						model.Image.UpdatedBy = req.User.UserId;
						model.Image.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateImage", model.Image);
					}
				}
				else if (model.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
				{
					model.ImageID = null;
					bankaccount.ImageID = null;
				}

				if (bankaccount != null)
				{
					if (model.BankAccountID == null)
					{
						bankaccount.CreatedBy = req.User.UserId;
						bankaccount.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertBankAccount", bankaccount);
						bankaccount.ID = id.ToIntegerNullToNull();
					}
					else
					{
						bankaccount.UpdatedBy = req.User.UserId;
						bankaccount.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateBankAccount", bankaccount);

						if (imageID != null && model.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
						{
							DaoFactory.InstanceBiz.Delete("DeleteImage", new DataMap() { { "ID", imageID } });
						}
					}
					model.BankAccountID = bankaccount.ID;
				}

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCustomerBankAccount", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCustomerBankAccount", model);
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
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

		public static void SaveCustomerStore(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CustomerStoreModel>();

				var parameter = new DataMap()
				{
					{ "CustomerID", model.CustomerID },
					{ "StoreID", model.StoreID }
				};
				var exists = DaoFactory.InstanceBiz.QueryForObject<CustomerStoreModel>("SelectCustomerStoreExists", parameter);
				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCustomerStore", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCustomerStore", model);
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
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
					if (model.Contact == null)
						throw new Exception("담당자정보를 알 수 없습니다.");

					if (model.ContactID == null)
					{
						model.Contact.CreatedBy = req.User.UserId;
						model.Contact.CreatedByName = req.User.UserName;

						var id = DaoFactory.InstanceBiz.Insert("InsertContact", model.Contact);
						model.Contact.ID = id.ToIntegerNullToNull();
						model.ContactID = id.ToIntegerNullToNull();
					}
					else
					{
						model.Contact.ID = model.ContactID;
						model.Contact.UpdatedBy = req.User.UserId;
						model.Contact.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateContact", model.Contact);
					}

					if (model.ID == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertCustomerContact", model);
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateCustomerContact", model);
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

					var dup = DaoFactory.InstanceBiz.QueryForObject<CustomerManagerModel>("SelectCustomerManagerDuplicate", map);
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
						var before = DaoFactory.InstanceBiz.QueryForObject<CustomerManagerModel>("SelectCustomerManagerBefore", map);
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

							id = DaoFactory.InstanceBiz.Insert("InsertCustomerManager", manager);
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
	}
}
