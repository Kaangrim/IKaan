using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Common
{
	[DataContract]
	public class CodeModel: ModelBase
	{
		[DataMember]
		[Display(Name = "계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "계층명")]
		public string HierName { get; set; }

		[DataMember]
		[Display(Name = "레벨")]
		public int CodeLevel { get; set; }

		[DataMember]
		[Display(Name = "코드")]
		public string Code { get; set; }

		[DataMember]
		[Display(Name = "코드명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "코드값")]
		public string Value { get; set; }

		[DataMember]
		[Display(Name = "상위코드")]
		public string ParentCode { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public int SortOrder { get; set; }

		[DataMember]
		[Display(Name = "하위코드길이")]
		public int MaxLength { get; set; }

		[DataMember]
		[Display(Name = "코드값1")]
		public string CodeValue01 { get; set; }

		[DataMember]
		[Display(Name = "코드값2")]
		public string CodeValue02 { get; set; }

		[DataMember]
		[Display(Name = "코드값3")]
		public string CodeValue03 { get; set; }

		[DataMember]
		[Display(Name = "코드값4")]
		public string CodeValue04 { get; set; }

		[DataMember]
		[Display(Name = "코드값5")]
		public string CodeValue05 { get; set; }

		[DataMember]
		[Display(Name = "코드값6")]
		public string CodeValue06 { get; set; }

		[DataMember]
		[Display(Name = "코드값7")]
		public string CodeValue07 { get; set; }

		[DataMember]
		[Display(Name = "코드값8")]
		public string CodeValue08 { get; set; }

		[DataMember]
		[Display(Name = "코드값9")]
		public string CodeValue09 { get; set; }

		[DataMember]
		[Display(Name = "코드값10")]
		public string CodeValue10 { get; set; }
	}
}
