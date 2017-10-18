using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Catalog.Category;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Biz.Catalog.Category
{
	public partial class CategoryItemListForm : EditForm
	{
		public CategoryItemListForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupCategoryType.BindData("CategoryType", "All");
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "CategoryName", Width = 150 },
				new XGridColumn() { FieldName = "CategoryType", Visible = false },
				new XGridColumn() { FieldName = "CategoryTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Category3", Visible = false },
				new XGridColumn() { FieldName = "Category3Name", Width = 150 },
				new XGridColumn() { FieldName = "Category4", Visible = false },
				new XGridColumn() { FieldName = "Category4Name", Width = 150 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "SortOrder", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "InfoNoticeID", Visible = false },
				new XGridColumn() { FieldName = "InfoNoticeName", Width = 150 },
				new XGridColumn() { FieldName = "ParentID", CaptionCode = "ParentCategoryID", Visible = false },
				new XGridColumn() { FieldName = "ParentName", CaptionCode = "ParentCategoryName", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<CategoryItemModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "CategoryType", lupCategoryType.EditValue },
				{ "FindText", txtFindText.EditValue }
			});
		}
		protected override void DataInit()
		{
			ShowEdit(null);
		}

		protected override void ShowEdit(object data = null)
		{
			using(var form = new CategoryItemEditForm())
			{
				form.Text = "카테고리항목등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = data;
				if (form.ShowDialog() == DialogResult.OK)
				{
					DataLoad();
				}
			}
		}
	}
}