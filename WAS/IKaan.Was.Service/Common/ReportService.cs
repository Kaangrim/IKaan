using System;
using System.Collections.Generic;
using IKaan.Base.Map;
using IKaan.Model.Report;
using IKaan.Model.Common.Was;
using IKaan.Was.Core.Mappers;

namespace IKaan.Was.Service.Base
{
	public static class ReportService
	{
		public static WasRequest GetSaleInvoiceList(WasRequest request)
		{
			try
			{
				//request.Data = DaoFactory.Instance.QueryForList<SaleInvoiceList>("GetSaleInvoiceList", (request.Parameter as DataMap));
				return request;
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return request;
			}
		}

		public static WasRequest GetSaleInvoiceData(WasRequest request)
		{
			try
			{
				var saletran = DaoFactory.Instance.QueryForList<SaleInvoiceTran>("GetSaleInvoiceTran", (request.Parameter as DataMap));
				var saleitem = DaoFactory.Instance.QueryForList<SaleInvoiceTranItem>("GetSaleInvoiceTranItem", (request.Parameter as DataMap));

				request.Data = new List<WasRequest>
				{
					new WasRequest() { Data = saletran },
					new WasRequest() { Data = saleitem }
				};
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
