using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Channel;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;
using IKaan.Win.View.Biz.Master.Mapping;

namespace IKaan.Win.View.Biz.Master.Channel
{
	public partial class ChannelEditForm : EditForm
	{
		public ChannelEditForm()
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemName.Tag = true;
			lcItemCode.Tag = true;
			lcItemChannelType.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("ChannelName");
			lcGroupBrand.Text = DomainUtils.GetFieldName("Brand");
			lcGroupSetting.Text = DomainUtils.GetFieldName("Setting");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupChannelType.BindData("ChannelType");

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Channel Brand List
			gridBrands.Init();
			gridBrands.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "ChannelMargin", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "BrandMargin", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBrands.ColumnFix("RowNo");
			gridBrands.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					GridView view = sender as GridView;
					ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
				}
			};
			#endregion

			#region Channel Setting List
			gridSettings.Init();
			gridSettings.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "SettingCode", Visible = false },
				new XGridColumn() { FieldName = "SettingName", Width = 200 },
				new XGridColumn() { FieldName = "SettingValue", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridSettings.ColumnFix("RowNo");
			gridSettings.SetRespositoryItemTextEdit("SettingValue");
			gridSettings.SetEditable("SettingValue");
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<ChannelModel>();
			gridBrands.Clear<ChannelBrandModel>();
			gridSettings.Clear<ChannelSettingModel>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<ChannelModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model != null)
				{
					SetControlData(model);
					gridBrands.DataSource = model.Brands;
					gridSettings.DataSource = model.Settings;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
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
				var model = this.GetControlData<ChannelModel>();
				model.Settings = gridSettings.DataSource as List<ChannelSettingModel>;
				using (var res = WasHandler.Execute<ChannelModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteChannel", new DataMap() { { "ID", txtID.EditValue } }))
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
			if (lcTab.SelectedTabPage.Name == lcGroupBrand.Name)
			{
				using (var form = new _ChannelBrandEditForm())
				{
					form.Text = "브랜드입점등록";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = new DataMap()
					{
						{ "MappingType", "Channel" },
						{ "ChannelID", txtID.EditValue },
						{ "ID", data }
					};

					if (form.ShowDialog() == DialogResult.OK)
						DataLoad(txtID.EditValue);
				}
			}
		}
	}
}