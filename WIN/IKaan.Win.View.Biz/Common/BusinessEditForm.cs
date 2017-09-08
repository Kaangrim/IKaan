using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Common
{
	public partial class BusinessEditForm : EditForm
	{
		private string loadUrl = string.Empty;

		public BusinessEditForm()
		{
			InitializeComponent();

			txtPostalCode.ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if(e.Button.Kind== ButtonPredefines.Ellipsis)
				{
					PostalCode data = SearchPostCode.Find();
					if (data != null)
					{
						if (data.PostalNo.IsNullOrEmpty())
							txtPostalCode.EditValue = data.ZoneCode;
						else
							txtPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtAddressLine1.EditValue = data.Address1;
						txtAddressLine2.EditValue = data.Address2;
					}
				}
			};

			picImage.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
				{
					txtImageUrl.EditValue = picImage.GetLoadedImageLocation();
				}
			};
			picImage.LoadCompleted += delegate (object sender, EventArgs e)
			{
				txtImageUrl.EditValue = loadUrl;
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

			SetFieldNames();

			

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			txtAddressID.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupFindBizType.BindData("BizType", "All");
			lupFindStatus.BindData("Yn", "All");
			lupBizType.BindData("BizType");
			lupCountry.BindData("Country");
			lupStatus.BindData("BizStatus");			
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizNo", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizName", Width = 150 },
				new XGridColumn() { FieldName = "RepName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BizKind", Width = 100 },
				new XGridColumn() { FieldName = "BizItem", Width = 100 },
				new XGridColumn() { FieldName = "StatusName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
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

			#region Customer List
			gridCustomers.Init();
			gridCustomers.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BusinessID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },				
				new XGridColumn() { FieldName = "CustomerName", Width = 150 },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridCustomers.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<BusinessModel>();
			gridCustomers.Clear<CustomerBusinessModel>();

			txtAddressID.Clear();
			txtPostalCode.Clear();
			txtCity.Clear();
			txtStateProvince.Clear();
			txtAddressLine1.Clear();
			txtAddressLine2.Clear();

			loadUrl = string.Empty;
			picImage.EditValue = null;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtBizNo.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BusinessModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "Status", lupFindStatus.EditValue },
				{ "BizType", lupFindBizType.EditValue }
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
				var model = WasHandler.GetData<BusinessModel>("Biz", "GetData", "Select", new DataMap() { { "ID", id } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model.Address != null)
				{
					txtPostalCode.EditValue = model.Address.PostalCode;
					txtAddressLine1.EditValue = model.Address.AddressLine1;
					txtAddressLine2.EditValue = model.Address.AddressLine2;
					lupCountry.EditValue = model.Address.Country;
					txtCity.EditValue = model.Address.City;
					txtStateProvince.EditValue = model.Address.StateProvince;
				}

				if (model.Links == null)
					model.Links = new List<BusinessLinksModel>();
				gridCustomers.DataSource = model.Links;

				loadUrl = model.Image.Url;
				if (loadUrl.IsNullOrEmpty())
				{
					picImage.EditValue = null;
					txtImageUrl.EditValue = null;
				}
				else
				{
					picImage.LoadAsync(ConstsVar.IMG_URL + loadUrl);
					txtImageUrl.EditValue = loadUrl;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBizNo.Focus();

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
				var model = this.GetControlData<BusinessModel>();
				model.Address = new AddressModel()
				{
					ID = model.AddressID,
					PostalCode = txtPostalCode.EditValue.ToStringNullToNull(),
					City = txtCity.EditValue.ToStringNullToNull(),
					StateProvince = txtStateProvince.EditValue.ToStringNullToNull(),
					Country = lupCountry.EditValue.ToStringNullToNull(),
					AddressLine1 = txtAddressLine1.EditValue.ToStringNullToNull(),
					AddressLine2 = txtAddressLine2.EditValue.ToStringNullToNull()
				};

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					string path = picImage.GetLoadedImageLocation();
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(txtImageUrl.EditValue.ToString(), txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Image.Url = url;
					}
				}
				else
				{
					if (loadUrl.IsNullOrEmpty() == false)
					{
						FTPHandler.DeleteFile(loadUrl);
						loadUrl = string.Empty;
					}
				}

				using (var res = WasHandler.Execute<BusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				if (txtImageUrl.EditValue.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(txtImageUrl.EditValue.ToString());
					loadUrl = string.Empty;
				}

				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteBusiness", map, "ID"))
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