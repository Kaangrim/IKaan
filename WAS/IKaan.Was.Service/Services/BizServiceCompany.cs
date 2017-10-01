using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Company;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceCompany
	{
		public static CompanyModel GetCompany(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CompanyModel>("SelectCompany", parameter);
				if (model != null)
				{
					parameter = new DataMap() { { "CompanyID", model.ID } };

					//현재 사업자 정보
					model.CurrentBusiness = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectCompanyBusinessCurrent", parameter);
					if (model.CurrentBusiness == null)
						model.CurrentBusiness = new BusinessModel();

					if (model.CurrentBusiness.AddressID != null)
					{
						model.CurrentBusiness.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", new DataMap() { { "ID", model.CurrentBusiness.AddressID } });
						if (model.CurrentBusiness.Address == null)
							model.CurrentBusiness.Address = new AddressModel();
					}

					//주소
					model.Addresses = DaoFactory.InstanceBiz.QueryForList<CompanyAddressModel>("SelectCompanyAddressList", parameter);
					if (model.Addresses == null)
						model.Addresses = new List<CompanyAddressModel>();

					//계좌
					model.BankAccounts = DaoFactory.InstanceBiz.QueryForList<CompanyBankAccountModel>("SelectCompanyBankAccountList", parameter);
					if (model.BankAccounts == null)
						model.BankAccounts = new List<CompanyBankAccountModel>();

					//사업자
					model.Businesses = DaoFactory.InstanceBiz.QueryForList<CompanyBusinessModel>("SelectCompanyBusinessList", parameter);
					if (model.Businesses == null)
						model.Businesses = new List<CompanyBusinessModel>();

					//담당자
					model.Contacts = DaoFactory.InstanceBiz.QueryForList<CompanyContactModel>("SelectCompanyContactList", parameter);
					if (model.Contacts == null)
						model.Contacts = new List<CompanyContactModel>();

					//쇼핑몰
					model.Stores = DaoFactory.InstanceBiz.QueryForList<CompanyStoreModel>("SelectCompanyStoreList", parameter);
					if (model.Stores == null)
						model.Stores = new List<CompanyStoreModel>();
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

		public static CompanyBusinessModel GetCompanyBusiness(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CompanyBusinessModel>("SelectCompanyBusiness", parameter);
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

		public static CompanyContactModel GetCompanyContact(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CompanyContactModel>("SelectCompanyContact", parameter);
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

		public static CompanyAddressModel GetCompanyAddress(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CompanyAddressModel>("SelectCompanyAddress", parameter);
				req.Data = model;
				req.Result.Count = 1;
				return model;
			}
			catch
			{
				throw;
			}
		}

		public static CompanyBankAccountModel GetCompanyBankAccount(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<CompanyBankAccountModel>("SelectCompanyBankAccount", parameter);
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

		public static void SaveCompany(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CompanyModel>();

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCompany", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCompany", model);
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

		public static void SaveCompanyAddress(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CompanyAddressModel>();
				var address = new AddressModel()
				{
					ID = model.AddressID,
					PostalCode = model.PostalCode,
					Country = model.Country,
					City = model.City,
					StateProvince = model.StateProvince,
					AddressLine1 = model.AddressLine1,
					AddressLine2 = model.AddressLine2
				};

				if (model.AddressID == null)
				{
					address.CreatedBy = req.User.UserId;
					address.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertAddress", address);
					address.ID = id.ToIntegerNullToNull();
				}
				else
				{
					address.UpdatedBy = req.User.UserId;
					address.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateAddress", address);
				}
				model.AddressID = address.ID;
				
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCompanyAddress", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCompanyAddress", model);
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

		public static void SaveCompanyBankAccount(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CompanyBankAccountModel>();
				var bankaccount = new BankAccountModel()
				{
					Name = model.BankAccountName,
					BankName = model.BankName,
					AccountNo = model.AccountNo,
					Depositor = model.Depositor,
					ImageID = model.ImageID
				};

				if (model.Image != null)
				{
					if (model.ImageID == null)
					{
						if (model.Image.Url.IsNullOrEmpty() == false)
						{
							model.Image.CreatedBy = req.User.UserId;
							model.Image.CreatedByName = req.User.UserName;
							var id = DaoFactory.InstanceBiz.Insert("InsertImage", model.Image);
							model.Image.ID = id.ToIntegerNullToNull();
						}
					}
					else
					{
						if (model.Image.Url.IsNullOrEmpty() == false)
						{
							model.Image.UpdatedBy = req.User.UserId;
							model.Image.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateImage", model.Image);
						}
						else
						{
							DaoFactory.InstanceBiz.Delete("DeleteImage", model.ImageID);
							model.Image.ID = null;
							model.ImageID = null;
						}
					}
					model.ImageID = model.Image.ID;
					bankaccount.ImageID = model.ImageID;
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
					}
					model.BankAccountID = bankaccount.ID;
				}

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCompanyBankAccount", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCompanyBankAccount", model);
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

		public static void SaveCompanyBusiness(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CompanyBusinessModel>();

				if (model.Business != null)
				{
					if (model.Business.Address != null)
					{
						if (model.Business.AddressID == null)
						{
							model.Business.Address.CreatedBy = req.User.UserId;
							model.Business.Address.CreatedByName = req.User.UserName;
							var id = DaoFactory.InstanceBiz.Insert("InsertAddress", model.Business.Address);
							model.Business.Address.ID = id.ToIntegerNullToNull();
							
						}
						else
						{
							model.Business.Address.UpdatedBy = req.User.UserId;
							model.Business.Address.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateAddress", model.Business.Address);
						}
						model.Business.AddressID = model.Business.Address.ID;
					}
					else
					{
						model.Business.AddressID = null;
					}

					if (model.Business.Image != null)
					{
						if (model.Business.ImageID == null)
						{
							if (model.Business.Image.Url.IsNullOrEmpty() == false)
							{
								model.Business.Image.CreatedBy = req.User.UserId;
								model.Business.Image.CreatedByName = req.User.UserName;
								var id = DaoFactory.InstanceBiz.Insert("InsertImage", model.Business.Image);
								model.Business.Image.ID = id.ToIntegerNullToNull();
							}
						}
						else
						{
							if (model.Business.Image.Url.IsNullOrEmpty() == false)
							{
								model.Business.Image.UpdatedBy = req.User.UserId;
								model.Business.Image.UpdatedByName = req.User.UserName;
								DaoFactory.InstanceBiz.Update("UpdateImage", model.Business.Image);
							}
							else
							{
								DaoFactory.InstanceBiz.Delete("DeleteImage", new DataMap() { { "ID", model.Business.ImageID } });
								model.Business.Image.ID = null;
							}
						}
						model.Business.ImageID = model.Business.Image.ID;
					}

					if (model.BusinessID == null)
					{
						model.Business.CreatedBy = req.User.UserId;
						model.Business.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertBusiness", model.Business);
						model.Business.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.Business.UpdatedBy = req.User.UserId;
						model.Business.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateBusiness", model.Business);
					}
					model.BusinessID = model.Business.ID;
				}

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCompanyBusiness", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCompanyBusiness", model);
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

		public static void SaveCompanyContact(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CompanyContactModel>();

				if (model.Contact != null)
				{
					if (model.ContactID == null)
					{
						model.Contact.CreatedBy = req.User.UserId;
						model.Contact.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertContact", model.Contact);
						model.Contact.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.Contact.UpdatedBy = req.User.UserId;
						model.Contact.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateContact", model.Contact);
					}
					model.ContactID = model.Contact.ID;
				}

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCompanyContact", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCompanyContact", model);
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

		public static void SaveCompanyStore(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<CompanyStoreModel>();

				var parameter = new DataMap()
				{
					{ "CompanyID", model.CompanyID },
					{ "StoreID", model.StoreID }
				};
				var exists = DaoFactory.InstanceBiz.QueryForObject<CompanyStoreModel>("SelectCompanyStoreExists", parameter);
				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertCompanyStore", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateCompanyStore", model);
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
	}
}
