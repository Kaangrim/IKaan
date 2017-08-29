using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.Buttons;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Customer
{
	public partial class ChannelEditForm : EditForm
	{
		public ChannelEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += delegate (object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
			{
				if (e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupContact.Name)
						ShowContactForm(null);
					else if (lcTab.SelectedTabPage.Name == lcGroupManager.Name)
						ShowManagerForm(null);
					else if (lcTab.SelectedTabPage.Name == lcGroupBrand.Name)
						ShowChannelBrandForm(null);
					else if (lcTab.SelectedTabPage.Name == lcGroupCustomer.Name)
						ShowChannelCustomerForm(null);
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

			lcItemChannelName.Tag = true;
			lcItemChannelCode.Tag = true;
			lcItemChannelType.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lupFindChannelType.BindData("ChannelType", "All");
			lupFindUseYn.BindData("Yn", "All");
			lupChannelType.BindData("ChannelType");

			spnOrderNoDigit.SetFormat("N0", false, HorzAlignment.Near);
			spnOrderLine.SetFormat("N0", false, HorzAlignment.Near);
			spnAccountLine.SetFormat("N0", false, HorzAlignment.Near);

			InitGrid();

			lcTab.CustomHeaderButtons.OfType<CustomHeaderButton>().Where(x => x.Tag.ToStringNullToEmpty() == "DEL").ToList().ForEach(button =>
			{
				button.Visible = false;
			});

			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Channel List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelCode", Width = 80 },
				new XGridColumn() { FieldName = "ChannelName", Width = 150 },
				new XGridColumn() { FieldName = "ChannelTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
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
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridBrands.ColumnFix("RowNo");
			gridBrands.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					GridView view = sender as GridView;
					ShowChannelBrandForm(view.GetRowCellValue(e.RowHandle, "ID"));
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
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridCustomers.ColumnFix("RowNo");
			gridCustomers.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					GridView view = sender as GridView;
					ShowChannelCustomerForm(view.GetRowCellValue(e.RowHandle, "ID"));
				}
			};
			#endregion

			#region Contact List
			gridContacts.Init();
			gridContacts.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "PersonName", CaptionCode = "ContactName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Position", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "AssignedTask", Width = 150 },
				new XGridColumn() { FieldName = "Email", Width = 150 },
				new XGridColumn() { FieldName = "PhoneNo1", Width = 100 },
				new XGridColumn() { FieldName = "PhoneNo2", Width = 100 },
				new XGridColumn() { FieldName = "FaxNo", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridContacts.ColumnFix("RowNo");
			gridContacts.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					GridView view = sender as GridView;
					ShowContactForm(view.GetRowCellValue(e.RowHandle, "ID"));
				}
			};
			#endregion

			#region Manager List
			gridManagers.Init();
			gridManagers.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "EmployeeID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EmployeeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridManagers.ColumnFix("RowNo");
			gridManagers.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					GridView view = sender as GridView;
					ShowManagerForm(view.GetRowCellValue(e.RowHandle, "ID"));
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
			ClearControlData<ChannelModel>();
			gridBrands.Clear<ChannelBrandModel>();
			gridCustomers.Clear<CustomerChannelModel>();
			gridContacts.Clear<ChannelContactModel>();
			gridManagers.Clear<ChannelManagerModel>();

			chkOrderDateYn.Checked = true;
			chkOrderAddYearYn.Checked = false;
			spnOrderNoDigit.EditValue = 0;
			chkOptionYn.Checked = true;
			txtOptionFormat.EditValue = null;
			spnOrderLine.EditValue = 2;
			spnAccountLine.EditValue = 2;

			lcTab.CustomHeaderButtons.OfType<CustomHeaderButton>().Where(x => x.Tag.ToStringNullToEmpty() == "ADD").ToList().ForEach(button =>
			{
				button.Enabled = false;
			});

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtChannelName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<ChannelModel>("Biz", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

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
					{ "ID", id },
					{ "ChannelID", id }
				};
				var model = WasHandler.GetData<ChannelModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				if (model.Brands == null)
					model.Brands = new List<ChannelBrandModel>();
				if (model.Customers == null)
					model.Customers = new List<CustomerChannelModel>();
				if (model.Contacts == null)
					model.Contacts = new List<ChannelContactModel>();
				if (model.Managers == null)
					model.Managers = new List<ChannelManagerModel>();
				if (model.Setting == null)
					model.Setting = new ChannelSettingModel();

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
				gridContacts.DataSource = model.Contacts;
				gridManagers.DataSource = model.Managers;

				lcTab.CustomHeaderButtons.OfType<CustomHeaderButton>().Where(x => x.Tag.ToStringNullToEmpty() == "ADD").ToList().ForEach(button =>
				{
					button.Enabled = true;
				});

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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteChannel", map, "ID"))
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

		private void ShowContactForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				using (ChannelContactEditForm form = new ChannelContactEditForm())
				{
					form.Text = "채널담당자등록";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = new DataMap()
					{
						{ "ChannelID", txtID.EditValue },
						{ "ChannelName", txtChannelName.EditValue },
						{ "ID", id }
					};

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

		private void ShowManagerForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				using (ChannelManagerEditForm form = new ChannelManagerEditForm())
				{
					form.Text = "채널매니저등록";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = new DataMap()
					{
						{ "ChannelID", txtID.EditValue },
						{ "ChannelName", txtChannelName.EditValue },
						{ "ID", id }
					};

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

		private void ShowChannelBrandForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				using (ChannelBrandEditForm form = new ChannelBrandEditForm())
				{
					form.Text = "브랜드 입점 등록";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = new DataMap()
					{
						{ "ChannelID", txtID.EditValue },
						{ "ChannelName", txtChannelName.EditValue },
						{ "ID", id }
					};

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

		private void ShowChannelCustomerForm(object id)
		{
			try
			{
				if (txtID.EditValue.IsNullOrEmpty())
					return;

				using (ChannelCustomerEditForm form = new ChannelCustomerEditForm())
				{
					form.Text = "거래처 등록";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = new DataMap()
					{
						{ "ChannelID", txtID.EditValue },
						{ "ChannelName", txtChannelName.EditValue },
						{ "ID", id }
					};

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