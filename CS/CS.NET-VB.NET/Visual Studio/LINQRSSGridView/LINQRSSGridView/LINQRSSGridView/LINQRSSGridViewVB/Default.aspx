<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Default.aspx.vb" Inherits="LINQRSSGridViewVB._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
<title>RSS Feed using ASP.NET and LINQ</title>
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
<asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
<Columns>
<asp:TemplateField HeaderText="Title">
 <ItemTemplate>
  <a href='<%# Eval("link") %>' target="_blank"><%# Eval("title") %></a>
 </ItemTemplate>
</asp:TemplateField>
<asp:BoundField DataField="description" HtmlEncode="false" 
   HeaderText="Description" />
<asp:BoundField DataField="Author" 
   HeaderText="Author" />
</Columns>
</asp:GridView>               
    <br />               
</div>
<asp:Button ID="btnFetchRss" runat="server" onclick="btnFetchRss_Click" 
    Text="Button" />
    
</form>
</body>
</html>
