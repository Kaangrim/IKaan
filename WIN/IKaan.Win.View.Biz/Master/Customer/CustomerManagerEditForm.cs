﻿using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Customer;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Channel
{
	public partial class CustomerManagerEditForm : EditForm
	{
		public CustomerManagerEditForm()
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
			txtChannelID.SetEnable(false);

			txtEmployeeID.CodeGroup = "EmployeeList";
			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;

			txtChannelID.EditValue = (this.ParamsData as DataMap).GetValue("ChannelID");
			txtChannelID.EditText = (this.ParamsData as DataMap).GetValue("ChannelName");
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
				var parameter = new DataMap() { { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<CustomerManagerModel>("Biz", "GetData", "Select", parameter);
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
			ClearControlData<CustomerManagerModel>();
			
			txtChannelID.EditValue = (this.ParamsData as DataMap).GetValue("ChannelID");
			txtChannelID.EditText = (this.ParamsData as DataMap).GetValue("ChannelName");

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtEmployeeID.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CustomerManagerModel>();
				using (var res = WasHandler.Execute<CustomerManagerModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteChannelManager", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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