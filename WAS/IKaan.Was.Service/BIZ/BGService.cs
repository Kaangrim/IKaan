using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.BIZ.BG;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.BIZ
{
	public static class BGService
	{
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
				{
					throw new Exception("처리요청이 없습니다.");
				}

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				foreach (WasRequest req in list)
				{
					switch (req.ModelName)
					{
						case "BGCategory":
							req.SetList<BGCategory>();
							break;
						case "BGInfoNotice":
							req.SetList<BGInfoNotice>();
							break;
						case "BGGoods":
							req.SetList<BGGoods>();
							break;
						case "BGGoodsInfoNotice":
							req.SetList<BGGoodsInfoNotice>();
							break;
					}
				}

				if (isOneRequest)
				{
					request = list[0];
				}
				else
				{
					request.Data = list;
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest GetData(WasRequest request)
		{
			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
				{
					throw new Exception("처리요청이 없습니다.");
				}

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				var parameter = request.Parameter.JsonToAnyType<DataMap>();

				foreach (WasRequest req in list)
				{
					switch (req.ModelName)
					{
						case "BGCategory":
							req.SetData<BGCategory>();
							break;
						case "BGInfoNotice":
							req.SetData<BGInfoNotice>();
							(req.Data as BGInfoNotice).Items = req.GetList<BGInfoNoticeItem>();
							break;
						case "BGGoods":
							req.GetGoodsData();
							break;
					}
				}

				if (isOneRequest)
				{
					request = list[0];
				}
				else
				{
					request.Data = list;
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest Save(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				if (request.IsTransaction)
				{
					DaoFactory.InstanceBiz.BeginTransaction();
					isTran = true;
				}

				try
				{
					//테이블
					if (list.Count > 0)
					{
						foreach (WasRequest req in list)
						{
							if (req.Data == null)
								throw new Exception("저장할 데이터가 존재하지 않습니다.");

							switch (req.ModelName)
							{
								case "BGCategory":
									req.SaveCategory();
									break;
								case "BGInfoNotice":
									var infoNotice = req.SaveData<BGInfoNotice>();
									if (infoNotice != null)
										req.SaveInfoNoticeItem(infoNotice);
									break;
								case "BGGoods":
									req.SaveGoods();
									break;
								case "BGGoodsImage":
									req.SaveGoodsImage();
									break;
							}
						}
					}

					if (isTran)
						DaoFactory.InstanceBiz.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceBiz.RollBackTransaction();

					throw new Exception(ex.Message);
				}

				if (isOneRequest)
				{
					request = list[0];
				}
				else
				{
					request.Data = list;
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest Delete(WasRequest request)
		{
			bool isTran = false;

			try
			{
				if (request == null || (request.Data == null && request.SqlId.IsNullOrEmpty()))
					throw new Exception("처리요청이 없습니다.");

				bool isOneRequest = true;
				List<WasRequest> list = new List<WasRequest>();
				if (request.Data != null && request.Data.GetType() == typeof(JArray))
				{
					list = request.Data.JsonToAnyType<List<WasRequest>>();
					isOneRequest = false;
				}
				else
				{
					list.Add(request);
				}

				if (request.IsTransaction)
				{
					DaoFactory.InstanceBiz.BeginTransaction();
					isTran = true;
				}

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.InstanceBiz.Delete(req.SqlId, map);
					}

					if (isTran)
						DaoFactory.InstanceBiz.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceBiz.RollBackTransaction();

					throw new Exception(ex.Message);
				}

				if (isOneRequest)
				{
					request = list[0];
				}
				else
				{
					request.Data = list;
				}

				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		private static void SaveCategory(this WasRequest req)
		{
			BGCategory model = req.SaveData<BGCategory>();
			int? parentID = null;
			List<int?> catlist = new List<int?>();

			catlist.Add(model.ID);
			parentID = model.ParentID;
			while (parentID != null)
			{
				catlist.Add(parentID);
				var model2 = DaoFactory.InstanceBiz.QueryForObject<BGCategory>("SelectBGCategory", new DataMap() { { "ID", parentID } });
				if (model2 != null && model2.ParentID != null)
					parentID = model2.ParentID;
				else
					parentID = null;
			}

			DataMap map = new DataMap();
			map.SetValue("ID", model.ID);
			for (int i = 0; i < catlist.Count; i++)
			{
				map.SetValue("Category" + (i + 1).ToString(), catlist[i]);
			}
			DaoFactory.InstanceBiz.Update("UpdateBGCategoryLevel", map);
		}

		private static void SaveInfoNoticeItem(this WasRequest req, BGInfoNotice model)
		{
			try
			{
				foreach (var data in model.Items)
				{
					if (data.InfoNoticeID == null)
					{
						data.InfoNoticeID = model.ID;
					}
					req.SaveSubData<BGInfoNoticeItem>(data, false);
				}
			}
			catch
			{
				throw;
			}
		}
		
		private static BGGoods GetGoodsData(this WasRequest req)
		{
			try
			{
				DataMap parameter = req.Parameter.JsonToAnyType<DataMap>();
				BGGoods goods = DaoFactory.InstanceBiz.QueryForObject<BGGoods>("SelectBGGoods", parameter);
				if (goods != null)
				{
					parameter = new DataMap()
					{
						{ "GoodsID", goods.ID },
						{ "CategoryID", goods.CategoryID }
					};

					//상품상세
					goods.Detail = DaoFactory.InstanceBiz.QueryForObject<BGGoodsDetail>("SelectBGGoodsDetail", parameter);
					if (goods.Detail == null)
						goods.Detail = new BGGoodsDetail();

					//상품 이미지
					goods.Image = DaoFactory.InstanceBiz.QueryForList<BGGoodsImage>("SelectBGGoodsImageList", parameter);
					if (goods.Image == null)
						goods.Image = new List<BGGoodsImage>();

					//상품 옵션
					goods.Item = DaoFactory.InstanceBiz.QueryForList<BGGoodsItem>("SelectBGGoodsItemList", parameter);
					if (goods.Item == null)
						goods.Item = new List<BGGoodsItem>();

					//정보고시
					goods.InfoNotice = DaoFactory.InstanceBiz.QueryForList<BGGoodsInfoNotice>("SelectBGGoodsInfoNoticeByCategory", parameter);
					if (goods.InfoNotice == null)
						goods.InfoNotice = new List<BGGoodsInfoNotice>();

					//상품속성
					goods.Attribute = DaoFactory.InstanceBiz.QueryForList<BGGoodsAttribute>("SelectBGGoodsAttributeList", parameter);
					if (goods.Attribute == null)
						goods.Attribute = new List<BGGoodsAttribute>();
				}
				req.Data = goods;
				req.Result.Count = 1;
				return goods;
			}
			catch
			{
				throw;
			}
		}

		private static void SaveGoods(this WasRequest req)
		{
			try
			{
				BGGoods model = req.Data.JsonToAnyType<BGGoods>();

				if (model != null)
				{
					#region 상품 기본정보 저장
					if (model.ID.IsNullOrEmpty())
					{
						model.CreateBy = req.User.UserId;
						model.CreateByName = req.User.UserName;

						object id = DaoFactory.InstanceBiz.Insert("InsertBGGoods", model);
						model.ID = id.ToIntegerNullToNull();
					}
					else
					{
						model.UpdateBy = req.User.UserId;
						model.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBGGoods", model);
					}
					#endregion

					#region 상품상세정보
					BGGoodsDetail detail = DaoFactory.InstanceBiz.QueryForObject<BGGoodsDetail>("SelectBGGoodsDetailList", new DataMap() { { "GoodsID", model.ID } });
					if (detail == null)
					{
						model.Detail.GoodsID = model.ID;
						model.Detail.CreateBy = req.User.UserId;
						model.Detail.CreateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Insert("InsertBGGoodsDetail", model.Detail);
					}
					else
					{
						model.Detail.UpdateBy = req.User.UserId;
						model.Detail.UpdateByName = req.User.UserName;

						DaoFactory.InstanceBiz.Update("UpdateBGGoodsDetail", model.Detail);
					}
					#endregion

					#region 품목정보
					if (model.Item != null && model.Item.Count > 0)
					{
						foreach (BGGoodsItem item in model.Item)
						{
							if (item.ID.IsNullOrEmpty())
							{
								item.GoodsID = model.ID;
								item.CreateBy = req.User.UserId;
								item.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertBGGoodsItem", item);
							}
							else
							{
								BGGoodsItem old = DaoFactory.InstanceBiz.QueryForObject<BGGoodsItem>("SelectBGGoodsItem", new DataMap() { { "ID", item.ID } });
								if (old != null)
								{
									if (old.Option1Type != item.Option1Type ||
										old.Option1Name != item.Option1Name ||
										old.Option2Type != item.Option2Type ||
										old.Option2Name != item.Option2Name)
									{
										item.UpdateBy = req.User.UserId;
										item.UpdateByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateBGGoodsItem", item);
									}
								}
							}
						}
					}
					#endregion

					#region 속성저장
					if (model.Attribute != null && model.Attribute.Count > 0)
					{
						foreach (BGGoodsAttribute attr in model.Attribute)
						{
							if (attr.ID.IsNullOrEmpty())
							{
								attr.GoodsID = model.ID;
								attr.CreateBy = req.User.UserId;
								attr.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertBGGoodsAttribute", attr);
							}
							else
							{
								BGGoodsAttribute old = DaoFactory.InstanceBiz.QueryForObject<BGGoodsAttribute>("SelectBGGoodsAttribute", new DataMap() { { "ID", attr.ID } });
								if (old != null)
								{
									if (attr.AttrName.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteBGGoodsAttribute", new DataMap() { { "ID", attr.ID } });
									}
									else
									{
										if (old.AttrType != attr.AttrType ||
											old.AttrCode != attr.AttrCode ||
											old.AttrName != attr.AttrName)
										{
											attr.UpdateBy = req.User.UserId;
											attr.UpdateByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateBGGoodsAttribute", attr);
										}
									}
								}
							}
						}
					}
					#endregion

					#region 정보고시저장
					if (model.InfoNotice != null && model.InfoNotice.Count > 0)
					{
						foreach (BGGoodsInfoNotice info in model.InfoNotice)
						{
							if (info.ID.IsNullOrEmpty())
							{
								if (info.InfoNoticeValue.IsNullOrEmpty() == false)
								{
									info.GoodsID = model.ID;
									info.CreateBy = req.User.UserId;
									info.CreateByName = req.User.UserName;

									DaoFactory.InstanceBiz.Insert("InsertBGGoodsInfoNotice", info);
								}
							}
							else
							{
								BGGoodsInfoNotice old = DaoFactory.InstanceBiz.QueryForObject<BGGoodsInfoNotice>("SelectBGGoodsInfoNotice", new DataMap() { { "ID", info.ID } });

								if (old != null)
								{
									//정보고시값이 없으면 삭제한다.
									if (info.InfoNoticeValue.IsNullOrEmpty())
									{
										DaoFactory.InstanceBiz.Delete("DeleteBGGoodsInfoNotice", new DataMap() { { "ID", info.ID } });
									}
									else
									{
										if (old.InfoNoticeItemID != info.InfoNoticeItemID ||
											old.InfoNoticeValue != info.InfoNoticeValue)
										{
											info.UpdateBy = req.User.UserId;
											info.UpdateByName = req.User.UserName;

											DaoFactory.InstanceBiz.Update("UpdateBGGoodsInfoNotice", info);
										}
									}
								}
							}
						}
					}
					#endregion
				}

				req.Result.ReturnValue = model.ID;
				req.Result.Count = 1;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}

		private static void SaveGoodsImage(this WasRequest req)
		{
			try
			{
				BGGoods model = req.Data.JsonToAnyType<BGGoods>();

				if (model != null)
				{
					#region 이미지
					if (model.Image != null && model.Image.Count > 0)
					{
						foreach (BGGoodsImage image in model.Image)
						{
							if (image.ID.IsNullOrEmpty())
							{
								image.GoodsID = model.ID;
								image.CreateBy = req.User.UserId;
								image.CreateByName = req.User.UserName;

								DaoFactory.InstanceBiz.Insert("InsertBGGoodsImage", image);
							}
							else
							{
								BGGoodsImage old = DaoFactory.InstanceBiz.QueryForObject<BGGoodsImage>("SelectBGGoodsImage", new DataMap() { { "ID", image.ID } });
								if (old != null)
								{
									if (old.ImageType != image.ImageType ||
										old.ImageGroup != image.ImageGroup ||
										old.ImageUrl != image.ImageUrl)
									{
										image.UpdateBy = req.User.UserId;
										image.UpdateByName = req.User.UserName;

										DaoFactory.InstanceBiz.Update("UpdateBGGoodsImage", image);
									}
								}
							}
						}
					}
					#endregion
				}

				req.Result.ReturnValue = model.ID;
				req.Result.Count = 1;
				req.Error.Number = 0;
			}
			catch
			{
				throw;
			}
		}
	}
}