﻿using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Brand;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;
using IKaan.Win.View.Biz.Master.Mapping;

namespace IKaan.Win.View.Biz.Master.Brand
{
	public partial class BrandEditForm : EditForm
	{
		public BrandEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += delegate (object sender, CustomHeaderButtonEventArgs e)
			{
				ShowEdit(null);
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
			lcItemCode.SetFieldName("BrandCode");
			lcItemCategory.SetFieldName("BrandCategory");
			lcItemStyle.SetFieldName("BrandStyle");

			lcGroupAttribute.Text = DomainUtils.GetFieldName("Attribute");
			lcGroupChannel.Text = DomainUtils.GetFieldName("Channel");
			lcGroupImage.Text = DomainUtils.GetFieldName("Image");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupCategory.BindData("BrandCategory", "None");
			lupStyle.BindData("BrandStyle", "None");

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
				new XGridColumn() { FieldName = "ImageType", Visible = false },
				new XGridColumn() { FieldName = "ImageTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ImageUrl", Width = 300 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
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
						ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Attributes List
			gridAttributes.Init();
			gridAttributes.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "AttributeTypeID", Visible = false },
				new XGridColumn() { FieldName = "AttributeID", Visible = false },
				new XGridColumn() { FieldName = "AttributeTypeName", Width = 100 },
				new XGridColumn() { FieldName = "AttributeName", Width = 100 },
				new XGridColumn() { FieldName = "AttributeValue", Width = 100 },
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
			gridChannels.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
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
			ClearControlData<BrandModel>();
			picLogo.EditValue = null;

			gridImages.Clear<BrandImageModel>();
			gridAttributes.Clear<BrandAttributeModel>();
			gridChannels.Clear<ChannelBrandModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<BrandModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				SetControlData(model);
				if (model.ImageUrl.IsNullOrEmpty() == false)
					picLogo.LoadAsync(GlobalVar.ImageServerInfo.CdnUrl + model.ImageUrl);

				gridImages.DataSource = model.Images;
				gridAttributes.DataSource = model.Attributes;
				gridChannels.DataSource = model.Channels;

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
				object id = null;
				var model = this.GetControlData<BrandModel>();
				using (var res = WasHandler.Execute<BrandModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					id = res.Result.ReturnValue;
				}
				ShowMsgBox("저장하였습니다.");
				callback(arg, id);
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteBrand", new DataMap() { { "ID", txtID.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				ShowMsgBox("삭제하였습니다.");
				callback(arg, null);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void ShowEdit(object data = null)
		{
			var parameter = new DataMap()
			{
				{ "MappingType", "Brand" },
				{ "BrandID", txtID.EditValue },
				{ "ID", data }
			};

			if (lcTab.SelectedTabPage.Name == lcGroupImage.Name)
			{
				using (var form = new _ImageEditForm()
				{
					Text = "이미지등록",
					StartPosition = FormStartPosition.CenterScreen,
					IsLoadingRefresh = true,
					ParamsData = parameter
				})
				{
					if (form.ShowDialog() == DialogResult.OK)
						DataLoad(txtID.EditValue);
				}
			}
			else if (lcTab.SelectedTabPage.Name == lcGroupChannel.Name)
			{
				using (var form = new _ChannelEditForm())
				{
					form.Text = "채널등록";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = parameter;

					if (form.ShowDialog() == DialogResult.OK)
						DataLoad(txtID.EditValue);
				}
			}
		}
	}
}