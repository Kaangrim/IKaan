using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using IKaan.Application.Crypto;
namespace IKaan.Web.Core.Config
{
    public class CookieManager
    {
        public readonly string __EncPassword = "ikaanwebscm";
        private string __Domain;
        private Dictionary<string, HttpCookie> CookieDic;


        public CookieManager(string Domain)
        {
            __Domain = Domain;
            CookieDic = new Dictionary<string, HttpCookie>();
        }

        public void SetCookieValue(string cookienameByParent, string cookienameByChild, string cookievalue, DateTime ExpiresTime, System.Text.Encoding Enc)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies[cookienameByParent];

            if (cookie == null)
            {
                cookie = new HttpCookie(cookienameByParent)
                {
                    Domain = __Domain,
                    Path = "/",
                    Expires = ExpiresTime
                };
            }

            cookie[cookienameByChild] = HttpUtility.UrlEncode(cookievalue, Enc);

            HttpContext.Current.Response.Cookies.Add(cookie);
        }

        public void SetCookieValue(string cookienameByParent, string cookienameByChild, string cookievalue)
        {
            SetCookieValue(cookienameByParent, cookienameByChild, cookievalue, DateTime.Now.AddYears(1), System.Text.Encoding.UTF8);
        }

        public void SetCookieValue(string cookienameByParent, string cookievalue)
        {
            SetCookieValue(cookienameByParent, cookievalue, null);
        }

        public void SetCookieValue(string cookienameByParent, string cookievalue, DateTime ExpiresTime)
        {
            SetCookieValue(cookienameByParent, cookievalue, null, ExpiresTime, System.Text.Encoding.UTF8);
        }

        public void SetCookieValue(string CookieNameByParent, string CookieNameByChild, string CookieValue, System.Text.Encoding Enc)
        {
            SetCookieValue(CookieNameByParent, CookieNameByChild, CookieValue, DateTime.Now.AddYears(1), Enc);
        }
        

        #region Get GetCookieValue, 암호화 포함

        private HttpCookie GetHttpCookie(string cookienameByParent)
        {
            if (!CookieDic.ContainsKey(cookienameByParent))
            {
                CookieDic[cookienameByParent] = HttpContext.Current.Request.Cookies[cookienameByParent];
            }

            return CookieDic[cookienameByParent];
        }

        public string GetCookieValue(string cookienameByParent)
        {
            HttpCookie Cookie = GetHttpCookie(cookienameByParent);
            if (Cookie == null) return string.Empty;
            //return GetHttpCookie(cookienameByParent).Value;
            return Cookie.Value;
        }

        /// <summary>
        /// 쿠키 값 조회
        /// </summary>
        /// <param name="CookieNameByParent"></param>
        /// <param name="cookienameByChild"></param>
        /// <param name="Decryption">쿠키 복호화 여부</param>
        /// <returns></returns>
        public string GetCookieValue(string CookieNameByParent, string cookienameByChild, bool Decryption = false)
        {
            if (!Decryption)
            {
                string returnvalue = null;
                HttpCookie cookie = GetHttpCookie(CookieNameByParent);
                if (cookie != null && cookie.HasKeys) returnvalue = cookie[cookienameByChild];
                return returnvalue == null ? String.Empty : HttpUtility.UrlDecode(returnvalue);
            }
            else
            {
                string CurCookie = GetCookieValue(CookieNameByParent);

                if (string.IsNullOrEmpty(CurCookie)) return string.Empty;

                CryptoParams Params = new CryptoParams();
                Params.SetCryptoParams(HttpUtility.UrlDecode(CurCookie), __EncPassword);

                return Params.GetParameter(cookienameByChild);
            }
        }

        #endregion

        #region SetCookieEncryption, GetCookieDecryption

        public void SetCookieEncryption(string CookieNameByParent, string CookieNameByChild, string CookieValue)
        {
            HttpCookie CurCookie = GetHttpCookie(CookieNameByParent);

            CryptoParams Params = new CryptoParams();
            Params.SetCryptoParams(HttpUtility.UrlDecode(CurCookie.Value), __EncPassword);
            Params.SetParameter(CookieNameByChild, CookieValue);

            SetCookieValue(CookieNameByChild, HttpUtility.UrlEncode(Params.GetParamsString(true)), null, DateTime.Now.AddYears(1), System.Text.Encoding.UTF8);

            CurCookie.Value = HttpUtility.UrlEncode(Params.GetParamsString(true));
            HttpContext.Current.Response.Cookies.Add(CurCookie);
        }

        #endregion 

        public void RemoveCookieValue(string cookienameByParent)
        {
            SetCookieValue(cookienameByParent, "");
        }

        /// <summary>
        /// 쿠키를 굽는다.
        /// </summary>
        /// <param name="strCookieName">쿠키명</param>
        /// <param name="strCookieValue">쿠키에 구울 값</param>
        public void SetCookie(string strCookieName, string strCookieValue, string domain)
        {
            HttpCookie hc = new HttpCookie(strCookieName);
            hc.Expires = DateTime.Now.AddYears(1);    //쿠키를 1년동안 유지한다
            hc.Domain = domain;
            hc.Path = "/";
            hc.Value = HttpContext.Current.Server.UrlEncode(strCookieValue);
            HttpContext.Current.Response.Cookies.Add(hc);
        }


        /// <summary>
        /// Cookies 값이 있는지 없는지 검사를 한다.
        /// </summary>
        /// <param name="strCookieName">쿠키명</param>
        /// <returns>true, false 로 여부를 알려 준다.</returns>
        public bool IsCookieValue(string strCookieName)
        {
            HttpCookieCollection hcc = new HttpCookieCollection();
            HttpCookie LocalCookie;
            hcc = HttpContext.Current.Request.Cookies;
            string[] arrCookies = hcc.AllKeys;
            bool booReturnValue = false;
            for (int intNo = 0; intNo < arrCookies.Length; intNo++)
            {
                LocalCookie = hcc[arrCookies[intNo]];
                if (LocalCookie.Name == strCookieName)
                {
                    booReturnValue = true;
                    break;
                }
            }
            return booReturnValue;
        }

        public void Dispose()
        {
           
        }
    }
}