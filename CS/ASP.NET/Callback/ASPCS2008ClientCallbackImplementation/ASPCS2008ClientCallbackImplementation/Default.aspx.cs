using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008ClientCallbackImplementation
{
    public partial class _Default : System.Web.UI.Page, System.Web.UI.ICallbackEventHandler // Note
    {
        protected System.Collections.Specialized.ListDictionary catalog;
        protected String returnValue;
        protected void Page_Load(object sender, EventArgs e)
        {
            String cbReference =
                Page.ClientScript.GetCallbackEventReference(this,
                "arg", "ReceiveServerData", "context");
            String callbackScript;
            callbackScript = "function CallServer(arg, context)" +
                "{ " + cbReference + ";}";
            Page.ClientScript.RegisterClientScriptBlock(this.GetType(),
                "CallServer", callbackScript, true);

            catalog = new System.Collections.Specialized.ListDictionary();
            catalog.Add("monitor", 12);
            catalog.Add("laptop", 10);
            catalog.Add("keyboard", 23);
            catalog.Add("mouse", 17);

            ListBox1.DataSource = catalog;
            ListBox1.DataTextField = "key";
            ListBox1.DataBind();

        }

        public void RaiseCallbackEvent(String eventArgument)
        {
            if (catalog[eventArgument] == null)
            {
                returnValue = "-1";
            }
            else
            {
                returnValue = catalog[eventArgument].ToString();
            }
        }
        public String GetCallbackResult()
        {
            return returnValue;
        }
    }
}
