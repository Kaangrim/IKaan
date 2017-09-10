using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceStore
	{
		public static StoreModel GetStore(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<StoreModel>("SelectStore", parameter);
				if (model != null)
				{
					//이미지
					var image = DaoFactory.InstanceBiz.QueryForObject<ImageModel>("SelectImage", new DataMap() { { "ID", model.ImageID } });
					model.Image = image;
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
				
		public static void SaveStore(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<StoreModel>();
				if (model != null)
				{
					if (model.Image != null)
					{
						if (model.ImageID == null)
						{
							model.Image.CreatedBy = req.User.UserId;
							model.Image.CreatedByName = req.User.UserName;
							object imageId = DaoFactory.InstanceBiz.Insert("InsertImage", model.Image);
							model.Image.ID = imageId.ToIntegerNullToNull();
							model.ImageID = imageId.ToIntegerNullToNull();
						}
						else
						{
							model.Image.UpdatedBy = req.User.UserId;
							model.Image.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateImage", model.Image);
						}
					}
					else
					{
						if (model.ID != null)
						{
							var old = DaoFactory.InstanceBiz.QueryForObject<StoreModel>("SelectStore", new DataMap() { { "ID", model.ID } });
							if (old != null)
							{
								DaoFactory.InstanceBiz.Delete("DeleteImage", new DataMap() { { "ID", old.ImageID } });
								model.ImageID = null;
							}
						}
					}

					if (model.ID == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;
						object id = DaoFactory.InstanceBiz.Insert("InsertStore", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateStore", model);
					}

					req.Result.Count = 1;
					req.Result.ReturnValue = model.ID;
					req.Error.Number = 0;
				}
			}
			catch
			{
				throw;
			}
		}		
	}
}
