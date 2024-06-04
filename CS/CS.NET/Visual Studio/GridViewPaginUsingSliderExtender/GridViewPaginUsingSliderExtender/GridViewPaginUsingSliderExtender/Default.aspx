<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title>How to page a GridView Using an ASP.NET AJAX Slider Extender</title>
<style type="text/css">
body
{
font: normal 11px auto "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;    
background-color: #ffffff;
color: #4f6b72;       
}

th {
font: bold 11px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
color: #4f6b72;
border-right: 1px solid #C1DAD7;
border-bottom: 1px solid #C1DAD7;
border-top: 1px solid #C1DAD7;
letter-spacing: 2px;
text-transform: uppercase;
text-align: left;
padding: 6px 6px 6px 12px;
background: #D5EDEF;
}

td {
border-right: 1px solid #C1DAD7;
border-bottom: 1px solid #C1DAD7;
background: #fff;
padding: 6px 6px 6px 12px;
color: #4f6b72;
}

td.alt
{
background: #F5FAFA;
color: #797268;
}

td.boldtd
{
font: bold 13px "Trebuchet MS", Verdana, Arial, Helvetica, sans-serif;
background: #D5EDEF;
color: #797268;
}
</style>
</head>
<body>
<form id="form1" runat="server">
<div>
<asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<asp:UpdatePanel ID="UpdPanel1" runat="server">
<ContentTemplate>

<asp:GridView ID="GridView1" runat="server" AllowPaging="true" AutoGenerateColumns="false"
DataKeyNames="ProductID" DataSourceID="SqlDataSource1" 
OnDataBound="GridView1_DataBound">
    <Columns>
    <asp:BoundField DataField="ProductName" HeaderText="ProductName" ReadOnly="true"
    SortExpression="ProductName" />
    <asp:BoundField DataField="QuantityPerUnit" HeaderText="Qty" ReadOnly="true"
    SortExpression="QuantityPerUnit" />
    <asp:BoundField DataField="UnitPrice" HeaderText="PricePerUnit" ReadOnly="true"
    SortExpression="UnitPrice" />
    <asp:BoundField DataField="UnitsInStock" HeaderText="StockQty" ReadOnly="true"
    SortExpression="UnitsInStock" />
    <asp:BoundField DataField="CategoryName" HeaderText="Category" ReadOnly="true"
    SortExpression="CategoryName" />
    </Columns>
    <PagerTemplate>
    <asp:TextBox ID="txtSlide" runat="server" Text='<%# GridView1.PageIndex + 1 %>'
     AutoPostBack="true" OnTextChanged="txtSlide_Changed"/>               
    <cc1:SliderExtender ID="ajaxSlider" runat="server"
    TargetControlID="txtSlide"                            
    Orientation="Horizontal"                                     
    /> 
    <asp:Label ID="lblPage" runat="server" Text='<%# "Page " + (GridView1.PageIndex + 1) + " of " + GridView1.PageCount %>' />
    </PagerTemplate>
</asp:GridView>

</ContentTemplate>
</asp:UpdatePanel>
<asp:SqlDataSource ID="SqlDataSource1" runat="server" 
ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>" 
SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock], [CategoryName] FROM [Alphabetical list of products]">
</asp:SqlDataSource>

</div>
</form>
</body>
</html>
