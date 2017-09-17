﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraLayout;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Win.Core.Controls.Common;

namespace IKaan.Win.Core.Utils
{
	public static class LayoutUtils
	{
		public static void SetFieldName(this LayoutControl lc)
		{
			if (lc == null)
			{
				return;
			}
			lc.Items.OfType<LayoutControlItem>().ToList().ForEach(delegate (LayoutControlItem item)
			{
				item.SetFieldName();
			});

			lc.Items.OfType<LayoutControlGroup>().ToList().ForEach(delegate (LayoutControlGroup group)
			{
				group.SetFieldName();
			});
		}
		public static void SetFieldName(this LayoutControlGroup group)
		{
			if (group == null)
			{
				return;
			}
			group.Items.OfType<LayoutControlItem>().ToList().ForEach(delegate (LayoutControlItem item)
			{
				item.SetFieldName();
			});

			group.Items.OfType<LayoutControlGroup>().ToList().ForEach(delegate (LayoutControlGroup groupItem)
			{
				groupItem.SetFieldName();
			});
		}
		public static void SetFieldName(this LayoutControlItem item, string fieldName = null, HorzAlignment hAlignment = HorzAlignment.Far)
		{
			if (string.IsNullOrEmpty(fieldName))
			{
				fieldName = item.Name.Replace("lcItem", string.Empty);
			}
			var caption = DomainUtils.GetFieldName(fieldName);
			if (caption.IsNullOrEmpty())
			{
				caption = item.Name;
			}
			item.SetFieldCaption(caption, hAlignment);
		}
		public static void SetFieldCaption(this LayoutControlItem item, string caption = null, HorzAlignment hAlignment = HorzAlignment.Far)
		{
			if (caption.IsNullOrEmpty() == false)
			{
				if (item.Tag != null && item.Tag.GetType() == typeof(bool) && (bool)item.Tag == true)
				{
					item.Text = string.Format("*{0}:", caption);
					item.AppearanceItemCaption.ForeColor = (SkinUtils.IsDarkSkin) ? Color.Yellow : Color.Red;
					item.AppearanceItemCaption.Options.UseForeColor = true;
				}
				else
				{
					item.Text = caption + ":";
					item.AppearanceItemCaption.Options.UseForeColor = false;
				}

				item.AppearanceItemCaption.TextOptions.HAlignment = hAlignment;
				item.AppearanceItemCaption.TextOptions.VAlignment = VertAlignment.Center;
			}
			else
			{
				item.Text = " ";
				item.AppearanceItemCaption.Options.UseForeColor = false;
			}
		}

		public static string GetFieldName(this LayoutControlItem item)
		{
			var columnName = item.Name.Replace("lcItem", string.Empty);
			var m = Regex.Match(columnName, "^[a-z]+([A-Z].+)$");

			if (m.Groups.Count > 1)
			{
				columnName = m.Groups[1].ToString();
			}
			else
			{
				columnName = string.Empty;
			}
			return columnName;
		}

		public static string GetFieldNameByControl(this LayoutControlItem item)
		{
			var columnName = item.Control.Name;
			var m = Regex.Match(columnName, "^[a-z]+([A-Z].+)$");

			if (m.Groups.Count > 1)
			{
				columnName = m.Groups[1].ToString();
			}
			else
			{
				columnName = string.Empty;
			}
			return columnName;
		}
		public static string GetFieldNameByControlNoPattern(this LayoutControlItem item)
		{
			var columnName = item.Control.Name;
			var m = Regex.Match(columnName, "^[a-z]+([A-Z].+)$");

			if (m.Groups.Count > 1)
			{
				columnName = m.Groups[1].ToString();
			}
			else
			{
				columnName = string.Empty;
			}
			return columnName;
		}

		public static object GetControlValue(this LayoutControlItem item)
		{
			if (item.Control == null)
			{
				return null;
			}
			object value = null;

