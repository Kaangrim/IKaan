using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	public class BMChannel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널명")]
		public string ChannelName { get; set; }

		[DataMember]
		[Display(Name = "영문명")]
		public string EngName { get; set; }

		[DataMember]
		[Display(Name = "채널코드")]
		public string ChannelCode { get; set; }

		[DataMember]
		[Display(Name = "채널유형")]
		public string ChannelType { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "채널유형명")]
		public string ChannelTypeName { get; set; }

		[DataMember]
		[Display(Name = "채널, 브랜드")]
		public IList<BMChannelBrand> ChannelBrand { get; set; }

		[DataMember]
		[Display(Name = "채널, 거래처")]
		public IList<BMCustomerChannel> ChannelCustomer { get; set; }

		public BMChannel()
		{
			ChannelBrand = new List<BMChannelBrand>();
			ChannelCustomer = new List<BMCustomerChannel>();
		}
	}
}
