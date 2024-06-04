using System;
using System.Web;

namespace WebApplication1
{   
    public class CustomHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            if (context.User.Identity.IsAuthenticated &&
                context.User.Identity.Name.ToUpper() == "CEO")
            {
                DownloadFile(context);
            }
            else
            {
                context.Response.Write("No access unless you're the CEO!!!");
            }
        }

        protected void DownloadFile(HttpContext context)
        {
            context.Response.Buffer = true;
            context.Response.Clear();
            context.Response.AddHeader("content-disposition", context.Request.Url.AbsolutePath);
            context.Response.ContentType = "text/plain";
            context.Response.WriteFile(context.Server.MapPath(context.Request.Url.AbsolutePath));         
        }  

        public override string ToString()
        {
            return "Some generic description to define what this class does..";
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
