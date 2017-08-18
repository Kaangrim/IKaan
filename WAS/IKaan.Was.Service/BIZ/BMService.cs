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
						case "BMAddress":
							req.SetList<BMAddress>();
							break;
						case "BMBusiness":
							req.SetList<BMBusiness>();
							break;
						case "BMBrand":
							req.SetList<BMBrand>();
							break;
						case "BMChannel":
							req.SetList<BMChannel>();
							break;
						case "BMSearchBrand":
							req.SetList<BMSearchBrand>();
							break;
						case "BMCustomer":
							req.SetList<BMCustomer>();
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
						case "BMAddress":
							req.SetData<BMAddress>();
							break;
						case "BMBusiness":
							req.GetBusiness();
							break;
						case "BMBrand":
							req.SetData<BMBrand>();
							(req.Data as BMBrand).Images = req.GetList<BMBrandImage>();
							(req.Data as BMBrand).Customers = req.GetList<BMCustomerBrand>();
							(req.Data as BMBrand).Channels = req.GetList<BMChannelBrand>();
							(req.Data as BMBrand).Contacts = req.GetList<BMBrandContact>();
							(req.Data as BMBrand).Managers = req.GetList<BMBrandManager>();
							break;
						case "BMBrandContact":
							req.SetData<BMBrandContact>();
							break;
						case "BMBrandManager":
							req.SetData<BMBrandManager>();
							break;
						case "BMChannel":
							req.SetData<BMChannel>();
							(req.Data as BMChannel).Brands = req.GetList<BMChannelBrand>();
							(req.Data as BMChannel).Customers = req.GetList<BMCustomerChannel>();
							(req.Data as BMChannel).Contacts = req.GetList<BMChannelContact>();
							(req.Data as BMChannel).Managers = req.GetList<BMChannelManager>();
							break;
						case "BMChannelBrand":
							req.SetData<BMChannelBrand>();
							break;
						case "BMChannelContact":
							req.SetData<BMChannelContact>();
							break;
						case "BMChannelManager":
							req.SetData<BMChannelManager>();
							break;
						case "BMSearchBrand":
							req.GetSearchBrand();
							break;
						case "BMSearchBrandActivity":
							req.SetData<BMSearchBrandActivity>();
							break;
						case "BMCustomer":
							req.GetCustomer();
							break;
						case "BMCustomerBusiness":
							req.GetCustomerBusiness();
							break;
						case "BMCustomerAddress":
							req.GetCustomerAddress();
							break;
						case "BMCustomerBank":
							req.SetData<BMCustomerBank>();
							break;
						case "BMCustomerBrand":
							req.SetData<BMCustomerBrand>();
							break;
						case "BMCustomerChannel":
							req.SetData<BMCustomerChannel>();
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
								case "BMBusiness":
									req.SaveBusiness();
									break;
								case "BMBrand":
									req.SaveBrand();
									break;
								case "BMBrandImage":
									req.SaveData<BMBrandImage>();
									break;
								case "BMBrandContact":
									req.SaveBrandContact();
									break;
								case "BMBrandManager":
									req.SaveBrandManager();
									break;
								case "BMChannel":
									req.SaveChannel();
									break;
								case "BMChannelBrand":
									req.SaveChannelBrand();
									break;
								case "BMChannelContact":
									req.SaveChannelContact();
									break;
								case "BMChannelManager":
									req.SaveChannelManager();
									break;
								case "BMSearchBrand":
									req.SaveData<BMSearchBrand>();
									break;
								case "BMSearchBrandActivity":
									req.SaveData<BMSearchBrandActivity>();
									break;
								case "BMCustomer":
									req.SaveCustomer();
									break;
								case "BMCustomerBusiness":
									req.SaveCustomerBusiness();
									break;
								case "BMCustomerAddress":
									req.SaveCustomerAddress();
									break;
								case "BMCustomerBank":
									req.SaveCustomerBank();
									break;
								case "BMCustomerBrand":
									req.SaveCustomerBrand();
									break;
								case "BMCustomerChannel":
									req.SaveCustomerChannel();
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
							DaoFactory.InstanceBiz.Update("UpdateBMPersonImageUrl", parameter);
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

		private static BMBusiness GetBusiness(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BMBusiness business = DaoFactory.InstanceBiz.QueryForObject<BMBusiness>("SelectBMBusiness", parameter);
				if (business != null)
				{
					//주소
					parameter = new DataMap() { { "ID", business.AddressID } };
					business.Address = DaoFactory.InstanceBiz.QueryForObject<BMAddress>("SelectBMAddress", parameter);
					if (business.Address == null)
						business.Address = new BMAddress();

					//거래처목록
					parameter = new DataMap() { { "BusinessID", business.ID } };
					business.Customers = DaoFactory.InstanceBiz.QueryForList<BMCustomerBusiness>("SelectBMCustomerBusinessList", parameter);
					if (business.Customers == null)
						business.Customers = new List<BMCustomerBusiness>();
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

		private static BMCustomer GetCustomer(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BMCustomer customer = DaoFactory.InstanceBiz.QueryForObject<BMCustomer>("SelectBMCustomer", parameter);
				if (customer != null)
				{
					parameter = new DataMap() { { "CustomerID", customer.ID } };

					//주소
					customer.AddressList = DaoFactory.InstanceBiz.QueryForList<BMCustomerAddress>("SelectBMCustomerAddressList", parameter);
					if (customer.AddressList == null)
						customer.AddressList = new List<BMCustomerAddress>();

					//계좌
					customer.BankList = DaoFactory.InstanceBiz.QueryForList<BMCustomerBank>("SelectBMCustomerBankList", parameter);
					if (customer.BankList == null)
						customer.BankList = new List<BMCustomerBank>();

					//사업자
					customer.BusinessList = DaoFactory.InstanceBiz.QueryForList<BMCustomerBusiness>("SelectBMCustomerBusinessList", parameter);
					if (customer.BusinessList == null)
						customer.BusinessList = new List<BMCustomerBusiness>();

					//브랜드
					customer.BrandList = DaoFactory.InstanceBiz.QueryForList<BMCustomerBrand>("SelectBMCustomerBrandList", parameter);
					if (customer.BrandList == null)
						customer.BrandList = new List<BMCustomerBrand>();

					//채널
					customer.ChannelList = DaoFactory.InstanceBiz.QueryForList<BMCustomerChannel>("SelectBMCustomerChannelList", parameter);
					if (customer.ChannelList == null)
						customer.ChannelList = new List<BMCustomerChannel>();
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

		private static BMSearchBrand GetSearchBrand(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BMSearchBrand brand = DaoFactory.InstanceBiz.QueryForObject<BMSearchBrand>("SelectBMSearchBrand", parameter);
				if (brand != null)
				{
					parameter = new DataMap() { { "SearchBrandID", brand.ID } };

					//주소
					brand.Activities = DaoFactory.InstanceBiz.QueryForList<BMSearchBrandActivity>("SelectBMSearchBrandActivityList", parameter);
					if (brand.Activities == null)
						brand.Activities = new List<BMSearchBrandActivity>();
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

		private static BMCustomerBusiness GetCustomerBusiness(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BMCustomerBusiness customer = DaoFactory.InstanceBiz.QueryForObject<BMCustomerBusiness>("SelectBMCustomerBusiness", parameter);
				if (customer != null)
				{
					//사업자
					parameter = new DataMap() { { "ID", customer.BusinessID } };
					customer.Business = DaoFactory.InstanceBiz.QueryForObject<BMBusiness>("SelectBMBusiness", parameter);

					//주소
					if (customer.Business != null)
					{
						parameter = new DataMap() { { "ID", customer.Business.AddressID } };
						customer.Business.Address = DaoFactory.InstanceBiz.QueryForObject<BMAddress>("SelectBMAddress", parameter);
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

		private static BMCustomerAddress GetCustomerAddress(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BMCustomerAddress customer = DaoFactory.InstanceBiz.QueryForObject<BMCustomerAddress>("SelectBMCustomerAddress", parameter);
				req.Data = customer;
				req.Result.Count = 1;
				return customer;
			}
			catch
			{
				throw;
			}
		}

		private static void SaveBrand(this WasRequest req)
		{
			try
			{
				BMBrand brand = req.Data.JsonToAnyType<BMBrand>();
				brand = req.SaveData<BMBrand>(brand);

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

		private static void SaveBrandContact(this WasRequest req)
		{
			try
			{
				BMBrandContact contact = req.Data.JsonToAnyType<BMBrandContact>();
				if (contact != null)
				{
					BMPerson person = new BMPerson()
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

						personID = DaoFactory.InstanceBiz.Insert("InsertBMPerson", person);
					}
					else
					{
						person.UpdateBy = req.User.UserId;
						person.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMPerson", person);
						personID = person.ID;
					}

					contact.PersonID = personID.ToIntegerNullToNull();

					if (contact.ID == null)
					{
						contact.CreateBy = req.User.UserId;
						contact.CreateByName = req.User.UserName;

						contactID = DaoFactory.InstanceBiz.Insert("InsertBMBrandContact", contact);
					}
					else
					{
						contact.UpdateBy = req.User.UserId;
						contact.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMBrandContact", contact);
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

		private static void SaveBrandManager(this WasRequest req)
		{
			try
			{
				object id = null;
				BMBrandManager manager = req.Data.JsonToAnyType<BMBrandManager>();
				if (manager != null)
				{
					DataMap map = new DataMap()
					{
						{ "BrandID", manager.BrandID },
						{ "StartDate", manager.StartDate }
					};

					BMBrandManager dup = DaoFactory.InstanceBiz.QueryForObject<BMBrandManager>("SelectBMBrandManagerDuplicate", map);
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

							DaoFactory.InstanceBiz.Update("UpdateBMBrandManager", manager);
							id = manager.ID;
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<BMBrandManager>("SelectBMBrandManagerBefore", map);
						if (before != null)
						{
							before.EndDate = manager.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBMBrandManagerEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<BMBrandManager>("SelectBMBrandManagerAfter", map);
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

							DaoFactory.InstanceBiz.Update("UpdateBMBrandManager", manager);
							id = manager.ID;
						}
						else
						{
							manager.CreateBy = req.User.UserId;
							manager.CreateByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertBMBrandManager", manager);
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

		private static void SaveChannel(this WasRequest req)
		{
			try
			{
				BMChannel channel = req.Data.JsonToAnyType<BMChannel>();
				channel = req.SaveData<BMChannel>(channel);

				if (channel != null)
				{
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

		private static void SaveChannelBrand(this WasRequest req)
		{
			try
			{
				BMChannelBrand model = req.Data.JsonToAnyType<BMChannelBrand>();
				if (model != null)
				{
					DataMap parameter = new DataMap()
					{
						{ "ChannelID", model.ChannelID },
						{ "BrandID", model.BrandID },
						{ "StartDate", model.StartDate }
					};

					var dup = DaoFactory.InstanceBiz.QueryForObject<BMChannelBrand>("SelectBMChannelBrandDuplicate", parameter);
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

					var before = DaoFactory.InstanceBiz.QueryForObject<BMChannelBrand>("SelectBMChannelBrandBefore", parameter);
					if (before != null)
					{
						before.EndDate = model.StartDate.Value.AddDays(-1);
						before.UpdateBy = req.User.UserId;
						before.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMChannelBrand", before);
					}

					var after = DaoFactory.InstanceBiz.QueryForObject<BMChannelBrand>("SelectBMChannelBrandAfter", parameter);
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

						object id = DaoFactory.InstanceBiz.Insert("InsertBMChannelBrand", model);
						model.ID = id.ToIntegerNullToNull();							
					}
					else
					{
						model.UpdateBy = req.User.UserId;
						model.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMChannelBrand", model);
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

		private static void SaveChannelContact(this WasRequest req)
		{
			try
			{
				BMChannelContact contact = req.Data.JsonToAnyType<BMChannelContact>();
				if (contact != null)
				{
					BMPerson person = new BMPerson()
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

						personID = DaoFactory.InstanceBiz.Insert("InsertBMPerson", person);
					}
					else
					{
						person.UpdateBy = req.User.UserId;
						person.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMPerson", person);
						personID = person.ID;
					}

					contact.PersonID = personID.ToIntegerNullToNull();

					if (contact.ID == null)
					{
						contact.CreateBy = req.User.UserId;
						contact.CreateByName = req.User.UserName;

						contactID = DaoFactory.InstanceBiz.Insert("InsertBMChannelContact", contact);
					}
					else
					{
						contact.UpdateBy = req.User.UserId;
						contact.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMChannelContact", contact);
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

		private static void SaveChannelManager(this WasRequest req)
		{
			try
			{
				object id = null;
				BMChannelManager manager = req.Data.JsonToAnyType<BMChannelManager>();
				if (manager != null)
				{
					DataMap map = new DataMap()
					{
						{ "ChannelID", manager.ChannelID },
						{ "StartDate", manager.StartDate }
					};

					BMBrandManager dup = DaoFactory.InstanceBiz.QueryForObject<BMBrandManager>("SelectBMChannelManagerDuplicate", map);
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

							DaoFactory.InstanceBiz.Update("UpdateBMChannelManager", manager);
							id = manager.ID;
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<BMBrandManager>("SelectBMChannelManagerBefore", map);
						if (before != null)
						{
							before.EndDate = manager.StartDate.Value.AddDays(-1);
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBMChannelManagerEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<BMBrandManager>("SelectBMChannelManagerAfter", map);
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

							DaoFactory.InstanceBiz.Update("UpdateBMChannelManager", manager);
							id = manager.ID;
						}
						else
						{
							manager.CreateBy = req.User.UserId;
							manager.CreateByName = req.User.UserName;

							id = DaoFactory.InstanceBiz.Insert("InsertBMChannelManager", manager);
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

		private static void SaveBusiness(this WasRequest req)
		{
			try
			{
				BMBusiness model = req.Data.JsonToAnyType<BMBusiness>();
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

								object id = DaoFactory.InstanceBiz.Insert("InsertBMAddress", model.Address);
								model.AddressID = id.ToIntegerNullToNull();
							}
						}
						else
						{
							model.Address.UpdateBy = req.User.UserId;
							model.Address.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBMAddress", model.Address);
						}
					}

					if (model.ID.IsNullOrDefault())
					{
						model.CreateBy = req.User.UserId;
						model.CreateByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertBMBusiness", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdateBy = req.User.UserId;
						model.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMBusiness", model);
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

		private static void SaveCustomer(this WasRequest req)
		{
			try
			{
				BMCustomer customer = req.Data.JsonToAnyType<BMCustomer>();
				customer = req.SaveData<BMCustomer>(customer);

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

								DaoFactory.InstanceBiz.Insert("InsertBMCustomerAddress", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateBMCustomerAddress", data);
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

								DaoFactory.InstanceBiz.Insert("InsertBMCustomerBank", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateBMCustomerBank", data);
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

								DaoFactory.InstanceBiz.Insert("InsertBMCustomerBrand", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateBMCustomerBrand", data);
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

								DaoFactory.InstanceBiz.Insert("InsertBMCustomerChannel", data);
							}
							else
							{
								if (data.RowState == "UPDATE")
								{
									data.UpdateBy = req.User.UserId;
									data.UpdateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Update("UpdateBMCustomerChannel", data);
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

		private static void SaveCustomerBusiness(this WasRequest req)
		{
			try
			{
				object customerId = null;
				object addressId = null;
				object businessId = null;

				BMCustomerBusiness customer = req.Data.JsonToAnyType<BMCustomerBusiness>();
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

								addressId = DaoFactory.InstanceBiz.Insert("InsertBMAddress", customer.Business.Address);
								customer.Business.Address.ID = addressId.ToIntegerNullToNull();
								customer.Business.AddressID = customer.Business.Address.ID;
							}
							else
							{
								customer.Business.Address.ID = customer.Business.AddressID;
								customer.Business.Address.UpdateBy = req.User.UserId;
								customer.Business.Address.UpdateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Update("UpdateBMAddress", customer.Business.Address);
							}
						}

						if (customer.BusinessID.IsNullOrDefault())
						{
							customer.Business.CreateBy = req.User.UserId;
							customer.Business.CreateByName = req.User.UserName;

							businessId = DaoFactory.InstanceBiz.Insert("InsertBMBusiness", customer.Business);
							customer.Business.ID = businessId.ToIntegerNullToNull();
							customer.BusinessID = customer.Business.ID;
						}
						else
						{
							customer.Business.UpdateBy = req.User.UserId;
							customer.Business.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBMBusiness", customer.Business);
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

					BMCustomerBusiness dup = DaoFactory.InstanceBiz.QueryForObject<BMCustomerBusiness>("SelectBMCustomerBusinessDuplicate", map);
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

							DaoFactory.InstanceBiz.Update("UpdateBMCustomerBusiness", customer);
						}
					}
					else
					{
						var before = DaoFactory.InstanceBiz.QueryForObject<BMCustomerBusiness>("SelectBMCustomerBusinessBefore", map);
						if (before != null)
						{
							before.UpdateBy = req.User.UserId;
							before.UpdateByName = req.User.UserName;
							before.EndDate = customer.StartDate.Value.AddDays(-1);

							DaoFactory.InstanceBiz.Update("UpdateBMCustomerBusinessEndDate", before);
						}

						var after = DaoFactory.InstanceBiz.QueryForObject<BMCustomerBusiness>("SelectBMCustomerBusinessAfter", map);
						if (after != null)
						{
							customer.EndDate = after.StartDate.Value.AddDays(-1);
						}

						if (customer.ID.IsNullOrDefault())
						{
							customer.CreateBy = req.User.UserId;
							customer.CreateByName = req.User.UserName;

							customerId = DaoFactory.InstanceBiz.Insert("InsertBMCustomerBusiness", customer);
							customer.ID = customerId.ToIntegerNullToNull();
						}
						else
						{
							customer.UpdateBy = req.User.UserId;
							customer.UpdateByName = req.User.UserName;

							DaoFactory.InstanceBiz.Update("UpdateBMCustomerBusiness", customer);
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

		private static void SaveCustomerAddress(this WasRequest req)
		{
			try
			{
				object customerId = null;
				object addressId = null;

				BMCustomerAddress customer = req.Data.JsonToAnyType<BMCustomerAddress>();
				if (customer != null)
				{
					if (customer.AddressID.IsNullOrDefault())
					{
						if (customer.PostalCode.IsNullOrEmpty() == false)
						{
							BMAddress address = new BMAddress()
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

							addressId = DaoFactory.InstanceBiz.Insert("InsertBMAddress", address);
							customer.AddressID = addressId.ToIntegerNullToNull();
						}
					}
					else
					{
						BMAddress address = new BMAddress()
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

						DaoFactory.InstanceBiz.Update("UpdateBMAddress", address);
					}

					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						customerId = DaoFactory.InstanceBiz.Insert("InsertBMCustomerAddress", customer);
						customer.ID = customerId.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMCustomerAddress", customer);
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

		private static void SaveCustomerBank(this WasRequest req)
		{
			try
			{
				object id = null;

				BMCustomerBank customer = req.Data.JsonToAnyType<BMCustomerBank>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertBMCustomerBank", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMCustomerBank", customer);
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

		private static void SaveCustomerBrand(this WasRequest req)
		{
			try
			{
				object id = null;

				BMCustomerBrand customer = req.Data.JsonToAnyType<BMCustomerBrand>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertBMCustomerBrand", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMCustomerBrand", customer);
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

		private static void SaveCustomerChannel(this WasRequest req)
		{
			try
			{
				object id = null;

				BMCustomerChannel customer = req.Data.JsonToAnyType<BMCustomerChannel>();
				if (customer != null)
				{
					if (customer.ID.IsNullOrDefault())
					{
						customer.CreateBy = req.User.UserId;
						customer.CreateByName = req.User.UserName;

						id = DaoFactory.InstanceBiz.Insert("InsertBMCustomerChannel", customer);
						customer.ID = id.ToIntegerNullToNull();
					}
					else
					{
						customer.UpdateBy = req.User.UserId;
						customer.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBMCustomerChannel", customer);
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

	}
}
