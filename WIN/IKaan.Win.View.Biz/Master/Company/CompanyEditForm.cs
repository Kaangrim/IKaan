using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Company;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;
using IKaan.Win.View.Biz.Master.Mapping;

namespace IKaan.Win.View.Biz.Master.Company
{
	public partial class CompanyEditForm : EditForm
	{
		public CompanyEditForm()
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("CompanyName");

			lcGroupAddress.Text = DomainUtils.GetFieldName("Address");
			lcGroupBankAccount.Text = DomainUtils.GetFieldName("BankAccount");
			lcGroupBusiness.Text = DomainUtils.GetFieldName("Business");
			lcGroupContact.Text = DomainUtils.GetFieldName("Contact");
			lcGroupStore.Text = DomainUtils.GetFieldName("Store");

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
				new XGridColumn() { FieldName = "Country", Width = 100 },
				new XGridColumn() { FieldName = "City", Width = 100 },
				new XGridColumn() { FieldName = "StateProvince", Width = 100 },
				new XGridColumn() { FieldName = "AddressLine1", Width = 200 },
				new XGridColumn() { FieldName = "AddressLine2", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);			
			gridAddress.ColumnFix("RowNo");
			gridAddress.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Store List
			gridStore.Init();
			gridStore.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "StoreID", Visible = false },
				new XGridColumn() { FieldName = "StoreName", Width = 200 },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridStore.ColumnFix("RowNo");
			gridStore.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
			gridBusiness.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Bank Account List
			gridBankAccount.Init();
			gridBankAccount.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "BankAccountName", Width = 150 },
				new XGridColumn() { FieldName = "BankName", Width = 150 },
				new XGridColumn() { FieldName = "AccountNo", Width = 150 },
				new XGridColumn() { FieldName = "Depositor", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBankAccount.ColumnFix("RowNo");
			gridBankAccount.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Contact List
			gridContact.Init();
			gridContact.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CompanyID", Visible = false },
				new XGridColumn() { FieldName = "ContactID", Visible = false },
				new XGridColumn() { FieldName = "ContactName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Position", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "AssignedTask", Width = 150 },
				new XGridColumn() { FieldName = "PhoneNo", Width = 100 },
				new XGridColumn() { FieldName = "MobileNo", Width = 100 },
				new XGridColumn() { FieldName = "FaxNo", Width = 100 },
				new XGridColumn() { FieldName = "Email", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridContact.ColumnFix("RowNo");
			gridContact.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

		#region Data Access

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
				gridBankAccount.DataSource = model.BankAccounts;
				gridContact.DataSource = model.Contacts;
				gridBusiness.DataSource = model.Businesses;
				gridStore.DataSource = model.Stores;

				if (model.Businesses.Count > 0)
				{
					lupBizType.EditValue = model.CurrentBusiness.BizType;
					txtBizName.EditValue = model.CurrentBusiness.Name;
					txtBizNo.EditValue = model.CurrentBusiness.BizNo;
					txtRepName.EditValue = model.CurrentBusiness.RepName;
					txtBizKind.EditValue = model.CurrentBusiness.BizKind;
					txtBizItem.EditValue = model.CurrentBusiness.BizItem;
					txtAddressLine1.EditValue = model.CurrentBusiness.Address.AddressLine1;
					txtAddressLine2.EditValue = model.CurrentBusiness.Address.AddressLine2;
				}

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

		#endregion

		protected override void ShowEdit(object data = null)
		{
			if (txtID.EditValue.IsNullOrEmpty())
				return;

			try
			{
				if (lcTab.SelectedTabPage.Name == lcGroupAddress.Name)
				{
					using (var form = new _AddressEditForm()
					{
						Text = "주소등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Company" },
							{ "CompanyID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad(txtID.EditValue);
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupBankAccount.Name)
				{
					using (var form = new _BankAccountEditForm()
					{
						Text = "은행계좌등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Company" },
							{ "CompanyID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad(txtID.EditValue);
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupBusiness.Name)
				{
					using (var form = new _BusinessEditForm()
					{
						Text = "사업자정보등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Company" },
							{ "CompanyID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad(txtID.EditValue);
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupContact.Name)
				{
					using (var form = new _ContactEditForm()
					{
						Text = "담당자등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Company" },
							{ "CompanyID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad(txtID.EditValue);
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupStore.Name)
				{
					using (var form = new _StoreEditForm()
					{
						Text = "상점등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Company" },
							{ "CompanyID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad(txtID.EditValue);
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