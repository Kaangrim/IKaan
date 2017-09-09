using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Database
{
	[DataContract]
	public class DatabaseModel: ModelBase
	{
		[DataMember]
		[Display(Name = "데이터베이스명")]
		public string DatabaseName { get; set; }

		[DataMember]
		[Display(Name = "DBMS유형")]
		public string DbmsType { get; set; }

		[DataMember]
		[Display(Name = "서버명")]
		public int ServerID { get; set; }

		[DataMember]
		[Display(Name = "연결문자열")]
		public string ConnectionString { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "서버명")]
		public string ServerName { get; set; }

		[DataMember]
		[Display(Name = "DBMS유형명")]
		public string DbmsTypeName { get; set; }
	}
}
