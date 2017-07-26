using System;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;

namespace IKaan.Biz.View.Forms
{
	public partial class WebForm : EditForm
	{
		public WebForm()
		{
			InitializeComponent();

			wb.DocumentCompleted += delegate (object sender, System.Windows.Forms.WebBrowserDocumentCompletedEventArgs e) { doDocumentCompleted(); };
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
		}

		protected override void InitControls()
		{
			base.InitControls();
			SetFieldNames();
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataLoad(object param = null)
		{
			string url1 = @"http://insight.withit.co.kr";
			string url2 = @"http://app.withit.co.kr";

			if (this.Text.ToStringNullToEmpty() == "SMAPS1")
				wb.Navigate(new Uri(url1));
			else if (this.Text.ToStringNullToEmpty() == "SMAPS2")
				wb.Navigate(new Uri(url2));
		}

		private void doDocumentCompleted()
		{
			try
			{
				//var el_id = wb.GetElement("input", "mail", null, null, 0);
				//if (el_id != null)
				//{
				//	el_id.SetAttribute("value", txtLoginId.Text);
				//	var el_pw = wb.GetElement("input", "passwd", null, null, 0);
				//	if (el_pw != null)
				//		el_pw.SetAttribute("value", txtLoginPw.Text);
				//	wbPage.Document.InvokeScript("chk");
				//}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}