using System;
using System.Windows.Forms;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Company;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _AddressEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;
		private object _address_id = null;

		public _AddressEditForm()
		{
			InitializeComponent();

			txtPostalCode.ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
				{
					var data = SearchPostalCode.Find();
					if (data != null)
					{
						lupCountry.EditValue = "KOR";
						txtPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtAddressLine1.EditValue = data.Address1;
						txtAddressLine2.EditValue = data.Address2;

						if (data.Address1.IsNullOrEmpty() == false)
						{
							var address = data.Address1.Split(' ');
							if (address != null && address.Length > 0)
							{
								txtCity.EditValue = address[0].ToStringNullToEmpty();
								txtStateProvince.EditValue = address[1].ToStringNullToEmpty();
							}
						}
					}
				}
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtPostalCode.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemPostalCode.Tag = true;
			lcItemAddressLine1.Tag = true;

			SetFieldNames();

			lupCompanyID.SetEnable(false);

			lupAddressType.BindData("AddressType");
			lupCountry.BindData("Country");

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

		#region Data Access

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
				if (_type == "Company")
				{
					var model = WasHandler.GetData<CompanyAddressModel>("Biz", "GetData", "Select", parameter);
					SetControlData(model);
					lupCompanyID.EditValue = model.CompanyID;
					_id = model.ID;
					_address_id = model.AddressID;
				}
				else if (_type == "Customer")
				{
					var model = WasHandler.GetData<CustomerAddressModel>("Biz", "GetData", "Select", parameter);
					SetControlData(model);
					lupCompanyID.EditValue = model.CustomerID;
					_id = model.ID;
					_address_id = model.AddressID;
				}
				else if (_type == "Partner")
				{
					var model = WasHandler.GetData<PartnerAddressModel>("Biz", "GetData", "Select", parameter);
					SetControlData(model);
					lupCompanyID.EditValue = model.PartnerID;
					_id = model.ID;
					_address_id = model.AddressID;
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtPostalCode.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<AddressModel>();
			if (_type == "Company")
				ClearControlData<CompanyAddressModel>();
			else if (_type == "Customer")
				ClearControlData<CustomerAddressModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerAddressModel>();
			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			_id = null;
			_address_id = null;

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtPostalCode.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				object id = null;
				if (_type == "Company")
				{
					var model = this.GetControlData<CompanyAddressModel>();
					model.ID = _id.ToIntegerNullToNull();
					model.AddressID = _address_id.ToIntegerNullToNull();
					model.CompanyID = lupCompanyID.EditValue.ToIntegerNullToNull();

					using (var res = WasHandler.Execute<CompanyAddressModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Customer")
				{
					var model = this.GetControlData<CustomerAddressModel>();
					model.ID = _id.ToIntegerNullToNull();
					model.AddressID = _address_id.ToIntegerNullToNull();
					model.CustomerID = lupCompanyID.EditValue.ToIntegerNullToNull();

					using (var res = WasHandler.Execute<CustomerAddressModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Partner")
				{
					var model = this.GetControlData<PartnerAddressModel>();
					model.ID = _id.ToIntegerNullToNull();
					model.AddressID = _address_id.ToIntegerNullToNull();
					model.PartnerID = lupCompanyID.EditValue.ToIntegerNullToNull();

					using (var res = WasHandler.Execute<PartnerAddressModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", string.Format("Delete{0}Address", _type), new DataMap() { { "ID", _id } }))
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

		#endregion
	}
}