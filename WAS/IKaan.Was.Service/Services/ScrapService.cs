using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;
using IKaan.Model.Scrap.Common;
using IKaan.Model.Scrap.Mapping;
using IKaan.Model.Scrap.Smaps;
using IKaan.Was.Core.Mappers;
using IKaan.Was.Service.Utils;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Services
{
	public static class ScrapService
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
					switch (req.ModelName.Replace("Model", ""))
					{
						case "ScrapBrand":
							req.SetList<ScrapBrandModel>();
							break;
						case "ScrapProduct":
							req.SetList<ScrapProductModel>();
							break;
						case "ScrapSite":
							req.SetList<ScrapSiteModel>();
							break;
						case "ScrapColor":
							req.SetList<ScrapColorModel>();
							break;
						case "ScrapSize":
							req.SetList<ScrapSizeModel>();
							break;
						case "ScrapCategory":
							req.SetList<ScrapCategoryModel>();
							break;
						case "SmapsAgency":
							req.SetList<SmapsAgencyModel>();
							break;
						case "SmapsBrand":
							req.SetList<SmapsBrandModel>();
							break;
						case "SmapsCategory":
							req.SetList<SmapsCategoryModel>();
							break;
						case "SmapsColor":
							req.SetList<SmapsColorModel>();
							break;
						case "SmapsLookbook":
							req.SetList<SmapsLookbookModel>();
							break;
						case "SmapsProduct":
							req.SetList<SmapsProductModel>();
							break;
						case "SmapsSize":
							req.SetList<SmapsSizeModel>();
							break;
						case "SmapsUser":
							req.SetList<SmapsUserModel>();
							break;
						case "SmapsRequest":
							req.SetList<SmapsRequestModel>();
							break;
						case "ScrapBrandToSmaps":
							req.SetList<ScrapBrandToSmapsModel>();
							break;
						case "ScrapCategoryToSmaps":
							req.SetList<ScrapCategoryToSmapsModel>();
							break;
						case "ScrapProductToSmaps":
							req.SetList<ScrapProductToSmapsModel>();
							break;
						case "ScrapColorToSmaps":
							req.SetList<ScrapColorToSmapsModel>();
							break;
						case "ScrapSizeToSmaps":
							req.SetList<ScrapSizeToSmapsModel>();
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
					switch (req.ModelName.Replace("Model", ""))
					{
						case "ScrapBrand":
							req.SetData<ScrapBrandModel>();
							break;
						case "ScrapProduct":
							req.GetScrapProduct();
							break;
						case "ScrapSite":
							req.SetData<ScrapSiteModel>();
							break;
						case "ScrapColor":
							req.SetData<ScrapColorModel>();
							break;
						case "ScrapSize":
							req.SetData<ScrapSizeModel>();
							break;
						case "ScrapCategory":
							req.SetData<ScrapCategoryModel>();
							break;
						case "SmapsAgency":
							req.SetData<SmapsAgencyModel>();
							break;
						case "SmapsBrand":
							req.SetData<SmapsBrandModel>();
							break;
						case "SmapsCategory":
							req.SetData<SmapsCategoryModel>();
							break;
						case "SmapsColor":
							req.SetData<SmapsColorModel>();
							break;
						case "SmapsLookbook":
							req.SetData<SmapsLookbookModel>();
							break;
						case "SmapsProduct":
							req.SetData<SmapsProductModel>();
							break;
						case "SmapsSize":
							req.SetData<SmapsSizeModel>();
							break;
						case "SmapsUser":
							req.SetData<SmapsUserModel>();
							break;
						case "SmapsRequest":
							req.SetData<SmapsRequestModel>();
							break;
						case "ScrapBrandToSmaps":
							req.SetData<ScrapBrandToSmapsModel>();
							break;
						case "ScrapCategoryToSmaps":
							req.SetData<ScrapCategoryToSmapsModel>();
							break;
						case "ScrapProductToSmaps":
							req.SetData<ScrapProductToSmapsModel>();
							break;
						case "ScrapColorToSmaps":
							req.SetData<ScrapColorToSmapsModel>();
							break;
						case "ScrapSizeToSmaps":
							req.SetData<ScrapSizeToSmapsModel>();
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
					DaoFactory.InstanceScrap.BeginTransaction();
					isTran = true;
				}

				try
				{
					//테이블
					if (list.Count > 0)
					{
						foreach (WasRequest req in list)
						{
							if (req.ModelName.IsNullOrEmpty() == false && req.Data == null)
								throw new Exception("저장할 데이터가 존재하지 않습니다.");
							
							if (req.ModelName.IsNullOrEmpty() && req.Parameter == null)
								throw new Exception("처리할 조건이 존재하지 않습니다.");

							string reqId = req.ModelName;
							if (reqId.IsNullOrEmpty())
								reqId = req.SqlId;

							if (reqId.IsNullOrEmpty() == false)
								reqId = reqId.Replace("Model", "");

							switch (reqId)
							{
								case "ScrapBrand":
									req.SaveScrapBrand();
									break;
								case "ScrapProduct":
									req.SaveScrapProduct();
									break;
								case "ScrapSite":
									req.SaveScrapSite();
									break;
								case "ScrapColor":
									req.SaveScrapColor();
									break;
								case "ScrapSize":
									req.SaveScrapSize();
									break;
								case "SmapsAgency":
									req.SaveSmapsAgency();
									break;
								case "SmapsBrand":
									req.SaveSmapsBrand();
									break;
								case "SmapsCategory":
									req.SaveSmapsCategory();
									break;
								case "SmapsColor":
									req.SaveSmapsColor();
									break;
								case "SmapsLookbook":
									req.SaveSmapsLookbook();
									break;
								case "SmapsProduct":
									req.SaveSmapsProduct();
									break;
								case "SmapsSize":
									req.SaveSmapsSize();
									break;
								case "SmapsUser":
									req.SaveSmapsUser();
									break;
								case "SmapsRequest":
									req.SaveSmapsRequest();
									break;
								case "ScrapBrandToSmaps":
									req.SaveScrapBrandToSmaps();
									break;
								case "ScrapCategoryToSmaps":
									req.SaveScrapCategoryToSmaps();
									break;
								case "ScrapProductToSmaps":
									req.SaveScrapProductToSmaps();
									break;
								//case "ScrapColorToSmaps":
								//	req.SaveScrapColorToSmaps();
								//	break;
								//case "ScrapSizeToSmaps":
								//	req.SaveScrapSizeToSmaps();
								//	break;
								case "BatchScrapOption":
									req.BatchScrapOption();
									break;
							}
						}
					}

					if (isTran)
						DaoFactory.InstanceScrap.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceScrap.RollBackTransaction();

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
					DaoFactory.InstanceScrap.BeginTransaction();
					isTran = true;
				}

				try
				{
					foreach (WasRequest req in list)
					{
						DataMap map = req.Data.JsonToAnyType<DataMap>();
						DaoFactory.InstanceScrap.Delete(req.SqlId, map);
					}

					if (isTran)
						DaoFactory.InstanceScrap.CommitTransaction();
				}
				catch (Exception ex)
				{
					if (isTran)
						DaoFactory.InstanceScrap.RollBackTransaction();

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
	}
}
