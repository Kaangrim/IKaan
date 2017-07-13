using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AABookmark: ModelBase
	{
		[DataMember]
		[Display(Name = "사용자ID")]
		public int UserID { get; set; }

		[DataMember]
		[Display(Name = "메뉴ID")]
		public int MenuID { get; set; }

		[DataMember]
		[Display(Name = "정렬순서")]
		public int SortOrder { get; set; }

		[DataMember]
		[Display(Name = "메뉴명")]
		public string MenuName { get; set; }
	}
}
