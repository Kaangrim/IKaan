using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	public class BGCategory : ModelBase
	{
		[DataMember]
		[Display(Name = "부모ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public string CategoryName { get; set; }

		[DataMember]
		[Display(Name = "카테고리1")]
		public int? Category1 { get; set; }

		[DataMember]
		[Display(Name = "카테고리2")]
		public int? Category2 { get; set; }

		[DataMember]
		[Display(Name = "카테고리3")]
		public int? Category3 { get; set; }

		[DataMember]
		[Display(Name = "카테고리4")]
		public int? Category4 { get; set; }

		[DataMember]
		[Display(Name = "카테고리5")]
		public int? Category5 { get; set; }

		[DataMember]
		[Display(Name = "정보고시ID")]
		public int? InfoNoticeID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public string SortOrder { get; set; }
	}
}
