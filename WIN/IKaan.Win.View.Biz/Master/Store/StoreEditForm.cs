using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Master.Store
{
	public partial class StoreEditForm : EditForm
	{
		private string loadImageUrl = string.Empty;

		public StoreEditForm()
		{
			InitializeComponent();
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

			lcItemStoreType.Tag = true;
			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("StoreName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupStoreType.BindData("StoreType");
		}

		protected override void DataInit()
		{
			ClearControlData<StoreModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<StoreModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.Image != null && model.Image.Url.IsNullOrEmpty() == false)
				{
					loadImageUrl = model.Image.Url;
					picImage.LoadAsync(ConstsVar.IMG_URL + model.Image.Url);
				}
				else
				{
					loadImageUrl = string.Empty;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtName.Focus();

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
				var model = this.GetControlData<StoreModel>();
				if (model.Image == null)
					model.Image = new ImageModel();

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					string path = picImage.GetLoadedImageLocation();
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadStore(path, txtName.EditValue.ToString());
						model.Image.Url = url;
						model.Image.Name = ImageUtils.GetFileName(path);
						model.Image.Width = ImageUtils.GetSizePixel(path).Width;
						model.Image.Height = ImageUtils.GetSizePixel(path).Height;
						model.Image.ImageType = "40";
					}
				}
				else
				{
					if (loadImageUrl.IsNullOrEmpty() == false)
					{
						FTPHandler.DeleteFile(loadImageUrl);
						loadImageUrl = string.Empty;
					}
				}

				
				using (var res = WasHandler.Execute<StoreModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteStore", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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