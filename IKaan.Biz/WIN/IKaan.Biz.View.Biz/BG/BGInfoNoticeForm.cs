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
using IKaan.Model.BIZ.BG;

namespace IKaan.Biz.View.Biz.BG
{
	public partial class BGInfoNoticeForm : EditForm
	{
		public BGInfoNoticeForm()
		{
			InitializeComponent();

			btnAddItem.Click += delegate (object sender, EventArgs e)
			{
				gridItems.AddNewRow();
			};
			btnDeleteItem.Click += delegate (object sender, EventArgs e)
			{
				
			};
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
			#region List
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "InfoNoticeName", Width = 200 },
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

			#region Item List
			gridItems.Init();
			gridItems.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "InfoNoticeID", Visible = false },
				new XGridColumn() { FieldName = "ItemName", CaptionCode = "InfoNoticeItemName", Width = 200 },
				new XGridColumn() { FieldName = "UseYn", Width = 80 },
				new XGridColumn() { FieldName = "SortOrder", Width = 80, HorzAlignment = HorzAlignment.Near },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridItems.SetEditable("ItemName", "UseYn", "SortOrder");
			gridItems.SetRespositoryItemTextEdit("ItemName");
			gridItems.SetRepositoryItemCheckEdit("UseYn");
			gridItems.SetRepositoryItemSpinEdit("SortOrder", "D", null, true, HorzAlignment.Near);
			gridItems.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<BGInfoNotice>();
			gridItems.Clear<BGInfoNoticeItem>();

			btnAddItem.Enabled = false;
			btnDeleteItem.Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtInfoNoticeName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<BGInfoNotice>("BG", "GetList", "Select", new DataMap()
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
				var model = WasHandler.GetData<BGInfoNotice>("BG", "GetData", "Select", new DataMap()
				{
					{ "ID", id },
					{ "InfoNoticeID", id }
				});
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<BGInfoNoticeItem> items = new List<BGInfoNoticeItem>();

				if (model.Items != null)
					items = model.Items;

				SetControlData(model);
				gridItems.DataSource = items;

				btnAddItem.Enabled = true;
				if (gridItems.RowCount > 0)
					btnDeleteItem.Enabled = true;
				else
					btnDeleteItem.Enabled = false;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtInfoNoticeName.Focus();

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
				var model = this.GetControlData<BGInfoNotice>();
				List<BGInfoNoticeItem> items = new List<BGInfoNoticeItem>();

				if (gridItems.RowCount > 0)
					items = gridItems.DataSource as List<BGInfoNoticeItem>;

				model.Items = items;

				using (var res = WasHandler.Execute<BGInfoNotice>("BG", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("BG", "Delete", "DeleteBGInfoNotice", map, "ID"))
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
	}
}