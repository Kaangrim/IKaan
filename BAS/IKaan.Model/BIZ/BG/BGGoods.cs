using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BG
{
	[DataContract]
	public class BGGoods : ModelBase
	{
		[DataMember]
		[Display(Name = "스타일번호")]
		public string StyleNo { get; set; }

		[DataMember]
		[Display(Name = "브랜드ID")]
		public string BrandID { get; set; }

		[DataMember]
		[Display(Name = "연령")]
		public string Age { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string Gender { get; set; }

		[DataMember]
		[Display(Name = "출시년도")]
		public string ReleaseYear { get; set; }

		[DataMember]
		[Display(Name = "시즌")]
		public string Season { get; set; }

		[DataMember]
		[Display(Name = "원산지")]
		public string Origin { get; set; }

		[DataMember]
		[Display(Name = "카테고리ID")]
		public string CategoryID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "해외배송여부")]
		public string AbroadYn { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string GoodsName { get; set; }

		[DataMember]
		[Display(Name = "상세설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "브랜드명")]
		public string BrandName { get; set; }

		[DataMember]
		[Display(Name = "상품상세")]
		public IList<BGGoodsDetail> GoodsDetail { get; set; }

		[DataMember]
		[Display(Name = "상품이미지")]
		public IList<BGGoodsImage> GoodsImage { get; set; }

		[DataMember]
		[Display(Name = "상품옵션")]
		public IList<BGGoodsItem> GoodsOption { get; set; }

		[DataMember]
		[Display(Name = "상품가격")]
		public IList<BGGoodsPrice> GoodsPrice { get; set; }

		public BGGoods()
		{
			GoodsDetail = new List<BGGoodsDetail>();
			GoodsImage = new List<BGGoodsImage>();
			GoodsOption = new List<BGGoodsItem>();
			GoodsPrice = new List<BGGoodsPrice>();
		}
	}
}
