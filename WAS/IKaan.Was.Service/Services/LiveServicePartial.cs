using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Live;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class LiveServicePartial
	{
		public static void SaveChannelOrder(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ChannelOrderModel>();
				if (model != null)
				{
					//업로드 데이터의 브랜드ID가 널인 경우 
					//기존 데이터에서 찾아서 자동으로 업데이트한다.
					if (model.BrandID == null)
					{
						DataMap findMap = new DataMap()
						{
							{ "ChannelID", model.ChannelID },
							{ "GoodsCode", model.GoodsCode }
						};
						var find = DaoFactory.InstanceLive.QueryForObject<ChannelOrderModel>("SelectChannelOrderByGoodsCode", findMap);
						if (find != null && find.BrandID != null)
						{
							model.BrandID = find.BrandID;
							model.BrandName = find.BrandName;
						}
					}

					//채널오더 저장
					if (model.ID == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceLive.Insert("InsertChannelOrder", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceLive.Update("UpdateChannelOrder", model);
					}
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

		public static void SaveChannelOrderBrand(this WasRequest req)
		{
			try
			{
				ChannelOrderModel model = req.Data.JsonToAnyType<ChannelOrderModel>();
				if (model != null)
				{
					if (model.ID != null)
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceLive.Update("UpdateChannelOrderBrand", model);
					}
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

		public static void SaveChannelOrderCancel(this WasRequest req)
		{
			try
			{
				ChannelOrderCancelModel model = req.Data.JsonToAnyType<ChannelOrderCancelModel>();
				if (model != null)
				{
					if (model.ID == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceLive.Insert("InsertChannelOrderCancel", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceLive.Update("UpdateChannelOrderCancel", model);
					}
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

		public static void SaveChannelOrderReturn(this WasRequest req)
		{
			try
			{
				ChannelOrderReturnModel model = req.Data.JsonToAnyType<ChannelOrderReturnModel>();
				if (model != null)
				{
					if (model.ID == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceLive.Insert("InsertChannelOrderReturn", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceLive.Update("UpdateChannelOrderReturn", model);
					}
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
