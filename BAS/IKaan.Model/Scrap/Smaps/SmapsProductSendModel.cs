using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsProductSendModel
	{
		[DataMember]
		[Display(Name = "대행사UID")]
		public int? agency_uid { get; set; }

		[DataMember]
		[Display(Name = "브랜드UID")]
		public int? brand_uid { get; set; }

		[DataMember]
		[Display(Name = "룩북UID")]
		public int? lookbook_uid { get; set; }

		[DataMember]
		[Display(Name = "상품명")]
		public string product_name { get; set; }

		[DataMember]
		[Display(Name = "상품번호")]
		public string product_number { get; set; }

		[DataMember]
		[Display(Name = "가격")]
		public decimal product_price { get; set; }

		[DataMember]
		[Display(Name = "단품가격여부")]
		public string product_unset_price { get; set; }

		[DataMember]
		[Display(Name = "카테고리UID")]
		public int? category_uid { get; set; }

		[DataMember]
		[Display(Name = "성별")]
		public string sex { get; set; }

		[DataMember]
		[Display(Name = "메모")]
		public string memo { get; set; }

		[DataMember]
		[Display(Name = "주의사항")]
		public string caution { get; set; }

		[DataMember]
		[Display(Name = "태그")]
		public string tag { get; set; }

		[DataMember]
		[Display(Name = "옵션수")]
		public int option { get; set; }

		[DataMember]
		[Display(Name = "사이즈UID")]
		public List<int> option_size_uid { get; set; }

		[DataMember]
		[Display(Name = "사이즈명")]
		public List<string> option_size_view { get; set; }

		[DataMember]
		[Display(Name = "색상값")]
		public List<string> option_color { get; set; }

		[DataMember]
		[Display(Name = "색상명")]
		public List<string> option_color_view { get; set; }

		[DataMember]
		[Display(Name = "입고일")]
		public List<DateTime> option_add_date { get; set; }

		[DataMember]
		[Display(Name = "이미지경로")]
		public List<string> image { get; set; }

		[DataMember]
		[Display(Name = "이미지넓이")]
		public List<int> image_width { get; set; }

		[DataMember]
		[Display(Name = "이미지높이")]
		public List<int> image_height { get; set; }

		[DataMember]
		[Display(Name = "썸네일구분")]
		public List<string> is_thumbnail { get; set; }

		[DataMember]
		[Display(Name = "메인이미지여부")]
		public List<string> is_main { get; set; }
	}
}
