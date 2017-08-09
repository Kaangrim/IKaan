using System;
using System.Runtime.Serialization;

namespace IKaan.Model.Was
{
	[DataContract]
	public class WasResult
	{
		[DataMember]
		public int Count { get; set; }

		[DataMember]
		public object ReturnValue { get; set; }

		[DataMember]
		public string ReturnMessage { get; set; }

		[DataMember]
		public DateTime? StartTime { get; set; }

		[DataMember]
		public DateTime? EndTime { get; set; }

		public WasResult()
		{
			Count = 0;
			ReturnValue = null;
		}
	}
}
