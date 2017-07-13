using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.UserModels;
using IKaan.Model.Was;
using IKaan.Was.Core.Mappers;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Base
{
	public static class CodeHelpService
	{
		public static WasRequest GetList(WasRequest request)
		{
			try
			{
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
					var parameter = req.Parameter.JsonToAnyType<DataMap>();
					IList<UMCodeHelp> result = new List<UMCodeHelp>();
					switch(parameter.GetValue("SystemType").ToStringNullToEmpty())
					{
						case "BIZ":
							result = DaoFactory.InstanceBiz.QueryForList<UMCodeHelp>(string.Concat("SelectCodeHelp", req.SqlId), parameter);
							break;
						case "ECM":
							result = DaoFactory.InstanceEcm.QueryForList<UMCodeHelp>(string.Concat("SelectCodeHelp", req.SqlId), parameter);
							break;
						default:
							result = DaoFactory.Instance.QueryForList<UMCodeHelp>(string.Concat("SelectCodeHelp", req.SqlId), parameter);
							break;
					}
					req.Data = result;
					req.Result.Count = (result == null) ? 0 : result.Count;
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
