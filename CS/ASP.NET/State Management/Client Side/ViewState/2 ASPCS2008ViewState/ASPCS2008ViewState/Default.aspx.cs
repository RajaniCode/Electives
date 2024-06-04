using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ASPCS2008ViewState
{
    public partial class _Default : System.Web.UI.Page
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

        private int IsPostBackCounter
        {
            get
            {
                object Instance = ViewState["IsPostBackCounter"];
                return (Instance == null) ? 0 : (int)Instance;
            }
            set
            {
                ViewState["IsPostBackCounter"] = value;
            }
        }

        private int NotIsPostBackCounter
        {
            get
            {
                object Instance = ViewState["NotIsPostBackCounter"];
                return (Instance == null) ? 0 : (int)Instance;
            }
            set
            {
                ViewState["NotIsPostBackCounter"] = value;
            }
        }

        private int NotIsCallbackCounter
        {
            get
            {
                object Instance = ViewState["NotIsCallbackCounter"];
                return (Instance == null) ? 0 : (int)Instance;
            }
            set
            {
                ViewState["NotIsCallbackCounter"] = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            IsPostBackCounter++;
            TextBox2.Text = IsPostBackCounter.ToString();

            if (!IsPostBack)
            {
                NotIsPostBackCounter++;
                TextBox3.Text = NotIsPostBackCounter.ToString();
            }

            if (!IsCallback)
            {
                NotIsCallbackCounter++;

                TextBox4.Text = NotIsCallbackCounter.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Counter++;
            TextBox1.Text = Counter.ToString();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("SomePage.aspx");
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            if (Page != null)
            {
                Page.RegisterRequiresViewStateEncryption();
            }
        }

        protected override object SaveViewState()
        {           
            object obj = base.SaveViewState();

            if (Page != null)
            {
                if (Page.ViewStateEncryptionMode == ViewStateEncryptionMode.Never)
                {
                    throw new Exception("ViewStateEncryptionMode.Never not allowed when using the SensitiveDataList control.");
                }
            }

            return obj;
        }  
    }
}

// http://msdn.microsoft.com/en-us/library/aa479501.aspx