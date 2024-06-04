using System;
using System.Collections;
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

using CrystalDecisions.Shared;

namespace ASPCS2008CrystalReportsXIR2
{
    public partial class _Default : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            CrystalReportViewer1.ParameterFieldInfo.Clear();
            CrystalReportViewer1.ReportSource = Server.MapPath(@"\Reports\CrystalReportsXIR2.rpt");

            // CrystalReportViewer1.ReportSource = Request.MapPath(@"\Reports\CrystalReportsXIR2.rpt");

            // CrystalReportViewer1.ReportSource = Request.ApplicationPath + @"\Reports\CrystalReportsXIR2.rpt";
                        
            ParameterFields ParamFields = this.CrystalReportViewer1.ParameterFieldInfo;
            ParameterField Parameter = new ParameterField();
            Parameter.Name = "ParameterField";
            ParameterDiscreteValue DiscreteValue = new ParameterDiscreteValue();
            DiscreteValue.Value = "This is the parameter!";
            Parameter.CurrentValues.Add(DiscreteValue);
            ParamFields.Add(Parameter);

            CrystalReportViewer1.ShowFirstPage();           
        }
    }
}


/*
web.config
<add assembly="CrystalDecisions.Web, Version=11.5.3300.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"/>
 TO REMOVE WARNING:
 DELETE: inheritInChildApplications="true"
*/