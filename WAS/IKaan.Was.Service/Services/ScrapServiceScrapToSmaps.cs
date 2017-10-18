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
					var category = DaoFactory.InstanceScrap.QueryForObject<SmapsCategoryModel>("SelectScrapCategoryToSmapsID", new DataMap() { { "ScrapCategoryID", data.CategoryID } });
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
						category_uid = category.uid,
						sex = sex
					};

					//옵션추출
					var colorlist = new List<string>();
					var sizelist = new List<string>();

					if (data.Code == "300300751")
					{
						colorlist = new List<string>();
					}

					#region 옵션명칭 비교 -> 옵션 값 추출
					if (data.Option1Type.IsNullOrEmpty() == false && data.Option1Name.IsNullOrEmpty() == false)
					{
						foreach (var str in data.Option1Name.Split(','))
						{
							var opt = DaoFactory.InstanceScrap.QueryForObject<ScrapOptionModel>("SelectScrapOptionExists", new DataMap() { { "Name", str.Trim() } });
							if (opt != null)
							{
								if (opt.Option1Type.IsNullOrEmpty() == false)
								{
									if (opt.Option1Type.ToUpper() == "COLOR")
										colorlist.Add(opt.Option1Value);
									else if (opt.Option1Type.ToUpper() == "SIZE")
										sizelist.Add(opt.Option1Value);
								}

								if (opt.Option2Type.IsNullOrEmpty() == false)
								{
									if (opt.Option2Type.ToUpper() == "COLOR")
										colorlist.Add(opt.Option2Value);
									else if (opt.Option2Type.ToUpper() == "SIZE")
										sizelist.Add(opt.Option2Value);
								}
							}
						}
					}

					if (data.Option2Type.IsNullOrEmpty() == false && data.Option2Name.IsNullOrEmpty() == false)
					{
						foreach (var str in data.Option2Name.Split(','))
						{
							var opt = DaoFactory.InstanceScrap.QueryForObject<ScrapOptionModel>("SelectScrapOptionExists", new DataMap() { { "Name", str.Trim() } });
							if (opt != null)
							{
								if (opt.Option1Type.IsNullOrEmpty() == false)
								{
									if (opt.Option1Type.ToUpper() == "COLOR")
										colorlist.Add(opt.Option1Value);
									else if (opt.Option1Type.ToUpper() == "SIZE")
										sizelist.Add(opt.Option1Value);
								}

								if (opt.Option2Type.IsNullOrEmpty() == false)
								{
									if (opt.Option2Type.ToUpper() == "COLOR")
										colorlist.Add(opt.Option2Value);
									else if (opt.Option2Type.ToUpper() == "SIZE")
										sizelist.Add(opt.Option2Value);
								}
							}
						}
					}
					#endregion

					var sizes = new Dictionary<int, string>();
					var colors = new Dictionary<string, string>();
					var optionlist = new List<SmapsOptionModel>();
					var option_size_ids = new List<int>();
					var option_size_names = new List<string>();
					var option_color_ids = new List<string>();
					var option_color_names = new List<string>();

					foreach (var color in colorlist)
					{
						var option_color = DaoFactory.InstanceScrap.QueryForObject<SmapsColorModel>("SelectSmapsColorByCode", new DataMap() { { "value", color } });
						if (option_color != null)
						{
							if (colors.ContainsKey(option_color.value) == false)
								colors.Add(option_color.value, option_color.text);
						}
					}

					foreach (var size in sizelist)
					{
						var option_size = DaoFactory.InstanceScrap.QueryForObject<SmapsSizeModel>("SelectSmapsSizeByName", new DataMap()
						{
							{ "category_uid", save.category_uid },
							{ "sex", save.sex },
							{ "text", size }
						});

						if (option_size != null)
						{
							if (sizes.ContainsKey(option_size.uid.ToIntegerNullToZero()) == false)
								sizes.Add(option_size.uid.ToIntegerNullToZero(), option_size.text);
						}
						else
						{
							var option_size2 = DaoFactory.InstanceScrap.QueryForObject<SmapsSizeModel>("SelectSmapsSizeOne", new DataMap()
							{
								{ "category_uid", save.category_uid },
								{ "sex", save.sex }
							});

							if (option_size2 != null)
							{
								if (sizes.ContainsKey(option_size2.uid.ToIntegerNullToZero()) == false)
									sizes.Add(option_size2.uid.ToIntegerNullToZero(), option_size2.text);
							}
						}
					}

					if (colors.Count > 0 && sizes.Count > 0)
					{
						save.option = colors.Count * sizes.Count;

						foreach(var colorPair in colors)
						{
							foreach(var sizePair in sizes)
							{
								option_size_ids.Add(sizePair.Key);
								option_size_names.Add(sizePair.Value);
								option_color_ids.Add(colorPair.Key);
								option_color_names.Add(colorPair.Value);
							}
						}

						save.option_size_uid = string.Join(",", option_size_ids);
						save.option_size_view = string.Join(",", option_size_names);
						save.option_color = string.Join(",", option_color_ids);
						save.option_color_view = string.Join(",", option_color_names);
					}
					
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

					var tosmaps = DaoFactory.InstanceScrap.QueryForObject<ScrapProductToSmapsModel>("SelectScrapProductToSmapsExists", new DataMap() { { "ScrapProductID", data.ID } });
					if (tosmaps != null)
					{
						var smaps = DaoFactory.InstanceScrap.QueryForObject<SmapsProductModel>("SelectSmapsProduct", new DataMap() { { "ID", tosmaps.SmapsProductID } });
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

						tosmaps.UpdatedBy = req.User.UserId;
						tosmaps.UpdatedByName = req.User.UserName;
						tosmaps.SmapsProductID = save.ID;
						DaoFactory.InstanceScrap.Update("UpdateScrapProductToSmaps", tosmaps);
					}
					else
					{
						save.CreatedBy = req.User.UserId;
						save.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceScrap.Insert("InsertSmapsProduct", save);
						save.ID = id.ToIntegerNullToNull();

						tosmaps = new ScrapProductToSmapsModel()
						{
							ScrapProductID = data.ID,
							SmapsProductID = save.ID,
							CreatedBy = req.User.UserId,
							CreatedByName = req.User.UserName
						};
						var id2 = DaoFactory.InstanceScrap.Insert("InsertScrapProductToSmaps", tosmaps);
						data.ID = id2.ToIntegerNullToNull();
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
