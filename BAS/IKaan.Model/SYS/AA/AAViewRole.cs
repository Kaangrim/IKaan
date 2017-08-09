using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAViewRole: ModelBase
	{
		[DataMember]
		[Display(Name = "뷰ID")]
		public int ViewID { get; set; }

		[DataMember]
		[Display(Name = "역할ID")]
		public int RoleID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }
	}
}
