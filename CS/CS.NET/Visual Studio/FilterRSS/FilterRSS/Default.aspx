<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Filter an RSS Feed using LINQ</title>
</head>
<body>
    <form id="form1" runat="server">
<div> 
    <asp:DropDownList ID="DropDownList1" runat="server" 
        onselectedindexchanged="DropDownList1_SelectedIndexChanged" 
        AutoPostBack="True">
    </asp:DropDownList> 
    <br /><br />
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
    <Columns>
        <asp:TemplateField HeaderText="Title">
         <ItemTemplate>
         <a href='<%# Eval("link") %>' target="_blank"><%# Eval("title") %></a>
         </ItemTemplate>
        </asp:TemplateField>
        <asp:BoundField DataField="Author" 
           HeaderText="Author" />
       <asp:BoundField DataField="description" HtmlEncode="false" 
               HeaderText="Description" />
    </Columns>
    </asp:GridView> 
</div>
    </form>
</body>
</html>
