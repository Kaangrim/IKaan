﻿using System;
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
							req.SetData<BMBusiness>();
							(req.Data as BMBusiness).Address = req.GetData<BMAddress>();
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
						case "BMChannelContact":
							req.SetData<BMChannelContact>();
							break;
						case "BMChannelManager":
							req.SetData<BMChannelManager>();
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
								case "BMChannelContact":
									req.SaveChannelContact();
									break;
								case "BMChannelManager":
									req.SaveChannelManager();
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
			BMBusiness model = req.Data.JsonToAnyType<BMBusiness>();
			BMAddress address = model.Address;
			if (address == null)
				address = new BMAddress();
			if (model.AddressID != null)
				address.ID = model.AddressID;
			if (address.ID == null || address.ID == default(int))
			{
				address.CreateBy = req.User.UserId;
				address.CreateByName = req.User.UserName;
				object id = DaoFactory.InstanceBiz.Insert("InsertBMAddress", address);
				address.ID = id.ToIntegerNullToNull();
				model.AddressID = id.ToIntegerNullToNull();
			}
			else
			{
				address.UpdateBy = req.User.UserId;
				address.UpdateByName = req.User.UserName;
				DaoFactory.InstanceBiz.Update("UpdateBMAddress", address);
			}			
			req.SaveData<BMBusiness>(model);
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
	}
}
