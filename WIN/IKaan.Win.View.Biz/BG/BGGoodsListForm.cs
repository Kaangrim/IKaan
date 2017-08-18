using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Layout;
using DevExpress.XtraLayout.Customization;
using DevExpress.XtraLayout.Utils;
using IKaan.Base.Map;
using IKaan.Model.BIZ.BG;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.BG
{
	public partial class BGGoodsListForm : EditForm
	{
		public BGGoodsListForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
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
			#region Goods List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "GoodsCode", Width = 100 },
				new XGridColumn() { FieldName = "GoodsName", Width = 200 },
				new XGridColumn() { FieldName = "BrandID", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "CategoryID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "CategoryName", Width = 200 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
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
					gridList.BindList<BGGoods>("BG", "GetList", "SelectBGGoodsList", new DataMap()
					{
						{ "FindText", txtFindText.EditValue },
						{ "GoodsNo", txtGoodsCode.EditValue },
						{ "GoodsName", txtGoodsName.EditValue },
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
					wbList.Navigate(string.Format("{0}{1}", GlobalVar.ServerInfo.ServerUrl, "Biz/GoodsList"));	
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void ShowEdit(object data = null)
		{
			using (var form = new BGGoodsEditForm()
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