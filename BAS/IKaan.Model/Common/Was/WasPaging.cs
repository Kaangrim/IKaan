using System.Runtime.Serialization;

namespace IKaan.Model.Common.Was
{
	[DataContract]
	public class WasPaging
	{
		[DataMember]
		public int PageNo { get; set; }

		[DataMember]
		public int PageSize { get; set; }

		[DataMember]
		public int TotalPages { get; set; }

		[DataMember]
		public int TotalRecords { get; set; }

		public WasPaging()
		{
			PageNo = 0;
			PageSize = 0;
			TotalPages = 0;
			TotalRecords = 0;
		}
	}
}
