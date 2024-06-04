<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication7._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
        OnDataBound="GridView1_DataBound" AutoGenerateColumns="False" DataKeyNames="CustomerID"
        DataSourceID="SqlDataSource1">
        <Columns>
            <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" ReadOnly="True" SortExpression="CustomerID" />
            <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" SortExpression="CompanyName" />
            <asp:BoundField DataField="ContactName" HeaderText="ContactName" SortExpression="ContactName" />
            <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" SortExpression="ContactTitle" />
            <asp:BoundField DataField="Address" HeaderText="Address" SortExpression="Address" />
            <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
        </Columns>
        <PagerTemplate>
            <table width="100%">
                <tr>
                    <td style="text-align: right">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server" />
                    </td>
                </tr>
            </table>
        </PagerTemplate>
    </asp:GridView>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:NorthwindConnectionString %>"
        SelectCommand="SELECT [CustomerID], [CompanyName], [ContactName], [ContactTitle], [Address], [City] FROM [Customers]">
    </asp:SqlDataSource>
    </form>
</body>
</html>
