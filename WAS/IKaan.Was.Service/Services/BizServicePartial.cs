using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Brand;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.InfoNotice;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Services
{
	public static class BizServicePartial
	{
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
						
	}
}
