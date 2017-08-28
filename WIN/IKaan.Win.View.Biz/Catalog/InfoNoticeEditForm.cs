using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Catalog
{
	public partial class InfoNoticeEditForm : EditForm
	{
		public InfoNoticeEditForm()
		{
			InitializeComponent();

			lcTab.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				if (e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					(gridItems.DataSource as List<InfoNoticeItemModel>).Add(new InfoNoticeItemModel());
				}
				else if (e.Button.Tag.ToStringNullToEmpty() == "DEL")
				{
					gridItems.MainView.DeleteRow(gridItems.FocusedRowHandle);
				}
			};
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButton()
		{
			base.InitButton();
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
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
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
				new XGridColumn() { FieldName = "CreateDate" },
				new XGridColumn() { FieldName = "CreateByName" },
				new XGridColumn() { FieldName = "UpdateDate" },
				new XGridColumn() { FieldName = "UpdateByName" }
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
			ClearControlData<InfoNoticeModel>();
			gridItems.Clear<InfoNoticeItemModel>();

			lcTab.CustomHeaderButtons[0].Enabled =
				lcTab.CustomHeaderButtons[1].Enabled = false;

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtInfoNoticeName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<InfoNoticeModel>("Biz", "GetList", "Select", new DataMap()
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
				var model = WasHandler.GetData<InfoNoticeModel>("Biz", "GetData", "Select", new DataMap()
				{
					{ "ID", id },
					{ "InfoNoticeID", id }
				});
				if (model == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<InfoNoticeItemModel> items = new List<InfoNoticeItemModel>();

				if (model.Items != null)
					items = model.Items;

				SetControlData(model);
				gridItems.DataSource = model.Items ?? new List<InfoNoticeItemModel>();

				lcTab.CustomHeaderButtons[0].Enabled = true;
				if (gridItems.RowCount > 0)
					lcTab.CustomHeaderButtons[1].Enabled = true;
				else
					lcTab.CustomHeaderButtons[1].Enabled = false;

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
				var model = this.GetControlData<InfoNoticeModel>();
				List<InfoNoticeItemModel> items = new List<InfoNoticeItemModel>();

				if (gridItems.RowCount > 0)
					items = gridItems.DataSource as List<InfoNoticeItemModel>;

				model.Items = items;

				using (var res = WasHandler.Execute<InfoNoticeModel>("Biz", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Biz", "Delete", "DeleteInfoNotice", map, "ID"))
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