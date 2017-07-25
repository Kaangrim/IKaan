using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.LIB.LG
{
	public class LGGoods : ModelBase
	{
		[DataMember]
		[Display(Name = "상품번호")]
		public string GoodsNo { get; set; }

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
		public IList<LGGoodsDetail> GoodsDetail { get; set; }

		[DataMember]
		[Display(Name = "상품이미지")]
		public IList<LGGoodsImage> GoodsImage { get; set; }

		[DataMember]
		[Display(Name = "상품옵션")]
		public IList<LGGoodsItem> GoodsOption { get; set; }

		[DataMember]
		[Display(Name = "상품가격")]
		public IList<LGGoodsPrice> GoodsPrice { get; set; }

		public LGGoods()
		{
			GoodsDetail = new List<LGGoodsDetail>();
			GoodsImage = new List<LGGoodsImage>();
			GoodsOption = new List<LGGoodsItem>();
			GoodsPrice = new List<LGGoodsPrice>();
		}
	}
}
