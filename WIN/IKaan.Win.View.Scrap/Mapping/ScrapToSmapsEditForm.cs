using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Scrap.Common;
using IKaan.Model.Scrap.Mapping;
using IKaan.Model.Scrap.Smaps;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Mapping
{
	public partial class ScrapToSmapsEditForm : EditForm
	{
		public ScrapToSmapsEditForm()
		{
			InitializeComponent();

			lupSite.EditValueChanged += (object sender, EventArgs e) =>
			{
				lupBrand.BindData("ScrapBrand", "All", false, new DataMap() { { "SiteID", lupSite.EditValue } });
			};

			btnInterface.Click += (object sender, EventArgs e) => { };
			btnOptionMatching.Click += (object sender, EventArgs e) => { OptionMatching(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true });
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
			lupBrand.BindData("ScrapBrand", "All", false, new DataMap() { { "SiteID", lupSite.EditValue } });
			lupMappingYn.BindData("Yn", "All");

			InitGrid();

			lcTabList.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Brand
			gridBrandList.Init();
			gridBrandList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "ScrapBrandID", Width = 100 },
				new XGridColumn() { FieldName = "ScrapBrandName", Width = 150},
				new XGridColumn() { FieldName = "ProductCount", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SmapsBrandID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsBrandName", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBrandList.ColumnFix("RowNo");
			gridBrandList.ColumnFix("Checked");

			gridBrandList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						var data = CodeHelper.ShowForm("SmapsBrand", null, null);
						if (data != null)
						{
							view.SetRowCellValue(e.RowHandle, "SmapsBrandID", (data as DataMap).GetValue("Code"));
							view.SetRowCellValue(e.RowHandle, "SmapsBrandName", (data as DataMap).GetValue("Name"));
						}
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
				new XGridColumn() { FieldName = "ScrapCategoryName", Width = 200 },
				new XGridColumn() { FieldName = "SmapsCategoryID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsCategoryName", Width = 200 },
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
						var data = CodeHelper.ShowForm("SmapsCategory", null, null);
						if (data != null)
						{
							view.SetRowCellValue(e.RowHandle, "SmapsCategoryID", (data as DataMap).GetValue("Code"));
							view.SetRowCellValue(e.RowHandle, "SmapsCategoryName", (data as DataMap).GetValue("Name"));
						}
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
				new XGridColumn() { FieldName = "BrandCode", Width = 100 },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "CategoryName", Width = 200 },
				new XGridColumn() { FieldName = "ScrapProductID", Width = 100 },
				new XGridColumn() { FieldName = "ScrapProductName", Width = 200 },
				new XGridColumn() { FieldName = "SmapsProductID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsProductName", Width = 200 },
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
						var data = CodeHelper.ShowForm("SmapsProduct", null, null);
						if (data != null)
						{
							view.SetRowCellValue(e.RowHandle, "SmapsProductID", (data as DataMap).GetValue("Code"));
							view.SetRowCellValue(e.RowHandle, "SmapsProductName", (data as DataMap).GetValue("Name"));
						}
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
				new XGridColumn() { FieldName = "ScrapColorID", Width = 100 },
				new XGridColumn() { FieldName = "ScrapColorName", Width = 200 },
				new XGridColumn() { FieldName = "SmapsColorID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsColorName", Width = 200 },
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
						var data = CodeHelper.ShowForm("SmapsColor", null, null);
						if (data != null)
						{
							view.SetRowCellValue(e.RowHandle, "SmapsColorID", (data as DataMap).GetValue("Code"));
							view.SetRowCellValue(e.RowHandle, "SmapsColorName", (data as DataMap).GetValue("Name"));
						}
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
				new XGridColumn() { FieldName = "CategoryName", Width = 100 },
				new XGridColumn() { FieldName = "Gender", Visible = false },
				new XGridColumn() { FieldName = "GenderName", Width = 100 },
				new XGridColumn() { FieldName = "ScrapSizeID", Width = 100 },
				new XGridColumn() { FieldName = "ScrapSizeName", Width = 200 },
				new XGridColumn() { FieldName = "SmapsSizeID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsSizeName", Width = 200 },
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
						var data = CodeHelper.ShowForm("SmapsSize", null, null);
						if (data != null)
						{
							view.SetRowCellValue(e.RowHandle, "SmapsSizeID", (data as DataMap).GetValue("Code"));
							view.SetRowCellValue(e.RowHandle, "SmapsSizeName", (data as DataMap).GetValue("Name"));
						}
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
				if (lcTabList.SelectedTabPage.Name == lcGroupBrand.Name)
				{
					gridBrandList.BindList<ScrapBrandToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "MappingYn", lupMappingYn.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
				{
					gridCategoryList.BindList<ScrapCategoryToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "MappingYn", lupMappingYn.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupProduct.Name)
				{
					gridProductList.BindList<ScrapProductToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "BrandCode", lupBrand.GetValue(0) },
						{ "FindText", txtFindText.EditValue },
						{ "MappingYn", lupMappingYn.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupColor.Name)
				{
					gridColorList.BindList<ScrapColorToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "MappingYn", lupMappingYn.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupSize.Name)
				{
					gridSizeList.BindList<ScrapSizeToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "MappingYn", lupMappingYn.EditValue }
					});
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void OptionMatching()
		{
			try
			{
				SplashUtils.ShowWait("처리하는 중입니다... 잠시만...");
				using (var res = WasHandler.Batch("Scrap", "Save", "BatchScrapOption", new DataMap() { { "SiteID", lupSite.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					SetMessage("처리하였습니다.");
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