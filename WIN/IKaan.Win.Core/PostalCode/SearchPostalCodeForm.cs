using System;
using System.Security.Permissions;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Variables;
using Newtonsoft.Json.Linq;

namespace IKaan.Win.Core.PostalCode
{
	[PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
	[System.Runtime.InteropServices.ComVisible(true)]
	public partial class SearchPostalCodeForm : XtraForm
	{
		private bool bOpened = false;   //중복실행방지

		public SearchPostalCodeForm()
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
				this.LookAndFeel.UseDefaultLookAndFeel = false;
				this.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSkin);

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

		public PostalCodeModel ReturnData { get; set; }

		public void Callback(object data)
		{
			try
			{
				JObject obj = JObject.Parse(data.ToString());

				var returnData = new PostalCodeModel()
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