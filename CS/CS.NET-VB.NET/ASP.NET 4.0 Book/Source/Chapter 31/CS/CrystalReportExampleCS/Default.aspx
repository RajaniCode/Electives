<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=14.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CrystalReportExample</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportViewer ID="CrystalReportViewer1" runat="server" AutoDataBind="True"
            Height="1039px" ReportSourceID="CrystalReportSource1" Width="901px" />
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReport1.rpt">
            </Report>
        </CR:CrystalReportSource>
    
    </div>
    </form>
</body>
</html>

