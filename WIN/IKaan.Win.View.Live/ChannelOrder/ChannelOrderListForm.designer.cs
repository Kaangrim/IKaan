namespace IKaan.Win.View.Live.ChannelOrder
{
	partial class ChannelOrderListForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupSearch = new DevExpress.XtraLayout.LayoutControlGroup();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcItemOrderDate = new DevExpress.XtraLayout.LayoutControlItem();
			this.datOrderDate = new DevExpress.XtraEditors.DateEdit();
			this.lcItemChannel = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupChannelID = new IKaan.Win.Core.Controls.Common.XLookup();
			this.esSearchTitle = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcButtonUpload = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
			this.gridList = new IKaan.Win.Core.Controls.Grid.XGrid();
			this.lcGroupList = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcGridList = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnBrandMapping = new DevExpress.XtraEditors.SimpleButton();
			this.lcButtonBrandMapping = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOrderDate)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datOrderDate.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.datOrderDate.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonUpload)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonBrandMapping)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.btnBrandMapping);
			this.lc.Controls.Add(this.btnUpload);
			this.lc.Controls.Add(this.gridList);
			this.lc.Controls.Add(this.datOrderDate);
			this.lc.Controls.Add(this.lupChannelID);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(930, 427, 622, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupSearch,
            this.lcGroupList});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(990, 552);
			// 
			// lcGroupSearch
			// 
			this.lcGroupSearch.ExpandButtonVisible = true;
			this.lcGroupSearch.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem2,
            this.lcItemOrderDate,
            this.lcItemChannel,
            this.esSearchTitle,
            this.lcButtonUpload,
            this.lcButtonBrandMapping});
			this.lcGroupSearch.Location = new System.Drawing.Point(0, 0);
			this.lcGroupSearch.Name = "lcGroupSearch";
			this.lcGroupSearch.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupSearch.Size = new System.Drawing.Size(270, 548);
			this.lcGroupSearch.TextLocation = DevExpress.Utils.Locations.Left;
			this.lcGroupSearch.TextVisible = false;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(0, 122);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(236, 361);
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcItemOrderDate
			// 
			this.lcItemOrderDate.Control = this.datOrderDate;
			this.lcItemOrderDate.Location = new System.Drawing.Point(0, 81);
			this.lcItemOrderDate.Name = "lcItemOrderDate";
			this.lcItemOrderDate.Size = new System.Drawing.Size(236, 41);
			this.lcItemOrderDate.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemOrderDate.TextSize = new System.Drawing.Size(91, 14);
			// 
			// datOrderDate
			// 
			this.datOrderDate.EditValue = null;
			this.datOrderDate.Location = new System.Drawing.Point(31, 108);
			this.datOrderDate.Name = "datOrderDate";
			this.datOrderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datOrderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.datOrderDate.Size = new System.Drawing.Size(232, 20);
			this.datOrderDate.StyleController = this.lc;
			this.datOrderDate.TabIndex = 19;
			// 
			// lcItemChannel
			// 
			this.lcItemChannel.Control = this.lupChannelID;
			this.lcItemChannel.Location = new System.Drawing.Point(0, 40);
			this.lcItemChannel.Name = "lcItemChannel";
			this.lcItemChannel.Size = new System.Drawing.Size(236, 41);
			this.lcItemChannel.TextLocation = DevExpress.Utils.Locations.Top;
			this.lcItemChannel.TextSize = new System.Drawing.Size(91, 14);
			// 
			// lupChannelID
			// 
			this.lupChannelID.DisplayMember = "";
			this.lupChannelID.GroupCode = null;
			this.lupChannelID.ListMember = "ListName";
			this.lupChannelID.Location = new System.Drawing.Point(31, 67);
			this.lupChannelID.Name = "lupChannelID";
			this.lupChannelID.NullText = "[EditValue is null]";
			this.lupChannelID.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupChannelID.SelectedIndex = -1;
			this.lupChannelID.Size = new System.Drawing.Size(232, 20);
			this.lupChannelID.StyleController = this.lc;
			this.lupChannelID.TabIndex = 12;
			this.lupChannelID.ValueMember = "";
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
			this.esSearchTitle.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
			this.esSearchTitle.Location = new System.Drawing.Point(0, 0);
			this.esSearchTitle.MaxSize = new System.Drawing.Size(236, 40);
			this.esSearchTitle.MinSize = new System.Drawing.Size(236, 40);
			this.esSearchTitle.Name = "esSearchTitle";
			this.esSearchTitle.Size = new System.Drawing.Size(236, 40);
			this.esSearchTitle.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esSearchTitle.Text = "검색조건";
			this.esSearchTitle.TextSize = new System.Drawing.Size(91, 0);
			this.esSearchTitle.TextVisible = true;
			// 
			// lcButtonUpload
			// 
			this.lcButtonUpload.Control = this.btnUpload;
			this.lcButtonUpload.Location = new System.Drawing.Point(0, 483);
			this.lcButtonUpload.Name = "lcButtonUpload";
			this.lcButtonUpload.Size = new System.Drawing.Size(236, 26);
			this.lcButtonUpload.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonUpload.TextVisible = false;
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(31, 493);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(232, 22);
			this.btnUpload.StyleController = this.lc;
			this.btnUpload.TabIndex = 21;
			this.btnUpload.Text = "엑셀업로드";
			// 
			// gridList
			// 
			this.gridList.Compress = false;
			this.gridList.DataSource = null;
			this.gridList.Editable = true;
			this.gridList.FocusedRowHandle = -2147483648;
			this.gridList.GridViewType = IKaan.Win.Core.Controls.Grid.GridViewType.GridView;
			this.gridList.Location = new System.Drawing.Point(281, 11);
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
			this.gridList.Size = new System.Drawing.Size(698, 530);
			this.gridList.TabIndex = 20;
			// 
			// lcGroupList
			// 
			this.lcGroupList.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGridList});
			this.lcGroupList.Location = new System.Drawing.Point(270, 0);
			this.lcGroupList.Name = "lcGroupList";
			this.lcGroupList.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupList.Size = new System.Drawing.Size(716, 548);
			this.lcGroupList.TextVisible = false;
			// 
			// lcGridList
			// 
			this.lcGridList.Control = this.gridList;
			this.lcGridList.Location = new System.Drawing.Point(0, 0);
			this.lcGridList.Name = "lcGridList";
			this.lcGridList.Size = new System.Drawing.Size(702, 534);
			this.lcGridList.TextSize = new System.Drawing.Size(0, 0);
			this.lcGridList.TextVisible = false;
			// 
			// btnBrandMapping
			// 
			this.btnBrandMapping.Location = new System.Drawing.Point(31, 519);
			this.btnBrandMapping.Name = "btnBrandMapping";
			this.btnBrandMapping.Size = new System.Drawing.Size(232, 22);
			this.btnBrandMapping.StyleController = this.lc;
			this.btnBrandMapping.TabIndex = 22;
			this.btnBrandMapping.Text = "브랜드 자동매핑";
			// 
			// lcButtonBrandMapping
			// 
			this.lcButtonBrandMapping.Control = this.btnBrandMapping;
			this.lcButtonBrandMapping.Location = new System.Drawing.Point(0, 509);
			this.lcButtonBrandMapping.Name = "lcButtonBrandMapping";
			this.lcButtonBrandMapping.Size = new System.Drawing.Size(236, 26);
			this.lcButtonBrandMapping.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonBrandMapping.TextVisible = false;
			// 
			// ChannelOrderListForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(990, 618);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "ChannelOrderListForm";
			this.Text = "ChannelOrderListForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupSearch)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOrderDate)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datOrderDate.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.datOrderDate.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemChannel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupChannelID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esSearchTitle)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonUpload)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGridList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonBrandMapping)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupSearch;
		private Core.Controls.Common.XLookup lupChannelID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemChannel;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
		private DevExpress.XtraEditors.DateEdit datOrderDate;
		private DevExpress.XtraLayout.LayoutControlItem lcItemOrderDate;
		private DevExpress.XtraLayout.EmptySpaceItem esSearchTitle;
		private Core.Controls.Grid.XGrid gridList;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupList;
		private DevExpress.XtraLayout.LayoutControlItem lcGridList;
		private DevExpress.XtraEditors.SimpleButton btnUpload;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonUpload;
		private DevExpress.XtraEditors.SimpleButton btnBrandMapping;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonBrandMapping;
	}
}