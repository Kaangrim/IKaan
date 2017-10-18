using System;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab.ViewInfo;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Attribute;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Model;

namespace IKaan.Win.View.Biz.Master.Attribute
{
	public partial class AttributeListForm : EditForm
	{
		public AttributeListForm()
		{
			InitializeComponent();

			lcTab1.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					ShowAttributeTypeEdit(null);
				}
			};
			lcTab2.CustomHeaderButtonClick += (object sender, CustomHeaderButtonEventArgs e) =>
			{
				if (e.Button.Kind == ButtonPredefines.Glyph && e.Button.Tag.ToStringNullToEmpty() == "ADD")
				{
					ShowAttributeEdit(null);
				}
			};
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
			base.InitControls();

			SetFieldNames();

			txtAttributeType.SetEnable(false);

			InitGrid();
		}

		void InitGrid()
		{
			gridAttributeType.Init();
			gridAttributeType.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "AttributeTypeName", Width = 200 },
				new XGridColumn() { FieldName = "Code", Width = 100 },
				new XGridColumn() { FieldName = "ValueType", Visible = false },
				new XGridColumn() { FieldName = "ValueTypeName", Width = 100, HorzAlignment = HorzAlignment.Center },
				new XGridColumn() { FieldName = "UseYn", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridAttributeType.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridAttributeType.ColumnFix("RowNo");
			gridAttributeType.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowAttributeTypeEdit(view.GetRowCellValue(e.RowHandle, "ID"));
					}
					else if (e.Button == MouseButtons.Left && e.Clicks == 1)
					{
						GridView view = sender as GridView;
						txtAttributeType.EditValue = view.GetRowCellValue(e.RowHandle, "ID");
						txtAttributeType.EditText = view.GetRowCellValue(e.RowHandle, "Name");
						DetailDataLoad(view.GetRowCellValue(e.RowHandle, "ID"));
					}
				}
				catch (Exception ex)
				{
					ShowErrBox(ex);
				}
			};

			gridAttribute.Init();
			gridAttribute.AddGridColumns(
				new XGridColumn() { FieldName = "RowNo" },
				new XGridColumn() { FieldName = "ID", HorzAlignment = HorzAlignment.Center, Width = 80, Visible = false },
				new XGridColumn() { FieldName = "Name", CaptionCode = "AttributeName", Width = 200 },
				new XGridColumn() { FieldName = "Code", Width = 100 },
				new XGridColumn() { FieldName = "UseYn", HorzAlignment = HorzAlignment.Center, Width = 80, RepositoryItem = gridAttribute.GetRepositoryItemCheckEdit() },
				new XGridColumn() { FieldName = "AttributeTypeID", Visible = false },
				new XGridColumn() { FieldName = "CreatedOn" },
				new XGridColumn() { FieldName = "CreatedByName" },
				new XGridColumn() { FieldName = "UpdatedOn" },
				new XGridColumn() { FieldName = "UpdatedByName" }
			);
			gridAttribute.ColumnFix("RowNo");
			gridAttribute.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
					return;

				try
				{
					if (e.Button == MouseButtons.Left && e.Clicks == 2)
					{
						GridView view = sender as GridView;
						ShowAttributeEdit(view.GetRowCellValue(e.RowHandle, "ID"));
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

		protected override void DataLoad(object param = null)
		{
			gridAttributeType.BindList<AttributeTypeModel>("Biz", "GetList", "Select", new DataMap()
			{
				{ "FindText", txtFindText.EditValue }
			});
		}

		void DetailDataLoad(object id)
		{
			try
			{
				gridAttribute.BindList<AttributeModel>("Biz", "GetList", "Select", new DataMap()
				{
					{ "AttributeTypeID", id }
				});
			}
			catch(Exception ex)
			{
				ShowErrBox(ex);
			}
		}

		void ShowAttributeTypeEdit(object id)
		{
			using(var form = new AttributeTypeEditForm())
			{
				form.Text = "속성유형편집";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = id;
				if (form.ShowDialog() == DialogResult.OK)
					DataLoad();
			}
		}
		void ShowAttributeEdit(object id)
		{
			if (txtAttributeType.EditValue == null)
			{
				ShowMsgBox("먼저 좌측의 속성유형을 선택해야 합니다.");
				return;
			}

			using (var form = new AttributeEditForm())
			{
				form.Text = "속성편집";
				form.StartPosition = FormStartPosition.CenterScreen;
				form.IsLoadingRefresh = true;
				form.ParamsData = new DataMap()
				{
					{ "AttributeTypeID", txtAttributeType.EditValue },
					{ "ID", id }
				};
				if (form.ShowDialog() == DialogResult.OK)
					DetailDataLoad(txtAttributeType.EditValue);
			}
		}
	}
}