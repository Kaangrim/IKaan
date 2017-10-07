using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Brand;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceBrand
	{
		public static BrandModel GetBrand(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<BrandModel>("SelectBrand", parameter);
				if (model != null)
				{
					//브랜드채널
					model.Channels = DaoFactory.InstanceBiz.QueryForList<ChannelBrandModel>("SelectChannelBrandList", new DataMap() { { "BrandID", parameter.GetValue("ID") } });
					if (model.Channels == null)
						model.Channels = new List<ChannelBrandModel>();

					//브랜드속성
					model.Attributes = DaoFactory.InstanceBiz.QueryForList<BrandAttributeModel>("SelectBrandAttributeList", new DataMap() { { "BrandID", parameter.GetValue("ID") } });
					if (model.Attributes == null)
						model.Attributes = new List<BrandAttributeModel>();

					//브랜드이미지
					model.Images = DaoFactory.InstanceBiz.QueryForList<BrandImageModel>("SelectBrandImageList", new DataMap() { { "BrandID", parameter.GetValue("ID") } });
					if (model.Images == null)
						model.Images = new List<BrandImageModel>();
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

		public static BrandImageModel GetBrandImage(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var model = DaoFactory.InstanceBiz.QueryForObject<BrandImageModel>("SelectBrandImage", parameter);
				if (model != null)
				{
					model.Image = DaoFactory.InstanceBiz.QueryForObject<ImageModel>("SelectImage", new DataMap() { { "ID", model.ImageID } });
					if (model.Image == null)
						model.Image = new ImageModel();
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

		public static void SaveBrand(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<BrandModel>();
				if (model.ID == null)
				{
					var exists = DaoFactory.InstanceBiz.QueryForObject<BrandModel>("SelectBrandByName", new DataMap() { { "Name", model.Name.Trim() } });
					if (exists == null)
					{
						model.CreatedBy = req.User.UserId;
						model.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertBrand", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.ID = exists.ID;
						model.Category = exists.Category;
						model.Style = exists.Style;
						model.Url = exists.Url;
						model.UseYn = "Y";
						model.UpdatedBy = req.User.UserId;
						model.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateBrand", model);
					}
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateBrand", model);
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

		public static void SaveBrandImage(this WasRequest req)
		{
			try
			{
				var model = req.Data.JsonToAnyType<BrandImageModel>();

				var imageID = model.ImageID;
				if (Regex.IsMatch(model.Image.RowState.ToStringNullToEmpty().ToUpper(), "INSERT|UPDATE"))
				{
					if (imageID == null)
					{
						model.Image.CreatedBy = req.User.UserId;
						model.Image.CreatedByName = req.User.UserName;
						var id = DaoFactory.InstanceBiz.Insert("InsertImage", model.Image);
						model.Image.ID = id.ToIntegerNullToNull();
						model.ImageID = id.ToIntegerNullToNull();
					}
					else
					{
						model.Image.ID = model.ImageID;
						model.Image.UpdatedBy = req.User.UserId;
						model.Image.UpdatedByName = req.User.UserName;
						DaoFactory.InstanceBiz.Update("UpdateImage", model.Image);
					}
				}
				else if (model.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
				{
					model.ImageID = null;
				}

				if (model.ID == null)
				{
					model.CreatedBy = req.User.UserId;
					model.CreatedByName = req.User.UserName;
					var id = DaoFactory.InstanceBiz.Insert("InsertBrandImage", model);
					model.ID = id.ToIntegerNullToNull();
				}
				else
				{
					model.UpdatedBy = req.User.UserId;
					model.UpdatedByName = req.User.UserName;
					DaoFactory.InstanceBiz.Update("UpdateBrandImage", model);

					if (imageID != null && model.Image.RowState.ToStringNullToEmpty().ToUpper() == "DELETE")
					{
						DaoFactory.InstanceBiz.Delete("DeleteImage", new DataMap() { { "ID", imageID } });
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
