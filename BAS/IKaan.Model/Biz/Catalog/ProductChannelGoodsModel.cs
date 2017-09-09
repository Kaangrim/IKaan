using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Catalog
{
	[DataContract]
	public class ProductChannelGoodsModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? ProductID { get; set; }

		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "채널상품ID")]
		public int? ChannelGoodsID { get; set; }
	}
}
