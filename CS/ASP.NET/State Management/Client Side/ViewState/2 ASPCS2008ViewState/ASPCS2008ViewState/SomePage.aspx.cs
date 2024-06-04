using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008ViewState
{
    public partial class SomePage : System.Web.UI.Page
    {
        private int Counter
        {
            get
            {
                object Instance = ViewState["Counter"];
                return (Instance == null) ? 0 : (int)Instance;
            }
            set
            {
                ViewState["Counter"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Counter++;
            TextBox1.Text = Counter.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Page != null)
            {
                Page.RegisterRequiresViewStateEncryption();
            }
        }

    }
}
