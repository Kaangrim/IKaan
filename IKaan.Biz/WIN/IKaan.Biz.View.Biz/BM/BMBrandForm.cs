using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Variables;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BM
{
	public partial class BMBrandForm : EditForm
	{
		public BMBrandForm()
		{
			InitializeComponent();

			btnAddImage.Click += delegate (object sender, EventArgs e) { AddImage(); };
			btnDeleteImage.Click += delegate (object sender, EventArgs e) { DeleteImage(); };

			btnAddContact.Click += delegate (object sender, EventArgs e) { ShowContactForm(null); };
			btnAddManager.Click += delegate (object sender, EventArgs e) { ShowManagerForm(null); };
			btnAddChannel.Click += delegate (object sender, EventArgs e) { ShowChannelForm(null); };
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

			lcItemBrandName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lupFindBrandCategory.BindData("BrandCategory", "All");
			lupFindBrandStyle.BindData("BrandStyle", "All");
			lupFindUseYn.BindData("Yn", "All");
			lupFindUseYn.EditValue = "Y";
			lupBrandCategory.BindData("BrandCategory");
			lupBrandStyle.BindData("BrandStyle");

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
				new XGridColumn() { FieldName = "BrandName", Width = 200 },
				new XGridColumn() { FieldName = "BrandCategoryName", Width = 100 },
				new XGridColumn() { FieldName = "BrandStyleName", Width = 100 },
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

			#region Image List
			gridImages.Init();
			gridImages.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "ImageType", Width = 100 },
				new XGridColumn() { FieldName = "ImageUrl", Width = 300 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridImages.SetRepositoryItemLookUpEdit("ImageType");
			gridImages.SetRepositoryItemButtonEdit("ImageUrl");
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
						AddImage(new DataMap()
						{
							{ "ID", view.GetRowCellValue(e.RowHandle, "ID") },
							{ "BrandID", view.GetRowCellValue(e.RowHandle, "BrandID") },
							{ "ImageType", view.GetRowCellValue(e.RowHandle, "ImageType") },
							{ "ImageUrl", view.GetRowCellValue(e.RowHandle, "ImageUrl") }
						});
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Customer List
			gridCustomers.Init();
			gridCustomers.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "PersonName", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridCustomers.ColumnFix("RowNo");
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
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridChannels.ColumnFix("RowNo");
			#endregion

			#region Contact List
			gridContacts.Init();
			gridContacts.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "PersonName", CaptionCode = "ContactName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Position", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Email", Width = 150 },
				new XGridColumn() { FieldName = "PhoneNo1", Width = 100 },
				new XGridColumn() { FieldName = "PhoneNo2", Width = 100 },
				new XGridColumn() { FieldName = "FaxNo", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
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
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "EmployeeID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EmployeeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
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
			//gridManagers.SetEditable("EmployeeName", "StartDate");
			//gridManagers.SetRepositoryItemButtonEdit("EmployeeName");
			//(gridManagers.MainView.Columns["EmployeeName"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			//{
			//	if(e.Button.Kind== DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
			//	{
			//		DataMap data = CodeHelper.ShowForm("EmployeeList", null, null);
			//		if (data != null)
			//		{
			//			gridManagers.SetValue(gridManagers.FocusedRowHandle, "EmployeeID", data.GetValue("Code"));
			//			gridManagers.SetValue(gridManagers.FocusedRowHandle, "EmployeeName", data.GetValue("Name"));
			//		}
			//	}
			//};
			//(gridManagers.MainView.Columns["EmployeeName"].ColumnEdit as RepositoryItemButtonEdit).KeyDown += delegate (object sender, KeyEventArgs e)
			//{
			//	if(e.KeyCode== Keys.Enter)
			//	{
			//		object findtext = gridManagers.GetValue(gridManagers.FocusedRowHandle, "EmployeeName");
			//		DataMap data = CodeHelper.ShowForm("EmployeeList", new DataMap() { { "FindText", findtext } }, null);
			//		if (data != null)
			//		{
			//			gridManagers.SetValue(gridManagers.FocusedRowHandle, "EmployeeID", data.GetValue("Code"));
			//			gridManagers.SetValue(gridManagers.FocusedRowHandle, "EmployeeName", data.GetValue("Name"));
			//		}
			//	}
			//	else if(e.KeyCode== Keys.Delete)
			//	{
			//		object findtext = gridManagers.GetValue(gridManagers.FocusedRowHandle, "EmployeeName");
			//		if (findtext.IsNullOrEmpty())
			//			gridManagers.SetValue(gridManagers.FocusedRowHandle, "EmployeeID", null);
			//	}
			//};
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<BMBrand>();
			picBrandLogo.EditValue = null;
			gridImages.Clear<BMBrandImage>();
			gridCustomers.Clear<BMCustomerBrand>();
			gridChannels.Clear<BMChannelBrand>();
			gridContacts.Clear<BMBrandContact>();
			gridManagers.Clear<BMBrandManager>();

			btnAddImage.Enabled = 
				btnDeleteImage.Enabled =
				btnAddContact.Enabled =
				btnAddManager.Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtBrandName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BMBrand>("BM", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "UseYn", lupFindUseYn.EditValue }
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
					{ "ID", id },
					{ "BrandID", id }
				};
				var model = WasHandler.GetData<BMBrand>("BM", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				if (model.Images == null)
					model.Images = new List<BMBrandImage>();
				if (model.Customers == null)
					model.Customers = new List<BMCustomerBrand>();
				if (model.Channels == null)
					model.Channels = new List<BMChannelBrand>();
				if (model.Contacts == null)
					model.Contacts = new List<BMBrandContact>();
				if (model.Managers == null)
					model.Managers = new List<BMBrandManager>();

				SetControlData(model);
				picBrandLogo.LoadAsync(ConstsVar.IMG_URL + model.ImageUrl);

				gridImages.DataSource = model.Images;
				gridCustomers.DataSource = model.Customers;
				gridChannels.DataSource = model.Channels;
				gridContacts.DataSource = model.Contacts;
				gridManagers.DataSource = model.Managers;

				btnAddImage.Enabled =
					btnAddContact.Enabled =
					btnAddManager.Enabled = true;

				btnDeleteImage.Enabled = (gridImages.RowCount > 0) ? true : false;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBrandName.Focus();

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
				var model = this.GetControlData<BMBrand>();

				using (var res = WasHandler.Execute<BMBrand>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("BM", "Delete", "DeleteBMBrand", map, "ID"))
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

		private void AddImage(DataMap parameter = null)
		{
			try
			{
				if (parameter == null)
				{
					parameter = new DataMap()
					{
						{ "ID", null },
						{ "BrandID", txtID.EditValue },
						{ "ImageType", null },
						{ "ImageUrl", null }
					};
				}
				using (BMBrandImageForm form = new BMBrandImageForm()
				{
					Text = "브랜드이미지",
					StartPosition = FormStartPosition.CenterScreen,
					ParamsData = parameter,
					IsLoadingRefresh = true
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

		private void DeleteImage()
		{
			try
			{
				if (gridImages.FocusedRowHandle < 0)
					return;

				DataMap map = new DataMap() { { "ID", gridImages.GetValue(gridImages.FocusedRowHandle, "ID") } };
				using (var res = WasHandler.Execute<DataMap>("LM", "Delete", "DeleteBMBrandImage", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					DetailDataLoad(txtID.EditValue);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void ShowContactForm(object id)
		{
			if (txtID.EditValue.IsNullOrEmpty())
				return;

			using(BMBrandContactForm form = new BMBrandContactForm())
			{
				form.Text = "브랜드담당자등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = new DataMap()
				{
					{ "BrandID", txtID.EditValue },
					{ "BrandName", txtBrandName.EditValue },
					{ "ID", id }
				};

				if (form.ShowDialog() == DialogResult.OK)
				{
					DetailDataLoad(txtID.EditValue);
				}
			}
		}

		private void ShowManagerForm(object id)
		{
			if (txtID.EditValue.IsNullOrEmpty())
				return;

			using (BMBrandManagerForm form = new BMBrandManagerForm())
			{
				form.Text = "브랜드매니저등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = new DataMap()
				{
					{ "BrandID", txtID.EditValue },
					{ "BrandName", txtBrandName.EditValue },
					{ "ID", id }
				};

				if (form.ShowDialog() == DialogResult.OK)
				{
					DetailDataLoad(txtID.EditValue);
				}
			}
		}

		private void ShowChannelForm(object id)
		{
			if (txtID.EditValue.IsNullOrEmpty())
				return;

			using (BMBrandChannelForm form = new BMBrandChannelForm())
			{
				form.Text = "채널등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = new DataMap()
				{
					{ "BrandID", txtID.EditValue },
					{ "BrandName", txtBrandName.EditValue },
					{ "ID", id }
				};

				if (form.ShowDialog() == DialogResult.OK)
				{
					DetailDataLoad(txtID.EditValue);
				}
			}
		}
	}
}