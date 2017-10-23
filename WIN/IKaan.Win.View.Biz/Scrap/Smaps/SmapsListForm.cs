using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Api;
using IKaan.Model.Scrap.Mapping;
using IKaan.Model.Scrap.Smaps;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;
using Newtonsoft.Json;

namespace IKaan.Win.View.Biz.Scrap.Smaps
{
	public partial class SmapsListForm : EditForm
	{
		public SmapsListForm()
		{
			InitializeComponent();

			lcTab.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				lcGroupSearch.BeginUpdate();
				if (e.Page.Name == lcTabGroupInterface.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsSex.Visibility =
						lcItemSmapsStatus.Visibility = LayoutVisibility.Always;
					lcItemScrapSite.Visibility =
						lcItemMappingYn.Visibility = LayoutVisibility.Never;
				}
				else
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsSex.Visibility =
						lcItemSmapsStatus.Visibility = LayoutVisibility.Never;
					lcItemScrapSite.Visibility =
						lcItemMappingYn.Visibility = LayoutVisibility.Always;
				}
				lcGroupSearch.EndUpdate();
			};

			lcTabInterface.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				lcGroupSearch.BeginUpdate();
				if (lcTab.SelectedTabPage.Name != lcTabGroupInterface.Name)
					return;

				if (e.Page.Name == lcGroupInterfaceAgency.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceAgency.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceBrand.Name)
				{
					lcItemSmapsAgency.Visibility = LayoutVisibility.Always;
					lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceBrand.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceCategory.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceCategory.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceColor.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceColor.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceLookbook.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility = LayoutVisibility.Always;
					lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceLookbook.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceProduct.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Always;
					lcItemScrapSite.Visibility = LayoutVisibility.Always;
					SetRecords(gridInterfaceProduct.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceSize.Name)
				{
					lcItemSmapsCategory.Visibility =
					lcItemSmapsSex.Visibility = LayoutVisibility.Always;
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsLookbook.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceSize.RowCount);
				}
				else if (e.Page.Name == lcGroupInterfaceUser.Name)
				{
					lcItemSmapsAgency.Visibility = LayoutVisibility.Always;
					lcItemSmapsBrand.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
					SetRecords(gridInterfaceUser.RowCount);
				}
				lcGroupSearch.EndUpdate();
			};
			lcTabMapping.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				if (lcTab.SelectedTabPage.Name != lcTabGroupMapping.Name)
					return;

				if (e.Page.Name == lcGroupMappingBrand.Name)
				{
					SetRecords(gridMappingBrand.RowCount);
				}
				else if (e.Page.Name == lcGroupMappingCategory.Name)
				{
					SetRecords(gridMappingCategory.RowCount);
				}
			};

			btnSend.Click += (object sender, EventArgs e) =>
			{
				if (lcTab.SelectedTabPage.Name == lcTabGroupInterface.Name)
				{
					if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceAgency.Name)
					{
						var list = gridInterfaceAgency.GetFilteredData<SmapsAgencyModel>().Where(x => x.Checked == "Y").ToList();
						DataSend(list);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceBrand.Name)
					{
						var list = gridInterfaceBrand.GetFilteredData<SmapsBrandModel>().Where(x => x.Checked == "Y").ToList();
						DataSend(list);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceLookbook.Name)
					{
						var list = gridInterfaceLookbook.GetFilteredData<SmapsLookbookModel>().Where(x => x.Checked == "Y").ToList();
						DataSend(list);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceProduct.Name)
					{
						var list = gridInterfaceProduct.GetFilteredData<SmapsProductModel>().Where(x => x.Checked == "Y").ToList();
						DataSend(list);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceUser.Name)
					{
						var list = gridInterfaceUser.GetFilteredData<SmapsUserModel>().Where(x => x.Checked == "Y").ToList();
						DataSend(list);
					}
				}
			};
			btnReceive.Click += (object sender, EventArgs e) =>
			{
				if (lcTab.SelectedTabPage.Name == lcTabGroupInterface.Name)
				{
					if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceAgency.Name)
					{
						DataReceive<SmapsAgencyReceiveModel>(null);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceUser.Name)
					{
						DataReceive<SmapsUserReceiveModel>(null);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceBrand.Name)
					{
						DataReceive<SmapsBrandReceiveModel>(null);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceLookbook.Name)
					{
						DataReceive<SmapsLookbookReceiveModel>(null);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceCategory.Name)
					{
						DataReceive<SmapsCategoryModel>(null);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceColor.Name)
					{
						DataReceive<SmapsColorModel>(null);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceSize.Name)
					{
						if (lupCategory.EditValue == null)
						{
							ShowMsgBox("카테고리를 선택해야 합니다.");
							return;
						}
						if (lupSex.EditValue == null)
						{
							ShowMsgBox("성별을 선택해야 합니다.");
							return;
						}

						DataReceive(new SmapsSizeModel()
						{
							category_uid = lupCategory.EditValue.ToIntegerNullToZero(),
							sex = lupSex.EditValue.ToStringNullToEmpty()
						});
					}
				}
			};
			btnOptionMatching.Click += (object sender, EventArgs e) => { OptionMatching(); };
			btnProductReady.Click += (object sender, EventArgs e) => { ProductReady(); };
			btnCopy.Click += (object sender, EventArgs e) =>
			{
				try
				{
					if (lcTab.SelectedTabPage.Name != lcTabGroupMapping.Name)
						return;
					if (lcTabMapping.SelectedTabPage.Name != lcGroupMappingCategory.Name)
						return;

					int rowIndex = gridMappingCategory.FocusedRowHandle;
					if (rowIndex < 0)
						return;

					var smapsCategoryID = gridMappingCategory.GetValue(rowIndex, "SmapsCategoryID");
					var smapsCategoryName = gridMappingCategory.GetValue(rowIndex, "SmapsCategoryName");

					for (int i = rowIndex + 1; i < gridMappingCategory.RowCount; i++)
					{
						gridMappingCategory.SetValue(i, "SmapsCategoryID", smapsCategoryID);
						gridMappingCategory.SetValue(i, "SmapsCategoryName", smapsCategoryName);
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			lcTabInterface.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Tag.ToStringNullToEmpty() == "NEW")
				{
					ShowEdit(null);
				}
			};
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

			lcGroupInterfaceAgency.Text = DomainUtils.GetFieldName("SmapsAgency");
			lcGroupInterfaceBrand.Text = DomainUtils.GetFieldName("SmapsBrand");
			lcGroupInterfaceCategory.Text = DomainUtils.GetFieldName("SmapsCategory");
			lcGroupInterfaceLookbook.Text = DomainUtils.GetFieldName("SmapsLookbook");
			lcGroupInterfaceColor.Text = DomainUtils.GetFieldName("SmapsColor");
			lcGroupInterfaceSize.Text = DomainUtils.GetFieldName("SmapsSize");
			lcGroupInterfaceProduct.Text = DomainUtils.GetFieldName("SmapsProduct");
			lcGroupInterfaceUser.Text = DomainUtils.GetFieldName("SmapsUser");

			lcGroupMappingBrand.Text = DomainUtils.GetFieldName("Brand");
			lcGroupMappingCategory.Text = DomainUtils.GetFieldName("Category");

			lupAgency.BindData("SmapsAgency", "All");
			lupBrand.BindData("SmapsBrand", "All");
			lupLookbook.BindData("SmapsLookbook", "All");
			lupCategory.BindData("SmapsCategory", "All");
			lupSex.BindData("SmapsSex", "All");
			lupStatus.BindData("SmapsStatus", "All");

			lupScrapSite.BindData("ScrapSite");
			lupMappingYn.BindData("Yn", "All");

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
			lcTabInterface.SelectedTabPageIndex = 0;
			lcTabMapping.SelectedTabPageIndex = 0;
			
			lcItemSmapsAgency.Visibility =
				lcItemSmapsBrand.Visibility =
				lcItemSmapsCategory.Visibility =
				lcItemSmapsLookbook.Visibility =
				lcItemSmapsSex.Visibility = LayoutVisibility.Never;
			lcItemSmapsStatus.Visibility = LayoutVisibility.Always;
			lcItemScrapSite.Visibility =
				lcItemMappingYn.Visibility = LayoutVisibility.Never;
		}

		void InitGrid()
		{
			#region Interface

			#region Interface Agency
			gridInterfaceAgency.Init();
			gridInterfaceAgency.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 60 },
				new XGridColumn() { FieldName = "type", Visible = false },
				new XGridColumn() { FieldName = "type_name", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "grade", Visible = false },
				new XGridColumn() { FieldName = "grade_name", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "name", CaptionCode = "agency_name", Width = 200 },
				new XGridColumn() { FieldName = "recommend", HorzAlignment = HorzAlignment.Center, Width = 60 },
				new XGridColumn() { FieldName = "sv_start_date", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "sv_end_date", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "cp_address", Width = 200 },
				new XGridColumn() { FieldName = "president_name", Width = 100 },
				new XGridColumn() { FieldName = "cp_crn", Width = 100 },
				new XGridColumn() { FieldName = "cp_email", Width = 120 },
				new XGridColumn() { FieldName = "cp_homepage", Width = 120 },
				new XGridColumn() { FieldName = "cp_intro", Width = 200 },
				new XGridColumn() { FieldName = "cp_tel", Width = 100 },
				new XGridColumn() { FieldName = "ct_department", Width = 100 },
				new XGridColumn() { FieldName = "ct_email", Width = 120 },
				new XGridColumn() { FieldName = "ct_fax", Width = 100 },
				new XGridColumn() { FieldName = "ct_hphone", Width = 100 },
				new XGridColumn() { FieldName = "ct_name", Width = 100 },
				new XGridColumn() { FieldName = "ct_position", Width = 80 },
				new XGridColumn() { FieldName = "ct_tel", Width = 100 },
				new XGridColumn() { FieldName = "consultation", Width = 200 },
				new XGridColumn() { FieldName = "using_price", Width = 100 },
				new XGridColumn() { FieldName = "image", Width = 200 },
				new XGridColumn() { FieldName = "image_width", Width = 80 },
				new XGridColumn() { FieldName = "image_height", Width = 80 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceAgency.ColumnFix("RowNo");
			gridInterfaceAgency.SetRepositoryItemCheckEdit("recommend");
			gridInterfaceAgency.SetRepositoryItemCheckEdit("Checked");
			gridInterfaceAgency.SetEditable("Checked");

			gridInterfaceAgency.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface Brand
			gridInterfaceBrand.Init();
			gridInterfaceBrand.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 60 },
				new XGridColumn() { FieldName = "name", CaptionCode = "brand_name", Width = 200 },
				new XGridColumn() { FieldName = "manager", Visible = false },
				new XGridColumn() { FieldName = "manager_name", Width = 100 },
				new XGridColumn() { FieldName = "showroom", Visible = false },
				new XGridColumn() { FieldName = "showroom_name", Width = 100 },
				new XGridColumn() { FieldName = "agency_uid", Visible = false },
				new XGridColumn() { FieldName = "agency_name", Width = 120 },
				new XGridColumn() { FieldName = "caption", Width = 100 },
				new XGridColumn() { FieldName = "image", Width = 200 },
				new XGridColumn() { FieldName = "image_width", Width = 80 },
				new XGridColumn() { FieldName = "image_height", Width = 80 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceBrand.ColumnFix("RowNo");
			gridInterfaceBrand.SetRepositoryItemCheckEdit("Checked");
			gridInterfaceBrand.SetEditable("Checked");
			gridInterfaceBrand.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface Category
			gridInterfaceCategory.Init();
			gridInterfaceCategory.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 80 },
				new XGridColumn() { FieldName = "name", CaptionCode = "category_name", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceCategory.ColumnFix("RowNo");
			gridInterfaceCategory.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface Color
			gridInterfaceColor.Init();
			gridInterfaceColor.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "value", Width = 80 },
				new XGridColumn() { FieldName = "text", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceColor.ColumnFix("RowNo");

			gridInterfaceColor.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface Lookbook
			gridInterfaceLookbook.Init();
			gridInterfaceLookbook.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 80 },
				new XGridColumn() { FieldName = "agency_uid", Visible = false },
				new XGridColumn() { FieldName = "agency_name", Width = 150 },
				new XGridColumn() { FieldName = "brand_uid", Visible = false },
				new XGridColumn() { FieldName = "brand_name", Width = 150 },
				new XGridColumn() { FieldName = "title", Width = 200 },
				new XGridColumn() { FieldName = "marketing", Width = 100 },
				new XGridColumn() { FieldName = "active_date_start", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "active_date_end", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "notice", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceLookbook.ColumnFix("RowNo");
			gridInterfaceLookbook.SetRepositoryItemCheckEdit("Checked");
			gridInterfaceLookbook.SetEditable("Checked");
			gridInterfaceLookbook.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface Product
			gridInterfaceProduct.Init();
			gridInterfaceProduct.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 60 },
				new XGridColumn() { FieldName = "agency_uid", Visible = false },
				new XGridColumn() { FieldName = "agency_name", Width = 120 },
				new XGridColumn() { FieldName = "brand_uid", Visible = false },
				new XGridColumn() { FieldName = "brand_name", Width = 150 },
				new XGridColumn() { FieldName = "lookbook_uid", Visible = false },
				new XGridColumn() { FieldName = "lookbook_name", Width = 200 },
				new XGridColumn() { FieldName = "product_name", Width = 250 },
				new XGridColumn() { FieldName = "product_number", Width = 80 },
				new XGridColumn() { FieldName = "product_price", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "product_unset_price", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "category_uid", Visible = false },
				new XGridColumn() { FieldName = "category_name", Width = 200 },
				new XGridColumn() { FieldName = "sex", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "memo", Width = 200 },
				new XGridColumn() { FieldName = "caution", Width = 200 },
				new XGridColumn() { FieldName = "tag", Width = 200 },
				new XGridColumn() { FieldName = "option", Width = 80 },
				new XGridColumn() { FieldName = "option_size_uid", Width = 200 },
				new XGridColumn() { FieldName = "option_size_view", Width = 200 },
				new XGridColumn() { FieldName = "option_color", Width = 200 },
				new XGridColumn() { FieldName = "option_color_view", Width = 200 },
				new XGridColumn() { FieldName = "option_add_date", Width = 100 },
				new XGridColumn() { FieldName = "image", Width = 200 },
				new XGridColumn() { FieldName = "image_width", Width = 100 },
				new XGridColumn() { FieldName = "image_height", Width = 100 },
				new XGridColumn() { FieldName = "is_thumbnail", Width = 100 },
				new XGridColumn() { FieldName = "is_main", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceProduct.ColumnFix("RowNo");
			gridInterfaceProduct.ColumnFix("Checked");
			gridInterfaceProduct.SetRepositoryItemCheckEdit("product_unset_price");
			gridInterfaceProduct.SetRepositoryItemCheckEdit("Checked");
			gridInterfaceProduct.SetEditable("Checked");

			gridInterfaceProduct.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface Size
			gridInterfaceSize.Init();
			gridInterfaceSize.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 80},
				new XGridColumn() { FieldName = "text", Width = 150 },
				new XGridColumn() { FieldName = "category_uid", Visible = false },
				new XGridColumn() { FieldName = "category_name", Width = 200 },
				new XGridColumn() { FieldName = "sex", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceSize.ColumnFix("RowNo");
			gridInterfaceSize.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Interface User
			gridInterfaceUser.Init();
			gridInterfaceUser.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ApiRequestID", Visible = false },
				new XGridColumn() { FieldName = "ApiType", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Status", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "RequestDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "uid", Width = 80 },
				new XGridColumn() { FieldName = "email", Width = 150 },
				new XGridColumn() { FieldName = "name", Width = 100 },
				new XGridColumn() { FieldName = "utype", Width = 100 },
				new XGridColumn() { FieldName = "agency_uid", Visible = false },
				new XGridColumn() { FieldName = "agency_name", Width = 200 },
				new XGridColumn() { FieldName = "phone1", Width = 150 },
				new XGridColumn() { FieldName = "phone2", Width = 150 },
				new XGridColumn() { FieldName = "phone3", Width = 150 },
				new XGridColumn() { FieldName = "introduce", Width = 200 },
				new XGridColumn() { FieldName = "rank", Width = 80 },
				new XGridColumn() { FieldName = "image", Width = 200 },
				new XGridColumn() { FieldName = "image_width", Width = 80 },
				new XGridColumn() { FieldName = "image_height", Width = 80 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInterfaceUser.ColumnFix("RowNo");
			gridInterfaceUser.SetRepositoryItemCheckEdit("Checked");
			gridInterfaceUser.SetEditable("Checked");
			gridInterfaceUser.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#endregion

			#region Mapping

			#region Mapping Brand
			gridMappingBrand.Init();
			gridMappingBrand.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "ScrapBrandID", Width = 100 },
				new XGridColumn() { FieldName = "ScrapBrandName", Width = 150 },
				new XGridColumn() { FieldName = "ProductCount", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SmapsBrandID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsBrandName", Width = 150 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridMappingBrand.ColumnFix("RowNo");
			gridMappingBrand.ColumnFix("Checked");
			gridMappingBrand.SetRepositoryItemCheckEdit("Checked");
			gridMappingBrand.SetEditable("Checked");

			gridMappingBrand.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
							view.SetRowCellValue(e.RowHandle, "Checked", "Y");
						}
						else
						{
							view.SetRowCellValue(e.RowHandle, "Checked", "N");
						}
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Mapping Category
			gridMappingCategory.Init();
			gridMappingCategory.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "SiteID", Visible = false },
				new XGridColumn() { FieldName = "ScrapCategoryID", Width = 100 },
				new XGridColumn() { FieldName = "ScrapCategoryName", Width = 200 },
				new XGridColumn() { FieldName = "SmapsCategoryID", Width = 100 },
				new XGridColumn() { FieldName = "SmapsCategoryName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridMappingCategory.ColumnFix("RowNo");
			gridMappingCategory.ColumnFix("Checked");
			gridMappingCategory.SetRepositoryItemCheckEdit("Checked");
			gridMappingCategory.SetEditable("Checked");

			gridMappingCategory.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
							view.SetRowCellValue(e.RowHandle, "SmapsCategoryID", (data as DataMap).GetValue("Code").ToIntegerNullToNull());
							view.SetRowCellValue(e.RowHandle, "SmapsCategoryName", (data as DataMap).GetValue("Name"));
							view.SetRowCellValue(e.RowHandle, "Checked", "Y");
						}
						else
						{
							view.SetRowCellValue(e.RowHandle, "Checked", "N");
						}
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion
			
			#endregion
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				SplashUtils.ShowWait();

				if (lcTab.SelectedTabPage.Name == lcTabGroupInterface.Name)
				{
					if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceAgency.Name)
					{
						gridInterfaceAgency.BindList<SmapsAgencyModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceAgency.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceBrand.Name)
					{
						gridInterfaceBrand.BindList<SmapsBrandModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "AgencyUid", lupAgency.EditValue },
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceBrand.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceCategory.Name)
					{
						gridInterfaceCategory.BindList<SmapsCategoryModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceCategory.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceColor.Name)
					{
						gridInterfaceColor.BindList<SmapsColorModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceColor.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceLookbook.Name)
					{
						gridInterfaceLookbook.BindList<SmapsLookbookModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "AgencyUid", lupAgency.GetValue(0) },
							{ "BrandUid", lupBrand.GetValue(0) },
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceLookbook.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceProduct.Name)
					{
						gridInterfaceProduct.BindList<SmapsProductModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "AgencyUid", lupAgency.GetValue(0) },
							{ "BrandUid", lupBrand.GetValue(0) },
							{ "LookbookUid", lupLookbook.GetValue(0) },
							{ "CategoryUid", lupCategory.GetValue(0) },
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceProduct.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceSize.Name)
					{
						gridInterfaceSize.BindList<SmapsSizeModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "CategoryUid", lupCategory.GetValue(0) },
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceSize.RowCount);
					}
					else if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceUser.Name)
					{
						gridInterfaceUser.BindList<SmapsUserModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "AgencyUid", lupAgency.GetValue(0) },
							{ "FindText", txtFindText.EditValue },
							{ "Status", lupStatus.EditValue }
						});
						SetRecords(gridInterfaceUser.RowCount);
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcTabGroupMapping.Name)
				{
					if (lcTabMapping.SelectedTabPage.Name == lcGroupMappingBrand.Name)
					{
						gridMappingBrand.BindList<ScrapBrandToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "SiteID", lupScrapSite.EditValue },
							{ "FindText", txtFindText.EditValue },
							{ "MappingYn", lupMappingYn.EditValue }
						});
						SetRecords(gridMappingBrand.RowCount);
					}
					else if (lcTabMapping.SelectedTabPage.Name == lcGroupMappingCategory.Name)
					{
						gridMappingCategory.BindList<ScrapCategoryToSmapsModel>("Scrap", "GetList", "Select", new DataMap()
						{
							{ "SiteID", lupScrapSite.EditValue },
							{ "FindText", txtFindText.EditValue },
							{ "MappingYn", lupMappingYn.EditValue }
						});
						SetRecords(gridMappingCategory.RowCount);
					}
				}
				SplashUtils.CloseWait();
			}
			catch (Exception ex)
			{
				SplashUtils.CloseWait();
				ShowErrBox(ex);
			}
		}
		
		protected override void ShowEdit(object data = null)
		{
			if (lcTab.SelectedTabPage.Name == lcTabGroupInterface.Name)
			{
				if (lcTabInterface.SelectedTabPage.Name == lcGroupInterfaceAgency.Name)
				{
					using (var form = new SmapsAgencyEditForm())
					{
						form.Text = "Smaps 대행사등록";
						form.StartPosition = FormStartPosition.CenterScreen;
						form.IsLoadingRefresh = true;
						form.ParamsData = data;
						if (form.ShowDialog() == DialogResult.OK)
							DataLoad();
					}
				}
			}
		}

		private void DataSend<T>(IList<T> datalist)
		{
			try
			{
				var apiModel = typeof(T).Name.Replace("Model", "");
				switch (apiModel)
				{
					case "SmapsAgency":
					case "SmapsBrand":
					case "SmapsLookbook":
					case "SmapsUser":
					case "SmapsProduct":
						break;
					default:
						ShowMsgBox("처리할 수 있는 요청유형이 아닙니다.");
						return;
				}

				SplashUtils.ShowWait("처리하는 중입니다... 잠시만...");
				SetMessage("처리하는 중입니다... 잠시만...");
				Application.DoEvents();

				foreach (var data in datalist)
				{
					var resultText = string.Empty;
					if (apiModel == "SmapsProduct")
					{
						var smapsProduct = data as SmapsProductModel;
						var product = new SmapsProductSendModel()
						{
							agency_uid = smapsProduct.agency_uid,
							brand_uid = smapsProduct.brand_uid,
							lookbook_uid = smapsProduct.lookbook_uid,
							product_name = smapsProduct.product_name,
							product_number = smapsProduct.product_number,
							product_price = smapsProduct.product_price,
							product_unset_price = smapsProduct.product_unset_price,
							category_uid = smapsProduct.category_uid,
							sex = smapsProduct.sex,
							memo = smapsProduct.memo,
							caution = smapsProduct.caution,
							tag = smapsProduct.tag
						};

						product.option = smapsProduct.option.ToIntegerNullToZero();

						if (smapsProduct.option_size_uid.IsNullOrEmpty() == false)
						{
							product.option_size_uid = new List<int>();
							foreach (var str in smapsProduct.option_size_uid.Split(','))
								product.option_size_uid.Add(str.ToIntegerNullToZero());
						}

						if (smapsProduct.option_size_view.IsNullOrEmpty() == false)
						{
							product.option_size_view = new List<string>();
							foreach (var str in smapsProduct.option_size_view.Split(','))
								product.option_size_view.Add(str);
						}

						if (smapsProduct.option_color.IsNullOrEmpty() == false)
						{
							product.option_color = new List<string>();
							foreach (var str in smapsProduct.option_color.Split(','))
								product.option_color.Add(str);
						}

						if (smapsProduct.option_color_view.IsNullOrEmpty() == false)
						{
							product.option_color_view = new List<string>();
							foreach (var str in smapsProduct.option_color_view.Split(','))
								product.option_color_view.Add(str);
						}

						product.image = new List<string>();
						foreach (var str in smapsProduct.image.Split(','))
							product.image.Add(str);

						product.image_width = new List<int>();
						foreach (var str in smapsProduct.image_width.Split(','))
							product.image_width.Add(str.ToIntegerNullToZero());

						product.image_height = new List<int>();
						foreach (var str in smapsProduct.image_height.Split(','))
							product.image_height.Add(str.ToIntegerNullToZero());

						product.is_thumbnail = new List<string>();
						foreach (var str in smapsProduct.is_thumbnail.Split(','))
							product.is_thumbnail.Add(str);

						product.is_main = new List<string>();
						foreach (var str in smapsProduct.is_main.Split(','))
							product.is_main.Add(str);

						resultText = ApiHandler.PostForm(product, chkIsTest.Checked);
					}
					else
					{
						resultText = ApiHandler.PostForm(data, chkIsTest.Checked);
					}
					
					var result = resultText.JsonToAnyType<ApiResultModel>();

					if (result.success.ToUpper() == "TRUE")
					{
						switch (apiModel)
						{
							case "SmapsAgency":
								(data as SmapsAgencyModel).uid = result.uid;
								break;
							case "SmapsBrand":
								(data as SmapsBrandModel).uid = result.uid;
								break;
							case "SmapsLookbook":
								(data as SmapsLookbookModel).uid = result.uid;
								break;
							case "SmapsUser":
								(data as SmapsUserModel).uid = result.uid;
								break;
							case "SmapsProduct":
								(data as SmapsProductModel).uid = result.uid;
								break;
						}
					}

					//전송API데이터를 생성한다.
					var model = new ApiRequestModel()
					{
						ApiName = "Smaps",
						ApiType = "S",
						ApiModel = apiModel,
						RequestDate = DateTime.Now,
						Status = (result.success == "true") ? "S" : "F",
						Message = result.msg,
						SendData = JsonConvert.SerializeObject(data),
						ReceiveData = resultText,
						Data = new List<T> { data }
					};

					//API연동한다.
					using (var res = WasHandler.Execute<ApiRequestModel>("Scrap", "Save", "SaveApiRequest", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
					}
				}

				SetMessage("연동되었습니다.");
				SplashUtils.CloseWait();
				DataLoad();
			}
			catch(Exception ex)
			{
				SplashUtils.CloseWait();
				ShowErrBox(ex);
			}
		}

		private void DataReceive<T>(T parameter)
		{
			try
			{
				SplashUtils.ShowWait("데이터를 수신하는 중입니다... 잠시만...");

				var apiModel = typeof(T).Name.Replace("Model", "");
				var result = ApiHandler.Get<T>(chkIsTest.Checked);

				if (result.IsNullOrEmpty() == false)
				{
					var model = new ApiRequestModel()
					{
						ApiName = "Smaps",
						ApiType = "R",
						ApiModel = apiModel,						
						RequestDate = DateTime.Now,
						Status = "S",
						Message = "Success",
						SendData = null,
						ReceiveData = result,
						Data = result.JsonToAnyType<IList<T>>()
					};

					using (var res = WasHandler.Execute<ApiRequestModel>("Scrap", "Save", "SaveApiRequest", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
					}

					SetMessage("연동되었습니다.");
					SplashUtils.CloseWait();
					DataLoad();
				}
			}
			catch (Exception ex)
			{
				SplashUtils.CloseWait();
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				if (lcTab.SelectedTabPage.Name == lcTabGroupMapping.Name)
				{
					if (lcTabMapping.SelectedTabPage.Name == lcGroupMappingBrand.Name)
					{
						DataSaveBrand();
					}
					else if (lcTabMapping.SelectedTabPage.Name == lcGroupMappingCategory.Name)
					{
						DataSaveCategory();
					}
					DataLoad();
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		private void DataSaveCategory()
		{
			try
			{
				var list = gridMappingCategory.GetFilteredData<ScrapCategoryToSmapsModel>().Where(x => x.Checked == "Y").ToList();
				if (list != null && list.Count > 0)
				{
					using (var res = WasHandler.Execute<ScrapCategoryToSmapsModel>("Scrap", "Save", "Insert", list))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
					}
				}
			}
			catch
			{
				throw;
			}
		}
		private void DataSaveBrand()
		{
			try
			{
				var list = gridMappingBrand.GetFilteredData<ScrapBrandToSmapsModel>().Where(x => x.Checked == "Y").ToList();
				if (list != null && list.Count > 0)
				{
					using (var res = WasHandler.Execute<ScrapBrandToSmapsModel>("Scrap", "Save", "Insert", list))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
					}
				}
			}
			catch
			{
				throw;
			}
		}

		private void OptionMatching()
		{
			try
			{
				SplashUtils.ShowWait("처리하는 중입니다... 잠시만...");
				using (var res = WasHandler.Batch("Scrap", "Save", "BatchScrapOption", new DataMap() { { "SiteID", lupScrapSite.EditValue } }))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				SetMessage("처리하였습니다.");
				SplashUtils.CloseWait();
			}
			catch (Exception ex)
			{
				SplashUtils.CloseWait();
				ShowErrBox(ex);
			}
		}

		private void ProductReady()
		{
			try
			{
				if (lupBrand.EditValue == null)
				{
					ShowMsgBox("브랜드를 선택하세요!!!");
					return;
				}

				SplashUtils.ShowWait("처리하는 중입니다... 잠시만...");

				var parameter = new DataMap()
				{
					{ "SiteID", lupScrapSite.EditValue },
					{ "SmapsBrandID", lupBrand.EditValue },
					{ "brand_uid", lupBrand.GetValue(0) }
				};

				using (var res = WasHandler.Batch("Scrap", "Save", "BatchProductReady", parameter))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					
				}

				SplashUtils.CloseWait();
				SetMessage("처리하였습니다.");
				DataLoad();
			}
			catch (Exception ex)
			{
				SplashUtils.CloseWait();
				ShowErrBox(ex);
			}
		}
	}
}