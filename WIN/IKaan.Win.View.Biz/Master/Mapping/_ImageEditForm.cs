using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Base.Variables;
using IKaan.Model.Biz.Master.Brand;
using IKaan.Model.Biz.Master.Common;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Mapping
{
	public partial class _ImageEditForm : EditForm
	{
		private string _type = string.Empty;

		public _ImageEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupImageType.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { });
		}

		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtID.SetEnable(false);
			txtImageID.SetEnable(false);
			txtBrandID.SetEnable(false);
			memImagePath.SetEnable(false);
			txtHost.SetEnable(false);

			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			_type = (this.ParamsData as DataMap).GetValue("MappingType").ToStringNullToEmpty();
			if (_type.IsNullOrEmpty())
			{
				ShowMsgBox("매핑유형을 찾을 수 없습니다.");
				Close();
				return;
			}

			if (_type.ToUpper() == "BRAND")
			{
				lupImageType.BindData("ImageType");
				txtHost.EditValue = ConstsVar.IMG_URL_BRAND;
				txtBrandID.EditValue = (this.ParamsData as DataMap).GetValue("BrandID").ToStringNullToEmpty();
			}
		}

		protected override void DataInit()
		{
			txtID.Clear();
			txtImageID.Clear();
			memImagePath.Clear();
			picImage.Clear();

			EditMode = EditModeEnum.New;
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
				var parameter = new DataMap() { { "ID", (param as DataMap).GetValue("ID") } };
				if (_type.ToUpper() == "BRAND")
				{
					var model = WasHandler.GetData<BrandImageModel>("Biz", "GetData", "Select", parameter);
					if (model != null)
					{
						SetControlData(model);
						txtBrandID.EditValue = model.BrandID.ToStringNullToEmpty();
						picImage.ImageID = model.ImageID;
						if (model.Image.Url.IsNullOrEmpty())
						{
							picImage.Clear();
						}
						else
						{
							picImage.LoadImage(ConstsVar.IMG_URL + model.Image.Url);
						}
					}
				}

				SetToolbarButtons(new ToolbarButtons() { Save = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				lupImageType.Focus();
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
				if (_type.ToUpper() == "BRAND")
				{
					var image = new ImageModel();
					if (picImage.EditValue != null)
					{
						if (picImage.ImagePath.IsNullOrEmpty() == false)
						{
							string url = FTPHandler.UploadBrand(picImage.ImagePath, txtBrandID.EditValue.ToString().Replace("-", ""), lupImageType.EditValue.ToStringNullToEmpty());
							image.ID = picImage.ImageID.ToIntegerNullToNull();
							image.Url = url;
							image.Name = picImage.GetFileName();
							image.Width = picImage.ImageWidth;
							image.Height = picImage.ImageHeight;
							image.ImageType = BaseConstsImageType.BRAND;
							image.RowState = (picImage.ImageID == null) ? "INSERT" : "UPDATE";
						}
					}
					else
					{
						if (picImage.ImageUrl.IsNullOrEmpty() == false && picImage.EditValue == null)
						{
							FTPHandler.DeleteFile(picImage.ImageUrl);
							image.RowState = "DELETE";
						}
					}

					var model = this.GetControlData<BrandImageModel>();
					model.BrandID = txtBrandID.EditValue.ToIntegerNullToNull();
					model.Image = image;
					model.Image.ID = model.ImageID;

					using (var res = WasHandler.Execute<BrandImageModel>("Biz", "Save", "Insert", model, "ID"))
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
		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				if (picImage.ImageUrl.IsNullOrEmpty() == false)
				{
					FTPHandler.DeleteFile(picImage.ImageUrl);
				}

				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", string.Format("Delete{0}Image", _type), new DataMap() { { "ID", txtID.EditValue } }))
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