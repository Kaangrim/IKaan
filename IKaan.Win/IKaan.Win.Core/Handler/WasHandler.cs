using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Model.Was;

namespace IKaan.Win.Core.Was.Handler
{
	public static class WasHandler
	{
		private const string apiUrl = @"api/IKaan";

		public static WasRequest Execute(this WasRequest request)
		{
			try
			{
				HttpClient http = new HttpClient();
				http.DefaultRequestHeaders.Connection.Clear();
				http.DefaultRequestHeaders.ConnectionClose = false;
				http.DefaultRequestHeaders.Connection.Add("Keep-Alive");
				//client.DefaultRequestHeaders.Add("Connection", "keep-alive");
				//client.DefaultRequestHeaders.Add("Keep-Alive", "timeout=6000");
				http.DefaultRequestHeaders.Accept.Clear();
				http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
				http.DefaultRequestHeaders.ExpectContinue = false;
				http.Timeout = TimeSpan.FromMinutes(60);
				http.BaseAddress = new Uri(GlobalVar.ServerInfo.ServerUrl);

				request.User.UserId = GlobalVar.UserInfo.UserId;
				request.User.UserName = GlobalVar.UserInfo.UserName;
				request.User.LanguageCode = GlobalVar.UserInfo.LanguageCode;
				request.DatabaseId = GlobalVar.ServerInfo.DatabaseId;

				bool isTransaction = false;

				//멀티요청인 경우 해당 요청건에 사용자정보를 넣는다.
				if (request.Data != null && request.Data.GetType() == typeof(List<WasRequest>))
				{
					foreach (WasRequest req in (request.Data as List<WasRequest>))
					{
						if (req.ServiceId.IsNullOrEmpty())
							req.ServiceId = request.ServiceId;
						req.User.UserId = GlobalVar.UserInfo.UserId;
						req.User.UserName = GlobalVar.UserInfo.UserName;
						req.User.LanguageCode = GlobalVar.UserInfo.LanguageCode;
						if (req.SqlId.ToStringNullToEmpty().StartsWith("Insert") ||
							req.SqlId.ToStringNullToEmpty().StartsWith("Update") ||
							req.SqlId.ToStringNullToEmpty().StartsWith("Delete"))
							isTransaction = true;

						req.IsTransaction = isTransaction;
					}
				}
				else
				{
					if (request.SqlId.ToStringNullToEmpty().StartsWith("Insert") ||
						request.SqlId.ToStringNullToEmpty().StartsWith("Update") ||
						request.SqlId.ToStringNullToEmpty().StartsWith("Delete"))
						isTransaction = true;
				}
				request.IsTransaction = isTransaction;

				//서버에 처리요청을 보낸디ㅏ.
				var response = http.PostAsJsonAsync(apiUrl, request).Result;
				if (response.IsSuccessStatusCode)
				{
					return response.Content.ReadAsAsync<WasRequest>().Result;
				}
				else
				{
					throw new Exception(string.Format("{0}{1}{2}{3}{4}", 
						response.StatusCode,
						Environment.NewLine,
						response.RequestMessage,
						Environment.NewLine,
						response.ReasonPhrase));
				}
			}
			catch (AggregateException ex)
			{
				//하나 이상의 오류 발생한 경우
				string message = string.Empty;
				for (int i = 0; i < ex.InnerExceptions.Count; i++)
					message = string.Concat(message,
						ex.InnerExceptions[i].Message,
						Environment.NewLine,
						ex.InnerExceptions[i].StackTrace,
						Environment.NewLine);
				throw new Exception(message);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static WasRequest Execute(string serviceId, string processId, string sqlId, object parameter)
		{
			try
			{

				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				var res = (new WasRequest()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					SqlId = sqlId,
					Parameter = parameter
				}).Execute();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.Error.Number != 0)
					throw new Exception(res.Error.Message);

				return res;
			}
			catch
			{
				throw;
			}
		}

