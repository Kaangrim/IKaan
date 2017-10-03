using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;

namespace IKaan.Was.Service.Services
{
	public static class BizServicePartner
	{
		public static PartnerModel GetPartner(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<PartnerModel>("SelectPartner", parameter);
				if (model != null)
				{
					parameter = new DataMap() { { "PartnerID", model.ID } };

					//현재 사업자 정보
					model.CurrentBusiness = DaoFactory.InstanceBiz.QueryForObject<BusinessModel>("SelectPartnerBusinessCurrent", parameter);
					if (model.CurrentBusiness == null)
						model.CurrentBusiness = new BusinessModel();

					if (model.CurrentBusiness.AddressID != null)
					{
						model.CurrentBusiness.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", new DataMap() { { "ID", model.CurrentBusiness.AddressID } });
						if (model.CurrentBusiness.Address == null)
							model.CurrentBusiness.Address = new AddressModel();
					}

					//주소
					model.Addresses = DaoFactory.InstanceBiz.QueryForList<PartnerAddressModel>("SelectPartnerAddressList", parameter);
					if (model.Addresses == null)
						model.Addresses = new List<PartnerAddressModel>();

					//계좌
					model.BankAccounts = DaoFactory.InstanceBiz.QueryForList<PartnerBankAccountModel>("SelectPartnerBankAccountList", parameter);
					if (model.BankAccounts == null)
						model.BankAccounts = new List<PartnerBankAccountModel>();

					//사업자
					model.Businesses = DaoFactory.InstanceBiz.QueryForList<PartnerBusinessModel>("SelectPartnerBusinessList", parameter);
					if (model.Businesses == null)
						model.Businesses = new List<PartnerBusinessModel>();

					//브랜드
					model.Brands = DaoFactory.InstanceBiz.QueryForList<PartnerBrandModel>("SelectPartnerBrandList", parameter);
					if (model.Brands == null)
						model.Brands = new List<PartnerBrandModel>();

					//채널
					model.Channels = DaoFactory.InstanceBiz.QueryForList<PartnerChannelModel>("SelectPartnerChannelList", parameter);
					if (model.Channels == null)
						model.Channels = new List<PartnerChannelModel>();

					//담당자
					model.Contacts = DaoFactory.InstanceBiz.QueryForList<PartnerContactModel>("SelectPartnerContactList", parameter);
					if (model.Contacts == null)
						model.Contacts = new List<PartnerContactModel>();

					//매니저
					model.Managers = DaoFactory.InstanceBiz.QueryForList<PartnerManagerModel>("SelectPartnerManagerList", parameter);
					if (model.Managers == null)
						model.Managers = new List<PartnerManagerModel>();
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
		
		public static PartnerBusinessModel GetPartnerBusiness(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<PartnerBusinessModel>("SelectPartnerBusiness", parameter);
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

		public static PartnerAddressModel GetPartnerAddress(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var Partner = DaoFactory.InstanceBiz.QueryForObject<PartnerAddressModel>("SelectPartnerAddress", parameter);
				req.Data = Partner;
				req.Result.Count = 1;
				return Partner;
			}
			catch
			{
				throw;
			}
		}

		public static PartnerContactModel GetPartnerContact(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<PartnerContactModel>("SelectPartnerContact", parameter);
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

		public static PartnerBankAccountModel GetPartnerBankAccount(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<PartnerBankAccountModel>("SelectPartnerBankAccount", parameter);
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
		
		public static void SavePartner(this WasRequest req)
		{
			try
			{
				var Partner = req.Data.JsonToAnyType<PartnerModel>();
				Partner = req.SaveData<PartnerModel>(Partner);

				if (Partner != null)
				{
					//거래처 주소
					if (Partner.Addresses != null && Partner.Addresses.Count > 0)
					{
						foreach (var data in Partner.Addresses)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.PartnerID = Partner.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertPartnerAddress", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdatePartnerAddress", data);
								}
							}
						}
					}

					//거래처 계좌정보
					if (Partner.BankAccounts != null && Partner.BankAccounts.Count > 0)
					{
						foreach (var data in Partner.BankAccounts)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.PartnerID = Partner.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertPartnerBankAccount", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdatePartnerBankAccount", data);
								}
							}
						}
					}

