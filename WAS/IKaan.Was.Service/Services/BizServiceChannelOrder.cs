using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base.Common;
using IKaan.Model.Biz.Catalog.Product;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Sales.Address;
using IKaan.Model.Biz.Sales.Order;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceChannelOrder
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
						var find = DaoFactory.InstanceBiz.QueryForObject<ChannelOrderModel>("SelectChannelOrderByGoodsCode", findMap);
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

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelOrder", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateChannelOrder", model);
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

						DaoFactory.InstanceBiz.Update("UpdateChannelOrderBrand", model);
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

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelOrderCancel", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateChannelOrderCancel", model);
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

						object id = DaoFactory.InstanceBiz.Insert("InsertChannelOrderReturn", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateChannelOrderReturn", model);
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

		public static void SaveChannelOrderToBizOrder(this WasRequest req)
		{
			var productType = "10";
			var categoryID = 1000;

			try
			{
				DaoFactory.InstanceBiz.BeginTransaction();

				var model = req.Data.JsonToAnyType<ChannelOrderModel>();
				if (model != null)
				{
					if (model.Status == "0")
					{
						#region 주문헤더저장
						object orderID = 0;
						var parameter = new DataMap()
						{
							{ "StoreID", model.StoreID },
							{ "ChannelID", model.ChannelID },
							{ "OrderNo", model.OrderNo }
						};
						var exists = DaoFactory.InstanceBiz.QueryForObject<OrderModel>("SelectOrderExists", parameter);
						if (exists == null)
						{
							var order = new OrderModel()
							{
								StoreID = model.StoreID,
								ChannelID = model.ChannelID.Value,
								MemberID = null,
								OrderDate = model.OrderDate.Value,
								OrderTime = DateTime.Now.ToString("HH"),
								OrderNo = model.OrderNo,
								Description = model.Description,
								Status = "0",
								CreatedBy = req.User.UserId,
								CreatedByName = req.User.UserName
							};

							var billing = new BillingAddressModel()
							{
								Name = model.Orderer,
								PhoneNo = model.OrdererTelNo,
								MobileNo = model.OrdererMobile,
								Email = model.OrdererEmail,
								CreatedBy = req.User.UserId,
								CreatedByName = req.User.UserName
							};

							var shipping = new ShippingAddressModel()
							{
								Name = model.Recipient,
								PhoneNo = model.RecipientTelNo,
								MobileNo = model.RecipientMobile,
								CreatedBy = req.User.UserId,
								CreatedByName = req.User.UserName
							};

							//배송지주소
							if (model.RecipientAddress.IsNullOrEmpty() == false)
							{
								var addressArray = model.RecipientAddress.Split(' ');
								var address = new AddressModel()
								{
									PostalCode = model.PostalCode,
									Country = "KOR",
									City = addressArray[0],
									StateProvince = addressArray[1],
									AddressLine1 = model.RecipientAddress,
									CreatedBy = req.User.UserId,
									CreatedByName = req.User.UserName
								};

								var id = DaoFactory.InstanceBiz.Insert("InsertAddress", address);
								shipping.AddressID = id.ToIntegerNullToNull();
							}

							//주문자정보저장
							var billingID = DaoFactory.InstanceBiz.Insert("InsertBillingAddress", billing);
							order.BillingAddressID = billingID.ToIntegerNullToNull();

							//배송지정보저장
							var shippingID = DaoFactory.InstanceBiz.Insert("InsertShippingAddress", shipping);
							order.ShippingAddressID = shippingID.ToIntegerNullToNull();

							orderID = DaoFactory.InstanceBiz.Insert("InsertOrder", order);
							order.ID = orderID.ToIntegerNullToNull();
						}
						else
						{
							orderID = exists.ID;
						}
						#endregion

						#region  상품저장
						var product = new ProductModel();						
						var orderitem = DaoFactory.InstanceBiz.QueryForObject<OrderItemModel>("SelectOrderItemByProductCode", new DataMap()
						{
							{ "StoreID", model.StoreID },
							{ "ChannelID", model.ChannelID },
							{ "ProductCode", model.GoodsCode }
						});
						if (orderitem != null)
						{
							product = DaoFactory.InstanceBiz.QueryForObject<ProductModel>("SelectProduct", new DataMap() { { "ID", orderitem.ProductID } });
						}
						else
						{
							product = DaoFactory.InstanceBiz.QueryForObject<ProductModel>("SelectProductByCode", new DataMap() { { "ProductCode", model.GoodsCode } });
							if (product == null)
							{
								if (model.BrandID == null)
									throw new System.Exception("브랜드가 매핑되지 않은 상품이 존재합니다.");

								var category = DaoFactory.Instance.QueryForObject<CodeModel>("SelectCodeByCode", new DataMap()
								{
									{ "Code", "LiveCategory" },
									{ "ParentCode", "System" }
								});
								if (category != null)
									categoryID = category.Value.ToIntegerNullToZero();

								product = new ProductModel()
								{
									Name = model.GoodsName,
									Code = model.GoodsCode,
									ProductType = productType,
									BrandID = model.BrandID.ToIntegerNullToZero(),
									CategoryID = categoryID.ToIntegerNullToZero(),
									ListPrice = model.SalePrice,
									SalePrice = model.SalePrice,
									UseYn = "Y",
									CreatedBy = req.User.UserId,
									CreatedByName = req.User.UserName
								};

								var productid = DaoFactory.InstanceBiz.Insert("InsertProduct", product);
								product.ID = productid.ToIntegerNullToNull();
							}
						}						
						#endregion

						#region 주문상세 저장
						var item = new OrderItemModel()
						{
							OrderID = orderID.ToIntegerNullToNull(),
							ProductID = product.ID.Value,
							ProductCode = model.GoodsCode,
							ProductName = model.GoodsName,
							Option1 = model.Option1,
							Option2 = model.Option2,
							Bundle = model.GiftName,
							SalePrice = model.SalePrice,
							OrderQty = model.OrderQty,
							OrderAmt = model.OrderQty * model.SalePrice,
							DiscountAmt = 0,
							CouponAmt = model.CouponAmt,
							DeliveryFee = model.DeliveryFee,
							SupplyPrice = model.SupplyPrice,
							SupplyAmt = model.SupplyPrice * model.OrderQty,
							CancelYn = "N",
							CancelDate = null,
							ChannelOrderSeq = model.ID.ToStringNullToNull(),
							Currency = "KOR",
							LocalSalePrice = model.SalePrice,
							CreatedBy = req.User.UserId,
							CreatedByName = req.User.UserName
						};

						var orderItemID = DaoFactory.InstanceBiz.Insert("InsertOrderItem", item);
						item.ID = orderItemID.ToIntegerNullToNull();
						#endregion

						//금액수정
						DaoFactory.InstanceBiz.Update("UpdateOrderTotal", new DataMap() { { "ID", orderID } });

						#region 오더집계 저장
						//집계처리(주문집계)
						DaoFactory.InstanceBiz.Update("MergeOrderSumDayByChannelOrderDate", new DataMap()
						{
							{ "StoreID", model.StoreID },
							{ "ChannelID", model.ChannelID },
							{ "OrderDate", model.OrderDate },
							{ "CreatedBy", req.User.UserId },
							{ "CreatedByName", req.User.UserName },
							{ "UpdatedBy", req.User.UserId },
							{ "UpdatedByName", req.User.UserName }
						});

						//집계처리(주문상품집계)
						DaoFactory.InstanceBiz.Update("MergeOrderSumProductByChannelOrderDate", new DataMap()
						{
							{ "StoreID", model.StoreID },
							{ "ChannelID", model.ChannelID },
							{ "OrderDate", model.OrderDate },
							{ "CreatedBy", req.User.UserId },
							{ "CreatedByName", req.User.UserName },
							{ "UpdatedBy", req.User.UserId },
							{ "UpdatedByName", req.User.UserName }
						});

						//집계처리(시간대별 집계)
						DaoFactory.InstanceBiz.Update("MergeOrderSumTimeByChannelOrderDate", new DataMap()
						{
							{ "StoreID", model.StoreID },
							{ "ChannelID", model.ChannelID },
							{ "OrderDate", model.OrderDate },
							{ "CreatedBy", req.User.UserId },
							{ "CreatedByName", req.User.UserName },
							{ "UpdatedBy", req.User.UserId },
							{ "UpdatedByName", req.User.UserName }
						});
						#endregion

						#region  채널오더에 주문ID, 주문상세ID, 처리상태, 브랜드ID를 업데이트한다.
						model.OrderID = orderID.ToIntegerNullToNull();
						model.OrderItemID = orderItemID.ToIntegerNullToNull();
						model.BrandID = product.BrandID;
						DaoFactory.InstanceBiz.Update("UpdateChannelOrderOrderID", model);
						#endregion
					}
				}

				DaoFactory.InstanceBiz.CommitTransaction();
				req.Result.Count = 1;
				req.Result.ReturnValue = model.ID;
				req.Error.Number = 0;
			}
			catch
			{
				DaoFactory.InstanceBiz.RollBackTransaction();
				throw;
			}
		}
	}
}
