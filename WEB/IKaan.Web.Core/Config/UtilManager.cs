using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.Routing;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Security;
using System.Security.Principal;
using System.Security.Cryptography;
using Newtonsoft.Json;
using IKaan.Web.Core.Config;

public static class UtilManager
{
    public static string JsonToString(object model)
    {
        string json = JsonConvert.SerializeObject(model);
        return json;
    }

    public static string EncodeText(string textToEncode)
    {
        UTF8Encoding utf8 = new UTF8Encoding();
        Byte[] encodeBytes = utf8.GetBytes(textToEncode);
        string tempStr = string.Empty;

        foreach (Byte b in encodeBytes)
        {
            tempStr += "%" + string.Format("{0:X}", b);
        }

        return tempStr;

    }



    public static string IsNull(string obj, string replaceStr)
    {
        string sRtnVal = "";

        if (obj == null)
        {
            sRtnVal = replaceStr;
        }
        else
        {
            sRtnVal = obj;
        }

        return sRtnVal;
    }

    public static string ReplaceScript(string pContent)
    {

        string sRtnVal = "";


        Regex regEx = new Regex("<(no)?script.*?script>", RegexOptions.Singleline);
        sRtnVal = regEx.Replace(pContent, "");

        regEx = new Regex(@"</?form[^>]*>", RegexOptions.IgnoreCase);
        sRtnVal = regEx.Replace(sRtnVal, "");

        regEx = new Regex(@"</?iframe[^>]*>", RegexOptions.IgnoreCase);
        sRtnVal = regEx.Replace(sRtnVal, "");


        return sRtnVal;

    }

    public static string ReplaceHtml(string pContent)
    {
        string sRtnVal = "";


        Regex regEx = new Regex("<[^>]*>", RegexOptions.IgnoreCase);
        sRtnVal = regEx.Replace(pContent, "");

        return sRtnVal;
    }

    public static string TextToHtml(string text)
    {
        string strReturn = text
            .Replace("&amp", "&")
            .Replace("&lt;", "<")
            .Replace("&gt;", ">")
            .Replace("\n", "<br />")
            .Replace("\r\n", "<br />")
            .Replace("&nbsp;&nbsp;&nbsp;", "\t");

        return strReturn;
    }



    public static string GetStringByByte(string pStr, int nLen)
    {
        int nCurLen, nMusLen; //현재문자열길이, 잘라낼 문자열길이 

        string strRtn = "";

        // Server.HtmlDecode : 부정확한 기호로 인코드 됬던 문자를 태그로 변환시킴( 예.  "&lt"  =>  "<" ) 
        string strCont = Regex.Replace(HttpContext.Current.Server.HtmlDecode(pStr), "<[^>]*>", " ");

        nCurLen = Regex.Replace(strCont, "[ㄱ-힝]", "**").Length;

        if (nCurLen > nLen)
        {
            nMusLen = 0;

            for (int i = 0; i < strCont.Trim().Length; i++)
            {
                if (nMusLen >= nLen)
                    break;

                if (Regex.Replace(strCont.Trim().Substring(i, 1), "[ㄱ-힝]", "**").Length == 2)
                    nMusLen += 2;
                else
                    nMusLen += 1;

                strRtn = strCont.Trim().Substring(0, i);
            }

            strRtn = strRtn + "...";
        }
        else
        {
            strRtn = strCont.Trim();
        }

        return strRtn;

    }

    public static int GetStringByByte(string pStr)
    {
        int nCurLen, nMusLen; //현재문자열길이, 잘라낼 문자열길이 

        // Server.HtmlDecode : 부정확한 기호로 인코드 됬던 문자를 태그로 변환시킴( 예.  "&lt"  =>  "<" ) 
        string strCont = Regex.Replace(HttpContext.Current.Server.HtmlDecode(pStr), "<[^>]*>", " ");

        nCurLen = Regex.Replace(strCont, "[ㄱ-힝]", "**").Length;
        nMusLen = 0;

        for (int i = 0; i < strCont.Trim().Length; i++)
        {
            if (Regex.Replace(strCont.Trim().Substring(i, 1), "[ㄱ-힝]", "**").Length == 2)
                nMusLen += 2;
            else
                nMusLen += 1;
        }

        return nMusLen;

    }

