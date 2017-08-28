using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Common
{
	public partial class CustomerEditForm : EditForm
	{
		public CustomerEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += delegate (object sender, CustomHeaderButtonEventArgs e)
			{
				if (lcTab.SelectedTabPage.Name == lcGroupAddress.Name)
					ShowAddressEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupBank.Name)
					ShowBankEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupBrand.Name)
					ShowBrandEditForm(null);
				else if (lcTab.SelectedTabPage.Name == lcGroupChannel.Name)
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
			gridBrand.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
			gridChannel.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
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
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "CustomerTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizNo", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RepName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
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
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "AddressID", Visible = false },
				new XGridColumn() { FieldName = "AddressTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "PostalCode", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "AddressLine1", Width = 200 },
				new XGridColumn() { FieldName = "AddressLine2", Width = 200 },
				new XGridColumn() { FieldName = "Country", Width = 100 },
				new XGridColumn() { FieldName = "City", Width = 100 },
				new XGridColumn() { FieldName = "StateProvince", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);			
			gridAddress.ColumnFix("RowNo");
			#endregion

			#region Channel List
			gridChannel.Init();
			gridChannel.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "ChannelName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridChannel.ColumnFix("RowNo");

			#endregion

			#region Business List
			gridBusiness.Init();
			gridBusiness.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "BusinessID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizNo", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizName", Width = 200 },
				new XGridColumn() { FieldName = "RepName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridBusiness.ColumnFix("RowNo");
			#endregion

			#region Bank List
			gridBank.Init();
			gridBank.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "BankName", Width = 150 },
				new XGridColumn() { FieldName = "AccountNo", Width = 150 },
				new XGridColumn() { FieldName = "Depositor", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridBank.ColumnFix("RowNo");
			#endregion

			#region Brand List
			gridBrand.Init();
			gridBrand.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Modified", Visible = false },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "PersonName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridBrand.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<CustomerModel>();

			gridAddress.Clear<CustomerAddressModel>();
			gridBrand.Clear<CustomerBrandModel>();
			gridBusiness.Clear<CustomerBusinessModel>();
			gridBrand.Clear<CustomerBrandModel>();
			gridChannel.Clear<CustomerChannelModel>();

			lcTab.CustomHeaderButtons[0].Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtCustomerName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<CustomerModel>("Biz", "GetList", "Select", new DataMap()
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
				var model = WasHandler.GetData<CustomerModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.AddressList == null)
					model.AddressList = new List<CustomerAddressModel>();
				if (model.BankList == null)
					model.BankList = new List<CustomerBankModel>();
				if (model.BrandList == null)
					model.BrandList = new List<CustomerBrandModel>();
				if (model.BusinessList == null)
					model.BusinessList = new List<CustomerBusinessModel>();
				if (model.ChannelList == null)
					model.ChannelList = new List<CustomerChannelModel>();

				gridAddress.DataSource = model.AddressList;
				gridBank.DataSource = model.BankList;
				gridBrand.DataSource = model.BrandList;
				gridBusiness.DataSource = model.BusinessList;
				gridChannel.DataSource = model.ChannelList;

				lcTab.CustomHeaderButtons[0].Enabled = true;

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
				var model = this.GetControlData<CustomerModel>();

				using (var res = WasHandler.Execute<CustomerModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCustomer", map, "ID"))
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

				using (CustomerAddressEditForm form = new CustomerAddressEditForm()
				{
					Text = "주소등록",
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

				using (CustomerBusinessEditForm form = new CustomerBusinessEditForm()
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
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ShowBankEditForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				using (CustomerBankEditForm form = new CustomerBankEditForm()
				{
					Text = "계좌정보등록",
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

				using (CustomerBrandEditForm form = new CustomerBrandEditForm()
				{
					Text = "브랜드등록",
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

				using (CustomerChannelEditForm form = new CustomerChannelEditForm()
				{
					Text = "채널등록",
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
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}