using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IKaan.Web.Core.Config;
using IKaan.Web.Core.Utils;

namespace IKaan.Web.View.SCM.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index() 
        {
          
            return View();
        }
    }
}