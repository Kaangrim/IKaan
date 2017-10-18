using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Data;
using SmartXLS;
using System.Reflection;
using ExcelLibrary;
using ExcelLibrary.SpreadSheet;
using ExcelLibrary.BinaryDrawingFormat;
using ExcelLibrary.BinaryFileFormat;
using ExcelLibrary.CompoundDocumentFormat;

namespace IKaan.Web.Core.Utils
{
    public class ToExcel
    {


        /// <summary>
        /// 엑셀 헤더 정보
        /// </summary>
        private string[] Headers { get; set; }

        /// <summary>
        /// 엑셀 내용....
        /// </summary>
        private object[,] myExcelData = null;

        private WorkBook workbook = new WorkBook();
        private RangeStyle _rstyle;



        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <param name="Headers_"></param>
        /// <param name="list"></param>
        public string ToExcelFromList<T>(string dir, string fileName, string[] Headers_, List<T> list)
        {
            return this.ToExcelFromList<T>(dir, fileName, Headers_, Headers_, list);
        }

        /// <summary>
        /// List the type of conversion to Excel(No Image)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <param name="Headers_"></param>
        /// <param name="list"></param>
        public string ToExcelFromList<T>(string dir, string fileName, string[] Headers_, string[] dataHeaders_, List<T> list)
        {
            this.Headers = Headers_;
            myExcelData = new object[list.Count + 1, Headers_.Length];

            workbook.setSheetName(0, fileName);
            workbook.Sheet = 0;
            _rstyle = workbook.getRangeStyle();


            this.Headers = Headers_;
            //Sheet 헤더 내용 채우기
            this.FillHeaderColumn();

            this.Headers = dataHeaders_;
            //List 에서 Object 형식으로 데이터 내용 채우기
            this.FillRowData<T>(list);


            //Sheet 데이타 내용 채우기
            this.FillDataColumn<T>(list);

            return this.CreateExcel(dir, fileName);
        }

        /// <summary>
        /// List 형식을 Object 형식에 데이터 채우기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list_"></param>
        public void FillRowData<T>(List<T> list_)
        {
            int ii = 0;
            foreach (T tlist in list_)
            {
                PropertyInfo[] pClass = tlist.GetType().GetProperties();
                int jj = 0;
                if (pClass != null && pClass.Length > 0)
                {
                    foreach (PropertyInfo pc in pClass)
                    {
                        for (int kk = 0; kk < this.Headers.Length; kk++)
                        {
                            if (pc.Name.Trim() == this.Headers[kk].ToString().Trim())
                            {
                                myExcelData[ii, kk] = pc.GetValue(tlist, null);

                                jj++;
                            }

                            if (Headers.Length == jj)
                            {
                                continue;
                            }
                        }
                    }
                }
                ii++;
            }
        }

        /// <summary>
        /// 엑셀시트 헤더값 채우기
        /// </summary>
        private void FillHeaderColumn()
        {
            for (int ii = 0; ii < Headers.Length; ii++)
            {
                workbook.setText(0, ii, Headers[ii].ToString());
                workbook.setSelection(0, 0, 0, Headers.Length - 1);
                _rstyle.BottomBorder = RangeStyle.BorderDouble;
                workbook.setRangeStyle(_rstyle);
            }
        }

        /// <summary>
        /// 엑셀시트 내용 채우기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        private void FillDataColumn<T>(List<T> list)
        {
            for (int kk = 0; kk < list.Count; kk++)
            {
                for (int ii = 0; ii < Headers.Length; ii++)
                {
                    if (myExcelData != null && myExcelData[kk, ii] != null)
                        workbook.setText(kk + 1, ii, myExcelData[kk, ii].ToString());
                }
            }
        }


        /// <summary>
        /// Save the converted Excel
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        private string CreateExcel(string dir, string fileName)
        {
            if (!System.IO.Directory.Exists(dir))
            {
                System.IO.Directory.CreateDirectory(dir);
            }

            var dt = DateTime.Now;

            fileName = dir + "\\" + fileName;
            workbook.write(fileName);

            return fileName;
        }









