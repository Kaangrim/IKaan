using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;

namespace IKaan.Base.Utils
{
	public static class ExtensionUtils
	{
		static GregorianCalendar gc = new GregorianCalendar();

		#region Boolean
		public static bool YnToBool(this object obj)
		{
			if (obj == null || !(obj is string))
			{
				return false;
			}
			return obj.ToString() == "Y" ? true : false;
		}

		public static bool YnToBool(this string str)
		{
			return str == "Y" ? true : false;
		}
		#endregion
		
		#region DateTime String to String
		public static string ToDateTime(this string str, string format = "yyyy-MM-dd")
		{
			return str.Length == 8 ? DateTime.ParseExact(str, "yyyyMMdd", null).ToString(format) : DateTime.Parse(str).ToString(format);
		}
		
		public static string ToDateTime(this object obj, string format = "yyyy-MM-dd")
		{
			if (obj == null || !(obj is string))
			{
				return string.Empty;
			}
			return obj.ToString().ToDateTime(format);
		}

		public static string ToDateTimeString(this DateTime? dt, string format = "yyyy-MM-dd")
		{
			if (dt == null)
				return null;
			else if (dt.GetType() != typeof(DateTime) && dt.GetType() != typeof(DateTime?))
				return null;
			else
				return Convert.ToDateTime(dt).ToString(format);
		}
		#endregion

		#region String to Lower
		public static string ToLowerUpper(this string str, bool? isUpper)
		{
			if (isUpper != null)
			{
				if ((bool)isUpper)
				{
					str = str.ToUpper();
				}
				else
				{
					str = str.ToLower();
				}
			}

			return str;
		}
		#endregion

		#region Decimal
		public static decimal ToDecimalNullToZero(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}

		public static decimal? ToDecimalNullToNull(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return null;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		#endregion

		#region Integer
		public static int ToIntegerNullToZero(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		public static int? ToIntegerNullToNull(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return null;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}

		public static int ToInteger(this decimal d)
		{
			return Convert.ToInt32(d);
		}

		public static int ToInteger(this double d)
		{
			return Convert.ToInt32(d);
		}
		#endregion

		#region Double
		public static double ToDoubleNullToZero(this object obj)
		{
			if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
			{
				return 0;
			}
			else
			{
				return Convert.ToDouble(obj);
			}
		}
		#endregion

		public static bool ToBooleanNullToFalse(this object obj)
		{
			if (obj is bool)
			{
				if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
				{
					return false;
				}
				else
				{
					return (bool)obj;
				}
			}
			else
			{
				if (obj is string)
				{
					if (obj == null || obj == DBNull.Value || obj.ToString() == string.Empty)
					{
						return false;
					}
					else
					{
						return obj.ToString() == "Y" ? true : false;
					}
				}
				else
				{
					return false;
				}
			}
		}

		public static string ToStringNullToEmpty(this object obj, bool emptyRemove = true)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return string.Empty;
			}
			else
			{
				if (emptyRemove)
					return obj.ToString().Trim();
				else
					return obj.ToString();
			}
		}

		public static string ToStringNullToNull(this object obj)
		{
			if (obj == null || obj == DBNull.Value)
			{
				return null;
			}
			else
			{
				return obj.ToString();
			}
		}

		public static bool IsNullOrEmpty(this object obj)
		{
			return string.IsNullOrEmpty(obj.ToStringNullToEmpty());
		}

		public static bool IsNullOrDefault(this object obj)
		{
			if (obj == null)
				return true;

			if (obj.GetType() == typeof(int) || obj.GetType() == typeof(int?))
			{
				if (obj.ToIntegerNullToNull() == null || obj.ToIntegerNullToNull() == default(int))
					return true;
				else
					return false;
			}
			else
			{
				return false;
			}
		}

		public static DataTable ToEmptyDataTable(Dictionary<string, Type> columns)
		{
			var dt = new DataTable();
			foreach (KeyValuePair<string, Type> columnName in columns)
			{
				dt.Columns.Add(columnName.Key, columnName.Value);
			}

			return dt;
		}

		public static double BytesToMegaBytes(this long bytes)
		{
			return (bytes / 1024f) / 1024f;
		}
		public static double BytesToKiloBytes(this long kb)
		{
			return kb / 1024f;
		}

		#region WeekOfMonth
		public static int GetWeekOfMonth(this DateTime dt)
		{
			DateTime first = new DateTime(dt.Year, dt.Month, 1);
			return dt.GetWeekOfYear() - first.GetWeekOfYear() + 1;
		}

		public static int GetWeekOfYear(this DateTime dt)
		{
			GregorianCalendar gc = new GregorianCalendar();
			return gc.GetWeekOfYear(dt, CalendarWeekRule.FirstDay, DayOfWeek.Sunday);
		}
		#endregion
	}
}
