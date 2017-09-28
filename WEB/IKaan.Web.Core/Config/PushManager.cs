using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using System.Text;
using System.IO;

public static class PushManager
{

    public static string PushNotification(string title, string msg, string regIds)
    {
        string apiKey = ""; //UtilManager.GetSaveKey("GOOGLE_SERVER_API_KEY");
        string registID = "";
        //기기별로 보낼경우는 한번에 1000개 까지 보낼수 있는데 이부분은 적용하세요.

        if (regIds.Contains(","))
        {
            foreach (var item in regIds.Split(','))
            {
                if (!string.IsNullOrEmpty(registID)) registID += ",";

                registID += "\"" + item + "\"";

            }
        }
        else
        {
            registID = "\"" + regIds + "\"";
        }

        string postData = "{\"collapse_key\":\"score_update\",\"delay_while_idle\":true,\"data\":{\"payload\":\"" + msg + "\",\"title\":\"" + title + "\",\"message\":\"" + msg + "\"},\"registration_ids\":[" + registID + "]}";

        string returnPush = PushManager.SendGCMNotification(apiKey, postData, "application/json");

        return returnPush;
    }

    #region [App - GCM 발송용 확인데이터]
    /// <summary>
    /// App - GCM 발송용 확인데이터
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="certificate"></param>
    /// <param name="chain"></param>
    /// <param name="sslPolicyErrors"></param>
    /// <returns></returns>
    public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
    {
        return true;
    }
    #endregion

    #region [App - GCM 푸쉬 발송]
    /// <summary>
    /// App - GCM 푸쉬 발송
    /// </summary>
    /// <param name="apiKey">앱별 푸쉬 발송용 키값</param>
    /// <param name="postData">푸쉬 발송 정보</param>
    /// <param name="postDataContentType">푸쉬 발송용 Type</param>
    /// <returns></returns>
    public static string SendGCMNotification(string apiKey, string postData, string postDataContentType = "application/json")
    {
        ServicePointManager.ServerCertificateValidationCallback += new RemoteCertificateValidationCallback(ValidateServerCertificate);

        //
        //  MESSAGE CONTENT
        byte[] byteArray = Encoding.UTF8.GetBytes(postData);
        //
        //  CREATE REQUEST
        HttpWebRequest Request = (HttpWebRequest)WebRequest.Create("https://android.googleapis.com/gcm/send");
        Request.Method = "POST";
        Request.KeepAlive = false;
        Request.ContentType = postDataContentType;
        Request.Headers.Add(string.Format("Authorization: key={0}", apiKey));
        Request.ContentLength = byteArray.Length;
        Stream dataStream = Request.GetRequestStream();
        dataStream.Write(byteArray, 0, byteArray.Length);
        dataStream.Close();
        //
        //  SEND MESSAGE
        try
        {
            WebResponse Response = Request.GetResponse();
            HttpStatusCode ResponseCode = ((HttpWebResponse)Response).StatusCode;
            if (ResponseCode.Equals(HttpStatusCode.Unauthorized) || ResponseCode.Equals(HttpStatusCode.Forbidden))
            {
                //var text = "Unauthorized - need new token";
                return "Unauthorized - need new token";
            }
            else if (!ResponseCode.Equals(HttpStatusCode.OK))
            {
                //var text = "Response from web service isn't OK";
                return "Response from web service isn't OK";
            }
            StreamReader Reader = new StreamReader(Response.GetResponseStream());
            string responseLine = Reader.ReadToEnd();
            Reader.Close();

            return responseLine;
        }
        catch (Exception)
        {
            return "error";
        }
    }
    #endregion
}