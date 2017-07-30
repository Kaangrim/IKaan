using System;
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
using IKaan.Model.BIZ.BC;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BC
{
	public partial class BCEmployeeForm : EditForm
	{
		public BCEmployeeForm()
		{
			InitializeComponent();

			btnAddLine.Click += delegate (object sender, EventArgs e)
			{
				ShowAppointmentForm(null);
			};
			btnDelLine.Click += delegate (object sender, EventArgs e)
			{
				int rowIndex = gridAppointment.FocusedRowHandle;
				if (rowIndex < 0)
					return;

				if (gridAppointment.GetValue(rowIndex, "ID") == null)
					gridAppointment.MainView.DeleteRow(rowIndex);
				else
					DataDeleteAppointment();
			};
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

			lcItemEmployeeNo.Tag = true;
			lcItemEmployeeName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);
			txtPersonID.SetEnable(false);
			txtImageUrl.SetEnable(false);

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
				new XGridColumn() { FieldName = "EmployeeName", Width = 100 },
				new XGridColumn() { FieldName = "EmployeeNo", Width = 100 },
				new XGridColumn() { FieldName = "DepartmentName", Width = 150 },
				new XGridColumn() { FieldName = "Position", Width = 100 },
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
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
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
			ClearControlData<BCEmployee>();

			txtEngName.Clear();
			txtEmail.Clear();
			txtPhoneNo1.Clear();
			txtPhoneNo2.Clear();
			txtFaxNo.Clear();
			picImage.EditValue = null;
			txtImageUrl.Clear();

			gridAppointment.Clear<BCAppointment>();

			btnAddLine.Enabled =
				btnDelLine.Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtEmployeeNo.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BCEmployee>("BC", "GetList", "Select", new DataMap()
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
				var model = WasHandler.GetData<BCEmployee>("BC", "GetData", "Select", new DataMap() { { "ID", id } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model.Person == null)
					model.Person = new BMPerson();

				picImage.LoadAsync(ConstsVar.IMG_URL + model.Person.ImageUrl);
				txtImageUrl.EditValue = model.Person.ImageUrl;
				txtEngName.EditValue = model.Person.EngName;
				txtEmail.EditValue = model.Person.Email;
				txtPhoneNo1.EditValue = model.Person.PhoneNo1;
				txtPhoneNo2.EditValue = model.Person.PhoneNo2;
				txtFaxNo.EditValue = model.Person.FaxNo;

				gridAppointment.DataSource = model.Appointments;

				btnAddLine.Enabled = true;
				btnDelLine.Enabled = true;

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

				var model = this.GetControlData<BCEmployee>();
				model.Person = new BMPerson()
				{
					PersonType = "",
					PersonName = txtEmployeeName.EditValue.ToString(),
					EngName = txtEngName.EditValue.ToStringNullToEmpty(),
					Email = txtEmail.EditValue.ToStringNullToEmpty(),
					PhoneNo1 = txtPhoneNo1.EditValue.ToStringNullToEmpty(),
					PhoneNo2 = txtPhoneNo2.EditValue.ToStringNullToEmpty(),
					FaxNo = txtFaxNo.EditValue.ToStringNullToEmpty(),
					ImageUrl = txtImageUrl.EditValue.ToStringNullToEmpty()
				};

				using (var res = WasHandler.Execute<BCEmployee>("BC", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				DataMap map = new DataMap()
				{
					{ "ID", txtID.EditValue },
					{ "PersonID", txtPersonID.EditValue }
				};
				using (var res = WasHandler.Execute<DataMap>("BC", "Delete", "DeleteBCEmployee", map, "ID"))
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
				DataMap map = new DataMap()
				{
					{ "ID", id }
				};
				using (var res = WasHandler.Execute<DataMap>("BC", "Delete", "DeleteBCAppointment", map, "ID"))
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
			using (BCAppointmentForm form = new BCAppointmentForm())
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
	}
}