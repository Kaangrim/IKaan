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
		[Display(Name = "주문일자여부")]
		public string OrderDateYn { get; set; }

		[DataMember]
		[Display(Name = "주문연도추가여부")]
		public string OrderAddYearYn { get; set; }

		[DataMember]
		[Display(Name = "주문번호자릿수")]
		public int OrderNoDigit { get; set; }

		[DataMember]
		[Display(Name = "옵션여부")]
		public string OptionYn { get; set; }

		[DataMember]
		[Display(Name = "옵션포맷")]
		public string OptionFormat { get; set; }

		[DataMember]
		[Display(Name = "주문데이터 시작라인")]
		public int OrderLine { get; set; }

		[DataMember]
		[Display(Name = "정산데이터 시작라인")]
		public int AccountLine { get; set; }
	}
}
