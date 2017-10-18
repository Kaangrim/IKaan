using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Smaps;
using Newtonsoft.Json;

namespace IKaan.Win.Core.Was.Handler
{
	public static class ApiHandler
	{
		private const string key = @"4c55-e3ad-7286-cfe2-68cb-116b-fbb7-6bbf";
		private const string apiSiteTest = @"http://dev.brand.smaps.co.kr";
		private const string apiSiteReal = @"http://brand.smaps.co.kr";

		#region Post & Get

		public static string PostJson<T>(T data, bool isTest = false)
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

		public static string PostForm<T>(T data, bool isTest = false)
		{
			try
			{
				var requestType = typeof(T).Name.Replace("Model", "");
				var values = new NameValueCollection();
				var api = string.Empty;
				switch (requestType)
				{
					case "SmapsAgency":
						api = @"wapi/add_agency";
						values = GetFormDataSmapsAgency(data);
						break;
					case "SmapsBrand":
						api = @"wapi/add_brand";
						values = GetFormDataSmapsBrand(data);
						break;
					case "SmapsLookbook":
						api = @"wapi/add_lookbook";
						values = GetFormDataSmapsLookbook(data);
						break;
					case "SmapsProductSend":
						api = @"wapi/add_product";
						values = GetFormDataSmapsProductSend(data);
						break;
					case "SmapsUser":
						api = @"wapi/add_user";
						values = GetFormDataSmapsUser(data);
						break;
				}
				string url = (isTest) ? apiSiteTest : apiSiteReal + "/" + api + "?k=" + key;
				using (var client = new WebClient())
				{
					var response = client.UploadValues(url, "POST", values);
					return Encoding.UTF8.GetString(response);
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
			catch (WebException ex)
			{
				throw new Exception(ex.Message);
			}
			catch (Exception ex)
			{
				throw new Exception(ex.Message);
			}
		}

		public static string PostStream<T>(T data, bool isTest = false)
		{
			try
			{
				var requestType = typeof(T).Name.Replace("Model", "");
				var api = string.Empty;
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
				string url = (isTest) ? apiSiteTest : apiSiteReal + "/" + api + "?k=" + key;

				var json = JsonConvert.SerializeObject(data);
				var content = new StringContent(json, Encoding.UTF8, "application/json");
				var byteArray = Encoding.UTF8.GetBytes(json);
				var request = (HttpWebRequest)WebRequest.Create(url);
				request.ContentLength = byteArray.Length;
				request.ContentType = @"application/json";
				request.Method = "POST";

				using (var requestStream = request.GetRequestStream())
				{
					requestStream.Write(byteArray, 0, byteArray.Length);
				}

				using (var responseStream = new StreamReader(((HttpWebResponse)request.GetResponse()).GetResponseStream()))
				{
					return responseStream.ReadToEnd();
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
			catch (WebException ex)
			{
				throw new Exception(ex.Message);
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

		#endregion

		#region Create NameValueCollection

		private static NameValueCollection GetFormDataSmapsAgency(object data)
		{
			var values = new NameValueCollection();
			var model = data as SmapsAgencyModel;

			values.Add("type", model.type.ToStringNullToEmpty());
			values.Add("grade", model.grade.ToStringNullToEmpty());
			values.Add("name", model.name.ToStringNullToEmpty());
			values.Add("recommend", model.recommend.ToStringNullToEmpty());
			values.Add("sv_start_date", model.sv_start_date.ToDateTimeString());
			values.Add("sv_end_date", model.sv_end_date.ToDateTimeString());
			values.Add("cp_address", model.cp_address.ToStringNullToEmpty());
			values.Add("president_name", model.president_name.ToStringNullToEmpty());
			values.Add("cp_crn", model.cp_crn.ToStringNullToEmpty());
			values.Add("cp_email", model.cp_email.ToStringNullToEmpty());
			values.Add("cp_homepage", model.cp_homepage.ToStringNullToEmpty());
			values.Add("cp_intro", model.cp_intro.ToStringNullToEmpty());
			values.Add("cp_tel", model.cp_tel.ToStringNullToEmpty());
			values.Add("ct_department", model.ct_department.ToStringNullToEmpty());
			values.Add("ct_email", model.ct_email.ToStringNullToEmpty());
			values.Add("ct_fax", model.ct_fax.ToStringNullToEmpty());
			values.Add("ct_hphone", model.ct_hphone.ToStringNullToEmpty());
			values.Add("ct_name", model.ct_name.ToStringNullToEmpty());
			values.Add("ct_position", model.ct_position.ToStringNullToEmpty());
			values.Add("ct_tel", model.ct_tel.ToStringNullToEmpty());
			values.Add("consultation", model.consultation.ToStringNullToEmpty());
			values.Add("using_price", model.using_price.ToStringNullToEmpty());
			values.Add("image", model.image.ToStringNullToEmpty());
			values.Add("image_width", model.image_width.ToStringNullToEmpty());
			values.Add("image_height", model.image_height.ToStringNullToEmpty());
			return values;
		}

		private static NameValueCollection GetFormDataSmapsUser(object data)
		{
			var values = new NameValueCollection();
			var model = data as SmapsUserModel;

			values.Add("email", model.email.ToStringNullToEmpty());
			values.Add("name", model.name.ToStringNullToEmpty());
			values.Add("agency_uid", model.agency_uid.ToStringNullToEmpty());
			values.Add("passwd", model.passwd.ToStringNullToEmpty());
			values.Add("phone1", model.phone1.ToStringNullToEmpty());
			values.Add("phone2", model.phone2.ToStringNullToEmpty());
			values.Add("phone3", model.phone3.ToStringNullToEmpty());
			values.Add("introduce", model.introduce.ToStringNullToEmpty());
			values.Add("rank", model.rank.ToStringNullToEmpty());
			values.Add("image", model.image.ToStringNullToEmpty());
			values.Add("image_width", model.image_width.ToStringNullToEmpty());
			values.Add("image_height", model.image_height.ToStringNullToEmpty());
			return values;
		}

		private static NameValueCollection GetFormDataSmapsBrand(object data)
		{
			var values = new NameValueCollection();
			var model = data as SmapsBrandModel;

			values.Add("name", model.name.ToStringNullToEmpty());
			values.Add("manager", model.manager.ToStringNullToEmpty());
			values.Add("showroom", model.showroom.ToStringNullToEmpty());
			values.Add("agency_uid", model.agency_uid.ToStringNullToEmpty());
			values.Add("caption", model.caption.ToStringNullToEmpty());
			values.Add("image", model.image.ToStringNullToEmpty());
			values.Add("image_width", model.image_width.ToStringNullToEmpty());
			values.Add("image_height", model.image_height.ToStringNullToEmpty());
			return values;
		}

		private static NameValueCollection GetFormDataSmapsLookbook(object data)
		{
			var values = new NameValueCollection();
			var model = data as SmapsLookbookModel;

			values.Add("agency_uid", model.agency_uid.ToStringNullToEmpty());
			values.Add("brand_uid", model.brand_uid.ToStringNullToEmpty());
			values.Add("title", model.title.ToStringNullToEmpty());
			values.Add("marketing", model.marketing.ToStringNullToEmpty());
			values.Add("active_date_start", model.active_date_start.ToDateTimeString());
			values.Add("active_date_end", model.active_date_end.ToDateTimeString());
			values.Add("notice", model.notice.ToStringNullToEmpty());
			return values;
		}

		private static NameValueCollection GetFormDataSmapsProductSend(object data)
		{
			var values = new NameValueCollection();
			var model = data as SmapsProductSendModel;

			values.Add("agency_uid", model.agency_uid.ToStringNullToEmpty());
			values.Add("brand_uid", model.brand_uid.ToStringNullToEmpty());
			values.Add("lookbook_uid", model.lookbook_uid.ToStringNullToEmpty());
			values.Add("product_name", model.product_name.ToStringNullToEmpty());
			values.Add("product_number", model.product_number.ToStringNullToEmpty());
			values.Add("product_price", model.product_price.ToStringNullToEmpty());
			values.Add("product_unset_price", model.product_unset_price.ToStringNullToEmpty());
			values.Add("category_uid", model.category_uid.ToStringNullToEmpty());
			values.Add("sex", model.sex.ToStringNullToEmpty());
			values.Add("memo", model.memo.ToStringNullToEmpty());
			values.Add("caution", model.caution.ToStringNullToEmpty());
			values.Add("tag", model.tag.ToStringNullToEmpty());
			values.Add("option", model.option.ToStringNullToEmpty());

			if (model.option > 0)
			{
				if (model.option_size_uid != null && model.option_size_uid.Count > 0)
				{
					for (int i = 0; i < model.option_size_uid.Count; i++)
						values.Add("option_size_uid[]", model.option_size_uid[i].ToStringNullToEmpty());
				}

				if (model.option_size_view != null && model.option_size_view.Count > 0)
				{
					for (int i = 0; i < model.option_size_view.Count; i++)
						values.Add("option_size_view[]", model.option_size_view[i]);
				}

				if (model.option_color != null && model.option_color.Count > 0)
				{
					for (int i = 0; i < model.option_color.Count; i++)
						values.Add("option_color[]", model.option_color[i]);
				}

				if (model.option_color_view != null && model.option_color_view.Count > 0)
				{
					for (int i = 0; i < model.option_color_view.Count; i++)
						values.Add("option_color_view[]", model.option_color_view[i]);
				}

				if (model.option_add_date != null && model.option_add_date.Count > 0)
				{
					for (int i = 0; i < model.option_add_date.Count; i++)
						values.Add("option_add_date[]", DateTime.Now.ToString("yyyyMMdd"));
				}
			}
			if (model.image != null && model.image.Count > 0)
			{
				for (int i = 0; i < model.image.Count; i++)
					values.Add("image[]", model.image[i]);
			}

			if (model.image_width != null && model.image_width.Count > 0)
			{
				for (int i = 0; i < model.image_width.Count; i++)
					values.Add("image_width[]", model.image_width[i].ToString());
			}
			if (model.image_height != null && model.image_height.Count > 0)
			{
				for (int i = 0; i < model.image_height.Count; i++)
					values.Add("image_height[]", model.image_height[i].ToString());
			}
			if (model.is_thumbnail != null && model.is_thumbnail.Count > 0)
			{
				for (int i = 0; i < model.is_thumbnail.Count; i++)
					values.Add("is_thumbnail[]", model.is_thumbnail[i]);
			}
			if (model.is_main != null && model.is_main.Count > 0)
			{
				for (int i = 0; i < model.is_main.Count; i++)
					values.Add("is_main[]", model.is_main[i]);
			}

			return values;
		}

		private static string GetFormStringSmapsProductSend(object data)
		{
			var postData = string.Empty;
			var model = data as SmapsProductSendModel;

			postData = postData + "agency_uid=" + model.agency_uid.ToStringNullToEmpty() + "&";
			postData = postData + "brand_uid=" + model.brand_uid.ToStringNullToEmpty() + "&";
			postData = postData + "lookbook_uid=" + model.lookbook_uid.ToStringNullToEmpty() + "&";
			postData = postData + "product_name=" + model.product_name.ToStringNullToEmpty() + "&";
			postData = postData + "product_number=" + model.product_number.ToStringNullToEmpty() + "&";
			postData = postData + "product_price=" + model.product_price.ToStringNullToEmpty() + "&";
			postData = postData + "product_unset_price=" + model.product_unset_price.ToStringNullToEmpty() + "&";
			postData = postData + "category_uid=" + model.category_uid.ToStringNullToEmpty() + "&";
			postData = postData + "sex=" + model.sex.ToStringNullToEmpty() + "&";
			postData = postData + "memo=" + model.memo.ToStringNullToEmpty() + "&";
			postData = postData + "caution=" + model.caution.ToStringNullToEmpty() + "&";
			postData = postData + "tag=" + model.tag.ToStringNullToEmpty() + "&";
			postData = postData + "option=" + model.option.ToStringNullToEmpty() + "&";

			if (model.option > 0)
			{
				if (model.option_size_uid != null && model.option_size_uid.Count > 0)
				{
					for (int i = 0; i < model.option_size_uid.Count; i++)
						postData = postData + "option_size_uid[]=" + model.option_size_uid[i].ToStringNullToEmpty() + "&";
				}

				if (model.option_size_view != null && model.option_size_view.Count > 0)
				{
					for (int i = 0; i < model.option_size_view.Count; i++)
						postData = postData + "option_size_view[]=" + model.option_size_view[i] + "&";
				}

				if (model.option_color != null && model.option_color.Count > 0)
				{
					for (int i = 0; i < model.option_color.Count; i++)
						postData = postData + "option_color[]=" + model.option_color[i] + "&";
				}

				if (model.option_color_view != null && model.option_color_view.Count > 0)
				{
					for (int i = 0; i < model.option_color_view.Count; i++)
						postData = postData + "option_color_view[]=" + model.option_color_view[i] + "&";
				}

				if (model.option_add_date != null && model.option_add_date.Count > 0)
				{
					for (int i = 0; i < model.option_add_date.Count; i++)
						postData = postData + "option_add_date[]=" + model.option_add_date[i].ToDateTimeString() + "&";
				}
			}
			if (model.image != null && model.image.Count > 0)
			{
				for (int i = 0; i < model.image.Count; i++)
					postData = postData + "image[]=" + model.image[i] + "&";
			}

			if (model.image_width != null && model.image_width.Count > 0)
			{
				for (int i = 0; i < model.image_width.Count; i++)
					postData = postData + "image_width[]=" + model.image_width[i].ToString() + "&";
			}
			if (model.image_height != null && model.image_height.Count > 0)
			{
				for (int i = 0; i < model.image_height.Count; i++)
					postData = postData + "image_height[]=" + model.image_height[i].ToString() + "&";
			}
			if (model.is_thumbnail != null && model.is_thumbnail.Count > 0)
			{
				for (int i = 0; i < model.is_thumbnail.Count; i++)
					postData = postData + "is_thumbnail[]=" + model.is_thumbnail[i] + "&";
			}
			if (model.is_main != null && model.is_main.Count > 0)
			{
				for (int i = 0; i < model.is_main.Count; i++)
					postData = postData + "is_main[]=" + model.is_main[i] + "&";
			}

			return postData;
		}

		#endregion
	}
}
