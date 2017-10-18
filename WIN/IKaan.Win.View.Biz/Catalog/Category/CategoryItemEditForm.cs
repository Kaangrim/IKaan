using System;
using DevExpress.Utils;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Catalog.Category;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Catalog.Category
{
	public partial class CategoryItemEditForm : EditForm
	{
		public CategoryItemEditForm()
		{
			InitializeComponent();
			lupCategoryType.EditValueChanged += (object sender, EventArgs e) =>
			{
				var type = lupCategoryType.EditValue.ToStringNullToEmpty();
				if (type.IsNullOrEmpty() == false)
				{
					lupParentID.BindData("Categories", "None", false, new DataMap() { { "CategoryType", (type.ToIntegerNullToZero() - 1).ToString() } });
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lcItemName.SetFieldName("CategoryName");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupCategoryType.BindData("CategoryType");
			spnSortOrder.SetFormat("D", false, HorzAlignment.Near);
			txtInfoNoticeID.CodeGroup = "InfoNoticeList";
			lupParentID.BindData("Categories", "None");
		}

		protected override void DataInit()
		{
			ClearControlData<CategoryItemModel>();
			txtInfoNoticeID.Clear();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			if (param == null)
			{
				DataInit();
				return;
			}

			try
			{
				var model = WasHandler.GetData<CategoryItemModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("데이터가 존재하지 않습니다.");

				SetControlData(model);
				txtInfoNoticeID.EditValue = model.InfoNoticeID;
				txtInfoNoticeID.EditText = model.InfoNoticeName;
				lupParentID.BindData("Categories", "None", false, new DataMap() { { "CategoryType", (lupCategoryType.EditValue.ToIntegerNullToZero() - 1).ToString() } });
				lupParentID.EditValue = model.ParentID.ToStringNullToNull();

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
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
				var model = this.GetControlData<CategoryItemModel>();
				model.InfoNoticeID = txtInfoNoticeID.EditValue.ToIntegerNullToNull();
				using (var res = WasHandler.Execute<CategoryItemModel>("Biz", "Save", "Insert", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCategoryItem", new DataMap() { { "ID", txtID.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				ShowMsgBox("삭제하였습니다.");
				callback(arg, null);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}