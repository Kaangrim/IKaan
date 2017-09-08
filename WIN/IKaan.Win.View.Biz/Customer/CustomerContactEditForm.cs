using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Customer
{
	public partial class CustomerContactEditForm : EditForm
	{
		public CustomerContactEditForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtPersonName.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemChannel.Tag = true;
			lcItemPersonName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtPersonID.SetEnable(false);
			txtChannelID.SetEnable(false);

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
				DataMap parameter = new DataMap() { { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<CustomerContactModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtPersonName.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<CustomerContactModel>();
			txtChannelID.EditValue = (this.ParamsData as DataMap).GetValue("ChannelID");
			txtChannelID.EditText = (this.ParamsData as DataMap).GetValue("ChannelName");

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtPersonName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CustomerContactModel>();

				using (var res = WasHandler.Execute<CustomerContactModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteChannelContact", map, "ID"))
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