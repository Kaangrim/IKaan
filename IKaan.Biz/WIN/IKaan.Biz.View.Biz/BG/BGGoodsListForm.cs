﻿using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Model.BIZ.BG;

namespace IKaan.Biz.View.Biz.BG
{
	public partial class BGGoodsListForm : EditForm
	{
		public BGGoodsListForm()
		{
			InitializeComponent();

			lupGridType.EditValueChanged += delegate (object sender, EventArgs e)
			{
				if (lupGridType.EditValue.ToString().ToUpper() == "LIST")
					gridList.GridViewType = GridViewType.GridView;
				else if (lupGridType.EditValue.ToString().ToUpper() == "CARD")
					gridList.GridViewType = GridViewType.CardView;
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
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
			lupBrandID.BindData("BrandList", "All");
			lupCategoryID.BindData("CategoryList", "All");
			lupAge.BindData("Age", "All");
			lupGender.BindData("Gender", "All");
			lupSeason.BindData("Season", "All");
			lupOrigin.BindData("Country", "All");
			lupUseYn.BindData("Yn", "All");
			lupAbroadYn.BindData("Yn", "All");
			lupGridType.BindData("GridType");
		}

		void InitGrid()
		{
			#region Goods List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "GoodsNo", Width = 200 },
				new XGridColumn() { FieldName = "GoodsName", Width = 200 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
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
			gridList.BindList<BGGoods>("LG", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "GoodsNo", txtGoodsNo.EditValue },
				{ "GoodsName", txtGoodsName.EditValue },
				{ "CategoryID", lupCategoryID.EditValue },
				{ "BrandID", lupBrandID.EditValue },
				{ "Age", lupAge.EditValue },
				{ "Gender", lupGender.EditValue },
				{ "Season", lupSeason.EditValue },
				{ "Origin", lupOrigin.EditValue },
				{ "UseYn", lupUseYn.EditValue },
				{ "AbroadYn", lupAbroadYn.EditValue }
			});
		}

		protected override void ShowEdit(object data = null)
		{
			using (var form = new BGGoodsEditForm()
			{
				Text = "상품등록",
				StartPosition = FormStartPosition.CenterScreen,
				ParamsData = data
			})
			{
				if (form.ShowDialog() == DialogResult.OK)
					DataLoad(null);
			}
		}
	}
}