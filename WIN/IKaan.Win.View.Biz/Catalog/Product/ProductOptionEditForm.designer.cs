namespace IKaan.Win.View.Biz.Catalog.Product
{
	partial class ProductOptionEditForm
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			this.lcGroupEdit1 = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemOption2Type = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupOption2Type = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemOption1Type = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupOption1Type = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcGroupEditBase = new DevExpress.XtraLayout.LayoutControlGroup();
			this.memOption1Name = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemOption1Name = new DevExpress.XtraLayout.LayoutControlItem();
			this.memOption2Name = new DevExpress.XtraEditors.MemoEdit();
			this.lcItemOption2Name = new DevExpress.XtraLayout.LayoutControlItem();
			this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption2Type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupOption2Type.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption1Type)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupOption1Type.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memOption1Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption1Name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memOption2Name.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption2Name)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.memOption2Name);
			this.lc.Controls.Add(this.memOption1Name);
			this.lc.Controls.Add(this.lupOption1Type);
			this.lc.Controls.Add(this.lupOption2Type);
			this.lc.Location = new System.Drawing.Point(0, 44);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(922, 391, 457, 350);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(498, 202);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEditBase});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
			this.lcGroupBase.Size = new System.Drawing.Size(498, 202);
			// 
			// lcGroupEdit1
			// 
			this.lcGroupEdit1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemOption1Type,
            this.lcItemOption2Type,
            this.lcItemOption1Name,
            this.lcItemOption2Name,
            this.emptySpaceItem1,
            this.emptySpaceItem2});
			this.lcGroupEdit1.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEdit1.Name = "lcGroupEdit1";
			this.lcGroupEdit1.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit1.Size = new System.Drawing.Size(494, 198);
			this.lcGroupEdit1.TextVisible = false;
			// 
			// lcItemOption2Type
			// 
			this.lcItemOption2Type.Control = this.lupOption2Type;
			this.lcItemOption2Type.Location = new System.Drawing.Point(0, 92);
			this.lcItemOption2Type.Name = "lcItemOption2Type";
			this.lcItemOption2Type.Size = new System.Drawing.Size(240, 24);
			this.lcItemOption2Type.TextSize = new System.Drawing.Size(109, 14);
			// 
			// lupOption2Type
			// 
			this.lupOption2Type.DisplayMember = "";
			this.lupOption2Type.GroupCode = null;
			this.lupOption2Type.ListMember = "ListName";
			this.lupOption2Type.Location = new System.Drawing.Point(124, 103);
			this.lupOption2Type.Name = "lupOption2Type";
			this.lupOption2Type.NullText = "[EditValue is null]";
			this.lupOption2Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupOption2Type.SelectedIndex = -1;
			this.lupOption2Type.Size = new System.Drawing.Size(123, 20);
			this.lupOption2Type.StyleController = this.lc;
			this.lupOption2Type.TabIndex = 36;
			this.lupOption2Type.ValueMember = "";
			// 
			// lcItemOption1Type
			// 
			this.lcItemOption1Type.Control = this.lupOption1Type;
			this.lcItemOption1Type.Location = new System.Drawing.Point(0, 0);
			this.lcItemOption1Type.Name = "lcItemOption1Type";
			this.lcItemOption1Type.Size = new System.Drawing.Size(240, 24);
			this.lcItemOption1Type.TextSize = new System.Drawing.Size(109, 14);
			// 
			// lupOption1Type
			// 
			this.lupOption1Type.DisplayMember = "";
			this.lupOption1Type.GroupCode = null;
			this.lupOption1Type.ListMember = "ListName";
			this.lupOption1Type.Location = new System.Drawing.Point(124, 11);
			this.lupOption1Type.Name = "lupOption1Type";
			this.lupOption1Type.NullText = "[EditValue is null]";
			this.lupOption1Type.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupOption1Type.SelectedIndex = -1;
			this.lupOption1Type.Size = new System.Drawing.Size(123, 20);
			this.lupOption1Type.StyleController = this.lc;
			this.lupOption1Type.TabIndex = 58;
			this.lupOption1Type.ValueMember = "";
			// 
			// lcGroupEditBase
			// 
			this.lcGroupEditBase.GroupBordersVisible = false;
			this.lcGroupEditBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit1});
			this.lcGroupEditBase.Location = new System.Drawing.Point(0, 0);
			this.lcGroupEditBase.Name = "lcGroupEditBase";
			this.lcGroupEditBase.Size = new System.Drawing.Size(494, 198);
			this.lcGroupEditBase.TextVisible = false;
			// 
			// memOption1Name
			// 
			this.memOption1Name.Location = new System.Drawing.Point(124, 35);
			this.memOption1Name.Name = "memOption1Name";
			this.memOption1Name.Size = new System.Drawing.Size(363, 64);
			this.memOption1Name.StyleController = this.lc;
			this.memOption1Name.TabIndex = 59;
			// 
			// lcItemOption1Name
			// 
			this.lcItemOption1Name.Control = this.memOption1Name;
			this.lcItemOption1Name.Location = new System.Drawing.Point(0, 24);
			this.lcItemOption1Name.Name = "lcItemOption1Name";
			this.lcItemOption1Name.Size = new System.Drawing.Size(480, 68);
			this.lcItemOption1Name.TextSize = new System.Drawing.Size(109, 14);
			// 
			// memOption2Name
			// 
			this.memOption2Name.Location = new System.Drawing.Point(124, 127);
			this.memOption2Name.Name = "memOption2Name";
			this.memOption2Name.Size = new System.Drawing.Size(363, 64);
			this.memOption2Name.StyleController = this.lc;
			this.memOption2Name.TabIndex = 60;
			// 
			// lcItemOption2Name
			// 
			this.lcItemOption2Name.Control = this.memOption2Name;
			this.lcItemOption2Name.Location = new System.Drawing.Point(0, 116);
			this.lcItemOption2Name.Name = "lcItemOption2Name";
			this.lcItemOption2Name.Size = new System.Drawing.Size(480, 68);
			this.lcItemOption2Name.TextSize = new System.Drawing.Size(109, 14);
			// 
			// emptySpaceItem1
			// 
			this.emptySpaceItem1.AllowHotTrack = false;
			this.emptySpaceItem1.Location = new System.Drawing.Point(240, 0);
			this.emptySpaceItem1.Name = "emptySpaceItem1";
			this.emptySpaceItem1.Size = new System.Drawing.Size(240, 24);
			this.emptySpaceItem1.Text = "  콤마(,)로 분리하여 등록합니다.";
			this.emptySpaceItem1.TextSize = new System.Drawing.Size(109, 0);
			this.emptySpaceItem1.TextVisible = true;
			// 
			// emptySpaceItem2
			// 
			this.emptySpaceItem2.AllowHotTrack = false;
			this.emptySpaceItem2.Location = new System.Drawing.Point(240, 92);
			this.emptySpaceItem2.Name = "emptySpaceItem2";
			this.emptySpaceItem2.Size = new System.Drawing.Size(240, 24);
			this.emptySpaceItem2.Text = "  콤마(,)로 분리하여 등록합니다.";
			this.emptySpaceItem2.TextSize = new System.Drawing.Size(109, 0);
			this.emptySpaceItem2.TextVisible = true;
			// 
			// ProductOptionEditForm
			// 
			this.Appearance.BackColor = System.Drawing.Color.White;
			this.Appearance.Options.UseBackColor = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(498, 268);
			this.LookAndFeel.SkinName = "Office 2016 Dark";
			this.Name = "ProductOptionEditForm";
			this.Text = "ProductOptionEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption2Type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupOption2Type.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption1Type)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupOption1Type.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEditBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memOption1Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption1Name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memOption2Name.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemOption2Name)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit1;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEditBase;
		private Core.Controls.Common.XLookup lupOption2Type;
		private DevExpress.XtraLayout.LayoutControlItem lcItemOption2Type;
		private Core.Controls.Common.XLookup lupOption1Type;
		private DevExpress.XtraLayout.LayoutControlItem lcItemOption1Type;
		private DevExpress.XtraEditors.MemoEdit memOption2Name;
		private DevExpress.XtraEditors.MemoEdit memOption1Name;
		private DevExpress.XtraLayout.LayoutControlItem lcItemOption1Name;
		private DevExpress.XtraLayout.LayoutControlItem lcItemOption2Name;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
	}
}