using System.Collections.Generic;
using IKaan.Win.Core.Model;
using IKaan.Model.Common.UserModels ;

namespace IKaan.Win.Core.Variables
{
	public static class GlobalVar
	{
		static GlobalVar()
		{
			ServerInfo = new ServerInfo();
			UserInfo = new UserInfo();
			SkinInfo = new SkinInfo();
			MainInfo = new MainInfo();
			Codes = new List<UCodeLookup>();
		}

		public static string Version { get; set; }

		public static ServerInfo ServerInfo { get; set; }

		public static UserInfo UserInfo { get; set; }

		public static SkinInfo SkinInfo { get; set; }

		public static MainInfo MainInfo { get; set; }

		public static IList<UCodeLookup> Codes { get; set; }
		
	}
}
