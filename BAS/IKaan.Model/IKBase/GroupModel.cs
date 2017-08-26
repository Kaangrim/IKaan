using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class GroupModel: ModelBase
	{
		[DataMember]
		[Display(Name = "그룹명")]
		public string GroupName { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

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
		[Display(Name = "그룹단계")]
		public int? GroupLevel { get; set; }

		[DataMember]
		[Display(Name = "그룹권한")]
		public IList<GroupRoleModel> GroupRole { get; set; }

		[DataMember]
		[Display(Name = "그룹메뉴")]
		public IList<GroupMenuModel> GroupMenu { get; set; }

		public GroupModel()
		{
			GroupRole = new List<GroupRoleModel>();
			GroupMenu = new List<GroupMenuModel>();
		}
	}
}
