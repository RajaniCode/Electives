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

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        TextArea1.Attributes["onblur"] = "javascript:alert('TextArea lost the focus');";
    }
    protected void Select1_ServerChange(object sender, EventArgs e)
    {
        span1.InnerHtml = "You have selected " + Select1.Value.ToString() + " color in dropdown list.";
    }
    protected void Checkbox1_ServerChange(object sender, EventArgs e)
    {
        if (Checkbox1.Checked == true)
            span1.InnerHtml = "CheckBox is checked";
        else
            span1.InnerHtml = "CheckBox is unchecked";

    }
    protected void Radio1_ServerChange(object sender, EventArgs e)
    {
        if (Radio1.Checked == true)
            span1.InnerHtml = "Radio button is selected";
        else
            span1.InnerHtml = "Radio button is not selected";

    }
    protected void TextArea1_ServerChange(object sender, EventArgs e)
    {
        if (Convert.ToBoolean(TextArea1.Value == ""))
            span1.InnerHtml = "TextArea is empty";
        else
            span1.InnerHtml = "There is some text in TextArea";

    }
    protected void Select2_ServerChange(object sender, EventArgs e)
    {
        int loopindex;
        span1.InnerHtml = "You have selected ";
        for (loopindex = 0; loopindex <= Select2.Items.Count - 1; loopindex++)
        {
            if (Select2.Items[loopindex].Selected)
                span1.InnerHtml += Select2.Items[loopindex].Value.ToString() + " ";
        }

    }
    protected void Button1_ServerClick(object sender, EventArgs e)
    {
        span2.InnerHtml = "Submit button is clicked.";
    }
}
