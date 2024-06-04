<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
     Enter Product Name:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    <asp:Button ID="Button1" runat="server" Text="Search" />
   

    <asp:LinqDataSource ID="LinqDataSource1" runat="server" 
        ContextTypeName="DataClassesDataContext" EntityTypeName="" 
        Select="new (ProductID, ProductName)" TableName="Products">
    </asp:LinqDataSource>
    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
        DataSourceID="LinqDataSource1">
        <Columns>
            <asp:BoundField DataField="ProductID" HeaderText="ProductID" ReadOnly="True" 
                SortExpression="ProductID" />
            <asp:BoundField DataField="ProductName" HeaderText="ProductName" 
                ReadOnly="True" SortExpression="ProductName" />
        </Columns>
    </asp:GridView>
    <asp:QueryExtender ID="QueryExtender1" runat="server" TargetControlID="LinqDataSource1">
    <asp:SearchExpression SearchType="StartsWith"  DataFields="ProductName">
  <asp:ControlParameter ControlID="TextBox1" />
</asp:SearchExpression>
    </asp:QueryExtender>
    </form>
</body>
</html>
