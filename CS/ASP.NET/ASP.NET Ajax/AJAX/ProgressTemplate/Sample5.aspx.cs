using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Text;

public partial class Sample5 : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void simulateButton_Click(object sender, EventArgs e)
    {
        //show a message;
        StringBuilder loadInformationMessage = new StringBuilder();

        for (int counter = 1; counter < 100; counter++)
        {
            loadInformationMessage.Append(
                                    String.Format("{0}&nbsp;&nbsp;&nbsp;{1}<br />"
                                    , counter
                                    , DateTime.Now.AddDays(counter)));
        }

        messageLabel.Text = loadInformationMessage.ToString();

        //sleep for 5 seconds
        Thread.Sleep(5000);
    }
}