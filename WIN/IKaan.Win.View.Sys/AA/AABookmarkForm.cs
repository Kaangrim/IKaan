using System;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;
using IKaan.Model.SYS.AA;

namespace IKaan.Win.View.Sys.AA
{
	public partial class AABookmarkForm : EditForm
	{
		public AABookmarkForm()
		{
			InitializeComponent();

			btnUp.Click += delegate (object sender, EventArgs e) { doGridMoveUp(); };
			btnDown.Click += delegate (object sender, EventArgs e) { doGridMoveDown(); };
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			txtFindText.Focus();
		}

		protected override void InitButtons()
		{
			base.InitButtons();
			SetToolbarButtons(new ToolbarButtons() { Refresh = true, Save = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();
			
			InitGrid();
		}

		void InitGrid()
		{
			#region Bookmark User
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "UserID", HorzAlignment = HorzAlignment.Center, Width = 100 },
				new XGridColumn() { FieldName = "UserName", Width = 100 },
				new XGridColumn() { FieldName = "BookmarkCount", HorzAlignment = HorzAlignment.Center, Width = 80 }
			);
			gridList.ColumnFix("RowNo");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == System.Windows.Forms.MouseButtons.Left && e.Clicks == 1)
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

			#region Bookmark By User
			gridBookmark.Init();
			gridBookmark.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "UserID", Visible = false },
				new XGridColumn() { FieldName = "MenuID", Visible = false },
				new XGridColumn() { FieldName = "MenuName", Width = 300 },
				new XGridColumn() { FieldName = "SortOrder", HorzAlignment = HorzAlignment.Center, Width = 80 }
			);
			gridBookmark.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<AABookmarkUser>("AA", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var list = WasHandler.GetList<AABookmark>("AA", "GetList", "Select", new DataMap() { { "ID", id } });
				gridBookmark.DataSource = list;
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
				var model = this.GetControlData<AABookmark>();
				using (var res = WasHandler.Execute<AABookmark>("AA", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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

		private void doGridMoveUp()
		{
			int rowIndex = gridBookmark.FocusedRowHandle;
			if (rowIndex < 1)
				return;

			int id = gridBookmark.GetValue(rowIndex, "ID").ToIntegerNullToZero();
			int prevOrder = gridBookmark.GetValue(rowIndex - 1, "SortOrder").ToIntegerNullToZero();
			gridBookmark.SetValue(rowIndex, "SortOrder", prevOrder - 1);
			gridBookmark.Refresh();
		}
		private void doGridMoveDown()
		{
			int rowIndex = gridBookmark.FocusedRowHandle;
			if (rowIndex > gridBookmark.RowCount - 2)
				return;

			int id = gridBookmark.GetValue(rowIndex, "ID").ToIntegerNullToZero();
			int nextOrder = gridBookmark.GetValue(rowIndex + 1, "SortOrder").ToIntegerNullToZero();
			gridBookmark.SetValue(rowIndex, "SortOrder", nextOrder + 1);
			gridBookmark.Refresh();
		}
	}
}