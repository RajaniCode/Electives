using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

// ERROR: Not supported in C#: OptionDeclaration // ERROR: Not supported in C#: OptionDeclaration using System.Data;
using System.Xml;
using System.Net;
using System.IO;

namespace ContentLoading
{
    partial class RSSFeed : System.Web.UI.UserControl
    {

        public string URL
        {
            //Link to the RSS XML page
            set
            {
                rssData.Url = value;
            }
        }

        public string RSSTitle
        {
            //Create a header for the RSS block
            set
            {
                lblHeader.Text = value;
            }
        }

        protected void DisplayRSS(object s, EventArgs e)
        {
            try
            {

                //Download the RSS feed
                WebClient wc;
                wc = new WebClient();
                wc.Proxy.Credentials = System.Net.CredentialCache.DefaultNetworkCredentials;
                byte[] feed;
                feed = wc.DownloadData(rssData.Url);


                //Populate the RSS content block
                rptRSS.DataSource = rssData;
                rptRSS.DataBind();

                //Display the loaded content block
                mvRSS.ActiveViewIndex = 1;
            }
            catch (Exception ex)
            {
                //Diplay the "unable to load" content block
                mvRSS.ActiveViewIndex = 2;
            }

            //Important! Turn the timer off or it will continuously run
            //this routine. You could add an increased value to the
            //Interval setting if you want it to try again but, at some
            //point you need to tell it to stop--unless you are purposefully
            //cycling through content.
            timerRSS.Enabled = false;
        }
    }
}