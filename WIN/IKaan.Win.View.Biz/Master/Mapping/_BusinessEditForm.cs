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
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _BusinessEditForm : EditForm
	{
		private string _type = string.Empty;
		private object _id = null;
		private object _business_id = null;
		private object _address_id = null;

		public _BusinessEditForm()
		{
			InitializeComponent();

			txtBizNo.ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			{
				
			};
			txtPostalCode.ButtonClick += delegate (object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
			{
				if(e.Button.Kind== DevExpress.XtraEditors.Controls.ButtonPredefines.Ellipsis)
				{
					var data = SearchPostalCode.Find();
					if (data != null)
					{
						txtPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtAddressLine1.EditValue = data.Address1;
						txtAddressLine2.EditValue = data.Address2;

						lupCountry.EditValue = "KOR";
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
			datStartDate.Focus();
		}
		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemBizNo.Tag = true;
			lcItemBizName.Tag = true;
			lcItemRepName.Tag = true;

			SetFieldNames();

			lupCompanyID.SetEnable(false);
			datEndDate.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);
			datEndDate.Init(CalendarViewType.DayView);
			datEndDate.EditValue = null;

			lupBizType.BindData("BizType");
			lupCountry.BindData("Country");
			lupStatus.BindData("BizStatus");

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
			ClearControlData<BusinessModel>();
			ClearControlData<AddressModel>();

			if (_type == "Company")
				ClearControlData<CompanyBusinessModel>();
			else if (_type == "Customer")
				ClearControlData<CustomerBusinessModel>();
			else if (_type == "Partner")
				ClearControlData<PartnerBusinessModel>();

			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue(string.Format("{0}ID", _type)).ToStringNullToEmpty();

			picImage.Clear();

			_id = null;
			_business_id = null;
			_address_id = null;

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBizName.Focus();
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
				var business = new BusinessModel();

				if (_type == "Company")
				{
					var model = WasHandler.GetData<CompanyBusinessModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCompanyID.EditValue = model.CompanyID.ToStringNullToEmpty();
						_id = model.ID;
						_business_id = model.BusinessID;
						business = model.Business;
					}
				}
				else if (_type == "Customer")
				{
					var model = WasHandler.GetData<CustomerBusinessModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCompanyID.EditValue = model.CustomerID.ToStringNullToEmpty();
						_id = model.ID;
						_business_id = model.BusinessID;
						business = model.Business;
					}
				}
				else if (_type == "Partner")
				{
					var model = WasHandler.GetData<PartnerBusinessModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						lupCompanyID.EditValue = model.PartnerID.ToStringNullToEmpty();
						_id = model.ID;
						_business_id = model.BusinessID;
						business = model.Business;
					}
				}

				if (business != null)
				{
					txtBizNo.EditValue = business.BizNo;
					txtBizName.EditValue = business.Name;
					txtRepName.EditValue = business.RepName;
					memBizKind.EditValue = business.BizKind;
					memBizItem.EditValue = business.BizItem;
					txtEmail.EditValue = business.Email;
					lupStatus.EditValue = business.Status;

					txtPostalCode.EditValue = business.Address.PostalCode;
					txtAddressLine1.EditValue = business.Address.AddressLine1;
					txtAddressLine2.EditValue = business.Address.AddressLine2;
					lupCountry.EditValue = business.Address.Country;
					txtCity.EditValue = business.Address.City;
					txtStateProvince.EditValue = business.Address.StateProvince;

					if (business.Image != null)
					{
						if (business.Image.Url.IsNullOrEmpty())
						{
							picImage.Clear();
						}
						else
						{
							picImage.ImageID = business.ImageID;
							picImage.LoadImage(GlobalVar.ImageServerInfo.CdnUrl + business.Image.Url);
						}
					}

					_address_id = business.AddressID;
				}
				else
				{
					_address_id = null;
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBizName.Focus();
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
					id = DataSaveCompany();
				else if (_type == "Customer")
					id = DataSaveCustomer();
				else if (_type == "Partner")
					id = DataSavePartner();

				(this.ParamsData as DataMap).SetValue("ID", id);
				ShowMsgBox("저장하였습니다.");
				callback(arg, this.ParamsData);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		private object DataSaveCompany()
		{
			try
			{
				object id = null;
				var model = this.GetControlData<CompanyBusinessModel>();
				model.ID = _id.ToIntegerNullToNull();
				model.CompanyID = lupCompanyID.EditValue.ToIntegerNullToNull();
				model.BusinessID = _business_id.ToIntegerNullToNull();
				model.Business = new BusinessModel()
				{
					ID = _business_id.ToIntegerNullToNull(),
					BizType = lupBizType.EditValue.ToStringNullToNull(),
					BizNo = txtBizNo.EditValue.ToStringNullToNull(),
					Name = txtBizName.EditValue.ToStringNullToNull(),
					RepName = txtRepName.EditValue.ToStringNullToNull(),
					BizKind = memBizKind.EditValue.ToStringNullToNull(),
					BizItem = memBizItem.EditValue.ToStringNullToNull(),
					Email = txtEmail.EditValue.ToStringNullToNull(),
					Status = lupStatus.EditValue.ToStringNullToNull(),
					AddressID = _address_id.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = _address_id.ToIntegerNullToNull(),
						PostalCode = txtPostalCode.EditValue.ToStringNullToNull(),
						AddressLine1 = txtAddressLine1.EditValue.ToStringNullToNull(),
						AddressLine2 = txtAddressLine2.EditValue.ToStringNullToNull(),
						Country = lupCountry.EditValue.ToStringNullToNull(),
						City = txtCity.EditValue.ToStringNullToNull(),
						StateProvince = txtStateProvince.EditValue.ToStringNullToNull()
					},
					ImageID = picImage.ImageID.ToIntegerNullToNull()
				};

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					if (picImage.ImagePath.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(GlobalVar.ImageServerInfo, picImage.ImagePath, txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Business.Image = new ImageModel()
						{
							ID = picImage.ImageID.ToIntegerNullToNull(),
							Url = url,
							Name = picImage.GetFileName(),
							Width = picImage.ImageWidth,
							Height = picImage.ImageHeight,
							ImageType = BaseConstsImageType.BUSINESS
						};
					}
				}
				else
				{
					if (picImage.ImageUrl.IsNullOrEmpty() == false && picImage.EditValue == null)
					{
						FTPHandler.DeleteFile(GlobalVar.ImageServerInfo, picImage.ImageUrl);
					}
				}

				using (var res = WasHandler.Execute<CompanyBusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					id = res.Result.ReturnValue;
				}
				return id;
			}
			catch
			{
				throw;
			}
		}
		private object DataSaveCustomer()
		{
			try
			{
				object id = null;
				var model = this.GetControlData<CustomerBusinessModel>();
				model.ID = _id.ToIntegerNullToNull();
				model.CustomerID = lupCompanyID.EditValue.ToIntegerNullToNull();
				model.BusinessID = _business_id.ToIntegerNullToNull();
				model.Business = new BusinessModel()
				{
					ID = _business_id.ToIntegerNullToNull(),
					BizType = lupBizType.EditValue.ToStringNullToNull(),
					BizNo = txtBizNo.EditValue.ToStringNullToNull(),
					Name = txtBizName.EditValue.ToStringNullToNull(),
					RepName = txtRepName.EditValue.ToStringNullToNull(),
					BizKind = memBizKind.EditValue.ToStringNullToNull(),
					BizItem = memBizItem.EditValue.ToStringNullToNull(),
					Email = txtEmail.EditValue.ToStringNullToNull(),
					Status = lupStatus.EditValue.ToStringNullToNull(),
					AddressID = _address_id.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = _address_id.ToIntegerNullToNull(),
						PostalCode = txtPostalCode.EditValue.ToStringNullToNull(),
						AddressLine1 = txtAddressLine1.EditValue.ToStringNullToNull(),
						AddressLine2 = txtAddressLine2.EditValue.ToStringNullToNull(),
						Country = lupCountry.EditValue.ToStringNullToNull(),
						City = txtCity.EditValue.ToStringNullToNull(),
						StateProvince = txtStateProvince.EditValue.ToStringNullToNull()
					},
					ImageID = picImage.ImageID.ToIntegerNullToNull(),
					Image = new ImageModel()
					{
						ID = picImage.ImageID.ToIntegerNullToNull()
					}
				};

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					if (picImage.ImagePath.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(null, picImage.ImagePath, txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Business.Image.ID = picImage.ImageID.ToIntegerNullToNull();
						model.Business.Image.Url = url;
						model.Business.Image.Name = picImage.GetFileName();
						model.Business.Image.Width = picImage.ImageWidth;
						model.Business.Image.Height = picImage.ImageHeight;
						model.Business.Image.ImageType = BaseConstsImageType.BUSINESS;
						model.Business.Image.RowState = (picImage.ImageID == null) ? "INSERT" : "UPDATE";
					}
				}
				else
				{
					if (picImage.ImageUrl.IsNullOrEmpty() == false && picImage.EditValue == null)
					{
						FTPHandler.DeleteFile(null, picImage.ImageUrl);
						model.Business.Image.RowState = "DELETE";
					}
				}

				using (var res = WasHandler.Execute<CustomerBusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					id = res.Result.ReturnValue;
				}
				return id;
			}
			catch
			{
				throw;
			}
		}
		private object DataSavePartner()
		{
			try
			{
				object id = null;
				var model = this.GetControlData<PartnerBusinessModel>();
				model.ID = _id.ToIntegerNullToNull();
				model.PartnerID = lupCompanyID.EditValue.ToIntegerNullToNull();
				model.BusinessID = _business_id.ToIntegerNullToNull();
				model.Business = new BusinessModel()
				{
					ID = _business_id.ToIntegerNullToNull(),
					BizType = lupBizType.EditValue.ToStringNullToNull(),
					BizNo = txtBizNo.EditValue.ToStringNullToNull(),
					Name = txtBizName.EditValue.ToStringNullToNull(),
					RepName = txtRepName.EditValue.ToStringNullToNull(),
					BizKind = memBizKind.EditValue.ToStringNullToNull(),
					BizItem = memBizItem.EditValue.ToStringNullToNull(),
					Email = txtEmail.EditValue.ToStringNullToNull(),
					Status = lupStatus.EditValue.ToStringNullToNull(),
					AddressID = _address_id.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = _address_id.ToIntegerNullToNull(),
						PostalCode = txtPostalCode.EditValue.ToStringNullToNull(),
						AddressLine1 = txtAddressLine1.EditValue.ToStringNullToNull(),
						AddressLine2 = txtAddressLine2.EditValue.ToStringNullToNull(),
						Country = lupCountry.EditValue.ToStringNullToNull(),
						City = txtCity.EditValue.ToStringNullToNull(),
						StateProvince = txtStateProvince.EditValue.ToStringNullToNull()
					},
					ImageID = picImage.ImageID.ToIntegerNullToNull()
				};

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					if (picImage.ImagePath.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(null, picImage.ImagePath, txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Business.Image = new ImageModel()
						{
							ID = picImage.ImageID.ToIntegerNullToNull(),
							Url = url,
							Name = picImage.GetFileName(),
							Width = picImage.ImageWidth,
							Height = picImage.ImageHeight,
							ImageType = BaseConstsImageType.BUSINESS
						};
					}
				}
				else
				{
					if (picImage.ImageUrl.IsNullOrEmpty() == false && picImage.EditValue == null)
					{
						FTPHandler.DeleteFile(null, picImage.ImageUrl);
					}
				}

				using (var res = WasHandler.Execute<PartnerBusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
					id = res.Result.ReturnValue;
				}
				return id;
			}
			catch
			{
				throw;
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