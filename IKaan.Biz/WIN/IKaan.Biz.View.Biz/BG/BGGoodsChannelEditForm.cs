using System;
using System.Windows.Forms;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;

namespace IKaan.Biz.View.Biz.BG
{
	public partial class BGGoodsChannelEditForm : EditForm
	{
		public BGGoodsChannelEditForm()
		{
			InitializeComponent();

			lupChannelAdmin.EditValueChanged += delegate (object sender, EventArgs e)
			{
				var data = lupChannelAdmin.GetSelectedDataRow() as LookupSource;
				if (data != null)
				{
					txtURL.EditValue = data.Option1;
					txtLoginId.EditValue = data.Option2;
					txtLoginPw.EditValue = data.Option3;
				}
			};

			wbPage.Navigated += delegate (object sender, WebBrowserNavigatedEventArgs e) { doNavigated(); };
			wbPage.DocumentCompleted += delegate (object sender, WebBrowserDocumentCompletedEventArgs e) { doDocumentCompleted(); };
			btnGetInfo.Click += delegate (object sender, EventArgs e) { doGetInfo(); };
			txtURL.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
					doNavigate();
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupChannelAdmin.Focus();
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

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupChannelAdmin.BindData("ChannelAdmin", null, true);
		}

		void InitGrid()
		{
		}

		private void doNavigate()
		{
			try
			{
				wbPage.Navigate(txtURL.Text);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		private void doNavigated()
		{
			try
			{
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		private void doDocumentCompleted()
		{
			try
			{
				if (lupChannelAdmin.EditValue.ToString() == "SABANGNET")
				{
					var el_id = wbPage.GetElement("input", "id", null, null, 0);
					if (el_id != null)
					{
						el_id.SetAttribute("value", txtLoginId.Text);
						var el_pw = wbPage.GetElement("input", "passwd", null, null, 0);
						if (el_pw != null)
							el_pw.SetAttribute("value", txtLoginPw.Text);
						wbPage.Document.InvokeScript("chk");
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void doGetInfo()
		{
			try
			{
				if (lupChannelAdmin.EditValue.ToString() == "SABANGNET")
				{
					var doc = wbPage.Document.Window.Frames[1].Document;
					if (doc.Url.AbsoluteUri.Contains("product_info"))
					{
						//품번코드
						var el_product_id = doc.GetElement("input", "product_id", null, null, 0);
						if (el_product_id != null)
							memInfoText.Text = memInfoText.Text + Environment.NewLine + "품번코드: " + el_product_id.GetAttribute("value");
						//상품명
						var el_product_name = doc.GetElement("input", "product_name", "input-txt", "", 0);
						if (el_product_name != null)
							memInfoText.Text = memInfoText.Text + Environment.NewLine + "상품명: " + el_product_name.GetAttribute("value");
					}
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}