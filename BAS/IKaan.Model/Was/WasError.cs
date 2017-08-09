using System.Runtime.Serialization;

namespace IKaan.Model.Was
{
	[DataContract]
	public class WasError
	{
		[DataMember]
		public int Number { get; set; }

		[DataMember]
		public string Message { get; set; }

		public WasError()
		{
			Number = 0;
			Message = "SUCCESS";
		}
	}
}
