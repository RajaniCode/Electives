<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Paging._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            DataSourceID="ObjectDataSource1" AllowPaging="True">
            <Columns>
                <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" 
                    SortExpression="CustomerID" />
                <asp:BoundField DataField="CompanyName" HeaderText="CompanyName" 
                    SortExpression="CompanyName" />
                <asp:BoundField DataField="ContactName" HeaderText="ContactName" 
                    SortExpression="ContactName" />
                <asp:BoundField DataField="ContactTitle" HeaderText="ContactTitle" 
                    SortExpression="ContactTitle" />
                <asp:BoundField DataField="Address" HeaderText="Address" 
                    SortExpression="Address" />
                <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
                <asp:BoundField DataField="Region" HeaderText="Region" 
                    SortExpression="Region" />
                <asp:BoundField DataField="PostalCode" HeaderText="PostalCode" 
                    SortExpression="PostalCode" />
                <asp:BoundField DataField="Country" HeaderText="Country" 
                    SortExpression="Country" />
                <asp:BoundField DataField="Phone" HeaderText="Phone" SortExpression="Phone" />
                <asp:BoundField DataField="Fax" HeaderText="Fax" SortExpression="Fax" />
            </Columns>
        </asp:GridView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" 
            SelectMethod="GetCustomers" TypeName="Paging.Northwind" 
            EnablePaging="True" SelectCountMethod="GetCustomerCount">
            <SelectParameters>
                <asp:Parameter Name="maximumRows" Type="Int32" />
                <asp:Parameter Name="startPageIndex" Type="Int32" />
                <asp:Parameter Name="startRowIndex" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    </form>
</body>
</html>
