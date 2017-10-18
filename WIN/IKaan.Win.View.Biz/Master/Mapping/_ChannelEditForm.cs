using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _ChannelEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;

		public _ChannelEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupChannelID.Focus();
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
			lcItemChannel.Tag = true;

			SetFieldNames();

			lupCustomerID.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;

			lupChannelID.BindData("ChannelList");

			_type = (this.ParamsData as DataMap).GetValue("MappingType").ToStringNullToEmpty();
			if (_type.IsNullOrEmpty())
			{
				ShowMsgBox("매핑유형을 알 수 없습니다.");
				Close();
				return;
			}

			lcItemCustomer.SetFieldName(_type);
			lupCustomerID.BindData(string.Format("{0}List", _type));
			lupCustomerID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			if (_type.ToUpper() == "CHANNEL")
			{
				lcItemChannel.SetFieldName("Customer");
				lupChannelID.BindData(string.Format("{0}List", "Customer"));
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
				var parameter = new DataMap(){ { "ID", (param as DataMap).GetValue("ID") } };
				if (_type.ToUpper() == "CUSTOMER")
				{
					var model = WasHandler.GetData<CustomerChannelModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCustomerID.EditValue = model.CustomerID.ToStringNullToEmpty();
						_id = model.ID;
					}
				}
				else if (_type == "PARTNER")
				{
					var model = WasHandler.GetData<PartnerChannelModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCustomerID.EditValue = model.PartnerID.ToStringNullToEmpty();
						_id = model.ID;
					}
				}
				else if (_type == "CHANNEL")
				{
					var model = WasHandler.GetData<CustomerChannelModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCustomerID.EditValue = model.ChannelID.ToStringNullToEmpty();
						lupChannelID.EditValue = model.CustomerID.ToStringNullToEmpty();
						_id = model.ID;
					}
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				lupChannelID.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			if (_type == "Customer" || _type == "Channel")
				ClearControlData<CustomerChannelModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerChannelModel>();

			lupCustomerID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			lupChannelID.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				object id = null;
				if (_type == "Customer")
				{
					var model = this.GetControlData<CustomerChannelModel>();
					model.CustomerID = lupCustomerID.EditValue.ToIntegerNullToNull();
					model.ID = _id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CustomerChannelModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Partner")
				{
					var model = this.GetControlData<PartnerChannelModel>();
					model.PartnerID = lupCustomerID.EditValue.ToIntegerNullToNull();
					model.ID = _id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<PartnerChannelModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Channel")
				{
					var model = this.GetControlData<CustomerChannelModel>();
					model.ChannelID = lupCustomerID.EditValue.ToIntegerNullToNull();
					model.CustomerID = lupChannelID.EditValue.ToIntegerNullToNull();
					model.ID = _id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CustomerChannelModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				(this.ParamsData as DataMap).SetValue("ID", id);
				ShowMsgBox("저장하였습니다.");
				callback(arg, this.ParamsData);
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
				string sqlId = string.Format("Delete{0}Channel", _type);
				if (_type == "Channel")
					sqlId = "DeleteCustomerChannel";

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", sqlId, new DataMap() { { "ID", _id } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				(this.ParamsData as DataMap).SetValue("ID", null);
				ShowMsgBox("삭제하였습니다.");
				callback(arg, this.ParamsData);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}