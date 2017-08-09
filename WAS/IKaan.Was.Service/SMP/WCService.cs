using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.SMP.WC;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.SMP
{
	public static class WCService
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
						case "WCBrandInfo":
							req.SetList<WCBrandInfo>();
							break;
						case "WCGoodsInfo":
							req.SetList<WCGoodsInfo>();
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
						case "WCBrandInfo":
							req.SetData<WCBrandInfo>();
							break;
						case "WCGoodsInfo":
							req.SetData<WCGoodsInfo>();
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
					DaoFactory.InstanceSmp.BeginTransaction();
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
								case "WCBrandInfo":
									req.SaveBrandInfo();
									break;
								case "WCGoodsInfo":
									req.SaveGoodsInfo();
									break;
							}
						}
					}

					if (isTran)
						DaoFactory.InstanceSmp.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceSmp.RollBackTransaction();

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
					DaoFactory.InstanceSmp.BeginTransaction();
					isTran = true;
				}

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.InstanceSmp.Delete(req.SqlId, map);
					}

					if (isTran)
						DaoFactory.InstanceSmp.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceSmp.RollBackTransaction();

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
		
		private static void SaveBrandInfo(this WasRequest req)
		{
			try
			{
				WCBrandInfo brand = req.Data.JsonToAnyType<WCBrandInfo>();

				DataMap map = new DataMap()
				{
					{ "SiteCode", brand.SiteCode },
					{ "BrandCode", brand.BrandCode }
				};
				var exists = DaoFactory.InstanceSmp.QueryForObject<WCBrandInfo>("SelectWCBrandInfoExists", map);
				if (exists == null)
				{
					brand.CreateBy = req.User.UserId;
					brand.CreateByName = req.User.UserName;

					object id = DaoFactory.InstanceSmp.Insert("InsertWCBrandInfo", brand);
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

						DaoFactory.InstanceSmp.Update("UpdateWCBrandInfo", brand);
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

		private static void SaveGoodsInfo(this WasRequest req)
		{
			try
			{
				WCGoodsInfo goods = req.Data.JsonToAnyType<WCGoodsInfo>();

				DataMap map = new DataMap()
				{
					{ "SiteCode", goods.SiteCode },
					{ "BrandCode", goods.BrandCode },
					{ "GoodsCode", goods.GoodsCode },
					{ "GoodsName", goods.GoodsName }
				};
				var exists = DaoFactory.InstanceSmp.QueryForObject<WCGoodsInfo>("SelectWCGoodsInfoExists", map);
				if (exists == null)
				{
					goods.CreateBy = req.User.UserId;
					goods.CreateByName = req.User.UserName;

					object id = DaoFactory.InstanceSmp.Insert("InsertWCGoodsInfo", goods);
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

						DaoFactory.InstanceSmp.Update("UpdateWCGoodsInfo", goods);
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
