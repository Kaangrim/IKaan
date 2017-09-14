using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using DevExpress.XtraLayout.Utils;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Scrap.Smaps;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Scrap.Interface
{
	public partial class SmapsInterfaceForm : EditForm
	{
		public SmapsInterfaceForm()
		{
			InitializeComponent();

			lcTabList.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				if (e.Page.Name == lcGroupAgency.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
				}
				else if (e.Page.Name == lcGroupBrand.Name)
				{
					lcItemSmapsAgency.Visibility = LayoutVisibility.Always;
					lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
				}
				else if (e.Page.Name == lcGroupCategory.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
				}
				else if (e.Page.Name == lcGroupColor.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
				}
				else if (e.Page.Name == lcGroupLookbook.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility = LayoutVisibility.Always;
					lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
				}
				else if (e.Page.Name == lcGroupProduct.Name)
				{
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Always;
				}
				else if (e.Page.Name == lcGroupSize.Name)
				{
					lcItemSmapsCategory.Visibility =
					lcItemSmapsSex.Visibility = LayoutVisibility.Always;
					lcItemSmapsAgency.Visibility =
						lcItemSmapsBrand.Visibility =
						lcItemSmapsLookbook.Visibility = LayoutVisibility.Never;
				}
				else if (e.Page.Name == lcGroupSmapsUser.Name)
				{
					lcItemSmapsAgency.Visibility = LayoutVisibility.Always;
					lcItemSmapsBrand.Visibility =
						lcItemSmapsLookbook.Visibility =
						lcItemSmapsCategory.Visibility =
						lcItemSmapsSex.Visibility = LayoutVisibility.Never;
				}
			};

			btnSend.Click += (object sender, EventArgs e) =>
			{
				if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
				{
					DataInterface<SmapsCategoryModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupColor.Name)
				{
					DataInterface<SmapsColorModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupSize.Name)
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

					DataInterface(new SmapsSizeModel()
					{
						category_uid = lupCategory.EditValue.ToIntegerNullToZero(),
						sex = lupSex.EditValue.ToStringNullToEmpty()
					});
				}
			};
			btnReceive.Click += (object sender, EventArgs e) =>
			{
				if (lcTabList.SelectedTabPage.Name == lcGroupAgency.Name)
				{
					DataReceive<SmapsAgencyModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupBrand.Name)
				{
					DataReceive<SmapsBrandModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupLookbook.Name)
				{
					DataReceive<SmapsLookbookModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
				{
					DataReceive<SmapsCategoryModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupColor.Name)
				{
					DataReceive<SmapsColorModel>(null);
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupSize.Name)
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
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lcGroupAgency.Text = DomainUtils.GetFieldName("SmapsAgency");
			lcGroupBrand.Text = DomainUtils.GetFieldName("SmapsBrand");
			lcGroupCategory.Text = DomainUtils.GetFieldName("SmapsCategory");
			lcGroupLookbook.Text = DomainUtils.GetFieldName("SmapsLookbook");
			lcGroupColor.Text = DomainUtils.GetFieldName("SmapsColor");
			lcGroupSize.Text = DomainUtils.GetFieldName("SmapsSize");
			lcGroupProduct.Text = DomainUtils.GetFieldName("SmapsProduct");
			lcGroupSmapsUser.Text = DomainUtils.GetFieldName("SmapsUser");

			lupAgency.BindData("SmapsAgency", "All");
			lupBrand.BindData("SmapsBrand", "All");
			lupLookbook.BindData("SmapsLookbook", "All");
			lupCategory.BindData("SmapsCategory", "All");
			lupSex.BindData("SmapsSex", "All");
			lupStatus.BindData("SmapsStatus", "All");

			InitGrid();

			lcTabList.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region Agency
			gridAgencyList.Init();
			gridAgencyList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "type" },
				new XGridColumn() { FieldName = "grade" },
				new XGridColumn() { FieldName = "name" },
				new XGridColumn() { FieldName = "recommend" },
				new XGridColumn() { FieldName = "sv_start_date" },
				new XGridColumn() { FieldName = "sv_end_date" },
				new XGridColumn() { FieldName = "cp_address" },
				new XGridColumn() { FieldName = "president_name" },
				new XGridColumn() { FieldName = "cp_crn" },
				new XGridColumn() { FieldName = "cp_email" },
				new XGridColumn() { FieldName = "cp_homepage" },
				new XGridColumn() { FieldName = "cp_intro" },
				new XGridColumn() { FieldName = "cp_tel" },
				new XGridColumn() { FieldName = "ct_department" },
				new XGridColumn() { FieldName = "ct_email" },
				new XGridColumn() { FieldName = "ct_fax" },
				new XGridColumn() { FieldName = "ct_hphone" },
				new XGridColumn() { FieldName = "ct_name" },
				new XGridColumn() { FieldName = "ct_position" },
				new XGridColumn() { FieldName = "ct_tel" },
				new XGridColumn() { FieldName = "consultation" },
				new XGridColumn() { FieldName = "using_price" },
				new XGridColumn() { FieldName = "image" },
				new XGridColumn() { FieldName = "image_width" },
				new XGridColumn() { FieldName = "image_height" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridAgencyList.ColumnFix("RowNo");

			gridAgencyList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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

			#region Brand
			gridBrandList.Init();
			gridBrandList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "name" },
				new XGridColumn() { FieldName = "manager" },
				new XGridColumn() { FieldName = "showroom" },
				new XGridColumn() { FieldName = "agency_uid" },
				new XGridColumn() { FieldName = "caption" },
				new XGridColumn() { FieldName = "image" },
				new XGridColumn() { FieldName = "image_width" },
				new XGridColumn() { FieldName = "image_height" },
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
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "name" },
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
				new XGridColumn() { FieldName = "value" },
				new XGridColumn() { FieldName = "text" },
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

			#region Lookbook
			gridLookbookList.Init();
			gridLookbookList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "agency_uid" },
				new XGridColumn() { FieldName = "brand_uid" },
				new XGridColumn() { FieldName = "title" },
				new XGridColumn() { FieldName = "marketing" },
				new XGridColumn() { FieldName = "active_date_start" },
				new XGridColumn() { FieldName = "active_date_end" },
				new XGridColumn() { FieldName = "notice" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridLookbookList.ColumnFix("RowNo");

			gridLookbookList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "agency_uid" },
				new XGridColumn() { FieldName = "brand_uid" },
				new XGridColumn() { FieldName = "lookbook_uid" },
				new XGridColumn() { FieldName = "product_name" },
				new XGridColumn() { FieldName = "product_number" },
				new XGridColumn() { FieldName = "product_price" },
				new XGridColumn() { FieldName = "product_unset_price" },
				new XGridColumn() { FieldName = "category_uid" },
				new XGridColumn() { FieldName = "sex" },
				new XGridColumn() { FieldName = "memo" },
				new XGridColumn() { FieldName = "caution" },
				new XGridColumn() { FieldName = "tag" },
				new XGridColumn() { FieldName = "option" },
				new XGridColumn() { FieldName = "option_size_uid" },
				new XGridColumn() { FieldName = "option_size_view" },
				new XGridColumn() { FieldName = "option_color" },
				new XGridColumn() { FieldName = "option_color_view" },
				new XGridColumn() { FieldName = "option_add_date" },
				new XGridColumn() { FieldName = "image" },
				new XGridColumn() { FieldName = "image_width" },
				new XGridColumn() { FieldName = "image_height" },
				new XGridColumn() { FieldName = "is_thumbnail" },
				new XGridColumn() { FieldName = "is_main" },
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
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "text" },
				new XGridColumn() { FieldName = "category_uid" },
				new XGridColumn() { FieldName = "sex" },
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

			#region User
			gridUserList.Init();
			gridUserList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "uid" },
				new XGridColumn() { FieldName = "email" },
				new XGridColumn() { FieldName = "name" },
				new XGridColumn() { FieldName = "agency_uid" },
				new XGridColumn() { FieldName = "passwd" },
				new XGridColumn() { FieldName = "phone1" },
				new XGridColumn() { FieldName = "phone2" },
				new XGridColumn() { FieldName = "phone3" },
				new XGridColumn() { FieldName = "introduce" },
				new XGridColumn() { FieldName = "rank" },
				new XGridColumn() { FieldName = "image" },
				new XGridColumn() { FieldName = "image_width" },
				new XGridColumn() { FieldName = "image_height" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridUserList.ColumnFix("RowNo");
			gridUserList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
				if (lcTabList.SelectedTabPage.Name == lcGroupAgency.Name)
				{
					gridAgencyList.BindList<SmapsAgencyModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupBrand.Name)
				{
					gridBrandList.BindList<SmapsBrandModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "AgencyUid", lupAgency.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupCategory.Name)
				{
					gridCategoryList.BindList<SmapsCategoryModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupColor.Name)
				{
					gridColorList.BindList<SmapsColorModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupLookbook.Name)
				{
					gridLookbookList.BindList<SmapsLookbookModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "AgencyUid", lupAgency.EditValue },
						{ "BrandUid", lupBrand.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupProduct.Name)
				{
					gridProductList.BindList<SmapsProductModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "AgencyUid", lupAgency.EditValue },
						{ "BrandUid", lupBrand.EditValue },
						{ "LookbookUid", lupLookbook.EditValue },
						{ "CategoryUid", lupCategory.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupSize.Name)
				{
					gridSizeList.BindList<SmapsSizeModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "CategoryUid", lupCategory.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
				else if (lcTabList.SelectedTabPage.Name == lcGroupSmapsUser.Name)
				{
					gridSizeList.BindList<SmapsUserModel>("Scrap", "GetList", "Select", new DataMap()
					{
						{ "AgencyUid", lupAgency.EditValue },
						{ "FindText", txtFindText.EditValue },
						{ "Status", lupStatus.EditValue }
					});
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		
		private void DataInterface<T>(T parameter)
		{
			try
			{
				var requestType = typeof(T).Name.Replace("Model", "");
				string result = string.Empty;

				switch (requestType)
				{
					case "SmapsCategory":
					case "SmapsColor":
						result = ApiHandler.Get<T>();
						break;
					case "SmapsAgency":
					case "SmapsBrand":
					case "SmapsLookbook":
					case "SmapsUser":
					case "SmapsProduct":
					case "SmapsSize":
						result = ApiHandler.Post<T>(parameter);
						break;
				}

				if (result.IsNullOrEmpty() == false)
				{
					var list = result.JsonToAnyType<IList<T>>();
					var model = new SmapsRequestModel()
					{
						RequestType = requestType,
						RequestDate = DateTime.Now,
						Status = "Received",
						RequestText = null,
						ReturnText = result,
						Data = list
					};
					using (var res = WasHandler.Execute<SmapsRequestModel>("Scrap", "Save", "SaveSmapsRequest", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						SetMessage("연동되었습니다.");
						DataLoad();
					}
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void DataReceive<T>(T parameter)
		{
			try
			{
				var requestType = typeof(T).Name.Replace("Model", "");
				string result = ApiHandler.Get<T>();

				//switch (requestType)
				//{
				//	case "SmapsCategory":
				//	case "SmapsColor":
				//		result = ApiHandler.Get<T>();
				//		break;
				//	case "SmapsAgency":
				//	case "SmapsBrand":
				//	case "SmapsLookbook":
				//	case "SmapsUser":
				//	case "SmapsProduct":
				//	case "SmapsSize":
				//		result = ApiHandler.Post<T>(parameter);
				//		break;
				//}

				if (result.IsNullOrEmpty() == false)
				{
					var list = result.JsonToAnyType<IList<T>>();
					var model = new SmapsRequestModel()
					{
						RequestType = requestType,
						RequestDate = DateTime.Now,
						Status = "Received",
						RequestText = null,
						ReturnText = result,
						Data = list
					};
					using (var res = WasHandler.Execute<SmapsRequestModel>("Scrap", "Save", "SaveSmapsRequest", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						SetMessage("연동되었습니다.");
						DataLoad();
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}