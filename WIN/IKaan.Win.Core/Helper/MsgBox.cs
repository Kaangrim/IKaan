using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using IKaan.Base.Logging;
using IKaan.Base.Utils;

namespace IKaan.Win.Core.Helper
{
	public static class MsgBox
	{
		public static void Show(string text)
		{
			XtraMessageBox.Show(text, "HELP!!");
		}
		public static void Show(string text, string caption)
		{
			XtraMessageBox.Show(text, caption);
		}
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons)
		{
			return XtraMessageBox.Show(text, caption, buttons);
		}
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon)
		{
			return XtraMessageBox.Show(text, caption, buttons, icon);
		}
		public static DialogResult Show(string text, string caption, MessageBoxButtons buttons, MessageBoxIcon icon, MessageBoxDefaultButton defaulButtonModel)
		{
			return XtraMessageBox.Show(text, caption, buttons, icon, defaulButtonModel);
		}


		public static void Show(Exception ex)
		{
			try
			{
				var error = ErrorUtils.GetMessageAndTrace(ex);

				Logger.Error(error.Message);

				using (var msgbox = new MsgBoxForm())
				{
					msgbox.Text = "ERROR!!";
					msgbox.Message = error.Message + 
						Environment.NewLine + Environment.NewLine +
						"********** Stack Trace **********" + 
						Environment.NewLine + 
						error.StackTrace;
					msgbox.ShowDialog();
				}
			}
			catch
			{
			}
		}
	}
}
