using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace SecurityFilters.Controllers
{
    public class PublicController : Controller
    {
        //
        // GET: /Public/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string Username, string Role, string ReturnUrl)
        {
            if (string.IsNullOrEmpty(Username))
                Username = "Unknown";//Default value that is set if nothing is entered

            var authTicket = new FormsAuthenticationTicket(1,   Username, DateTime.Now, DateTime.Now.AddMinutes(30), true, 
                                                                Role);
            string cookieContents = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, cookieContents)
                                        {
                                            Expires = authTicket.Expiration,
                                            Path = FormsAuthentication.FormsCookiePath
                                        };
            Response.Cookies.Add(cookie);

            if(!string.IsNullOrEmpty(ReturnUrl))
                    Response.Redirect(ReturnUrl);

            return View("Index");
        }


    }
}
