<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=14.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <CR:CrystalReportPartsViewer ID="CrystalReportPartsViewer1" runat="server" 
            AutoDataBind="True" ReportSourceID="CrystalReportSource1" />
    
        <CR:CrystalReportSource ID="CrystalReportSource1" runat="server">
            <Report FileName="CrystalReport1.rpt">
            </Report>
        </CR:CrystalReportSource>

    
    
    </div>
    </form>
</body>
</html>
