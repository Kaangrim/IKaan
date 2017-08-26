using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.IKBiz
{
	[DataContract]
	public class GoodsDetailModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "상세설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "상세설명(RTF)")]
		public string DescriptionRTF { get; set; }
	}
}
