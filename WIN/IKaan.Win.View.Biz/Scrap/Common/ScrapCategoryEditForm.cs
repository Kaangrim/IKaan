﻿using System;
using IKaan.Base.Map;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Scrap.Common
{
	public partial class ScrapCategoryEditForm : EditForm
	{ 
		public ScrapCategoryEditForm()
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

			lcItemSite.Tag = true;
			lcItemName.Tag = true;

			SetFieldNames();

			lcItemName.SetFieldName("CategoryName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupSiteID.BindData("ScrapSite");
		}

		protected override void DataInit()
		{
			ClearControlData<ScrapCategoryModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<ScrapCategoryModel>("Scrap", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
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
				var model = this.GetControlData<ScrapCategoryModel>();
				using (var res = WasHandler.Execute<ScrapCategoryModel>("Scrap", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Scrap", "Delete", "DeleteScrapCategory", new DataMap() { { "ID", txtID.EditValue } }))
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