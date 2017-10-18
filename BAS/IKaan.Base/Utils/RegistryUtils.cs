using IKaan.Base.Variables;
using Microsoft.Win32;

namespace IKaan.Base.Utils
{
	public class RegistryUtils
	{
		private static string RegRootPath = BaseConstsVar.REG_ROOT;

		public static string GetValue(string path, string key)
		{
			try
			{
				var keyPath = string.Format(@"{0}\{1}", RegRootPath, path);
				var reg = Registry.CurrentUser.OpenSubKey(keyPath, true);
				if (reg == null)
				{
					reg = Registry.CurrentUser.CreateSubKey(keyPath);
				}
				return reg.GetValue(key).ToString();
			}
			catch
			{
				return null;
			}
		}

		public static void SetValue(string path, string key, string value)
		{
			var keyPath = string.Format(@"{0}\{1}", RegRootPath, path);
			var reg = Registry.CurrentUser.OpenSubKey(keyPath, true);
			if (reg == null)
			{
				reg = Registry.CurrentUser.CreateSubKey(keyPath);
			}
			reg.SetValue(key, value);
		}
	}
}
