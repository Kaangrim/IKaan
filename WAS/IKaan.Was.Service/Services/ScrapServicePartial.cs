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
				var model = DaoFactory.InstanceBiz.QueryForObject<ScrapProductModel>("SelectScrapProduct", parameter);
				if (model != null)
				{
					//이미지
					var imageList = DaoFactory.InstanceBiz.QueryForList<ScrapProductImageModel>("SelectScrapProductImage", new DataMap() { { "ProductID", model.ID } });
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
						exists.Option1Type != model.Option1Type ||
						exists.Option1Name != model.Option1Name ||
						exists.Option2Type != model.Option2Type ||
						exists.Option2Name != model.Option2Name)
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

		public static void SaveScrapColor(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapColorModel>();
				if (model == null)
					throw new System.Exception("저장할 내용이 없습니다.");

				if (model.ID == null)
				{
					var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapColorModel>("SelectScrapColorExists", new DataMap()
					{
						{ "SiteID", model.SiteID },
						{ "Name", model.Name }
					});

					if (exists == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;
						object id = DaoFactory.InstanceScrap.Insert("InsertScrapColor", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.ID = exists.ID;
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceScrap.Update("UpdateScrapColor", model);
					}
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceScrap.Update("UpdateScrapColor", model);
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
		public static void SaveScrapSize(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapSizeModel>();
				if (model == null)
					throw new System.Exception("저장할 내용이 없습니다.");

				if (model.ID == null)
				{
					var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapSizeModel>("SelectScrapSizeExists", new DataMap()
					{
						{ "SiteID", model.SiteID },
						{ "CategoryID", model.CategoryID },
						{ "Gender", model.Gender },
						{ "Name", model.Name }
					});

					if (exists == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;
						object id = DaoFactory.InstanceScrap.Insert("InsertScrapSize", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.ID = exists.ID;
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceScrap.Update("UpdateScrapSize", model);
					}
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceScrap.Update("UpdateScrapSize", model);
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
					throw new System.Exception("파라미터 내용이 정확하지 않습니다.");

				//색상옵션 정리
				var colors = DaoFactory.InstanceScrap.QueryForList<ScrapOptionModel>("SelectScrapOptionColorList", parameter);
				if (colors != null && colors.Count > 0)
				{
					foreach (var color in colors)
					{
						string[] names = color.Name.Split(',');
						foreach (var name in names)
						{
							var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapColorModel>("SelectScrapColorExists", new DataMap()
							{
								{ "SiteID", color.SiteID },
								{ "Name", name }
							});

							if (exists == null)
							{
								exists = new ScrapColorModel()
								{
									SiteID = color.SiteID,
									Name = name,
									CreatedBy = req.User.UserId,
									CreatedByName = req.User.UserName
								};
								DaoFactory.InstanceScrap.Insert("InsertScrapColor", exists);
							}
						}
					}
				}

				//사이즈옵션 정리
				var sizes = DaoFactory.InstanceScrap.QueryForList<ScrapOptionModel>("SelectScrapOptionSizeList", parameter);
				if (sizes != null && sizes.Count > 0)
				{
					foreach (var size in sizes)
					{
						string[] names = size.Name.Split(',');
						foreach (var name in names)
						{
							var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapSizeModel>("SelectScrapSizeExists", new DataMap()
							{
								{ "SiteID", size.SiteID },
								{ "CategoryID", size.CategoryID },
								{ "Gender", size.Gender },
								{ "Name", name }
							});

							if (exists == null)
							{
								exists = new ScrapSizeModel()
								{
									SiteID = size.SiteID,
									CategoryID = size.CategoryID,
									Gender = size.Gender,
									Name = name,
									CreatedBy = req.User.UserId,
									CreatedByName = req.User.UserName
								};
								DaoFactory.InstanceScrap.Insert("InsertScrapSize", exists);
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
