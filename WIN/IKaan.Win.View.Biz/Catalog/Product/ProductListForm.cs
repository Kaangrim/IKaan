using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Catalog.Product;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;

namespace IKaan.Win.View.Biz.Catalog.Product
{
	public partial class ProductListForm : EditForm
	{
		public ProductListForm()
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
			
			lcTabList.SelectedTabPageIndex = 0;
		}

		void InitCombo()
		{
			lupBrandID.BindData("BrandList", "All");
			lupCategoryID.BindData("CategoryList", "All");
			lupAge.BindData("Age", "All");
			lupGender.BindData("Gender", "All");
			lupSeason.BindData("Season", "All");
			lupOrigin.BindData("Country", "All");
			lupUseYn.BindData("Yn", "All");
		}

		void InitGrid()
		{
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Name", CaptionCode = "ProductName", Width = 200 },
				new XGridColumn() { FieldName = "Code", CaptionCode = "ProductCode", Width = 100 },
				new XGridColumn() { FieldName = "ProductType", Visible = false },
				new XGridColumn() { FieldName = "ProductTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandID", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "CategoryID", Visible = false },
				new XGridColumn() { FieldName = "CategoryName", Visible = false },
				new XGridColumn() { FieldName = "Category1", Visible = false },
				new XGridColumn() { FieldName = "Category1Name", Width = 100 },
				new XGridColumn() { FieldName = "Category2", Visible = false },
				new XGridColumn() { FieldName = "Category2Name", Width = 100 },
				new XGridColumn() { FieldName = "Category3", Visible = false },
				new XGridColumn() { FieldName = "Category3Name", Width = 100 },
				new XGridColumn() { FieldName = "Category4", Visible = false },
				new XGridColumn() { FieldName = "Category4Name", Width = 100 },
				new XGridColumn() { FieldName = "Category5", Visible = false },
				new XGridColumn() { FieldName = "Category5Name", Width = 100 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
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
			#endregion
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				if (lcTabList.SelectedTabPage.Name == lcGroupList.Name)
				{
					gridList.BindList<ProductModel>("Biz", "GetList", "Select", new DataMap()
					{
						{ "FindText", txtFindText.EditValue },
						{ "CategoryID", lupCategoryID.EditValue },
						{ "BrandID", lupBrandID.EditValue },
						{ "Age", lupAge.EditValue },
						{ "Gender", lupGender.EditValue },
						{ "Season", lupSeason.EditValue },
						{ "Origin", lupOrigin.EditValue },
						{ "UseYn", lupUseYn.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupCard.Name)
				{
					string data = string.Format("FindText={0}&GoodsCode={1}&GoodsName={2}&CategoryID={3}&BrandID={4}&Age={5}&Gender={6}&Season={7}&Origin={8}&UseYn={9}",
						txtFindText.EditValue, lupCategoryID.EditValue, lupBrandID.EditValue,
						lupAge.EditValue, lupGender.EditValue, lupSeason.EditValue, lupOrigin.EditValue, lupUseYn.EditValue);
					wbList.NavigatePost(@"http://localhost:58647/Goods", data);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void ShowEdit(object data = null)
		{
			using (var form = new ProductEditForm()
			{
				Text = "상품등록",
				StartPosition = FormStartPosition.CenterScreen,
				ParamsData = data,
				IsLoadingRefresh = true
			})
			{
				if (form.ShowDialog() == DialogResult.OK)
					DataLoad(null);
			}
		}
	}
}