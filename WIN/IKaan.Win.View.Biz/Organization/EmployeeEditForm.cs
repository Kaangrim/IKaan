﻿using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Organization;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Organization
{
	public partial class EmployeeEditForm : EditForm
	{
		private string loadUrl = string.Empty;

		public EmployeeEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += delegate (object sender, DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventArgs e)
			{
				if (e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupAppointment.Name)
					{
						ShowAppointmentForm(null);
					}
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

			lcItemEmployeeNo.Tag = true;
			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("EmployeeName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupEmployeeType.BindData("EmployeeType");
			lupFindDepartment.BindData("DepartmentList", "All");

			InitGrid();
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "EmployeeName", Width = 100 },
				new XGridColumn() { FieldName = "EmployeeNo", Width = 100 },
				new XGridColumn() { FieldName = "EmployeeTypeName", Width = 100 },
				new XGridColumn() { FieldName = "DepartmentName", Width = 150 },
				new XGridColumn() { FieldName = "Position", Width = 100 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
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

			#region Appointment List
			gridAppointment.Init();
			gridAppointment.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "EmployeeID", Visible = false },
				new XGridColumn() { FieldName = "DepartmentID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "DepartmentName", Width = 150 },
				new XGridColumn() { FieldName = "Position", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridAppointment.ColumnFix("RowNo");
			gridAppointment.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					GridView view = sender as GridView;
					ShowAppointmentForm(view.GetRowCellValue(e.RowHandle, "ID"));
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
			ClearControlData<EmployeeModel>();

			picImage.EditValue = null;
			loadUrl = string.Empty;

			gridAppointment.Clear<AppointmentModel>();

			lcTab.CustomHeaderButtons[0].Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtEmployeeNo.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<EmployeeModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "DepartmentID", lupFindDepartment.EditValue }
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
				var model = WasHandler.GetData<EmployeeModel>("Biz", "GetData", "Select", new DataMap() { { "ID", id } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.Image != null && model.Image.Url.IsNullOrEmpty() == false)
				{
					loadUrl = model.Image.Url;
					picImage.LoadAsync(GlobalVar.ImageServerInfo.CdnUrl + loadUrl);
				}

				txtEmail.EditValue = model.Email;
				txtPhoneNo.EditValue = model.PhoneNo;
				txtMobileNo.EditValue = model.MobileNo;
				txtFaxNo.EditValue = model.FaxNo;

				gridAppointment.DataSource = model.Appointments;

				lcTab.CustomHeaderButtons[0].Enabled = true;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtEmployeeNo.Focus();

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
				if (DataValidate() == false) return;

				var model = this.GetControlData<EmployeeModel>();
				model.Email = txtEmail.EditValue.ToStringNullToEmpty();

				using (var res = WasHandler.Execute<EmployeeModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				var map = new DataMap()
				{
					{ "ID", txtID.EditValue }
				};
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteEmployee", map, "ID"))
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

		private void DataDeleteAppointment()
		{
			try
			{
				if (gridAppointment.FocusedRowHandle < 0)
					throw new Exception("처리할 건이 없습니다.");

				object id = gridAppointment.GetValue(gridAppointment.FocusedRowHandle, "ID");
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteAppointment", new DataMap() { { "ID", id } }, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					DetailDataLoad(txtID.EditValue);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void ShowAppointmentForm(object id = null)
		{
			using (var form = new AppointmentEditForm())
			{
				form.Text = "발령등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = new DataMap()
				{
					{ "EmployeeID", txtID.EditValue },
					{ "ID", id }
				};

				if (form.ShowDialog() == DialogResult.OK)
				{
					DetailDataLoad(txtID.EditValue);
				}
			}
		}

		private void UploadImage()
		{
			try
			{
				string url = FTPHandler.UploadEmployee(null, picImage.GetLoadedImageLocation(), txtEmployeeNo.EditValue.ToString());
				var map = new DataMap()
				{
					{ "ID", txtID.EditValue },
					{ "ImageUrl", url }
				};

				using (var res = WasHandler.Execute<DataMap>("Biz", "SavePersonImageUrl", "UpdatePersonImageUrl", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("업로드하였습니다.");
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
				FTPHandler.DeleteFile(null, loadUrl);

				var map = new DataMap()
				{
					{ "ID", txtID.EditValue },
					{ "ImageUrl", null }
				};
				using (var res = WasHandler.Execute<DataMap>("Biz", "SavePersonImageUrl", "UpdatePersonImageUrl", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					picImage.EditValue = null;
					loadUrl = string.Empty;
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}