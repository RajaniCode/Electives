using System;
using System.Text;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
    public string strChart;
    StringBuilder strbld = new StringBuilder();
    protected void Page_Load(object sender, EventArgs e)
    {
        //strChart = "http://chart.apis.google.com/chart?cht=p3&chd=s:hW&chs=250x100&chl=Hello|World";
        strbld.Append("http://chart.apis.google.com/chart?cht=p3&chd=s:ABDDFKMPUYdflz5&chs=200x50&");                       
        strbld.Append("chl=YES(45%)|NO(20%)|CANT(35%)");
        strChart = strbld.ToString();
        this.DataBind();

    }

    
  

}
