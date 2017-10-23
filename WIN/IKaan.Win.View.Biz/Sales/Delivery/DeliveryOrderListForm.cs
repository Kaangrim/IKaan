using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Sales.Delivery;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;

namespace IKaan.Win.View.Biz.Sales.Delivery
{
	public partial class DeliveryOrderListForm : EditForm
	{
		public DeliveryOrderListForm()
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

			datStartDate.Init(Core.Enum.CalendarViewType.DayView);
			datEndDate.Init(Core.Enum.CalendarViewType.DayView);

			lupStoreID.BindData("StoreList", "All");
			lupBrandID.BindData("BrandList", "All");
			lupChannelID.BindData("ChannelList", "All");
			lupMemberID.BindData("MemberList", "All");
			lupStatus.BindData("DeliveryOrderStatus", "All");

			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "OrderDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "OrderNo", Width = 100 },
				new XGridColumn() { FieldName = "StoreID", Visible = false },
				new XGridColumn() { FieldName = "StoreName", Width = 150 },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "ChannelName", Width = 150 },
				new XGridColumn() { FieldName = "MemberID", Visible = false },
				new XGridColumn() { FieldName = "MemberName", Width = 150 },
				new XGridColumn() { FieldName = "Status", Visible = false },
				new XGridColumn() { FieldName = "StatusName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Description", Width = 300 },
				new XGridColumn() { FieldName = "OrderItemID", Visible = false },
				new XGridColumn() { FieldName = "OrderItemNo", Width = 50, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ProductID", Visible = false },
				new XGridColumn() { FieldName = "ProductName", Width = 300 },
				new XGridColumn() { FieldName = "ProductCode", Width = 100 },
				new XGridColumn() { FieldName = "Option1", Width = 100 },
				new XGridColumn() { FieldName = "Option2", Width = 100 },
				new XGridColumn() { FieldName = "Bundle", Width = 200 },
				new XGridColumn() { FieldName = "SalePrice", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "OrderQty", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },	
				new XGridColumn() { FieldName = "OrderAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "DiscountAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "CouponAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "DeliveryFee", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "SupplyPrice", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SupplyAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "ShippedQty", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = DevExpress.Data.SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "CancelYn", Width = 60, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CancelDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ChannelOrderSeq", Width = 80 },
				new XGridColumn() { FieldName = "Currency", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LocalSalePrice", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.ColumnFix("RowNo");
			gridList.ColumnFix("Checked");
			gridList.SetRepositoryItemCheckEdit("Checked");
			gridList.SetRepositoryItemCheckEdit("CancelYn");
			gridList.SetMerge("OrderNo", "OrderDate", "StoreID", "StoreName", "ChannelID", "ChannelName", "MemberID", "MemberName", "Descriptoiin");

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
			gridList.BindList<DeliveryOrderListModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "StoreID", lupStoreID.EditValue },
				{ "BrandID", lupBrandID.EditValue },
				{ "ChannelID", lupChannelID.EditValue },
				{ "MemberID", lupMemberID.EditValue },
				{ "StartDate", datStartDate.EditValue },
				{ "EndDate", datEndDate.EditValue },
				{ "FindText", txtFindText.EditValue },
				{ "Status", lupStatus.EditValue }
			});
		}

		protected override void ActNew()
		{
			ShowEdit(null);
		}

		protected override void ShowEdit(object data = null)
		{
			//using(var form = new OrderEditForm())
			//{
			//	form.Text = "주문조회 및 수정";
			//	form.StartPosition = FormStartPosition.CenterScreen;
			//	form.IsLoadingRefresh = true;
			//	form.ParamsData = data;
			//	if (form.ShowDialog() == DialogResult.OK)
			//		DataLoad();
			//}
		}
	}
}