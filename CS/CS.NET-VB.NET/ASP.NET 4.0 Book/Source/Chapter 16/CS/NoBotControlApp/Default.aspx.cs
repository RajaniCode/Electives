using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (NoBot1.IsValid())
        {
            Label3.Text = "User appears as a bot";
        }
        else
        {
            Label3.Text = "User appears as a Nobot";
        }

} 
    

    protected void NoBot1_GenerateChallengeAndResponse(object sender, NoBotEventArgs e)
    {
        Random sec = new Random();
        int first = sec.Next(60);
        int second = sec.Next(60);
        int third = sec.Next(60);
        e.ChallengeScript = String.Format("eval('{0}+{1}+{2}')", first, second, third);
        e.RequiredResponse = Convert.ToString(first + second + third);
    }
}