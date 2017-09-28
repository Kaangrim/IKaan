using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Catalog;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceCatalog
	{
		public static void SaveCategory(this WasRequest req)
		{
			var model = req.SaveData<CategoryModel>();
			int? parentID = null;
			List<int?> catlist = new List<int?>();

			catlist.Add(model.ID);
			parentID = model.ParentID;
			while (parentID != null)
			{
				catlist.Add(parentID);
				var model2 = DaoFactory.InstanceBiz.QueryForObject<CategoryModel>("SelectCategory", new DataMap() { { "ID", parentID } });
				if (model2 != null && model2.ParentID != null)
					parentID = model2.ParentID;
				else
					parentID = null;
			}

			DataMap map = new DataMap();
			map.SetValue("ID", model.ID);
			for (int i = 0; i < catlist.Count; i++)
			{
				map.SetValue("Category" + (i + 1).ToString(), catlist[i]);
			}
			DaoFactory.InstanceBiz.Update("UpdateCategoryLevel", map);
		}
		
		public static IList<ProductModel> GetProductList(DataMap parameter)
		{
			return DaoFactory.InstanceBiz.QueryForList<ProductModel>("SelectProductList", parameter);
		}

		public static ProductModel GetProductData(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var Product = DaoFactory.InstanceBiz.QueryForObject<ProductModel>("SelectProduct", parameter);
				if (Product != null)
				{
					parameter = new DataMap()
					{
						{ "ProductID", Product.ID },
						{ "CategoryID", Product.CategoryID }
					};

					//상품상세
					Product.Description = DaoFactory.InstanceBiz.QueryForObject<ProductDescriptionModel>("SelectProductDescription", parameter);
					if (Product.Description == null)
						Product.Description = new ProductDescriptionModel();

					//상품 이미지
					Product.Images = DaoFactory.InstanceBiz.QueryForList<ProductImageModel>("SelectProductImageList", parameter);
					if (Product.Images == null)
						Product.Images = new List<ProductImageModel>();

					//상품 옵션
					Product.Items = DaoFactory.InstanceBiz.QueryForList<ProductItemModel>("SelectProductItemList", parameter);
					if (Product.Items == null)
						Product.Items = new List<ProductItemModel>();

					//정보고시
					Product.InfoNotices = DaoFactory.InstanceBiz.QueryForList<ProductInfoNoticeModel>("SelectProductInfoNoticeByCategory", parameter);
					if (Product.InfoNotices == null)
						Product.InfoNotices = new List<ProductInfoNoticeModel>();

					//상품속성
					Product.Attributes = DaoFactory.InstanceBiz.QueryForList<ProductAttributeModel>("SelectProductAttributeList", parameter);
					if (Product.Attributes == null)
						Product.Attributes = new List<ProductAttributeModel>();
				}
				req.Data = Product;
				req.Result.Count = 1;
				return Product;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveProduct(this WasRequest req)
		{
			try
			{
				ProductModel model = req.Data.JsonToAnyType<ProductModel>();

				if (model != null)
				{
					#region 상품 기본정보 저장
					if (model.ID.IsNullOrEmpty())
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertProduct", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateProduct", model);
					}
					#endregion

					#region 상품상세정보
					ProductDescriptionModel detail = DaoFactory.InstanceBiz.QueryForObject<ProductDescriptionModel>("SelectProductDetailList", new DataMap() { { "ProductID", model.ID } });
					if (detail == null)
					{
						model.Description.ProductID = model.ID;
						model.Description.CreatedBy = req.User.UserId;
						model.Description.CreatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Insert("InsertProductDetail", model.Description);
					}
					else
					{
						model.Description.UpdatedBy = req.User.UserId;
						model.Description.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateProductDetail", model.Description);
					}
					#endregion

					#region 품목정보
					if (model.Items != null && model.Items.Count > 0)
					{
						foreach (ProductItemModel item in model.Items)
						{
							if (item.ID.IsNullOrEmpty())
							{
								item.ProductID = model.ID;
								item.CreatedBy = req.User.UserId;
								item.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertProductItem", item);
							}
							else
							{
								ProductItemModel old = DaoFactory.InstanceBiz.QueryForObject<ProductItemModel>("SelectProductItem", new DataMap() { { "ID", item.ID } });
								if (old != null)
								{
									if (old.Option1Type != item.Option1Type ||
										old.Option1Name != item.Option1Name ||
										old.Option2Type != item.Option2Type ||
										old.Option2Name != item.Option2Name)
									{
										item.UpdatedBy = req.User.UserId;
										item.UpdatedByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateProductItem", item);
									}
								}
							}
						}
					}
					#endregion

					#region 속성저장
					if (model.Attributes != null && model.Attributes.Count > 0)
					{
						foreach (ProductAttributeModel attr in model.Attributes)
						{
							if (attr.ID.IsNullOrEmpty())
							{
								attr.ProductID = model.ID;
								attr.CreatedBy = req.User.UserId;
								attr.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertProductAttribute", attr);
							}
							else
							{
								ProductAttributeModel old = DaoFactory.InstanceBiz.QueryForObject<ProductAttributeModel>("SelectProductAttribute", new DataMap() { { "ID", attr.ID } });
								if (old != null)
								{
									if (attr.AttributeName.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteProductAttribute", new DataMap() { { "ID", attr.ID } });
									}
									else
									{
										if (old.AttributeTypeID != attr.AttributeTypeID ||
											old.AttributeID != attr.AttributeID ||
											old.AttributeName != attr.AttributeName)
										{
											attr.UpdatedBy = req.User.UserId;
											attr.UpdatedByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateProductAttribute", attr);
										}
									}
								}
							}
						}
					}
					#endregion

					#region 정보고시저장
					if (model.InfoNotices != null && model.InfoNotices.Count > 0)
					{
						foreach (var info in model.InfoNotices)
						{
							if (info.ID.IsNullOrEmpty())
							{
								if (info.InfoNoticeValue.IsNullOrEmpty() == false)
								{
									info.ProductID = model.ID;
									info.CreatedBy = req.User.UserId;
									info.CreatedByName = req.User.UserName;

									DaoFactory.InstanceBiz.Insert("InsertProductInfoNotice", info);
								}
							}
							else
							{
								var old = DaoFactory.InstanceBiz.QueryForObject<ProductInfoNoticeModel>("SelectProductInfoNotice", new DataMap() { { "ID", info.ID } });

								if (old != null)
								{
									//정보고시값이 없으면 삭제한다.
									if (info.InfoNoticeValue.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteProductInfoNotice", new DataMap() { { "ID", info.ID } });
									}
									else
									{
										if (old.InfoNoticeItemID != info.InfoNoticeItemID ||
											old.InfoNoticeValue != info.InfoNoticeValue)
										{
											info.UpdatedBy = req.User.UserId;
											info.UpdatedByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateProductInfoNotice", info);
										}
									}
								}
							}
						}
					}
					#endregion
				}

				req.Result.ReturnValue = model.ID;
				req.Result.Count = 1;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveProductImage(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ProductModel>();

				if (model != null)
				{
					#region 이미지
					if (model.Images != null && model.Images.Count > 0)
					{
						foreach (var image in model.Images)
						{
							if (image.ID.IsNullOrEmpty())
							{
								image.ProductID = model.ID;
								image.CreatedBy = req.User.UserId;
								image.CreatedByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertProductImage", image);
							}
							else
							{
								var old = DaoFactory.InstanceBiz.QueryForObject<ProductImageModel>("SelectProductImage", new DataMap() { { "ID", image.ID } });
								if (old != null)
								{
									if (old.ImageType != image.ImageType ||
										old.ImageGroup != image.ImageGroup ||
										old.ImageID != image.ImageID)
									{
										image.UpdatedBy = req.User.UserId;
										image.UpdatedByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateProductImage", image);
									}
								}
							}
						}
					}
					#endregion
				}

				req.Result.ReturnValue = model.ID;
				req.Result.Count = 1;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}
								
	}
}
