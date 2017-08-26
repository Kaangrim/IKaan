using System.Runtime.Serialization;

namespace IKaan.Model.Common.Was
{
	[DataContract]
	public class WasMaster
	{
		[DataMember]
		public bool IsMaster { get; set; }

		[DataMember]
		public string KeyField { get; set; }

		public WasMaster()
		{
			IsMaster = false;
		}
	}
}
