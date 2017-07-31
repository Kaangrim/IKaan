namespace IKaan.Biz.Core.Variables
{
	public class ConstsVar
	{
		//Registry
		public const string REGISTRY_ROOT = @"Software\IKaan\Biz";
		public const string REGISTRY_FORM_SIZE = @"Layouts\MainLayout\FormSize";
		public const string REGISTRY_LOOK_AND_FEEL = @"Layouts\LookAndFeel";
		public const string REGISTRY_LOGIN_INFO = @"LoginInfo";
		public const string REGISTRY_FORM_STYLE = @"Layouts\FormStyle";
		public const string REGISTRY_SERVER_CONFIG = @"ServerConfig";
		public const string REGISTRY_CULTURE = @"Culture";
		public const string REGISTRY_DASHBOARD = @"Dashboard";
		public const string REGISTRY_GRID_LAYOUT = @"Layouts\GridLayout";

		//Application
		public const string APP_PATH = @"C:\IKaan";
		public const string APP_CRYPT_KEY = @"IKaan.V2017";
		public const string APP_PASSWORD = "IKaan.V2017";

		public const string URL_LOGIN_IMAGE = @"http://i.istockimg.com/file_thumbview_approve/56523166/6/stock-illustration-56523166-website-project-process-icons.jpg";
		public const string URL_LOGIN_LOGO = @"http://i.istockimg.com/file_thumbview_approve/24804086/5/stock-illustration-24804086-프로젝트-관리-태그-클라우드.jpg";
		public const string URL_HOME_VIEW = @"https://demos.devexpress.com/DashboardSamples/FullScreenSamples/SalesPerformance.aspx";
		public const string URL_WAIT_IMAGE = @"http://cfile10.uf.tistory.com/image/277BCD37569F57861C14C1";

		//Server
		public const string SERVER_MODE = "LOCAL";       //"WAS";
		public const string SERVER_REAL = @"http://localhost:58647/";
		public const string SERVER_TEST = @"http://localhost:58647/";
		public const string SERVER_DEBUG = @"http://localhost:58647/";

		//Skin
		public const string USER_FONT_NAME = "맑은 고딕";
		public const float USER_FONT_SIZE = 9f;
		public const bool USER_USE_SKIN = true;
		public const string USER_MAIN_SKIN = @"Office 2016 Colorful";       //@"Office 2016 Dark";
		public const string USER_FORM_SKIN = @"Office 2016 Dark";       //DevExpress Style
		public const string USER_FORM_SUB_SKIN = @"Office 2016 Colorful";
		public const string USER_GRID_SKIN = @"Office 2016 Colorful";
		public const bool USER_GRID_EVEN_AND_ODD = true;

		//Dictionary Case
		public const string DICTIONARY_CASE = "PascalCase"; //PascalCase, CamelCase, UpperCase

		//Image Server
		public const string IMG_FTP_URL = @"kaangrim.whoisimg.com";
		public const string IMG_FTP_ID = "kaangrim";
		public const string IMG_FTP_PW = "kaangrim0528";

		public const string DOC_URL = @"http://kaangrim.whoisimg.com";
		public const string DOC_URL_ROOT = @"/Documents";

		public const string IMG_URL = @"http://kaangrim.whoisimg.com";
		public const string IMG_URL_ROOT = @"/Images";

		public const string IMG_URL_BRAND = @"/Images/Brand";
		public const string IMG_URL_GOODS = @"/Images/Goods";
		public const string IMG_URL_SEARCH_BRAND = @"/Images/SearchBrand";
		public const string IMG_URL_PERSON = @"/Images/Person";

		public const string FILE_DEFINE_BRAND_LOGO = "{0}_LOGO";	//{0} : 브랜드ID
		public const string FILE_DEFINE_BRAND_MAIN = "{0}_MAIN";
		public const string FILE_DEFINE_PERSON = "PERSON_{0}";
	}
}
