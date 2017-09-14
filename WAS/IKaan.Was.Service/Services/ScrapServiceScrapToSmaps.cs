using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap.Mapping;
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
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandToSmapsModel>("SelectScrapBrandSmapsExists", new DataMap()
				{
					{ "ScrapBrandID", model.ScrapBrandID }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapBrandSmaps", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateScrapBrandSmaps", model);
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
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapCategoryToSmapsModel>("SelectScrapCategorySmapsExists", new DataMap()
				{
					{ "ScrapCategoryName", model.ScrapCategoryName }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapCategorySmaps", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateScrapCategorySmaps", model);
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
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapProductToSmapsModel>("SelectScrapProductSmapsExists", new DataMap()
				{
					{ "ScrapProductID", model.ScrapProductID }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertScrapProductSmaps", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateScrapProductSmaps", model);
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
