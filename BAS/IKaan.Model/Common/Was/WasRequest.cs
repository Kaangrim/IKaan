using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Serialization;

namespace IKaan.Model.Common.Was
{
	[DataContract]
	public class WasRequest: IDisposable
	{
		[DataMember]
		public string ServiceId { get; set; }

		[DataMember]
		public string ProcessId { get; set; }

		[DataMember]
		public string DatabaseId { get; set; }

		[DataMember]
		public bool IsTransaction { get; set; }

		[DataMember]
		public string SqlId { get; set; }

		[DataMember]
		public object Parameter { get; set; }

		[DataMember]
		public object Data { get; set; }

		[DataMember]
		public string ModelName { get; set; }

		[DataMember]
		public WasUser User { get; set; }

		[DataMember]
		public WasMaster Master { get; set; }

		[DataMember]
		public WasPaging Paging { get; set; }

		[DataMember]
		public WasResult Result { get; set; }

		[DataMember]
		public WasError Error { get; set; }

		public WasRequest()
		{
			Parameter = null;
			Data = null;
			User = new WasUser();
			Master = new WasMaster();
			Paging = new WasPaging();
			Result = new WasResult();
			Error = new WasError();
		}

		#region IDisposable Support
		private bool disposedValue = false; // 중복 호출을 검색하려면

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					// TODO: 관리되는 상태(관리되는 개체)를 삭제합니다.
					if (Data != null)
					{
						if (Data.GetType() == typeof(DataTable))
						{
							(Data as DataTable).Dispose();
						}
						else if (Data.GetType() == typeof(WasRequest))
						{
							(Data as WasRequest).Dispose();
						}
						else if (Data.GetType() == typeof(List<WasRequest>))
						{
							foreach(WasRequest req in (Data as List<WasRequest>))
							{
								req.Dispose();
							}
						}
						Data = null;
					}
					if (Parameter != null)
						Parameter = null;
				}

				// TODO: 관리되지 않는 리소스(관리되지 않는 개체)를 해제하고 아래의 종료자를 재정의합니다.
				// TODO: 큰 필드를 null로 설정합니다.

				disposedValue = true;
			}
		}

		// TODO: 위의 Dispose(bool disposing)에 관리되지 않는 리소스를 해제하는 코드가 포함되어 있는 경우에만 종료자를 재정의합니다.
		// ~WasData() {
		//   // 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
		//   Dispose(false);
		// }

		// 삭제 가능한 패턴을 올바르게 구현하기 위해 추가된 코드입니다.
		public void Dispose()
		{
			// 이 코드를 변경하지 마세요. 위의 Dispose(bool disposing)에 정리 코드를 입력하세요.
			Dispose(true);
			// TODO: 위의 종료자가 재정의된 경우 다음 코드 줄의 주석 처리를 제거합니다.
			GC.SuppressFinalize(this);
		}
		#endregion

	}
}
