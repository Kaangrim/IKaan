using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog.Category
{
	[DataContract]
	public class CategoryItemModel : ModelBase
	{
		[DataMember]
		[Display(Name = "카테고리명")]
		public string Name { get; set; }
		
		[DataMember]
		[Display(Name = "카테고리유형")]
		public string CategoryType { get; set; }

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
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "카테고리유형명")]
		public string CategoryTypeName { get; set; }

		[DataMember]
		[Display(Name = "정보고시명")]
		public string InfoNoticeName { get; set; }

		[DataMember]
		[Display(Name = "상위카테고리명")]
		public string ParentName { get; set; }
	}
}
