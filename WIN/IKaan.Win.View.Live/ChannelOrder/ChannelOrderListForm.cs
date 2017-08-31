using System;
using DevExpress.Data;
using DevExpress.Utils;
using IKaan.Base.Map;
using IKaan.Model.Biz;
using IKaan.Model.Live;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Live.ChannelOrder
{
	public partial class ChannelOrderListForm : EditForm
	{
		private ChannelSettingModel channelSetting = null;

		public ChannelOrderListForm()
		{
			InitializeComponent();
			
			lupChannelID.EditValueChanged += (object sender, EventArgs e) => { ChangeChannel(); };
			btnFileUpload.Click += (object sender, EventArgs e) => { UploadChannelOrder(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datOrderDate.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true });
		}
		protected override void InitControls()
		{
			try
			{
				base.InitControls();

				SetFieldNames();

				lupChannelID.BindData("ChannelList", "All");
				datOrderDate.Init(Core.Enum.CalendarViewType.DayView);

				InitGrid();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		
		void InitGrid()
		{
			try
			{
				gridList.Init();
				gridList.AddGridColumns(
					new XGridColumn() { FieldName = "Checked" },
					new XGridColumn() { FieldName = "RowNo" },
					new XGridColumn() { FieldName = "ChannelID", Visible = false },
					new XGridColumn() { FieldName = "ChannelName", Width = 120 },
					new XGridColumn() { FieldName = "OrderDate", Width = 80, HorzAlignment = HorzAlignment.Center },
					new XGridColumn() { FieldName = "OrderNo", Width = 120 },
					new XGridColumn() { FieldName = "OrderSeq", Width = 100 },
					new XGridColumn() { FieldName = "GoodsCode", Width = 100 },
					new XGridColumn() { FieldName = "GoodsName", Width = 200 },
					new XGridColumn() { FieldName = "Option1", Width = 100 },
					new XGridColumn() { FieldName = "Option2", Width = 100 },
					new XGridColumn() { FieldName = "Orderer", Width = 100 },
					new XGridColumn() { FieldName = "OrdererEmail", Width = 150 },
					new XGridColumn() { FieldName = "OrdererMobile", Width = 100 },
					new XGridColumn() { FieldName = "OrdererTelNo", Width = 100 },
					new XGridColumn() { FieldName = "Recipient", Width = 100 },
					new XGridColumn() { FieldName = "RecipientMobile", Width = 100 },
					new XGridColumn() { FieldName = "RecipientTelNo", Width = 100 },
					new XGridColumn() { FieldName = "PostalCode", Width = 100 },
					new XGridColumn() { FieldName = "RecipientAddress", Width = 200 },
					new XGridColumn() { FieldName = "Description", Width = 200 },
					new XGridColumn() { FieldName = "OrderQty", Width = 70, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "SupplyPrice", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "SupplyAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "SalePrice", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "SaleAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "DeliveryFee", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "BrandAccAmt", Width = 100, FormatType = FormatType.Numeric, FormatString = "N0", HorzAlignment = HorzAlignment.Far, IsSummary = true, SummaryItemType = SummaryItemType.Sum },
					new XGridColumn() { FieldName = "CouponAmt", Width = 70, FormatType = FormatType.Numeric, FormatString = "N2", HorzAlignment = HorzAlignment.Far },
					new XGridColumn() { FieldName = "DealNo", Width = 100 },
					new XGridColumn() { FieldName = "BrandID", Width = 100 },
					new XGridColumn() { FieldName = "BrandName", Width = 150 },
					new XGridColumn() { FieldName = "DueDate", Width = 100 },
					new XGridColumn() { FieldName = "GiftName", Width = 200 },
					new XGridColumn() { FieldName = "FileUploadID", Width = 80 },
					new XGridColumn() { FieldName = "CreatedOn" },
					new XGridColumn() { FieldName = "CreatedByName" },
					new XGridColumn() { FieldName = "UpdatedOn" },
					new XGridColumn() { FieldName = "UpdatedByName" }
				);
				gridList.ColumnFix("RowNo");
				gridList.ColumnFix("Checked");
				gridList.SetRepositoryItemCheckEdit("Checked");
				gridList.SetEditable("Checked");
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				DataMap parameter = new DataMap()
				{
					{ "OrderDate", datOrderDate.GetDate() },
					{ "ChannelID", lupChannelID.EditValue }
				};
				gridList.BindList<ChannelOrderModel>("Live", "GetList", "Select", parameter);
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void UploadChannelOrder()
		{
			try
			{
				if (lupChannelID.EditValue == null)
				{
					ShowMsgBox("채널을 먼저 선택해야 합니다.");
					return;
				}

				int startLine = 2;
				if (channelSetting != null)
				{
					startLine = channelSetting.OrderLine;
				}

				var addData = new DataMap()
				{
					{ "ChannelID", lupChannelID.EditValue },
					{ "OrderDate", datOrderDate.DateTime }
				};
				if (UploadHandler.Execute<ChannelOrderModel>(null, null, startLine, addData))
				{
					ShowMsgBox("저장하였습니다.");
					DataLoad(null);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void ChangeChannel()
		{
			try
			{
				if (lupChannelID.EditValue == null)
				{
					channelSetting = null;
				}
				else
				{
					var list = WasHandler.GetList<ChannelSettingModel>("Biz", "GetList", "Select", new DataMap() { { "ChannelID", lupChannelID.EditValue } });
					if (list == null)
						throw new Exception("조회할 데이터가 없습니다.");

					channelSetting = list[0];
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}