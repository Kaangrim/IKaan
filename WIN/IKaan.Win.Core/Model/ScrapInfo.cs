using IKaan.Win.Core.Variables;

namespace IKaan.Win.Core.Model
{
	public class ScrapInfo
	{
		public string ProductFilePath { get; set; }

		public ScrapInfo()
		{
			ProductFilePath = ConstsVar.APP_PATH_PRODUCT;
		}
	}
}