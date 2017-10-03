using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Channel
{
	[DataContract]
	public class ChannelModel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널명")]
		public string Name { get; set; }

		[DataMember]
		[Display(Name = "채널코드")]
		public string Code { get; set; }

		[DataMember]
		[Display(Name = "채널유형")]
		public string ChannelType { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }

		[DataMember]
		[Display(Name = "설명(RTF)")]
		public string DescriptionRTF { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "이미지ID")]
		public int? ImageID { get; set; }

		[DataMember]
		[Display(Name = "채널유형명")]
		public string ChannelTypeName { get; set; }

		[DataMember]
		[Display(Name = "채널속성")]
		public IList<ChannelAttributeModel> Attributes { get; set; }

		[DataMember]
		[Display(Name = "채널브랜드")]
		public IList<ChannelBrandModel> Brands { get; set; }

		[DataMember]
		[Display(Name = "채널설정")]
		public IList<ChannelSettingModel> Settings { get; set; }

		public ChannelModel()
		{
			Attributes = new List<ChannelAttributeModel>();
			Brands = new List<ChannelBrandModel>();
			Settings = new List<ChannelSettingModel>();
		}
	}
}
