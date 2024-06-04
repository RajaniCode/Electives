using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008Cookies
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            HttpCookie CookieHttp = new HttpCookie("UserSettings");
            CookieHttp["Font"] = "Arial";
            CookieHttp["Color"] = "Blue";
            CookieHttp.Expires = DateTime.Now.AddDays(1d);
            Response.Cookies.Add(CookieHttp);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserSettings"] != null)
            {
                HttpCookie CookieHttp = new HttpCookie("UserSettings");
                CookieHttp["Font"] = "Times New Roman";
                CookieHttp.Expires = DateTime.Now.AddDays(1d);
                Response.Cookies.Add(CookieHttp);
            }
        } 

        protected void Button3_Click(object sender, EventArgs e)
        {
            if (Request.Cookies["UserSettings"] != null)
            {
                HttpCookie CookieHttp = new HttpCookie("UserSettings");
                CookieHttp.Expires = DateTime.Now.AddDays(-1d);
                Response.Cookies.Add(CookieHttp);
            }
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            string userSettings = string.Empty;

            if (Request.Cookies["UserSettings"] != null)
            {
                if (Request.Cookies["UserSettings"]["Font"] != null)
                {
                    userSettings = Request.Cookies["UserSettings"]["Font"];
                }
            }
            TextBox1.Text = userSettings;
        }

       
    }
}
