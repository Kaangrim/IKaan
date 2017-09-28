using System.Collections.Generic;
using System.Linq;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap.Common;
using IKaan.Model.Scrap.Mapping;
using IKaan.Model.Scrap.Smaps;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class ScrapServiceScrapToSmaps
	{
		public static void SaveScrapBrandToSmaps(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapBrandToSmapsModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandToSmapsModel>("SelectScrapBrandToSmapsExists", new DataMap()
				{
					{ "ScrapBrandID", model.ScrapBrandID }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapBrandToSmaps", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateScrapBrandToSmaps", model);
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

		public static void SaveScrapCategoryToSmaps(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapCategoryToSmapsModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapCategoryToSmapsModel>("SelectScrapCategoryToSmapsExists", new DataMap()
				{
					{ "ScrapCategoryID", model.ScrapCategoryID }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapCategoryToSmaps", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateScrapCategoryToSmaps", model);
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

		public static void SaveScrapProductToSmaps(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ScrapProductToSmapsModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapProductToSmapsModel>("SelectScrapProductToSmapsExists", new DataMap()
				{
					{ "ScrapProductID", model.ScrapProductID }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapProductToSmaps", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateScrapProductToSmaps", model);
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

		public static void BatchProductReady(this WasRequest req)
		{
			try
			{
				int count = 0;
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				if (parameter == null)
					throw new System.Exception("파라미터 내용이 정확하지 않습니다.");

				var list = DaoFactory.InstanceScrap.QueryForList<ScrapProductModel>("SelectScrapProductByBrand", parameter);
				foreach (var data in list)
				{
					//매핑된 브랜드 정보 추출
					var brand = DaoFactory.InstanceScrap.QueryForObject<SmapsBrandModel>("SelectSmapsBrandExists", new DataMap() { { "uid", parameter.GetValue("brand_uid") } });
					if (brand == null)
						continue;

					//매핑된 카테고리정보 추출
					var category = DaoFactory.InstanceScrap.QueryForObject<ScrapCategoryToSmapsModel>("SelectScrapCategoryToSmapsExists", new DataMap() { { "ScrapCategoryID", data.CategoryID } });
					if (category == null)
						continue;

					//매핑된 룩북정보 추출
					var lookbook = DaoFactory.InstanceScrap.QueryForObject<SmapsLookbookModel>("SelectSmapsLookbookByBrand", new DataMap()
					{
						{ "agency_uid", brand.agency_uid },
						{ "brand_uid", brand.uid }
					});
					if (lookbook == null)
						continue;

					//성별
					string sex = string.Empty;
					if (data.CategoryName.StartsWith("M"))
						sex = "M";
					else if (data.CategoryName.StartsWith("W"))
						sex = "F";
					else
						sex = "U";

					//저장 데이터모델 생성
					var save = new SmapsProductModel()
					{
						agency_uid = brand.agency_uid,
						brand_uid = brand.uid,
						lookbook_uid = lookbook.uid,
						product_name = data.Name,
						product_number = data.Code,
						product_price = data.ListPrice,
						product_unset_price = "N",
						category_uid = category.SmapsCategoryID,
						sex = sex
					};

					//옵션저장
					var optionlist = new List<SmapsOptionModel>();
					int option_count = 0;
					var option_size_ids = new List<int>();
					var option_size_names = new List<string>();
					var option_color_ids = new List<string>();
					var option_color_names = new List<string>();

					if (data.Option1Type.IsNullOrEmpty() == false && data.Option1Value.IsNullOrEmpty() == false)
					{
						foreach(var str in data.Option1Value.Split(','))
						{
							optionlist.Add(new SmapsOptionModel()
							{
								category_uid = save.category_uid.ToIntegerNullToZero(),
								sex = save.sex,
								type = data.Option1Type.ToUpper(),
								name = str
							});
						}
					}

					if (data.Option2Type.IsNullOrEmpty() == false && data.Option2Value.IsNullOrEmpty() == false)
					{
						foreach (var str in data.Option2Value.Split(','))
						{
							optionlist.Add(new SmapsOptionModel()
							{
								category_uid = save.category_uid.ToIntegerNullToZero(),
								sex = save.sex,
								type = data.Option2Type.ToUpper(),
								name = str
							});
						}
					}

					if (optionlist != null && optionlist.Count > 0)
					{
						foreach (var optiondata in optionlist)
						{
							if (optiondata.type == "COLOR")
							{
								var option_color = DaoFactory.InstanceScrap.QueryForObject<SmapsColorModel>("SelectSmapsColorByCode", new DataMap() { { "value", optiondata.name } });
								if (option_color != null)
								{
									option_color_ids.Add(option_color.value);
									option_color_names.Add(option_color.text);
									option_count++;
								}
							}
							else if (optiondata.type == "SIZE")
							{
								var option_size = DaoFactory.InstanceScrap.QueryForObject<SmapsSizeModel>("SelectSmapsSizeByName", new DataMap()
								{
									{ "category_uid", optiondata.category_uid },
									{ "sex", optiondata.sex },
									{ "text", optiondata.name }
								});

								if (option_size != null)
								{
									option_size_ids.Add(option_size.uid.ToIntegerNullToZero());
									option_size_names.Add(option_size.text);
									option_count++;
								}
							}
							else
							{
								var option_size = DaoFactory.InstanceScrap.QueryForObject<SmapsSizeModel>("SelectSmapsSizeOne", new DataMap()
								{
									{ "category_uid", optiondata.category_uid },
									{ "sex", optiondata.sex }
								});

								if (option_size != null)
								{
									option_size_ids.Add(option_size.uid.ToIntegerNullToZero());
									option_size_names.Add(option_size.text);
									option_count++;
								}
							}
						}

						if (option_count > 0)
						{
							save.option_size_uid = string.Join(",", option_size_ids.ToArray());
							save.option_size_view = string.Join(",", option_size_names.ToArray());
							save.option_color = string.Join(",", option_color_ids.ToArray());
							save.option_color_view = string.Join(",", option_color_names.ToArray());
						}
					}
					save.option = option_count;
					
					//이미지저장
					var productImage = new List<string>();
					var productImageWidth = new List<int>();
					var productImageHeight = new List<int>();
					var productIsThumbnail = new List<string>();
					var productIsMain = new List<string>();

					var images = DaoFactory.InstanceScrap.QueryForList<ScrapProductImageModel>("SelectScrapProductImageList", new DataMap() { { "ProductID", data.ID } });
					if (images != null && images.Count > 0)
					{
						int i = 0;
						foreach (var image in images)
						{
							i++;
							productImage.Add(image.Url);
							productImageWidth.Add(image.Width);
							productImageHeight.Add(image.Height);
							productIsThumbnail.Add((image.ImageType == "D") ? "Y" : "N");
							productIsMain.Add((i == 1) ? "Y" : "N");
						}
						save.image = string.Join(",", productImage.ToArray());
						save.image_width = string.Join(",", productImageWidth.ToArray());
						save.image_height = string.Join(",", productImageHeight.ToArray());
						save.is_thumbnail = string.Join(",", productIsThumbnail.ToArray());
						save.is_main = string.Join(",", productIsMain.ToArray());
					}

					var smaps = DaoFactory.InstanceScrap.QueryForObject<SmapsProductModel>("SelectSmapsProductExists", new DataMap() { { "uid", save.uid } });
					if (smaps == null)
					{
						save.CreatedBy = req.User.UserId;
						save.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceScrap.Insert("InsertSmapsProduct", save);
						save.ID = id.ToIntegerNullToNull();
					}
					else
					{
						save.ID = smaps.ID;
						save.UpdatedBy = req.User.UserId;
						save.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceScrap.Update("UpdateSmapsProduct", save);
					}

					//매핑테이블 저장
					var tosmaps = DaoFactory.InstanceScrap.QueryForObject<ScrapProductToSmapsModel>("SelectScrapProductToSmapsExists", new DataMap() { { "ScrapProductID", data.ID } });
					if (tosmaps == null)
					{
						tosmaps = new ScrapProductToSmapsModel()
						{
							ScrapProductID = data.ID,
							SmapsProductID = save.ID,
							CreatedBy = req.User.UserId,
							CreatedByName = req.User.UserName
						};
						var id = DaoFactory.InstanceScrap.Insert("InsertScrapProductToSmaps", tosmaps);
						data.ID = id.ToIntegerNullToNull();
					}
					else
					{
						tosmaps.UpdatedBy = req.User.UserId;
						tosmaps.UpdatedByName = req.User.UserName;
						tosmaps.SmapsProductID = save.ID;
						DaoFactory.InstanceScrap.Update("UpdateScrapProductToSmaps", tosmaps);
					}
					count++;
				}

				req.Result.Count = count;
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
