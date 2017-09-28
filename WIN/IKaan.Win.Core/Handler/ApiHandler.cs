using System;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace IKaan.Win.Core.Was.Handler
{
	public static class ApiHandler
	{
		private const string key = @"4c55-e3ad-7286-cfe2-68cb-116b-fbb7-6bbf";
		private const string apiSiteTest = @"http://dev.brand.smaps.co.kr";
		private const string apiSiteReal = @"http://brand.smaps.co.kr";

		public static string Post<T>(T data, bool isTest = false)
		{
			try
			{
				var requestType = typeof(T).Name.Replace("Model", "");

				using (var http = new HttpClient())
				{
					http.DefaultRequestHeaders.Connection.Clear();
					http.DefaultRequestHeaders.ConnectionClose = false;
					http.DefaultRequestHeaders.Connection.Add("Keep-Alive");
					http.DefaultRequestHeaders.Accept.Clear();
					http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
					http.DefaultRequestHeaders.ExpectContinue = false;
					http.Timeout = TimeSpan.FromMinutes(60);
					http.BaseAddress = new Uri((isTest) ? apiSiteTest : apiSiteReal);

					string api = string.Empty;
					switch (requestType)
					{
						case "SmapsAgency":
							api = @"wapi/add_agency";
							break;
						case "SmapsBrand":
							api = @"wapi/add_brand";
							break;
						case "SmapsLookbook":
							api = @"wapi/add_lookbook";
							break;
						case "SmapsProductSend":
							api = @"wapi/add_product";
							break;
						case "SmapsUser":
							api = @"wapi/add_user";
							break;
					}

					string url = api + "?k=" + key;

					//서버에 처리요청을 보낸다.
					string temp = JsonConvert.SerializeObject(data);
					var response = http.PostAsJsonAsync(url, data).Result;
					if (response.IsSuccessStatusCode)
					{
						return response.Content.ReadAsStringAsync().Result;
					}
					else
					{
						throw new Exception(string.Format("{0}{1}{2}{3}{4}",
							response.StatusCode, Environment.NewLine,
							response.RequestMessage, Environment.NewLine,
							response.ReasonPhrase));
					}
				}
			}
			catch (AggregateException ex)
			{
				//하나 이상의 오류 발생한 경우
				string message = string.Empty;
				for (int i = 0; i < ex.InnerExceptions.Count; i++)
					message = string.Concat(message,
						ex.InnerExceptions[i].Message, Environment.NewLine,
						ex.InnerExceptions[i].StackTrace, Environment.NewLine);
				throw new Exception(message);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static string Get<T>(bool isTest = false)
		{
			try
			{
				var requestType = typeof(T).Name.Replace("Model", "");

				using (var http = new HttpClient())
				{
					http.DefaultRequestHeaders.Connection.Clear();
					http.DefaultRequestHeaders.ConnectionClose = false;
					http.DefaultRequestHeaders.Connection.Add("Keep-Alive");
					http.DefaultRequestHeaders.Accept.Clear();
					http.DefaultRequestHeaders.Add("Accept", "application/json");
					http.DefaultRequestHeaders.ExpectContinue = false;
					http.Timeout = TimeSpan.FromMinutes(60);
					http.BaseAddress = new Uri((isTest) ? apiSiteTest : apiSiteReal);

					string api = string.Empty;
					switch (requestType)
					{
						case "SmapsAgencyReceive":
							api = @"wapi/list_agency";
							break;
						case "SmapsUserReceive":
							api = @"wapi/list_user";
							break;
						case "SmapsBrandReceive":
							api = @"wapi/list_brand";
							break;
						case "SmapsLookbookReceive":
							api = @"wapi/list_lookbook";
							break;
						case "SmapsCategory":
							api = @"wapi/list_category";
							break;
						case "SmapsSize":
							api = @"wapi/list_size";
							break;
						case "SmapsColor":
							api = @"wapi/list_color";
							break;
					}
					string url = api + "?k=" + key;

					//서버에 처리요청을 보낸다.
					var response = http.GetAsync(url).Result;
					if (response.IsSuccessStatusCode)
					{
						return response.Content.ReadAsStringAsync().Result;
					}
					else
					{
						throw new Exception(string.Format("{0}{1}{2}{3}{4}",
							response.StatusCode, Environment.NewLine,
							response.RequestMessage, Environment.NewLine,
							response.ReasonPhrase));
					}
				}
			}
			catch (AggregateException ex)
			{
				//하나 이상의 오류 발생한 경우
				string message = string.Empty;
				for (int i = 0; i < ex.InnerExceptions.Count; i++)
					message = string.Concat(message,
						ex.InnerExceptions[i].Message, Environment.NewLine,
						ex.InnerExceptions[i].StackTrace, Environment.NewLine);
				throw new Exception(message);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}
	}
}
