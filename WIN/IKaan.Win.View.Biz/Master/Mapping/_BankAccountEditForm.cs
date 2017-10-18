using System;
using System.Windows.Forms;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Base.Variables;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Company;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Model.Biz.Master.Partner;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _BankAccountEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;

		public _BankAccountEditForm()
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
				var parameter = new DataMap(){ { "ID", (param as DataMap).GetValue("ID") } };
				if (_type == "Company")
				{
					var model = WasHandler.GetData<CompanyBankAccountModel>("Biz", "GetData", "Select", parameter);

					SetControlData(model);
					_id = model.ID;
					lupCompanyID.EditValue = model.CompanyID.ToStringNullToEmpty();
					picImage.ImageID = model.ImageID;
					if (model.Image.Url.IsNullOrEmpty())
					{
						picImage.Clear();
					}
					else
					{
						picImage.LoadImage(GlobalVar.ImageServerInfo.CdnUrl + model.Image.Url);
					}
				}
				else if (_type == "Customer")
				{
					var model = WasHandler.GetData<CustomerBankAccountModel>("Biz", "GetData", "Select", parameter);

					SetControlData(model);
					_id = model.ID;
					lupCompanyID.EditValue = model.CustomerID.ToStringNullToEmpty();
					picImage.ImageID = model.ImageID;
					if (model.Image.Url.IsNullOrEmpty())
					{
						picImage.Clear();
					}
					else
					{
						picImage.LoadImage(GlobalVar.ImageServerInfo.CdnUrl + model.Image.Url);
					}
				}
				else if (_type == "Partner")
				{
					var model = WasHandler.GetData<PartnerBankAccountModel>("Biz", "GetData", "Select", parameter);

					SetControlData(model);
					_id = model.ID;
					lupCompanyID.EditValue = model.PartnerID.ToStringNullToEmpty();
					picImage.ImageID = model.ImageID;
					if (model.Image.Url.IsNullOrEmpty())
					{
						picImage.Clear();
					}
					else
					{
						picImage.LoadImage(GlobalVar.ImageServerInfo.CdnUrl + model.Image.Url);
					}
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
			if (_type == "Company")
				ClearControlData<CompanyBankAccountModel>();
			else if (_type == "Customer")
				ClearControlData<CustomerBankAccountModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerBankAccountModel>();
			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToNull();

			_id = null;
			picImage.Clear();

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBankName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				object id = null;
				var image = UploadImage();

				if (_type == "Company")
				{
					var model = this.GetControlData<CompanyBankAccountModel>();
					model.ID = _id.ToIntegerNullToNull();
					model.CompanyID = lupCompanyID.EditValue.ToIntegerNullToNull();
					model.ImageID = picImage.ImageID.ToIntegerNullToNull();
					model.Image = image;
					model.Image.ID = model.ImageID;

					using (var res = WasHandler.Execute<CompanyBankAccountModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Customer")
				{
					var model = this.GetControlData<CustomerBankAccountModel>();
					model.ID = _id.ToIntegerNullToNull();
					model.CustomerID = lupCompanyID.EditValue.ToIntegerNullToNull();
					model.ImageID = picImage.ImageID.ToIntegerNullToNull();
					model.Image = image;
					model.Image.ID = model.ImageID;

					using (var res = WasHandler.Execute<CustomerBankAccountModel>("Biz", "Save", "Insert", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
						id = res.Result.ReturnValue;
					}
				}
				else if (_type == "Partner")
				{
					var model = this.GetControlData<PartnerBankAccountModel>();
					model.ID = _id.ToIntegerNullToNull();
					model.PartnerID = lupCompanyID.EditValue.ToIntegerNullToNull();
					model.ImageID = picImage.ImageID.ToIntegerNullToNull();
					model.Image = image;
					model.Image.ID = model.ImageID;

					using (var res = WasHandler.Execute<PartnerBankAccountModel>("Biz", "Save", "Insert", model, "ID"))
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
		private ImageModel UploadImage()
		{
			var image = new ImageModel();
			if (picImage.EditValue != null)
			{
				if (picImage.ImagePath.IsNullOrEmpty() == false)
				{
					string url = FTPHandler.UploadBank(GlobalVar.ImageServerInfo, picImage.ImagePath, txtBankName.EditValue.ToString(), txtAccountNo.EditValue.ToString().Replace("-", ""));
					image.ID = picImage.ImageID.ToIntegerNullToNull();
					image.Url = url;
					image.Name = picImage.GetFileName();
					image.Width = picImage.ImageWidth;
					image.Height = picImage.ImageHeight;
					image.ImageType = BaseConstsImageType.BANK_ACCOUNT;
					image.RowState = (picImage.ImageID == null) ? "INSERT" : "UPDATE";
				}
			}
			else
			{
				if (picImage.ImageUrl.IsNullOrEmpty() == false && picImage.EditValue == null)
				{
					FTPHandler.DeleteFile(null, picImage.ImageUrl);
					image.RowState = "DELETE";
				}
			}
			return image;
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				if (picImage.ImageUrl.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(null, picImage.ImageUrl);
				}

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", string.Format("Delete{0}BankAccount", _type), new DataMap() { { "ID", _id } }))
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