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
					var imageID = model.ImageID;
					if (imageID == null)
					{
						if (model.Image != null)
						{
							model.Image.CreatedBy = req.User.UserId;
							model.Image.CreatedByName = req.User.UserName;
							var id = DaoFactory.InstanceBiz.Insert("InsertImage", model.Image);
							model.Image.ID = id.ToIntegerNullToNull();
						}
					}
					else
					{
						if (model.Image != null)
						{
							model.Image.ID = imageID;
							model.Image.UpdatedBy = req.User.UserId;
							model.Image.UpdatedByName = req.User.UserName;
							DaoFactory.InstanceBiz.Update("UpdateImage", model.Image);
						}
						else
						{
							model.ImageID = null;
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

						if (imageID != null && model.Image == null)
						{
							DaoFactory.InstanceBiz.Delete("DeleteImage", new DataMap() { { "ID", imageID } });
						}
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
