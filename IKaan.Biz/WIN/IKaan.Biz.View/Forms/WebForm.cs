using System;
using System.Windows.Forms;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;

namespace IKaan.Biz.View.Forms
{
	public partial class WebForm : BaseForm
	{
		public WebForm()
		{
			InitializeComponent();

			lupWebUrl.EditValueChanged += delegate (object sender, EventArgs e)
			{
				LookupSource data = lupWebUrl.GetSelectedDataRow() as LookupSource;
				if (data != null)
				{
					txtUrl.EditValue = data.Value;
				}
			};
			txtUrl.EditValueChanged += delegate (object sender, EventArgs e) { DataLoad(); };
			txtUrl.KeyDown += delegate (object sender, KeyEventArgs e) { if (e.KeyCode == Keys.Enter) DataLoad(); };
		}

		private void Init()
		{
			this.Padding = new Padding(4);
			txtUrl.EditValue = @"http://insight.withit.co.kr";
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			Init();

			lupWebUrl.BindData("WebUrl");
		}

		private void DataLoad()
		{
			if (txtUrl.EditValue.IsNullOrEmpty() == false)
				wb.Navigate(new Uri(txtUrl.Text));
		}
	}
}