using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class ScrapServicePartial
	{
		public static void SaveBrandInfo(this WasRequest req)
		{
			try
			{
				BrandInfoModel brand = req.Data.JsonToAnyType<BrandInfoModel>();

				DataMap map = new DataMap()
				{
					{ "SiteCode", brand.SiteCode },
					{ "BrandCode", brand.BrandCode }
				};
				var exists = DaoFactory.InstanceScrap.QueryForObject<BrandInfoModel>("SelectBrandInfoExists", map);
				if (exists == null)
				{
					brand.CreateBy = req.User.UserId;
					brand.CreateByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertBrandInfo", brand);
					brand.ID = id.ToIntegerNullToNull();
				}
				else
				{
					if (exists.BrandCode != brand.BrandCode ||
						exists.BrandCode != brand.BrandName ||
						exists.BrandURL != brand.BrandURL ||
						exists.GoodsCnt != brand.GoodsCnt)
					{
						brand.ID = exists.ID;
						brand.UpdateBy = req.User.UserId;
						brand.UpdateByName = req.User.UserName;

						DaoFactory.InstanceScrap.Update("UpdateBrandInfo", brand);
					}
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = brand.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		public static void SaveGoodsInfo(this WasRequest req)
		{
			try
			{
				GoodsInfoModel goods = req.Data.JsonToAnyType<GoodsInfoModel>();

				DataMap map = new DataMap()
				{
					{ "SiteCode", goods.SiteCode },
					{ "BrandCode", goods.BrandCode },
					{ "GoodsCode", goods.GoodsCode },
					{ "GoodsName", goods.GoodsName }
				};
				var exists = DaoFactory.InstanceScrap.QueryForObject<GoodsInfoModel>("SelectGoodsInfoExists", map);
				if (exists == null)
				{
					goods.CreateBy = req.User.UserId;
					goods.CreateByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertGoodsInfo", goods);
					goods.ID = id.ToIntegerNullToNull();
				}
				else
				{
					if (exists.GoodsCode != goods.GoodsCode ||
						exists.GoodsName != goods.GoodsName ||
						exists.GoodsURL != goods.GoodsURL ||
						exists.ListPrice != goods.ListPrice ||
						exists.SalePrice != goods.SalePrice ||
						exists.CategoryName != goods.CategoryName ||
						exists.ImageURL != goods.ImageURL ||
						exists.Option1Type != goods.Option1Type ||
						exists.Option1Name != goods.Option1Name ||
						exists.Option2Type != goods.Option2Type ||
						exists.Option2Name != goods.Option2Name)
					{
						goods.ID = exists.ID;
						goods.UpdateBy = req.User.UserId;
						goods.UpdateByName = req.User.UserName;

						DaoFactory.InstanceScrap.Update("UpdateGoodsInfo", goods);
					}
				}

				req.Result.Count = 1;
				req.Result.ReturnValue = goods.ID;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}
	}
}
