using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Company;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Company
{
	public partial class CompanyEditForm : EditForm
	{
		public CompanyEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += delegate (object sender, CustomHeaderButtonEventArgs e)
			{
				if (lcTab.SelectedTabPage.Name == lcGroupAddress.Name)
					ShowAddressEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupBank.Name)
					ShowBankEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupContact.Name)
					ShowBrandEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupStore.Name)
					ShowChannelEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupBusiness.Name)
					ShowBusinessEditForm(null);
			};

			gridBusiness.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowBusinessEditForm(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			gridAddress.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowAddressEditForm(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			gridBank.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowBankEditForm(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			gridContact.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowBrandEditForm(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			gridStore.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowChannelEditForm(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("CompanyName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupBizType.SetEnable(false);
			txtBizNo.SetEnable(false);
			txtBizName.SetEnable(false);
			txtRepName.SetEnable(false);
			txtBizKind.SetEnable(false);
			txtBizItem.SetEnable(false);
			txtAddressLine1.SetEnable(false);
			txtAddressLine2.SetEnable(false);

			lupBizType.BindData("BizType");

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Address List
			gridAddress.Init();
			gridAddress.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "AddressID", Visible = false },
				new XGridColumn() { FieldName = "AddressTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "PostalCode", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "AddressLine1", Width = 200 },
				new XGridColumn() { FieldName = "AddressLine2", Width = 200 },
				new XGridColumn() { FieldName = "Country", Width = 100 },
				new XGridColumn() { FieldName = "City", Width = 100 },
				new XGridColumn() { FieldName = "StateProvince", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);			
			gridAddress.ColumnFix("RowNo");
			#endregion

			#region Channel List
			gridStore.Init();
			gridStore.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "StoreID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "StoreName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridStore.ColumnFix("RowNo");

			#endregion

			#region Business List
			gridBusiness.Init();
			gridBusiness.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "BusinessID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizNo", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizName", Width = 200 },
				new XGridColumn() { FieldName = "RepName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBusiness.ColumnFix("RowNo");
			#endregion

			#region Bank List
			gridBank.Init();
			gridBank.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "BankName", Width = 150 },
				new XGridColumn() { FieldName = "AccountNo", Width = 150 },
				new XGridColumn() { FieldName = "Depositor", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBank.ColumnFix("RowNo");
			#endregion

			#region Contact List
			gridContact.Init();
			gridContact.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "ContactID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Name", CaptionCode = "ContactName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridContact.ColumnFix("RowNo");
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<CompanyModel>();

			gridAddress.Clear<CompanyAddressModel>();
			gridContact.Clear<CompanyContactModel>();
			gridBusiness.Clear<CompanyBusinessModel>();
			gridContact.Clear<CompanyContactModel>();
			gridStore.Clear<CompanyStoreModel>();

			lcTab.CustomHeaderButtons[0].Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<CompanyModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.Addresses == null)
					model.Addresses = new List<CompanyAddressModel>();
				if (model.BankAccounts == null)
					model.BankAccounts = new List<CompanyBankAccountModel>();
				if (model.Contacts == null)
					model.Contacts = new List<CompanyContactModel>();
				if (model.Businesses == null)
					model.Businesses = new List<CompanyBusinessModel>();
				if (model.Stores == null)
					model.Stores = new List<CompanyStoreModel>();

				gridAddress.DataSource = model.Addresses;
				gridBank.DataSource = model.BankAccounts;
				gridContact.DataSource = model.Contacts;
				gridBusiness.DataSource = model.Businesses;
				gridStore.DataSource = model.Stores;

				lcTab.CustomHeaderButtons[0].Enabled = true;

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
				var model = this.GetControlData<CompanyModel>();
				using (var res = WasHandler.Execute<CompanyModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCompany", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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

		void ShowAddressEditForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				//using (CompanyAddressEditForm form = new CompanyAddressEditForm()
				//{
				//	Text = "주소등록",
				//	StartPosition = FormStartPosition.CenterScreen,
				//	IsLoadingRefresh = true,
				//	ParamsData = new DataMap()
				//	{
				//		{ "CompanyID", txtID.EditValue },
				//		{ "CompanyName", txtName.EditValue },
				//		{ "ID", id }
				//	}
				//})
				//{
				//	if (form.ShowDialog() == DialogResult.OK)
				//	{
				//		DetailDataLoad(txtID.EditValue);
				//	}
				//}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ShowBusinessEditForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				//using (CompanyBusinessEditForm form = new CompanyBusinessEditForm()
				//{
				//	Text = "사업자정보등록",
				//	StartPosition = FormStartPosition.CenterScreen,
				//	IsLoadingRefresh = true,
				//	ParamsData = new DataMap()
				//{
				//	{ "CompanyID", txtID.EditValue },
				//	{ "CompanyName", txtName.EditValue },
				//	{ "ID", id }
				//}
				//})
				//{
				//	if (form.ShowDialog() == DialogResult.OK)
				//	{
				//		DetailDataLoad(txtID.EditValue);
				//	}
				//}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ShowBankEditForm(object id)
		{
			try
			{
				//if (txtID.EditValue.IsNullOrEmpty())
				//	return;

				//using (CompanyBankEditForm form = new CompanyBankEditForm()
				//{
				//	Text = "계좌정보등록",
				//	StartPosition = FormStartPosition.CenterScreen,
				//	IsLoadingRefresh = true,
				//	ParamsData = new DataMap()
				//	{
				//		{ "CompanyID", txtID.EditValue },
				//		{ "CompanyName", txtName.EditValue },
				//		{ "ID", id }
				//	}
				//})
				//{
				//	if (form.ShowDialog() == DialogResult.OK)
				//	{
				//		DetailDataLoad(txtID.EditValue);
				//	}
				//}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ShowBrandEditForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				//using (CompanyBrandEditForm form = new CompanyBrandEditForm()
				//{
				//	Text = "브랜드등록",
				//	StartPosition = FormStartPosition.CenterScreen,
				//	IsLoadingRefresh = true,
				//	ParamsData = new DataMap()
				//	{
				//		{ "CompanyID", txtID.EditValue },
				//		{ "CompanyName", txtName.EditValue },
				//		{ "ID", id }
				//	}
				//})
				//{
				//	if (form.ShowDialog() == DialogResult.OK)
				//	{
				//		DetailDataLoad(txtID.EditValue);
				//	}
				//}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ShowChannelEditForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				//using (CompanyChannelEditForm form = new CompanyChannelEditForm()
				//{
				//	Text = "채널등록",
				//	StartPosition = FormStartPosition.CenterScreen,
				//	IsLoadingRefresh = true,
				//	ParamsData = new DataMap()
				//	{
				//		{ "CompanyID", txtID.EditValue },
				//		{ "CompanyName", txtName.EditValue },
				//		{ "ID", id }
				//	}
				//})
				//{
				//	if (form.ShowDialog() == DialogResult.OK)
				//	{
				//		DetailDataLoad(txtID.EditValue);
				//	}
				//}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}