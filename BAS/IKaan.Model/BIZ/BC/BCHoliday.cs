using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using IKaan.Model.Base;

namespace IKaan.Model.BIZ.BC
{
	[DataContract]
	public class BCHoliday : ModelBase
	{
		[DataMember]
		[Display(Name = "휴일일자")]
		public string HolidayDate { get; set; }

		[DataMember]
		[Display(Name = "휴일명")]
		public string HolidayName { get; set; }


		[DataMember]
		[Display(Name = "설명")]
		public string Description { get; set; } 
	}
}
