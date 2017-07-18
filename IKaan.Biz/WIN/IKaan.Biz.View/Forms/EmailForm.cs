using System;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;

namespace IKaan.Biz.View.Forms
{
	public partial class EmailForm : EditForm
	{
		public EmailForm()
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
			txtURL.EditValue = @"http://webmail.ikaan.net";
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataLoad(object param = null)
		{
			wb.Navigate(new Uri(txtURL.Text));
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