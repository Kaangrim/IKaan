using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Scrap;
using IKaan.Model.Scrap.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Biz.Scrap.Common
{
	public partial class ScrapSiteEditForm : EditForm
	{
		public ScrapSiteEditForm()
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

			lcItemName.Tag = true;
			lcItemUrl.Tag = true;

			SetFieldNames();
			
			lcItemName.SetFieldName("SiteName");
		
			txtID.SetEnable(false);
			txtCreatedOn.SetEnable(false);
			txtCreatedByName.SetEnable(false);
			txtUpdatedOn.SetEnable(false);
			txtUpdatedByName.SetEnable(false);

			spnSortOrder.SetFormat("D", false, HorzAlignment.Near);
			chkUseYn.Init();

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupScrapSite.BindData("ScrapSite", "All");
			lupParentID.BindData("ScrapSite", "Site", true);
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "HierID", Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "SiteName", Width = 250 },
				new XGridColumn() { FieldName = "ID", Caption = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "SiteName", Width = 200, Visible = false },
				new XGridColumn() { FieldName = "Url", Width = 120 },
				new XGridColumn() { FieldName = "SortOrder", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "UseYn", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "Description", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedBy" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedBy" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
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
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}

		protected override void DataInit()
		{
			txtID.Clear();

			object siteCode = lupParentID.EditValue;
			lupParentID.BindData("ScrapSite", "Site", true);
			lupParentID.EditValue = siteCode;

			txtName.Clear();
			txtUrl.Clear();
			spnSortOrder.Clear();
			memDescription.Clear();

			txtCreatedOn.Clear();
			txtCreatedByName.Clear();
			txtUpdatedOn.Clear();
			txtUpdatedByName.Clear();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			this.EditMode = EditModeEnum.New;
			txtName.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<ScrapSiteModel>("Scrap", "GetList", "Select", new DataMap()
			{
				{ "ParentID", lupScrapSite.EditValue },
				{ "FindText", txtFindText.EditValue }
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
				var data = WasHandler.GetData<ScrapSiteModel>("Scrap", "GetData", "Select", new DataMap() { { "ID", id } });
				SetControlData(data);

				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtName.Focus();
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		protected override void DataSave(object arg, SaveCallback callback)
		{
			if (DataValidate() == false) return;

			try
			{
				var model = GetControlData<ScrapSiteModel>();
				using (var res = WasHandler.Execute<ScrapSiteModel>("Scrap", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				using (var res = WasHandler.Execute<DataMap>("Scrap", "Delete", "DeleteScrapSite", new DataMap() { { "ID", txtID.EditValue } }, null))
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