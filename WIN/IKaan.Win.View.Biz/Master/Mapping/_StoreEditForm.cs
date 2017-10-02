using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Company;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _StoreEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;

		public _StoreEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupStoreID.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemStore.Tag = true;
			lcItemStartDate.Tag = true;

			SetFieldNames();

			lupCompanyID.SetEnable(false);
			datEndDate.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;

			lupStoreID.BindData("StoreList");

			_type = (this.ParamsData as DataMap).GetValue("MappingType").ToStringNullToEmpty();
			if (_type.IsNullOrEmpty())
			{
				ShowMsgBox("매핑유형을 알 수 없습니다.");
				Close();
				return;
			}

			lcItemCompany.SetFieldName(_type);
			lupCompanyID.BindData(string.Format("{0}List", _type));
			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();
		}

		protected override void DataInit()
		{
			if (_type == "Company")
				ClearControlData<CompanyStoreModel>();
			else if (_type == "Customer")
				ClearControlData<CustomerStoreModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerStoreModel>();

			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			_id = null;

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			lupStoreID.Focus();
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

				if (_type == "Company")
				{
					var model = WasHandler.GetData<CompanyStoreModel>("Biz", "GetData", "Select", parameter);
					SetControlData(model);
					_id = model.ID;
				}
				else if (_type == "Customer")
				{
					var model = WasHandler.GetData<CustomerStoreModel>("Biz", "GetData", "Select", parameter);
					SetControlData(model);
					_id = model.ID;
				}
				else if (_type == "Partner")
				{
					var model = WasHandler.GetData<PartnerStoreModel>("Biz", "GetData", "Select", parameter);
					SetControlData(model);
					_id = model.ID;
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				lupStoreID.Focus();
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
				object id = null;

				if (_type == "Company")
				{
					var model = this.GetControlData<CompanyStoreModel>();
					model.ID = _id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CompanyStoreModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Customer")
				{
					var model = this.GetControlData<CustomerStoreModel>();
					model.ID = _id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CustomerStoreModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Partner")
				{
					var model = this.GetControlData<PartnerStoreModel>();
					model.ID = _id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<PartnerStoreModel>("Biz", "Save", "Insert", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", string.Format("Delete{0}Business", _type), new DataMap() { { "ID", _id } }))
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