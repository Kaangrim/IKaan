using System;
using System.Collections.Generic;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Base.Authority;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Base.Authority
{
	public partial class GroupEditForm : EditForm
	{
		public GroupEditForm()
		{
			InitializeComponent();
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

			lcItemGroupName.Tag = true;
			SetFieldNames();

			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

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
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
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

			#region 권한그룹
			gridGroupRole.Init();
			gridGroupRole.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "HierID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "RoleName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridGroupRole.SetEditable("Checked");
			gridGroupRole.SetRepositoryItemCheckEdit("Checked");
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
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridGroupMenu.SetEditable("Checked");
			gridGroupMenu.SetRepositoryItemCheckEdit("Checked");
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
			ClearControlData<GroupModel>();
			gridGroupRole.Clear<GroupRoleModel>();
			gridGroupMenu.Clear<GroupMenuModel>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txGroupModelName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<GroupModel>("Base", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<GroupModel>("Base", "GetData", "Select", new DataMap() { { "ID", id } });
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<GroupRoleModel> groupRole = new List<GroupRoleModel>();
				IList<GroupMenuModel> groupMenu = new List<GroupMenuModel>();

				if (data.GroupRole != null)
					groupRole = data.GroupRole;

				if (data.GroupMenu != null)
					groupMenu = data.GroupMenu;

				SetControlData(data);
				gridGroupRole.DataSource = groupRole;
				gridGroupMenu.DataSource = groupMenu;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txGroupModelName.Focus();
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

				var groupData = this.GetControlData<GroupModel>();
				IList<GroupRoleModel> groupRoleList = new List<GroupRoleModel>();
				IList<GroupMenuModel> groupMenuList = new List<GroupMenuModel>();

				if (gridGroupRole.RowCount > 0)
					groupRoleList = gridGroupRole.DataSource as List<GroupRoleModel>;

				if (gridGroupMenu.RowCount > 0)
					groupMenuList = gridGroupMenu.DataSource as List<GroupMenuModel>;

				groupData.GroupRole = groupRoleList;
				groupData.GroupMenu = groupMenuList;

				using (var res = WasHandler.Execute<GroupModel>("Base", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", groupData, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteGroup", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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