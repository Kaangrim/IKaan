using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AD
{
	[DataContract]
	public class ADDatabase: ModelBase
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
	}
}