					//거래처 브랜드
					if (Partner.Brands != null && Partner.Brands.Count > 0)
					{
						foreach (var data in Partner.Brands)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.PartnerID = Partner.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertPartnerBrand", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdatePartnerBrand", data);
								}
							}
						}
					}

					//거래처 채널
					if (Partner.Channels != null && Partner.Channels.Count > 0)
					{
						foreach (var data in Partner.Channels)
						{
							if (data.ID == null || data.ID == default(int))
							{
								data.PartnerID = Partner.ID;
								data.CreatedBy = req.User.UserId;
								data.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertPartnerChannel", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdatePartnerChannel", data);
								}
							}
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = Partner.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SavePartnerBusiness(this WasRequest req)
		{
			try
			{
				object PartnerId = null;
				object addressId = null;
				object businessId = null;

				var Partner = req.Data.JsonToAnyType<PartnerBusinessModel>();
				if (Partner != null)
				{
					if (Partner.Business != null)
					{
						if (Partner.Business.Address != null)
						{
							if (Partner.Business.AddressID.IsNullOrDefault())
							{
								Partner.Business.Address.CreatedBy = req.User.UserId;
								Partner.Business.Address.CreatedByName = req.User.UserName;

								addressId = DaoFactory.InstanceBiz.Insert("InsertAddress", Partner.Business.Address);
								Partner.Business.Address.ID = addressId.ToIntegerNullToNull();
								Partner.Business.AddressID = Partner.Business.Address.ID;
							}
							else
							{
								Partner.Business.Address.ID = Partner.Business.AddressID;
								Partner.Business.Address.UpdatedBy = req.User.UserId;
								Partner.Business.Address.UpdatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Update("UpdateAddress", Partner.Business.Address);
							}
						}

						var imageID = Partner.Business.ImageID;
						if (Regex.IsMatch(Partner.Business.Image.RowState.ToStringNullToEmpty().ToUpper(), "INSERT|UPDATE"))
						{
							if (imageID == null)
							{
								Partner.Business.Image.CreatedBy = req.User.UserId;
								Partner.Business.Image.CreatedByName = req.User.UserName;
								var id = DaoFactory.InstanceBiz.Insert("InsertImage", Partner.Business.Image);
								Partner.Business.Image.ID = id.ToIntegerNullToNull();
								Partner.Business.ImageID = id.ToIntegerNullToNull();
							}
							else
							{
								Partner.Business.Image.ID = Partner.Business.ImageID;
								Partner.Business.Image.UpdatedBy = req.User.UserId;
								Partner.Business.Image.UpdatedByName = req.User.UserName;
								DaoFactory.InstanceBiz.Update("UpdateImage", Partner.Business.Image);
							}
						}
						else if (Partner.Business.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
						{
							Partner.Business.ImageID = null;
						}

						if (Partner.BusinessID.IsNullOrDefault())
						{
							Partner.Business.CreatedBy = req.User.UserId;
							Partner.Business.CreatedByName = req.User.UserName;
							businessId = DaoFactory.InstanceBiz.Insert("InsertBusiness", Partner.Business);
							Partner.Business.ID = businessId.ToIntegerNullToNull();
							Partner.BusinessID = Partner.Business.ID;
						}
						else
						{
							Partner.Business.UpdatedBy = req.User.UserId;
							Partner.Business.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateBusiness", Partner.Business);

							if (imageID != null && Partner.Business.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
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
						{ "PartnerID", Partner.PartnerID },
						{ "StartDate", Partner.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<PartnerBusinessModel>("SelectPartnerBusinessDuplicate", map);
					if (dup != null)
					{
						if (Partner.ID.IsNullOrDefault())
						{
							throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");
						}
						else
						{
							if (Partner.ID != dup.ID)
								throw new Exception("동일 시작일로 등록된 데이터가 존재합니다.");

							Partner.UpdatedBy = req.User.UserId;
							Partner.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdatePartnerBusiness", Partner);
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<PartnerBusinessModel>("SelectPartnerBusinessBefore", map);
						if (before != null)
						{
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;
							before.EndDate = Partner.StartDate.Value.AddDays(-1);

							DaoFactory.InstanceBiz.Update("UpdatePartnerBusinessEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<PartnerBusinessModel>("SelectPartnerBusinessAfter", map);
						if (after != null)
						{
							Partner.EndDate = after.StartDate.Value.AddDays(-1);
						}

						if (Partner.ID.IsNullOrDefault())
						{
							Partner.CreatedBy = req.User.UserId;
							Partner.CreatedByName = req.User.UserName;

							PartnerId = DaoFactory.InstanceBiz.Insert("InsertPartnerBusiness", Partner);
							Partner.ID = PartnerId.ToIntegerNullToNull();
						}
						else
						{
							Partner.UpdatedBy = req.User.UserId;
							Partner.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdatePartnerBusiness", Partner);
						}
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = Partner.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SavePartnerAddress(this WasRequest req)
		{
			try
			{
				object PartnerId = null;
				object addressId = null;

				var Partner = req.Data.JsonToAnyType<PartnerAddressModel>();
				if (Partner != null)
				{
					if (Partner.AddressID.IsNullOrDefault())
					{
						if (Partner.Address.PostalCode.IsNullOrEmpty() == false)
						{
							var address = new AddressModel()
							{
								PostalCode = Partner.Address.PostalCode,
								Country = Partner.Address.Country,
								City = Partner.Address.City,
								StateProvince = Partner.Address.StateProvince,
								AddressLine1 = Partner.Address.AddressLine1,
								AddressLine2 = Partner.Address.AddressLine2,
								CreatedBy = req.User.UserId,
								CreatedByName = req.User.UserName
							};

							addressId = DaoFactory.InstanceBiz.Insert("InsertAddress", address);
							Partner.AddressID = addressId.ToIntegerNullToNull();
						}
					}
					else
					{
						var address = new AddressModel()
						{
							ID = Partner.AddressID,
							PostalCode = Partner.Address.PostalCode,
							Country = Partner.Address.Country,
							City = Partner.Address.City,
							StateProvince = Partner.Address.StateProvince,
							AddressLine1 = Partner.Address.AddressLine1,
							AddressLine2 = Partner.Address.AddressLine2,
							UpdatedBy = req.User.UserId,
							UpdatedByName = req.User.UserName
						};

						DaoFactory.InstanceBiz.Update("UpdateAddress", address);
					}

					if (Partner.ID.IsNullOrDefault())
					{
						Partner.CreatedBy = req.User.UserId;
						Partner.CreatedByName = req.User.UserName;

						PartnerId = DaoFactory.InstanceBiz.Insert("InsertPartnerAddress", Partner);
						Partner.ID = PartnerId.ToIntegerNullToNull();
					}
					else
					{
						Partner.UpdatedBy = req.User.UserId;
						Partner.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdatePartnerAddress", Partner);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = Partner.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SavePartnerBankAccount(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<PartnerBankAccountModel>();
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
					var id = DaoFactory.InstanceBiz.Insert("InsertPartnerBankAccount", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdatePartnerBankAccount", model);
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

		public static void SavePartnerBrand(this WasRequest req)
		{
			try
			{
				object id = null;

				var Partner = req.Data.JsonToAnyType<PartnerBrandModel>();
				if (Partner != null)
				{
					if (Partner.ID.IsNullOrDefault())
					{
						Partner.CreatedBy = req.User.UserId;
						Partner.CreatedByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertPartnerBrand", Partner);
						Partner.ID = id.ToIntegerNullToNull();
					}
					else
					{
						Partner.UpdatedBy = req.User.UserId;
						Partner.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdatePartnerBrand", Partner);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = Partner.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SavePartnerChannel(this WasRequest req)
		{
			try
			{
				object id = null;

				var Partner = req.Data.JsonToAnyType<PartnerChannelModel>();
				if (Partner != null)
				{
					if (Partner.ID.IsNullOrDefault())
					{
						Partner.CreatedBy = req.User.UserId;
						Partner.CreatedByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertPartnerChannel", Partner);
						Partner.ID = id.ToIntegerNullToNull();
					}
					else
					{
						Partner.UpdatedBy = req.User.UserId;
						Partner.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdatePartnerChannel", Partner);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = Partner.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}

		public static void SavePartnerStore(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<PartnerStoreModel>();

				var parameter = new DataMap()
				{
					{ "PartnerID", model.PartnerID },
					{ "StoreID", model.StoreID }
				};
				var exists = DaoFactory.InstanceBiz.QueryForObject<PartnerStoreModel>("SelectPartnerStoreExists", parameter);
				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertPartnerStore", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdatePartnerStore", model);
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

		public static void SavePartnerContact(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<PartnerContactModel>();
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
						var id = DaoFactory.InstanceBiz.Insert("InsertPartnerContact", model);
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdatePartnerContact", model);
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

		public static void SavePartnerManager(this WasRequest req)
		{
			try
			{
				object id = null;
				var manager = req.Data.JsonToAnyType<PartnerManagerModel>();
				if (manager != null)
				{
					DataMap map = new DataMap()
					{
						{ "PartnerID", manager.PartnerID },
						{ "StartDate", manager.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<PartnerManagerModel>("SelectPartnerManagerDuplicate", map);
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

							DaoFactory.InstanceBiz.Update("UpdatePartnerManager", manager);
							id = manager.ID;
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<PartnerManagerModel>("SelectPartnerManagerBefore", map);
						if (before != null)
						{
							before.EndDate = manager.StartDate.Value.AddDays(-1);
							before.UpdatedBy = req.User.UserId;
							before.UpdatedByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdatePartnerManagerEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<PartnerManagerModel>("SelectPartnerManagerAfter", map);
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

							DaoFactory.InstanceBiz.Update("UpdatePartnerManager", manager);
							id = manager.ID;
						}
						else
						{
							manager.CreatedBy = req.User.UserId;
							manager.CreatedByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertPartnerManager", manager);
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
