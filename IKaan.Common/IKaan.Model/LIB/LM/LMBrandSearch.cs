using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LM
{
	public class LMBrandSearch : ModelBase
	{
		[DataMember]
		[Display(Name = "브랜드명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "채널적합도")]
		public string ChannelFitness { get; set; }

		[DataMember]
		[Display(Name = "홈페이지")]
		public string HomePage { get; set; }

		[DataMember]
		[Display(Name = "Style Or SKU")]
		public string StyleOrSku { get; set; }

		[DataMember]
		[Display(Name = "이메일")]
		public string Email { get; set; }

		[DataMember]
		[Display(Name = "연락처")]
		public string Phone { get; set; }

		[DataMember]
		[Display(Name = "주요제품")]
		public string MainGoods { get; set; }

		[DataMember]
		[Display(Name = "카테고리")]
		public string Category { get; set; }

		[DataMember]
		[Display(Name = "스타일")]
		public string Style { get; set; }

		[DataMember]
		[Display(Name = "가격대")]
		public string Price { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "카테고리분류")]
		public string TopCategory { get; set; }

		[DataMember]
		[Display(Name = "이미지")]
		public string GoodsImageUrl { get; set; }
	}
}
