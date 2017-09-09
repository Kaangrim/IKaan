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
	public partial class UserEditForm : EditForm
	{
		public UserEditForm()
		{
			InitializeComponent();

			btnPasswordInit.Click += delegate (object sender, EventArgs e) { doClearPassword(); };
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

			lcItemUserName.Tag = true;

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
			lupUserType.BindData("UserType", null, true);
		}

		void InitGrid()
		{
			#region 사용자목록
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 60 },
				new XGridColumn() { FieldName = "UserName", Width = 150 },
				new XGridColumn() { FieldName = "UserType", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "UserTypeName", Width = 100 },
				new XGridColumn() { FieldName = "LoginID", Width = 100 },
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

			#region 사용자그룹
			gridUserGroup.Init();
			gridUserGroup.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },				
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "HierID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "GroupName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridUserGroup.SetEditable("Checked");
			gridUserGroup.SetRepositoryItemCheckEdit("Checked");
			gridUserGroup.ColumnFix("RowNo");
			gridUserGroup.ColumnFix("Checked");
			#endregion

			#region 권한그룹
			gridUserRole.Init();
			gridUserRole.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "HierID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "RoleName", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridUserRole.SetEditable("Checked");
			gridUserRole.SetRepositoryItemCheckEdit("Checked");
			gridUserRole.ColumnFix("RowNo");
			gridUserRole.ColumnFix("Checked");
			#endregion

			#region 비밀번호변경이력
			gridPasswordHistory.Init();
			gridPasswordHistory.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" }
			);
			gridPasswordHistory.ColumnFix("RowNo");
			#endregion
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			ClearControlData<UserModel>();
			gridUserGroup.Clear<UserGroupModel>();
			gridUserRole.Clear<UserRoleModel>();
			gridPasswordHistory.Clear<UserPasswordHistModel>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtUserName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<UserModel>("Base", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<UserModel>("Base", "GetData", "Select", new DataMap() { { "ID", id } });
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<UserGroupModel> userGroup = new List<UserGroupModel>();
				IList<UserRoleModel> userRole = new List<UserRoleModel>();
				IList<UserPasswordHistModel> userPasswordHist = new List<UserPasswordHistModel>();

				if (data.UserGroup != null)
					userGroup = data.UserGroup;

				if (data.UserRole != null)
					userRole = data.UserRole;

				if (data.UserPasswordHist != null)
					userPasswordHist = data.UserPasswordHist;

				SetControlData(data);
				gridUserGroup.DataSource = userGroup;
				gridUserRole.DataSource = userRole;
				gridPasswordHistory.DataSource = userPasswordHist;

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtUserName.Focus();

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
				if (DataValidate() == false) return;

				var userData = this.GetControlData<UserModel>();
				var userGroup = new List<UserGroupModel>();
				var userRole = new List<UserRoleModel>();

				if (gridUserGroup.RowCount > 0)
					userGroup = gridUserGroup.DataSource as List<UserGroupModel>;

				if (gridUserRole.RowCount > 0)
					userRole = gridUserRole.DataSource as List<UserRoleModel>;

				userData.UserGroup = userGroup;
				userData.UserRole = userRole;					

				using (var res = WasHandler.Execute<UserModel>("Base", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", userData, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteUser", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
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

		void doClearPassword()
		{
			try
			{
				using (var res = WasHandler.Execute<DataMap>("Base", "ClearPassword", "ClearPassword", new DataMap() { { "ID", txtID.EditValue } }, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					ShowMsgBox("초기화했습니다.");
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}
	}
}