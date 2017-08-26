using System;
using System.Drawing;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraLayout;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.IKBase;
using IKaan.Win.Core.Controls.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Enum;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.View.Base.Common
{
	public partial class CodeEditForm : EditForm
	{
		public CodeEditForm()
		{
			InitializeComponent();

			lupParentCode.EditValueChanged += delegate (object sender, EventArgs e)
			{
				CodeGroupChanged();
			};
			lupCodeGroup.EditValueChanged += delegate (object sender, EventArgs e)
			{
				DataLoad(null);
			};
		}

		void CodeGroupChanged()
		{
			try
			{
				var row = lupParentCode.GetSelectedDataRow();
				if (row != null)
				{
					txtCode.Properties.MaxLength = (row as LookupSource).MaxLength;
					if ((row as LookupSource).MaxLength == 0)
						esCodeLength.Text = " (Max Length: 20)";
					else
						esCodeLength.Text = " (Max Length: " + (row as LookupSource).MaxLength.ToString() + ")";
					esCodeLength.AppearanceItemCaption.ForeColor = Color.Red;

					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option1, lcItemCodeValue01);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option2, lcItemCodeValue02);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option3, lcItemCodeValue03);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option4, lcItemCodeValue04);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option5, lcItemCodeValue05);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option6, lcItemCodeValue06);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option7, lcItemCodeValue07);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option8, lcItemCodeValue08);
					SetOptionTextAndLable(lupParentCode, (row as LookupSource).Option9, lcItemCodeValue09);
				}
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
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

		protected override void InitButton()
		{
			base.InitButton();
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
			lupCodeGroup.BindData("CodeGroup", "All");
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
				new XGridColumn() { FieldName = "MaxLength", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
				new XGridColumn() { FieldName = "SortOrder", Width = 80, HorzAlignment = HorzAlignment.Far, FormatType = FormatType.Numeric, FormatString = "N0" },
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
			gridList.BindList<CodeModel>("Base", "GetList", "Select", new DataMap()
			{
				{ "ParentCode", lupCodeGroup.EditValue },
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
				var data = WasHandler.GetData<CodeModel>("Base", "GetData", "Select", new DataMap() { { "ID", id } });
				SetControlData(data);
				CodeGroupChanged();

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
				var model = GetControlData<CodeModel>();
				using (var res = WasHandler.Execute<CodeModel>("Base", "Save", (this.EditMode == EditModeEnum.New) ? "Insert" : "Update", model, "ID"))
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

				using (var res = WasHandler.Execute<DataMap>("Base", "Delete", "DeleteCode", data, null))
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