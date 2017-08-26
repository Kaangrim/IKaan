using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBase
{
	[DataContract]
	public class ViewModel : ModelBase
	{
		[DataMember]
		[Display(Name = "화면명")]
		public string ViewName { get; set; }

		[DataMember]
		[Display(Name = "화면유형")]
		public string ViewType { get; set; }

		[DataMember]
		[Display(Name = "상위ID")]
		public int? ParentID { get; set; }

		[DataMember]
		[Display(Name = "모듈ID")]
		public int? ModuleID { get; set; }

		[DataMember]
		[Display(Name = "네임스페이스")]
		public string Namespace { get; set; }

		[DataMember]
		[Display(Name = "인스턴스")]
		public string Instance { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "도움말ID")]
		public int? HelpID { get; set; }

		[DataMember]
		[Display(Name = "화면형태명")]
		public string ViewTypeName { get; set; }

		[DataMember]
		[Display(Name = "모듈명")]
		public string ModuleName { get; set; }

		[DataMember]
		[Display(Name = "도움말명")]
		public string HelpName { get; set; }

		[DataMember]
		[Display(Name = "화면버튼")]
		public IList<ViewButtonModel> ViewButton { get; set; }

		public ViewModel()
		{
			ViewButton = new List<ViewButtonModel>();
		}
	}
}
