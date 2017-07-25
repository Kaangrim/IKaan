using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.LIB.LG;
using IKaan.Model.LIB.LM;

namespace IKaan.Biz.View.Lib.LG
{
	public partial class LGGoodsEditForm : EditForm
	{
		public LGGoodsEditForm()
		{
			InitializeComponent();
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);
			
			InitGrid();
		}

		void InitGrid()
		{
			#region Attribute List
			gridAttrList.Init();
			gridAttrList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo", Width = 40, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "AttrType", Visible = false },
				new XGridColumn() { FieldName = "GoodsID", Visible = false },
				new XGridColumn() { FieldName = "AttrCode", Visible = false },
				new XGridColumn() { FieldName = "AttrName", Width = 100 },
				new XGridColumn() { FieldName = "AttrValueCode", Width = 80 },
				new XGridColumn() { FieldName = "AttrValueName", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridAttrList.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridAttrList.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridAttrList.ColumnFix("RowNo");
			#endregion

			//#region Brand Image List
			//gridDetail.Init();
			//gridDetail.AddGridColumns(
			//	new XGridColumn() { FieldName = "RowNo" },
			//	new XGridColumn() { FieldName = "ID", Visible = false },
			//	new XGridColumn() { FieldName = "BrandID", Visible = false },
			//	new XGridColumn() { FieldName = "ImageType", Width = 100 },
			//	new XGridColumn() { FieldName = "ImageUrl", Width = 300 },
			//	new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
			//	new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
			//	new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
			//	new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			//);
			//gridDetail.SetRepositoryItemLookUpEdit("ImageType");
			//gridDetail.SetRepositoryItemButtonEdit("ImageUrl");
			//gridDetail.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			//gridDetail.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			//gridDetail.ColumnFix("RowNo");

			//gridDetail.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			//{
			//	if (e.RowHandle < 0)
			//		return;

			//	try
			//	{
			//		if (e.Button == MouseButtons.Left && e.Clicks == 2)
			//		{
			//			GridView view = sender as GridView;
			//			AddImage(new DataMap()
			//			{
			//				{ "ID", view.GetRowCellValue(e.RowHandle, "ID") },
			//				{ "BrandID", view.GetRowCellValue(e.RowHandle, "BrandID") },
			//				{ "ImageType", view.GetRowCellValue(e.RowHandle, "ImageType") },
			//				{ "ImageUrl", view.GetRowCellValue(e.RowHandle, "ImageUrl") }
			//			});
			//		}
			//	}
			//	catch (Exception ex)
			//	{
			//		ShowErrBox(ex);
			//	}
			//};
			//#endregion

			#region Option List
			gridOption.Init();
			gridOption.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "CustomerID", Visible = false },
				new XGridColumn() { FieldName = "PersonID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "CustomerName", Width = 200 },
				new XGridColumn() { FieldName = "PersonName", Width = 100 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridOption.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridOption.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridOption.ColumnFix("RowNo");
			#endregion

			#region Goods Image List
			gridImage.Init();
			gridImage.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "ChannelID", Visible = false },
				new XGridColumn() { FieldName = "StartDate", Width = 80 },
				new XGridColumn() { FieldName = "EndDate", Width = 80 },
				new XGridColumn() { FieldName = "ChannelName", Width = 200 },
				new XGridColumn() { FieldName = "ChannelMargin", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "BrandMargin", Width = 100, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N2" },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridImage.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridImage.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridImage.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<LGGoods>();
			gridOption.Clear<LGGoodsItem>();
			gridImage.Clear<LGGoodsImage>();
			gridDetail.Clear<LGGoodsDetail>();
			gridPrice.Clear<LGGoodsPrice>();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtGoodsNo.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			try
			{
				var model = WasHandler.GetData<LGGoods>("LG", "GetData", "Select", new DataMap()
				{
					{ "ID", param },
					{ "GoodsID", param }
				});
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<LGGoodsDetail> goodsDetail = new List<LGGoodsDetail>();
				IList<LGGoodsItem> goodsOption = new List<LGGoodsItem>();
				IList<LGGoodsImage> goodsImage = new List<LGGoodsImage>();
				IList<LGGoodsPrice> goodsPrice = new List<LGGoodsPrice>();

				if (model.GoodsDetail != null)
					goodsDetail = model.GoodsDetail;
				if (model.GoodsOption != null)
					goodsOption = model.GoodsOption;
				if (model.GoodsImage != null)
					goodsImage = model.GoodsImage;
				if (model.GoodsPrice != null)
					goodsPrice = model.GoodsPrice;

				SetControlData(model);
				gridOption.DataSource = goodsOption;
				gridImage.DataSource = goodsImage;
				gridDetail.DataSource = goodsDetail;
				gridPrice.DataSource = goodsPrice;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtGoodsNo.Focus();

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
				var model = this.GetControlData<LGGoods>();
				IList<LGGoodsDetail> goodsDetail = new List<LGGoodsDetail>();
				IList<LGGoodsItem> goodsOption = new List<LGGoodsItem>();
				IList<LGGoodsImage> goodsImage = new List<LGGoodsImage>();
				IList<LGGoodsPrice> goodsPrice = new List<LGGoodsPrice>();

				model.GoodsDetail = goodsDetail;
				model.GoodsOption = goodsOption;
				model.GoodsImage = goodsImage;
				model.GoodsPrice = goodsPrice;

				using (var res = WasHandler.Execute<LGGoods>("LG", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("LM", "Delete", "DeleteLGGoods", map, "ID"))
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

		private void AddImage(DataMap parameter = null)
		{
			try
			{
				//if (parameter == null)
				//{
				//	parameter = new DataMap()
				//	{
				//		{ "ID", null },
				//		{ "BrandID", txtID.EditValue },
				//		{ "ImageType", null },
				//		{ "ImageUrl", null }
				//	};
				//}
				//using (LMBrandImageForm form = new LMBrandImageForm()
				//{
				//	Text = "브랜드이미지",
				//	StartPosition = FormStartPosition.CenterScreen,
				//	ParamsData = parameter,
				//	IsLoadingRefresh = true
				//})
				//{					
				//	if (form.ShowDialog() == DialogResult.OK)
				//	{
				//		DetailDataLoad(txtID.EditValue);
				//	}
				//}
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
				//if (gridDetail.FocusedRowHandle < 0)
				//	return;

				//DataMap map = new DataMap() { { "ID", gridDetail.GetValue(gridDetail.FocusedRowHandle, "ID") } };
				//using (var res = WasHandler.Execute<DataMap>("LM", "Delete", "DeleteLMBrandImage", map, "ID"))
				//{
				//	if (res.Error.Number != 0)
				//		throw new Exception(res.Error.Message);

				//	ShowMsgBox("삭제하였습니다.");
				//	DataLoad(txtID.EditValue);
				//}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}