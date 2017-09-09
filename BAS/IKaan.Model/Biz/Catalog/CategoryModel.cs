using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog
{
	[DataContract]
	public class CategoryModel : ModelBase
	{
		[DataMember]
		[Display(Name = "카테고리명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "상위카테고리ID")]
		public int? ParentID { get; set; }
		
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
		public int SortOrder { get; set; }

		[DataMember]
		[Display(Name = "계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "계층명")]
		public string HierName { get; set; }

		[DataMember]
		[Display(Name = "단계")]
		public int Level { get; set; }

		[DataMember]
		[Display(Name = "카테고리1명")]
		public string Category1Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리2명")]
		public string Category2Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리3명")]
		public string Category3Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리4명")]
		public string Category4Name { get; set; }

		[DataMember]
		[Display(Name = "카테고리5명")]
		public string Category5Name { get; set; }

		[DataMember]
		[Display(Name = "정보고시명")]
		public string InfoNoticeName { get; set; }
	}
}
