using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base.Common;
using IKaan.Model.Biz.Catalog.Product;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Sales.Address;
using IKaan.Model.Biz.Sales.Order;
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

		public static void SaveChannelOrderToBizOrder(this WasRequest req)
		{
			var storeID = 1002;
			var productType = "10";
			var categoryID = 1000;

			try
			{				
				var model = req.Data.JsonToAnyType<ChannelOrderModel>();
				if (model != null)
				{
					if (model.Status == "0")
					{
						#region 상점ID 가져오기
						var store = DaoFactory.Instance.QueryForObject<CodeModel>("SelectCodeByCode", new DataMap()
						{
							{ "Code", "LiveStoreID" },
							{ "ParentCode", "System" }
						});

						if (store != null)
						{
							storeID = store.Value.ToIntegerNullToZero();
						}
						#endregion

						#region 주문헤더저장
						object orderID = 0;
						var parameter = new DataMap()
						{
							{ "StoreID", storeID },
							{ "ChannelID", model.ChannelID },
							{ "OrderNo", model.OrderNo }
						};
						var exists = DaoFactory.InstanceBiz.QueryForObject<OrderModel>("SelectOrderExists", parameter);
						if (exists == null)
						{
							var order = new OrderModel()
							{
								StoreID = storeID,
								ChannelID = model.ChannelID,
								MemberID = null,
								OrderDate = model.OrderDate.Value,
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
						object productID = null;
						var itemParams = new DataMap()
						{
							{ "StoreID", storeID },
							{ "ChannelID", model.ChannelID },
							{ "ProductCode", model.GoodsCode }
						};

						var productExists = DaoFactory.InstanceBiz.QueryForObject<OrderItemModel>("SelectOrderItemByProductCode", itemParams);
						if (productExists != null)
						{
							productID = productExists.ProductID;
						}
						else
						{
							var defaultCategory = DaoFactory.Instance.QueryForObject<CodeModel>("SelectCodeByCode", new DataMap()
							{
								{ "Code", "LiveCategory" },
								{ "ParentCode", "System" }
							});
							if (defaultCategory != null)
								categoryID = defaultCategory.Value.ToIntegerNullToZero();

							var product = new ProductModel()
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

							productID = DaoFactory.InstanceBiz.Insert("InsertProduct", product);
							product.ID = productID.ToIntegerNullToNull();
						}
						#endregion

						#region 주문상세 저장
						var item = new OrderItemModel()
						{
							OrderID = orderID.ToIntegerNullToNull(),
							ProductID = productID.ToIntegerNullToZero(),
							ProductCode = model.GoodsCode,
							ProductName = model.GoodsName,
							Option1 = model.Option1,
							Option2 = model.Option2,
							Bundle = model.GiftName,
							SalePrice = model.SalePrice,
							OrderQty = model.OrderQty,
							OrderAmt = model.SaleAmt,
							DiscountAmt = 0,
							CouponAmt = model.CouponAmt,
							DeliveryFee = model.DeliveryFee,
							SupplyPrice = model.SupplyPrice,
							SupplyAmt = model.SupplyAmt,
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

						#region  채널오더에 주문ID, 주문상세ID, 처리상태를 업데이트한다.
						model.OrderID = orderID.ToIntegerNullToNull();
						model.OrderItemID = orderItemID.ToIntegerNullToNull();
						DaoFactory.InstanceLive.Update("UpdateChannelOrderOrderID", model);
						#endregion
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
