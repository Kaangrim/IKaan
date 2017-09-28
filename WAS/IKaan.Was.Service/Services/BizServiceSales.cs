using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Sales;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceSales
	{ 				
		public static void SaveOrderSumByChannel(this WasRequest req)
		{
			try
			{
				int count = 0;
				var model = req.Data.JsonToAnyType<OrderSumByChannelModel>();
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
									line.CreatedBy = req.User.UserId;
									line.CreatedByName = req.User.UserName;

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

									line.UpdatedBy = req.User.UserId;
									line.UpdatedByName = req.User.UserName;

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
									line.CreatedBy = req.User.UserId;
									line.CreatedByName = req.User.UserName;

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

									line.UpdatedBy = req.User.UserId;
									line.UpdatedByName = req.User.UserName;

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
