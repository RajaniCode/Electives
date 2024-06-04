<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008GridViewClientSideRowSelection._Default" EnableEventValidation="false"%>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    
<link id="cssSheet" rel="stylesheet" type="text/css" href="CSS/gridCSS.css"/> 

<script language="javascript" type="text/javascript">
var oldgridSelectedColor;



function setMouseOverColor(element) {

    oldgridSelectedColor = element.style.backgroundColor;
    element.style.backgroundColor='yellow';
    element.style.cursor='hand';
    element.style.textDecoration='underline';
}

function setMouseOutColor(element) {

    element.style.backgroundColor=oldgridSelectedColor;
    element.style.textDecoration='none';
}

</script>

</head>
<body>
    <form id="form1" runat="server">
    
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />     
    
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
    
     <div>    
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
            OnRowDataBound="GridView1_RowDataBound" OnSelectedIndexChanged="GridView1_SelectedIndexChanged" Width="80%">
            <FooterStyle CssClass="FooterStyle" />
            <RowStyle CssClass="RowStyle" />
            <HeaderStyle CssClass="HeaderStyle" />
            <AlternatingRowStyle CssClass="AlternateRowStyle" />            
            <Columns>
                <asp:CommandField ShowSelectButton="True" Visible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="number" HeaderText="number" SortExpression="number" />
                <asp:BoundField DataField="type" HeaderText="type" SortExpression="type" />
                <asp:BoundField DataField="low" HeaderText="low" SortExpression="low" />
                <asp:BoundField DataField="high" HeaderText="high" SortExpression="high" />
                <asp:BoundField DataField="status" HeaderText="status" SortExpression="status" />
            </Columns>
        </asp:GridView>
        <br />
    </div>
    
    <div>
        <br />
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:masterConnectionString %>"
            SelectCommand="select top 10 * from dbo.spt_values"></asp:SqlDataSource>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        <span id="MessageBrowser" enableviewstate="false" runat="server" />
        <br />
        <span id="MessageCSS" enableviewstate="false" runat="server" />
    </div>

	</ContentTemplate>
	</asp:UpdatePanel>    
	 
    </form>
</body>
</html>
