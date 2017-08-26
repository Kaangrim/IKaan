using System;
using System.Windows.Forms;
using IKaan.Base.Utils;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Forms
{
	public partial class WebForm : EditForm
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

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { });
		}
		protected override void InitControls()
		{
			base.InitControls();
			SetFieldNames();

			lupWebUrl.BindData("WebUrl");
		}

		private void DataLoad()
		{
			if (txtUrl.EditValue.IsNullOrEmpty() == false)
				wb.Navigate(new Uri(txtUrl.Text));
		}
	}
}