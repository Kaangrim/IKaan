using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class UserGroupModel: ModelBase
	{
		[DataMember]
		[Display(Name = "사용자ID")]
		public int? UserID { get; set; }

		[DataMember]
		[Display(Name = "그룹ID")]
		public int? GroupID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "그룹명")]
		public string GroupName { get; set; }

		[DataMember]
		[Display(Name = "계층ID")]
		public string HierID { get; set; }

		[DataMember]
		[Display(Name = "그룹단계")]
		public int? GroupLevel { get; set; }
	}
}