    /// <summary>
    /// 패턴 매칭 되는 문자열 변환
    /// </summary>
    /// <param name="strOrgValue"></param>
    /// <param name="strNewValue"></param>
    /// <param name="pattern"></param>		
    /// <returns></returns>
    public static string ReplacePatternString(string strOrgValue, string strNewValue, string pattern)
    {

        string strRtnValue = strOrgValue;

        Regex objExTest = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection mc = objExTest.Matches(strOrgValue);


        if (mc.Count > 0)
        {
            foreach (Match m in mc)
            {
                strRtnValue = strRtnValue.Replace(m.Value, strNewValue);
            }
        }

        return strRtnValue;

    }


    public static string ReplacePatternToBoldColor(string strOrgValue, string strColor, string pattern)
    {

        string strRtnValue = strOrgValue;

        Regex objExTest = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection mc = objExTest.Matches(strOrgValue);


        if (mc.Count > 0)
        {
            foreach (Match m in mc)
            {
                strRtnValue = strRtnValue.Replace(m.Value, "<b style='color:" + strColor + "'>" + m.Value + "</b>");
            }
        }

        return strRtnValue;

    }


    public static string GetImageStringByPattern(string pContent, string width, string height, string style = "margin-right:10px;margin-bottom:10px")
    {

        string strRtnValue = "";

        string sPettern = "<img [^<>]*>"; // 이미지태그
                                          //string sPettern = "[^=']*\\.(gif|jpg|bmp)"; // 이미지경로와 이미지명
                                          //string sPettern = "[^= '/]*\\.(gif|jpg|png)"; // 이미지명만 가져오기


        Regex objExTest = new Regex(sPettern, RegexOptions.IgnoreCase);
        MatchCollection mc = objExTest.Matches(pContent);


        if (mc.Count > 0)
        {
            strRtnValue = mc[0].Value;

        }

        Regex regEx = new Regex("<img", RegexOptions.IgnoreCase);
        strRtnValue = regEx.Replace(strRtnValue, string.Format("<img style='{2}' {0} {1} ", width == "" ? "" : "width='" + width + "'", height == "" ? "" : "height='" + height + "'", style));

        return strRtnValue;

    }
    public static string GetImageBaseStringByPattern(string pContent, string width, string height)
    {

        string strRtnValue = "";

        string sPettern = "<img [^<>]*>"; // 이미지태그
                                          //string sPettern = "[^=']*\\.(gif|jpg|bmp)"; // 이미지경로와 이미지명
                                          //string sPettern = "[^= '/]*\\.(gif|jpg|png)"; // 이미지명만 가져오기


        Regex objExTest = new Regex(sPettern, RegexOptions.IgnoreCase);
        MatchCollection mc = objExTest.Matches(pContent);


        if (mc.Count > 0)
        {
            strRtnValue = mc[0].Value;

        }

        Regex regEx = new Regex("<img", RegexOptions.IgnoreCase);
        strRtnValue = regEx.Replace(strRtnValue, string.Format("<img style='{0} {1}'  ", width == "" ? "" : "width='" + width + "'", height == "" ? "" : "height='" + height + "'"));

        return strRtnValue;

    }


    /// <summary>
    /// 이미지 src경로만 추출
    /// </summary>
    /// <param name="pContent"></param>
    /// <param name="pRoot"></param>
    /// <returns></returns>
    public static string GetImageSrc(string pContent, string pRoot)
    {

        string strRtnValue = "";
        string sSrc = "";

        string sPettern = "<img[^>]*src=[\"']?([^>\"']+)[\"']?[^>]*>"; // 이미지태그
                                                                       //string sPettern = "[^=']*\\.(gif|jpg|bmp)"; // 이미지경로와 이미지명
                                                                       //string sPettern = "[^= '/]*\\.(gif|jpg|png)"; // 이미지명만 가져오기


        Regex objExTest = new Regex(sPettern, RegexOptions.IgnoreCase);
        MatchCollection mc = objExTest.Matches(pContent);


        if (mc.Count > 0)
        {
            strRtnValue = mc[0].Value;
            objExTest = new Regex("/" + pRoot + "/[\"']?([^>\"']+)(.gif|.jpg|.png|.jpeg)", RegexOptions.IgnoreCase);

            MatchCollection mc2 = objExTest.Matches(strRtnValue);

            if (mc2.Count > 0)
            {
                sSrc = mc2[0].Value;

            }

        }


        return sSrc;

    }

