using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Common
{
	[DataContract]
	public class ScrapOptionModel : ModelBase
	{
		[DataMember]
		[Display(Name = "옵션명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "옵션1유형")]
		public string Option1Type { get; set; }

		[DataMember]
		[Display(Name = "옵션1명")]
		public string Option1Name { get; set; }

		[DataMember]
		[Display(Name = "옵션1값")]
		public string Option1Value { get; set; }

		[DataMember]
		[Display(Name = "옵션2유형")]
		public string Option2Type { get; set; }

		[DataMember]
		[Display(Name = "옵션2명")]
		public string Option2Name { get; set; }

		[DataMember]
		[Display(Name = "옵션2값")]
		public string Option2Value { get; set; }
	}
}
