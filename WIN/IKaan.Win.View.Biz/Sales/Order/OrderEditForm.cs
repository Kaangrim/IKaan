using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Model.Biz.Sales.Address;
using IKaan.Model.Biz.Sales.Order;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.PostalCode;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Sales.Order
{
	public partial class OrderEditForm : EditForm
	{
		object baID = null;
		object saID = null;
		object baAddressID = null;
		object saAddressID = null;

		public OrderEditForm()
		{
			InitializeComponent();

			txtBAPostalCode.ButtonClick += (object sender, ButtonPressedEventArgs e)=>
			{
				if (e.Button.Kind == ButtonPredefines.Ellipsis)
				{
					var data = SearchPostalCode.Find();
					if (data != null)
					{
						if (data.PostalNo.IsNullOrEmpty())
							txtBAPostalCode.EditValue = data.ZoneCode;
						else
							txtBAPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtBAAddressLine1.EditValue = data.Address1;
						txtBAAddressLine2.EditValue = data.Address2;

						lupBACountry.EditValue = "KOR";
						if (data.Address1.IsNullOrEmpty() == false)
						{
							var address = data.Address1.Split(' ');
							if (address != null && address.Length > 0)
							{
								txtBACity.EditValue = address[0].ToStringNullToEmpty();
								txtBAStateProvince.EditValue = address[1].ToStringNullToEmpty();
							}
						}
					}
				}
			};
			txtSAPostalCode.ButtonClick += (object sender, ButtonPressedEventArgs e) =>
			{
				if (e.Button.Kind == ButtonPredefines.Ellipsis)
				{
					var data = SearchPostalCode.Find();
					if (data != null)
					{
						if (data.PostalNo.IsNullOrEmpty())
							txtSAPostalCode.EditValue = data.ZoneCode;
						else
							txtSAPostalCode.EditValue = data.ZoneCode + "(" + data.PostalNo + ")";
						txtSAAddressLine1.EditValue = data.Address1;
						txtSAAddressLine2.EditValue = data.Address2;

						lupSACountry.EditValue = "KOR";
						if (data.Address1.IsNullOrEmpty() == false)
						{
							var address = data.Address1.Split(' ');
							if (address != null && address.Length > 0)
							{
								txtSACity.EditValue = address[0].ToStringNullToEmpty();
								txtSAStateProvince.EditValue = address[1].ToStringNullToEmpty();
							}
						}
					}
				}
			};
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

			lupBACountry.BindData("Country");
			lupSACountry.BindData("Country");

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

					txtBAName.EditValue = model.BillingAddress.Name;
					txtBAEmail.EditValue = model.BillingAddress.Email;
					txtBAPhoneNo.EditValue = model.BillingAddress.PhoneNo;
					txtBAMobileNo.EditValue = model.BillingAddress.MobileNo;
					txtBAFaxNo.EditValue = model.BillingAddress.FaxNo;
					txtBAPostalCode.EditValue = model.BillingAddress.Address.PostalCode;
					lupBACountry.EditValue = model.BillingAddress.Address.Country;
					txtBACity.EditValue = model.BillingAddress.Address.City;
					txtBAStateProvince.EditValue = model.BillingAddress.Address.StateProvince;
					txtBAAddressLine1.EditValue = model.BillingAddress.Address.AddressLine1;
					txtBAAddressLine2.EditValue = model.BillingAddress.Address.AddressLine2;

					txtSAName.EditValue = model.ShippingAddress.Name;
					txtSAEmail.EditValue = model.ShippingAddress.Email;
					txtSAPhoneNo.EditValue = model.ShippingAddress.PhoneNo;
					txtSAMobileNo.EditValue = model.ShippingAddress.MobileNo;
					txtSAFaxNo.EditValue = model.ShippingAddress.FaxNo;
					txtSAPostalCode.EditValue = model.ShippingAddress.Address.PostalCode;
					lupSACountry.EditValue = model.ShippingAddress.Address.Country;
					txtSACity.EditValue = model.ShippingAddress.Address.City;
					txtSAStateProvince.EditValue = model.ShippingAddress.Address.StateProvince;
					txtSAAddressLine1.EditValue = model.ShippingAddress.Address.AddressLine1;
					txtSAAddressLine2.EditValue = model.ShippingAddress.Address.AddressLine2;

					baID = model.BillingAddressID;
					baAddressID = model.BillingAddress.AddressID;
					saID = model.ShippingAddressID;
					saAddressID = model.ShippingAddress.AddressID;
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
				model.BillingAddress = new BillingAddressModel()
				{
					ID = baID.ToIntegerNullToNull(),
					Name = txtBAName.EditValue.ToStringNullToNull(),
					Email = txtBAEmail.EditValue.ToStringNullToNull(),
					PhoneNo = txtBAPhoneNo.EditValue.ToStringNullToNull(),
					MobileNo = txtBAMobileNo.EditValue.ToStringNullToNull(),
					FaxNo = txtBAFaxNo.EditValue.ToStringNullToNull(),
					AddressID = baAddressID.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = baAddressID.ToIntegerNullToNull(),
						PostalCode = txtBAPostalCode.EditValue.ToStringNullToNull(),
						Country = lupBACountry.EditValue.ToStringNullToNull(),
						City = txtBACity.EditValue.ToStringNullToNull(),
						StateProvince = txtBAStateProvince.EditValue.ToStringNullToNull(),
						AddressLine1 = txtBAAddressLine1.EditValue.ToStringNullToNull(),
						AddressLine2 = txtBAAddressLine2.EditValue.ToStringNullToNull()
					}
				};
				model.ShippingAddress = new ShippingAddressModel()
				{
					ID = saID.ToIntegerNullToNull(),
					Name = txtSAName.EditValue.ToStringNullToNull(),
					Email = txtSAEmail.EditValue.ToStringNullToNull(),
					PhoneNo = txtSAPhoneNo.EditValue.ToStringNullToNull(),
					MobileNo = txtSAMobileNo.EditValue.ToStringNullToNull(),
					FaxNo = txtSAFaxNo.EditValue.ToStringNullToNull(),
					AddressID = saAddressID.ToIntegerNullToNull(),
					Address = new AddressModel()
					{
						ID = saAddressID.ToIntegerNullToNull(),
						PostalCode = txtSAPostalCode.EditValue.ToStringNullToNull(),
						Country = lupSACountry.EditValue.ToStringNullToNull(),
						City = txtSACity.EditValue.ToStringNullToNull(),
						StateProvince = txtSAStateProvince.EditValue.ToStringNullToNull(),
						AddressLine1 = txtSAAddressLine1.EditValue.ToStringNullToNull(),
						AddressLine2 = txtSAAddressLine2.EditValue.ToStringNullToNull()
					}
				};
				model.Items = gridItems.DataSource as List<OrderItemModel>;
				model.Notes = gridNotes.DataSource as List<OrderNoteModel>;

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