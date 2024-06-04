using System;
using System.Xml.Linq;

public partial class _Default : System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnGetLoc_Click(object sender, EventArgs e)
    {
        String url = String.Empty;        

        if (txtIP.Text.Trim() != String.Empty)
        {
            url = String.Format("http://iplocationtools.com/ip_query2.php?ip={0}", txtIP.Text.Trim());
            XDocument xDoc = XDocument.Load(url);
            if (xDoc == null | xDoc.Root == null)
            {
                throw new ApplicationException("Data is not Valid");
            }

            Xml1.TransformSource = "IP.xslt";
            Xml1.DocumentContent = xDoc.ToString();
        }       
    }
}

