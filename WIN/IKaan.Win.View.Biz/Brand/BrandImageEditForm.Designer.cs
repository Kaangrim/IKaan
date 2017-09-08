namespace IKaan.Win.View.Biz.Brand
{
	partial class BrandImageEditForm
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
			this.esImagePath = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcGroupEdit = new DevExpress.XtraLayout.LayoutControlGroup();
			this.lcItemImageType = new DevExpress.XtraLayout.LayoutControlItem();
			this.lupImageType = new IKaan.Win.Core.Controls.Common.XLookup();
			this.lcItemImageID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtImageID = new DevExpress.XtraEditors.TextEdit();
			this.lcButtonUpload = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnUpload = new DevExpress.XtraEditors.SimpleButton();
			this.esMessage = new DevExpress.XtraLayout.EmptySpaceItem();
			this.emptySpaceItem3 = new DevExpress.XtraLayout.EmptySpaceItem();
			this.lcButtonDelete = new DevExpress.XtraLayout.LayoutControlItem();
			this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
			this.lcItemBrandID = new DevExpress.XtraLayout.LayoutControlItem();
			this.txtBrandID = new DevExpress.XtraEditors.TextEdit();
			this.picImage = new DevExpress.XtraEditors.PictureEdit();
			this.lcItemImage = new DevExpress.XtraLayout.LayoutControlItem();
			this.lcGroupImage = new DevExpress.XtraLayout.LayoutControlGroup();
			this.txtImagePath = new DevExpress.XtraEditors.TextEdit();
			this.lcItemImagePath = new DevExpress.XtraLayout.LayoutControlItem();
			((System.ComponentModel.ISupportInitialize)(this.lc)).BeginInit();
			this.lc.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esImagePath)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImageType)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lupImageType.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImageID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtImageID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonUpload)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.esMessage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDelete)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrandID)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBrandID.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupImage)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtImagePath.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImagePath)).BeginInit();
			this.SuspendLayout();
			// 
			// lc
			// 
			this.lc.Controls.Add(this.txtImagePath);
			this.lc.Controls.Add(this.txtBrandID);
			this.lc.Controls.Add(this.btnDelete);
			this.lc.Controls.Add(this.btnUpload);
			this.lc.Controls.Add(this.txtImageID);
			this.lc.Controls.Add(this.lupImageType);
			this.lc.Controls.Add(this.picImage);
			this.lc.Location = new System.Drawing.Point(0, 47);
			this.lc.Margin = new System.Windows.Forms.Padding(0);
			this.lc.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(1199, 224, 450, 400);
			this.lc.OptionsView.UseDefaultDragAndDropRendering = false;
			this.lc.Padding = new System.Windows.Forms.Padding(2);
			this.lc.Size = new System.Drawing.Size(790, 396);
			// 
			// lcGroupBase
			// 
			this.lcGroupBase.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcGroupEdit,
            this.lcGroupImage});
			this.lcGroupBase.Name = "Root";
			this.lcGroupBase.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
			this.lcGroupBase.Size = new System.Drawing.Size(790, 396);
			// 
			// esImagePath
			// 
			this.esImagePath.AllowHotTrack = false;
			this.esImagePath.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esImagePath.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
			this.esImagePath.Location = new System.Drawing.Point(0, 96);
			this.esImagePath.MaxSize = new System.Drawing.Size(0, 20);
			this.esImagePath.MinSize = new System.Drawing.Size(10, 20);
			this.esImagePath.Name = "esImagePath";
			this.esImagePath.Size = new System.Drawing.Size(380, 20);
			this.esImagePath.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.esImagePath.Text = " ";
			this.esImagePath.TextSize = new System.Drawing.Size(96, 0);
			this.esImagePath.TextVisible = true;
			// 
			// lcGroupEdit
			// 
			this.lcGroupEdit.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemImageType,
            this.lcItemImageID,
            this.lcButtonUpload,
            this.esImagePath,
            this.esMessage,
            this.emptySpaceItem3,
            this.lcButtonDelete,
            this.lcItemBrandID,
            this.lcItemImagePath});
			this.lcGroupEdit.Location = new System.Drawing.Point(396, 0);
			this.lcGroupEdit.Name = "lcGroupEdit";
			this.lcGroupEdit.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupEdit.Size = new System.Drawing.Size(394, 396);
			this.lcGroupEdit.TextVisible = false;
			// 
			// lcItemImageType
			// 
			this.lcItemImageType.Control = this.lupImageType;
			this.lcItemImageType.Location = new System.Drawing.Point(0, 48);
			this.lcItemImageType.Name = "lcItemImageType";
			this.lcItemImageType.Size = new System.Drawing.Size(380, 24);
			this.lcItemImageType.TextSize = new System.Drawing.Size(96, 14);
			// 
			// lupImageType
			// 
			this.lupImageType.DisplayMember = "";
			this.lupImageType.GroupCode = null;
			this.lupImageType.ListMember = "ListName";
			this.lupImageType.Location = new System.Drawing.Point(505, 57);
			this.lupImageType.Name = "lupImageType";
			this.lupImageType.NullText = "[EditValue is null]";
			this.lupImageType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), "재구성")});
			this.lupImageType.SelectedIndex = -1;
			this.lupImageType.Size = new System.Drawing.Size(276, 20);
			this.lupImageType.StyleController = this.lc;
			this.lupImageType.TabIndex = 6;
			this.lupImageType.ValueMember = "";
			// 
			// lcItemImageID
			// 
			this.lcItemImageID.Control = this.txtImageID;
			this.lcItemImageID.Location = new System.Drawing.Point(0, 24);
			this.lcItemImageID.MaxSize = new System.Drawing.Size(380, 24);
			this.lcItemImageID.MinSize = new System.Drawing.Size(380, 24);
			this.lcItemImageID.Name = "lcItemImageID";
			this.lcItemImageID.Size = new System.Drawing.Size(380, 24);
			this.lcItemImageID.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcItemImageID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// txtImageID
			// 
			this.txtImageID.Location = new System.Drawing.Point(505, 33);
			this.txtImageID.Name = "txtImageID";
			this.txtImageID.Size = new System.Drawing.Size(276, 20);
			this.txtImageID.StyleController = this.lc;
			this.txtImageID.TabIndex = 7;
			// 
			// lcButtonUpload
			// 
			this.lcButtonUpload.Control = this.btnUpload;
			this.lcButtonUpload.Location = new System.Drawing.Point(152, 116);
			this.lcButtonUpload.MaxSize = new System.Drawing.Size(114, 26);
			this.lcButtonUpload.MinSize = new System.Drawing.Size(114, 26);
			this.lcButtonUpload.Name = "lcButtonUpload";
			this.lcButtonUpload.Size = new System.Drawing.Size(114, 26);
			this.lcButtonUpload.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonUpload.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonUpload.TextVisible = false;
			// 
			// btnUpload
			// 
			this.btnUpload.Location = new System.Drawing.Point(557, 125);
			this.btnUpload.Name = "btnUpload";
			this.btnUpload.Size = new System.Drawing.Size(110, 22);
			this.btnUpload.StyleController = this.lc;
			this.btnUpload.TabIndex = 8;
			this.btnUpload.Text = "업로드";
			// 
			// esMessage
			// 
			this.esMessage.AllowHotTrack = false;
			this.esMessage.AppearanceItemCaption.Options.UseTextOptions = true;
			this.esMessage.AppearanceItemCaption.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
			this.esMessage.AppearanceItemCaption.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
			this.esMessage.Location = new System.Drawing.Point(0, 142);
			this.esMessage.Name = "esMessage";
			this.esMessage.Size = new System.Drawing.Size(380, 240);
			this.esMessage.Text = " ";
			this.esMessage.TextSize = new System.Drawing.Size(0, 0);
			// 
			// emptySpaceItem3
			// 
			this.emptySpaceItem3.AllowHotTrack = false;
			this.emptySpaceItem3.Location = new System.Drawing.Point(0, 116);
			this.emptySpaceItem3.Name = "emptySpaceItem3";
			this.emptySpaceItem3.Size = new System.Drawing.Size(152, 26);
			this.emptySpaceItem3.TextSize = new System.Drawing.Size(0, 0);
			// 
			// lcButtonDelete
			// 
			this.lcButtonDelete.Control = this.btnDelete;
			this.lcButtonDelete.Location = new System.Drawing.Point(266, 116);
			this.lcButtonDelete.MaxSize = new System.Drawing.Size(114, 26);
			this.lcButtonDelete.MinSize = new System.Drawing.Size(114, 26);
			this.lcButtonDelete.Name = "lcButtonDelete";
			this.lcButtonDelete.Size = new System.Drawing.Size(114, 26);
			this.lcButtonDelete.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
			this.lcButtonDelete.TextSize = new System.Drawing.Size(0, 0);
			this.lcButtonDelete.TextVisible = false;
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(671, 125);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(110, 22);
			this.btnDelete.StyleController = this.lc;
			this.btnDelete.TabIndex = 9;
			this.btnDelete.Text = "삭제";
			// 
			// lcItemBrandID
			// 
			this.lcItemBrandID.Control = this.txtBrandID;
			this.lcItemBrandID.Location = new System.Drawing.Point(0, 0);
			this.lcItemBrandID.Name = "lcItemBrandID";
			this.lcItemBrandID.Size = new System.Drawing.Size(380, 24);
			this.lcItemBrandID.TextSize = new System.Drawing.Size(96, 14);
			// 
			// txtBrandID
			// 
			this.txtBrandID.Location = new System.Drawing.Point(505, 9);
			this.txtBrandID.Name = "txtBrandID";
			this.txtBrandID.Size = new System.Drawing.Size(276, 20);
			this.txtBrandID.StyleController = this.lc;
			this.txtBrandID.TabIndex = 10;
			// 
			// picImage
			// 
			this.picImage.Cursor = System.Windows.Forms.Cursors.Default;
			this.picImage.Location = new System.Drawing.Point(9, 9);
			this.picImage.Name = "picImage";
			this.picImage.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
			this.picImage.Properties.ShowScrollBars = true;
			this.picImage.Properties.ZoomAccelerationFactor = 1D;
			this.picImage.Size = new System.Drawing.Size(378, 378);
			this.picImage.StyleController = this.lc;
			this.picImage.TabIndex = 4;
			// 
			// lcItemImage
			// 
			this.lcItemImage.Control = this.picImage;
			this.lcItemImage.Location = new System.Drawing.Point(0, 0);
			this.lcItemImage.Name = "lcItemImage";
			this.lcItemImage.Size = new System.Drawing.Size(382, 382);
			this.lcItemImage.TextSize = new System.Drawing.Size(0, 0);
			this.lcItemImage.TextVisible = false;
			// 
			// lcGroupImage
			// 
			this.lcGroupImage.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.lcItemImage});
			this.lcGroupImage.Location = new System.Drawing.Point(0, 0);
			this.lcGroupImage.Name = "lcGroupImage";
			this.lcGroupImage.Padding = new DevExpress.XtraLayout.Utils.Padding(4, 4, 4, 4);
			this.lcGroupImage.Size = new System.Drawing.Size(396, 396);
			this.lcGroupImage.TextVisible = false;
			// 
			// txtImagePath
			// 
			this.txtImagePath.Location = new System.Drawing.Point(505, 81);
			this.txtImagePath.Name = "txtImagePath";
			this.txtImagePath.Size = new System.Drawing.Size(276, 20);
			this.txtImagePath.StyleController = this.lc;
			this.txtImagePath.TabIndex = 11;
			// 
			// lcItemImagePath
			// 
			this.lcItemImagePath.Control = this.txtImagePath;
			this.lcItemImagePath.Location = new System.Drawing.Point(0, 72);
			this.lcItemImagePath.Name = "lcItemImagePath";
			this.lcItemImagePath.Size = new System.Drawing.Size(380, 24);
			this.lcItemImagePath.TextSize = new System.Drawing.Size(96, 14);
			// 
			// LMBrandImageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(790, 468);
			this.Name = "BrandImageEditForm";
			this.Text = "BrandImageEditForm";
			((System.ComponentModel.ISupportInitialize)(this.lc)).EndInit();
			this.lc.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.lcGroupBase)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esImagePath)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupEdit)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImageType)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lupImageType.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImageID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtImageID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonUpload)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.esMessage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcButtonDelete)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemBrandID)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtBrandID.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.picImage.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcGroupImage)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtImagePath.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.lcItemImagePath)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraLayout.EmptySpaceItem esImagePath;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupEdit;
		private DevExpress.XtraEditors.PictureEdit picImage;
		private DevExpress.XtraLayout.LayoutControlItem lcItemImage;
		private DevExpress.XtraEditors.TextEdit txtImageID;
		private Core.Controls.Common.XLookup lupImageType;
		private DevExpress.XtraLayout.LayoutControlItem lcItemImageType;
		private DevExpress.XtraLayout.LayoutControlItem lcItemImageID;
		private DevExpress.XtraEditors.SimpleButton btnUpload;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonUpload;
		private DevExpress.XtraLayout.LayoutControlGroup lcGroupImage;
		private DevExpress.XtraLayout.EmptySpaceItem esMessage;
		private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
		private DevExpress.XtraEditors.SimpleButton btnDelete;
		private DevExpress.XtraLayout.LayoutControlItem lcButtonDelete;
		private DevExpress.XtraEditors.TextEdit txtBrandID;
		private DevExpress.XtraLayout.LayoutControlItem lcItemBrandID;
		private DevExpress.XtraEditors.TextEdit txtImagePath;
		private DevExpress.XtraLayout.LayoutControlItem lcItemImagePath;
	}
}