﻿using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Common.UserModels;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;
using Newtonsoft.Json.Linq;

namespace IKaan.Was.Service.Common
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
					var sqlId = string.Concat("SelectCodeHelp", req.SqlId);
					IList<UCodeHelp> result = DaoFactory.Instance.QueryForList<UCodeHelp>(sqlId, parameter);
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
