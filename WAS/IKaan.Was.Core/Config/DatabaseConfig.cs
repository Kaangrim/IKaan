using IKaan.Base.Map;
using IKaan.Base.Utils;

namespace IKaan.Was.Core.Config
{
	public static class DatabaseConfig
	{
		public static string Id { get; set; }
		public static DataMap Connections { get; internal set; }
		public static string ConnectionString
		{
			get
			{
				return Connections.GetValue(Id).ToStringNullToEmpty();
			}
		}

		static DatabaseConfig()
		{
			Connections = new DataMap();
			Connections.SetValue("REAL", @"Data Source=.\SQLEXPRESS;Initial Catalog=AUBE;Integrated Security=True");
			Connections.SetValue("TEST", @"Data Source=.\SQLEXPRESS;Initial Catalog=AUBE;Integrated Security=True");
		}

		public static string GetConnectionString(string id = null)
		{
			if (string.IsNullOrEmpty(id))
			{
				id = Id;
			}
			return Connections.GetValue(id).ToStringNullToEmpty();
		}
	}
}
