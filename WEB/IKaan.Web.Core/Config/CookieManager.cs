using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace IKaan.Web.Core.Config
{
    public class CookieManager
    {
        public static void AddCookieEncrypt(string key, string value)
        {            
            if (!String.IsNullOrEmpty(value))
            {
                string groupKey = UtilManager.GetSaveKey("AuthCookieKey");
                HttpContext.Current.Response.Cookies[groupKey][key] = CryptoManager.EncryptAES256(value.ToString());
            }

        }

        public static void AddCookieExpires(int days)
        {
            string groupKey = UtilManager.GetSaveKey("AuthCookieKey");
            HttpContext.Current.Response.Cookies[groupKey].Expires = DateTime.Now.AddDays(days);
        }

        public static void AddCookie(string key, string value)
        {
            if (!String.IsNullOrEmpty(value)) { 
                string groupKey = UtilManager.GetSaveKey("AuthCookieKey");
                HttpContext.Current.Response.Cookies[groupKey][key] = value.ToString();
            }
        }

        public static void AddCookieDomain(string value)
        {
            string groupKey = UtilManager.GetSaveKey("AuthCookieKey");
            HttpContext.Current.Response.Cookies[groupKey].Domain = value.ToString();
        }
        public static void AddCookiePath(string value)
        {
            string groupKey = UtilManager.GetSaveKey("AuthCookieKey");
            HttpContext.Current.Response.Cookies[groupKey].Path = value.ToString();
        }

        public static void AddCookieHttpOnly(bool value)
        {
            string groupKey = UtilManager.GetSaveKey("AuthCookieKey");
            HttpContext.Current.Request.Cookies[groupKey].HttpOnly = value;
        }

        public static void ClearCookie()
        {
            HttpContext.Current.Response.Cookies.Clear();
        }


        public static string GetCookieDecrypt(string key)
        {
            string groupKey = UtilManager.GetSaveKey("AuthCookieKey");

            string sRtnValue = "";

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            { 
                return null;
            }

            if (HttpContext.Current.Request.Cookies[groupKey] != null)
            {
                if (HttpContext.Current.Request.Cookies[groupKey][key] != null)
                { 
                    sRtnValue = CryptoManager.DecryptAES256(HttpContext.Current.Request.Cookies[groupKey][key]);
                }
            }


            return sRtnValue;
        }

        public static string GetCookie(string key)
        {
            string groupKey = UtilManager.GetSaveKey("AuthCookieKey");

            string sRtnValue = "";

            if (!HttpContext.Current.User.Identity.IsAuthenticated)
                return null;

            if (HttpContext.Current.Request.Cookies[groupKey] != null)
            {
                if (HttpContext.Current.Request.Cookies[groupKey][key] != null)
                {
                    sRtnValue = HttpContext.Current.Request.Cookies[groupKey][key];
                }
            }

            return sRtnValue;
        }

        public static string GetLoginID()
        {
            string GetLoginID;

            if (HttpContext.Current.User.Identity.IsAuthenticated)
            {
                GetLoginID = CryptoManager.DecryptAES256(HttpContext.Current.User.Identity.Name);
            }
            else
            {
                GetLoginID = null;
            }

            return GetLoginID;

        }

        

        public static string GetIPAddress()
        {
            return HttpContext.Current.Request.UserHostAddress;

        }


        public static string GetSessionID()
        {
            return HttpContext.Current.Session.SessionID;

        }


    }
}