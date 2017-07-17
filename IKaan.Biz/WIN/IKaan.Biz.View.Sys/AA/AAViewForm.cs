using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.SYS.AA;
using IKaan.Model.Was;

namespace IKaan.Biz.View.Sys.AA
{
	public partial class AAViewForm : EditForm
	{
		public AAViewForm()
		{
			InitializeComponent();
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

			lcItemViewName.Tag = true;

			SetFieldNames();

			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupViewType.BindData("ViewType", null, true);
			lupParentID.BindData("ViewList", "없음", true);
			lupModuleID.BindData("ModuleList", "없음", true);
			lupHelpID.BindData("HelpList", "없음", true);
		}

		void InitGrid()
		{
			#region 화면목록
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "HierID", Visible = false },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 60 },
				new XGridColumn() { FieldName = "ViewName", Width = 150 },
				new XGridColumn() { FieldName = "ViewType", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "ViewTypeName", Width = 100 },
				new XGridColumn() { FieldName = "ModuleID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "ModuleName", Width = 100 },
				new XGridColumn() { FieldName = "Namespace", Width = 100 },
				new XGridColumn() { FieldName = "Instance", Width = 100 },
				new XGridColumn() { FieldName = "UseYn", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridList.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridList.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
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

			#region  기능버튼설정
			gridViewButtons.Init();
			gridViewButtons.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "UseYn", Visible = false },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "ButtonName", Width = 150 },
				new XGridColumn() { FieldName = "ButtonType", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "ButtonTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "LinkViewCode", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridViewButtons.SetEditable("Checked", "LinkViewCode");
			gridViewButtons.SetRepositoryItemCheckEdit("Checked");
			gridViewButtons.SetRepositoryItemLookUpEdit("LinkViewCode", "Code", "Name", "ViewList", "없음");
			gridViewButtons.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridViewButtons.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridViewButtons.ColumnFix("RowNo");
			gridViewButtons.ColumnFix("Checked");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<AAView>();
			gridViewButtons.Clear<AAViewButton>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtViewName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<AAView>("AA", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<AAView>("AA", "GetData", "Select", new DataMap() { { "ID", id } });
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<AAViewButton> viewButton = new List<AAViewButton>();

				if (data.ViewButton != null)
					viewButton = data.ViewButton;

				SetControlData(data);
				gridViewButtons.DataSource = viewButton;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtViewName.Focus();

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
				var viewData = this.GetControlData<AAView>();
				List<AAViewButton> viewButtonList = new List<AAViewButton>();

				if (gridViewButtons.RowCount > 0)
					viewButtonList = gridViewButtons.DataSource as List<AAViewButton>;

				viewData.ViewButton = viewButtonList;

				using (var res = WasHandler.Execute<AAView>("AA", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", viewData, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("AA", "Delete", "DeleteAAView", map, "ID"))
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