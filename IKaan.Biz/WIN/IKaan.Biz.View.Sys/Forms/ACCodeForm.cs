using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Controls.Common;
using IKaan.Biz.Core.Controls.Grid;
using IKaan.Biz.Core.Enum;
using IKaan.Biz.Core.Forms;
using IKaan.Biz.Core.Model;
using IKaan.Biz.Core.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.SYS.AC;

namespace IKaan.Biz.View.Sys.Forms
{
	public partial class ACCodeForm : EditForm
	{
		public ACCodeForm()
		{
			InitializeComponent();

			lupParentCode.EditValueChanged += delegate (object sender, EventArgs e)
			{
				XLookup lookup = sender as XLookup;
				var row = lookup.GetSelectedDataRow();
				if (row != null)
				{
					SetOptionTextAndLable(lookup, (row as LookupSource).Option1, lcItemCodeValue01);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option2, lcItemCodeValue02);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option3, lcItemCodeValue03);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option4, lcItemCodeValue04);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option5, lcItemCodeValue05);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option6, lcItemCodeValue06);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option7, lcItemCodeValue07);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option8, lcItemCodeValue08);
					SetOptionTextAndLable(lookup, (row as LookupSource).Option9, lcItemCodeValue09);

				}
			};
		}

		void SetOptionTextAndLable(XLookup lookup, string value, LayoutControlItem layout)
		{
			if (lookup.EditValue.IsNullOrEmpty())
			{
				layout.SetFieldName();
				if (layout.Control != null)
					(layout.Control as TextEdit).SetEnable(true);
			}
			else
			{
				if (value.IsNullOrEmpty())
				{
					layout.SetFieldCaption(null);
					if (layout.Control != null)
						(layout.Control as TextEdit).SetEnable(false);
				}
				else
				{
					layout.SetFieldCaption(value);
					if (layout.Control != null)
						(layout.Control as TextEdit).SetEnable(true);
				}
			}
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

			lcItemName.Tag = true;
			lcItemCode.Tag = true;

			SetFieldNames();
			
			lcItemName.SetFieldName("CodeName");
			lcItemValue.SetFieldName("CodeValue");
		
			txtID.SetEnable(false);
			txtCreateDate.SetEnable(false);
			txtCreateByName.SetEnable(false);
			txtUpdateDate.SetEnable(false);
			txtUpdateByName.SetEnable(false);

			spnSortOrder.SetFormat("D", false, HorzAlignment.Near);
			spnMaxLength.SetFormat("D", false, HorzAlignment.Near);
			chkUseYn.Init();

			InitCombo();
			InitGrid();
		}

		void InitCombo()
		{
			lupParentCode.BindData("CodeGroup", "ROOT", true);
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "HierID", Visible = false },
				new XGridColumn() { FieldName = "HierName", CaptionCode = "CodeName", Width = 250 },
				new XGridColumn() { FieldName = "ID", Caption = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "Code", Width = 120 },
				new XGridColumn() { FieldName = "Value", CaptionCode = "CodeValue", Width = 120 },
				new XGridColumn() { FieldName = "UseYn", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridList.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "CodeValue01", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue02", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue03", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue04", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue05", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue06", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue07", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue08", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue09", Width = 100 },
				new XGridColumn() { FieldName = "CodeValue10", Width = 100 }
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

			object group_code = lupParentCode.EditValue;
			lupParentCode.BindData("CodeGroup", "ROOT", true);
			lupParentCode.EditValue = group_code;

			txtName.Clear();
			txtCode.Clear();
			txtValue.Clear();
			spnSortOrder.Clear();
			memDescription.Clear();

			txtCodeValue01.Clear();
			txtCodeValue02.Clear();
			txtCodeValue03.Clear();
			txtCodeValue04.Clear();
			txtCodeValue05.Clear();

			txtCreateDate.Clear();
			txtCreateByName.Clear();
			txtUpdateDate.Clear();
			txtUpdateByName.Clear();

			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true });
			this.EditMode = EditModeEnum.New;
			txtCode.Focus();
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<ACCode>("AC", "GetList", "Select", new DataMap() { { "FindText", txtFindText.EditValue } });

			if (param != null)
				DetailDataLoad(param);
			else
				DataInit();
		}

		void DetailDataLoad(object id)
		{
			try
			{
				var data = WasHandler.GetData<ACCode>("AC", "GetData", "Select", new DataMap() { { "ID", id } });
				SetControlData(data);
				SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true, Save = true, SaveAndNew = true, Delete = true });
				this.EditMode = EditModeEnum.Modify;
				txtCode.Focus();
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
				var model = GetControlData<ACCode>();
				using (var res = WasHandler.Execute<ACCode>("AC", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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
				DataMap data = new DataMap()
				{
					{ "ID", txtID.EditValue }
				};

				using (var res = WasHandler.Execute<DataMap>("AC", "Delete", "DeleteACCode", data, null))
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