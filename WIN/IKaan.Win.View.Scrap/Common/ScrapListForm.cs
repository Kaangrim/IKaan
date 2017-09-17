using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;

namespace IKaan.Win.View.Scrap.Common
{
	public partial class ScrapListForm : EditForm
	{
		public ScrapListForm()
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
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true, Delete = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lcGroupBrand.Text = DomainUtils.GetFieldName("Brand");
			lcGroupCategory.Text = DomainUtils.GetFieldName("Category");
			lcGroupColor.Text = DomainUtils.GetFieldName("Color");
			lcGroupSize.Text = DomainUtils.GetFieldName("Size");
			lcGroupProduct.Text = DomainUtils.GetFieldName("Product");

			lupSite.BindData("ScrapSite");
			lupBrand.BindData("ScrapBrand", "All");
			lupCategory.BindData("ScrapCategory", "All");

			InitGrid();

			lcTabList.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Brand
			gridBrandList.Init();
			gridBrandList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "Code", CaptionCode = "BrandCode", Width = 80 },
				new XGridColumn() { FieldName = "Name", CaptionCode = "BrandName", Width = 200 },
				new XGridColumn() { FieldName = "ProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "ScrapProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "ScrapImageCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "GenderMen", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "GenderFemale", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "GenderUnisex", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "Url", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBrandList.ColumnFix("RowNo");

			gridBrandList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						//ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Category
			gridCategoryList.Init();
			gridCategoryList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "CategoryName", Width = 300 },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridCategoryList.ColumnFix("RowNo");

			gridCategoryList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						//ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Color
			gridColorList.Init();
			gridColorList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "ColorName", Width = 200 },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridColorList.ColumnFix("RowNo");

			gridColorList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						//ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Product
			gridProductList.Init();
			gridProductList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "BrandCode", Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 200 },
				new XGridColumn() { FieldName = "Code", CaptionCode = "ProductCode", Width = 100 },
				new XGridColumn() { FieldName = "Name", CaptionCode = "ProductName", Width = 300 },
				new XGridColumn() { FieldName = "ListPrice", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SalePrice", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "CategoryName", Width = 200 },
				new XGridColumn() { FieldName = "CategoryID", Width = 100 },
				new XGridColumn() { FieldName = "Gender", Width = 100 },
				new XGridColumn() { FieldName = "Option1Type", Width = 100 },
				new XGridColumn() { FieldName = "Option1Name", Width = 200 },
				new XGridColumn() { FieldName = "Option2Type", Width = 100 },
				new XGridColumn() { FieldName = "Option2Name", Width = 200 },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "Url", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridProductList.ColumnFix("RowNo");

			gridProductList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						//ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Size
			gridSizeList.Init();
			gridSizeList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "CategoryID", Visible = false },
				new XGridColumn() { FieldName = "CategoryName", Width = 200 },
				new XGridColumn() { FieldName = "Gender", Visible = false },
				new XGridColumn() { FieldName = "GenderName", Width = 100 },
				new XGridColumn() { FieldName = "Name", CaptionCode = "SizeName", Width = 150 },
				new XGridColumn() { FieldName = "Description",Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridSizeList.ColumnFix("RowNo");
			gridSizeList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						//ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
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
				SplashUtils.ShowWait("조회하는 중입니다... 잠시만...");

				if (lcTabList.SelectedTabPage.Name == lcGroupBrand.Name)
				{
					gridBrandList.BindList<ScrapBrandModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
				{
					gridCategoryList.BindList<ScrapCategoryModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupColor.Name)
				{
					gridColorList.BindList<ScrapColorModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupProduct.Name)
				{
					gridProductList.BindList<ScrapProductModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "BrandID", lupBrand.EditValue },
						{ "CategoryID", lupCategory.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupSize.Name)
				{
					gridSizeList.BindList<ScrapSizeModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "CategoryID", lupCategory.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
			finally
			{
				SplashUtils.CloseWait();
			}
		}
	}
}