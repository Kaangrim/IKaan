using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class GoodsAttributeModel : ModelBase
	{
		[DataMember]
		[Display(Name = "상품ID")]
		public int? GoodsID { get; set; }

		[DataMember]
		[Display(Name = "속성분류")]
		public string AttrType { get; set; }

		[DataMember]
		[Display(Name = "속성코드")]
		public string AttrCode { get; set; }

		[DataMember]
		[Display(Name = "속성명")]
		public string AttrName { get; set; }
	}
}
