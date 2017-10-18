using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using System.Configuration;
using System.Security.Cryptography;

using IKaan.Web.Model.SCM;
using IKaan.Web.Model.SCM.Biz;
using IKaan.Web.Service.Services;
using IKaan.Web.Core.Config;
using IKaan.Web.Core.Utils;

namespace IKaan.Web.View.SCM.Controllers
{
    public class AccountController : Controller
    {
        // **************************************
        // URL: /Account/Login 
        // Description : Get
        // **************************************
        public ActionResult Login()
        {
            string port = Request.ServerVariables["SERVER_PORT"];
            string strSecureURL = String.Empty;

            //### 로그인 페이지 SSL 처리
            if (port == "80")
            {               
                strSecureURL = UtilManager.SSLCheck(strSecureURL, port);
                return Redirect(strSecureURL);
            }

            return View();
        }
        // **************************************
        // URL: /Account/Login 
        // Description : Post
        // **************************************
        [HttpPost]
        public ActionResult Login(LoginModel model, string ReturnUrl)
        {            
            string EncriptLoginPW = CryptoManager.EncryptSHA512(model.LoginPW);            
            
            /*##모델Check##*/
            if (ModelState.IsValid)
            {               
                ContactModel Contact;
                
                using (Repository repo = new Repository())
                {
                    #region  ## 로그인Check ##
                    Contact = repo.Account.UserSSLLogin(model.LoginID, EncriptLoginPW);
                    
                    if (Contact != null)
                    {                      
                        if (Contact.ResultCode == "Err")
                        {
                            Response.Write(ComUtils.JavascriptAlertAndBack(Contact.ResultMassege));
                            Response.End();
                        }

                        //form과 db 비밀번호 비교
                        if (Contact.LoginPW != EncriptLoginPW)
                        {
                            Response.Write(ComUtils.JavascriptAlertAndBack("아이디 / 비밀번호를 확인해 주세요."));
                            Response.End();
                        }
                        
                        #region ## 쿠키 생성 시작##                    
                        CookieManager.ClearCookie();
                        FormsAuthentication.SetAuthCookie(CryptoManager.EncryptAES256(Contact.LoginID), false); // true 이면 영구 
                        CookieManager.AddCookieEncrypt("LoginName", Contact.Name);
                        CookieManager.AddCookieEncrypt("AuthGroup", Contact.AuthGroup);
                        CookieManager.AddCookieDomain(UtilManager.GetSaveKey("AuthCookieDomain"));
                        CookieManager.AddCookieExpires(1);
                        CookieManager.AddCookiePath("/");
                        CookieManager.AddCookieHttpOnly(true);
                        #endregion ## 쿠키 생성 끝##

                    }
                    else
                    {
                        Response.Write(ComUtils.JavascriptAlertAndBack("칸그림 관리자에게 문의해 주세요."));
                        Response.End();
                        
                    }
                    #endregion ## 회원체크 ##
                }
            }
            return Redirect("/");
        }
        // **************************************
        // URL: /Account/LogOut
        // **************************************

        public ActionResult LogOut()
        {            
            FormsAuthentication.SignOut();
            return Redirect("/");
        }
    }
}