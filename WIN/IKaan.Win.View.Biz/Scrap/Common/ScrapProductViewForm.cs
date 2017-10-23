using System;
using IKaan.Base.Utils;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;

namespace IKaan.Win.View.Biz.Scrap.Common
{
	public partial class ScrapProductViewForm : EditForm
	{ 
		public ScrapProductViewForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtUrl.Focus();
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

			txtUrl.SetEnable(false);
			txtUrl.EditValue = this.ParamsData.ToString();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				if (param.IsNullOrEmpty() == false)
					wb.Navigate(param.ToStringNullToEmpty());
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}