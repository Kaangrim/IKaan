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
	public partial class CategoryEditForm : EditForm
	{
		public CategoryEditForm()
		{
			InitializeComponent();

			lupCategory1.ButtonClick += this.LupCategory1_ButtonClick;
		}

		private void LupCategory1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			if (e.Button.Kind == DevExpress.XtraEditors.Controls.ButtonPredefines.Plus)
			{
				ShowEdit();
			}
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

			lupCategory1.BindData("Categories", "None", false, new DataMap() { { "CategoryType", "1" } });
			lupCategory2.BindData("Categories", "None", false, new DataMap() { { "CategoryType", "2" } });
			lupCategory3.BindData("Categories", "None", false, new DataMap() { { "CategoryType", "3" } });
			lupCategory4.BindData("Categories", "None", false, new DataMap() { { "CategoryType", "4" } });
			lupCategory5.BindData("Categories", "None", false, new DataMap() { { "CategoryType", "5" } });

			spnSortOrder.SetFormat("D", false, HorzAlignment.Near);
			txtInfoNoticeID.CodeGroup = "InfoNoticeList";
		}

		protected override void DataInit()
		{
			ClearControlData<CategoryModel>();
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
				var model = WasHandler.GetData<CategoryModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });

				SetControlData(model);
				lupCategory1.EditValue = model.Category1.ToStringNullToNull();
				lupCategory2.EditValue = model.Category2.ToStringNullToNull();
				lupCategory3.EditValue = model.Category3.ToStringNullToNull();
				lupCategory4.EditValue = model.Category4.ToStringNullToNull();
				lupCategory5.EditValue = model.Category5.ToStringNullToNull();
				txtInfoNoticeID.EditValue = model.InfoNoticeID;
				txtInfoNoticeID.EditText = model.InfoNoticeName;

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
				var model = this.GetControlData<CategoryModel>();
				model.InfoNoticeID = txtInfoNoticeID.EditValue.ToIntegerNullToNull();
				using (var res = WasHandler.Execute<CategoryModel>("Biz", "Save", "Insert", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteCategory", new DataMap() { { "ID", txtID.EditValue } }))
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

		protected override void ShowEdit(object data = null)
		{
			using(var form = new CategoryItemEditForm())
			{
				form.Text = "카테고리항목등록";
				form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = data;
				if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }
			}
		}
	}
}