using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Organization
{
	public partial class DepartmentEditForm : EditForm
	{
		public DepartmentEditForm()
		{
			InitializeComponent();
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

			lcItemDepartmentName.Tag = true;
			lcItemStartDate.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lupFindDepartment.BindData("DepartmentList", "All");
			lupParentID.BindData("DepartmentList", "Root");
			txtManagerID.CodeGroup = "EmployeeList";

			datStartDate.Init(CalendarViewType.DayView);

			InitGrid();
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "DepartmentName", Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "DepartmentName", Width = 200 },
				new XGridColumn() { FieldName = "ManagerName", Width = 100, HorzAlignment = HorzAlignment.Center },
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

			#region History
			gridHistory.Init();
			gridHistory.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "DepartmentID", Visible = false },
				new XGridColumn() { FieldName = "DepartmentName", Width = 150 },
				new XGridColumn() { FieldName = "ParentID", Visible = false },
				new XGridColumn() { FieldName = "ManagerID", Visible = false },
				new XGridColumn() { FieldName = "ManagerName", Width = 100 },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridHistory.ColumnFix("RowNo");
			#endregion

			#region Appointment
			gridAppointment.Init();
			gridAppointment.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "DepartmentID", Visible = false },
				new XGridColumn() { FieldName = "EmployeeID", Visible = false },
				new XGridColumn() { FieldName = "EmployeeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridAppointment.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<DepartmentModel>();
			txtManagerID.Clear();

			gridHistory.Clear<DepartmentHistModel>();
			gridAppointment.Clear<AppointmentModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtDepartmentName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<DepartmentModel>("Biz", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var model = WasHandler.GetData<DepartmentModel>("Biz", "GetData", "Select", new DataMap()
				{
					{ "ID", id },
					{ "DepartmentID", id }
				});
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				txtManagerID.EditValue = model.ManagerID;
				txtManagerID.EditText = model.ManagerName;

				if (model != null)
				{
					gridHistory.DataSource = model.History;
					gridAppointment.DataSource = model.Appointments;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtDepartmentName.Focus();

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
				var model = this.GetControlData<DepartmentModel>();
				model.ManagerID = txtManagerID.EditValue.ToIntegerNullToNull();

				using (var res = WasHandler.Execute<DepartmentModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteDepartment", map, "ID"))
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