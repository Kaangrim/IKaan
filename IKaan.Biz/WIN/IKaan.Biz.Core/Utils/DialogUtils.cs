using System;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace IKaan.Biz.Core.Utils
{
	public class DialogUtils
	{
		public static FileInfo OpenImageFile()
		{
			using (OpenFileDialog dlg = new OpenFileDialog())
			{
				dlg.Filter = "";

				ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
				string sep = string.Empty;

				foreach (var c in codecs)
				{
					string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
					dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
					sep = "|";
				}

				dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

				dlg.DefaultExt = ".png"; // Default file extension 

				// Show open file dialog box 
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					// Open document 
					string filePath = dlg.FileName;
					FileInfo info = new FileInfo(filePath);
					return info;
				}
				else
				{
					return null;
				}
			}
		}

		public static FileInfo SaveImageFile()
		{
			using (SaveFileDialog dlg = new SaveFileDialog())
			{
				dlg.Filter = "";

				ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
				string sep = string.Empty;

				foreach (var c in codecs)
				{
					string codecName = c.CodecName.Substring(8).Replace("Codec", "Files").Trim();
					dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, codecName, c.FilenameExtension);
					sep = "|";
				}

				dlg.Filter = String.Format("{0}{1}{2} ({3})|{3}", dlg.Filter, sep, "All Files", "*.*");

				dlg.DefaultExt = ".png"; // Default file extension 

				// Show open file dialog box 
				if (dlg.ShowDialog() == DialogResult.OK)
				{
					// Open document 
					string filePath = dlg.FileName;
					FileInfo info = new FileInfo(filePath);
					return info;
				}
				else
				{
					return null;
				}
			}
		}
	}
}
