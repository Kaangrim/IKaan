using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Channel
{
	public partial class ChannelCustomerEditForm : EditForm
	{
		public ChannelCustomerEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datStartDate.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemStartDate.Tag = true;
			lcItemCustomer.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtChannelID.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);
			txtCustomerID.CodeGroup = "CustomerList";

			if (this.ParamsData != null && this.ParamsData.GetType() == typeof(DataMap))
			{
				txtChannelID.EditValue = (this.ParamsData as DataMap).GetValue("ChannelID");
				txtChannelID.EditText = (this.ParamsData as DataMap).GetValue("ChannelName");
			}
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
				DataMap parameter = new DataMap(){ { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<CustomerChannelModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				//txtCustomerID.EditText = model.CustmerName;

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				datStartDate.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<CustomerChannelModel>();

			if (this.ParamsData != null && this.ParamsData.GetType() == typeof(DataMap))
			{
				txtChannelID.EditValue = (this.ParamsData as DataMap).GetValue("ChannelID");
				txtChannelID.EditText = (this.ParamsData as DataMap).GetValue("ChannelName");
			}

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			datStartDate.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CustomerChannelModel>();

				using (var res = WasHandler.Execute<CustomerChannelModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCustomerChannel", map, "ID"))
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