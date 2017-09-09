using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Authority
{
	[DataContract]
	public class UserRoleModel: ModelBase
	{
		[DataMember]
		[Display(Name = "사용자ID")]
		public int? UserID { get; set; }

		[DataMember]
		[Display(Name = "권한그룹ID")]
		public int? RoleID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "권한그룹명")]
		public string RoleName { get; set; }

		[DataMember]
		[Display(Name = "계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "권한그룹단계")]
		public int? RoleLevel { get; set; }
	}
}
