using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap.Common;
using IKaan.Model.Scrap.Smaps;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class ScrapServiceSmaps
	{
		public static void SaveSmapsAgency(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsAgencyModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsAgencyExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsAgency", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsAgency", model);
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

		public static void SaveSmapsBrand(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsBrandModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsBrandExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsBrand", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsBrand", model);
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

		public static void SaveSmapsCategory(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsCategoryModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsCategoryExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsCategory", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsCategory", model);
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

		public static void SaveSmapsColor(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsColorModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsColorExists", new DataMap()
				{
					{ "value", model.value }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsColor", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsColor", model);
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

		public static void SaveSmapsLookbook(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsLookbookModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsLookbookExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsLookbook", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsLookbook", model);
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

		public static void SaveSmapsProduct(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsProductModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsProductExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsProduct", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsProduct", model);
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

		public static void SaveSmapsSize(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsSizeModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsSizeExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsSize", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsSize", model);
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

		public static void SaveSmapsUser(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsUserModel>();
				var exists = DaoFactory.InstanceScrap.QueryForObject<ScrapBrandModel>("SelectSmapsUserExists", new DataMap()
				{
					{ "uid", model.uid }
				});

				if (exists == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsUser", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.ID = exists.ID;
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsUser", model);
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

		public static void SaveSmapsRequest(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<SmapsRequestModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;

					object id = DaoFactory.InstanceScrap.Insert("InsertSmapsRequest", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;

					DaoFactory.InstanceScrap.Update("UpdateSmapsRequest", model);
				}

				if (model.Data != null)
				{
					switch (model.RequestType)
					{
						case "SmapsAgency":							
							foreach(var data in model.Data.JsonToAnyType<IList<SmapsAgencyModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsAgency", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsAgency", data);
								}
							}
							break;
						case "SmapsBrand":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsBrandModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsBrand", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsBrand", data);
								}
							}
							break;
						case "SmapsLookbook":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsLookbookModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsLookbook", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsLookbook", data);
								}
							}
							break;
						case "SmapsCategory":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsCategoryModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsCategory", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsCategory", data);
								}
							}
							break;
						case "SmapsColor":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsColorModel>>())
							{
								if (data.ID == null && data.value == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsColor", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsColor", data);
								}
							}
							break;
						case "SmapsSize":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsSizeModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsSize", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsSize", data);
								}
							}
							break;
						case "SmapsProduct":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsProductModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsProduct", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsProduct", data);
								}
							}
							break;
						case "SmapsUser":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsUserModel>>())
							{
								if (data.ID == null && data.uid == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsUser", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.RequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsUser", data);
								}
							}
							break;
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
