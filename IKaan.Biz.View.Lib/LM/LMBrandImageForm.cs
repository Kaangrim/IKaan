﻿using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Handler;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Variables;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.LIB.LM;

namespace IKaan.Biz.View.Lib.LM
{
	public partial class LMBrandImageForm : EditForm
	{
		private string loadUrl = string.Empty;

		public LMBrandImageForm()
		{
			InitializeComponent();

			btnUpload.Click += delegate (object sender, EventArgs e) { UploadImage(); };
			btnDelete.Click += delegate (object sender, EventArgs e) { DeleteImage(); };
			picImage.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (this.IsLoaded)
				{
					txtImagePath.EditValue = picImage.GetLoadedImageLocation();
					if (picImage.EditValue.IsNullOrEmpty() == false)
					{
						btnUpload.Enabled = true;
					}
				}
			};
			picImage.LoadCompleted += delegate (object sender, EventArgs e)
			{
				txtImagePath.EditValue = loadUrl;
				btnUpload.Enabled = false;
				btnDelete.Enabled = true;
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			lupImageType.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { });
		}

		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtImageID.SetEnable(false);
			txtBrandID.SetEnable(false);
			txtImagePath.SetEnable(false);

			InitCombo();

			esImagePath.Text = "이미지서버 경로: " + ConstsVar.IMG_URL_BRAND;
		}

		private void InitCombo()
		{
			lupImageType.BindData("ImageType");
		}

		protected override void DataInit()
		{
			loadUrl = string.Empty;
			txtImageID.Clear();
			txtImagePath.Clear();
			picImage.EditValue = null;
			btnUpload.Enabled = false;
			btnDelete.Enabled = false;
			EditMode = EditModeEnum.New;
		}
		protected override void DataLoad(object param = null)
		{
			try
			{
				if (param == null || param.GetType() != typeof(DataMap))
				{
					ShowMsgBox("전달값을 확인할 수 없습니다.");
					Close();
					return;
				}
				if ((param as DataMap).GetValue("BrandID").IsNullOrEmpty())
				{
					ShowMsgBox("브랜드ID를 확인할 수 없습니다.");
					Close();
					return;
				}

				txtBrandID.EditValue = (param as DataMap).GetValue("BrandID");

				if ((param as DataMap).GetValue("ID").IsNullOrEmpty())
				{
					DataInit();
					return;
				}

				txtImageID.EditValue = (param as DataMap).GetValue("ID");
				lupImageType.EditValue = (param as DataMap).GetValue("ImageType");

				loadUrl = (param as DataMap).GetValue("ImageUrl").ToString();
				picImage.LoadAsync(ConstsVar.IMG_URL + loadUrl);
				txtImagePath.EditValue = loadUrl;

				EditMode = EditModeEnum.Modify;
				lupImageType.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void UploadImage()
		{
			try
			{
				if (txtBrandID.EditValue == null)
				{
					ShowMsgBox("브랜드ID를 알 수 없습니다.");
					return;
				}

				string url = FTPHandler.UploadBrand(picImage.GetLoadedImageLocation(), txtBrandID.EditValue.ToString(), lupImageType.GetValue(0).ToStringNullToEmpty());
				LMBrandImage model = new LMBrandImage()
				{
					ID = txtImageID.EditValue.ToIntegerNullToNull(),
					BrandID = txtBrandID.EditValue.ToIntegerNullToNull(),
					ImageType = lupImageType.EditValue.ToString(),
					ImageUrl = url
				};

				using (var res = WasHandler.Execute<LMBrandImage>("LM", "Save", (this.EditMode== EditModeEnum.New)?"Insert":"Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("업로드하였습니다." + Environment.NewLine + "서버경로: " + url);
					this.SetModifiedCount();
					DataInit();
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void DeleteImage()
		{
			try
			{
				if (txtBrandID.EditValue == null)
					return;

				DataMap map = new DataMap() { { "ID", txtBrandID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("LM", "Delete", "DeleteLMBrandImage", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					this.SetModifiedCount();
					DataInit();
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}