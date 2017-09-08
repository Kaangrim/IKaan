using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Brand
{
	public partial class BrandManagerEditForm : EditForm
	{
		public BrandManagerEditForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtEmployeeID.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemEmployee.Tag = true;
			lcItemStartDate.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			datEndDate.SetEnable(false);
			txtBrandID.SetEnable(false);

			txtEmployeeID.CodeGroup = "EmployeeList";
			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;

			txtBrandID.EditValue = (this.ParamsData as DataMap).GetValue("BrandID");
			txtBrandID.EditText = (this.ParamsData as DataMap).GetValue("BrandName");
		}
		protected override void DataLoad(object param = null)
		{
			if (param == null || param.GetType() != typeof(DataMap) || (param as DataMap).GetValue("ID").IsNullOrEmpty())
			{
				DataInit();
				return;
			}

			try
			{
				DataMap parameter = new DataMap() { { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<PartnerManagerModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				txtEmployeeID.EditValue = model.EmployeeID;
				txtEmployeeID.EditText = model.EmployeeName;

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtEmployeeID.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<PartnerManagerModel>();
			
			txtBrandID.EditValue = (this.ParamsData as DataMap).GetValue("BrandID");
			txtBrandID.EditText = (this.ParamsData as DataMap).GetValue("BrandName");

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtEmployeeID.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<PartnerManagerModel>();

				using (var res = WasHandler.Execute<PartnerManagerModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteBrandManager", map, "ID"))
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