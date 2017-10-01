using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Company;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Company
{
	public partial class CompanyAddressEditForm : EditForm
	{
		public CompanyAddressEditForm()
		{
			InitializeComponent();

			txtPostalCode.ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			{
				if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
				{
					if (lupCountry.EditValue.IsNullOrEmpty())
					{
						ShowMsgBox("국가를 선택하세요!!!");
						lupCountry.Focus();
						return;
					}

					if (lupCountry.EditValue.ToString() == "KOR")
					{
						var data = SearchPostalCode.Find();
						if (data != null)
						{
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
			txtCompanyID.SetEnable(false);
			txtAddressID.SetEnable(false);

			lupAddressType.BindData("AddressType");
			lupCountry.BindData("Country");

			txtCompanyID.EditValue = (this.ParamsData as DataMap).GetValue("CompanyID");
			txtCompanyID.EditText = (this.ParamsData as DataMap).GetValue("CompanyName");
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
				var parameter = new DataMap(){ { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<CompanyAddressModel>("Biz", "GetData", "Select", parameter);
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
			ClearControlData<CompanyAddressModel>();
			ClearControlData<AddressModel>();

			txtCompanyID.EditValue = (this.ParamsData as DataMap).GetValue("CompanyID");
			txtCompanyID.EditText = (this.ParamsData as DataMap).GetValue("CompanyName");

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
				var model = this.GetControlData<CompanyAddressModel>();
				using (var res = WasHandler.Execute<CompanyAddressModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					
					(this.ParamsData as DataMap).SetValue("ID", res.Result.ReturnValue);
				}
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCompanyAddress", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					
					(this.ParamsData as DataMap).SetValue("ID", null);
				}
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