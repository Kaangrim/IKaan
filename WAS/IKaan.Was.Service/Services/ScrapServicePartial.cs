using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap.Common;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class ScrapServicePartial
	{
		public static ScrapProductModel GetScrapProduct(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceScrap.QueryForObject<ScrapProductModel>("SelectScrapProduct", parameter);
				if (model != null)
				{
					//이미지
					var imageList = DaoFactory.InstanceScrap.QueryForList<ScrapProductImageModel>("SelectScrapProductImageList", new DataMap() { { "ProductID", model.ID } });
					model.Images = imageList;
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

		public static void SaveScrapBrand(this WasRequest req)
		{
			try
			{
				ScrapBrandModel model = req.Data.JsonToAnyType<ScrapBrandModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectScrapBrandExists", new DataMap()
				{
					{ "SiteID", model.SiteID },
					{ "Code", model.Code }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapBrand", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					if (exists.Code != model.Code ||
						exists.Name != model.Name ||
						exists.Url != model.Url ||
						exists.ProductCount != model.ProductCount)
					{
						model.ID = exists.ID;
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceScrap.Update("UpdateScrapBrand", model);
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

		public static void SaveScrapProduct(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapProductModel>();

				//카테고리저장
				if (model.CategoryName.IsNullOrEmpty() == false)
				{
					var categoryMap = new DataMap()
					{
						{ "SiteID", model.SiteID },
						{ "Name", model.CategoryName }
					};

					var category = DaoFactory.InstanceScrap.QueryForObject<ScrapCategoryModel>("SelectScrapCategoryByName", categoryMap);
					if (category == null)
					{
						category = new ScrapCategoryModel()
						{
							SiteID = model.SiteID,
							Name = model.CategoryName,
							CreatedBy = req.User.UserId,
							CreatedByName = req.User.UserName
						};
						var categoryID = DaoFactory.InstanceScrap.Insert("InsertScrapCategory", category);
						model.CategoryID = categoryID.ToIntegerNullToNull();
					}
					else
					{
						model.CategoryID = category.ID;
					}

					if (model.Gender.IsNullOrEmpty())
					{
						if (model.CategoryName.StartsWith("MEN"))
							model.Gender = "M";
						else if (model.CategoryName.StartsWith("WOMEN"))
							model.Gender = "F";
						else
							model.Gender = "U";
					}
				}

				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapProductModel>("SelectScrapProductExists", new DataMap()
				{
					{ "SiteID", model.SiteID },
					{ "BrandCode", model.BrandCode },
					{ "Code", model.Code }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapProduct", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;

					if (exists.Code != model.Code ||
						exists.Name != model.Name ||
						exists.Url != model.Url ||
						exists.ListPrice != model.ListPrice ||
						exists.SalePrice != model.SalePrice ||
						exists.CategoryName != model.CategoryName ||
						exists.CategoryID != model.CategoryID ||
						exists.Option1Type != model.Option1Type ||
						exists.Option1Name != model.Option1Name ||
						exists.Option1Value != model.Option1Value ||
						exists.Option2Type != model.Option2Type ||
						exists.Option2Name != model.Option2Name ||
						exists.Option2Value != model.Option2Value)
					{	
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;

						DaoFactory.InstanceScrap.Update("UpdateScrapProduct", model);
					}
				}

				if (model.Images != null && model.Images.Count > 0)
				{
					foreach (var image in model.Images)
					{
						if (image.ID == null)
						{
							image.ProductID = model.ID;
							image.CreatedBy = req.User.UserId;
							image.CreatedByName = req.User.UserName;
							object imageId = DaoFactory.InstanceScrap.Insert("InsertScrapProductImage", image);
							image.ID = imageId.ToIntegerNullToNull();
						}
						else
						{
							image.ProductID = model.ID;
							image.UpdatedBy = req.User.UserId;
							image.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceScrap.Update("UpdateScrapProductImage", image);
						}
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

		public static void SaveScrapProductImage(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapProductImageModel>();
				if (model == null)
					throw new System.Exception("저장할 내용이 없습니다.");

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.InstanceScrap.Insert("InsertScrapProductImage", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceScrap.Update("UpdateScrapProductImage", model);
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

		public static void SaveScrapSite(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapSiteModel>();
				if (model == null)
					throw new System.Exception("저장할 내용이 없습니다.");

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.InstanceScrap.Insert("InsertScrapSite", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceScrap.Update("UpdateScrapSite", model);
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
		
		public static void SaveScrapOption(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapOptionModel>();
				if (model == null)
					throw new System.Exception("저장할 내용이 없습니다.");

				if (model.ID == null)
				{
					var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapOptionModel>("SelectScrapOptionExists", new DataMap()
					{
						{ "Name", model.Name }
					});

					if (exists == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;
						object id = DaoFactory.InstanceScrap.Insert("InsertScrapOption", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.ID = exists.ID;
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceScrap.Update("UpdateScrapOption", model);
					}
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceScrap.Update("UpdateScrapOption", model);
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

		public static void BatchScrapOption(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				if (parameter == null)
					throw new Exception("파라미터 내용이 정확하지 않습니다.");

				var list = DaoFactory.InstanceScrap.QueryForList<ScrapProductModel>("SelectScrapProductList", parameter);
				if (list != null && list.Count > 0)
				{
					foreach(var data in list)
					{
						if (data.Option1Name.IsNullOrEmpty() == false)
						{
							foreach(var str in data.Option1Name.Split(','))
							{
								var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapOptionModel>("SelectScrapOptionExists", new DataMap() { { "Name", str } });
								if (exists == null)
								{
									exists = new ScrapOptionModel()
									{
										CreatedOn = DateTime.UtcNow,
										CreatedBy = req.User.UserId,
										CreatedByName = req.User.UserName,
										Name = str
									};

									var id = DaoFactory.InstanceScrap.Insert("InsertScrapOption", exists);
									exists.ID = id.ToIntegerNullToNull();
								}
							}
						}

						if (data.Option2Name.IsNullOrEmpty() == false)
						{
							foreach (var str in data.Option2Name.Split(','))
							{
								var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapOptionModel>("SelectScrapOptionExists", new DataMap() { { "Name", str } });
								if (exists == null)
								{
									exists = new ScrapOptionModel()
									{
										CreatedOn = DateTime.UtcNow,
										CreatedBy = req.User.UserId,
										CreatedByName = req.User.UserName,
										Name = str
									};

									var id = DaoFactory.InstanceScrap.Insert("InsertScrapOption", exists);
									exists.ID = id.ToIntegerNullToNull();
								}
							}
						}
					}
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
