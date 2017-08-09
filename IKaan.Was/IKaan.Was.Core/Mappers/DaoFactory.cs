using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;

namespace IKaan.Was.Core.Mappers
{
	public class DaoFactory
	{
		private static object syncLock = new object();
		private static ISqlMapper mapper = null;
		private static ISqlMapper mapperBiz = null;
		private static ISqlMapper mapperLib = null;
		private static ISqlMapper mapperSmp = null;
		
		public static ISqlMapper Instance
		{
			get
			{
				try
				{
					if (mapper == null)
					{
						lock (syncLock)
						{
							if (mapper == null)
							{
								var dom = new DomSqlMapBuilder();
								var sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMap.config, IKaan.Was.Core");
								mapper = dom.Configure(sqlMapConfig);
							}
						}
					}
				}
				catch
				{
					throw;
				}
				return mapper;
			}
		}

		public static ISqlMapper InstanceBiz
		{
			get
			{
				try
				{
					if (mapperBiz == null)
					{
						lock (syncLock)
						{
							if (mapperBiz == null)
							{
								var dom = new DomSqlMapBuilder();
								var sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMapBiz.config, IKaan.Was.Core");
								mapperBiz = dom.Configure(sqlMapConfig);
							}
						}
					}
				}
				catch
				{
					throw;
				}
				return mapperBiz;
			}
		}

		public static ISqlMapper InstanceLib
		{
			get
			{
				try
				{
					if (mapperLib == null)
					{
						lock (syncLock)
						{
							if (mapperBiz == null)
							{
								var dom = new DomSqlMapBuilder();
								var sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMapLib.config, IKaan.Was.Core");
								mapperLib = dom.Configure(sqlMapConfig);
							}
						}
					}
				}
				catch
				{
					throw;
				}
				return mapperLib;
			}
		}

		public static ISqlMapper InstanceSmp
		{
			get
			{
				try
				{
					if (mapperSmp == null)
					{
						lock (syncLock)
						{
							if (mapperSmp == null)
							{
								var dom = new DomSqlMapBuilder();
								var sqlMapConfig = Resources.GetEmbeddedResourceAsXmlDocument("Config.SqlMapSmp.config, IKaan.Was.Core");
								mapperSmp = dom.Configure(sqlMapConfig);
							}
						}
					}
				}
				catch
				{
					throw;
				}
				return mapperSmp;
			}
		}
	}
}