		public static WasRequest Execute<T>(string serviceId, string processId, string sqlId, object data, string keyField)
		{
			try
			{
				if (data == null)
					throw new Exception("처리할 데이터가 없습니다.");

				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				//모델 리스트로 전송한 경우 요청데이터를 여러 건 만든다.
				if (data.GetType() == typeof(List<T>))
				{
					IList<WasRequest> reqlist = new List<WasRequest>();
					foreach(var row in (data as List<T>))
					{
						reqlist.Add(new WasRequest()
						{
							ServiceId = serviceId,
							ProcessId = processId,
							SqlId = sqlId,
							Data = row,
							ModelName = typeof(T).Name,
							Master = new WasMaster()
							{
								IsMaster = true,
								KeyField = keyField
							}
						});

						if (reqlist.Count == 0)
							throw new Exception("처리할 건이 없습니다.");

						data = reqlist;
					}
				}

				using (var res = (new WasRequest()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					SqlId = sqlId,
					Data = data,
					ModelName = typeof(T).Name,
					Master = new WasMaster()
					{
						IsMaster = true,
						KeyField = keyField
					}
				}).Execute())
				{
					if (res == null)
						throw new Exception("요청결과가 없습니다.");

					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					return res;
				}
			}
			catch
			{
				throw;
			}
		}
		
		public static WasRequest GetData(string serviceId, string processId, string sqlId, DataMap parameter, string modelName)
		{
			try
			{
				if (string.IsNullOrEmpty(serviceId))
					serviceId = "Base";

				if (string.IsNullOrEmpty(processId))
					processId = "GetData";

				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("CreateBy") == false)
					parameter.SetValue("CreateBy", GlobalVar.UserInfo.UserId);
				if (parameter.ContainsKey("CreateByName") == false)
					parameter.SetValue("CreateByName", GlobalVar.UserInfo.UserName);

				var res = (new WasRequest()
				{
					ServiceId = serviceId,
					ProcessId = processId,
					SqlId = sqlId,
					Parameter = parameter,
					ModelName = modelName
				}).Execute();

				if (res == null)
					throw new Exception("요청결과가 없습니다.");

				if (res.Error.Number != 0)
					throw new Exception(res.Error.Message);

				if (res.Data == null)
					throw new Exception("요청결과의 데이터가 없습니다.");

				return res;
			}
			catch
			{
				throw;
			}
		}
		
		public static T GetData<T>(string serviceId, string processId, string sqlId, DataMap parameter)
		{
			try
			{
				if (processId.IsNullOrEmpty())
					processId = "GetData";

				using (var res = GetData(serviceId, processId, sqlId, parameter, typeof(T).ToGenericInnerType().Name))
				{
					if (res.Result.Count == 0)
						return default(T);
					else
						return ConvertUtils.JsonToAnyType<T>(res.Data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static IList<T> GetList<T>(string serviceId, string processId, string sqlId, DataMap parameter)
		{
			try
			{
				if (processId.IsNullOrEmpty())
					processId = "GetList";

				using (var res = GetData(serviceId, processId, sqlId, parameter, typeof(T).ToGenericInnerType().Name))
				{
					if (res.Result.Count == 0)
						return default(IList<T>);
					else
						return ConvertUtils.JsonToAnyType<IList<T>>(res.Data);
				}
			}
			catch
			{
				throw;
			}
		}

		public static WasRequest ProcedureCall<T>(string sqlId, DataMap parameter)
		{
			try
			{
				if (parameter == null)
					parameter = new DataMap();

				if (parameter.ContainsKey("CreateBy") == false)
					parameter.SetValue("CreateBy", GlobalVar.UserInfo.UserId);
				if (parameter.ContainsKey("CreateByName") == false)
					parameter.SetValue("CreateByName", GlobalVar.UserInfo.UserName);

				var res = (new WasRequest()
				{
					ServiceId = "Base",
					ProcessId = "ProcedureCall",
					SqlId = sqlId,
					IsTransaction = true,
					Parameter = parameter,
					ModelName = typeof(T).Name
				}).Execute();

				if (res == null)
					throw new Exception("처리결과를 수신하지 못했습니다.");

				if (res.Error.Number != 0)
					throw new Exception(res.Error.Message);

				return res;
			}
			catch
			{
				throw;
			}
		}
	}
}
