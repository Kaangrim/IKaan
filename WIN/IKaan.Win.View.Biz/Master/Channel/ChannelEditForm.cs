using System;
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
			lcGroupCustomer.Text = DomainUtils.GetFieldName("Customer");
			lcGroupBrand.Text = DomainUtils.GetFieldName("Brand");
			lcGroupSetting.Text = DomainUtils.GetFieldName("Setting");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupChannelType.BindData("ChannelType");

			spnOrderNoDigit.SetFormat("N0", false, HorzAlignment.Near);
			spnOrderLine.SetFormat("N0", false, HorzAlignment.Near);
			spnAccountLine.SetFormat("N0", false, HorzAlignment.Near);

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

			#region Channel Customer List
			gridCustomers.Init();
			gridCustomers.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridCustomers.ColumnFix("RowNo");
			gridCustomers.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
		}

		protected override void DataInit()
		{
			ClearControlData<ChannelModel>();
			gridBrands.Clear<ChannelBrandModel>();
			gridCustomers.Clear<CustomerChannelModel>();

			chkOrderDateYn.Checked = true;
			chkOrderAddYearYn.Checked = false;
			spnOrderNoDigit.EditValue = 0;
			chkOptionYn.Checked = true;
			txtOptionFormat.EditValue = null;
			spnOrderLine.EditValue = 2;
			spnAccountLine.EditValue = 2;

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

					chkOrderDateYn.Checked = (model.Setting.OrderDateYn == "Y") ? true : false;
					chkOrderAddYearYn.Checked = (model.Setting.OrderAddYearYn == "Y") ? true : false;
					spnOrderNoDigit.EditValue = model.Setting.OrderNoDigit;
					chkOptionYn.Checked = (model.Setting.OptionYn == "Y") ? true : false;
					txtOptionFormat.EditValue = model.Setting.OptionFormat;
					spnOrderLine.EditValue = model.Setting.OrderLine;
					spnAccountLine.EditValue = model.Setting.AccountLine;

					gridBrands.DataSource = model.Brands;
					gridCustomers.DataSource = model.Customers;
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
				model.Setting = new ChannelSettingModel()
				{
					ChannelID = txtID.EditValue.ToIntegerNullToNull(),
					OrderDateYn = chkOrderDateYn.Checked ? "Y" : "N",
					OrderAddYearYn = chkOrderAddYearYn.Checked ? "Y" : "N",
					OrderNoDigit = spnOrderNoDigit.EditValue.ToIntegerNullToZero(),
					OptionYn = chkOptionYn.Checked ? "Y" : "N",
					OptionFormat = txtOptionFormat.EditValue.ToStringNullToNull(),
					OrderLine = spnOrderLine.EditValue.ToIntegerNullToZero(),
					AccountLine = spnOrderLine.EditValue.ToIntegerNullToZero()
				};

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
			else if (lcTab.SelectedTabPage.Name == lcGroupCustomer.Name)
			{
				using (var form = new _ChannelEditForm())
				{
					form.Text = "채널/거래처등록";
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