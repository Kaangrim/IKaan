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
				ChannelOrderModel model = req.Data.JsonToAnyType<ChannelOrderModel>();
				if (model != null)
				{
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
