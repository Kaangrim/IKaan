using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class GoodsItemModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "옵션1유형")]
		public string Option1Type { get; set; }

		[DataMember]
		[Display(Name = "옵션1명")]
		public string Option1Name { get; set; }

		[DataMember]
		[Display(Name = "옵션2유형")]
		public string Option2Type{ get; set; }

		[DataMember]
		[Display(Name = "옵션2명")]
		public string Option2Name { get; set; }
	}
}
