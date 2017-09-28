using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Search;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Services
{
	public static class BizServiceSearching
	{		
		public static SearchBrandModel GetSearchBrand(this WasRequest req)
		{
			try
			{
				var parameter = req.Parameter.JsonToAnyType<DataMap>();
				var brand = DaoFactory.InstanceBiz.QueryForObject<SearchBrandModel>("SelectSearchBrand", parameter);
				if (brand != null)
				{
					parameter = new DataMap() { { "SearchBrandID", brand.ID } };

					//주소
					brand.Activities = DaoFactory.InstanceBiz.QueryForList<SearchBrandActivityModel>("SelectSearchBrandActivityList", parameter);
					if (brand.Activities == null)
						brand.Activities = new List<SearchBrandActivityModel>();
				}
				req.Data = brand;
				req.Result.Count = 1;
				return brand;
			}
			catch
			{
				throw;
			}
		}
	}
}
