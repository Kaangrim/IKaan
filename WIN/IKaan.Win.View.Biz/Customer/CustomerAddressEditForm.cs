using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Customer
{
	public partial class CustomerAddressEditForm : EditForm
	{
		public CustomerAddressEditForm()
		{
			InitializeComponent();

			txtPostalCode.ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
				{
					var data = SearchPostCode.Find();
					if (data != null)
					{
						txtPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtAddressLine1.EditValue = data.Address1;
						txtAddressLine2.EditValue = data.Address2;
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

			txtID.SetEnable(false);
			txtCustomerID.SetEnable(false);
			txtAddressID.SetEnable(false);

			lupAddressType.BindData("AddressType");
			lupCountry.BindData("Country");

			txtCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID");
			txtCustomerID.EditText = (this.ParamsData as DataMap).GetValue("CustomerName");
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
				var model = WasHandler.GetData<CustomerAddressModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

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
			ClearControlData<CustomerAddressModel>();
			txtCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID");
			txtCustomerID.EditText = (this.ParamsData as DataMap).GetValue("CustomerName");

			txtAddressID.Clear();
			txtPostalCode.Clear();
			txtAddressLine1.Clear();
			txtAddressLine2.Clear();
			lupCountry.Clear();
			txtCity.Clear();
			txtStateProvince.Clear();

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtPostalCode.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CustomerAddressModel>();
				
				using (var res = WasHandler.Execute<CustomerAddressModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCustomerAddress", map, "ID"))
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