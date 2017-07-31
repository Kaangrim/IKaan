using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.PostCode;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BM
{
	public partial class BMCustomerForm : EditForm
	{
		public BMCustomerForm()
		{
			InitializeComponent();

			btnAddBusiness.Click += delegate (object sender, EventArgs e) { AddBusiness(null); };
			gridBusiness.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						AddBusiness(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			btnAddAddress.Click += delegate (object sender, EventArgs e)
			{
				(gridAddress.DataSource as List<BMCustomerAddress>).Add(new BMCustomerAddress()
				{
					CustomerID = txtID.EditValue.ToIntegerNullToNull()
				});
				gridAddress.SetFocus(gridAddress.FocusedRowHandle, "PostalCode");
			};
			btnDelAddress.Click += delegate (object sender, EventArgs e)
			{
				throw new NotImplementedException();
			};
		}

		void AddBusiness(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				using (BMCustomerBusinessForm form = new BMCustomerBusinessForm()
				{
					Text = "사업자정보등록",
					StartPosition = FormStartPosition.CenterScreen,
					IsLoadingRefresh = true,
					ParamsData = new DataMap()
				{
					{ "CustomerID", txtID.EditValue },
					{ "CustomerName", txtCustomerName.EditValue },
					{ "ID", id }
				}
				})
				{
					if (form.ShowDialog() == DialogResult.OK)
					{
						DetailDataLoad(txtID.EditValue);
					}
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
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

			lcItemCustomerType.Tag = true;
			lcItemCustomerName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lupBizType.SetEnable(false);
			txtBizNo.SetEnable(false);
			txtBizName.SetEnable(false);
			txtRepName.SetEnable(false);
			txtBizKind.SetEnable(false);
			txtBizItem.SetEnable(false);
			txtAddressLine1.SetEnable(false);
			txtAddressLine2.SetEnable(false);

			lupBizType.BindData("BizType");
			lupCustomerType.BindData("CustomerType");

			lupFindCustomerType.BindData("CustomerType", "All");
			lupFindUseYn.BindData("Yn", "All");
			lupFindUseYn.EditValue = "Y";

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "CustomerTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
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

			#region Address List
			gridAddress.Init();
			gridAddress.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "AddressID", Visible = false },
				new XGridColumn() { FieldName = "PostalCode", Width = 100 },
				new XGridColumn() { FieldName = "AddressLine1", Width = 200 },
				new XGridColumn() { FieldName = "AddressLine2", Width = 200 },
				new XGridColumn() { FieldName = "Country", Width = 100 },
				new XGridColumn() { FieldName = "City", Width = 100 },
				new XGridColumn() { FieldName = "StateProvince", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);			
			gridAddress.ColumnFix("RowNo");
			gridAddress.SetRepositoryItemButtonEdit("PostalCode");
			gridAddress.SetEditable("PostalCode", "AddressLine1", "AddressLine2", "Country", "City", "StateProvince");
			(gridAddress.MainView.Columns["PostalCode"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
				{
					var data = SearchPostCode.Find();
					if (data != null)
					{
						int rowindex = gridAddress.FocusedRowHandle;
						gridAddress.SetValue(rowindex, "PostalCode", data.PostalNo);
						gridAddress.SetValue(rowindex, "AddressLine1", data.Address1);
						gridAddress.SetValue(rowindex, "AddressLine2", data.Address2);
					}
				}
			};
			#endregion

			#region Channel List
			gridChannel.Init();
			gridChannel.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "ChannelName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridChannel.ColumnFix("RowNo");
			gridChannel.SetRepositoryItemButtonEdit("ChannelName");
			gridChannel.SetEditable("ChannelName", "StartDate");

			#endregion

			#region Business List
			gridBusiness.Init();
			gridBusiness.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "BusinessID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100 },
				new XGridColumn() { FieldName = "EndDate", Width = 100 },
				new XGridColumn() { FieldName = "BizNo", Width = 100 },
				new XGridColumn() { FieldName = "BizName", Width = 200 },
				new XGridColumn() { FieldName = "RepName", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridBusiness.ColumnFix("RowNo");
			#endregion

			#region Bank List
			gridBank.Init();
			gridBank.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "BankName", Width = 150 },
				new XGridColumn() { FieldName = "AccountNo", Width = 150 },
				new XGridColumn() { FieldName = "Depositor", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridBank.ColumnFix("RowNo");
			gridBank.SetRespositoryItemTextEdit("BankName");
			gridBank.SetRespositoryItemTextEdit("AccountNo");
			gridBank.SetRespositoryItemTextEdit("Depositor");
			gridBank.SetEditable("BankName", "AccountNo", "Depositor");
			#endregion

			#region Brand List
			gridBrand.Init();
			gridBrand.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "PersonName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridBrand.ColumnFix("RowNo");
			gridBrand.SetRepositoryItemButtonEdit("BrandName");
			gridBrand.SetEditable("BrandName", "StartDate");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<BMCustomer>();

			gridAddress.Clear<BMCustomerAddress>();
			gridBrand.Clear<BMCustomerBrand>();
			gridBusiness.Clear<BMCustomerBusiness>();
			gridBrand.Clear<BMCustomerBrand>();
			gridChannel.Clear<BMCustomerChannel>();

			btnAddAddress.Enabled =
				btnDelAddress.Enabled = false;
			btnAddBrand.Enabled =
				btnDelBrand.Enabled = false;
			btnAddBusiness.Enabled = false;
			btnAddBank.Enabled =
				btnDelBank.Enabled = false;
			btnAddChannel.Enabled =
				btnDelChannel.Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtCustomerName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BMCustomer>("BM", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "UseYn", lupFindUseYn.EditValue },
				{ "CustomerType", lupFindCustomerType.EditValue }
			});

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				DataMap parameter = new DataMap()
				{
					{ "ID", id }
				};
				var model = WasHandler.GetData<BMCustomer>("BM", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.AddressList == null)
					model.AddressList = new List<BMCustomerAddress>();
				if (model.BankList == null)
					model.BankList = new List<BMCustomerBank>();
				if (model.BrandList == null)
					model.BrandList = new List<BMCustomerBrand>();
				if (model.BusinessList == null)
					model.BusinessList = new List<BMCustomerBusiness>();
				if (model.ChannelList == null)
					model.ChannelList = new List<BMCustomerChannel>();

				gridAddress.DataSource = model.AddressList;
				gridBank.DataSource = model.BankList;
				gridBrand.DataSource = model.BrandList;
				gridBusiness.DataSource = model.BusinessList;
				gridChannel.DataSource = model.ChannelList;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtCustomerName.Focus();

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
				var model = this.GetControlData<BMCustomer>();

				using (var res = WasHandler.Execute<BMCustomer>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("BM", "Delete", "DeleteBMCustomer", map, "ID"))
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