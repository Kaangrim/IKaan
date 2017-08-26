using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class GroupRoleModel: ModelBase
	{
		[DataMember]
		[Display(Name = "그룹ID")]
		public int? GroupID { get; set; }

		[DataMember]
		[Display(Name = "역할ID")]
		public int? RoleID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "권한그룹명")]
		public string RoleName { get; set; }

		[DataMember]
		[Display(Name = "권한계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "권한계층명")]
		public string HierName { get; set; }

		[DataMember]
		[Display(Name = "권한단계")]
		public int? RoleLevel { get; set; }
	}
}
