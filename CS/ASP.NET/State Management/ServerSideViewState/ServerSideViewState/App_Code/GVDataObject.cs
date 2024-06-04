using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

/// <summary>
/// Summary description for GVDataObject
/// </summary>
[Serializable]
public class GVDataObject
{
    public string Field1 { get; set; }
    public string Field2 { get; set; }
    public string Field3 { get; set; }
}
