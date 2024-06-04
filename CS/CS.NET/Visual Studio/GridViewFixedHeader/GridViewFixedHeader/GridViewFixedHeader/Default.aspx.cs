using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page 
{
    protected void GridView1_PreRender(object sender, EventArgs e)
    {
        ScrollT.UseAccessibleHeader = true;
        ScrollT.HeaderRow.TableSection = TableRowSection.TableHeader;
    }

    protected void Page_Load(object sender, EventArgs e)
    {

    }
}
