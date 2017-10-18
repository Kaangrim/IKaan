using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IKaan.Web.Core.Config;
using IKaan.Web.Core.Utils;
using System.Web.Routing;
using System.Collections.Specialized;
using System.Net;
using System.Text; 

namespace IKaan.Web.View.SCM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            ViewBag.LoginID = CookieManager.GetLoginID();
            ViewBag.LoginName = CookieManager.GetCookieDecrypt("LoginName");

            return View();
        }


    }
}