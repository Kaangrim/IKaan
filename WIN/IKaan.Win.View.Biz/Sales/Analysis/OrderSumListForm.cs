﻿using System;
using System.Windows.Forms;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraPivotGrid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Sales.Analysis;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Sales.Analysis
{
	public partial class OrderSumListForm : EditForm
	{
		public OrderSumListForm()
		{
			InitializeComponent();

			btnShowBrandEdit.Click += delegate (object sender, EventArgs e) { ShowBrandEdit(); };
			btnShowChannelEdit.Click += delegate (object sender, EventArgs e) { ShowChannelEdit(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datPeriod.DateFrEdit.Focus();
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

			lupBrandID.BindData("BrandList", "All");
			lupChannelID.BindData("ChannelList", "All");

			datPeriod.DateFrEdit.Init(Core.Enum.CalendarViewType.DayView);
			datPeriod.DateToEdit.Init(Core.Enum.CalendarViewType.DayView);

			InitGrid();
		}

		void InitGrid()
		{
			#region Grid Setting

			PivotGridField fieldBrandName = new PivotGridField("BrandName", PivotArea.RowArea);
			fieldBrandName.Caption = DomainUtils.GetFieldName("BrandName");

			PivotGridField fieldChannelName = new PivotGridField("ChannelName", PivotArea.ColumnArea);
			fieldChannelName.Caption = DomainUtils.GetFieldName("ChannelName");

			PivotGridField fieldOrderQty = new PivotGridField("OrderQty", PivotArea.DataArea);
			fieldOrderQty.Caption = DomainUtils.GetFieldName("OrderQty");
			fieldOrderQty.CellFormat.FormatType = FormatType.Numeric;
			fieldOrderQty.CellFormat.FormatString = "N0";
			fieldOrderQty.Width = 60;

			PivotGridField fieldOrderAmt = new PivotGridField("OrderAmt", PivotArea.DataArea);
			fieldOrderAmt.Caption = DomainUtils.GetFieldName("OrderAmt");
			fieldOrderAmt.CellFormat.FormatType = FormatType.Numeric;
			fieldOrderAmt.CellFormat.FormatString = "N0";
			fieldOrderAmt.Width = 90;

			gridOrder.Fields.AddRange(new PivotGridField[] { fieldBrandName, fieldChannelName, fieldOrderQty, fieldOrderAmt });

			fieldBrandName.AreaIndex = 0;
			fieldChannelName.AreaIndex = 0;

			#endregion

			#region Expected Sales List
			gridSales.Init();
			gridSales.ShowFooter = true;
			gridSales.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40 },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "ChannelName", Width = 120 },
				new XGridColumn() { FieldName = "ChannelManager", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "BrandManager", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "OrderQty", Width = 70, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "OrderAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "ChannelMargin", Width = 70, FormatType = FormatType.Numeric, FormatString = "N2", HorzAlignment = HorzAlignment.Far },
				new XGridColumn() { FieldName = "ChannelAccAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "BrandMargin", Width = 70, FormatType = FormatType.Numeric, FormatString = "N2", HorzAlignment = HorzAlignment.Far },
				new XGridColumn() { FieldName = "BrandAccAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
				new XGridColumn() { FieldName = "SaleMargin", Width = 70, FormatType = FormatType.Numeric, FormatString = "N2", HorzAlignment = HorzAlignment.Far },
				new XGridColumn() { FieldName = "SaleAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum }
			);
			gridSales.ColumnFix("RowNo");
			gridSales.SetMerge("ChannelID", "ChannelName", "ChannelManager", "BrandID", "BrandName", "BrandManager");
			#endregion
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var parameter = new DataMap()
				{
					{ "StartDate", datPeriod.DateFrEdit.GetDate() },
					{ "EndDate", datPeriod.DateToEdit.GetDate() },
					{ "ChannelID", lupChannelID.EditValue },
					{ "BrandID", lupBrandID.EditValue }
				};

				if (lcTab.SelectedTabPage.Name == lcGroupList1.Name)
				{
					var list = WasHandler.GetList<OrderSumModel>("Biz", "GetList", "Select", parameter);
					gridOrder.DataSource = list;
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupList2.Name)
				{
					var list = WasHandler.GetList<OrderSumSalesModel>("Biz", "GetList", "Select", parameter);
					gridSales.DataSource = list;
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void ShowBrandEdit()
		{
			try
			{
				using (var form = new OrderSumBrandEditForm()
				{
					Text = "브랜드별 매출등록",
					StartPosition = FormStartPosition.CenterScreen
				})
				{
					if (form.ShowDialog() == DialogResult.OK)
						DataLoad(null);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		private void ShowChannelEdit()
		{
			try
			{
				using (var form = new OrderSumChannelEditForm()
				{
					Text = "채널별 매출등록",
					StartPosition = FormStartPosition.CenterScreen
				})
				{
					if (form.ShowDialog() == DialogResult.OK)
						DataLoad(null);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}