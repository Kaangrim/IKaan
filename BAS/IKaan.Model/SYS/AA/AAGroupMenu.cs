using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAGroupMenu: ModelBase
	{
		[DataMember]
		[Display(Name = "그룹ID")]
		public int? GroupID { get; set; }

		[DataMember]
		[Display(Name = "메뉴ID")]
		public int? MenuID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "메뉴명")]
		public string MenuName { get; set; }

		[DataMember]
		[Display(Name = "메뉴계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "메뉴계층명")]
		public string HierName { get; set; }

		[DataMember]
		[Display(Name = "메뉴단계")]
		public int? MenuLevel { get; set; }
	}
}
