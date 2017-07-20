using System;
using IKaan.Base.Map;
using IKaan.Base.Utils;
using IKaan.Biz.Core.Was.Handler;
using IKaan.Model.BIZ.BM;

namespace IKaan.Biz.Core.Utils
{
	public static class CommonRequest
	{
		public static int SaveAddress(DataMap map)
		{
			try
			{
				//using (var res = WasHandler.Execute<BMAddress>("Base", "Save", "Address", map, "ID"))
				//{
				//	if (res.Error.Number != 0)
				//		throw new Exception(res.Error.Message);

				//	if (res.Result.ReturnValue == null)
				//		throw new Exception("반환값이 정확하지 않습니다.");

				//	return res.Result.ReturnValue.ToIntegerNullToZero();
				//}
				return 0;
			}
			catch
			{
				throw;
			}
		}
	}
}
