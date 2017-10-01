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
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Company
{
	public partial class CompanyBusinessEditForm : EditForm
	{
		private object id = null;
		private object businessID = null;
		private object addressID = null;

		public CompanyBusinessEditForm()
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
			lupCompanyID.BindData("CompanyList");

			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue("CompanyID").ToStringNullToEmpty();
		}

		protected override void DataInit()
		{
			ClearControlData<CompanyBusinessModel>();
			ClearControlData<BusinessModel>();
			ClearControlData<AddressModel>();

			lupCompanyID.EditValue = (this.ParamsData as DataMap).GetValue("CompanyID").ToStringNullToEmpty();

			picImage.Clear();

			id = null;
			businessID = null;
			addressID = null;

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
				var model = WasHandler.GetData<CompanyBusinessModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				id = model.ID;
				businessID = model.BusinessID;

				if (model.Business != null)
				{
					txtBizNo.EditValue = model.Business.BizNo;
					txtBizName.EditValue = model.Business.Name;
					txtRepName.EditValue = model.Business.RepName;
					memBizKind.EditValue = model.Business.BizKind;
					memBizItem.EditValue = model.Business.BizItem;
					txtEmail.EditValue = model.Business.Email;
					lupStatus.EditValue = model.Business.Status;

					txtPostalCode.EditValue = model.Business.Address.PostalCode;
					txtAddressLine1.EditValue = model.Business.Address.AddressLine1;
					txtAddressLine2.EditValue = model.Business.Address.AddressLine2;
					lupCountry.EditValue = model.Business.Address.Country;
					txtCity.EditValue = model.Business.Address.City;
					txtStateProvince.EditValue = model.Business.Address.StateProvince;

					if (model.Business.Image != null)
					{
						if (model.Business.Image.Url.IsNullOrEmpty())
						{
							picImage.Clear();
						}
						else
						{
							picImage.ImageID = model.Business.ImageID;
							picImage.LoadImage(ConstsVar.IMG_URL + model.Business.Image.Url);
						}
					}

					addressID = model.Business.AddressID;
				}
				else
				{
					addressID = null;
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
				var model = this.GetControlData<CompanyBusinessModel>();

				model.ID = id.ToIntegerNullToNull();
				model.BusinessID = businessID.ToIntegerNullToNull();
				model.Business = new BusinessModel()
				{
					ID = businessID.ToIntegerNullToNull(),
					BizType = lupBizType.EditValue.ToStringNullToNull(),
					BizNo = txtBizNo.EditValue.ToStringNullToNull(),
					Name = txtBizName.EditValue.ToStringNullToNull(),
					RepName = txtRepName.EditValue.ToStringNullToNull(),
					BizKind = memBizKind.EditValue.ToStringNullToNull(),
					BizItem = memBizItem.EditValue.ToStringNullToNull(),
					Email = txtEmail.EditValue.ToStringNullToNull(),
					Status = lupStatus.EditValue.ToStringNullToNull(),
					AddressID = addressID.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = addressID.ToIntegerNullToNull(),
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
						string url = FTPHandler.UploadBusiness(picImage.ImagePath, txtBizNo.EditValue.ToString().Replace("-", ""));
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
						FTPHandler.DeleteFile(picImage.ImageUrl);
					}
				}

				using (var res = WasHandler.Execute<CompanyBusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCompanyBusiness", new DataMap() { { "ID", id } }))
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