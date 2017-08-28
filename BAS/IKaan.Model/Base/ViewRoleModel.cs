using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base
{
	[DataContract]
	public class ViewRoleModel: ModelBase
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
