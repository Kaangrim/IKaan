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

namespace IKaan.Biz.View.Sys.AA
{
	public partial class AAGroupForm : EditForm
	{
		public AAGroupForm()
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

			lcItemGroupName.Tag = true;
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
			lupParentID.BindData("GroupList", "없음", true);
		}

		void InitGrid()
		{
			#region 그룹
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80 },
				new XGridColumn() { FieldName = "HierID", Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "GroupName", Width = 300 },				
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

			#region 권한그룹
			gridGroupRole.Init();
			gridGroupRole.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "HierID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "RoleName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridGroupRole.SetEditable("Checked");
			gridGroupRole.SetRepositoryItemCheckEdit("Checked");
			gridGroupRole.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridGroupRole.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridGroupRole.ColumnFix("RowNo");
			gridGroupRole.ColumnFix("Checked");
			#endregion

			#region 그룹메뉴
			gridGroupMenu.Init();
			gridGroupMenu.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "HierID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "MenuName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridGroupMenu.SetEditable("Checked");
			gridGroupMenu.SetRepositoryItemCheckEdit("Checked");
			gridGroupMenu.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridGroupMenu.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridGroupMenu.ColumnFix("RowNo");
			gridGroupMenu.ColumnFix("Checked");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<AAGroup>();
			gridGroupRole.Clear<AAGroupRole>();
			gridGroupMenu.Clear<AAGroupMenu>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtGroupName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<AAGroup>("AA", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<AAGroup>("AA", "GetData", "Select", new DataMap() { { "ID", id } });
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<AAGroupRole> groupRole = new List<AAGroupRole>();
				IList<AAGroupMenu> groupMenu = new List<AAGroupMenu>();

				if (data.GroupRole != null)
					groupRole = data.GroupRole;

				if (data.GroupMenu != null)
					groupMenu = data.GroupMenu;

				SetControlData(data);
				gridGroupRole.DataSource = groupRole;
				gridGroupMenu.DataSource = groupMenu;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtGroupName.Focus();
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
				if (DataValidate() == false)
					return;

				var groupData = this.GetControlData<AAGroup>();
				IList<AAGroupRole> groupRoleList = new List<AAGroupRole>();
				IList<AAGroupMenu> groupMenuList = new List<AAGroupMenu>();

				if (gridGroupRole.RowCount > 0)
					groupRoleList = gridGroupRole.DataSource as List<AAGroupRole>;

				if (gridGroupMenu.RowCount > 0)
					groupMenuList = gridGroupMenu.DataSource as List<AAGroupMenu>;

				groupData.GroupRole = groupRoleList;
				groupData.GroupMenu = groupMenuList;

				using (var res = WasHandler.Execute<AAGroup>("AA", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", groupData, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("AA", "Delete", "DeleteAAGroup", map, "ID"))
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