using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using IKaan.Base.Utils;
using IKaan.Model.Common.Was;

namespace IKaan.Was.Controllers
{
	public class IKaanController : ApiController
    {
		private const string assemblyName = @"IKaan.Was.Service";
		private string serviceType = "Services";

		public HttpResponseMessage Post(WasRequest request)
		{
			if (request.ServiceId.Equals("CodeHelp") || 
				request.ServiceId.Equals("Email") ||
				request.ServiceId.Equals("AUTH") ||
				request.ServiceId.Equals("Common") ||
				request.ServiceId.Equals("Report"))
			{
				serviceType = "Common";
			}

			string namespaceName = string.Format("{0}.{1}.{2}Service", assemblyName, serviceType, request.ServiceId);
			string methodName = request.ProcessId;

			try
			{
				WasRequest result = (WasRequest)TypeUtils.InvokeMethodByParam(assemblyName, namespaceName, methodName, request);
				return Request.CreateResponse(HttpStatusCode.Created, result);
			}
			catch (Exception ex)
			{
				request.Error.Number = ex.HResult;
				request.Error.Message = ex.Message;
				return Request.CreateResponse(HttpStatusCode.Created, request);
			}
		}
	}
}
