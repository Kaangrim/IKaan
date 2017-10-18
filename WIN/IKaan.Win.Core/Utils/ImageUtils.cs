using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using IKaan.Base.Utils;
using IKaan.Model.Biz.Master.Common;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Utils
{
	public static class ImageUtils
	{
		private static string localImagePath = GlobalVar.ScrapInfo.ProductFilePath;

		public static void Download(string url, string localpath, string filename = null)
		{
			if (filename.IsNullOrEmpty())
				filename = url;

			if (localpath.IsNullOrEmpty())
				localpath = localImagePath;
			else
				localpath = localImagePath + localpath + @"\";

			string ext = url.Substring(url.LastIndexOf(".") + 1);

			if (filename.LastIndexOf(".") < 0)
				filename = filename + "." + ext;

			string filepath = localpath + filename;
			if (!Directory.Exists(localpath))
				Directory.CreateDirectory(localpath);

			if (File.Exists(filepath))
				File.Delete(filepath);

			using (WebClient client = new WebClient())
			{
				client.DownloadFile(url, filepath);
			}
		}

		public static string DownloadByStream(string url, string localpath, string filename = null)
		{
			if (filename.IsNullOrEmpty())
				filename = url;

			if (localpath.IsNullOrEmpty())
				localpath = localImagePath;
			else
				localpath = localImagePath + @"\" + localpath + @"\";

			string ext = url.Substring(url.LastIndexOf(".") + 1);

			if (filename.LastIndexOf(".") < 0)
				filename = filename + "." + ext;

			string filepath = localpath + filename;

			if (!Directory.Exists(localpath))
				Directory.CreateDirectory(localpath);

			if (File.Exists(filepath))
				File.Delete(filepath);

			using (WebClient client = new WebClient())
			{
				byte[] data = client.DownloadData(url);

				using (MemoryStream stream = new MemoryStream(data))
				{
					using (var image = Image.FromStream(stream))
					{
						switch (ext.ToLower())
						{
							case "jpg":
							case "jpeg":
								image.Save(filepath, ImageFormat.Jpeg);
								break;
							case "gif":
								image.Save(filepath, ImageFormat.Gif);
								break;
							case "png":
								image.Save(filepath, ImageFormat.Png);
								break;
							case "bmp":
								image.Save(filepath, ImageFormat.Bmp);
								break;
							default:
								image.Save(filepath);
								break;
						}
					}
				}
			}
			return filepath;
		}

		public static ImageModel SelectImage()
		{
			using (var dialog = new OpenFileDialog())
			{
				dialog.Filter = GetImageFilter();
				dialog.FilterIndex = 1;
				dialog.RestoreDirectory = true;

				if (dialog.ShowDialog() == DialogResult.OK)
				{
					if (dialog.FileName.IsNullOrEmpty())
						return null;

					return new ImageModel()
					{
						Name = GetFileName(dialog.FileName),
						Url = dialog.FileName,
						Width = GetSizePixel(dialog.FileName).Width,
						Height = GetSizePixel(dialog.FileName).Height
					};
				}
				else
					return null;
			}
		}

		public static Size GetSizePixel(string imagePath)
		{
			BitmapImage image = new BitmapImage(new Uri(imagePath));
			return new Size()
			{
				Height = image.PixelHeight,
				Width = image.PixelWidth
			};
		}

		public static string GetFileName(string imagePath)
		{
			return Path.GetFileName(imagePath);
		}

		private static string GetImageFilter()
		{
			StringBuilder allImageExtensions = new StringBuilder();
			string separator = "";
			ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
			Dictionary<string, string> images = new Dictionary<string, string>();
			foreach (var codec in codecs)
			{
				allImageExtensions.Append(separator);
				allImageExtensions.Append(codec.FilenameExtension);
				separator = ";";
				images.Add(string.Format("{0} Files: ({1})", codec.FormatDescription, codec.FilenameExtension), codec.FilenameExtension);
			}
			StringBuilder sb = new StringBuilder();
			if (allImageExtensions.Length > 0)
			{
				sb.AppendFormat("{0}|{1}", "All Images", allImageExtensions.ToString());
			}
			images.Add("All Files", "*.*");
			foreach (KeyValuePair<string, string> image in images)
			{
				sb.AppendFormat("|{0}|{1}", image.Key, image.Value);
			}
			return sb.ToString();
		}
	}
}
