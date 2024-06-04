using System;
using System.Collections.Generic;
using System.Web.Services;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static List<Patient> getAllPatientList()
    {
        Patient pObj = new Patient();
        return pObj.Lists();
    }
}
