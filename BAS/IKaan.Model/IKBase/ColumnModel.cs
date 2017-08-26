using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class ColumnModel: ModelBase
	{
		[DataMember]
		[Display(Name = "테이블ID")]
		public int? TableID { get; set; }

		[DataMember]
		[Display(Name = "물리명")]
		public string PhysicalName { get; set; }

		[DataMember]
		[Display(Name = "논리명")]
		public string LogicalName { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "데이터형식")]
		public string DataType { get; set; }

		[DataMember]
		[Display(Name = "테이블ID")]
		public string NullYn { get; set; }

		[DataMember]
		[Display(Name = "Primary Key 여부")]
		public string PkYn { get; set; }

		[DataMember]
		[Display(Name = "Foreign Key 여부")]
		public string FkYn { get; set; }

		[DataMember]
		[Display(Name = "Identity 여부")]
		public string IdentityYn { get; set; }

		[DataMember]
		[Display(Name = "기본값")]
		public string DefaultValue { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public int SortOrder { get; set; }

		[DataMember]
		[Display(Name = "스키마명")]
		public string SchemaName { get; set; }

		[DataMember]
		[Display(Name = "테이블명")]
		public string TableName { get; set; }
	}
}
