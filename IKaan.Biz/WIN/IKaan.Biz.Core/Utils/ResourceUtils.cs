using System.Drawing;
using IKaan.Biz.Core.Resources;

namespace IKaan.Biz.Core.Utils
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
