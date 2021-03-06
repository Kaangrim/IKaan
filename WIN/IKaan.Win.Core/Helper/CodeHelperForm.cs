﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Controls.Grid;
using IKaan.Win.Core.Forms;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Helper
{
	public partial class CodeHelperForm : BaseForm
	{
		public CodeHelperForm()
		{
			InitializeComponent();
			Initialize();

			txtFindText.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					BindData();
				}
				else
				{
					if (e.KeyCode == Keys.Escape)
					{
						ReturnData = null;
						Close();
					}
				}
			};
			gridList.RowCellClick += delegate (object sender, RowCellClickEventArgs e)
			{
				if (e.RowHandle < 0)
				{
					return;
				}
				if (e.Button == MouseButtons.Left && e.Clicks == 2)
				{
					if (e.RowHandle < 0)
					{
						return;
					}
					SetReturnDataAndClose();
				}
			};
			gridList.MainView.KeyDown += delegate (object sender, KeyEventArgs e)
			{
				if (e.KeyCode == Keys.Enter)
				{
					if (gridList.MainView.FocusedRowHandle < 0)
					{
						return;
					}
					SetReturnDataAndClose();
				}
			};
		}

		private void Initialize()
		{
			this.LookAndFeel.UseDefaultLookAndFeel =
				sc.LookAndFeel.UseDefaultLookAndFeel = false;
			this.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSkin);
			sc.LookAndFeel.SetSkinStyle(GlobalVar.SkinInfo.FormSubSkin);

			Parameters = new DataMap();
		}

		public string[] DisplayFields { get; set; }
		public DataMap Parameters { get; set; }
		public string CodeField { get; set; }
		public string NameField { get; set; }
		public string CodeGroup { get; set; }

		public void Init()
		{
			lcItemFindText.SetFieldName("FindText");
			lcItemUseYn.SetFieldName("UseYn");

			lupUseYn.BindData("Yn", "ALL", true);
			if (Parameters != null)
			{
				lupUseYn.EditValue = Parameters.GetValue("UseYn");
				txtFindText.EditValue = Parameters.GetValue("FindText");
			}

			gridList.Init();
			if (DisplayFields != null)
			{
				var columns = new List<XGridColumn>();
				foreach (string field in DisplayFields)
				{
					columns.Add(new XGridColumn() { FieldName = field });
				}
				gridList.AddGridColumns(columns.ToArray());
				
			}
			SetColumnWidth();
		}
		public void Init(string codeField, string nameField, DataMap parameters, params string[] displayFields)
		{
			CodeField = codeField;
			NameField = nameField;
			Parameters = parameters;
			DisplayFields = displayFields;
			Init();
		}

		public void BindData(object data = null)
		{
			if (data == null)
			{
				if (txtFindText.EditValue != null)
				{
					Parameters.SetValue("FindText", txtFindText.EditValue);
				}
				if (Parameters == null)
					Parameters = new DataMap();

				Parameters.SetValue("UseYn", lupUseYn.EditValue);

				data = CodeHelper.Search(CodeGroup, Parameters);
				if (data == null)
				{
					MsgBox.Show("검색된 데이터가 없습니다.");
					txtFindText.Focus();
					return;
				}
			}

			if (data != null)
			{
				gridList.DataSource = data;
				SetGridColumnName(data.GetType());
			}
		}

		protected override void OnShown(EventArgs e)
		{
			base.OnShown(e);
			if (gridList.MainView.RowCount > 0)
			{
				gridList.MainView.Focus();
			}
			else
			{
				txtFindText.Focus();
			}
		}

		private void SetReturnDataAndClose()
		{
			var rowHandle = gridList.MainView.FocusedRowHandle;
			DataMap returnMap = new DataMap();
			gridList.MainView.Columns.ToList().ForEach(x =>
			{
				returnMap.SetValue(x.FieldName, gridList.MainView.GetRowCellValue(rowHandle, x.FieldName));
			});
			ReturnData = returnMap;
			SetModifiedCount();
			Close();
		}

		private void SetColumnWidth()
		{
			try
			{
				int colWidth = 0;
				List<string> list = new List<string>();
				if (this.DisplayFields != null)
				{
					list = this.DisplayFields.ToList();
				}
				else
				{
					foreach (GridColumn col in gridList.MainView.Columns)
					{
						list.Add(col.FieldName);
					}
				}

				int column_count = 0;
				foreach (string colName in list)
				{
					if (gridList.MainView.Columns.Where(x => x.FieldName == colName).Any() && gridList.MainView.Columns[colName].Visible)
					{
						if (column_count < (list.Count - 1))
							gridList.MainView.Columns[colName].BestFit();
						colWidth += gridList.MainView.Columns[colName].Width;
					}
					column_count++;
				}

				if (colWidth < gridList.Width && gridList.MainView.Columns.Count > 0)
				{
					string colName = gridList.MainView.Columns.Where(x => x.FieldName.EndsWith("Name")).LastOrDefault().FieldName;
					if (colName.IsNullOrEmpty() == false && list.Contains(colName))
					{
						gridList.MainView.Columns[colName].Width =
							gridList.MainView.Columns[colName].Width + (gridList.Width - colWidth - 40);
					}
					else
					{
						gridList.MainView.Columns[list[list.Count - 1]].Width =
							gridList.MainView.Columns[list[list.Count - 1]].Width + (gridList.Width - colWidth - 40);
					}
				}
			}
			catch(Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		private void SetGridColumnName(Type type)
		{
			try
			{
				List<string> mergeFields = new List<string>();

				foreach (string colName in type.GetProperties().Select(p=>p.Name).ToArray())
				{
					if (gridList.MainView.Columns.Where(x => x.FieldName == colName).Any())
					{
						if (colName.EndsWith("ID") ||
							colName.EndsWith("Code") ||
							colName.EndsWith("Type") ||
							colName.EndsWith("No") ||
							colName.EndsWith("Yn"))
						{
							gridList.SetHorzAlign(colName, DevExpress.Utils.HorzAlignment.Center);
						}
						else if (colName.EndsWith("Qty") ||
							colName.EndsWith("Amt") ||
							colName.EndsWith("Price"))
						{
							gridList.SetFormat(colName, DevExpress.Utils.FormatType.Numeric, "N0");
							gridList.SetHorzAlign(colName, DevExpress.Utils.HorzAlignment.Far);
						}

						if (colName.EndsWith("Yn"))
						{
							gridList.SetRepositoryItemCheckEdit(colName);
						}

						if (colName.EndsWith("Yn") == false)
						{
							mergeFields.Add(colName);
						}
					}
					else
					{
						gridList.AddGridColumn(new XGridColumn() { FieldName = colName, Visible = false });
					}

					if (mergeFields.Count > 0)
					{
						gridList.SetMerge(mergeFields.ToArray());
					}
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}
	}
}