        /// <summary>
        /// DataTable과 동일한 Excel을 생성한다.
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <param name="dt"></param>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public string ToExcelFromDataTable(string dir, string fileName, System.Data.DataTable dt, string SheetName)
        {
            System.GC.Collect();
            int row = 0;
            int col = 0;

            workbook.setSheetName(0, SheetName);

            for (row = 0; row < dt.Rows.Count; row++)
            {
                for (col = 0; col < dt.Columns.Count; col++)
                {
                    //Header
                    if (row == 0)
                    {
                        workbook.setText(row, col, dt.Columns[col].ToString());
                    }
                    string text = dt.Rows[row].ItemArray[col].ToString();

                    if (dt.Columns[col].ColumnName == "[이미지]" || dt.Columns[col].ColumnName == "이미지")
                    {
                        workbook.addHyperlink(row + 1, col, row + 1, col, text, HyperLink.kURLAbs, "이미지링크");
                    }
                    else
                    {
                        workbook.setText(row + 1, col, text);
                    }
                }
            }


            return this.CreateExcel(dir, fileName);
        }

        /// <summary>
        /// DataTable로 Header값과 동일한 Excel을 생성한다.
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <param name="dt"></param>
        /// <param name="header"></param>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public string ToExcelFromDataTable(string dir, string fileName, System.Data.DataTable dt, string[] header, string SheetName)
        {
            int row = 0;
            int col = 0;

            workbook.setSheetName(0, SheetName);

            for (row = 0; row < dt.Rows.Count; row++)
            {
                for (col = 0; col < dt.Columns.Count; col++)
                {
                    for (int j = 0; j < header.Length; j++)
                    {
                        if (dt.Columns[col].ToString() == header[j])
                        {
                            //Header
                            if (row == 0)
                            {
                                workbook.setText(row, j, dt.Columns[col].ToString());
                            }

                            string text = dt.Rows[row].ItemArray[col].ToString();

                            workbook.setText(row + 1, j, text);
                        }

                    }
                }
            }
            return this.CreateExcel(dir, fileName);
        }




        /// <summary>
        /// DataTable로 Header값과 동일한 Excel을 생성한다.
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="fileName"></param>
        /// <param name="dt"></param>
        /// <param name="header"></param>
        /// <param name="SheetName"></param>
        /// <returns></returns>
        public string ToExcelFromXml(string dir, string fileName, System.Data.DataTable dt, string[] header = null, string SheetName = "Sheet1")
        {
            this.CreateExcel(dir, fileName);

            if (string.IsNullOrEmpty(dt.TableName))
            {
                dt.TableName = "Sheet1";
            }
            workbook.setSheetName(0, SheetName);

            int ii = 0;
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                if (dt.Columns[col].ColumnName == "[이미지]" || dt.Columns[col].ColumnName == "이미지")
                {
                    ii = col;
                    break;
                }
            }

            /*
            ConditionFormat[] condfmt = new ConditionFormat[dt.Columns.Count];


            for (int col = 0; col < dt.Columns.Count; col++)
            {
                condfmt[col] = workbook.CreateConditionFormat();
                condfmt[col].Type = ConditionFormat.eTypeFormula;
            }

            workbook.ConditionalFormats = condfmt;
            */

            //workbook.ConditionalFormats = condfmt;
            //ii
            workbook.ImportDataTable(dt, true, 0, 0, 2100000000, 999999999);

            /*
            for (int col = 0; col < dt.Columns.Count; col++)
            {
                if (dt.Columns[col].ColumnName == "[이미지]" || dt.Columns[col].ColumnName == "이미지")
                {
                    for (int row = 0; row < dt.Rows.Count; row++)
                    {
                        workbook.addHyperlink(row + 1, col, row + 1, col, dt.Rows[row][col].ToString()  , HyperLink.kURLAbs, "이미지링크");
                    }
                    break;
                }
            }
            */
            return this.CreateExcel(dir, fileName);
        }

