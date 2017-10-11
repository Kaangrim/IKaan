using System;
using DevExpress.Utils;
using IKaan.Base.Map;
using IKaan.Model.Biz.Sales.Shipment;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;

namespace IKaan.Win.View.Biz.Sales.Shipment
{
	public partial class ShipmentListForm : EditForm
	{
		public ShipmentListForm()
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
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
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
			lupStatus.BindData("OrderStatus", "All");

			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "OrderDate", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "OrderNo", Width = 100 },
				new XGridColumn() { FieldName = "StoreID", Visible = false },
				new XGridColumn() { FieldName = "StoreName", Width = 150 },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "ChannelName", Width = 150 },
				new XGridColumn() { FieldName = "MemberID", Visible = false },
				new XGridColumn() { FieldName = "MemberName", Width = 150 },
				new XGridColumn() { FieldName = "TotalOrderQty", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "TotalOrderAmt", Width = 110, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "TotalDiscountAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "TotalCouponAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "TotalDeliveryFee", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "TotalSupplyAmt", Width = 110, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "Status", Visible = false },
				new XGridColumn() { FieldName = "StatusName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "Description", Width = 300 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.ColumnFix("RowNo");
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<ShipmentModel>("Biz", "GetList", "Select", new DataMap()
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
	}
}