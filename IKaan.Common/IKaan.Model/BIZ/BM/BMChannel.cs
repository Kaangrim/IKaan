using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BM
{
	[DataContract]
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
		public IList<BMChannelBrand> Brands { get; set; }

		[DataMember]
		[Display(Name = "채널, 거래처")]
		public IList<BMCustomerChannel> Customers { get; set; }

		[DataMember]
		[Display(Name = "채널, 담당자")]
		public IList<BMChannelContact> Contacts { get; set; }

		[DataMember]
		[Display(Name = "채널, 관리자")]
		public IList<BMChannelManager> Managers { get; set; }

		public BMChannel()
		{
			Brands = new List<BMChannelBrand>();
			Customers = new List<BMCustomerChannel>();
			Contacts = new List<BMChannelContact>();
			Managers = new List<BMChannelManager>();
		}
	}
}
