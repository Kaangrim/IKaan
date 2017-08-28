using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class LiveServicePartial
	{
		public static void SaveChannelOrder(this WasRequest req)
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

		public static void SaveChannelOrderCancel(this WasRequest req)
		{
			try
			{
				
				req.Result.Count = 1;
				req.Result.ReturnValue = null;
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
