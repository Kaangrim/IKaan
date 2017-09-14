using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Scrap.Smaps
{
	[DataContract]
	public class SmapsColorModel : ModelBase
	{
		[DataMember]
		[Display(Name = "요청ID")]
		public int? RequestID { get; set; }

		[DataMember]
		[Display(Name = "색상값")]
		public string value { get; set; }

		[DataMember]
		[Display(Name = "색상명")]
		public string text { get; set; }
	}
}
