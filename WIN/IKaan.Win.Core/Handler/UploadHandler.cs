using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using DevExpress.Spreadsheet;
using DevExpress.XtraSpreadsheet;
using IKaan.Base.Utils;
using IKaan.Win.Core.Was.Handler;

namespace IKaan.Win.Core.Handler
{
	public static class UploadHandler
	{
		public static IList<T> GetExcelData<T>(int startLine)
		{
			if (startLine == default(int))
				startLine = 2;

			IList<T> result = new List<T>();

			string fileName = FileUtils.OpenExcelFile();

			if (fileName.IsNullOrEmpty() == false)
			{
				using (SpreadsheetControl sheet = new SpreadsheetControl())
				{
					sheet.Document.CreateNewDocument();
					sheet.LoadDocument(fileName);

					ColumnCollection cols = sheet.ActiveWorksheet.Columns;
					RowCollection rows = sheet.ActiveWorksheet.Rows;

					for (int i = 0; i <= rows.LastUsedIndex; i++)
					{
						if (rows[i].Visible == false)
							continue;

						if (i < startLine)
							continue;

						var data = (T)Activator.CreateInstance(typeof(T), null);
						var entityType = typeof(T);
						var properties = TypeDescriptor.GetProperties(entityType);

						for (int c = 0; c <= cols.LastUsedIndex; c++)
						{
							if (rows[0][c].Value.TextValue.IsNullOrEmpty())
								continue;

							PropertyDescriptor prop = properties.OfType<PropertyDescriptor>().Where(p => p.Name == rows[0][c].Value.ToString()).FirstOrDefault();
							if (prop == null)
								continue;

							if (prop.PropertyType == typeof(decimal) || prop.PropertyType == typeof(decimal?))
							{
								if (rows[i][c].Value.IsEmpty)
								{
									data.GetType().GetProperty(prop.Name).SetValue(data, null, null);
								}
								else
								{
									if (rows[i][c].Value.IsNumeric)
										data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.NumericValue, null);
									else
										data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.NumericValue.ToDecimalNullToNull(), null);
								}
							}
							else if (prop.PropertyType == typeof(int) || prop.PropertyType == typeof(int?))
							{
								if (rows[i][c].Value.IsEmpty)
								{
									data.GetType().GetProperty(prop.Name).SetValue(data, null, null);
								}
								else
								{
									if (rows[i][c].Value.IsNumeric)
										data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.NumericValue, null);
									else
										data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.NumericValue.ToIntegerNullToNull(), null);
								}
							}
							else if (prop.PropertyType == typeof(DateTime) || prop.PropertyType == typeof(DateTime?))
							{
								if (rows[i][c].Value.IsEmpty)
								{
									data.GetType().GetProperty(prop.Name).SetValue(data, null, null);
								}
								else
								{
									if (rows[i][c].Value.IsDateTime)
										data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.DateTimeValue, null);
									else
										data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.TextValue.ToDateTime(), null);
								}
							}
							else
							{
								if (rows[i][c].Value.IsEmpty)
									data.GetType().GetProperty(prop.Name).SetValue(data, null, null);
								else
									data.GetType().GetProperty(prop.Name).SetValue(data, rows[i][c].Value.TextValue.ToStringNullToNull(), null);
							}
						}
						result.Add(data);
					}
				}
			}

			return result;
		}

		public static bool Execute<T>(string serviceId, string processId, string sqlId = null, int startLine = 2)
		{
			try
			{
				if (startLine == default(int))
					startLine = 2;

				IList<T> list = UploadHandler.GetExcelData<T>(startLine);
				if (list == null || list.Count == 0)
					return false;

				if (sqlId.IsNullOrEmpty())
					sqlId = string.Concat("Insert", typeof(T).Name);

				using (var res = WasHandler.Execute<T>(serviceId, processId, sqlId, list, "ID"))
				{
					if (res.Error.Number != 0)
						throw new Exception(res.Error.Message);

					return true;
				}
			}
			catch
			{
				throw;
			}
		}
	}
}
