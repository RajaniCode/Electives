using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

public partial class _Default : System.Web.UI.Page
{

    protected void Page_Init(object sender, EventArgs e)
    {
        Page.InitComplete += new EventHandler(Page_InitComplete);

    }

    protected void Page_InitComplete(object sender, System.EventArgs e)
    {
        if (WebPartManager1.Personalization.CanEnterSharedScope)
        {
            if (WebPartManager1.Personalization.Scope == PersonalizationScope.User)
                RadioButton1.Checked = true;
            else
                RadioButton2.Checked = true;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        WebPartManager1.Personalization.ResetPersonalizationState();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.EditDisplayMode;
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        WebPartManager1.DisplayMode = WebPartManager.BrowseDisplayMode;
    }
    protected void RadioButton1_CheckedChanged(object sender, EventArgs e)
    {
        if (WebPartManager1.Personalization.Scope == PersonalizationScope.Shared)
            WebPartManager1.Personalization.ToggleScope();

    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        if (WebPartManager1.Personalization.CanEnterSharedScope &&
            WebPartManager1.Personalization.Scope == PersonalizationScope.User)
            WebPartManager1.Personalization.ToggleScope();

    }
}