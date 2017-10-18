using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Channel;
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
		private DataMap _ChannelSetting = new DataMap();

		public ChannelOrderListForm()
		{
			InitializeComponent();
			
			lupChannelID.EditValueChanged += (object sender, EventArgs e) => { ChangeChannel(); };
			btnFileUpload.Click += (object sender, EventArgs e) => { UploadChannelOrder(); };
			btnBrandMapping.Click += (object sender, EventArgs e) => { BrandMapping(); };
			btnSave.Click += (object sender, EventArgs e) => { SaveOrder(); };
			btnDelete.Click += (object sender, EventArgs e) => { DeleteOrder(); };
			btnApply.Click += (object sender, EventArgs e) => { ApplyOrder(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			datOrderDate.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
			btnSave.Enabled = btnDelete.Enabled = btnApply.Enabled = true;
		}
		protected override void InitControls()
		{
			try
			{
				base.InitControls();

				SetFieldNames();

				lcItemStartLine.SetFieldCaption("시작라인");
				lcItemFileRows.SetFieldCaption("파일건수");
				lcItemSelectBrand.SetFieldCaption("브랜드선택");
				
				datOrderDate.Init(Core.Enum.CalendarViewType.DayView);

				txtStartLine.SetEnable(false);
				txtFileRows.SetEnable(false);

				InitLookup();
				InitGrid();

				lcTab.SelectedTabPageIndex = 0;
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void InitLookup()
		{
			lupChannelID.BindData("ChannelList", "All");
			lupBrandID.BindData("BrandList", "All");
			lupSelectBrand.BindData("BrandList", "==선택하세요==");
		}
		
		void InitGrid()
		{
			try
			{
				gridOrders.Init();
				gridOrders.AddGridColumns(
					new XGridColumn() { FieldName = "RowNo" },
					new XGridColumn() { FieldName = "Checked" },
					new XGridColumn() { FieldName = "Status", Visible = false },
					new XGridColumn() { FieldName = "StatusName", Width = 80, HorzAlignment = HorzAlignment.Center },
					new XGridColumn() { FieldName = "ChannelID", Visible = false },
					new XGridColumn() { FieldName = "ChannelName", Width = 120 },
					new XGridColumn() { FieldName = "OrderDate", Width = 80, HorzAlignment = HorzAlignment.Center },
					new XGridColumn() { FieldName = "OrderNo", Width = 120 },
					new XGridColumn() { FieldName = "OrderSeq", Width = 100 },
					new XGridColumn() { FieldName = "BrandID", Visible = false },
					new XGridColumn() { FieldName = "BrandName", Width = 150 },
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
					new XGridColumn() { FieldName = "DueDate", Width = 100 },
					new XGridColumn() { FieldName = "GiftName", Width = 200 },
					new XGridColumn() { FieldName = "FileUploadID", Width = 80, HorzAlignment = HorzAlignment.Center },
					new XGridColumn() { FieldName = "OrderID", Width = 80, HorzAlignment = HorzAlignment.Center },
					new XGridColumn() { FieldName = "OrderItemID", Width = 80, HorzAlignment = HorzAlignment.Center },
					new XGridColumn() { FieldName = "CreatedOn" },
					new XGridColumn() { FieldName = "CreatedByName" },
					new XGridColumn() { FieldName = "UpdatedOn" },
					new XGridColumn() { FieldName = "UpdatedByName" }
				);
				gridOrders.ColumnFix("RowNo");
				gridOrders.ColumnFix("Checked");
				gridOrders.SetRepositoryItemCheckEdit("Checked");
				gridOrders.SetEditable("Checked");
				gridOrders.RowCellStyle += (object sender, RowCellStyleEventArgs e) =>
				{
					if (e.RowHandle < 0)
						return;

					try
					{
						GridView view = sender as GridView;
						if (e.Column.FieldName == "StatusName")
						{
							switch (view.GetRowCellValue(e.RowHandle, "Status").ToStringNullToEmpty())
							{
								case "0":
									break;
								case "7":
									e.Appearance.ForeColor = Color.Blue;
									break;
								case "8":
									e.Appearance.ForeColor = Color.Gray;
									break;
							}
						}
						else if (e.Column.FieldName.StartsWith("Cancel"))
						{
							if(view.GetRowCellValue(e.RowHandle, "CancelYn").ToStringNullToEmpty() == "Y")
							{
								e.Appearance.BackColor = Color.LightPink;
							}
						}
					}
					catch (Exception ex)
					{
						ShowErrBox(ex);
					}
				};
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
				if (lcTab.SelectedTabPage.Name == lcGroupOrder.Name)
				{
					DataMap parameter = new DataMap()
					{
						{ "OrderDate", datOrderDate.GetDate() },
						{ "ChannelID", lupChannelID.EditValue }
					};
					gridOrders.BindList<ChannelOrderModel>("Live", "GetList", "Select", parameter);
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupCancel.Name)
				{
					DataMap parameter = new DataMap()
					{
						{ "CancelDate", datOrderDate.GetDate() },
						{ "ChannelID", lupChannelID.EditValue }
					};
					gridOrders.BindList<ChannelOrderCancelModel>("Live", "GetList", "Select", parameter);
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupReturn.Name)
				{
					DataMap parameter = new DataMap()
					{
						{ "ReturnDate", datOrderDate.GetDate() },
						{ "ChannelID", lupChannelID.EditValue }
					};
					gridOrders.BindList<ChannelOrderReturnModel>("Live", "GetList", "Select", parameter);
				}
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
				if (_ChannelSetting.GetValue("OrderLine") != null)
					startLine = _ChannelSetting.GetValue("OrderLine").ToIntegerNullToZero();

				var fileName = FileUtils.OpenExcelFile();
				IList<ChannelOrderModel> data = UploadHandler.GetExcelData<ChannelOrderModel>(fileName, startLine);
				if (data == null || data.Count == 0)
					throw new Exception("처리할 내용이 없습니다.");
				txtFileRows.EditValue = data.Count;

				foreach(var line in data)
				{
					if (line.OrderDate == null || line.OrderDate == default(DateTime))
						line.OrderDate = datOrderDate.DateTime;
					if (line.ChannelID == null)
						line.ChannelID = lupChannelID.EditValue.ToIntegerNullToZero();
				}

				if (UploadHandler.Execute(null, fileName, startLine, data))
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
				txtStartLine.Clear();
				txtFileRows.Clear();

				_ChannelSetting = new DataMap();
				if (lupChannelID.EditValue != null)
				{
					var list = WasHandler.GetList<ChannelSettingModel>("Biz", "GetList", "Select", new DataMap() { { "ChannelID", lupChannelID.EditValue } });
					if (list != null && list.Count > 0)
					{
						foreach (var data in list)
							_ChannelSetting.SetValue(data.SettingCode, data.SettingValue);
					}

					if (_ChannelSetting.GetValue("OrderLine") != null)
						txtStartLine.EditValue = _ChannelSetting.GetValue("OrderLine").ToIntegerNullToZero();
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void BrandMapping()
		{
			try
			{
				if (lupSelectBrand.EditValue == null)
				{
					ShowMsgBox("적용할 브랜드를 선택하세요!!!");
					lupSelectBrand.Focus();
					return;
				}

				if (lcTab.SelectedTabPage.Name == lcGroupOrder.Name)
				{
					if (gridOrders.RowCount == 0)
					{
						ShowMsgBox("처리할 건이 없습니다.");
						return;
					}

					for (int i = 0; i < gridOrders.RowCount; i++)
					{
						if (gridOrders.GetValue(i, "Checked").ToStringNullToEmpty() == "Y")
						{
							gridOrders.SetValue(i, "BrandID", lupSelectBrand.EditValue);
							gridOrders.SetValue(i, "BrandName", lupSelectBrand.Text);
						}
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupCancel.Name)
				{
					if (gridCancel.RowCount == 0)
					{
						ShowMsgBox("처리할 건이 없습니다.");
						return;
					}

					for (int i = 0; i < gridCancel.RowCount; i++)
					{
						if (gridCancel.GetValue(i, "Checked").ToStringNullToEmpty() == "Y")
						{
							gridCancel.SetValue(i, "BrandID", lupSelectBrand.EditValue);
							gridCancel.SetValue(i, "BrandName", lupSelectBrand.Text);
						}
					}
				}
				else if (lcTab.SelectedTabPage.Name == lcGroupReturn.Name)
				{
					if (gridReturn.RowCount == 0)
					{
						ShowMsgBox("처리할 건이 없습니다.");
						return;
					}

					for (int i = 0; i < gridReturn.RowCount; i++)
					{
						if (gridReturn.GetValue(i, "Checked").ToStringNullToEmpty() == "Y")
						{
							gridReturn.SetValue(i, "BrandID", lupSelectBrand.EditValue);
							gridReturn.SetValue(i, "BrandName", lupSelectBrand.Text);
						}
					}
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		#region Save
		void Save()
		{
			if (lcTab.SelectedTabPage.Name == lcGroupOrder.Name)
				SaveOrder();
			else if (lcTab.SelectedTabPage.Name == lcGroupCancel.Name)
				SaveCancel();
			else if (lcTab.SelectedTabPage.Name == lcGroupReturn.Name)
				SaveReturn();
		}
		void SaveOrder()
		{
			try
			{
				if (gridOrders.RowCount == 0)
				{
					ShowMsgBox("처리할 건이 없습니다.");
					return;
				}
				var list = gridOrders.GetFilteredData<ChannelOrderModel>().Where(x => x.Checked == "Y" && x.Status == "0").ToList();
				if (list == null || list.Count == 0)
				{
					ShowMsgBox("처리할 건이 없습니다.");
					return;
				}

				using (var res = WasHandler.Execute<ChannelOrderModel>("Live", "Save", "UpdateChannelOrderBrand", list, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("저장하였습니다.");
					DataLoad(null);
				}
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void SaveCancel()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void SaveReturn()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		#endregion

		#region Delete
		void Delete()
		{
			if (lcTab.SelectedTabPage.Name == lcGroupOrder.Name)
				DeleteOrder();
			else if (lcTab.SelectedTabPage.Name == lcGroupCancel.Name)
				DeleteCancel();
			else if (lcTab.SelectedTabPage.Name == lcGroupReturn.Name)
				DeleteReturn();
		}
		void DeleteOrder()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DeleteCancel()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void DeleteReturn()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		#endregion

		#region Apply
		void Apply()
		{
			if (lcTab.SelectedTabPage.Name == lcGroupOrder.Name)
				ApplyOrder();
			else if (lcTab.SelectedTabPage.Name == lcGroupCancel.Name)
				ApplyCancel();
			else if (lcTab.SelectedTabPage.Name == lcGroupReturn.Name)
				ApplyReturn();
		}
		void ApplyOrder()
		{
			try
			{
				var list = gridOrders.GetFilteredData<ChannelOrderModel>().Where(x => x.Checked == "Y" && x.Status == "0").ToList();
				if (list == null || list.Count == 0)
					throw new Exception("처리할 건이 없습니다.");

				using (var res = WasHandler.Execute<ChannelOrderModel>("Live", "Save", "InsertChannelOrderToBizOrder", list, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);
				}
				ShowMsgBox("처리하였습니다.");
				DataLoad(null);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ApplyCancel()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		void ApplyReturn()
		{
			try
			{

			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		#endregion
	}
}