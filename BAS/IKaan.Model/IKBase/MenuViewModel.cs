using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class MenuViewModel : ModelBase
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
