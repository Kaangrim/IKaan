using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap.Api;
using IKaan.Model.Scrap.Smaps;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class ScrapServiceApi
	{
		public static void SaveApiRequest(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<ApiRequestModel>();
				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					object id = DaoFactory.InstanceScrap.Insert("InsertApiRequest", model);
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
					switch (model.ApiModel)
					{
						case "SmapsAgency":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsAgencyModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsAgencyModel>("SelectSmapsAgencyExists", new DataMap() { { "uid", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsAgency", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsAgency", data);
								}
							}
							break;
						case "SmapsAgencyReceive":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsAgencyReceiveModel>>())
							{
								var save = new SmapsAgencyModel()
								{
									uid = data.uid,
									name = data.agency_name
								};

								if (save.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsAgencyModel>("SelectSmapsAgencyExists", new DataMap() { { "uid", save.uid } });
									if (exists != null)
										save.ID = exists.ID;
								}

								if (save.ID == null)
								{
									save.CreatedBy = req.User.UserId;
									save.CreatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsAgency", save);
									save.ID = id.ToIntegerNullToNull();
								}
								else
								{
									save.UpdatedBy = req.User.UserId;
									save.UpdatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsAgency", save);
								}
							}
							break;
						case "SmapsBrand":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsBrandModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsBrandModel>("SelectSmapsBrandExists", new DataMap() { { "uid", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsBrand", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsBrand", data);
								}
							}
							break;
						case "SmapsBrandReceive":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsBrandReceiveModel>>())
							{
								var save = new SmapsBrandModel()
								{
									uid = data.uid,
									name = data.brand_name,
									agency_uid = data.agency_uid,
									manager = data.manager_uid
								};

								if (save.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsBrandModel>("SelectSmapsBrandExists", new DataMap() { { "uid", save.uid } });
									if (exists != null)
										save.ID = exists.ID;
								}

								if (save.ID == null)
								{
									save.CreatedBy = req.User.UserId;
									save.CreatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsBrand", save);
									save.ID = id.ToIntegerNullToNull();
								}
								else
								{
									save.UpdatedBy = req.User.UserId;
									save.UpdatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsBrand", save);
								}
							}
							break;
						case "SmapsLookbook":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsLookbookModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsLookbookModel>("SelectSmapsLookbookExists", new DataMap() { { "uid", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsLookbook", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsLookbook", data);
								}
							}
							break;
						case "SmapsLookbookReceive":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsLookbookReceiveModel>>())
							{
								var save = new SmapsLookbookModel()
								{
									uid = data.uid,
									title = data.title,
									agency_uid = data.agency_uid,
									brand_uid = data.brand_uid
								};

								if (save.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsLookbookModel>("SelectSmapsLookbookExists", new DataMap() { { "uid", save.uid } });
									if (exists != null)
										save.ID = exists.ID;
								}

								if (save.ID == null)
								{
									save.CreatedBy = req.User.UserId;
									save.CreatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsLookbook", save);
									save.ID = id.ToIntegerNullToNull();
								}
								else
								{
									save.UpdatedBy = req.User.UserId;
									save.UpdatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsLookbook", save);
								}
							}
							break;
						case "SmapsCategory":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsCategoryModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsCategoryModel>("SelectSmapsCategoryExists", new DataMap() { { "uid", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsCategory", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsCategory", data);
								}
							}
							break;
						case "SmapsColor":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsColorModel>>())
							{
								if (data.value != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsColorModel>("SelectSmapsColorExists", new DataMap() { { "value", data.value } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsColor", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsColor", data);
								}
							}
							break;
						case "SmapsSize":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsSizeModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsSizeModel>("SelectSmapsSizeExists", new DataMap() { { "value", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsSize", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsSize", data);
								}
							}
							break;
						case "SmapsProduct":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsProductModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsProductModel>("SelectSmapsProductExists", new DataMap() { { "uid", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsProduct", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsProduct", data);
								}
							}
							break;
						case "SmapsUser":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsUserModel>>())
							{
								if (data.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsUserModel>("SelectSmapsUserExists", new DataMap() { { "uid", data.uid } });
									if (exists != null)
										data.ID = exists.ID;
								}

								if (data.ID == null)
								{
									data.CreatedBy = req.User.UserId;
									data.CreatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsUser", data);
									data.ID = id.ToIntegerNullToNull();
								}
								else
								{
									data.UpdatedBy = req.User.UserId;
									data.UpdatedByName = req.User.UserName;
									data.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsUser", data);
								}
							}
							break;
						case "SmapsUserReceive":
							foreach (var data in model.Data.JsonToAnyType<IList<SmapsUserReceiveModel>>())
							{
								var save = new SmapsUserModel()
								{
									uid = data.uid,
									name = data.name,
									utype = data.utype,
									agency_uid = data.agency_uid
								};

								if (save.uid != null)
								{
									var exists = DaoFactory.InstanceScrap.QueryForObject<SmapsUserModel>("SelectSmapsUserExists", new DataMap() { { "uid", save.uid } });
									if (exists != null)
										save.ID = exists.ID;
								}

								if (save.ID == null)
								{
									save.CreatedBy = req.User.UserId;
									save.CreatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									object id = DaoFactory.InstanceScrap.Insert("InsertSmapsUser", save);
									save.ID = id.ToIntegerNullToNull();
								}
								else
								{
									save.UpdatedBy = req.User.UserId;
									save.UpdatedByName = req.User.UserName;
									save.ApiRequestID = model.ID.ToIntegerNullToZero();
									DaoFactory.InstanceScrap.Update("UpdateSmapsUser", save);
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
