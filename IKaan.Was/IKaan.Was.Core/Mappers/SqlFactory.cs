using System.Data.SqlClient;
using IKaan.Was.Core.Config;
using Microsoft.ApplicationBlocks.Data;

namespace IKaan.Was.Service.Mappers
{
	public class SqlFactory
	{
		public static SqlHelper Instance;
		public static SqlConnection Connection
		{
			get
			{
				return new SqlConnection(DatabaseConfig.ConnectionString);
			}
		}
	}
}
