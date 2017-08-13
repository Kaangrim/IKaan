using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AD
{
	[DataContract]
	public class ADTable: ModelBase
	{
		[DataMember]
		[Display(Name = "데이터베이스ID")]
		public int DatabaseID { get; set; }

		[DataMember]
		[Display(Name = "스키마명")]
		public string SchemaName { get; set; }

		[DataMember]
		[Display(Name = "테이블명")]
		public string TableName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "데이터베이스명")]
		public string DatabaseName { get; set; }

		[DataMember]
		[Display(Name = "컬럼")]
		public IList<ADColumn> Columns { get; set; }
	}
}
