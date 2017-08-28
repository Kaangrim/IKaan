using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz
{
	[DataContract]
	public class ChannelModel : ModelBase
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
		public IList<ChannelBrandModel> Brands { get; set; }

		[DataMember]
		[Display(Name = "채널, 거래처")]
		public IList<CustomerChannelModel> Customers { get; set; }

		[DataMember]
		[Display(Name = "채널, 담당자")]
		public IList<ChannelContactModel> Contacts { get; set; }

		[DataMember]
		[Display(Name = "채널, 관리자")]
		public IList<ChannelManagerModel> Managers { get; set; }

		public ChannelModel()
		{
			Brands = new List<ChannelBrandModel>();
			Customers = new List<CustomerChannelModel>();
			Contacts = new List<ChannelContactModel>();
			Managers = new List<ChannelManagerModel>();
		}
	}
}