    public static string GetImageInContent(string content)
    {
        return Regex.Match(content, "<img.+?src=[\"'](.+?)[\"'].*?>", RegexOptions.IgnoreCase).Groups[1].Value;
    }

    /// <summary>
    /// 파일 사이즈 문자열로
    /// </summary>
    /// <param name="pLength"></param>
    /// <returns></returns>
    public static string GetFileSizeString(long pLength)
    {

        string sRtnValue = "";

        try
        {


            long lUseSize = pLength;

            string sByte = "";


            if (pLength < 1024)
            {
                sByte = "Byte";
            }
            else if (pLength >= 1024 && pLength < 1048576)
            {
                lUseSize = pLength / 1024;
                sByte = "KB";
            }
            else if (pLength >= 1048576)
            {
                lUseSize = pLength / 1024 / 1024;
                sByte = "MB";
            }
            else
            {
                lUseSize = 0;
                sByte = "Byte";
            }

            sRtnValue = lUseSize.ToString() + " " + sByte;  //사용량




        }
        catch
        {

        }

        return sRtnValue;


    }

    public static string GetFileExtension(string fileName)
    {

        string[] arrFile = fileName.Split('.');
        string fileExt = arrFile.Length > 1 ? arrFile[arrFile.Length - 1] : "";

        return fileExt;
    }


    public static bool DeleteFile(string fileSavePathKey, string fileName, string userId)
    {
        bool result = false;

        try
        {
            var downPath = ConfigurationManager.AppSettings[fileSavePathKey].Replace("{userid}", userId) + "\\" + fileName;

            var file = new FileInfo(downPath);

            if (file.Exists)
            {
                file.Delete();
                result = true;
            }
        }
        catch
        {
            result = false;
        }

        return result;
    }

    public static string GetIconByExtension(string ext)
    {
        string sExtImg = "icon_none.jpg";

        ext = ext.ToLower();

        if (ext == ".xls" || ext == ".xlsx")
            sExtImg = "icon_xls.jpg";
        else if (ext == ".ppt" || ext == ".pptx")
            sExtImg = "icon_ppt.jpg";
        else if (ext == ".doc" || ext == ".docx")
            sExtImg = "icon_doc.jpg";
        else if (ext == ".jpg" || ext == ".jpeg")
            sExtImg = "icon_jpg.jpg";
        else if (ext == ".gif")
            sExtImg = "icon_gif.jpg";
        else if (ext == ".png")
            sExtImg = "icon_png.jpg";
        else if (ext == ".pdf")
            sExtImg = "icon_pdf.jpg";
        else if (ext == ".zip")
            sExtImg = "icon_zip.jpg";
        else if (ext == ".hwp")
            sExtImg = "icon_hwp.jpg";
        else if (ext == ".txt")
            sExtImg = "icon_txt.jpg";

        return sExtImg;
    }

       

    public static string GetSexString(string id)
    {
        string sRtnValue = "";

        if (id.Length != 14)
            return "";

        string temp = id.Substring(7, 1);

        if (temp == "1" || temp == "3" || temp == "9")
            sRtnValue = "남자";
        else if (temp == "5" || temp == "7")
            sRtnValue = "남자(외국인)";
        else if (temp == "2" || temp == "4" || temp == "0")
            sRtnValue = "여자";
        else if (temp == "6" || temp == "8")
            sRtnValue = "여자(외국인)";
        else
            sRtnValue = "";

        return sRtnValue;
    }

    public static string GetAge(string birth)
    {
        if (string.IsNullOrEmpty(birth))
            return "";

        if (birth.Length != 10)
            return "";

        double result = UtilManager.DateDiff("y", Convert.ToDateTime(birth), DateTime.Now);



        return Convert.ToInt16(result).ToString();
    }

