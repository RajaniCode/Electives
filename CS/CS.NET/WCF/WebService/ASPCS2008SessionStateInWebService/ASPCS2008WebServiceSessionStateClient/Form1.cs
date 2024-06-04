using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Net;
using Microsoft.VisualBasic;

namespace ASPCS2008WebServiceSessionStateClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        System.Net.CookieContainer Cookies;

        // Works with cookied ASP.NET sessions but NOT with cookieless sessions.
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    localhost.Service1 proxy = new localhost.Service1();
        //    int ret = 0;
        //    // Set the Cookie Container on the proxy
        //    if (Cookies == null)
        //    {
        //        Cookies = new System.Net.CookieContainer();
        //    }
        //    proxy.CookieContainer = Cookies;
        //    ret = proxy.IncrementSessionCounterX();
        //    label1.Text = "Result: " + Convert.ToString(ret);

        //}

        
        Uri webServiceUrl;

        // Works with both cookied and cookieless ASP.NET sessions.
        private void button1_Click(object sender, EventArgs e)
        {
            localhost.Service1 proxy = new localhost.Service1();
            int ret = 0;
            // Set the Cookie Container on the proxy
            if (Cookies == null)
            {
                Cookies = new System.Net.CookieContainer();
            }
            proxy.CookieContainer = Cookies;
            // Set the Url on the proxy
            if (webServiceUrl == null)
            {
                webServiceUrl = new Uri(proxy.Url);
            }
            else
            {
                proxy.Url = webServiceUrl.AbsoluteUri;
            }
            try
            {
                ret = proxy.IncrementSessionCounterX();
            }
            catch (WebException we)
            {
                // We need an HttpWebResponse if we expect to 
                // check the HTTP status code.
                if (we.Response is HttpWebResponse)
                {
                    HttpWebResponse HttpResponse = default(HttpWebResponse);
                    HttpResponse = (HttpWebResponse)we.Response;
                    if (HttpResponse.StatusCode == HttpStatusCode.Found)
                    {
                        MsgBoxResult result = Interaction.MsgBox(string.Format("redirectPrompt", HttpResponse.Headers["Location"]), MsgBoxStyle.YesNo, "Title");
                        // This is a "302 Found" response. Prompt the user
                        // to see if it is okay to redirect.
                        if (result == MsgBoxResult.Yes)
                        {
                            // It is okay.  Set the new location and
                            // try again.
                            webServiceUrl = new Uri(webServiceUrl, HttpResponse.Headers["Location"]);
                            button1_Click(sender, e);
                            return;
                        }
                    }
                }
                throw we;
            }

            label1.Text = "Result: " + Convert.ToString(ret);
        }

    }
}
