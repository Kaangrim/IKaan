using System.Collections.Generic;
using System.Linq;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Sales.Address;
using IKaan.Model.Biz.Sales.Order;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceOrder
	{ 
		public static OrderModel GetOrder(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<OrderModel>("SelectOrder", parameter);
				if (model != null)
				{
					//Billing Address
					if (model.BillingAddressID != null) { 
						model.BillingAddress = DaoFactory.InstanceBiz.QueryForObject<BillingAddressModel>("SelectBillingAddress", new DataMap() { { "ID", model.BillingAddressID } });
					}
					if (model.BillingAddress == null)
						model.BillingAddress = new BillingAddressModel();

					if (model.BillingAddress.AddressID != null)
					{
						model.BillingAddress.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", new DataMap() { { "ID", model.BillingAddress.AddressID } });
					}
					if (model.BillingAddress.Address == null)
						model.BillingAddress.Address = new AddressModel();


					//Shipping Address
					if (model.ShippingAddressID != null)
					{
						model.ShippingAddress = DaoFactory.InstanceBiz.QueryForObject<ShippingAddressModel>("SelectShippingAddress", new DataMap() { { "ID", model.ShippingAddressID } });
					}
					if (model.ShippingAddress.Address == null)
						model.ShippingAddress.Address = new AddressModel();

					if (model.ShippingAddress.AddressID != null)
					{
						model.ShippingAddress.Address = DaoFactory.InstanceBiz.QueryForObject<AddressModel>("SelectAddress", new DataMap() { { "ID", model.ShippingAddress.AddressID } });
					}
					if (model.ShippingAddress.Address == null)
						model.ShippingAddress.Address = new AddressModel();

					//상품상세
					model.Items = DaoFactory.InstanceBiz.QueryForList<OrderItemModel>("SelectOrderItemList", new DataMap() { { "OrderID", model.ID } });
					if (model.Items == null)
						model.Items = new List<OrderItemModel>();

					//비고사항
					model.Notes = DaoFactory.InstanceBiz.QueryForList<OrderNoteModel>("SelectOrderNoteList", new DataMap() { { "OrderID", model.ID } });
					if (model.Notes == null)
						model.Notes = new List<OrderNoteModel>();
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

		public static void SaveOrder(this WasRequest req)
		{
			try
			{
				int count = 0;
				var model = req.Data.JsonToAnyType<OrderModel>();
				if (model != null)
				{
					var map = new DataMap()
					{
						{ "StoreID", model.StoreID },
						{ "ChannelID", model.ChannelID },
						{ "OrderNo", model.OrderNo }
					};
					if (model.ID == null)
					{
						var exists = DaoFactory.InstanceBiz.QueryForObject<OrderModel>("SelectOrderExists", map);
						if (exists == null)
						{
							model.CreatedBy = req.User.UserId;
							model.CreatedByName = req.User.UserName;
							var id = DaoFactory.InstanceBiz.Insert("InsertOrder", model);
							model.ID = id.ToIntegerNullToNull();
						}
						else
						{
							model.ID = exists.ID;
							model.UpdatedBy = req.User.UserId;
							model.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateOrder", model);
						}
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateOrder", model);
					}

					if (model.Items != null)
					{
						//이미 등록된 주문상세를 비교하여 수정된 리스트에 없으면 삭제한다.
						IList<OrderItemModel> itemlist = DaoFactory.InstanceBiz.QueryForList<OrderItemModel>("SelectOrderItemList", new DataMap() { { "OrderID", model.ID } });
						if (itemlist != null)
						{
							foreach (var item in itemlist)
							{
								if (model.Items.Where(x => x.ID == item.ID).Any() == false)
								{
									DaoFactory.InstanceBiz.Delete("DeleteOrderItem", new DataMap() { { "ID", item.ID } });
								}
							}
						}

						foreach (var item in model.Items)
						{
							var exists = DaoFactory.InstanceBiz.QueryForObject<OrderItemModel>("SelectOrderItem", new DataMap() { { "ID", item.ID } });
							if (exists == null)
							{
								item.OrderID = model.ID;
								item.CreatedBy = req.User.UserId;
								item.CreatedByName = req.User.UserName;
								var id = DaoFactory.InstanceBiz.Insert("InsertOrderItem", item);
								item.ID = id.ToIntegerNullToNull();
							}
							else
							{
								item.UpdatedBy = req.User.UserId;
								item.UpdatedByName = req.User.UserName;
								DaoFactory.InstanceBiz.Update("UpdateOrderItem", item);
							}

							model.TotalOrderQty += item.OrderQty;
							model.TotalOrderAmt += item.OrderAmt;
							model.TotalDiscountAmt += item.DiscountAmt;
							model.TotalCouponAmt += item.CouponAmt;
							model.TotalDeliveryFee += item.DeliveryFee;
							model.TotalSupplyAmt += item.SupplyAmt;
						}

						//금액수정
						DaoFactory.InstanceBiz.Update("UpdateOrder", model);
					}
				}

				req.Result.Count = count;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}
		public static void DeleteOrder(this WasRequest req)
		{
			try
			{
				var parameter = req.Data.JsonToAnyType<DataMap>();
				if (parameter != null)
				{
					DaoFactory.InstanceBiz.Delete("DeleteOrderNoteByOrderID", new DataMap() { { "OrderID", parameter.GetValue("ID") } });
					DaoFactory.InstanceBiz.Delete("DeleteOrderItemByOrderID", new DataMap() { { "OrderID", parameter.GetValue("ID") } });
					DaoFactory.InstanceBiz.Delete("DeleteOrder", new DataMap() { { "ID", parameter.GetValue("ID") } });
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = null;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}
	}
}
