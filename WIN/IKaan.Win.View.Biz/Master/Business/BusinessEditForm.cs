﻿using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Base.Variables;
using IKaan.Model.Biz.Master.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Business
{
	public partial class BusinessEditForm : EditForm
	{
		private object id = null;
		private object addressID = null;

		public BusinessEditForm()
		{
			InitializeComponent();

			txtPostalCode.ButtonClick += delegate (object sender, ButtonPressedEventArgs e)
			{
				if(e.Button.Kind== ButtonPredefines.Ellipsis)
				{
					var data = SearchPostalCode.Find();
					if (data != null)
					{
						if (data.PostalNo.IsNullOrEmpty())
							txtPostalCode.EditValue = data.ZoneCode;
						else
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
			txtName.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lcItemName.SetFieldName("BizName");

			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupBizType.BindData("BizType");
			lupCountry.BindData("Country");
			lupStatus.BindData("BizStatus");			
		}

		void InitGrid()
		{
			#region Links
			gridLinks.Init();
			gridLinks.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BusinessID", Visible = false },
				new XGridColumn() { FieldName = "LinkType", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LinkID", Visible = false },				
				new XGridColumn() { FieldName = "LinkName", Width = 150 },
				new XGridColumn() { FieldName = "StartDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "EndDate", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridLinks.ColumnFix("RowNo");
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<BusinessModel>();
			ClearControlData<AddressModel>();
			gridLinks.Clear<BusinessLinksModel>();

			id = null;
			addressID = null;
			picImage.Clear();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtBizNo.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<BusinessModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				id = model.ID;
				addressID = model.AddressID;

				if (model.Address != null)
				{
					txtPostalCode.EditValue = model.Address.PostalCode;
					txtAddressLine1.EditValue = model.Address.AddressLine1;
					txtAddressLine2.EditValue = model.Address.AddressLine2;
					lupCountry.EditValue = model.Address.Country;
					txtCity.EditValue = model.Address.City;
					txtStateProvince.EditValue = model.Address.StateProvince;
				}

				if (model.Links == null)
					model.Links = new List<BusinessLinksModel>();
				gridLinks.DataSource = model.Links;

				picImage.ImageID = model.ImageID;
				if (model.Image.Url.IsNullOrEmpty())
				{
					picImage.Clear();
				}
				else
				{
					picImage.LoadImage(GlobalVar.ImageServerInfo.CdnUrl + model.Image.Url);
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBizNo.Focus();

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
				var model = this.GetControlData<BusinessModel>();
				model.ID = id.ToIntegerNullToNull();
				model.AddressID = addressID.ToIntegerNullToNull();
				model.ImageID = picImage.ImageID.ToIntegerNullToNull();

				model.Address = new AddressModel()
				{
					ID = model.AddressID,
					PostalCode = txtPostalCode.EditValue.ToStringNullToNull(),
					City = txtCity.EditValue.ToStringNullToNull(),
					StateProvince = txtStateProvince.EditValue.ToStringNullToNull(),
					Country = lupCountry.EditValue.ToStringNullToNull(),
					AddressLine1 = txtAddressLine1.EditValue.ToStringNullToNull(),
					AddressLine2 = txtAddressLine2.EditValue.ToStringNullToNull()
				};

				model.Image = new ImageModel
				{
					ID = picImage.ImageID.ToIntegerNullToNull(),
					ImageType = BaseConstsImageType.BUSINESS
				};

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					string path = picImage.ImagePath;
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadBusiness(GlobalVar.ImageServerInfo, path, txtBizNo.EditValue.ToString().Replace("-", ""));
						model.Image.Url = url;
						model.Image.Name = picImage.GetFileName();
						model.Image.Width = picImage.ImageWidth;
						model.Image.Height = picImage.ImageHeight;
					}
					else
					{
						model.Image = null;
					}
				}
				else
				{
					if (picImage.ImageUrl.IsNullOrEmpty() == false)
					{
						FTPHandler.DeleteFile(null, picImage.ImageUrl);
						model.Image.Url = null;
					}
				}

				using (var res = WasHandler.Execute<BusinessModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					callback(arg, res.Result.ReturnValue);
				}
			}
			catch(Exception ex)
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
					FTPHandler.DeleteFile(null, picImage.ImageUrl);
				}

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteBusiness", new DataMap() { { "ID", id } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					callback(arg, null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}