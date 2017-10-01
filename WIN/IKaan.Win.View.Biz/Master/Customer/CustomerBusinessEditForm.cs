using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Master.Customer;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Customer
{
	public partial class CustomerBusinessEditForm  : EditForm
	{
		public CustomerBusinessEditForm ()
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

			txtID.SetEnable(false);
			lupCustomerID.SetEnable(false);
			txtBusinessID.SetEnable(false);
			txtAddressID.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);

			lupBizType.BindData("BizType");
			lupCountry.BindData("Country");
			lupStatus.BindData("BizStatus");
			lupCustomerID.BindData("CustomerList");

			lupCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID").ToStringNullToEmpty();
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
				var model = WasHandler.GetData<CustomerBusinessModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.Business != null)
				{
					txtBizNo.EditValue = model.Business.BizNo;
					txtBizName.EditValue = model.Business.Name;
					txtRepName.EditValue = model.Business.RepName;
					memBizKind.EditValue = model.Business.BizKind;
					memBizItem.EditValue = model.Business.BizItem;
					txtEmail.EditValue = model.Business.Email;
					txtAddressID.EditValue = model.Business.AddressID;
					lupStatus.EditValue = model.Business.Status;

					txtPostalCode.EditValue = model.Business.Address.PostalCode;
					txtAddressLine1.EditValue = model.Business.Address.AddressLine1;
					txtAddressLine2.EditValue = model.Business.Address.AddressLine2;
					lupCountry.EditValue = model.Business.Address.Country;
					txtCity.EditValue = model.Business.Address.City;
					txtStateProvince.EditValue = model.Business.Address.StateProvince;
				}

				picImage.ImageID = model.Business.ImageID;
				if (model.Business.Image.Url.IsNullOrEmpty())
				{
					picImage.Clear();
				}
				else
				{
					picImage.LoadImage(ConstsVar.IMG_URL + model.Business.Image.Url);
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
		protected override void DataInit()
		{
			ClearControlData<CustomerBusinessModel>();
			lupCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID").ToStringNullToEmpty();

			txtBizNo.Clear();
			txtBizName.Clear();
			txtRepName.Clear();
			memBizKind.Clear();
			memBizItem.Clear();
			txtEmail.Clear();
			txtAddressID.Clear();

			txtPostalCode.Clear();
			txtAddressLine1.Clear();
			txtAddressLine2.Clear();
			lupCountry.Clear();
			txtCity.Clear();
			txtStateProvince.Clear();

			picImage.Clear();

			SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBizName.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<CustomerBusinessModel>();
				model.Business = new BusinessModel()
				{
					ID = txtBusinessID.EditValue.ToIntegerNullToNull(),
					BizType = lupBizType.EditValue.ToStringNullToNull(),
					BizNo = txtBizNo.EditValue.ToStringNullToNull(),
					Name = txtBizName.EditValue.ToStringNullToNull(),
					RepName = txtRepName.EditValue.ToStringNullToNull(),
					BizKind = memBizKind.EditValue.ToStringNullToNull(),
					BizItem = memBizItem.EditValue.ToStringNullToNull(),
					Email = txtEmail.EditValue.ToStringNullToNull(),
					Status = lupStatus.EditValue.ToStringNullToNull(),
					AddressID = txtAddressID.EditValue.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = txtAddressID.EditValue.ToIntegerNullToNull(),
						PostalCode = txtPostalCode.EditValue.ToStringNullToNull(),
						AddressLine1 = txtAddressLine1.EditValue.ToStringNullToNull(),
						AddressLine2 = txtAddressLine2.EditValue.ToStringNullToNull(),
						Country = lupCountry.EditValue.ToStringNullToNull(),
						City = txtCity.EditValue.ToStringNullToNull(),
						StateProvince = txtStateProvince.EditValue.ToStringNullToNull()
					}
				};

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					string path = picImage.ImagePath;
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(path, txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Business.Image.Url = url;
					}
					else
					{
						model.Business.Image = null;
					}
				}
				else
				{
					if (picImage.ImageUrl.IsNullOrEmpty() == false)
					{
						FTPHandler.DeleteFile(picImage.ImageUrl);
						model.Business.Image.Url = null;
					}
				}

				using (var res = WasHandler.Execute<CustomerBusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				if (picImage.ImageUrl.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(picImage.ImageUrl);
				}

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCustomerBusiness", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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