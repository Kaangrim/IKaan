using System;
using System.Windows.Forms;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;

namespace IKaan.Biz.View.Forms
{
	public partial class WebForm : BaseForm
	{
		public WebForm()
		{
			InitializeComponent();
			Init();

			txtUrl.EditValueChanged += delegate (object sender, EventArgs e) { DataLoad(); };
			txtUrl.KeyDown += delegate (object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) DataLoad(); };
		}

		private void Init()
		{
			this.Padding = new Padding(4);
			txtUrl.EditValue = @"http://insight.withit.co.kr";
		}

		private void DataLoad()
		{
			if (txtUrl.EditValue.IsNullOrEmpty() == false)
				wb.Navigate(new Uri(txtUrl.Text));
		}
	}
}