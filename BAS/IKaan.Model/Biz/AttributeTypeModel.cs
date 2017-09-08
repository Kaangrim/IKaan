using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class AttributeTypeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "속성명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
