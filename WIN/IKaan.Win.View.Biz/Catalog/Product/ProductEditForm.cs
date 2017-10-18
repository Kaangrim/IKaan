using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Catalog.Product;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Catalog.Product
{
	public partial class ProductEditForm : EditForm
	{
		public ProductEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				if (e.Button.Tag.ToStringNullToEmpty() == "BAT")
				{
					try
					{
						using (var form = new ProductOptionEditForm())
						{
							form.Text = "옵션일괄등록";
							form.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
							form.IsLoadingRefresh = true;
							if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
							{
								if (form.ReturnData != null)
								{
									foreach (var item in (form.ReturnData as List<ProductItemModel>))
									{
										if ((gridItems.DataSource as List<ProductItemModel>).Where(x =>
											 x.Option1Type == item.Option1Type &&
											 x.Option1Name == item.Option1Name &&
											 x.Option2Type == item.Option2Type &&
											 x.Option2Name == item.Option2Name).Any())
											continue;

										gridItems.AddRow(item);
									}
								}
							}
						}
					}
					catch (Exception ex)
					{
						ShowErrBox(ex);
					}
				}
				else if (e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupOption.Name)
					{
						gridItems.AddRow(new ProductItemModel());
						gridItems.SetFocus(gridItems.RowCount - 1, "Option1Type");
					}
					else if (lcTab.SelectedTabPage.Name == lcGroupImages.Name)
					{
						gridImages.AddRow(new ProductImageModel()
						{
							ImageType = null,
							ImageGroup = null
						});
						gridImages.SetFocus(gridImages.RowCount - 1, "ImageType");
					}
					else if (lcTab.SelectedTabPage.Name == lcGroupAttribute.Name)
					{
						if (lupAttributeType.EditValue == null)
						{
							ShowMsgBox("속성유형을 선택하세요!!!");
							lupAttributeType.Focus();
							return;
						}
						if (lupAttributeValue.EditValue == null)
						{
							ShowMsgBox("속성값을 선택하세요!!!");
							lupAttributeValue.Focus();
							return;
						}

						gridAttributes.AddRow(new ProductAttributeModel()
						{
							ProductID = txtID.EditValue.ToIntegerNullToNull(),
							AttributeTypeID = lupAttributeType.EditValue.ToIntegerNullToNull(),
							AttributeTypeName = lupAttributeType.Text,
							ValueType = lupAttributeType.GetValue(1).ToStringNullToNull(),
							AttributeID = lupAttributeValue.EditValue.ToIntegerNullToNull(),
							AttributeName = lupAttributeValue.Text,
							AttributeCode = lupAttributeValue.GetValue(2).ToStringNullToNull(),
							AttributeValue = lupAttributeValue.Text							
						});
					}
				}
				else if (e.Button.Tag.ToStringNullToEmpty() == "DEL")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupOption.Name)
					{
						DeleteOption();
					}
					else if (lcTab.SelectedTabPage.Name == lcGroupImages.Name)
					{
						DeleteImage();
					}
				}
			};

			lupCategoryID.EditValueChanged += (object sender, EventArgs e) =>
			{
				LoadInfoNotice();
			};

			lupAttributeType.EditValueChanged += (object sender, EventArgs e)=>
			{
				lupAttributeValue.BindData("Attribute", "", false, new DataMap() { { "AttributeTypeID", lupAttributeType.EditValue } });
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtName.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, SaveAndClose = true });
		}
		protected override void InitControls()
		{
			lcItemCode.Tag = true;
			lcItemName.Tag = true;
			lupCategoryID.Tag = true;
			lupBrandID.Tag = true;

			base.InitControls();

			SetFieldNames();

			lcGroupAttribute.Text = DomainUtils.GetFieldName("Attribute");
			lcGroupDetail.Text = DomainUtils.GetFieldName("Description");
			lcGroupImages.Text = DomainUtils.GetFieldName("Image");
			lcGroupOption.Text = DomainUtils.GetFieldName("Option");
			lcGroupInfoNotices.Text = DomainUtils.GetFieldName("InfoNotice");

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			lupCategoryID.BindData("Categories", "==카테고리선택==");
			lupBrandID.BindData("BrandList", "==브랜드선택==");
			lupProductType.BindData("ProductType");
			lupAttributeType.BindData("AttributeType");
			lupAttributeValue.BindData("Attribute", "", false, new DataMap() { { "AttributeTypeID", lupAttributeType.EditValue } });

			spnListPrice.SetFormat("N0", false);
			spnSalePrice.SetFormat("N0", false);

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
			lcTab.SelectedTabPageIndex = 0;
		}

		void InitGrid()
		{
			#region GoodsItem
			gridItems.Init();
			gridItems.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ProductID", Visible = false },
				new XGridColumn() { FieldName = "Option1Type", Width = 100 },
				new XGridColumn() { FieldName = "Option1Name", Width = 100 },
				new XGridColumn() { FieldName = "Option2Type", Width = 100 },
				new XGridColumn() { FieldName = "Option2Name", Width = 100 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridItems.ColumnFix("RowNo");
			gridItems.SetRepositoryItemLookUpEdit("Option1Type", "OptionType", "None");
			gridItems.SetRepositoryItemLookUpEdit("Option2Type", "OptionType", "None");
			gridItems.SetEditable("Option1Type", "Option1Name", "Option2Type", "Option2Name");
			#endregion

			#region GoodsImage
			gridImages.Init();
			gridImages.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ProductID", Visible = false },
				new XGridColumn() { FieldName = "ImageType", Width = 100 },
				new XGridColumn() { FieldName = "ImageGroup", Width = 100 },
				new XGridColumn() { FieldName = "Name", CaptionCode = "ImageName", Width = 200 },
				new XGridColumn() { FieldName = "Url", Width = 200 },
				new XGridColumn() { FieldName = "Path", Width = 200 },
				new XGridColumn() { FieldName = "Width", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "Height", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridImages.ColumnFix("RowNo");
			gridImages.SetRepositoryItemButtonEdit("Name");
			gridImages.SetRepositoryItemLookUpEdit("ImageType", "ImageType", "None");
			gridImages.SetRepositoryItemLookUpEdit("ImageGroup", "ImageGroup", "None");
			gridImages.SetEditable("ImageType", "ImageGroup", "Name");
			(gridImages.MainView.Columns["Name"].ColumnEdit as RepositoryItemButtonEdit).TextEditStyle = TextEditStyles.DisableTextEditor;
			(gridImages.MainView.Columns["Name"].ColumnEdit as RepositoryItemButtonEdit).ButtonClick += (object sender, ButtonPressedEventArgs e) =>
			{
				try
				{
					var image = ImageUtils.SelectImage();
					if (image != null)
					{
						gridImages.SetValue(gridImages.FocusedRowHandle, "Name", image.Name);
						gridImages.SetValue(gridImages.FocusedRowHandle, "Path", image.Url);
						gridImages.SetValue(gridImages.FocusedRowHandle, "Width", image.Width);
						gridImages.SetValue(gridImages.FocusedRowHandle, "Height", image.Height);
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			gridImages.RowCellClick += (object sender, RowCellClickEventArgs e)=>
			{
				if (e.RowHandle < 0)
					return;

				if (e.Button == MouseButtons.Left && e.Clicks == 1)
				{
					GridView view = sender as GridView;
					if (view.GetRowCellValue(e.RowHandle, "Path").IsNullOrEmpty() == false)
					{
						picImage.LoadImage(view.GetRowCellValue(e.RowHandle, "Path").ToStringNullToEmpty());
					}
					else
					{
						if (view.GetRowCellValue(e.RowHandle, "Url").IsNullOrEmpty() == false)
							picImage.LoadImage(GlobalVar.ImageServerInfo.CdnUrl + view.GetRowCellValue(e.RowHandle, "Url").ToStringNullToEmpty());
					}
				}
			};
			#endregion

			#region GoodsAttribute
			gridAttributes.Init();
			gridAttributes.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ProductID", Visible = false },				
				new XGridColumn() { FieldName = "AttributeTypeID", Visible = false },
				new XGridColumn() { FieldName = "AttributeID", Visible = false },
				new XGridColumn() { FieldName = "AttributeTypeName", Width = 100 },
				new XGridColumn() { FieldName = "AttributeValue", Width = 200 },
				new XGridColumn() { FieldName = "ValueType", Visible = false },
				new XGridColumn() { FieldName = "AttributeName", Visible = false },
				new XGridColumn() { FieldName = "AttributeCode", Visible = false },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridAttributes.ColumnFix("RowNo");
			gridAttributes.SetEditable("AttributeValue");
			#endregion

			#region Info Notice
			gridInfoNotices.Init();
			gridInfoNotices.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "ProductID", Visible = false },
				new XGridColumn() { FieldName = "InfoNoticeItemID", Visible = false },
				new XGridColumn() { FieldName = "InfoNoticeItemName", Width = 150 },
				new XGridColumn() { FieldName = "InfoNoticeValue", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridInfoNotices.ColumnFix("RowNo");
			gridInfoNotices.SetRespositoryItemTextEdit("InfoNoticeValue");
			gridInfoNotices.SetEditable("InfoNoticeValue");
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<ProductModel>();
			rteDescription.Clear();

			gridItems.Clear<ProductItemModel>();
			gridImages.Clear<ProductImageModel>();
			gridAttributes.Clear<ProductAttributeModel>();
			gridInfoNotices.Clear<ProductInfoNoticeModel>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, SaveAndClose = true });
			EditMode = EditModeEnum.New;
			txtCode.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			if (param == null)
			{
				DataInit();
				return;
			}

			try
			{
				var model = WasHandler.GetData<ProductModel>("Biz", "GetData", "Select", new DataMap() { { "ID", param } });
				if (model != null)
				{
					SetControlData(model);
					rteDescription.EditValue = model.DescriptionRTF;

					if (model.Items == null)
						model.Items = new List<ProductItemModel>();
					if (model.Images == null)
						model.Images = new List<ProductImageModel>();
					if (model.Attributes == null)
						model.Attributes = new List<ProductAttributeModel>();
					if (model.InfoNotices == null)
						model.InfoNotices = new List<ProductInfoNoticeModel>();

					gridItems.DataSource = model.Items;
					gridImages.DataSource = model.Images;
					gridAttributes.DataSource = model.Attributes;
					gridInfoNotices.DataSource = model.InfoNotices;
				}
				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, SaveAndClose = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtCode.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			//유효성 검사
			if (DataValidate() == false) return;

			try
			{
				var model = this.GetControlData<ProductModel>();
				model.Description = rteDescription.EditText;
				model.DescriptionRTF = rteDescription.EditValue;

				model.Items = gridItems.DataSource as List<ProductItemModel>;				
				model.Attributes = gridAttributes.DataSource as List<ProductAttributeModel>;
				model.InfoNotices = gridInfoNotices.DataSource as List<ProductInfoNoticeModel>;
				model.Images = gridImages.DataSource as List<ProductImageModel>;

				//유효성검사
				foreach(var item in model.Items)
				{
					if (item.Option1Type.IsNullOrEmpty() == false && item.Option1Name.IsNullOrEmpty())
						throw new Exception("옵션유형(1)을 선택하였으면 옵션값(1)을 입력해야 합니다.");
					if (item.Option1Name.IsNullOrEmpty() == false && item.Option1Type.IsNullOrEmpty())
						throw new Exception("옵션값(1)을 입력하였으면 옵션유형(1)을 선택해야 합니다.");
					if (item.Option2Type.IsNullOrEmpty() == false && item.Option2Name.IsNullOrEmpty())
						throw new Exception("옵션유형(2)을 선택하였으면 옵션값(2)을 입력해야 합니다.");
					if (item.Option2Name.IsNullOrEmpty() == false && item.Option2Type.IsNullOrEmpty())
						throw new Exception("옵션값(2)을 입력하였으면 옵션유형(2)을 선택해야 합니다.");
				}

				foreach(var image in model.Images)
				{
					if (image.ImageType.IsNullOrEmpty())
						throw new Exception("이미지유형을 선택하세요!!!");
					if (image.ImageGroup.IsNullOrEmpty())
						throw new Exception("이미지그룹을 선택하세요!!!");
					if (image.Url.IsNullOrEmpty() && image.Path.IsNullOrEmpty())
						throw new Exception("이미지를 선택해야 합니다!!!");
				}

				foreach(var attribute in model.Attributes)
				{
					if (attribute.AttributeTypeID == null)
						throw new Exception("속성유형을 선택해야 합니다.");
					if (attribute.AttributeValue.IsNullOrEmpty())
						throw new Exception("속성값을 입력해야 합니다.");
				}

				//이미지 파일저장
				foreach (var image in model.Images.Where(x => x.Path.IsNullOrEmpty() == false))
				{
					var url = FTPHandler.UploadGoods(GlobalVar.ImageServerInfo, image.Path, model.BrandID.ToString(), model.Code, image.ImageType, image.ImageGroup);
					image.Url = url;
				}

				//정보 저장
				using (var res = WasHandler.Execute<ProductModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					model.ID = res.Result.ReturnValue.ToIntegerNullToNull();
				}

				ShowMsgBox("저장하였습니다.");
				callback(arg, model.ID);
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
				var map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteProduct", map, "ID"))
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
				
		private void DeleteOption()
		{
			try
			{
				if (gridItems.DataSource == null || gridItems.RowCount == 0 || gridItems.FocusedRowHandle < 0)
					return;

				if (gridItems.GetValue(gridItems.FocusedRowHandle, "ID").IsNullOrEmpty())
				{
					gridItems.DeleteRow(gridItems.FocusedRowHandle);
					gridItems.UpdateCurrentRow();
				}
				else
				{
					var map = new DataMap() { { "ID", gridItems.GetValue(gridItems.FocusedRowHandle, "ID") } };
					using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteProductItem", map, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						ShowMsgBox("삭제하였습니다.");
						DataLoad(txtID.EditValue);
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void DeleteImage()
		{
			try
			{
				if (gridImages.DataSource == null || gridImages.RowCount == 0 || gridImages.FocusedRowHandle < 0)
					return;

				if (gridImages.GetValue(gridImages.FocusedRowHandle, "ID").IsNullOrEmpty())
				{
					gridImages.DeleteRow(gridImages.FocusedRowHandle);
					gridImages.UpdateCurrentRow();
				}
				else
				{
					var map = new DataMap() { { "ID", gridImages.GetValue(gridImages.FocusedRowHandle, "ID") } };
					using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteProductImage", map, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);

						ShowMsgBox("삭제하였습니다.");
						DataLoad(txtID.EditValue);
					}
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		private void LoadInfoNotice()
		{
			try
			{
				DataMap map = new DataMap()
				{
					{ "CategoryID", lupCategoryID.EditValue },
					{ "ProductID", txtID.EditValue }
				};
				gridInfoNotices.BindList<ProductInfoNoticeModel>("Biz", "GetList", "SelectProductInfoNoticeByCategory", map);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}