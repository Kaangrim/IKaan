using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Customer
{
	public partial class CustomerBankEditForm : EditForm
	{
		private string loadUrl = string.Empty;

		public CustomerBankEditForm()
		{
			InitializeComponent();

			picImage.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
				{
					txtImageUrl.EditValue = picImage.GetLoadedImageLocation();
				}
			};
			picImage.LoadCompleted += delegate (object sender, EventArgs e)
			{
				txtImageUrl.EditValue = loadUrl;
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtBankName.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemBankName.Tag = true;
			lcItemAccountNo.Tag = true;
			lcItemDepositor.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCustomerID.SetEnable(false);
			txtImageUrl.SetEnable(false);

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
				var parameter = new DataMap(){ { "ID", (param as DataMap).GetValue("ID") } };
				var model = WasHandler.GetData<CustomerBankAccountModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				loadUrl = model.BankAccount.Image.Url;
				if (model.BankAccount.Image.Url.IsNullOrEmpty())
				{
					picImage.EditValue = null;
					txtImageUrl.EditValue = null;
				}
				else
				{
					picImage.LoadAsync(ConstsVar.IMG_URL + model.BankAccount.Image.Url);
					txtImageUrl.EditValue = loadUrl;
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBankName.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			ClearControlData<CustomerBankAccountModel>();
			txtCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID");
			txtCustomerID.EditText = (this.ParamsData as DataMap).GetValue("CustomerName");

			txtBankName.Clear();
			txtAccountNo.Clear();
			txtDepositor.Clear();
			picImage.EditValue = null;
			loadUrl = string.Empty;

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBankName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CustomerBankAccountModel>();

				if (picImage.EditValue != null)
				{
					string path = picImage.GetLoadedImageLocation();
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBank(txtImageUrl.EditValue.ToString(), txtBankName.EditValue.ToString(), txtAccountNo.EditValue.ToString().Replace("-", ""));
						model.BankAccount.Image.Url = url;
					}
				}
				else
				{
					if (loadUrl.IsNullOrEmpty() == false)
					{
						FTPHandler.DeleteFile(loadUrl);
						loadUrl = string.Empty;
					}
				}

				using (var res = WasHandler.Execute<CustomerBankAccountModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				if (txtImageUrl.EditValue.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(txtImageUrl.EditValue.ToString());
					loadUrl = string.Empty;
				}

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCustomerBank", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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