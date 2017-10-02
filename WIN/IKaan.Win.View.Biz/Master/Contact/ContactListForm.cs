using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Model.Biz.Master.Common;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Biz.Master.Contact
{
	public partial class ContactListForm : EditForm
	{
		public ContactListForm()
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
			SetToolbarButtons(new ToolbarButtons() { New = true, Refresh = true });
		}
		protected override void InitControls()
		{
			base.InitControls();

			SetFieldNames();

			lupContactType.BindData("ContactType", "All");
			lupUseYn.BindData("Yn", "All");
			lupUseYn.EditValue = "Y";

			InitGrid();
		}

		void InitGrid()
		{
			gridList.Init();
			gridList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "ContactName", Width = 100 },
				new XGridColumn() { FieldName = "ContactType", Visible = false },
				new XGridColumn() { FieldName = "ContactTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "PhoneNo", Width = 100 },
				new XGridColumn() { FieldName = "MobileNo", Width = 100 },
				new XGridColumn() { FieldName = "FaxNo", Width = 100 },
				new XGridColumn() { FieldName = "Email", Width = 200 },
				new XGridColumn() { FieldName = "UseYn", Width = 60, HorzAlignment = HorzAlignment.Center},
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridList.ColumnFix("RowNo");
			gridList.SetRepositoryItemCheckEdit("UseYn");

			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch(Exception ex)
				{
					ShowErrBox(ex);
				}
			};
		}

		protected override void DataLoad(object param = null)
		{
			gridList.BindList<ContactModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "ContactType", lupContactType.EditValue },
				{ "UseYn", lupUseYn.EditValue },
				{ "FindText", txtFindText.EditValue }
			});
		}
		protected override void DataInit()
		{
			ShowEdit(null);
		}

		protected override void ShowEdit(object data = null)
		{
			using(var form = new ContactEditForm())
			{
				form.Text = "담당자등록";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = data;
				if (form.ShowDialog() == DialogResult.OK)
				{
					DataLoad();
				}
			}
		}
	}
}