using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Authority
{
	[DataContract]
	public class ViewButtonModel: ModelBase
	{
		[DataMember]
		[Display(Name = "화면ID")]
		public int? ViewID { get; set; }

		[DataMember]
		[Display(Name = "버튼ID")]
		public int? ButtonID { get; set; }

		[DataMember]
		[Display(Name = "사용여부")]
		public string UseYn { get; set; }

		[DataMember]
		[Display(Name = "연결화면ID")]
		public int? LinkViewID { get; set; }

		[DataMember]
		[Display(Name = "화면명")]
		public string ViewName { get; set; }

		[DataMember]
		[Display(Name = "버튼명")]
		public string ButtonName { get; set; }

		[DataMember]
		[Display(Name = "연결화면명")]
		public string LinkViewName { get; set; }

		[DataMember]
		[Display(Name = "연결화면코드")]
		public string LinkViewCode { get; set; }

		[DataMember]
		[Display(Name = "버튼형태명")]
		public string ButtonTypeName { get; set; }
	}
}
