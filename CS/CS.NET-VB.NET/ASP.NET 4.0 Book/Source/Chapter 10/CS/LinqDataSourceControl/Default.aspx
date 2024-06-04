<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
            ContextTypeName="DataClassesDataContext" EntityTypeName="" 
            Select="new (ProductID, ProductName, QuantityPerUnit, UnitPrice, UnitsInStock)" 
            TableName="Products">
        </asp:LinqDataSource>
    
    </div>
    <asp:GridView ID="GridView1" runat="server" DataSourceID="LinqDataSource1" 
        AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" 
                SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                ReadOnly="True" SortExpression="ProductName" />
            <asp:BoundField DataField="QuantityPerUnit" HeaderText="QuantityPerUnit" 
                ReadOnly="True" SortExpression="QuantityPerUnit" />
            <asp:BoundField DataField="UnitPrice" HeaderText="UnitPrice" ReadOnly="True" 
                SortExpression="UnitPrice" />
            <asp:BoundField DataField="UnitsInStock" HeaderText="UnitsInStock" 
                ReadOnly="True" SortExpression="UnitsInStock" />
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>
