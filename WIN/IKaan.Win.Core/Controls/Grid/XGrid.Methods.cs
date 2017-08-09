using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Model.Base;
using IKaan.Win.Core.Helper;
using IKaan.Win.Core.Utils;
using IKaan.Win.Core.Variables;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.Core.Controls.Grid
{
	partial class XGrid
	{
		public event EventHandler DataSourceChanged;

		/// <summary>
		/// 그리드 뷰를 선택한 그리드뷰형태로 변환하여 MainView와 연결한다.
		/// </summary>
		private void SetGridView()
		{
			switch (GridViewType)
			{
				case GridViewType.GridView:
					Grid.MainView = _GridView;
					break;
				case GridViewType.BandedGridView:
					Grid.MainView = _BandedGridView;
					break;
				case GridViewType.AdvBandedGridView:
					Grid.MainView = _AdvBandedGridView;
					break;
				case GridViewType.CardView:
					Grid.MainView = _CardView;
					break;
				case GridViewType.LayoutView:
					Grid.MainView = _LayoutView;
					break;
				case GridViewType.TileView:
					Grid.MainView = _TileView;
					break;
				case GridViewType.WinExplorerView:
					Grid.MainView = _WinExplorerView;
					break;
				default:
					Grid.MainView = null;
					break;
			}
		}

		/// <summary>
		/// 인쇄미리보기
		/// </summary>
		public void PrintPreview()
		{
			var pageHeaderFooter = _PrintableComponentLink.PageHeaderFooter as PageHeaderFooter;
			pageHeaderFooter.Header.Content.Clear();
			pageHeaderFooter.Header.Content.AddRange(new string[] { PageHeaderLeft, PageHeaderCenter, PageHeaderRight });
			pageHeaderFooter.Header.LineAlignment = BrickAlignment.Far;

			pageHeaderFooter.Footer.Content.AddRange(new string[] { PageFooterLeft, PageFooterCenter, PageFooterRight });
			pageHeaderFooter.Footer.LineAlignment = BrickAlignment.Far;

			_PrintableComponentLink.Component = Grid;
			_PrintableComponentLink.CreateDocument(_PrintingSystem);
			_PrintableComponentLink.ShowPreview();
		}

		/// <summary>
		/// 그리드 초기화
		/// </summary>
		public void Init()
		{
			if (MainView is AdvBandedGridView)
			{
				if (GlobalVar.SkinInfo.IsGridEvenAndOdd)
				{
					(MainView as AdvBandedGridView).OptionsView.EnableAppearanceEvenRow = true;
					(MainView as AdvBandedGridView).OptionsView.EnableAppearanceOddRow = true;
				}
				(MainView as AdvBandedGridView).OptionsView.ShowGroupPanel = false;
				(MainView as AdvBandedGridView).OptionsView.ShowDetailButtons = false;
				(MainView as AdvBandedGridView).OptionsSelection.EnableAppearanceFocusedRow = true;
				(MainView as AdvBandedGridView).OptionsSelection.EnableAppearanceFocusedCell = true;
				(MainView as AdvBandedGridView).FocusRectStyle = DrawFocusRectStyle.CellFocus;
				(MainView as AdvBandedGridView).OptionsSelection.MultiSelect = true;
				(MainView as AdvBandedGridView).OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
				(MainView as AdvBandedGridView).OptionsView.ColumnAutoWidth = false;
				(MainView as AdvBandedGridView).OptionsBehavior.ReadOnly = true;
				(MainView as AdvBandedGridView).OptionsBehavior.Editable = false;
			}
			else if (MainView is BandedGridView)
			{
				if (GlobalVar.SkinInfo.IsGridEvenAndOdd)
				{
					(MainView as BandedGridView).OptionsView.EnableAppearanceEvenRow = true;
					(MainView as BandedGridView).OptionsView.EnableAppearanceOddRow = true;
				}
				(MainView as BandedGridView).OptionsView.ShowGroupPanel = false;
				(MainView as BandedGridView).OptionsView.ShowDetailButtons = false;
				(MainView as BandedGridView).OptionsSelection.EnableAppearanceFocusedRow = true;
				(MainView as BandedGridView).OptionsSelection.EnableAppearanceFocusedCell = true;
				(MainView as BandedGridView).FocusRectStyle = DrawFocusRectStyle.CellFocus;
				(MainView as BandedGridView).OptionsSelection.MultiSelect = true;
				(MainView as BandedGridView).OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
				(MainView as BandedGridView).OptionsView.ColumnAutoWidth = false;
				(MainView as BandedGridView).OptionsBehavior.ReadOnly = true;
				(MainView as BandedGridView).OptionsBehavior.Editable = false;
			}
			else if (MainView is GridView)
			{
				if (GlobalVar.SkinInfo.IsGridEvenAndOdd)
				{
					(MainView as GridView).OptionsView.EnableAppearanceEvenRow = true;
					(MainView as GridView).OptionsView.EnableAppearanceOddRow = true;
				}
				(MainView as GridView).OptionsView.ShowGroupPanel = false;
				(MainView as GridView).OptionsView.ShowDetailButtons = false;
				(MainView as GridView).OptionsSelection.EnableAppearanceFocusedRow = true;
				(MainView as GridView).OptionsSelection.EnableAppearanceFocusedCell = true;
				(MainView as GridView).FocusRectStyle = DrawFocusRectStyle.CellFocus;
				(MainView as GridView).OptionsSelection.MultiSelect = true;
				(MainView as GridView).OptionsSelection.MultiSelectMode = GridMultiSelectMode.RowSelect;
				(MainView as GridView).OptionsView.ColumnAutoWidth = false;
				(MainView as GridView).OptionsBehavior.ReadOnly = true;
				(MainView as GridView).OptionsBehavior.Editable = false;
			}

			if (MainView is GridView || MainView is BandedGridView || MainView is AdvBandedGridView)
			{
				if (AppearanceObject.DefaultFont.Size > 10f)
				{
					(MainView as GridView).OptionsView.RowAutoHeight = true;
				}
				else if (AppearanceObject.DefaultFont.Size > 9f)
				{
					(MainView as GridView).OptionsView.RowAutoHeight = false;
					(MainView as GridView).RowHeight = 18;
				}
				else
				{
					(MainView as GridView).OptionsView.RowAutoHeight = false;
					(MainView as GridView).RowHeight = 16;
				}
			}

			if (GlobalVar.SkinInfo.GridSkin.IsNullOrEmpty() == false)
			{
				LookAndFeel.UseDefaultLookAndFeel = false;
				LookAndFeel.SkinName = GlobalVar.SkinInfo.GridSkin.ToString();
			}
			else
			{
				LookAndFeel.UseDefaultLookAndFeel = true;
			}
		}

		/// <summary>
		/// 그리드 컬럼을 추가하여 초기화
		/// </summary>
		/// <param name="columns">GridColumn 배열</param>
		public void Init(params GridColumn[] columns)
		{
			Init();

			if (columns != null && columns.Length > 0)
			{
				AddGridColumns(columns);
				BestFitColumns();
			}
		}

		/// <summary>
		/// 그리드 컬럼을 추가하여 초기화
		/// </summary>
		/// <param name="columns">XGridColumn 배열</param>
		public void Init(params XGridColumn[] columns)
		{
			Init(false, columns);
		}

		/// <summary>
		/// 편집가능여부, 그리드 컬럼 포함 그리드 초기화
		/// </summary>
		/// <param name="isEditable">편집여부</param>
		/// <param name="columns">XGridColumn 배열</param>
		public void Init(bool isEditable, params XGridColumn[] columns)
		{
			Init();

			MainView.OptionsBehavior.Editable = isEditable;

			if (columns != null && columns.Length > 0)
			{
				AddGridColumns(columns);
				BestFitColumns();
			}
		}

		/// <summary>
		/// 전체 그리드 컬럼의 Width를 자동으로 맞춘다.
		/// </summary>
		public void BestFitColumns()
		{
			if (GridViewType == GridViewType.GridView ||
				GridViewType == GridViewType.BandedGridView ||
				GridViewType == GridViewType.AdvBandedGridView)
			{
				((GridView)Grid.MainView).BestFitColumns();
			}
		}

		/// <summary>
		/// GridColumn 배열로 그리드의 컬럼을 추가한다.
		/// </summary>
		/// <param name="columns">GridColumn 배열</param>
		public void AddGridColumns(params GridColumn[] columns)
		{
			MainView.BeginUpdate();

			MainView.Columns.Clear();

			foreach (GridColumn col in columns)
			{
				if (string.IsNullOrEmpty(col.Caption))
				{
					col.Caption = DomainUtils.GetFieldName(col.FieldName);
				}
				col.OptionsColumn.AllowMerge = DefaultBoolean.False;
				col.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
				col.CustomizationCaption = col.Caption;
				col.AppearanceHeader.Options.UseTextOptions = true;
				col.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			}

			MainView.Columns.AddRange(columns);

			MainView.EndUpdate();
		}

		/// <summary>
		/// XGridColumn 배열로 그리드의 컬럼을 추가한다.
		/// </summary>
		/// <param name="columns">XGridColumn 배열</param>
		public void AddGridColumns(params XGridColumn[] columns)
		{
			MainView.BeginUpdate();
			MainView.Columns.Clear();
			foreach (XGridColumn column in columns)
			{
				if (MainView is BandedGridView || MainView is AdvBandedGridView)
				{
					AddBandColumn(column);
				}
				else
				{
					AddGridColumn(column);
				}
			}
			MainView.EndUpdate();
		}

		/// <summary>
		/// 그리드의 컬럼을 추가한다.
		/// </summary>
		/// <param name="column">XGridColumn</param>
		public void AddGridColumn(XGridColumn column)
		{
			//Caption
			if (string.IsNullOrEmpty(column.Caption))
			{
				if (!string.IsNullOrEmpty(column.CaptionCode))
				{
					column.Caption = DomainUtils.GetFieldName(column.CaptionCode);
				}
				else
				{
					column.Caption = DomainUtils.GetFieldName(column.FieldName);
				}
			}

			var gridColumn = new GridColumn()
			{
				Caption = column.Caption,
				FieldName = column.FieldName,
				UnboundType = column.ColumnType
			};

			gridColumn.OptionsColumn.AllowMerge = DefaultBoolean.False;
			gridColumn.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
			gridColumn.CustomizationCaption = gridColumn.Caption;
			gridColumn.AppearanceHeader.Options.UseTextOptions = true;
			gridColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			if (column.IsMandatory)
			{
				gridColumn.AppearanceHeader.Options.UseForeColor = true;
				gridColumn.AppearanceHeader.ForeColor = Color.Red;
				gridColumn.AppearanceHeader.Font =
					new Font(gridColumn.AppearanceHeader.Font, FontStyle.Bold);
				gridColumn.Tag = true;
			}
			else
			{
				gridColumn.AppearanceHeader.Options.UseForeColor = false;
				gridColumn.Tag = null;
			}
			gridColumn.AppearanceCell.Options.UseTextOptions = true;
			switch (column.FieldName)
			{
				case "Checked":
				case "RowNo":
				case "CreateDate":
				case "CreateBy":
				case "CreateByName":
				case "UpdateDate":
				case "UpdateBy":
				case "UpdateByName":
					gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
					break;
				default:
					if (column.FieldName.EndsWith("Date"))
						gridColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
					else
						gridColumn.AppearanceCell.TextOptions.HAlignment = column.HorzAlignment;
					break;
			}

			switch (column.FieldName)
			{
				case "CreateDate":
				case "UpdateDate":
					gridColumn.DisplayFormat.FormatType =
						gridColumn.GroupFormat.FormatType = FormatType.DateTime;
					break;
				default:
					gridColumn.DisplayFormat.FormatType =
						gridColumn.GroupFormat.FormatType = column.FormatType;

					if (!string.IsNullOrEmpty(column.FormatString))
					{
						gridColumn.DisplayFormat.FormatString = column.FormatString;
						gridColumn.GroupFormat.FormatString = column.FormatString;
					}
					break;
			}

			if (column.RepositoryItem != null)
			{
				gridColumn.ColumnEdit = column.RepositoryItem;
			}

			if ((column.IsSummary) &&
				(
					MainView.GetType() == typeof(GridView) || 
					MainView.GetType() == typeof(BandedGridView) || 
					MainView.GetType() == typeof(AdvBandedGridView)
				))
			{
				gridColumn.SummaryItem.SummaryType = column.SummaryItemType;
				gridColumn.SummaryItem.FieldName = column.FieldName;

				if (!string.IsNullOrEmpty(column.FormatString))
				{
					gridColumn.SummaryItem.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
				}

				if (column.IsSummaryGroup)
				{
					var item = new GridGroupSummaryItem()
					{
						FieldName = column.FieldName,
						ShowInGroupColumnFooter = gridColumn,
						ShowInGroupColumnFooterName = column.FieldName,
						SummaryType = column.SummaryItemType
					};

					if (!string.IsNullOrEmpty(column.FormatString))
					{
						item.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
					}
					GroupSummaryAdd(item);

					gridColumn.OptionsColumn.AllowGroup = DefaultBoolean.True;
				}
			}

			if (column.ReadOnly || MainView.OptionsBehavior.Editable == false)
			{
				gridColumn.OptionsColumn.ReadOnly = true;
				gridColumn.OptionsColumn.AllowEdit = false;
				gridColumn.OptionsColumn.AllowFocus = false;
			}
			else
			{
				gridColumn.OptionsColumn.ReadOnly = false;
				gridColumn.OptionsColumn.AllowEdit = true;
				gridColumn.OptionsColumn.AllowFocus = true;
			}

			if (column.Width > 0)
			{
				gridColumn.Width = column.Width;
				gridColumn.MinWidth = column.Width;
			}
			else
			{
				switch (column.FieldName)
				{
					case "Checked":
						gridColumn.Width = 40;
						gridColumn.MinWidth = 40;
						break;
					case "RowNo":
						gridColumn.Width = 50;
						gridColumn.MinWidth = 50;
						break;
					case "CreateDate":
					case "UpdateDate":
						gridColumn.Width = 160;
						gridColumn.MinWidth = 160;
						break;
					case "CreateBy":
					case "UpdateBy":
						gridColumn.Width = 80;
						gridColumn.MinWidth = 80;
						break;
					case "CreateByName":
					case "UpdateByName":
						gridColumn.Width = 80;
						gridColumn.MinWidth = 80;
						break;
					default:
						if (column.FieldName.EndsWith("Date"))
						{
							gridColumn.Width = 100;
							gridColumn.MinWidth = 100;
						}
						else
						{
							gridColumn.BestFit();
						}
						break;
				}
			}
			gridColumn.Visible = column.Visible;

			if (column.Visible)
			{
				gridColumn.VisibleIndex = MainView.Columns.Count;
			}

			MainView.Columns.Add(gridColumn);
		}

		/// <summary>
		/// 그리드의 밴드에 컬럼을 추가한다.
		/// </summary>
		/// <param name="column">XGridColumn</param>
		public void AddBandColumn(XGridColumn column)
		{
			//Caption
			if (string.IsNullOrEmpty(column.Caption))
			{
				if (!string.IsNullOrEmpty(column.CaptionCode))
				{
					column.Caption = DomainUtils.GetFieldName(column.CaptionCode);
				}
				else
				{
					column.Caption = DomainUtils.GetFieldName(column.FieldName);
				}
			}

			var bandedColumn = new BandedGridColumn()
			{
				Caption = column.Caption,
				FieldName = column.FieldName,
				UnboundType = column.ColumnType
			};

			bandedColumn.OptionsColumn.AllowMerge = DefaultBoolean.False;
			bandedColumn.OptionsFilter.FilterPopupMode = FilterPopupMode.CheckedList;
			bandedColumn.CustomizationCaption = bandedColumn.Caption;
			bandedColumn.AppearanceHeader.Options.UseTextOptions = true;
			bandedColumn.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			bandedColumn.AppearanceCell.Options.UseTextOptions = true;
			switch (column.FieldName)
			{
				case "Checked":
				case "RowNo":
				case "CreateDate":
				case "CreateBy":
				case "CreateByName":
				case "UpdateDate":
				case "UpdateBy":
				case "UpdateByName":
					bandedColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
					break;
				default:
					if (column.FieldName.EndsWith("Date"))
						bandedColumn.AppearanceCell.TextOptions.HAlignment = HorzAlignment.Center;
					else
						bandedColumn.AppearanceCell.TextOptions.HAlignment = column.HorzAlignment;
					break;
			}


			bandedColumn.DisplayFormat.FormatType =
				bandedColumn.GroupFormat.FormatType = column.FormatType;

			if (!string.IsNullOrEmpty(column.FormatString))
			{
				bandedColumn.DisplayFormat.FormatString = column.FormatString;
				bandedColumn.GroupFormat.FormatString = column.FormatString;
			}

			if (column.RepositoryItem != null)
			{
				bandedColumn.ColumnEdit = column.RepositoryItem;
			}

			if ((column.IsSummary) &&
				(
					MainView.GetType() == typeof(GridView) || 
					MainView.GetType() == typeof(BandedGridView) || 
					MainView.GetType() == typeof(AdvBandedGridView)
				))
			{
				bandedColumn.SummaryItem.SummaryType = column.SummaryItemType;
				bandedColumn.SummaryItem.FieldName = column.FieldName;

				if (!string.IsNullOrEmpty(column.FormatString))
				{
					bandedColumn.SummaryItem.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
				}

				if (column.IsSummaryGroup)
				{
					var item = new GridGroupSummaryItem()
					{
						FieldName = column.FieldName,
						ShowInGroupColumnFooter = bandedColumn,
						ShowInGroupColumnFooterName = column.FieldName,
						SummaryType = column.SummaryItemType
					};

					if (!string.IsNullOrEmpty(column.FormatString))
					{
						item.DisplayFormat = string.Format("{{0:{0}}}", column.FormatString);
					}
					GroupSummaryAdd(item);

					bandedColumn.OptionsColumn.AllowGroup = DefaultBoolean.True;
				}
			}

			if (column.ReadOnly || MainView.OptionsBehavior.Editable == false)
			{
				bandedColumn.OptionsColumn.ReadOnly = true;
				bandedColumn.OptionsColumn.AllowEdit = false;
				bandedColumn.OptionsColumn.AllowFocus = false;
			}
			else
			{
				bandedColumn.OptionsColumn.ReadOnly = false;
				bandedColumn.OptionsColumn.AllowEdit = true;
				bandedColumn.OptionsColumn.AllowFocus = true;
			}

			if (column.Width > 0)
			{
				bandedColumn.Width = column.Width;
				bandedColumn.MinWidth = column.Width;
			}
			else
			{
				switch (column.FieldName)
				{
					case "Checked":
						bandedColumn.Width = 40;
						bandedColumn.MinWidth = 40;
						break;
					case "RowNo":
						bandedColumn.Width = 50;
						bandedColumn.MinWidth = 50;
						break;
					case "CreateDate":
					case "UpdateDate":
						bandedColumn.Width = 150;
						bandedColumn.MinWidth = 150;
						break;
					case "CreateBy":
					case "UpdateBy":
						bandedColumn.Width = 100;
						bandedColumn.MinWidth = 100;
						break;
					case "CreateByName":
					case "UpdateByName":
						bandedColumn.Width = 100;
						bandedColumn.MinWidth = 100;
						break;
					default:
						if (column.FieldName.EndsWith("Date"))
						{
							bandedColumn.Width = 100;
							bandedColumn.MinWidth = 100;
						}
						else
						{
							bandedColumn.BestFit();
						}
						break;
				}
			}

			bandedColumn.Visible = column.Visible;

			if (column.Visible)
			{
				bandedColumn.VisibleIndex = MainView.Columns.Count;
			}
			MainView.Columns.Add(bandedColumn);
		}

		/// <summary>
		/// 그리드의 밴드를 추가한다.
		/// </summary>
		/// <param name="bands">GridBand의 배열</param>
		public void BandsAdd(params GridBand[] bands)
		{
			if (MainView.GetType() != typeof(BandedGridView) && MainView.GetType() != typeof(AdvBandedGridView))
			{
				return;
			}
			MainView.BeginUpdate();
			((BandedGridView)MainView).Bands.AddRange(bands);
			MainView.EndUpdate();
		}

		/// <summary>
		/// 그리드 밴드와 컬럼 설정
		/// </summary>
		/// <param name="band">GridBand</param>
		/// <param name="columns">컬럼명 배열</param>
		public void AddBandAndColumns(GridBand band, params string[] columns)
		{
			if (MainView.GetType() != typeof(BandedGridView) && MainView.GetType() != typeof(AdvBandedGridView))
			{
				return;
			}
			var view = MainView as BandedGridView;
			view.BeginUpdate();

			//if (band.Caption.IsNullOrEmpty())
			//{
			//	band.Caption = DomainUtils.GetFieldName(band.Name);
			//}
			band.AppearanceHeader.Options.UseTextOptions = true;
			band.AppearanceHeader.TextOptions.HAlignment = HorzAlignment.Center;
			band.AppearanceHeader.TextOptions.VAlignment = VertAlignment.Center;

			if (view.Bands.Where(x => x.Name == band.Name).Any() == false)
			{
				view.Bands.Add(band);
			}
			if (columns != null && columns.Length > 0)
			{
				var width = 0;
				view.Columns.Cast<BandedGridColumn>().Where(x => columns.Contains(x.FieldName)).ToList().ForEach(x =>
				{
					x.OwnerBand = band;
					if (x.Visible)
					{
						width += x.Width;
					}
					x.CustomizationCaption = (band.Caption.Trim().IsNullOrEmpty() == false) ? string.Format("{0}-{1}", band.Caption, x.Caption) : x.Caption;
				});
				band.Width = width;
			}
			view.EndUpdate();
		}

		/// <summary>
		/// 새로운 라인을 생성한다.
		/// </summary>
		/// <returns>추가한 Row번호</returns>
		public int AddNewRow()
		{
			if (MainView.DataSource  != null)
			{
				MainView.PostEditor();
				MainView.UpdateCurrentRow();
				MainView.AddNewRow();
			}
			MainGrid.RefreshDataSource();
			return MainView.RowCount - 1;
		}
		
		/// <summary>
		/// 그리드 컬럼의 편집여부 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="editable">편집여부</param>
		public void SetColumnEditable(string fieldName, bool editable)
		{
			MainView.Columns[fieldName].OptionsColumn.ReadOnly = !editable;
			MainView.Columns[fieldName].OptionsColumn.AllowEdit = editable;
			MainView.Columns[fieldName].OptionsColumn.AllowFocus = editable;

			if (editable)
			{
				MainView.Columns[fieldName].AppearanceHeader.Font = 
					new Font(MainView.Columns[fieldName].AppearanceHeader.Font, FontStyle.Bold);
				MainView.Columns[fieldName].AppearanceCell.BackColor = SkinUtils.EditBackColor;
				MainView.Columns[fieldName].AppearanceCell.ForeColor = SkinUtils.EditForeColor;
			}

			SetEditStyle();
		}

		/// <summary>
		/// 그리드 편집 여부 설정
		/// </summary>
		/// <param name="editable">편집여부</param>
		public void SetEditable(bool editable)
		{
			Editable = editable;
			ReadOnly = !editable;
			SetEditStyle();
		}

		/// <summary>
		/// 편집 가능한 컬럼 배열 설정
		/// </summary>
		/// <param name="columns">컬럼명 배열</param>
		public void SetEditable(params string[] columns)
		{
			if (columns != null && columns.Length > 0)
			{
				SetEditable(true);
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col) && IsExitsColumn(col))
					{
						SetColumnEditable(col, true);
					}
				}
			}
			SetEditStyle();
		}

		/// <summary>
		/// 편집 가능한 컬럼 배열 설정
		/// </summary>
		/// <param name="isEdit">편집여부</param>
		/// <param name="columns">컬럼명 배열</param>
		public void SetEditable(bool isEdit, params string[] columns)
		{
			if (columns != null && columns.Length > 0)
			{
				SetEditable(true);
				foreach (string col in columns)
				{
					if (!string.IsNullOrEmpty(col) && IsExitsColumn(col))
					{
						SetColumnEditable(col, isEdit);
					}
				}
			}
			SetEditStyle();
		}

		/// <summary>
		/// 컬럼 RepositoryItem 설정
		/// </summary>
		/// <param name="fieldName">필드명</param>
		/// <param name="item">RepositoryItem</param>
		public void SetColumnEdit(string fieldName, RepositoryItem item)
		{
			MainView.Columns[fieldName].ColumnEdit = item;
			MainView.Columns[fieldName].ColumnEdit.EditValueChanged += RepositoryItemEditValueChanged;
		}

		/// <summary>
		/// RepositoryItem 값 변경 이벤트
		/// </summary>
		/// <param name="sender">object</param>
		/// <param name="e">EventArgs</param>
		private void RepositoryItemEditValueChanged(object sender, EventArgs e)
		{
			MainView.PostEditor();
		}

		/// <summary>
		/// 그리드 편집가능 셀 스타일 설정
		/// </summary>
		private void SetEditStyle()
		{
			//if (MainView.GetType() == typeof(GridView))
			//{
			//	var view = MainView as GridView;
			//	var bEditable = false;

			//	bEditable = view.Columns.Cast<GridColumn>().Where(x => x.OptionsColumn.AllowEdit == true).Any();

			//	view.Appearance.FocusedCell.BorderColor = Color.Red;
			//	view.Appearance.FocusedCell.BackColor = SkinUtils.EditBackColor;
			//	view.Appearance.FocusedCell.ForeColor = SkinUtils.EditForeColor;
			//	view.Appearance.FocusedCell.Options.UseBorderColor = bEditable;
			//	view.Appearance.FocusedCell.Options.UseBackColor = bEditable;
			//}
		}

		/// <summary>
		/// 그리드에 컬럼 존재 여부
		/// </summary>
		/// <param name="fieldName"></param>
		/// <returns></returns>
		public bool IsExitsColumn(string fieldName)
		{
			return MainView.Columns.Cast<GridColumn>().Any(x => x.FieldName == fieldName);
		}

		/// <summary>
		/// 그리드 데이터 초기화
		/// </summary>
		public void Clear<T>()
		{
			DataSource = new List<T>();
			MainView.RefreshData();
		}

		/// <summary>
		/// 그리드 컬럼 초기화
		/// </summary>
		public void ColumnClear()
		{
			DataSource = null;
			MainView.Columns.Clear();
		}

		/// <summary>
		/// 그리드 Readonly 설정
		/// </summary>
		/// <param name="bEnable"></param>
		public void SetEnable(bool bEnable = false)
		{
			MainView.OptionsBehavior.ReadOnly = !bEnable;
		}

		/// <summary>
		/// 그리드 뷰의 값 적용
		/// </summary>
		public void PostEditor()
		{
			MainView.PostEditor();
		}

		/// <summary>
		/// 현재 Row의 값 Update
		/// </summary>
		public void UpdateCurrentRow()
		{
			MainView.UpdateCurrentRow();
		}

		/// <summary>
		/// 엑셀변환
		/// </summary>
		public void ExportToXlsx()
		{
			try
			{
				if (MainView.RowCount == 0)
				{
					MsgBox.Show("엑셀 내보내기할 데이터가 없습니다.");
					return;
				}

				var fileName = string.Format("{0}_{1}", ParentForm.Text, string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));

				fileName = fileName
					.Replace(@"\", string.Empty)
					.Replace(@"/", string.Empty)
					.Replace(@":", string.Empty)
					.Replace(@"*", string.Empty)
					.Replace(@"?", string.Empty)
					.Replace("\"", string.Empty)
					.Replace(@"<", string.Empty)
					.Replace(@">", string.Empty)
					.Replace(@"|", string.Empty)
				;

				var path = FileUtils.GetExportFilePath();
				if (string.IsNullOrEmpty(path))
				{
					path = ConstsVar.APP_PATH;
				}
				using (var savefile = new SaveFileDialog())
				{
					savefile.InitialDirectory = path;
					savefile.Title = "Save Grid Excel File";
					savefile.DefaultExt = "xlsx";
					savefile.Filter = "xlsx files (*.xlsx)|*.xlsx|xls files (*.xls)|*.xls|All files (*.*)|*.*";
					savefile.FileName = fileName;
					if (savefile.ShowDialog() != DialogResult.OK)
					{
						return;
					}
					fileName = savefile.FileName;
				}

				path = Path.GetDirectoryName(fileName);
				FileUtils.SetExcelPath(path);

				MainView.ExportToXlsx(fileName);
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 기본 레이아웃 파일명 가져오기
		/// </summary>
		/// <returns></returns>
		public string GetDefaultLayoutFileName()
		{
			return string.Format("{0}\\Layout_{1}_{2}.xml", GetDefaultLayoutPathName(), ParentForm.Name, Name);
		}

		/// <summary>
		/// 기본 레이아웃 경로명 가져오기
		/// </summary>
		/// <returns></returns>
		public string GetDefaultLayoutPathName()
		{
			return string.Format("{0}\\GridLayout", ConstsVar.APP_PATH);
		}

		/// <summary>
		/// 셀의 값 클립보드로 복사
		/// </summary>
		/// <param name="hitInfo"></param>
		public void CellToClipboard(GridHitInfo hitInfo)
		{
			try
			{
				var objVal = hitInfo.Column.View.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column);

				if (objVal.GetType().Equals(Type.GetType("System.Byte[]")))
				{
					var bArrayImg = (byte[])objVal;

					var img = Image.FromStream(new MemoryStream(bArrayImg));
					Clipboard.SetImage(img);
				}
				else
				{
					Clipboard.SetText(hitInfo.Column.View.GetRowCellValue(hitInfo.RowHandle, hitInfo.Column).ToString());
				}
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 레지스트리에서 레이아웃 설정 가져오기
		/// </summary>
		public void RestoreLayoutToRegistry()
		{
			MainView.RestoreLayoutFromRegistry(GetDefaultLayoutPathName());
		}
		
		public void CheckSelect(bool isCheck, string columnName = null)
		{
			try
			{
				if (string.IsNullOrEmpty(columnName))
					columnName = "Checked";

				if (MainView.DataSource == null)
					return;

				if (MainView.DataRowCount == 0)
					return;

				if (MainView.DataRowCount > 0)
				{
					for (int i = 0; i < MainView.DataRowCount; i++)
					{
						int rowHandle = MainView.GetVisibleRowHandle(i);
						if (MainView.GetRow(rowHandle) == null)
						{
							MainView.SetRowCellValue(i, columnName, "N");							
						}
						else
						{
							MainView.SetRowCellValue(i, columnName, (isCheck) ? "Y" : "N");
						}
					}
				}
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// 데이터 바인딩
		/// </summary>
		/// <param name="serverId">서비스ID</param>
		/// <param name="processId">프로세스ID</param>
		/// <param name="sqlId">SQL ID</param>
		/// <param name="param">파라미터</param>
		/// <param name="bestFit">자동맞춤여부</param>
		public void BindList<T>(string serviceId = null, string processId = null, string sqlId = null, DataMap param = null, bool bestFit = false)
		{
			try
			{
				int rowIndex = this.MainView.FocusedRowHandle;
				this.DataSource = WasHandler.GetList<T>(serviceId, processId, sqlId, param);
				if (this.DataSource == null)
				{
					this.DataSource = default(List<T>);
				}
				else
				{
					this.MainView.FocusedRowHandle = rowIndex;
					this.MainView.SelectRow(rowIndex);
				}

				if (bestFit)
				{
					BestFitColumns();
				}
			}
			catch (Exception ex)
			{
				MsgBox.Show(ex);
			}
		}

		public int GetRowHeight()
		{
			if (_GridViewType == GridViewType.GridView || 
				_GridViewType == GridViewType.BandedGridView || 
				_GridViewType == GridViewType.AdvBandedGridView)
			{
				GridViewInfo viewInfo = (MainView as GridView).GetViewInfo() as GridViewInfo;
				const int GridControlMaxHeight = 30000;
				int height = viewInfo.CalcRealViewHeight(new Rectangle(0, 0, (MainView as GridView).GridControl.Width, GridControlMaxHeight));
				if (height >= GridControlMaxHeight)
					height = (MainView as GridView).GridControl.Parent.Height;
				return height;
			}
			else
			{
				return -1;
			}
		}
	}
}