			if (item.Control.GetType() == typeof(TextEdit))
			{
				value = (item.Control as TextEdit).EditValue;
			}
			else if (item.Control.GetType() == typeof(XLookup))
			{
				value = (item.Control as XLookup).EditValue;
			}
			else if (item.Control.GetType() == typeof(SpinEdit))
			{
				value = (item.Control as SpinEdit).EditValue;
			}
			else if (item.Control.GetType() == typeof(MemoEdit))
			{
				value = (item.Control as MemoEdit).EditValue;
			}
			else if (item.Control.GetType() == typeof(DateEdit))
			{
				value = (item.Control as DateEdit).GetDateChar8();
			}
			else if (item.Control.GetType() == typeof(CheckEdit))
			{
				value = (item.Control as CheckEdit).EditValue;
			}
			else if (item.Control.GetType() == typeof(ButtonEdit))
			{
				value = (item.Control as ButtonEdit).EditValue;
			}
			else if (item.Control.GetType() == typeof(XSearch))
			{
				value = (item.Control as XSearch).EditValue;
			}

			if (value.ToStringNullToEmpty() == string.Empty)
			{
				value = null;
			}
			return value;
		}

		public static IDictionary<string, object> GetControlValueWithFieldName(this LayoutControlItem item)
		{
			if (item.Control == null)
			{
				return null;
			}
			var fieldName = item.GetFieldNameByControl().ToUpperUnderscoreByPattern();

			IDictionary<string, object> dic = new Dictionary<string, object>();

			if (item.Control.GetType() == typeof(TextEdit))
			{
				dic.Add(fieldName, ((TextEdit)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(XLookup))
			{
				dic.Add(fieldName, ((XLookup)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(SpinEdit))
			{
				dic.Add(fieldName, ((SpinEdit)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(MemoEdit))
			{
				dic.Add(fieldName, ((MemoEdit)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(DateEdit))
			{
				dic.Add(fieldName, ((DateEdit)item.Control).GetDateChar8());
			}
			else if (item.Control.GetType() == typeof(CheckEdit))
			{
				dic.Add(fieldName, ((CheckEdit)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(ButtonEdit))
			{
				dic.Add(fieldName, ((ButtonEdit)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(XSearch))
			{
				dic.Add(fieldName, ((XSearch)item.Control).EditValue);
			}
			else if (item.Control.GetType() == typeof(XPeriod))
			{
				dic.Add("ST_" + fieldName, ((XPeriod)item.Control).DateFrEdit.GetDateChar8());
				dic.Add("ED_" + fieldName, ((XPeriod)item.Control).DateToEdit.GetDateChar8());
			}
			return dic;
		}

		public static void SetControlValue(this LayoutControlItem item, object value, string text = "")
		{
			try
			{
				if (item.Control == null)
				{
					return;
				}

				if (item.Control.GetType() == typeof(TextEdit))
				{
					(item.Control as TextEdit).EditValue = value;
				}
				else if (item.Control.GetType() == typeof(XLookup))
				{
					(item.Control as XLookup).EditValue = value;
				}
				else if (item.Control.GetType() == typeof(SpinEdit))
				{
					(item.Control as SpinEdit).EditValue = value;
				}
				else if (item.Control.GetType() == typeof(MemoEdit))
				{
					(item.Control as MemoEdit).EditValue = value;
				}
				else if (item.Control.GetType() == typeof(DateEdit))
				{
					if (value == null || value == DBNull.Value)
					{
						(item.Control as DateEdit).EditValue = null;
					}
					else
					{
						if (value.GetType() == typeof(DateTime))
						{
							(item.Control as DateEdit).EditValue = value;
						}
						else
						{
							(item.Control as DateEdit).SetDateChar8(value.ToString());
						}
					}
				}
				else if (item.Control.GetType() == typeof(CheckEdit))
				{
					if (value.ToStringNullToEmpty() == "Y")
					{
						(item.Control as CheckEdit).Checked = true;
						(item.Control as CheckEdit).EditValue = "Y";
					}
					else
					{
						(item.Control as CheckEdit).Checked = false;
						(item.Control as CheckEdit).EditValue = "Y";
					}
				}
				else if (item.Control.GetType() == typeof(ButtonEdit))
				{
					(item.Control as ButtonEdit).EditValue = value;
				}
				else if (item.Control.GetType() == typeof(XSearch))
				{
					if (value == null | value == DBNull.Value)
					{
						(item.Control as XSearch).EditValue = null;
						(item.Control as XSearch).EditText = null;
					}
					else
					{
						(item.Control as XSearch).EditValue = value;
						(item.Control as XSearch).EditText = text;
					}
				}
			}
			catch
			{
				throw;
			}
		}

		/// <summary>
		/// LayoutControlGroup 배열로 각각의 Control EditValue 값을 DataTable 로 변환하여 줍니다.
		/// </summary>
		/// <param name="lcg">LayoutControlGroup</param>
		/// <returns>DataTable</returns>
		public static DataTable GroupToDataTable(this LayoutControl lc, params LayoutControlGroup[] groups)
		{
			var dt = new DataTable();
			var newRow = dt.NewRow();
			foreach (LayoutControlGroup group in groups)
			{
				foreach (LayoutControlItem item in group.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null))
				{
					var values = item.GetControlValueWithFieldName();
					if (values != null && values.Count > 0)
					{
						foreach (var dic in values)
						{
							dt.Columns.Add(dic.Key);
							newRow[dic.Key] = dic.Value;
						}
					}
				}
			}
			dt.Rows.Add(newRow);
			return dt;
		}

		public static DataMap GroupToDataMap(this LayoutControl lc, params LayoutControlGroup[] groups)
		{
			var map = new DataMap();
			foreach (LayoutControlGroup group in groups)
			{
				foreach (LayoutControlItem item in group.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null))
				{
					var values = item.GetControlValueWithFieldName();
					if (values != null && values.Count > 0)
					{
						foreach (var dic in values)
						{
							map.SetValue(dic.Key, dic.Value);
						}
					}
				}
			}
			return map;
		}

		/// <summary>
		/// LayoutControlGroup 각각의 Control EditValue 값을 DataTable 로 변환하여 줍니다.
		/// </summary>
		/// <param name="lcg">LayoutControlGroup</param>
		/// <returns>DataTable</returns>
		public static DataTable ItemToDataTable(this LayoutControl lc)
		{
			var dt = new DataTable();
			var newRow = dt.NewRow();
			foreach (LayoutControlItem item in lc.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null))
			{
				var values = item.GetControlValueWithFieldName();
				if (values != null && values.Count > 0)
				{
					foreach (var dic in values)
					{
						dt.Columns.Add(dic.Key);
						newRow[dic.Key] = dic.Value;
					}
				}
			}
			dt.Rows.Add(newRow);
			return dt;
		}

		public static DataTable ItemToDataTable(this LayoutControlGroup lcg)
		{
			var dt = new DataTable();
			var newRow = dt.NewRow();
			foreach (LayoutControlItem item in lcg.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null))
			{
				var values = item.GetControlValueWithFieldName();
				if (values != null && values.Count > 0)
				{
					foreach (var dic in values)
					{
						dt.Columns.Add(dic.Key);
						newRow[dic.Key] = dic.Value;
					}
				}
			}
			dt.Rows.Add(newRow);
			return dt;
		}

		public static DataMap ItemToDataMap(this LayoutControl lc)
		{
			var map = new DataMap();

			foreach (LayoutControlItem item in lc.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null))
			{
				var values = item.GetControlValueWithFieldName();
				if (values != null && values.Count > 0)
				{
					foreach (var dic in values)
					{
						map.SetValue(dic.Key, dic.Value);
					}
				}
			}
			return map;
		}

		public static DataMap ItemToDataMap(this LayoutControlGroup lcg)
		{
			var map = new DataMap();

			foreach (LayoutControlItem item in lcg.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null))
			{
				var values = item.GetControlValueWithFieldName();
				if (values != null && values.Count > 0)
				{
					foreach (var dic in values)
					{
						map.SetValue(dic.Key, dic.Value);
					}
				}
			}
			return map;
		}

		/// <summary>
		/// DataRow 의 값을 각각의 LayoutControlItem 의 Control EditValue값에 채워 넣습니다.
		/// </summary>
		/// <param name="row">DataRow</param>
		/// <param name="lcgs">LayoutControlGroup 배열</param>
		public static void BindingByDataRow(this LayoutControl lc, DataRow row, params LayoutControlGroup[] lcgs)
		{
			if (lcgs == null || lcgs.Length == 0)
			{
				lcgs = lc.Items.OfType<LayoutControlGroup>().ToArray();
			}
			foreach (LayoutControlGroup lcg in lcgs)
			{
				foreach (LayoutControlGroup group in lcg.Items.OfType<LayoutControlGroup>().Where(x => x.Items.Count > 0))
				{
					lc.BindingByDataRow(row, group);
				}

				foreach (LayoutControlItem item in lcg.Items.OfType<LayoutControlItem>().Where(x => x.Control != null))
				{
					var columnName = item.GetFieldNameByControlNoPattern();

					if (!string.IsNullOrEmpty(columnName) && row.Table.Columns.Contains(columnName))
					{
						item.SetControlValue(row.GetValue(columnName), row.GetValue(columnName.Substring(0, columnName.LastIndexOf('_')) + "_NM").ToStringNullToEmpty());
					}
				}
			}
		}
		public static void BindingByDataMap(this LayoutControl lc, DataMap map, params LayoutControlGroup[] lcgs)
		{
			if (lcgs == null || lcgs.Length == 0)
			{
				lcgs = lc.Items.OfType<LayoutControlGroup>().ToArray();
			}
			foreach (LayoutControlGroup lcg in lcgs)
			{
				foreach (LayoutControlGroup group in lcg.Items.OfType<LayoutControlGroup>().Where(x => x.Items.Count > 0))
				{
					lc.BindingByDataMap(map, group);
				}

				foreach (LayoutControlItem item in lcg.Items.OfType<LayoutControlItem>().Where(x => x.Control != null))
				{
					var columnName = item.GetFieldNameByControlNoPattern();

					if (!string.IsNullOrEmpty(columnName) && map.ContainsKey(columnName))
					{
						item.SetControlValue(map.GetValue(columnName), null);
					}
				}
			}
		}

		public static void ItemClear(this LayoutControlGroup group, params Control[] controls)
		{
			try
			{
				List<LayoutControlItem> list = null;
				if (controls == null || controls.Length == 0)
					list = group.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null).ToList();
				else
					list = group.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null && controls.Contains(x.Control)).ToList();

				if (list != null && list.Count > 0)
				{
					list.ForEach(x =>
					{
						ItemClear(x.Control);
					});
				}
			}
			catch
			{
			}
		}
		public static void ItemClear(this LayoutControl lc, params Control[] controls)
		{
			try
			{
				List<LayoutControlItem> list = null;
				if (controls == null || controls.Length == 0)
					list = lc.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null).ToList();
				else
					list = lc.Items.OfType<LayoutControlItem>().Where(x => x.Name.StartsWith("lcItem") && x.Control != null && controls.Contains(x.Control)).ToList();

				if (list != null && list.Count > 0)
				{
					list.ForEach(item =>
					{
						ItemClear(item.Control);
					});
				}
			}
			catch
			{
			}
		}
		private static void ItemClear(Control control)
		{
			if (control.GetType() == typeof(TextEdit))
			{
				(control as TextEdit).Clear();
			}
			else if (control.GetType() == typeof(XLookup))
			{
				(control as XLookup).Clear();
			}
			else if (control.GetType() == typeof(SpinEdit))
			{
				(control as SpinEdit).Clear();
			}
			else if (control.GetType() == typeof(MemoEdit))
			{
				(control as MemoEdit).Clear();
			}
			else if (control.GetType() == typeof(DateEdit))
			{
				(control as DateEdit).Clear();
			}
			else if (control.GetType() == typeof(CheckEdit))
			{
				(control as CheckEdit).Clear();
			}
			else if (control.GetType() == typeof(ButtonEdit))
			{
				(control as ButtonEdit).Clear();
			}
			else if (control.GetType() == typeof(XSearch))
			{
				(control as XSearch).Clear();
			}
			else if (control.GetType() == typeof(XPeriod))
			{
				(control as XPeriod).Clear();
			}
		}
	}
}
