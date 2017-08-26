using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.IKBiz;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Common
{
	public partial class CustomerBusinessEditForm  : EditForm
	{
		private string loadUrl = string.Empty;

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
					var data = SearchPostCode.Find();
					if (data != null)
					{
						txtPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtAddressLine1.EditValue = data.Address1;
						txtAddressLine2.EditValue = data.Address2;
					}
				}
			};

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
			txtCustomerID.SetEnable(false);
			txtBusinessID.SetEnable(false);
			txtAddressID.SetEnable(false);
			txtImageUrl.SetEnable(false);

			datStartDate.Init(CalendarViewType.DayView);

			lupBizType.BindData("BizType");
			lupCountry.BindData("Country");
			lupStatus.BindData("BizStatus");

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
				var model = WasHandler.GetData<CustomerBusinessModel>("Biz", "GetData", "Select", parameter);
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.Business != null)
				{
					txtBizNo.EditValue = model.Business.BizNo;
					txtBizName.EditValue = model.Business.BizName;
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

				loadUrl = model.Business.ImageUrl;
				if (loadUrl.IsNullOrEmpty())
				{
					picImage.EditValue = null;
					txtImageUrl.EditValue = null;
				}
				else
				{
					picImage.LoadAsync(ConstsVar.IMG_URL + loadUrl);
					txtImageUrl.EditValue = loadUrl;
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
			txtCustomerID.EditValue = (this.ParamsData as DataMap).GetValue("CustomerID");
			txtCustomerID.EditText = (this.ParamsData as DataMap).GetValue("CustomerName");

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

			loadUrl = string.Empty;
			picImage.EditValue = null;

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
					BizName = txtBizName.EditValue.ToStringNullToNull(),
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
					string path = picImage.GetLoadedImageLocation();
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(txtImageUrl.EditValue.ToString(), txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Business.ImageUrl = url;
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
				if (txtImageUrl.EditValue.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(txtImageUrl.EditValue.ToString());
					loadUrl = string.Empty;
				}

				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCustomerBusiness", map, "ID"))
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