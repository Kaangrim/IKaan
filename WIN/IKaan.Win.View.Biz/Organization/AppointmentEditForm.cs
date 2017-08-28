using System;
using IKaan.Base.Map;
using IKaan.Model.Biz;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Organization
{
	public partial class AppointmentEditForm : EditForm
	{
		public AppointmentEditForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupDepartmentID.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemEmployee.Tag = true;
			lcItemDepartment.Tag = true;
			lcItemStartDate.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			datStartDate.Init(CalendarViewType.DayView);
			lupEmployeeID.SetEnable(false);
			lupEmployeeID.BindData("EmployeeList");
			lupDepartmentID.BindData("DepartmentList");
		}
		protected override void DataInit()
		{
			ClearControlData<AppointmentModel>();
			lupEmployeeID.EditValue = (this.ParamsData as DataMap).GetValue("EmployeeID").ToString();

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			lupDepartmentID.Focus();
		}
		protected override void DataLoad(object param = null)
		{
			if (param == null || param.GetType() != typeof(DataMap) || (param as DataMap).GetValue("ID") == null)
			{
				DataInit();
				return;
			}

			try
			{
				var model = WasHandler.GetData<AppointmentModel>("Biz", "GetData", "Select", new DataMap() { { "ID", (param as DataMap).GetValue("ID") } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				lupDepartmentID.Focus();

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
				if (DataValidate() == false) return;

				var model = this.GetControlData<AppointmentModel>();

				using (var res = WasHandler.Execute<AppointmentModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					(this.ParamsData as DataMap).SetValue("ID", res.Result.ReturnValue);
					callback(arg, this.ParamsData);
				}
			}
			catch (Exception ex)
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
					{ "ID", txtID.EditValue }
				};
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteAppointment", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					(this.ParamsData as DataMap).SetValue("ID", null);
					callback(arg, this.ParamsData);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}