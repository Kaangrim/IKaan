using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Smaps;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Smaps
{
	public partial class SmapsAgencyEditForm : EditForm
	{
		private string loadImageUrl = string.Empty;

		public SmapsAgencyEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtname.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemtype.Tag = true;
			lcItemname.Tag = true;

			SetFieldNames();

			lcItemname.SetFieldName("AgencyName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			luptype.BindData("SmapsAgencyType");
			lupgrade.BindData("SmapsAgencyGrade");
		}

		protected override void DataInit()
		{
			ClearControlData<SmapsAgencyModel>();
			loadImageUrl = string.Empty;
			picImage.EditValue = null;

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtname.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<SmapsAgencyModel>("Scrap", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.image.IsNullOrEmpty() == false)
				{
					loadImageUrl = model.image;
					picImage.LoadAsync(ConstsVar.IMG_URL + model.image);
				}
				else
				{
					loadImageUrl = string.Empty;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtname.Focus();

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
				var model = this.GetControlData<SmapsAgencyModel>();

				//이미지 업로드
				if (picImage.EditValue != null)
				{
					string path = picImage.GetLoadedImageLocation();
					if (path.IsNullOrEmpty() == false)
					{
						string url = FTPHandler.UploadSmapsAgency(path, txtname.EditValue.ToString());
						model.image = url;
						model.image_width = ImageUtils.GetSizePixel(path).Width.ToStringNullToEmpty();
						model.image_height = ImageUtils.GetSizePixel(path).Height.ToStringNullToEmpty();
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

				
				using (var res = WasHandler.Execute<SmapsAgencyModel>("Scrap", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Scrap", "Delete", "DeleteSmapsAgency", new DataMap() { { "ID", txtuid.EditValue } }, "ID"))
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