<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="GridViewPathBinding._Default" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
    
<%@ Register Assembly="GridViewPathBinding" Namespace="GridViewPathBinding" TagPrefix="mc" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView runat="server" ID="gridView" DataSourceID="entityDs" AllowPaging="true" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="SalesOrderID" HeaderText="Order ID" />
                <mc:NavigationBoundField DataField="Product.Subcategory.Category.Name" HeaderText="Category" />                
                <mc:NavigationBoundField DataField="Product.Subcategory.Name" HeaderText="Subcategory" />                                
                <mc:NavigationBoundField DataField="Product.Name" HeaderText="Product" />
                <asp:BoundField DataField="OrderQty" HeaderText="Quantity" />
                <asp:BoundField DataField="UnitPrice" HeaderText="Unit Price" />
                <asp:BoundField DataField="LineTotal" HeaderText="Line Total" />
            </Columns>
        </asp:GridView>
        <asp:EntityDataSource ID="entityDs" runat="server" 
            ContextTypeName="GridViewPathBinding.Data.AdventureWorksEntities" EntitySetName="OrderDetails"
            AutoPage="true" Include="Product, Product.Subcategory, Product.Subcategory.Category">
        </asp:EntityDataSource>
        
    </div>
    </form>
</body>
</html>
