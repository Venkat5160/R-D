using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn_RD.Controllers
{
    public class HomeController : Controller
    {
        private const string URL_BASE = "http://api.linkedin.com/v1";
        public static string ConsumerKey { get { return ConfigurationManager.AppSettings["ConsumerKey"]; } }
        public static string ConsumerKeySecret { get { return ConfigurationManager.AppSettings["ConsumerSecret"]; } }
        public string AccessToken { get; set; }
        public string AccessTokenSecret { get; set; } 
          
        // GET: /Home/
        public ActionResult LinkedIN()
        {
            return View();
        }

        public ActionResult LinkedINAuth(string code, string state)
        {
            //This method path is your return URL  
            return View();
        }  
	}
}