    public static double DateDiff(string Interval, DateTime Date1, DateTime Date2)
    {
        double diff = 0;
        TimeSpan ts = Date2 - Date1;

        switch (Interval.ToLower())
        {
            case "y":
                ts = DateTime.Parse(Date2.ToString("yyyy-01-01")) - DateTime.Parse(Date1.ToString("yyyy-01-01"));
                diff = Convert.ToDouble(ts.TotalDays / 365);
                break;
            case "m":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-01")) - DateTime.Parse(Date1.ToString("yyyy-MM-01"));
                diff = Convert.ToDouble((ts.TotalDays / 365) * 12);
                break;
            case "d":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd"));
                diff = ts.Days;
                break;
            case "h":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:00:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:00:00"));
                diff = ts.TotalHours;
                break;
            case "n":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:00")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:00"));
                diff = ts.TotalMinutes;
                break;
            case "s":
                ts = DateTime.Parse(Date2.ToString("yyyy-MM-dd HH:mm:ss")) - DateTime.Parse(Date1.ToString("yyyy-MM-dd HH:mm:ss"));
                diff = ts.TotalSeconds;
                break;
            case "ms":
                diff = ts.TotalMilliseconds;
                break;
        }

        return diff;
    }

    public static string GetLocal(string localNm)
    {
        string sRtnValue = "";

        if (string.IsNullOrEmpty(localNm))
            return "";

        if (localNm.IndexOf(',') > 0)
        {
            sRtnValue = localNm.Substring(0, localNm.IndexOf(','));
        }
        else
        {
            sRtnValue = localNm;
        }

        return sRtnValue;
    }

    public static void SetTextFile(string path, string content)
    {

        FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite);
        StreamWriter sw = new StreamWriter(fs);
        sw.Write(content);
        sw.Close();
    }




    public static string WriteChecked(string checkBoxVal, string requestVal)
    {
        string retVal = string.Empty;

        if (requestVal == null)
            return retVal;

        if (requestVal.Contains(checkBoxVal))
            retVal = "checked=checked";

        return retVal;
    }

    public static string WriteSelected(string selectVal, string requestVal)
    {
        string retVal = string.Empty;

        if (requestVal == null)
            return retVal;

        if (requestVal.Contains(selectVal))
            retVal = "selected=selected";

        return retVal;
    }

    public static string WriteDisabled(string val, string requestVal)
    {
        string retVal = string.Empty;

        if (requestVal == null || !requestVal.Contains(val))
            retVal = "disabled=disabled";

        return retVal;
    }

    public static string WriteDisplayNone(string val, string requestVal)
    {
        string retVal = string.Empty;

        if (requestVal == null || !requestVal.Contains(val))
            retVal = "style=display:none";

        return retVal;
    }



    public static string ToFriendlyUrl(string url)
    {
        string sRtnVal = "";

        sRtnVal = url.Replace(" ", "-");

        Regex regEx = new Regex("[~!@()/%#$^&*=+|:;?\"<,.>']", RegexOptions.IgnoreCase);
        sRtnVal = regEx.Replace(sRtnVal, "");
        sRtnVal = sRtnVal.Replace("\\", "");


        return sRtnVal;
    }
    

    public static DateTime GetAddDate(DateTime date, string durationFg, int duration)
    {
        DateTime dt = System.DateTime.Now;

        switch (durationFg)
        {
            case "DAY":
                dt = date.AddDays(duration);
                break;
            case "MONTH":
                dt = date.AddMonths(duration);
                break;
            case "WEEK":
                dt = date.AddDays(duration * 7);
                break;
            case "YEAR":
                dt = date.AddYears(duration);
                break;
        }

        return dt;
    }


    public static int GetWeekCnt(DateTime dt)
    {
        int week = Enum.GetValues(typeof(DayOfWeek)).Length;
        int dayOffset = (int)dt.AddDays(-(dt.Day - 1)).DayOfWeek;
        int weekCnt = (dt.Day + dayOffset) / week;
        weekCnt += ((dt.Day + dayOffset) % week) > 0 ? 1 : 0;
        return weekCnt;
    }


    public static string[] GetStringSplit(int number)
    {
        string num = string.Format("{0:n0}", number);

        string[] arrNum = new string[num.Length];

        for (int i = 0; i < num.Length; i++)
        {
            arrNum[i] = num.Substring(i, 1);
        }

        return arrNum;

    }


    public static void ShowAndRedir(string strMessage, string redirUri)
    {
        string strHTML;
        strHTML = "<script language=\"javascript\">\n	<!--\n		alert('" + strMessage + "');\n" +
           "	window.document.location.href='" + redirUri + "';\n" +
           "//-->\n	</script>\n";

        //strHTML = "<script language=\"vbscript\">\n <!--\n		msgbox \"" + strMessage + "\"\n" +
        //	"	window.document.location.href=\"" + redirUri + "\"\n" +
        //	 "</script>\n";

        HttpContext.Current.Response.Write(strHTML.Replace("\\", "\\n"));
        HttpContext.Current.Response.End();
    }

    public static void ShowAndBack(string strMessage)
    {
        string strHTML;
        strHTML = "<script language=\"javascript\">\n	<!--\n		alert('" + strMessage + "');\n" +
           "	window.history.back();\n" +
           "//-->\n	</script>\n";

        //strHTML = "<script language=\"vbscript\">\n <!--\n		msgbox \"" + strMessage + "\"\n" +
        //	"	window.document.location.href=\"" + redirUri + "\"\n" +
        //	 "</script>\n";

        HttpContext.Current.Response.Write(strHTML.Replace("\\", "\\n"));
        HttpContext.Current.Response.End();
    }

    public static void ShowAndClose(string strMessage)
    {
        string strHTML;
        strHTML = "<script language=\"javascript\">\n	<!--\n		alert('" + strMessage + "');\n" +
           "	window.close();\n" +
           "//-->\n	</script>\n";

        //strHTML = "<script language=\"vbscript\">\n <!--\n		msgbox \"" + strMessage + "\"\n" +
        //	"	window.document.location.href=\"" + redirUri + "\"\n" +
        //	 "</script>\n";

        HttpContext.Current.Response.Write(strHTML.Replace("\\", "\\n"));
        HttpContext.Current.Response.End();
    }

   

    public static string EncryptString(string InputText, string Password = "smsko!@#")
    {

        // Rihndael class를 선언하고, 초기화 합니다
        RijndaelManaged RijndaelCipher = new RijndaelManaged();

        //// 입력받은 문자열을 바이트 배열로 변환
        byte[] PlainText = System.Text.Encoding.Unicode.GetBytes(InputText);

        // 딕셔너리 공격을 대비해서 키를 더더 풀기 어렵게 만들기 위해서
        //// Salt를 사용합니다.
        byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());

        // PasswordDeriveBytes 클래스를 사용해서 SecretKey를 얻습니다.
        PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

        //// Create a encryptor from the existing SecretKey bytes.
        // encryptor 객체를 SecretKey로부터 만듭니다.
        // Secret Key에는 32바이트
        // (Rijndael의 디폴트인 256bit가 바로 32바이트입니다)를 사용하고,
        // Initialization Vector로 16바이트
        // (역시 디폴트인 128비트가 바로 16바이트입니다)를 사용합니다
        ICryptoTransform Encryptor = RijndaelCipher.CreateEncryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

        // 메모리스트림 객체를 선언,초기화
        MemoryStream memoryStream = new MemoryStream();

        // CryptoStream객체를 암호화된 데이터를 쓰기 위한위한 용도로 선언
        CryptoStream cryptoStream = new CryptoStream(memoryStream, Encryptor, CryptoStreamMode.Write);

        // 암호화 프로세스가 진행됩니다.
        cryptoStream.Write(PlainText, 0, PlainText.Length);

        // 암호화 종료
        cryptoStream.FlushFinalBlock();

        // 암호화된 데이터를 바이트 배열로 담습니다.
        byte[] CipherBytes = memoryStream.ToArray();

        //// 스트림 해제
        memoryStream.Close();
        cryptoStream.Close();

        // 암호화된 데이터를 Base64 인코딩된 문자열로 변환합니다.
        string EncryptedData = Convert.ToBase64String(CipherBytes);

        //// 최종 결과를 리턴
        return EncryptedData;

    }

    public static string DecryptString(string InputText, string Password = "")
    {

        RijndaelManaged RijndaelCipher = new RijndaelManaged();

        byte[] EncryptedData = Convert.FromBase64String(InputText);
        byte[] Salt = Encoding.ASCII.GetBytes(Password.Length.ToString());


        PasswordDeriveBytes SecretKey = new PasswordDeriveBytes(Password, Salt);

        // Decryptor 객체를 만듭니다.
        ICryptoTransform Decryptor = RijndaelCipher.CreateDecryptor(SecretKey.GetBytes(32), SecretKey.GetBytes(16));

        MemoryStream memoryStream = new MemoryStream(EncryptedData);

        // 데이터 읽기(복호화이므로) 용도로 cryptoStream객체를 선언,선언, 초기화
        CryptoStream cryptoStream = new CryptoStream(memoryStream, Decryptor, CryptoStreamMode.Read);

        // 복호화된 데이터를 담을 바이트 배열을 선언합니다.선언합니다. 
        // 길이는 알 수 없지만,없지만, 일단 복호화되기 전의 데이터의 길이보다는
        // 길지 않을 것이기 때문에 그 길이로 선언합니다
        byte[] PlainText = new byte[EncryptedData.Length];

        // 복호화 시작
        int DecryptedCount = cryptoStream.Read(PlainText, 0, PlainText.Length);

        memoryStream.Close(); memoryStream.Close();
        cryptoStream.Close();

        // 복호화된 데이터를데이터를 문자열로 바꿉니다.
        string DecryptedData = Encoding.Unicode.GetString(PlainText, 0, DecryptedCount);

        // 최종 결과 리턴리턴 
        return DecryptedData;

    }

    
    public static RouteValueDictionary GetErrorRoute(string action, string message)
    {
        RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
        redirectTargetDictionary.Add("message", message);
        redirectTargetDictionary.Add("action", action);
        redirectTargetDictionary.Add("controller", "Error");

        return redirectTargetDictionary;

    }

    public static string GetBoardQuaryString(object routeValue)
    {
        string queryString = "";
        RouteValueDictionary routeDic = new RouteValueDictionary(routeValue);

        foreach (var item in routeDic)
        {
            if (item.Value != null)
            {
                string val = item.Value.ToString();
                if (val != "0" && val != "")
                {
                    queryString += string.IsNullOrEmpty(queryString) ? "?" : "&";
                    queryString += item.Key + "=" + item.Value;
                }
            }
        }

        return queryString;
    }

    public static bool IsValidateAntiToken()
    {
        bool isCheck = false;
        try
        {
            System.Web.Helpers.AntiForgery.Validate();
            isCheck = true;
        }
        catch (Exception) { }

        return isCheck;
    }

    public static string GetBitlyShortenUrl(string url)
    {
        string statusCode = string.Empty;
        string statusText = string.Empty;
        string shortUrl = string.Empty;
        string longUrl = string.Empty;
        string urlToShorten = url;

        using (WebClient wb = new WebClient())
        {
            string data = string.Format("http://api.bitly.com/v3/shorten/?login={0}&apiKey={1}&longUrl={2}&format={3}",
            //CodeManager.GetCodeName("SYS_API_FG", "BITLY_USER_ID"),
            //CodeManager.GetCodeName("SYS_API_FG", "BITLY_API_KEY"),
                HttpUtility.UrlEncode(urlToShorten),         // Encode the url we want to shorten
            "xml");

            System.Xml.XmlDocument xmlDoc = new System.Xml.XmlDocument();
            xmlDoc.LoadXml(wb.DownloadString(data));

            statusCode = xmlDoc.GetElementsByTagName("status_code")[0].InnerText;
            statusText = xmlDoc.GetElementsByTagName("status_txt")[0].InnerText;
            shortUrl = xmlDoc.GetElementsByTagName("url")[0].InnerText;
            longUrl = xmlDoc.GetElementsByTagName("long_url")[0].InnerText;

            Console.WriteLine(statusCode);      // Outputs "200"
            Console.WriteLine(statusText);      // Outputs "OK"
            Console.WriteLine(shortUrl);        // Outputs "http://bit.ly/WVk1qN"
            Console.WriteLine(longUrl);         // Outputs "http://www.fluxbytes.com/"
            if (!(statusCode == "200" && statusText == "OK"))
            {
                shortUrl = "";
            }

            return shortUrl;
        }
    }


    public static string GetUniqueFileName(string path, string name)
    {
        string strNm = Path.GetFileNameWithoutExtension(name);
        string strEx = Path.GetExtension(name);
        bool blnExists = true;

        int i = 0;

        while (blnExists)
        {
            if (File.Exists(Path.Combine(path, name)))
            {
                i++;
                name = String.Format("{0}({1}){2}", strNm, i.ToString(), strEx);
            }
            else
            {
                blnExists = false;
            }
        }

        return name;
    }

  

    public static bool IsMobile()
    {
        string u = HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"];
        Regex b = new Regex(@"(android|bb\d+|meego).+mobile|avantgo|bada\/|blackberry|blazer|compal|elaine|fennec|hiptop|iemobile|ip(hone|od)|iris|kindle|lge |maemo|midp|mmp|mobile.+firefox|netfront|opera m(ob|in)i|palm( os)?|phone|p(ixi|re)\/|plucker|pocket|psp|series(4|6)0|symbian|treo|up\.(browser|link)|vodafone|wap|windows (ce|phone)|xda|xiino", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        Regex v = new Regex(@"1207|6310|6590|3gso|4thp|50[1-6]i|770s|802s|a wa|abac|ac(er|oo|s\-)|ai(ko|rn)|al(av|ca|co)|amoi|an(ex|ny|yw)|aptu|ar(ch|go)|as(te|us)|attw|au(di|\-m|r |s )|avan|be(ck|ll|nq)|bi(lb|rd)|bl(ac|az)|br(e|v)w|bumb|bw\-(n|u)|c55\/|capi|ccwa|cdm\-|cell|chtm|cldc|cmd\-|co(mp|nd)|craw|da(it|ll|ng)|dbte|dc\-s|devi|dica|dmob|do(c|p)o|ds(12|\-d)|el(49|ai)|em(l2|ul)|er(ic|k0)|esl8|ez([4-7]0|os|wa|ze)|fetc|fly(\-|_)|g1 u|g560|gene|gf\-5|g\-mo|go(\.w|od)|gr(ad|un)|haie|hcit|hd\-(m|p|t)|hei\-|hi(pt|ta)|hp( i|ip)|hs\-c|ht(c(\-| |_|a|g|p|s|t)|tp)|hu(aw|tc)|i\-(20|go|ma)|i230|iac( |\-|\/)|ibro|idea|ig01|ikom|im1k|inno|ipaq|iris|ja(t|v)a|jbro|jemu|jigs|kddi|keji|kgt( |\/)|klon|kpt |kwc\-|kyo(c|k)|le(no|xi)|lg( g|\/(k|l|u)|50|54|\-[a-w])|libw|lynx|m1\-w|m3ga|m50\/|ma(te|ui|xo)|mc(01|21|ca)|m\-cr|me(rc|ri)|mi(o8|oa|ts)|mmef|mo(01|02|bi|de|do|t(\-| |o|v)|zz)|mt(50|p1|v )|mwbp|mywa|n10[0-2]|n20[2-3]|n30(0|2)|n50(0|2|5)|n7(0(0|1)|10)|ne((c|m)\-|on|tf|wf|wg|wt)|nok(6|i)|nzph|o2im|op(ti|wv)|oran|owg1|p800|pan(a|d|t)|pdxg|pg(13|\-([1-8]|c))|phil|pire|pl(ay|uc)|pn\-2|po(ck|rt|se)|prox|psio|pt\-g|qa\-a|qc(07|12|21|32|60|\-[2-7]|i\-)|qtek|r380|r600|raks|rim9|ro(ve|zo)|s55\/|sa(ge|ma|mm|ms|ny|va)|sc(01|h\-|oo|p\-)|sdk\/|se(c(\-|0|1)|47|mc|nd|ri)|sgh\-|shar|sie(\-|m)|sk\-0|sl(45|id)|sm(al|ar|b3|it|t5)|so(ft|ny)|sp(01|h\-|v\-|v )|sy(01|mb)|t2(18|50)|t6(00|10|18)|ta(gt|lk)|tcl\-|tdg\-|tel(i|m)|tim\-|t\-mo|to(pl|sh)|ts(70|m\-|m3|m5)|tx\-9|up(\.b|g1|si)|utst|v400|v750|veri|vi(rg|te)|vk(40|5[0-3]|\-v)|vm40|voda|vulc|vx(52|53|60|61|70|80|81|83|85|98)|w3c(\-| )|webc|whit|wi(g |nc|nw)|wmlb|wonu|x700|yas\-|your|zeto|zte\-", RegexOptions.IgnoreCase | RegexOptions.Multiline);
        if ((b.IsMatch(u) || v.IsMatch(u.Substring(0, 4))))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public static bool isValidIP()
    {
        bool isCheck = true;
        string[] arrFilterIP = new string[] { "127.0.0.1" };
        int length = arrFilterIP.Length;

        for (int i = 0; i < length; i++)
        {
            if (HttpContext.Current.Request.UserHostAddress.Contains(arrFilterIP[i]))
            {
                isCheck = false;
                break;
            }
        }

        return isCheck;
    }
}