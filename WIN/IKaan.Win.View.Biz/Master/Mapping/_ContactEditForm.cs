using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
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
	public partial class _ContactEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;
		private object _contact_id = null;

		public _ContactEditForm()
		{
			InitializeComponent();
		}
		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtName.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemCompany.Tag = true;
			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("ContactName");

			lupCompanyID.SetEnable(false);

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
				var contact = new ContactModel();

				if (_type == "Company")
				{
					var model = WasHandler.GetData<CompanyContactModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCompanyID.EditValue = model.CompanyID.ToStringNullToEmpty();
						contact = model.Contact;
						_id = model.ID;
						_contact_id = model.ContactID;
					}
				}
				else if (_type == "Customer")
				{
					var model = WasHandler.GetData<CustomerContactModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCompanyID.EditValue = model.CustomerID.ToStringNullToEmpty();
						contact = model.Contact;
						_id = model.ID;
						_contact_id = model.ContactID;
					}
				}
				else if (_type == "Partner")
				{
					var model = WasHandler.GetData<PartnerContactModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCompanyID.EditValue = model.PartnerID.ToStringNullToEmpty();
						contact = model.Contact;
						_id = model.ID;
						_contact_id = model.ContactID;
					}
				}

				if (contact != null)
				{
					txtName.EditValue = contact.Name;
					txtEmail.EditValue = contact.Email;
					txtPhoneNo.EditValue = contact.PhoneNo;
					txtMobileNo.EditValue = contact.MobileNo;
					txtFaxNo.EditValue = contact.FaxNo;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtName.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<ContactModel>();
			if (_type == "Company")
				ClearControlData<CompanyContactModel>();
			else if (_type == "Customer")
				ClearControlData<CustomerContactModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerContactModel>();

			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type));

			_id = null;
			_contact_id = null;

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				object id = null;
				var contact = new ContactModel()
				{
					ID = _contact_id.ToIntegerNullToNull(),
					Name = txtName.EditValue.ToStringNullToEmpty(),
					ContactType = "0",
					Email = txtEmail.EditValue.ToStringNullToEmpty(),
					PhoneNo = txtPhoneNo.EditValue.ToStringNullToEmpty(),
					MobileNo = txtMobileNo.EditValue.ToStringNullToEmpty(),
					FaxNo = txtFaxNo.EditValue.ToStringNullToEmpty()
				};

				if (_type == "Company")
				{
					var model = this.GetControlData<CompanyContactModel>();
					model.Contact = contact;
					model.ID = _id.ToIntegerNullToNull();
					model.CompanyID = lupCompanyID.EditValue.ToIntegerNullToNull();
					model.ContactID = _contact_id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CompanyContactModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Customer")
				{
					var model = this.GetControlData<CustomerContactModel>();
					model.Contact = contact;
					model.ID = _id.ToIntegerNullToNull();
					model.CustomerID = lupCompanyID.EditValue.ToIntegerNullToNull();
					model.ContactID = _contact_id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<CustomerContactModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Partner")
				{
					var model = this.GetControlData<PartnerContactModel>();
					model.Contact = contact;
					model.ID = _id.ToIntegerNullToNull();
					model.PartnerID = lupCompanyID.EditValue.ToIntegerNullToNull();
					model.ContactID = _contact_id.ToIntegerNullToNull();
					using (var res = WasHandler.Execute<PartnerContactModel>("Biz", "Save", "Insert", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", string.Format("Delete{0}Contact", _type), new DataMap() { { "ID", _id } }))
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