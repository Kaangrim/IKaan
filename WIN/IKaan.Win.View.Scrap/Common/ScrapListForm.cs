using System;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Common
{
	public partial class ScrapListForm : EditForm
	{
		public ScrapListForm()
		{
			InitializeComponent();

			lupSite.EditValueChanged += (object sender, EventArgs e) =>
			{
				lupBrand.BindData("ScrapBrand", "All", false, new DataMap() { { "SiteID", lupSite.EditValue } });
				lupCategory.BindData("ScrapCategory", "All", false, new DataMap() { { "SiteID", lupSite.EditValue } });
			};

			btnOptionDiv.Click += (object sender, EventArgs e) => { OptionDivide(); };
			btnImageUpload.Click += (object sender, EventArgs e) => { ImageUpload(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lcGroupBrand.Text = DomainUtils.GetFieldName("Brand");
			lcGroupCategory.Text = DomainUtils.GetFieldName("Category");
			lcGroupOption.Text = DomainUtils.GetFieldName("Option");
			lcGroupProduct.Text = DomainUtils.GetFieldName("Product");

			lupSite.BindData("ScrapSite");
			lupBrand.BindData("ScrapBrand", "All", false, new DataMap() { { "SiteID", lupSite.EditValue } });
			lupCategory.BindData("ScrapCategory", "All", false, new DataMap() { { "SiteID", lupSite.EditValue } });

			InitGrid();

			lcTabList.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Brand
			gridBrands.Init();
			gridBrands.ShowFooter = true;
			gridBrands.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "Code", CaptionCode = "BrandCode", Width = 80 },
				new XGridColumn() { FieldName = "Name", CaptionCode = "BrandName", Width = 200, IsSummary = true, SummaryItemType = SummaryItemType.Count, SummaryFormatString = "N0" },
				new XGridColumn() { FieldName = "ProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "ScrapProductCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "ScrapImageCount", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "GenderMen", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "GenderFemale", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "GenderUnisex", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "Url", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridBrands.ColumnFix("RowNo");

			gridBrands.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Category
			gridCategories.Init();
			gridCategories.AddGridColumns(
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
			gridCategories.ColumnFix("RowNo");

			gridCategories.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Option
			gridOptions.Init();
			gridOptions.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "OptionName", Width = 200 },
				new XGridColumn() { FieldName = "Option1Type", Width = 100 },
				new XGridColumn() { FieldName = "Option1Name", Width = 100 },
				new XGridColumn() { FieldName = "Option1Value", Width = 100 },
				new XGridColumn() { FieldName = "Option2Type", Width = 100 },
				new XGridColumn() { FieldName = "Option2Name", Width = 100 },
				new XGridColumn() { FieldName = "Option2Value", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridOptions.ColumnFix("RowNo");

			gridOptions.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Product
			gridProducts.Init();
			gridProducts.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
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
			gridProducts.ColumnFix("RowNo");
			gridProducts.ColumnFix("Checked");
			gridProducts.SetEditable("Checked");
			gridProducts.SetRepositoryItemCheckEdit("Checked");

			gridProducts.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						if (e.Column.FieldName == "Url")
						{
							var url = lupSite.GetValue(1).ToStringNullToEmpty();
							url = url + view.GetRowCellValue(e.RowHandle, "Url").ToStringNullToEmpty();
							Process.Start(url);
						}
						else
						{
							ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
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
				SplashUtils.ShowWait("조회하는 중입니다... 잠시만...");

				if (lcTabList.SelectedTabPage.Name == lcGroupBrand.Name)
				{
					gridBrands.BindList<ScrapBrandModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
				{
					gridCategories.BindList<ScrapCategoryModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupOption.Name)
				{
					gridOptions.BindList<ScrapOptionModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "FindText", txtFindText.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupProduct.Name)
				{
					gridProducts.BindList<ScrapProductModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "SiteID", lupSite.EditValue },
						{ "BrandCode", lupBrand.EditValue },
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

		protected override void ShowEdit(object data = null)
		{
			if (lcTabList.SelectedTabPage.Name == lcGroupBrand.Name)
			{
				using(var form = new ScrapBrandEditForm())
				{
					form.Text = "브랜드정보수정";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = data;

					if (form.ShowDialog() == DialogResult.OK)
						DataLoad();
				}
			}
			else if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
			{
				using (var form = new ScrapCategoryEditForm())
				{
					form.Text = "카테고리정보수정";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = data;

					if (form.ShowDialog() == DialogResult.OK)
						DataLoad();
				}
			}
			else if (lcTabList.SelectedTabPage.Name == lcGroupOption.Name)
			{
				using (var form = new ScrapOptionEditForm())
				{
					form.Text = "옵션정보수정";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = data;

					if (form.ShowDialog() == DialogResult.OK)
						DataLoad();
				}
			}
			else if (lcTabList.SelectedTabPage.Name == lcGroupProduct.Name)
			{
				using (var form = new ScrapProductEditForm())
				{
					form.Text = "상품정보수정";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = data;

					if (form.ShowDialog() == DialogResult.OK)
						DataLoad();
				}
			}
		}

		private void OptionDivide()
		{
			try
			{
				SplashUtils.ShowWait("처리하는 중입니다... 잠시만...");
				using (var res = WasHandler.Batch("Scrap", "Save", "BatchScrapOption", new DataMap() { { "SiteID", lupSite.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					SetMessage("처리하였습니다.");
					DataLoad();
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

		private void ImageUpload()
		{
			if (lcTabList.SelectedTabPage.Name != lcGroupProduct.Name)
				return;

			try
			{
				var list = gridProducts.GetFilteredData<ScrapProductModel>().Where(x => x.Checked == "Y").ToList();
				if (list == null || list.Count == 0)
				{
					ShowMsgBox("처리할 건이 없습니다.\r\n처리할 상품을 선택하세요!!!");
					return;
				}

				SplashUtils.ShowWait("처리하는 중입니다... 잠시만...");

				foreach(var data in list)
				{
					var images = WasHandler.GetList<ScrapProductImageModel>("Scrap", "GetList", "Select", new DataMap() { { "ProductID", data.ID } });
					if (images == null || images.Count == 0)
						continue;

					foreach (var image in images)
					{
						var url = FTPHandler.UploadScrapProduct(lupSite.GetValue(1).ToString(), image.Name, data.BrandName);
						image.Url = ConstsVar.IMG_URL + url;
						using (var res = WasHandler.Execute<ScrapProductImageModel>("Scrap", "Save", "Update", image, "ID"))
						{
							if (res.Error.Number != 0)
								throw new Exception(res.Error.Message);
						}
					}
				}

				ShowMsgBox("저장하였습니다.");
				DataLoad();
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