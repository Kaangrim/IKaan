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

				if (model.Address != null)
				{
					if (model.AddressID == null)
					{
						model.Address.CreatedBy = req.User.UserId;
						model.Address.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertAddress", model.Address);
						model.Address.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.Address.UpdatedBy = req.User.UserId;
						model.Address.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateAddress", model.Address);
					}
					model.AddressID = model.Address.ID;
				}
				
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

				if (model.BankAccount != null)
				{
					if (model.BankAccountID == null)
					{
						model.BankAccount.CreatedBy = req.User.UserId;
						model.BankAccount.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertBankAccount", model.BankAccount);
						model.BankAccount.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.BankAccount.UpdatedBy = req.User.UserId;
						model.BankAccount.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateBankAccount", model.BankAccount);
					}
					model.BankAccountID = model.BankAccount.ID;
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
						model.Business.Image.ImageType = "44";	//사업자등록증

						if (model.Business.ImageID == null)
						{
							model.Business.Image.CreatedBy = req.User.UserId;
							model.Business.Image.CreatedByName = req.User.UserName;
							var id = DaoFactory.InstanceBiz.Insert("InsertImage", model.Business.Image);
							model.Business.Image.ID = id.ToIntegerNullToNull();
						}
						else
						{
							model.Business.Image.UpdatedBy = req.User.UserId;
							model.Business.Image.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateImage", model.Business.Image);
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
