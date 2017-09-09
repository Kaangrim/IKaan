using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Common.Base;

namespace IKaan.Model.Base.Common
{
	[DataContract]
	public class CalendarModel : ModelBase
	{
		[DataMember]
		[Display(Name = "일자")]
		public DateTime CalDate { get; set; }

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
		[Display(Name = "월 주차")]
		public int WeekOfMonth { get; set; }

		[DataMember]
		[Display(Name = "연 주차")]
		public int WeekOfYear { get; set; }

		[DataMember]
		[Display(Name = "요일")]
		public string DayOfWeekName { get; set; }

		[DataMember]
		[Display(Name = "휴일여부")]
		public string HolidayYn { get; set; }

		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; }
	}
}
