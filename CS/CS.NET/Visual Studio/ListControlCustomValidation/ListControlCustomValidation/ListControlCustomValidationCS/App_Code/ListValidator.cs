using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


namespace CustomListValidator
{
/// <summary>
/// Summary description for ListValidator
/// </summary>
public class ListValidator : BaseValidator
{
    public ListValidator()
    {

    }

    protected override bool ControlPropertiesValid() 
    {
        Control ctrl = FindControl(ControlToValidate) as ListControl; 
        return (ctrl != null); 
    }

    protected override bool EvaluateIsValid()
    {
        return this.CheckIfItemIsChecked();
    }

    protected bool CheckIfItemIsChecked()
    {
        ListControl listItemValidate = ((ListControl)this.FindControl(this.ControlToValidate));
        foreach (ListItem listItem in listItemValidate.Items)
        {
            if (listItem.Selected == true)
                return true;
        }
        return false;
    }

    protected override void OnPreRender(EventArgs e)
    {
        // Determines whether the validation control can be rendered
        // for a newer ("uplevel") browser.
        // check if client-side validation is enabled.
        if (this.DetermineRenderUplevel() && this.EnableClientScript)
        {
            Page.ClientScript.RegisterExpandoAttribute(this.ClientID, "evaluationfunction", "CheckIfListChecked");
            this.CreateJavaScript();
        }
        base.OnPreRender(e);
    }

    protected void CreateJavaScript() 
    {
        StringBuilder sb = new StringBuilder();
        sb.Append(@"<script type=""text/javascript"">function CheckIfListChecked(ctrl){");
        sb.Append(@"var chkBoxList = document.getElementById(document.getElementById(ctrl.id).controltovalidate);");
        sb.Append(@"var chkBoxCount= chkBoxList.getElementsByTagName(""input"");");
        sb.Append(@"for(var i=0;i<chkBoxCount.length;i++){");
        sb.Append(@"if(chkBoxCount.item(i).checked){");
        sb.Append(@"return true; }");
        sb.Append(@"}return false; ");
        sb.Append(@"}</script>");
        Page.ClientScript.RegisterClientScriptBlock(GetType(),"JSScript", sb.ToString()); 
    }
}
}