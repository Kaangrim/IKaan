using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Brand
{
	public partial class BrandEditForm : EditForm
	{
		public BrandEditForm()
		{
			InitializeComponent();

			lcTab.SelectedPageChanged += delegate (object sender, LayoutTabPageChangedEventArgs e)
			{
				if (e.Page.Name == lcGroupImage.Name)
				{
					lcTab.CustomHeaderButtons[1].Enabled = (gridImages.RowCount > 0) ? true : false;
				}
				else
				{
					lcTab.CustomHeaderButtons[1].Visible = false;
				}
			};

			lcTab.CustomHeaderButtonClick += delegate (object sender, CustomHeaderButtonEventArgs e)
			{
				if (e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupImage.Name)
						AddImage();
					else if (lcTab.SelectedTabPage.Name == lcGroupChannel.Name)
						ShowChannelForm(null);
				}
				else if (e.Button.Tag.ToStringNullToEmpty() == "DEL")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupImage.Name)
					{
						DeleteImage();
					}
				}
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtName.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("BrandName");
			lcItemCategory.SetFieldName("BrandCategory");
			lcItemStyle.SetFieldName("BrandStyle");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupCategory.BindData("BrandCategory");
			lupStyle.BindData("BrandStyle");

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Image List
			gridImages.Init();
			gridImages.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "ImageType", Width = 100 },
				new XGridColumn() { FieldName = "ImageUrl", Width = 300 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridImages.SetRepositoryItemLookUpEdit("ImageType");
			gridImages.SetRepositoryItemButtonEdit("ImageUrl");
			gridImages.ColumnFix("RowNo");

			gridImages.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						AddImage(new DataMap()
						{
							{ "ID", view.GetRowCellValue(e.RowHandle, "ID") },
							{ "BrandID", view.GetRowCellValue(e.RowHandle, "BrandID") },
							{ "ImageType", view.GetRowCellValue(e.RowHandle, "ImageType") },
							{ "ImageUrl", view.GetRowCellValue(e.RowHandle, "ImageUrl") }
						});
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Customer List
			gridAttributes.Init();
			gridAttributes.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "PersonName", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridAttributes.ColumnFix("RowNo");
			#endregion

			#region Channel List
			gridChannels.Init();
			gridChannels.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "ChannelName", Width = 150 },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ChannelMargin", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "BrandMargin", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridChannels.ColumnFix("RowNo");
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<BrandModel>();
			picBrandLogo.EditValue = null;

			gridImages.Clear<BrandImageModel>();
			gridAttributes.Clear<CustomerBrandModel>();
			gridChannels.Clear<ChannelBrandModel>();

			lcTab.CustomHeaderButtons[0].Enabled = false;
			lcTab.CustomHeaderButtons[1].Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<BrandModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				if (model.Images == null)
					model.Images = new List<BrandImageModel>();
				if (model.Channels == null)
					model.Channels = new List<ChannelBrandModel>();
				if (model.Attributes == null)
					model.Attributes = new List<BrandAttributeModel>();

				SetControlData(model);
				picBrandLogo.LoadAsync(ConstsVar.IMG_URL + model.ImageUrl);

				gridImages.DataSource = model.Images;
				gridAttributes.DataSource = model.Attributes;
				gridChannels.DataSource = model.Channels;

				lcTab.CustomHeaderButtons[0].Enabled = true;
				if (lcTab.SelectedTabPage.Name == lcGroupImage.Name)
					lcTab.CustomHeaderButtons[1].Enabled = (gridImages.RowCount > 0) ? true : false;
				else
					lcTab.CustomHeaderButtons[1].Enabled = false;

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtName.Focus();

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
				var model = this.GetControlData<BrandModel>();

				using (var res = WasHandler.Execute<BrandModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteBrand", map, "ID"))
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

		private void AddImage(DataMap parameter = null)
		{
			try
			{
				if (parameter == null)
				{
					parameter = new DataMap()
					{
						{ "ID", null },
						{ "BrandID", txtID.EditValue },
						{ "ImageType", null },
						{ "ImageUrl", null }
					};
				}
				using (BrandImageEditForm form = new BrandImageEditForm()
				{
					Text = "브랜드이미지",
					StartPosition = FormStartPosition.CenterScreen,
					ParamsData = parameter,
					IsLoadingRefresh = true
				})
				{					
					if (form.ShowDialog() == DialogResult.OK)
					{
						DataLoad(txtID.EditValue);
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void DeleteImage()
		{
			try
			{
				if (gridImages.FocusedRowHandle < 0)
					return;

				DataMap map = new DataMap() { { "ID", gridImages.GetValue(gridImages.FocusedRowHandle, "ID") } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteBrandImage", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					DataLoad(txtID.EditValue);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void ShowChannelForm(object id)
		{
			if (txtID.EditValue.IsNullOrEmpty())
				return;

			using (BrandChannelEditForm form = new BrandChannelEditForm())
			{
				form.Text = "채널등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = new DataMap()
				{
					{ "BrandID", txtID.EditValue },
					{ "BrandName", txtName.EditValue },
					{ "ID", id }
				};

				if (form.ShowDialog() == DialogResult.OK)
				{
					DataLoad(txtID.EditValue);
				}
			}
		}
	}
}