using System;
using DevExpress.Utils;
using IKaan.Base.Map;
using IKaan.Model.Base;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Scrap.Forms
{
	public partial class BrandMappingEditForm : EditForm
	{
		public BrandMappingEditForm()
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
			SetToolbarButtons(new ToolbarButtons() { Refresh = true });
		}
		protected override void InitControls()
		{
			try
			{
				base.InitControls();

				SetFieldNames();

				InitGrid();
			}
			catch (Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void InitGrid()
		{
			#region Site List
			gridSiteList.Init();
			gridSiteList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", Visible = false },
				new XGridColumn() { FieldName = "Code", Visible = false },
				new XGridColumn() { FieldName = "Name", Caption = "검색경로명", Width = 200 },
				new XGridColumn() { FieldName = "Value", Caption = "검색URL", Width = 200 },
				new XGridColumn() { FieldName = "CodeValue01", Caption = "사이트URL", Width = 200 },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridSiteList.ColumnFix("RowNo");
			gridSiteList.SetRepositoryItemCheckEdit("Checked");
			gridSiteList.SetEditable("Checked");
			#endregion

			#region Brand List
			gridBrandList.Init();
			gridBrandList.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "SiteCode", Visible = false },
				new XGridColumn() { FieldName = "BrandCode", Width = 80, Visible = false },
				new XGridColumn() { FieldName = "BrandName", Width = 150 },
				new XGridColumn() { FieldName = "GoodsCnt", Width = 60, HorzAlignment = HorzAlignment.Far },
				new XGridColumn() { FieldName = "BrandURL", Width = 300 }
			);
			gridBrandList.ColumnFix("RowNo");
			#endregion
			
		}

		protected override void LoadForm()
		{
			base.LoadForm();
			DataLoad();
		}
		
		protected override void DataLoad(object param = null)
		{
			gridSiteList.BindList<CodeModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue },
				{ "UseYn", "Y" },
				{ "ParentCode", "CrawlingSite" },
				{ "IsNotParent", "Y" }
			});
		}
	}
}
 