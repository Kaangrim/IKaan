using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.SYS.AA;
using IKaan.Model.Was;

namespace IKaan.Biz.View.Sys.Forms
{
	public partial class AAUserForm : EditForm
	{
		public AAUserForm()
		{
			InitializeComponent();

			btnPasswordInit.Click += delegate (object sender, EventArgs e) { doClearPassword(); };
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

			lcItemUserName.Tag = true;

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

			#region 사용자그룹
			gridUserGroup.Init();
			gridUserGroup.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "Checked" },				
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "HierID", Width = 100, Visible = false },
				new XGridColumn() { FieldName = "GroupName", Width = 200 },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridUserGroup.SetEditable("Checked");
			gridUserGroup.SetRepositoryItemCheckEdit("Checked");
			gridUserGroup.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridUserGroup.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
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
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UpdateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "UpdateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridUserRole.SetEditable("Checked");
			gridUserRole.SetRepositoryItemCheckEdit("Checked");
			gridUserRole.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridUserRole.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
			gridUserRole.ColumnFix("RowNo");
			gridUserRole.ColumnFix("Checked");
			#endregion

			#region 비밀번호변경이력
			gridPasswordHistory.Init();
			gridPasswordHistory.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "CreateDate", Width = 150, HorzAlignment = HorzAlignment.Center, FormatType = FormatType.DateTime, FormatString = "yyyy.MM.dd HH:mm:ss" },
				new XGridColumn() { FieldName = "CreateByName", Width = 80, HorzAlignment = HorzAlignment.Center }
			);
			gridPasswordHistory.SetColumnBackColor(SkinUtils.ForeColor, "RowNo");
			gridPasswordHistory.SetColumnForeColor(SkinUtils.BackColor, "RowNo");
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
			ClearControlData<AAUser>();
			gridUserGroup.Clear<AAUserGroup>();
			gridUserRole.Clear<AAUserRole>();
			gridPasswordHistory.Clear<AAUserPasswordHist>();
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			EditMode = EditModeEnum.New;
			txtUserName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<AAUser>("AA", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<AAUser>("AA", "GetData", "Select", new DataMap() { { "ID", id } });
				if (data == null)
					throw new Exception("조회할 데이터가 없습니다.");

				IList<AAUserGroup> userGroup = new List<AAUserGroup>();
				IList<AAUserRole> userRole = new List<AAUserRole>();
				IList<AAUserPasswordHist> userPasswordHist = new List<AAUserPasswordHist>();

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

				var userData = this.GetControlData<AAUser>();
				List<AAUserGroup> userGroup = new List<AAUserGroup>();
				List<AAUserRole> userRole = new List<AAUserRole>();

				if (gridUserGroup.RowCount > 0)
					userGroup = gridUserGroup.DataSource as List<AAUserGroup>;

				if (gridUserRole.RowCount > 0)
					userRole = gridUserRole.DataSource as List<AAUserRole>;

				userData.UserGroup = userGroup;
				userData.UserRole = userRole;					

				using (var res = WasHandler.Execute<AAUser>("AA", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", userData, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("AA", "Delete", "DeleteAAUser", map, "ID"))
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
				DataMap map = new DataMap() { { "ID", txtID.EditValue } };
				using (var res = WasHandler.Execute<DataMap>("AA", "ClearPassword", "ClearPassword", map, "ID"))
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