        /// <summary>
        /// DataSet로 Header값과 동일한 Excel을(DataTable당 하나의 sheet생성) 생성한다.
        /// </summary>
        public string ToExcelFromDataSet(string dir, string fileName, System.Data.DataSet r_Ds)
        {
            this.CreateExcel(dir, fileName);

            //시트명 명명
            string sSheetName;
            for (int i = 0; i < r_Ds.Tables.Count; i++)
            {
                if (string.IsNullOrEmpty(r_Ds.Tables[i].TableName))
                {
                    sSheetName = "Sheet" + (i + 1);
                }
                else
                {
                    sSheetName = r_Ds.Tables[i].TableName;
                }

                workbook.insertSheets(i, 1);
                workbook.Sheet = i;
                workbook.setSheetName(i, sSheetName);

                workbook.ImportDataTable(r_Ds.Tables[i], true, 0, 0, 2100000000, 999999999);

            }

            return this.CreateExcel(dir, fileName);
        }




        /// <summary>
        /// 엑셀을 로드하여 DataTable로 변환
        /// (xlsx는 불가능하며, xls만 로드 가능)
        /// xlsx => outofmemory Exception
        /// </summary>
        /// <param name="FilePath"></param>
        /// <returns></returns>
        public System.Data.DataTable Get_FromExcel(string FilePath)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            Workbook book = Workbook.Load(FilePath);
            Worksheet sheet = book.Worksheets[0];


            // traverse cells
            foreach (QiHe.CodeLib.Pair<QiHe.CodeLib.Pair<int, int>, Cell> cell in sheet.Cells)
            {

                if (cell.Left.Left.ToString() == "0" && !dt.Columns.Contains(cell.Right.Value.ToString()))
                    dt.Columns.Add(cell.Right.Value.ToString());
            }

            // traverse rows by Index
            for (int rowIndex = sheet.Cells.FirstRowIndex;
                   rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                if (rowIndex == 0)
                    continue;

                System.Data.DataRow drow = dt.NewRow();
                Row row = sheet.Cells.GetRow(rowIndex);

                for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                {
                    drow[colIndex] = row.GetCell(colIndex);
                }
                dt.Rows.Add(drow);
            }

            return dt;


        }

        public System.Data.DataTable Get_FromExcel(string FilePath, int iSheetNum)
        {
            System.Data.DataTable dt = new System.Data.DataTable();

            Workbook book = Workbook.Load(FilePath);
            Worksheet sheet = book.Worksheets[iSheetNum];


            // traverse cells
            foreach (QiHe.CodeLib.Pair<QiHe.CodeLib.Pair<int, int>, Cell> cell in sheet.Cells)
            {

                if (cell.Left.Left.ToString() == "0" && !dt.Columns.Contains(cell.Right.Value.ToString()))
                    dt.Columns.Add(cell.Right.Value.ToString());
            }

            // traverse rows by Index
            for (int rowIndex = sheet.Cells.FirstRowIndex;
                   rowIndex <= sheet.Cells.LastRowIndex; rowIndex++)
            {
                if (rowIndex == 0)
                    continue;

                System.Data.DataRow drow = dt.NewRow();
                Row row = sheet.Cells.GetRow(rowIndex);

                for (int colIndex = row.FirstColIndex; colIndex <= row.LastColIndex; colIndex++)
                {
                    drow[colIndex] = row.GetCell(colIndex);
                }
                dt.Rows.Add(drow);
            }

            return dt;


        }
    }


    /// <summary>
    /// List<T>를 DataTable로 형 변환한다.
    /// </summary>
    public static class ConvertToDataTable
    {
        /// <summary>
        /// List<T>를 DataTable로 형 변환한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DataTable ToDataTableFromList<T>(this IList<T> data)
        {
            PropertyDescriptorCollection props =
                TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            for (int i = 0; i < props.Count; i++)
            {
                PropertyDescriptor prop = props[i];
                table.Columns.Add(prop.Name, prop.PropertyType);
            }
            object[] values = new object[props.Count];
            foreach (T item in data)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    values[i] = props[i].GetValue(item);
                }
                table.Rows.Add(values);
            }
            return table;
        }

    }
}