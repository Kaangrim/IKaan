using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Sales.Order;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Sales.Order
{
	public partial class OrderEditForm : EditForm
	{
		public OrderEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtOrderNo.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemStore.Tag = true;
			lcItemOrderNo.Tag = true;

			SetFieldNames();

			lcGroupItems.Text = DomainUtils.GetFieldName("Items");
			lcGroupNotes.Text = DomainUtils.GetFieldName("Notes");
			lcGroupBillingAddress.Text = DomainUtils.GetFieldName("BillingAddress");
			lcGroupShippingAddress.Text = DomainUtils.GetFieldName("ShippingAddress");

			txtID.SetEnable(false);
			txtOrderNo.SetEnable(false);
			datOrderDate.SetEnable(false);
			lupStoreID.SetEnable(false);
			txtChannel.SetEnable(false);
			txtMember.SetEnable(false);
			spnTotalCouponAmt.SetEnable(false);
			spnTotalDeliveryFee.SetEnable(false);
			spnTotalDiscountAmt.SetEnable(false);
			spnTotalOrderAmt.SetEnable(false);
			spnTotalOrderQty.SetEnable(false);
			spnTotalSupplyAmt.SetEnable(false);
			memDescription.SetEnable(false);
			lupStatus.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			spnTotalCouponAmt.SetFormat("N0", false);
			spnTotalDeliveryFee.SetFormat("N0", false);
			spnTotalDiscountAmt.SetFormat("N0", false);
			spnTotalOrderAmt.SetFormat("N0", false);
			spnTotalOrderQty.SetFormat("N0", false);
			spnTotalSupplyAmt.SetFormat("N0", false);

			lupStoreID.BindData("StoreList");
			lupStatus.BindData("OrderStatus");
			txtChannel.CodeGroup = "ChannelList";
			txtMember.CodeGroup = "MemberList";

			InitGrid();
		}

		void InitGrid()
		{
			gridItems.Init();
			gridItems.AddGridColumns(
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
			gridItems.ColumnFix("RowNo");

			gridNotes.Init();
			gridNotes.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "OrderID", Visible = false },
				new XGridColumn() { FieldName = "Note", Width = 300 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridNotes.ColumnFix("RowNo");

			gridNotes.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
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
		}

		protected override void DataInit()
		{
			ClearControlData<OrderModel>();
			txtChannel.Clear();
			txtMember.Clear();

			gridItems.Clear<OrderItemModel>();
			gridNotes.Clear<OrderNoteModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtOrderNo.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<OrderModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);
				if (model != null)
				{
					txtChannel.EditText = model.ChannelName;
					txtChannel.EditValue = model.ChannelID;
					txtMember.EditText = model.MemberName;
					txtMember.EditValue = model.MemberID;

					gridItems.DataSource = model.Items;
					gridNotes.DataSource = model.Notes;
				}

				SetToolbarButtons(new ToolbarButtons() { New = true, Save = true, SaveAndClose = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtOrderNo.Focus();

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<OrderModel>();

				using (var res = WasHandler.Execute<OrderModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					callback(arg, res.Result.ReturnValue);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteStore", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					callback(arg, null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void ShowEdit(object data = null)
		{
			if (lcTab.SelectedTabPage.Name == lcGroupNotes.Name)
			{
				using(var form = new OrderNoteEditForm())
				{
					form.Text = "주문비고";
					form.StartPosition = FormStartPosition.CenterScreen;
					form.IsLoadingRefresh = true;
					form.ParamsData = this.ParamsData;
					if (form.ShowDialog() == DialogResult.OK)
						DataLoad();
				}
			}
		}
	}
}