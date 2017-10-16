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
	public partial class CategoryListForm : EditForm
	{
		public CategoryListForm()
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
			lupCategory1.BindData("Categories", "All", false, new DataMap() { { "CategoryType", "1" } });
			lupCategory2.BindData("Categories", "All", false, new DataMap() { { "CategoryType", "2" } });
			lupCategory3.BindData("Categories", "All", false, new DataMap() { { "CategoryType", "3" } });
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "CategoryName", Width = 250 },
				new XGridColumn() { FieldName = "Category1", Visible = false },
				new XGridColumn() { FieldName = "Category1Name", Width = 150 },
				new XGridColumn() { FieldName = "Category2", Visible = false },
				new XGridColumn() { FieldName = "Category2Name", Width = 150 },
				new XGridColumn() { FieldName = "Category3", Visible = false },
				new XGridColumn() { FieldName = "Category3Name", Width = 150 },
				new XGridColumn() { FieldName = "Category4", Visible = false },
				new XGridColumn() { FieldName = "Category4Name", Width = 150 },
				new XGridColumn() { FieldName = "Category5", Visible = false },
				new XGridColumn() { FieldName = "Category5Name", Width = 150 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
			gridList.ColumnFix("RowNo");
			gridList.SetMerge("Category1", "Category1Name", "Category2", "Category2Name", "Category3", "Category3Name");

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
			gridList.BindList<CategoryModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "Category", lupCategory1.EditValue },
				{ "FindText", txtFindText.EditValue }
			});
		}
		protected override void DataInit()
		{
			ShowEdit(null);
		}

		protected override void ShowEdit(object data = null)
		{
			using(var form = new CategoryEditForm())
			{
				form.Text = "카테고리등록";
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