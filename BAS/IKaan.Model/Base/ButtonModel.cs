using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base
{
	[DataContract]
	public class ButtonModel: ModelBase
	{
		[DataMember]
		[Display(Name = "버튼명")]
		public string ButtonName { get; set; }

		[DataMember]
		[Display(Name = "버튼형태")]
		public string ButtonType { get; set; }

		[DataMember]
		[Display(Name = "오브젝트명")]
		public string Instance { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "버튼형태명")]
		public string ButtonTypeName { get; set; }
	}
}
