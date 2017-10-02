using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;
using IKaan.Win.View.Biz.Master.Mapping;

namespace IKaan.Win.View.Biz.Master.Partner
{
	public partial class PartnerEditForm : EditForm
	{
		public PartnerEditForm()
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

			lcItemPartnerType.Tag = true;
			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("PartnerName");
			lcGroupAddress.Text = DomainUtils.GetFieldName("Address");
			lcGroupBankAccount.Text = DomainUtils.GetFieldName("BankAccount");
			lcGroupBrand.Text = DomainUtils.GetFieldName("Brand");
			lcGroupBusiness.Text = DomainUtils.GetFieldName("Business");
			lcGroupChannel.Text = DomainUtils.GetFieldName("Channel");
			lcGroupContact.Text = DomainUtils.GetFieldName("Contact");
			lcGroupManager.Text = DomainUtils.GetFieldName("Manager");

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
			lupPartnerType.BindData("PartnerType");

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Address List
			gridAddresses.Init();
			gridAddresses.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
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
			gridAddresses.ColumnFix("RowNo");
			gridAddresses.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Channel List
			gridChannels.Init();
			gridChannels.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "ChannelName", Width = 200 },
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

			#region Business List
			gridBusinesses.Init();
			gridBusinesses.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
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
			gridBusinesses.ColumnFix("RowNo");
			gridBusinesses.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Bank List
			gridBankAccounts.Init();
			gridBankAccounts.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
				new XGridColumn() { FieldName = "BankName", Width = 150 },
				new XGridColumn() { FieldName = "AccountNo", Width = 150 },
				new XGridColumn() { FieldName = "Depositor", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBankAccounts.ColumnFix("RowNo");
			gridBankAccounts.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Brand List
			gridBrands.Init();
			gridBrands.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "PersonName", Width = 100, HorzAlignment = HorzAlignment.Center },
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
			gridContacts.Init();
			gridContacts.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
				new XGridColumn() { FieldName = "ContactID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ContactName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "PhoneNo", Width = 100 },
				new XGridColumn() { FieldName = "MobileNo", Width = 100 },
				new XGridColumn() { FieldName = "FaxNo", Width = 100 },
				new XGridColumn() { FieldName = "Email", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridContacts.ColumnFix("RowNo");
			gridContacts.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Manager List
			gridManagers.Init();
			gridManagers.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "PartnerID", Visible = false },
				new XGridColumn() { FieldName = "EmployeeID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "DepartmentName", Width = 100 },
				new XGridColumn() { FieldName = "EmployeeName", Width = 100, HorzAlignment = HorzAlignment.Center },				
				new XGridColumn() { FieldName = "PhoneNo", Width = 100 },
				new XGridColumn() { FieldName = "MobileNo", Width = 100 },
				new XGridColumn() { FieldName = "FaxNo", Width = 100 },
				new XGridColumn() { FieldName = "Email", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridManagers.ColumnFix("RowNo");
			gridManagers.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<PartnerModel>();
			ClearControlData<BusinessModel>();

			gridAddresses.Clear<PartnerAddressModel>();
			gridBrands.Clear<PartnerBrandModel>();
			gridBusinesses.Clear<PartnerBusinessModel>();
			gridBrands.Clear<PartnerBrandModel>();
			gridChannels.Clear<PartnerChannelModel>();
			gridContacts.Clear<PartnerContactModel>();
			gridManagers.Clear<PartnerManagerModel>();

			lcTab.CustomHeaderButtons[0].Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			if (param == null)
				return;

			try
			{
				var model = WasHandler.GetData<PartnerModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model != null)
				{
					SetControlData(model);
					gridAddresses.DataSource = model.Addresses;
					gridBankAccounts.DataSource = model.BankAccounts;
					gridBrands.DataSource = model.Brands;
					gridBusinesses.DataSource = model.Businesses;
					gridChannels.DataSource = model.Channels;
					gridContacts.DataSource = model.Contacts;
					gridManagers.DataSource = model.Managers;
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
				object id = null;
				var model = this.GetControlData<PartnerModel>();
				using (var res = WasHandler.Execute<PartnerModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeletePartner", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				if (lcTab.SelectedTabPage.Name == lcGroupAddress.Name)
				{
					using (var form = new _AddressEditForm()
					{
						Text = "주소등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
						{
							DataLoad(txtID.EditValue);
						}
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
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
						{
							DataLoad(txtID.EditValue);
						}
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupBrand.Name)
				{
					using (var form = new _BrandEditForm()
					{
						Text = "브랜드등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
						{
							DataLoad(txtID.EditValue);
						}
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
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
						{
							DataLoad(txtID.EditValue);
						}
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupChannel.Name)
				{
					using (var form = new _ChannelEditForm()
					{
						Text = "채널등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
						{
							DataLoad(txtID.EditValue);
						}
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
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
							{ "ID", data }
						}
					})
					{
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad(txtID.EditValue);
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupManager.Name)
				{
					using (var form = new _ContactEditForm()
					{
						Text = "매니저등록",
						StartPosition = FormStartPosition.CenterScreen,
						IsLoadingRefresh = true,
						ParamsData = new DataMap()
						{
							{ "MappingType", "Partner" },
							{ "PartnerID", txtID.EditValue },
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