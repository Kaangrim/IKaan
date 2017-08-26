using System.Text;
using System.Windows.Forms;

namespace IKaan.Win.Core.Utils
{
	public static class BrowserUtils
	{
		public static void NavigatePost(this WebBrowser wb, string url, string data = null)
		{
			byte[] postData = Encoding.Default.GetBytes(data);
			wb.Navigate(url, null, postData, "Content-Type: application/x-www-form-urlencoded");
		}
	}
}
