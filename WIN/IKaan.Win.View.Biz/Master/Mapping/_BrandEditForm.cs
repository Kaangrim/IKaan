﻿using System;
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
	public partial class _BrandEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;

		public _BrandEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupBrandID.Focus();
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
			lcItemBrand.Tag = true;

			SetFieldNames();

			lupCustomerID.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;

			lupBrandID.BindData("BrandList");

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
				if (_type == "Customer")
				{
					var model = WasHandler.GetData<CustomerBrandModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCustomerID.EditValue = model.CustomerID.ToStringNullToEmpty();
						_id = model.ID;
					}
				}
				else if (_type == "Partner")
				{
					var model = WasHandler.GetData<PartnerBrandModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCustomerID.EditValue = model.PartnerID.ToStringNullToEmpty();
						_id = model.ID;
					}
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				lupBrandID.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			if (_type == "Customer")
				ClearControlData<CustomerBrandModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerBrandModel>();

			lupCustomerID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			datStartDate.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				object id = null;
				if (_type == "Customer")
				{
					var model = this.GetControlData<CustomerBrandModel>();
					model.CustomerID = lupCustomerID.EditValue.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CustomerBrandModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Partner")
				{
					var model = this.GetControlData<PartnerBrandModel>();
					model.PartnerID = lupCustomerID.EditValue.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<PartnerBrandModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				ShowMsgBox("저장하였습니다.");
				(this.ParamsData as DataMap).SetValue("ID", id);
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", string.Format("Delete{0}Brand", _type), new DataMap() { { "ID", _id } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				ShowMsgBox("삭제하였습니다.");
				(this.ParamsData as DataMap).SetValue("ID", null);
				callback(arg, this.ParamsData);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}