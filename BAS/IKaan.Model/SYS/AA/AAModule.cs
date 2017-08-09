using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AA
{
	[DataContract]
	public class AAModule : ModelBase
	{
		[DataMember]
		[Display(Name = "모듈명")]
		public string ModuleName { get; set; }

		[DataMember]
		[Display(Name = "어셈블리")]
		public string Assembly { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		[StringLength(1)]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
