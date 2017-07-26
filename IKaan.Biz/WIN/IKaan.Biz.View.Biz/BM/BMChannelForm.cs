using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BM
{
	public partial class BMChannelForm : EditForm
	{
		public BMChannelForm()
		{
			InitializeComponent();

			btnAddBrand.Click += delegate (object sender, EventArgs e) { DataNewChannelBrand(); };
			btnDeleteBrand.Click += delegate (object sender, EventArgs e) { DataDeleteChannelBrand(); };
			btnAddCustomer.Click += delegate (object sender, EventArgs e) { DataNewChannelCustomer(); };
			btnDeleteCustomer.Click += delegate (object sender, EventArgs e) { DataDeleteChannelCustomer(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupFindChannelType.BindData("ChannelType", "All");
			lupFindUseYn.BindData("Yn", "All");
			lupChannelType.BindData("ChannelType");
		}

		void InitGrid()
		{
			#region Channel List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ChannelCode", Width = 80 },
				new XGridColumn() { FieldName = "ChannelName", Width = 150 },
				new XGridColumn() { FieldName = "ChannelTypeName", Width = 100 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
			gridList.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridList.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Channel Brand List
			gridChannelBrand.Init();
			gridChannelBrand.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "ChannelMargin", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "BrandMargin", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridChannelBrand.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridChannelBrand.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridChannelBrand.ColumnFix("RowNo");
			#endregion

			#region Channel Customer List
			gridChannelCustomer.Init();
			gridChannelCustomer.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "D" },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "D" },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridChannelCustomer.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridChannelCustomer.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridChannelCustomer.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<BMChannel>();
			gridChannelBrand.Clear<BMChannelBrand>();
			gridChannelCustomer.Clear<BMCustomerChannel>();

			btnAddBrand.Enabled = false;
			btnDeleteBrand.Enabled = false;
			btnAddCustomer.Enabled = false;
			btnDeleteCustomer.Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtChannelName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BMChannel>("BM", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var model = WasHandler.GetData<BMChannel>("BM", "GetData", "Select", new DataMap() { { "ID", id } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<BMChannelBrand> channelBrand = new List<BMChannelBrand>();
				IList<BMCustomerChannel> channelCustomer = new List<BMCustomerChannel>();

				if (model.ChannelBrand != null)
					channelBrand = model.ChannelBrand;
				if (model.ChannelCustomer != null)
					channelCustomer = model.ChannelCustomer;

				SetControlData(model);
				gridChannelBrand.DataSource = channelBrand;
				gridChannelCustomer.DataSource = channelCustomer;

				btnAddBrand.Enabled = 
					btnDeleteBrand.Enabled = 
					btnAddCustomer.Enabled = 
					btnDeleteCustomer.Enabled = true;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtChannelName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<BMChannel>();
				List<BMChannelBrand> channelBrand = new List<BMChannelBrand>();
				List<BMCustomerChannel> channelCustomer = new List<BMCustomerChannel>();

				if (gridChannelBrand.RowCount > 0)
					channelBrand = gridChannelBrand.DataSource as List<BMChannelBrand>;
				if (gridChannelCustomer.RowCount > 0)
					channelCustomer = gridChannelCustomer.DataSource as List<BMCustomerChannel>;

				model.ChannelBrand = channelBrand;
				model.ChannelCustomer = channelCustomer;

				using (var res = WasHandler.Execute<BMChannel>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("BM", "Delete", "DeleteBMChannel", map, "ID"))
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

		private void DataNewChannelBrand()
		{
			gridChannelBrand.AddNewRow();
		}
		private void DataDeleteChannelBrand()
		{

		}
		private void DataNewChannelCustomer()
		{
			gridChannelCustomer.AddNewRow();
		}
		private void DataDeleteChannelCustomer()
		{

		}
	}
}