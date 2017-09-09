using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog
{
	[DataContract]
	public class ProductDescriptionModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? ProductID { get; set; }

		[DataMember]
		[Display(Name = "상세설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상세설명(RTF)")]
		public string DescriptionRTF { get; set; }
	}
}
