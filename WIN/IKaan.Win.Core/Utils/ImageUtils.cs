using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Windows.Media.Imaging;
using IKaan.Base.Utils;
using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Utils
{
	public static class ImageUtils
	{
		private static string localImagePath = ConstsVar.APP_PATH_GOODS;

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

		public static void DownloadByStream(string url, string localpath, string filename = null)
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
	}
}
