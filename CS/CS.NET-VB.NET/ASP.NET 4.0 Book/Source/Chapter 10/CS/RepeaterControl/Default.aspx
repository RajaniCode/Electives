<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <table>
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource1">
<HeaderTemplate>
		<tr style="background-color: Gray">
		<th>
		ProductId
		</th>
		<th>
		ProductName
		</th>
		<th>
		UnitPrice
		</th>
		<th>
		UnitsInStock
		</th>
		<th>
		UnitsOnOrder
		</th>
		</tr>
		</HeaderTemplate>
		<ItemTemplate>
		<tr>
		<td>
		<%#DataBinder.Eval(Container, "DataItem.ProductID")%>
		</td>
		<td>
		<%#DataBinder.Eval(Container, "DataItem.ProductName")%>
		</td>
		<td>
		<%#DataBinder.Eval(Container, "DataItem.UnitPrice")%>
		</td>
		<td>
		<%#DataBinder.Eval(Container, "DataItem.UnitsInStock")%>
		</td>
		<td>
		<%#DataBinder.Eval(Container, "DataItem.UnitsOnOrder")%>
		</td>
		</tr>
		</ItemTemplate>
		<AlternatingItemTemplate>
		<tr>
		<td style="background-color: Gray">
		<%#DataBinder.Eval(Container, "DataItem.ProductID")%>
		</td>
		<td style="background-color: Gray">
		<%#DataBinder.Eval(Container, "DataItem.ProductName")%>
		</td>
		<td style="background-color: Gray">
		<%#DataBinder.Eval(Container, "DataItem.UnitPrice")%>
		</td>
		<td style="background-color: Gray">
		<%#DataBinder.Eval(Container, "DataItem.UnitsInStock")%>
		</td>
		<td style="background-color: Gray">
		<%#DataBinder.Eval(Container, "DataItem.UnitsOnOrder")%>
		</td>
		</tr>
		</AlternatingItemTemplate>
		</asp:Repeater>
		</table>
   
    
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
            SelectCommand="SELECT [ProductID], [ProductName], [UnitPrice], [UnitsInStock], [UnitsOnOrder] FROM [Alphabetical list of products]">
        </asp:SqlDataSource>
   
    
    </div>
    
    
   
    
    
    </form>
</body>
</html>
