using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using IKaan.Base.Variables;

namespace IKaan.Base.Utils
{
	public class FileUtils
	{
		public static string GetExportFilePath()
		{
			return string.Format("C:\\{0}\\ExportXls", BaseConstsVar.APP_PATH);
		}
		public static string GetUniqueFileName(string fileName)
		{
			var fileInfo = new FileInfo(fileName);
			return MakeUniqueFileName(fileInfo.DirectoryName, fileInfo.Name.Replace(fileInfo.Extension, string.Empty), fileInfo.Extension);
		}
		public static string GetUniqueFileName(string path, string fileName)
		{
			var fileInfo = new FileInfo(fileName);
			return MakeUniqueFileName(path, fileInfo.Name.Replace(fileInfo.Extension, string.Empty), fileInfo.Extension);
		}
		private static string MakeUniqueFileName(string path, string name, string ext)
		{
			var sb = new StringBuilder();
			var time = DateTime.Now.ToString("yyyyMMdd-HHmm_");
			var cnt = 0;
			while (true)
			{
				if (!File.Exists(sb.AppendFormat("{0}\\{1}{2}{3}{4}", path, time, name, cnt == 0 ? string.Empty : string.Format("({0})", cnt.ToString()), ext).ToString()))
				{
					return sb.ToString();
				}
				cnt++;
				sb.Clear();
			}
		}
		public static void CheckDirectory(string path)
		{
			if (!Directory.Exists(path))
			{
				Directory.CreateDirectory(path);
			}
		}
		public static string OpenExcelFile(string filter = "")
		{
			if (string.IsNullOrEmpty(filter))
				filter = "Excel files|*.xlsx;*.xls|All files|*.*";

			using (var ofd = new OpenFileDialog()
			{
				Filter = filter
			})
			{
				if (ofd.ShowDialog() == DialogResult.OK)
					return ofd.FileName;
				else
					return null;
			}
		}
		public static string SaveExcelFile(string filter = "", string fileName = "")
		{
			if (string.IsNullOrEmpty(filter))
				filter = "Excel(Xlsx) files|*.xlsx|Excel(Xls) files|*.xls|CSV files|*.csv|All files|*.*";

			using (var sfd = new SaveFileDialog()
			{
				Filter = filter,
				FileName = fileName
			})
			{
				if (sfd.ShowDialog() == DialogResult.OK)
					return sfd.FileName;
				else
					return null;
			}
		}
		public static void StartProcess(string fileName)
		{
			try
			{
				if (File.Exists(fileName))
				{
					StartProcess(fileName);
				}
			}
			catch
			{
			}
		}
		public static string GetExcelPath()
		{
			try
			{
				return string.Empty;
			}
			catch
			{
				throw;
			}
		}
		public static void SetExcelPath(string path)
		{
			try
			{
			}
			catch
			{
				throw;
			}
		}
	}
}
