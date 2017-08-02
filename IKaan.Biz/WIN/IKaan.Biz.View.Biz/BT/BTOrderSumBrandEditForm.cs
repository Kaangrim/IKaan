using System;
using System.Collections.Generic;
using DevExpress.Data;
using DevExpress.Utils;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BT;

namespace IKaan.Biz.View.Biz.BT
{
	public partial class BTOrderSumBrandEditForm : EditForm
	{
		public BTOrderSumBrandEditForm()
		{
			InitializeComponent();

			txtBrandID.EditValueChanged += delegate (object value)
			{
				if (value != null)
					DataLoad(null);
				else
					DataInit();
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);			
			txtBrandID.Focus();
		}
		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			lcItemBrand.Tag = true;

			SetFieldNames();

			datOrderDate.Init(CalendarViewType.DayView);
			txtBrandID.CodeGroup = "BrandList";

			InitGrid();
		}

		private void InitGrid()
		{
			gridList.Init();
			gridList.ShowFooter = true;
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "OrderDate", Visible = false },
				new XGridColumn() { FieldName = "ChannelName", Width = 200 },
				new XGridColumn() { FieldName = "OrderQty", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "OrderAmt", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0", SummaryItemType = SummaryItemType.Sum, IsSummary = true },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridList.ColumnFix("RowNo");
			gridList.SetRepositoryItemSpinEdit("OrderQty", "N0", null, true, HorzAlignment.Far);
			gridList.SetRepositoryItemSpinEdit("OrderAmt", "N0", null, true, HorzAlignment.Far);
			gridList.SetEditable("OrderQty", "OrderAmt");
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				DataMap parameter = new DataMap()
				{
					{ "BrandID", txtBrandID.EditValue },
					{ "OrderDate", datOrderDate.GetDate() }
				};

				gridList.BindList<BTOrderSum>("BT", "GetList", "SelectBTOrderSumListByBrand", parameter);

				SetToolbarButtons(new ToolbarButtons() { Refresh = true, New = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBrandID.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataInit()
		{
			gridList.Clear<BTOrderSum>();

			SetToolbarButtons(new ToolbarButtons() { Refresh = true, New = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtBrandID.Focus();
		}
		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				if (txtBrandID.EditValue == null)
				{
					throw new Exception("브랜드를 선택해야 합니다.");
				}
				if (datOrderDate.EditValue == null)
				{
					throw new Exception("주문일자를 입력하세요!!!");
				}
				if (gridList.DataSource == null || gridList.RowCount == 0)
				{
					throw new Exception("처리할 건이 없습니다.");
				}

				gridList.PostEditor();
				gridList.UpdateCurrentRow();

				BTOrderSumByBrand model = new BTOrderSumByBrand()
				{
					BrandID = txtBrandID.EditValue.ToIntegerNullToZero(),
					OrderDate = datOrderDate.GetDate(),
					OrderSumList = gridList.DataSource as List<BTOrderSum>
				};

				using (var res = WasHandler.Execute<BTOrderSumByBrand>("BT", "Save", "SaveOrderSum", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					DataLoad(null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		protected override void DataDelete(object arg, DeleteCallback callback)
		{
			try
			{
				DataMap map = new DataMap()
				{
					{ "BrandID", txtBrandID.EditValue },
					{ "OrderDate", datOrderDate.GetDate() }
				};
				using (var res = WasHandler.Execute<DataMap>("BT", "Delete", "DeleteBTOrderSumByBrand", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					DataLoad(null);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}