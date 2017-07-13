using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.SYS.AC
{
	[DataContract]
	public class ACCalendar : ModelBase
	{
		[DataMember]
		[Display(Name = "일자")]
		public string CalDate { get; set; }

		[DataMember]
		[Display(Name = "연")]
		public int CalYear { get; set; }

		[DataMember]
		[Display(Name = "월")]
		public int CalMonth { get; set; }

		[DataMember]
		[Display(Name = "일")]
		public int CalDay { get; set; }

		[DataMember]
		[Display(Name = "분기")]
		public int Quarter { get; set; }

		[DataMember]
		[Display(Name = "요일")]
		public int DayOfWeek { get; set; }

		[DataMember]
		[Display(Name = "연간 일수")]
		public int DayOfYear { get; set; }

		[DataMember]
		[Display(Name = "연간 주차")]
		public int WeekOfYear { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
