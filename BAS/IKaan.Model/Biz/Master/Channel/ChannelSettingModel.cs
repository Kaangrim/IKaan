using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Biz.Master.Channel
{
	[DataContract]
	public class ChannelSettingModel : ModelBase
	{
		[DataMember]
		[Display(Name = "채널ID")]
		public int? ChannelID { get; set; }

		[DataMember]
		[Display(Name = "설정코드")]
		public string SettingCode { get; set; }

		[DataMember]
		[Display(Name = "설정값")]
		public string SettingValue { get; set; }

		[DataMember]
		[Display(Name = "설정명")]
		public string SettingName { get; set; }
	}
}
