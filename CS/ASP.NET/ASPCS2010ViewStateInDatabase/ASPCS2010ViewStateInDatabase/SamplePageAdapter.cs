using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary> 
/// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
/// This class is the page adapter for the application. 
///  
/// Created on 26/6/2007. 
/// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
/// </summary> 
public class SamplePageAdapter : System.Web.UI.Adapters.PageAdapter
{

    /// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    /// <summary> 
    /// Gets the state persister for the page. 
    /// </summary> 
    /// <remarks> 
    ///         <author></author> 
    ///         <creation>Wednesday, 30 May 2007</creation> 
    /// </remarks> 
    /// ----------------------------------------------------------------------------------------------------------------------------------------------------------------- 
    public override PageStatePersister GetStatePersister()
    {
        return new SamplePageStatePersister(Page);
    }

}