using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraLayout;
using DevExpress.XtraTab.Buttons;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.IKBiz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Handler;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Catalog
{
	public partial class GoodsEditForm : EditForm
	{
		public GoodsEditForm()
		{
			InitializeComponent();

			lcTab.SelectedPageChanged += (object sender, LayoutTabPageChangedEventArgs e) =>
			{
				TabButtonEnabled();
			};
			lcTab.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				if (e.Button.Tag.ToStringNullToEmpty() == "DEL")
				{
					if (lcTab.SelectedTabPage.Name == lcGroupOption.Name)
					{
						DeleteOption();
					}
					else if (lcTab.SelectedTabPage.Name == lcGroupImage.Name)
					{
						DeleteImage();
					}
				}
			};

			lupCategoryID.EditValueChanged += (object sender, EventArgs e) =>
			{
				LoadInfoNotice();
			};

			btnCreateOption.Click += (object sender, EventArgs e) =>
			{
				try
				{
					if (lupOption1Type.EditValue.IsNullOrEmpty() == false && txtOption1Name.EditValue.IsNullOrEmpty())
						throw new Exception("옵션유형(1)을 선택했으면 옵션값(1)을 입력해야 합니다.");

					if (lupOption2Type.EditValue.IsNullOrEmpty() == false && txtOption2Name.EditValue.IsNullOrEmpty())
						throw new Exception("옵션유형(2)을 선택했으면 옵션값(2)을 입력해야 합니다.");

					if (txtOption1Name.EditValue.IsNullOrEmpty() && txtOption2Name.EditValue.IsNullOrEmpty())
						return;

					if (gridItem.DataSource == null)
						gridItem.DataSource = new List<GoodsItemModel>();

					string option1 = txtOption1Name.Text;
					string option2 = txtOption2Name.Text;
					//string[] opt1 = option1.Split(',');
					//string[] opt2 = option2.Split(',');

					if (option1.IsNullOrEmpty() == false && option2.IsNullOrEmpty() == false)
					{
						foreach (string opt1 in option1.Split(','))
						{
							foreach (string opt2 in option2.Split(','))
							{
								if ((gridItem.DataSource as List<GoodsItemModel>).Where(x => x.Option1Name == opt1 && x.Option2Name == opt2).Any() == false)
								{
									gridItem.AddRow(new GoodsItemModel()
									{
										Option1Type = lupOption1Type.EditValue.ToString(),
										Option1Name = opt1,
										Option2Type = lupOption2Type.EditValue.ToString(),
										Option2Name = opt2,
										RowState = "INSERT"
									});
								}
							}
						}
					}
					else
					{
						if (option1.IsNullOrEmpty() == false)
						{
							foreach (string opt1 in option1.Split(','))
							{
								if ((gridItem.DataSource as List<GoodsItemModel>).Where(x => x.Option1Name == opt1).Any() == false)
								{
									gridItem.AddRow(new GoodsItemModel()
									{
										Option1Type = lupOption1Type.EditValue.ToString(),
										Option1Name = opt1,
										RowState = "INSERT"
									});
								}
							}
						}
						else if (option2.IsNullOrEmpty() == false)
						{
							foreach (string opt2 in option2.Split(','))
							{
								if ((gridItem.DataSource as List<GoodsItemModel>).Where(x => x.Option2Name == opt2).Any() == false)
								{
									gridItem.AddRow(new GoodsItemModel()
									{
										Option2Type = lupOption2Type.EditValue.ToString(),
										Option2Name = opt2,
										RowState = "INSERT"
									});
								}
							}
						}
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			btnSaveImage.Click += (object sender, EventArgs e) =>
			{
				var imagePath = picImage.GetLoadedImageLocation();
				if (imagePath.IsNullOrEmpty())
				{
					ShowMsgBox("먼저 이미지를 선택하세요!!!");
					return;
				}

				if (gridImage.DataSource == null)
					gridImage.DataSource = new List<GoodsImageModel>();

				gridImage.MainView.BeginUpdate();
				(gridImage.DataSource as List<GoodsImageModel>).Add(new GoodsImageModel()
				{
					ImageType = lupImageType.EditValue.ToStringNullToEmpty(),
					ImageTypeName = lupImageType.Text,
					ImageGroup = lupImageGroup.EditValue.ToStringNullToEmpty(),
					ImageGroupName = lupImageGroup.Text,
					ImageUrl = imagePath,
					RowState = "INSERT"
				});
				gridImage.MainView.EndUpdate();
			};

			picImage.Properties.ImageChanged += (object sender, EventArgs e) =>
			{
				try
				{
					var path = picImage.GetLoadedImageLocation();
					var size = ImageUtils.GetSizePixel(path);
					if (path.IsNullOrEmpty() == false)
					{
						esImageInfo.Text =
							" 경로명 : " + Path.GetDirectoryName(path) + Environment.NewLine +
							" 파일명 : " + Path.GetFileName(path) + Environment.NewLine +
							" 사이즈 : " + size.Width + "px, " + size.Height + "px";
						esImageInfo.TextVisible = true;
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			picSub1Image.Click += (object sender, EventArgs e) =>
			{
				if (picSub1Image.Tag.IsNullOrEmpty() == false)
					picMainImage.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, picSub1Image.Tag));
			};
			picSub2Image.Click += (object sender, EventArgs e) =>
			{
				if (picSub2Image.Tag.IsNullOrEmpty() == false)
					picMainImage.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, picSub2Image.Tag));
			};
			picSub3Image.Click += (object sender, EventArgs e) =>
			{
				if (picSub3Image.Tag.IsNullOrEmpty() == false)
					picMainImage.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, picSub3Image.Tag));
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtGoodsName.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			lcItemGoodsCode.Tag = true;
			lcItemGoodsName.Tag = true;
			lupCategoryID.Tag = true;
			lupBrandID.Tag = true;

			base.InitControls();

			SetFieldNames();

			lcGroupAttribute.Text = DomainUtils.GetFieldName("Attribute");
			lcGroupDetail.Text = DomainUtils.GetFieldName("GoodsDetail");
			lcGroupImage.Text = DomainUtils.GetFieldName("GoodsImage");
			lcGroupOption.Text = DomainUtils.GetFieldName("GoodsOption");
			lcGroupInfoNotice.Text = DomainUtils.GetFieldName("InfoNotice");

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			lupCategoryID.BindData("CategoryList", "카테고리선택");
			lupBrandID.BindData("BrandList", "브랜드선택");
			lupOption1Type.BindData("OptionType", "None");
			lupOption2Type.BindData("OptionType", "None");
			lupImageType.BindData("ImageType", null, false, new DataMap() { { "Option2", "Y" } });
			lupImageGroup.BindData("ImageGroup");

			spnListPrice.SetFormat("N0", false);
			spnSalePrice.SetFormat("N0", false);

			picImage.Properties.SizeMode = PictureSizeMode.Squeeze;
			picMainImage.Properties.SizeMode = PictureSizeMode.Squeeze;
			picSub1Image.Properties.SizeMode = PictureSizeMode.Squeeze;
			picSub2Image.Properties.SizeMode = PictureSizeMode.Squeeze;
			picSub3Image.Properties.SizeMode = PictureSizeMode.Squeeze;

			InitGrid();

			lcTab.SelectedTabPageIndex = 0;
			TabButtonEnabled();
		}

		void InitGrid()
		{
			#region GoodsAttribute
			gridAttribute.Init();
			gridAttribute.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "GoodsID", Visible = false },
				new XGridColumn() { FieldName = "AttrType", Visible = false },
				new XGridColumn() { FieldName = "AttrTypeName", Width = 100 },
				new XGridColumn() { FieldName = "AttrCode", Width = 80 },
				new XGridColumn() { FieldName = "AttrName", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridAttribute.ColumnFix("RowNo");
			gridAttribute.SetRespositoryItemTextEdit("AttrCode");
			gridAttribute.SetRespositoryItemTextEdit("AttrName");
			gridAttribute.SetEditable("AttrType", "AttrCode", "AttrName");
			#endregion

			#region GoodsItem
			gridItem.Init();
			gridItem.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "GoodsID", Visible = false },
				new XGridColumn() { FieldName = "Option1Type", Width = 100 },
				new XGridColumn() { FieldName = "Option1Name", Width = 100 },
				new XGridColumn() { FieldName = "Option2Type", Width = 100 },
				new XGridColumn() { FieldName = "Option2Name", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridItem.ColumnFix("RowNo");
			gridItem.SetRepositoryItemLookUpEdit("Option1Type", "OptionType", "None");
			gridItem.SetRepositoryItemLookUpEdit("Option2Type", "OptionType", "None");
			#endregion

			#region GoodsImage
			gridImage.Init();
			gridImage.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "GoodsID", Visible = false },
				new XGridColumn() { FieldName = "ImageType", Visible = false },
				new XGridColumn() { FieldName = "ImageTypeName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ImageGroup", Visible = false },
				new XGridColumn() { FieldName = "ImageGroupName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ImageUrl", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridImage.ColumnFix("RowNo");
			#endregion

			#region Info Notice
			gridInfoNotice.Init();
			gridInfoNotice.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "GoodsID", Visible = false },
				new XGridColumn() { FieldName = "InfoNoticeItemID", Visible = false },
				new XGridColumn() { FieldName = "InfoNoticeItemName", Width = 150 },
				new XGridColumn() { FieldName = "InfoNoticeValue", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
			);
			gridInfoNotice.ColumnFix("RowNo");
			gridInfoNotice.SetRespositoryItemTextEdit("InfoNoticeValue");
			gridInfoNotice.SetEditable("InfoNoticeValue");
			#endregion
		}

		protected override void DataInit()
		{
			ClearControlData<GoodsModel>();
			rteDescription.Clear();

			gridItem.Clear<GoodsItemModel>();
			gridImage.Clear<GoodsImageModel>();
			gridAttribute.Clear<GoodsAttributeModel>();
			gridInfoNotice.Clear<GoodsInfoNoticeModel>();

			picImage.EditValue = null;
			picMainImage.EditValue = null;
			picMainImage.Tag = null;
			picSub1Image.EditValue = null;
			picSub1Image.Tag = null;
			picSub2Image.EditValue = null;
			picSub2Image.Tag = null;
			picSub3Image.EditValue = null;
			picSub3Image.Tag = null;

			chkUseYn.Checked = true;
			
			esImageInfo.TextVisible = false;
			TabButtonEnabled();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtGoodsCode.Focus();
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
				var model = WasHandler.GetData<GoodsModel>("Biz", "GetData", "Select", new DataMap()
				{
					{ "ID", param }
				});

				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				SetControlData(model);

				if (model.Detail == null)
					model.Detail = new GoodsDetailModel();
				if (model.Item == null)
					model.Item = new List<GoodsItemModel>();
				if (model.Image == null)
					model.Image = new List<GoodsImageModel>();
				if (model.Attribute == null)
					model.Attribute = new List<GoodsAttributeModel>();
				if (model.InfoNotice == null)
					model.InfoNotice = new List<GoodsInfoNoticeModel>();

				rteDescription.EditValue = model.Detail.DescriptionRTF;

				gridItem.DataSource = model.Item;
				gridImage.DataSource = model.Image;
				gridAttribute.DataSource = model.Attribute;
				gridInfoNotice.DataSource = model.InfoNotice;

				picMainImage.EditValue = null;
				picSub1Image.EditValue = null;
				picSub2Image.EditValue = null;
				picSub3Image.EditValue = null;

				if (model.Image != null && model.Image.Count > 0)
				{
					int i = 0;
					foreach (GoodsImageModel image in model.Image)
					{
						i++;
						if (i > 3)
							break;

						if (i == 1)
						{
							picMainImage.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, image.ImageUrl));
							picSub1Image.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, image.ImageUrl));
							picSub1Image.Tag = image.ImageUrl;
						}
						else if (i == 2)
						{
							picSub2Image.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, image.ImageUrl));
							picSub2Image.Tag = image.ImageUrl;
						}
						else if (i == 3)
						{
							picSub3Image.LoadAsync(string.Format("{0}/{1}", ConstsVar.IMG_URL, image.ImageUrl));
							picSub3Image.Tag = image.ImageUrl;
						}
					}
				}

				btnCreateOption.Enabled = true;
				TabButtonEnabled();
				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtGoodsCode.Focus();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			if (DataValidate() == false) return;

			try
			{
				var model = this.GetControlData<GoodsModel>();

				model.Detail = new GoodsDetailModel()
				{
					Description = rteDescription.EditText,
					DescriptionRTF = rteDescription.EditValue
				};

				model.Item = (gridItem.DataSource == null) ? null : gridItem.DataSource as List<GoodsItemModel>;				
				model.Attribute = (gridAttribute.DataSource == null) ? null : gridAttribute.DataSource as List<GoodsAttributeModel>;
				model.InfoNotice = (gridInfoNotice.DataSource == null) ? null : gridInfoNotice.DataSource as List<GoodsInfoNoticeModel>;
				model.Image = null;

				//이미지를 제외한 정보 저장
				using (var res = WasHandler.Execute<GoodsModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					model.ID = res.Result.ReturnValue.ToIntegerNullToNull();
				}

				model.Detail = null;
				model.Item = null;
				model.Attribute = null;
				model.InfoNotice = null;
				model.Image = (gridImage.DataSource == null) ? null : gridImage.DataSource as List<GoodsImageModel>;

				//이미지 파일저장
				if (model.Image != null && model.Image.Count > 0) {
					//FTP저장
					foreach (GoodsImageModel image in model.Image.Where(x => x.RowState == "INSERT"))
					{
						var url = FTPHandler.UploadGoods(image.ImageUrl, model.BrandID.ToString(), model.ID.ToString(), image.ImageType, image.ImageGroup);
						image.ImageUrl = url;
						image.GoodsID = model.ID;
					}

					//이미지정보 저장
					using (var res = WasHandler.Execute<GoodsImageModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
					{
						if (res.Error.Number != 0)
							throw new Exception(res.Error.Message);
					}
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteGoods", map, "ID"))
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

		private void TabButtonEnabled()
		{
			try
			{				
				lcTab.CustomHeaderButtons.OfType<CustomHeaderButton>().ToList().ForEach(x =>
				{
					if (lcTab.SelectedTabPage.Name == lcGroupOption.Name ||
					    lcTab.SelectedTabPage.Name == lcGroupImage.Name)
					{
						if (x.Tag.ToStringNullToEmpty() == "DEL")
							x.Visible = true;
						else
							x.Visible = false;
					}
					else
					{
						x.Visible = false;
					}
				});
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}
		
		private void DeleteOption()
		{
			try
			{
				if (gridItem.DataSource == null || gridItem.RowCount == 0 || gridItem.FocusedRowHandle < 0)
					return;

				if (gridItem.GetValue(gridItem.FocusedRowHandle, "ID").IsNullOrEmpty())
				{
					gridItem.DeleteRow(gridItem.FocusedRowHandle);
					gridItem.UpdateCurrentRow();
				}
				else
				{
					DataMap map = new DataMap() { { "ID", gridItem.GetValue(gridItem.FocusedRowHandle, "ID") } };
					using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteGoodsItem", map, "ID"))
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
				if (gridImage.DataSource == null || gridImage.RowCount == 0 || gridImage.FocusedRowHandle < 0)
					return;

				if (gridImage.GetValue(gridImage.FocusedRowHandle, "ID").IsNullOrEmpty())
				{
					gridImage.DeleteRow(gridImage.FocusedRowHandle);
					gridImage.UpdateCurrentRow();
				}
				else
				{
					DataMap map = new DataMap() { { "ID", gridImage.GetValue(gridImage.FocusedRowHandle, "ID") } };
					using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteGoodsImage", map, "ID"))
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
				{ "GoodsID", txtID.EditValue }
			};
				gridInfoNotice.BindList<GoodsInfoNoticeModel>("Biz", "GetList", "SelectGoodsInfoNoticeByCategory", map);
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}