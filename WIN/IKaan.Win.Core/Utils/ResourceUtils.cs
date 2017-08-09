﻿using System.Drawing;
using IKaan.Win.Core.Resources;

namespace IKaan.Win.Core.Utils
{
	public static class ResourceUtils
	{
		public static string GetPopMenusValue(string key)
		{
			return null;
		}
		public static string GetColumnCaption(string key)
		{
			return null;
		}

		public static Bitmap GetImage(string name)
		{
			try
			{
				var rm = ImageResource.ResourceManager;
				return (Bitmap)rm.GetObject(name);
			}
			catch
			{
				throw;
			}
		}
	}
}
