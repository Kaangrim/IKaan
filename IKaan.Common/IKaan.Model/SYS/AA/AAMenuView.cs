using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAMenuView : ModelBase
	{
		[DataMember]
		[Display(Name = "메뉴ID")]
		public int? MenuID { get; set; }

		[DataMember]
		[Display(Name = "뷰ID")]
		public int? ViewID { get; set; }

		[DataMember]
		[Display(Name = "파라미터")]
		public string Parameter { get; set; }
	}
}
