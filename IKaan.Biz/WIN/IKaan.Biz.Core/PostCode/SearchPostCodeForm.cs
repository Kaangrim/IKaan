using System;
using System.Security.Permissions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IKaan.Biz.Core.Helper;
using IKaan.Biz.Core.Model;
using Newtonsoft.Json.Linq;

namespace IKaan.Biz.Core.PostCode
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	[System.Runtime.InteropServices.ComVisibleAttribute(true)]
	public partial class SearchPostCodeForm : XtraForm
	{
		private bool bOpened = false;   //중복실행방지

		public SearchPostCodeForm()
		{
			InitializeComponent();

			wb.DocumentCompleted += delegate (object sender, WebBrowserDocumentCompletedEventArgs e)
			{
				while (wb.ReadyState != WebBrowserReadyState.Complete)
					Application.DoEvents();

				try
				{
					if (!bOpened)
					{
						wb.Document.InvokeScript("daumEmbedOpen", new object[] { });
						bOpened = true;
					}
				}
				catch (Exception ex)
				{
					MsgBox.Show(ex);
				}
			};
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);
			Init();
		}

		private void Init()
		{
			try
			{
				wb.ObjectForScripting = this;
				wb.AllowWebBrowserDrop = false;
				//wb.IsWebBrowserContextMenuEnabled = false;
				//wb.WebBrowserShortcutsEnabled = false;
				//string html = Properties.Resources.searchpostcode;
				//wb.DocumentText = html;
				//string curDir = Directory.GetCurrentDirectory();
				//wb.Url = new Uri(string.Format("file:///{0}/PostCode/searchpostcode.html", curDir));
				//wb.Navigate(new Uri(@"http://do.dwcts.co.kr/Html/searchpostcode.html"));
				wb.Navigate(new Uri(@"http://localhost:58647/Pages/DaumZipApi.html"));
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public PostalCode ReturnData { get; set; }

		public void Callback(object data)
		{
			try
			{
				JObject obj = JObject.Parse(data.ToString());

				PostalCode returnData = new PostalCode()
				{
					PostalNo = obj["postcode"].ToString().Replace("-", ""),
					ZoneCode = obj["zonecode"].ToString(),
					Address1 = (obj["userSelectedType"].ToString() == "J") ? obj["jibunAddress"].ToString() : obj["roadAddress"].ToString(),
					Address2 = obj["buildingName"].ToString()
				};

				this.ReturnData = returnData;
				this.DialogResult = DialogResult.OK;
				Close();
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);			
			}
		}
	}
}