namespace IKaan.Win.View.Biz.Sales.Order
{
	partial class OrderListForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions3 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions5 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListForm));
			this.gridList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.esSearchTitle = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemFindText = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtFindText = new DevExpress.XtraEditors.TextEdit();
			this.lcItemStartDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datStartDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemEndDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datEndDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemStore = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupStoreID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemChannel = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupChannelID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemBrand = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupBrandID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemMember = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupMemberID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemStatus = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupStatus = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcButtonDeliveryOrder = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnDeliveryOrder = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonOrderCancel = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnOrderCancel = new DevExpress.XtraEditors.SimpleButton();
			this.lcTabList = new DevExpress.XtraLayout.TabbedControlGroup();
			this.lcGroupLists = new DevExpress.XtraLayout.LayoutControlGroup();
			this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEndDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStore)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupStoreID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrandID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMember)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupMemberID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStatus)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupStatus.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDeliveryOrder)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonOrderCancel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupLists)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.btnOrderCancel);
			this.lc.Controls.Add(this.btnDeliveryOrder);
			this.lc.Controls.Add(this.lupStatus);
			this.lc.Controls.Add(this.lupMemberID);
			this.lc.Controls.Add(this.lupStoreID);
			this.lc.Controls.Add(this.datEndDate);
			this.lc.Controls.Add(this.datStartDate);
			this.lc.Controls.Add(this.lupBrandID);
			this.lc.Controls.Add(this.lupChannelID);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.txtFindText);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(795, 511, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcTabList});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 552);
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(259, 35);
			this.gridList.Name = "gridList";
			this.gridList.PageFooterCenter = null;
			this.gridList.PageFooterLeft = null;
			this.gridList.PageFooterRight = null;
			this.gridList.PageHeaderCenter = null;
			this.gridList.PageHeaderLeft = null;
			this.gridList.PageHeaderRight = null;
			this.gridList.Pager = null;
			this.gridList.PrintFooter = null;
			this.gridList.PrintHeader = null;
			this.gridList.ReadOnly = false;
			this.gridList.ShowFooter = false;
			this.gridList.ShowGroupPanel = false;
			this.gridList.Size = new System.Drawing.Size(722, 508);
			this.gridList.TabIndex = 7;
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.esSearchTitle,
            this.emptySpaceItem2,
            this.lcItemFindText,
            this.lcItemStartDate,
            this.lcItemEndDate,
            this.lcItemStore,
            this.lcItemChannel,
            this.lcItemBrand,
            this.lcItemMember,
            this.lcItemStatus,
            this.lcButtonDeliveryOrder,
            this.lcButtonOrderCancel});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(250, 548);
			this.lcGroupSearch.TextLocation = DevExpress.Utils.Locations.Left;
			this.lcGroupSearch.TextVisible = false;
			// 
			// esSearchTitle
			// 
			this.esSearchTitle.AllowHotTrack = false;
			this.esSearchTitle.AppearanceItemCaption.BackColor = System.Drawing.Color.Black;
			this.esSearchTitle.AppearanceItemCaption.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Bold);
			this.esSearchTitle.AppearanceItemCaption.ForeColor = System.Drawing.Color.White;
			this.esSearchTitle.AppearanceItemCaption.Options.UseBackColor = true;
			this.esSearchTitle.AppearanceItemCaption.Options.UseFont = true;
			this.esSearchTitle.AppearanceItemCaption.Options.UseForeColor = true;
			this.esSearchTitle.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esSearchTitle.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
			this.esSearchTitle.Location = new System.Drawing.Point(0, 0);
			this.esSearchTitle.MaxSize = new System.Drawing.Size(216, 40);
			this.esSearchTitle.MinSize = new System.Drawing.Size(216, 40);
			this.esSearchTitle.Name = "esSearchTitle";
			this.esSearchTitle.Size = new System.Drawing.Size(216, 40);
			this.esSearchTitle.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esSearchTitle.Text = "검색조건";
			this.esSearchTitle.TextSize = new System.Drawing.Size(87, 0);
			this.esSearchTitle.TextVisible = true;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 368);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(216, 115);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemFindText
			// 
			this.lcItemFindText.Control = this.txtFindText;
			this.lcItemFindText.Location = new System.Drawing.Point(0, 327);
			this.lcItemFindText.Name = "lcItemFindText";
			this.lcItemFindText.Size = new System.Drawing.Size(216, 41);
			this.lcItemFindText.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemFindText.TextSize = new System.Drawing.Size(87, 14);
			// 
			// txtFindText
			// 
			this.txtFindText.Location = new System.Drawing.Point(31, 354);
			this.txtFindText.Name = "txtFindText";
			this.txtFindText.Size = new System.Drawing.Size(212, 20);
			this.txtFindText.StyleController = this.lc;
			this.txtFindText.TabIndex = 4;
			// 
			// lcItemStartDate
			// 
			this.lcItemStartDate.Control = this.datStartDate;
			this.lcItemStartDate.Location = new System.Drawing.Point(0, 204);
			this.lcItemStartDate.Name = "lcItemStartDate";
			this.lcItemStartDate.Size = new System.Drawing.Size(216, 41);
			this.lcItemStartDate.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemStartDate.TextSize = new System.Drawing.Size(87, 14);
			// 
			// datStartDate
			// 
			this.datStartDate.EditValue = null;
			this.datStartDate.Location = new System.Drawing.Point(31, 231);
			this.datStartDate.Name = "datStartDate";
			this.datStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datStartDate.Size = new System.Drawing.Size(212, 20);
			this.datStartDate.StyleController = this.lc;
			this.datStartDate.TabIndex = 33;
			// 
			// lcItemEndDate
			// 
			this.lcItemEndDate.Control = this.datEndDate;
			this.lcItemEndDate.Location = new System.Drawing.Point(0, 245);
			this.lcItemEndDate.Name = "lcItemEndDate";
			this.lcItemEndDate.Size = new System.Drawing.Size(216, 41);
			this.lcItemEndDate.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemEndDate.TextSize = new System.Drawing.Size(87, 14);
			// 
			// datEndDate
			// 
			this.datEndDate.EditValue = null;
			this.datEndDate.Location = new System.Drawing.Point(31, 272);
			this.datEndDate.Name = "datEndDate";
			this.datEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datEndDate.Size = new System.Drawing.Size(212, 20);
			this.datEndDate.StyleController = this.lc;
			this.datEndDate.TabIndex = 34;
			// 
			// lcItemStore
			// 
			this.lcItemStore.Control = this.lupStoreID;
			this.lcItemStore.Location = new System.Drawing.Point(0, 40);
			this.lcItemStore.Name = "lcItemStore";
			this.lcItemStore.Size = new System.Drawing.Size(216, 41);
			this.lcItemStore.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemStore.TextSize = new System.Drawing.Size(87, 14);
			// 
			// lupStoreID
			// 
			this.lupStoreID.DisplayMember = "";
			this.lupStoreID.GroupCode = null;
			this.lupStoreID.ListMember = "ListName";
			this.lupStoreID.Location = new System.Drawing.Point(31, 67);
			this.lupStoreID.Name = "lupStoreID";
			this.lupStoreID.NullText = "[EditValue is null]";
			this.lupStoreID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions3, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupStoreID.SelectedIndex = -1;
			this.lupStoreID.Size = new System.Drawing.Size(212, 20);
			this.lupStoreID.StyleController = this.lc;
			this.lupStoreID.TabIndex = 35;
			this.lupStoreID.ValueMember = "";
			// 
			// lcItemChannel
			// 
			this.lcItemChannel.Control = this.lupChannelID;
			this.lcItemChannel.Location = new System.Drawing.Point(0, 81);
			this.lcItemChannel.Name = "lcItemChannel";
			this.lcItemChannel.Size = new System.Drawing.Size(216, 41);
			this.lcItemChannel.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemChannel.TextSize = new System.Drawing.Size(87, 14);
			// 
			// lupChannelID
			// 
			this.lupChannelID.DisplayMember = "";
			this.lupChannelID.GroupCode = null;
			this.lupChannelID.ListMember = "ListName";
			this.lupChannelID.Location = new System.Drawing.Point(31, 108);
			this.lupChannelID.Name = "lupChannelID";
			this.lupChannelID.NullText = "[EditValue is null]";
			this.lupChannelID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions5, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupChannelID.SelectedIndex = -1;
			this.lupChannelID.Size = new System.Drawing.Size(212, 20);
			this.lupChannelID.StyleController = this.lc;
			this.lupChannelID.TabIndex = 31;
			this.lupChannelID.ValueMember = "";
			// 
			// lcItemBrand
			// 
			this.lcItemBrand.Control = this.lupBrandID;
			this.lcItemBrand.Location = new System.Drawing.Point(0, 163);
			this.lcItemBrand.Name = "lcItemBrand";
			this.lcItemBrand.Size = new System.Drawing.Size(216, 41);
			this.lcItemBrand.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemBrand.TextSize = new System.Drawing.Size(87, 14);
			// 
			// lupBrandID
			// 
			this.lupBrandID.DisplayMember = "";
			this.lupBrandID.GroupCode = null;
			this.lupBrandID.ListMember = "ListName";
			this.lupBrandID.Location = new System.Drawing.Point(31, 190);
			this.lupBrandID.Name = "lupBrandID";
			this.lupBrandID.NullText = "[EditValue is null]";
			this.lupBrandID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupBrandID.SelectedIndex = -1;
			this.lupBrandID.Size = new System.Drawing.Size(212, 20);
			this.lupBrandID.StyleController = this.lc;
			this.lupBrandID.TabIndex = 32;
			this.lupBrandID.ValueMember = "";
			// 
			// lcItemMember
			// 
			this.lcItemMember.Control = this.lupMemberID;
			this.lcItemMember.Location = new System.Drawing.Point(0, 122);
			this.lcItemMember.Name = "lcItemMember";
			this.lcItemMember.Size = new System.Drawing.Size(216, 41);
			this.lcItemMember.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemMember.TextSize = new System.Drawing.Size(87, 14);
			// 
			// lupMemberID
			// 
			this.lupMemberID.DisplayMember = "";
			this.lupMemberID.GroupCode = null;
			this.lupMemberID.ListMember = "ListName";
			this.lupMemberID.Location = new System.Drawing.Point(31, 149);
			this.lupMemberID.Name = "lupMemberID";
			this.lupMemberID.NullText = "[EditValue is null]";
			this.lupMemberID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupMemberID.SelectedIndex = -1;
			this.lupMemberID.Size = new System.Drawing.Size(212, 20);
			this.lupMemberID.StyleController = this.lc;
			this.lupMemberID.TabIndex = 36;
			this.lupMemberID.ValueMember = "";
			// 
			// lcItemStatus
			// 
			this.lcItemStatus.Control = this.lupStatus;
			this.lcItemStatus.Location = new System.Drawing.Point(0, 286);
			this.lcItemStatus.Name = "lcItemStatus";
			this.lcItemStatus.Size = new System.Drawing.Size(216, 41);
			this.lcItemStatus.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemStatus.TextSize = new System.Drawing.Size(87, 14);
			// 
			// lupStatus
			// 
			this.lupStatus.DisplayMember = "";
			this.lupStatus.GroupCode = null;
			this.lupStatus.ListMember = "ListName";
			this.lupStatus.Location = new System.Drawing.Point(31, 313);
			this.lupStatus.Name = "lupStatus";
			this.lupStatus.NullText = "[EditValue is null]";
			this.lupStatus.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupStatus.SelectedIndex = -1;
			this.lupStatus.Size = new System.Drawing.Size(212, 20);
			this.lupStatus.StyleController = this.lc;
			this.lupStatus.TabIndex = 37;
			this.lupStatus.ValueMember = "";
			// 
			// lcButtonDeliveryOrder
			// 
			this.lcButtonDeliveryOrder.Control = this.btnDeliveryOrder;
			this.lcButtonDeliveryOrder.Location = new System.Drawing.Point(0, 483);
			this.lcButtonDeliveryOrder.Name = "lcButtonDeliveryOrder";
			this.lcButtonDeliveryOrder.Size = new System.Drawing.Size(216, 26);
			this.lcButtonDeliveryOrder.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonDeliveryOrder.TextVisible = false;
			// 
			// btnDeliveryOrder
			// 
			this.btnDeliveryOrder.Location = new System.Drawing.Point(31, 493);
			this.btnDeliveryOrder.Name = "btnDeliveryOrder";
			this.btnDeliveryOrder.Size = new System.Drawing.Size(212, 22);
			this.btnDeliveryOrder.StyleController = this.lc;
			this.btnDeliveryOrder.TabIndex = 38;
			this.btnDeliveryOrder.Text = "배송요청";
			// 
			// lcButtonOrderCancel
			// 
			this.lcButtonOrderCancel.Control = this.btnOrderCancel;
			this.lcButtonOrderCancel.Location = new System.Drawing.Point(0, 509);
			this.lcButtonOrderCancel.Name = "lcButtonOrderCancel";
			this.lcButtonOrderCancel.Size = new System.Drawing.Size(216, 26);
			this.lcButtonOrderCancel.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonOrderCancel.TextVisible = false;
			// 
			// btnOrderCancel
			// 
			this.btnOrderCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
			this.btnOrderCancel.Appearance.ForeColor = System.Drawing.Color.Red;
			this.btnOrderCancel.Appearance.Options.UseFont = true;
			this.btnOrderCancel.Appearance.Options.UseForeColor = true;
			this.btnOrderCancel.Location = new System.Drawing.Point(31, 519);
			this.btnOrderCancel.Name = "btnOrderCancel";
			this.btnOrderCancel.Size = new System.Drawing.Size(212, 22);
			this.btnOrderCancel.StyleController = this.lc;
			this.btnOrderCancel.TabIndex = 39;
			this.btnOrderCancel.Text = "주문취소";
			// 
			// lcTabList
			// 
			this.lcTabList.Location = new System.Drawing.Point(250, 0);
			this.lcTabList.Name = "lcTabList";
			this.lcTabList.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcTabList.SelectedTabPage = this.lcGroupLists;
			this.lcTabList.SelectedTabPageIndex = 0;
			this.lcTabList.Size = new System.Drawing.Size(736, 548);
			this.lcTabList.TabPages.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupLists});
			// 
			// lcGroupLists
			// 
			this.lcGroupLists.CaptionImage = ((System.Drawing.Image)(resources.GetObject("lcGroupLists.CaptionImage")));
			this.lcGroupLists.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
			this.lcGroupLists.Location = new System.Drawing.Point(0, 0);
			this.lcGroupLists.Name = "lcGroupLists";
			this.lcGroupLists.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupLists.Size = new System.Drawing.Size(726, 512);
			this.lcGroupLists.Text = "조회결과";
			// 
			// layoutControlItem3
			// 
			this.layoutControlItem3.Control = this.gridList;
			this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
			this.layoutControlItem3.Name = "layoutControlItem3";
			this.layoutControlItem3.Size = new System.Drawing.Size(726, 512);
			this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
			this.layoutControlItem3.TextVisible = false;
			// 
			// OrderListForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 618);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "OrderListForm";
			this.Text = "OrderListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemFindText)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtFindText.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStartDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datStartDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemEndDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datEndDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStore)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupStoreID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrand)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupBrandID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemMember)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupMemberID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemStatus)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupStatus.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDeliveryOrder)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonOrderCancel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcTabList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupLists)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private DevExpress.XtraEditors.TextEdit txtFindText;
		private DevExpress.XtraLayout.LayoutControlItem lcItemFindText;
		private IKaan.Win.Core.Controls.Grid.XGrid gridList;
		private Core.Controls.Common.XLookup lupChannelID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemChannel;
		private DevExpress.XtraLayout.EmptySpaceItem esSearchTitle;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraLayout.TabbedControlGroup lcTabList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupLists;
		private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
		private Core.Controls.Common.XLookup lupBrandID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemBrand;
		private DevExpress.XtraEditors.DateEdit datEndDate;
		private DevExpress.XtraEditors.DateEdit datStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStartDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemEndDate;
		private Core.Controls.Common.XLookup lupStoreID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStore;
		private Core.Controls.Common.XLookup lupMemberID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemMember;
		private Core.Controls.Common.XLookup lupStatus;
		private DevExpress.XtraLayout.LayoutControlItem lcItemStatus;
		private DevExpress.XtraEditors.SimpleButton btnDeliveryOrder;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonDeliveryOrder;
		private DevExpress.XtraEditors.SimpleButton btnOrderCancel;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonOrderCancel;
	}
}