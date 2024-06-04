<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
    Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>
<%@ Register TagPrefix="CR" Namespace="CrystalDecisions.Web" Assembly="CrystalDecisions.Web, Version=14.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>CrystalReportsMRV</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>   
       
        
    <rsweb:ReportViewer ID="ReportViewer1" runat="server" Font-Names="Verdana" 
            Font-Size="8pt" InteractiveDeviceInfos="(Collection)" 
            WaitMessageFont-Names="Verdana" WaitMessageFont-Size="14pt" Width="559px">
            <LocalReport ReportPath="Report1.rdlc">
                <DataSources>
                    <rsweb:ReportDataSource DataSourceId="ObjectDataSource1" Name="DataSet1" />
                </DataSources>
            </LocalReport>
        </rsweb:ReportViewer>
    
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetData" 
            TypeName="northwndDataSetTableAdapters.ProductsTableAdapter">
        </asp:ObjectDataSource>
         <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <br />
        
    </div>
    </form>
</body>
</html>
