using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows.Forms;

namespace IKaan.Base.Utils
{
	public static class HtmlUtils
	{
		public static string GetCookieAll(string url)
		{
			var cookies = new CookieContainer();
			var handler = new HttpClientHandler() { CookieContainer = cookies };

			var client = new HttpClient(handler);

			var sb = new StringBuilder();
			var uri = new Uri(url);
			var responseCookies = cookies.GetCookies(uri).Cast<Cookie>();
			foreach (Cookie cookie in responseCookies)
			{
				sb.AppendFormat("{0}: {1}", cookie.Name, cookie.Value);
			}
			return sb.ToString();
		}

		public static HtmlElement GetElement(this WebBrowser wb, string tagName, string name = "", string className = "", string innerText = "", int findIndex = 0)
		{
			int index = 0;
			try
			{
				foreach (HtmlElement link in wb.Document.GetElementsByTagName(tagName))
				{
					if ((innerText.IsNullOrEmpty() == true || link.InnerText.Equals(innerText)) &&
						(name.IsNullOrEmpty() || link.Name.Equals(name)) &&
						(className.IsNullOrEmpty() || link.GetAttribute("className") == className))
					{
						if (index == findIndex)
							return link;
						else
							index++;
					}
				}
				return null;
			}
			catch
			{
				throw;
			}
		}

		public static HtmlElement GetElement(this HtmlDocument doc, string tagName, string name = "", string className = "", string innerText = "", int findIndex = 0)
		{
			int index = 0;
			try
			{
				foreach (HtmlElement link in doc.GetElementsByTagName(tagName))
				{
					if ((innerText.IsNullOrEmpty() == true || link.InnerText.Equals(innerText)) &&
						(name.IsNullOrEmpty() || link.Name.Equals(name)) &&
						(className.IsNullOrEmpty() || link.GetAttribute("className") == className))
					{
						if (index == findIndex)
							return link;
						else
							index++;
					}
				}
				return null;
			}
			catch
			{
				throw;
			}
		}
	}
}
