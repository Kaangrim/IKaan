using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base
{
	[DataContract]
	public class MenuModel : ModelBase
	{
		[DataMember]
		[Display(Name = "메뉴명")]
		public string MenuName { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "메뉴유형")]
		public string MenuType { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public int SortOrder { get; set; }

		[DataMember]
		[Display(Name = "메뉴경로")]
		public string MenuPath { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "계층명")]
		public string HierName { get; set; }

		[DataMember]
		[Display(Name = "메뉴단계")]
		public int? MenuLevel { get; set; }

		[DataMember]
		[Display(Name = "화면ID")]
		public int? ViewID { get; set; }

		[DataMember]
		[Display(Name = "파라미터")]
		public string Parameter { get; set; }

		[DataMember]
		[Display(Name = "메뉴화면")]
		public IList<MenuViewModel> MenuView { get; set; }
	}
}
