using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using AjaxControlToolkit;

public partial class _Default : System.Web.UI.Page 
{
protected void Page_Load(object sender, EventArgs e)
{
    AccordionPane newAccordion = new AccordionPane();
    newAccordion.HeaderContainer.Controls.Add(new LiteralControl("Pane 5"));
    newAccordion.ContentContainer.Controls.Add(new
              LiteralControl("This pane was added using Code Behind"));
    AccordionCtrl.Panes.Add(newAccordion);
}
}
