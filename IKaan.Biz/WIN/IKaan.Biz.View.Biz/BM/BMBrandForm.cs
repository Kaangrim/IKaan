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
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.View.Biz.BM
{
	public partial class BMBrandForm : EditForm
	{
		public BMBrandForm()
		{
			InitializeComponent();

			btnAddImage.Click += delegate (object sender, EventArgs e) { AddImage(); };
			btnDeleteImage.Click += delegate (object sender, EventArgs e) { DeleteImage(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
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

			lupFindUseYn.BindData("Yn", "All");

			InitGrid();
		}

		void InitGrid()
		{
			#region Brand List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "BrandName", Width = 200 },
				new XGridColumn() { FieldName = "UseYn", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.SetRepositoryItemCheckEdit("UseYn");
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Brand Image List
			gridBrandImage.Init();
			gridBrandImage.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "BrandID", Visible = false },
				new XGridColumn() { FieldName = "ImageType", Width = 100 },
				new XGridColumn() { FieldName = "ImageUrl", Width = 300 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridBrandImage.SetRepositoryItemLookUpEdit("ImageType");
			gridBrandImage.SetRepositoryItemButtonEdit("ImageUrl");
			gridBrandImage.ColumnFix("RowNo");

			gridBrandImage.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						AddImage(new DataMap()
						{
							{ "ID", view.GetRowCellValue(e.RowHandle, "ID") },
							{ "BrandID", view.GetRowCellValue(e.RowHandle, "BrandID") },
							{ "ImageType", view.GetRowCellValue(e.RowHandle, "ImageType") },
							{ "ImageUrl", view.GetRowCellValue(e.RowHandle, "ImageUrl") }
						});
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
			#endregion

			#region Brand Customer List
			gridBrandCustomer.Init();
			gridBrandCustomer.AddGridColumns(
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
			gridBrandCustomer.ColumnFix("RowNo");
			#endregion

			#region Brand Channel List
			gridBrandChannel.Init();
			gridBrandChannel.AddGridColumns(
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
			gridBrandChannel.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<BMBrand>();
			gridBrandImage.Clear<BMBrandImage>();
			gridBrandCustomer.Clear<BMCustomerBrand>();
			gridBrandChannel.Clear<BMChannelBrand>();

			btnAddImage.Enabled = false;
			btnDeleteImage.Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtBrandName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BMBrand>("BM", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "UseYn", lupFindUseYn.EditValue }
			});

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var model = WasHandler.GetData<BMBrand>("BM", "GetData", "Select", new DataMap()
				{
					{ "ID", id },
					{ "BrandID", id }
				});
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<BMBrandImage> brandImage = new List<BMBrandImage>();
				IList<BMCustomerBrand> brandCustomer = new List<BMCustomerBrand>();
				IList<BMChannelBrand> brandChannel = new List<BMChannelBrand>();

				if (model.BrandImage != null)
					brandImage = model.BrandImage;
				if (model.BrandCustomer != null)
					brandCustomer = model.BrandCustomer;
				if (model.BrandChannel != null)
					brandChannel = model.BrandChannel;

				SetControlData(model);
				gridBrandImage.DataSource = brandImage;
				gridBrandCustomer.DataSource = brandCustomer;
				gridBrandChannel.DataSource = brandChannel;

				btnAddImage.Enabled = true;
				if (gridBrandImage.RowCount > 0)
					btnDeleteImage.Enabled = true;
				else
					btnDeleteImage.Enabled = false;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtBrandName.Focus();

			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			try
			{
				var model = this.GetControlData<BMBrand>();
				List<BMBrandImage> brandImage = new List<BMBrandImage>();

				if (gridBrandImage.RowCount > 0)
					brandImage = gridBrandImage.DataSource as List<BMBrandImage>;

				model.BrandImage = brandImage;

				using (var res = WasHandler.Execute<BMBrand>("BM", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("BM", "Delete", "DeleteBMBrand", map, "ID"))
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
				if (parameter == null)
				{
					parameter = new DataMap()
					{
						{ "ID", null },
						{ "BrandID", txtID.EditValue },
						{ "ImageType", null },
						{ "ImageUrl", null }
					};
				}
				using (BMBrandImageForm form = new BMBrandImageForm()
				{
					Text = "브랜드이미지",
					StartPosition = FormStartPosition.CenterScreen,
					ParamsData = parameter,
					IsLoadingRefresh = true
				})
				{					
					if (form.ShowDialog() == DialogResult.OK)
					{
						DetailDataLoad(txtID.EditValue);
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
				if (gridBrandImage.FocusedRowHandle < 0)
					return;

				DataMap map = new DataMap() { { "ID", gridBrandImage.GetValue(gridBrandImage.FocusedRowHandle, "ID") } };
				using (var res = WasHandler.Execute<DataMap>("LM", "Delete", "DeleteBMBrandImage", map, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("삭제하였습니다.");
					DetailDataLoad(txtID.EditValue);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}