using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Common
{
	public partial class ScrapProductEditForm : EditForm
	{ 
		public ScrapProductEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtCode.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemSite.Tag = true;
			lcItemCode.Tag = true;

			SetFieldNames();

			lcItemCode.SetFieldName("ProductCode");
			lcItemName.SetFieldName("ProductName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupSiteID.BindData("ScrapSite");
			lupBrandCode.BindData("ScrapBrand", null, false, new DataMap() { { "SiteID", lupSiteID.EditValue } });
			lupCategoryID.BindData("ScrapCategory", null, false, new DataMap() { { "SiteID", lupSiteID.EditValue } });
			lupGender.BindData("Gender");
			lupOption1Type.BindData("OptionType", "None");
			lupOption2Type.BindData("OptionType", "None");
			txtCategoryName.SetEnable(false);

			spnListPrice.SetFormat("N0", false, HorzAlignment.Far);
			spnSalePrice.SetFormat("N0", false, HorzAlignment.Far);

			InitGrid();
		}

		private void InitGrid()
		{
			#region Product
			gridImages.Init();
			gridImages.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ProductID", Visible = false },
				new XGridColumn() { FieldName = "ImageType", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "FileName", Width = 200 },
				new XGridColumn() { FieldName = "Url", Width = 200 },
				new XGridColumn() { FieldName = "Width", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "Height", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridImages.ColumnFix("RowNo");
			gridImages.ColumnFix("Checked");
			gridImages.SetEditable("Checked");
			gridImages.SetRepositoryItemCheckEdit("Checked");

			gridImages.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						picImage.EditValue = ConstsVar.IMG_URL + view.GetRowCellValue(e.RowHandle, "Url").ToStringNullToEmpty();
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<ScrapProductModel>();
			gridImages.Clear<ScrapProductImageModel>();
			picImage.EditValue = null;

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtCode.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<ScrapProductModel>("Scrap", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model.Images != null)
				{
					gridImages.DataSource = model.Images;
					if (model.Images != null && model.Images.Count > 0)
						picImage.LoadAsync(model.Images[0].Url);
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtCode.Focus();

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<ScrapProductModel>();
				model.Images = gridImages.DataSource as IList<ScrapProductImageModel>;
				using (var res = WasHandler.Execute<ScrapProductModel>("Scrap", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					callback(arg, res.Result.ReturnValue);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				using (var res = WasHandler.Execute<DataMap>("Scrap", "Delete", "DeleteScrapProduct", new DataMap() { { "ID", txtID.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					callback(arg, null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}