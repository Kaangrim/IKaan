using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Base.Variables;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Company;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Company
{
	public partial class CompanyBankAccountEditForm : EditForm
	{
		private object id = null;

		public CompanyBankAccountEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtBankAccountName.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemBankAccountType.Tag = true;
			lcItemBankAccountName.Tag = true;
			lcItemBankName.Tag = true;
			lcItemAccountNo.Tag = true;
			lcItemDepositor.Tag = true;

			SetFieldNames();
			
			lupCompanyID.SetEnable(false);

			lupBankAccountType.BindData("BankAccountType");
			lupCompanyID.BindData("CompanyList");
			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue("CompanyID").ToStringNullToNull();
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
				var model = WasHandler.GetData<CompanyBankAccountModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				id = model.ID;
				picImage.ImageID = model.ImageID;
				if (model.Image.Url.IsNullOrEmpty())
				{
					picImage.Clear();
				}
				else
				{
					picImage.LoadImage(ConstsVar.IMG_URL + model.Image.Url);
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
			ClearControlData<CompanyBankAccountModel>();
			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue("CompanyID").ToStringNullToNull();

			id = null;
			picImage.Clear();

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBankName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CompanyBankAccountModel>();
				model.ID = id.ToIntegerNullToNull();
				model.ImageID = picImage.ImageID.ToIntegerNullToNull();
				model.Image = null;

				if (picImage.EditValue != null)
				{
					if (picImage.ImagePath.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBank(picImage.ImagePath, txtBankName.EditValue.ToString(), txtAccountNo.EditValue.ToString().Replace("-", ""));
						model.Image = new ImageModel()
						{
							ID = picImage.ImageID.ToIntegerNullToNull(),
							Url = url,
							Name = picImage.GetFileName(),
							Width = picImage.ImageWidth,
							Height = picImage.ImageHeight,
							ImageType = BaseConstsImageType.BANK_ACCOUNT
						};
					}
				}
				else
				{
					if (picImage.ImageUrl.IsNullOrEmpty() == false && picImage.EditValue == null)
					{
						FTPHandler.DeleteFile(picImage.ImageUrl);
					}
				}

				using (var res = WasHandler.Execute<CompanyBankAccountModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				if (picImage.ImageUrl.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(picImage.ImageUrl);
				}

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCompanyBank", new DataMap() { { "ID", id } }, "ID"))
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
	}
}