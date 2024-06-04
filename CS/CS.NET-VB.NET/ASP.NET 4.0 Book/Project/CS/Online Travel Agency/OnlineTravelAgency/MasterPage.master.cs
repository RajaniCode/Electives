using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {   
        
        if (LoginName1.Page.User.Identity.IsAuthenticated)
        {
            hlChangePassowrd.Visible = true;
            LoginStatus1.Visible = true;
            Login1.Visible = false;
        }
        else
        {
            hlChangePassowrd.Visible = false;
            LoginStatus1.Visible = false;
            Login1.Visible = true;
        }
    }

    //[System.Web.Services.WebMethodAttribute(), System.Web.Script.Services.ScriptMethodAttribute()]
    //public static AjaxControlToolkit.Slide[] GetImages(string contextKey)
    //{
        
    //    new AjaxControlToolkit.Slide("Resources/Cars1.jpg", "First image of my album", "First Image");
    //    new AjaxControlToolkit.Slide("Resources/Cars2.jpg", "Second image of my album", "Second Image");
    //    new AjaxControlToolkit.Slide("Resources/Cars3.jpg", "Third image of my album", "Third Image");
    //    new AjaxControlToolkit.Slide("Resources/Cars4.jpg", "Fourth image of my album", "Fourth Image");
    //    return default(AjaxControlToolkit.Slide[]);


    //    //AjaxControlToolkit.Slide[] slides = new AjaxControlToolkit.Slide[4];
    //    //slides[0] = new AjaxControlToolkit.Slide("Resources/Cars1.jpg", "First image of my album", "First Image");
    //    //slides[1] = new AjaxControlToolkit.Slide("Resources/Cars2.jpg", "Second image of my album", "Second Image");
    //    //slides[2] = new AjaxControlToolkit.Slide("Resources/Cars3.jpg", "Third image of my album", "Third Image");
    //    //slides[3] = new AjaxControlToolkit.Slide("Resources/Cars4.jpg", "Fourth image of my album", "Fourth Image");
    //    //return (slides);
    //}    
    protected void LoginButton_Click(object sender, EventArgs e)
    {

    }
}
