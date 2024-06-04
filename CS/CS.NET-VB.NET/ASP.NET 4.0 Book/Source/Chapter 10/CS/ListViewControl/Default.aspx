<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:ListView ID="ListView1" runat="server" DataSourceID="SqlDataSource1" DataKeyNames="ProductID" >
        <AlternatingItemTemplate>
                <li style="background-color: #FFFFFF;color: #284775;">ProductID:
                    <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                    <br />
                    ProductName:
                    <asp:Label ID="ProductNameLabel" runat="server" 
                        Text='<%# Eval("ProductName") %>' />
                    <br />
                     QuantityPerUnit:
                    <asp:Label ID="QuantityPerUnitLabel" runat="server" 
                        Text='<%# Eval("QuantityPerUnit") %>' />
                    <br />
                    UnitPrice:
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    <br />
                    UnitsInStock:
                    <asp:Label ID="UnitsInStockLabel" runat="server" 
                        Text='<%# Eval("UnitsInStock") %>' />
                    <br />
                   
                </li>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <li style="background-color: #999999;">ProductID:
                    <asp:Label ID="ProductIDLabel1" runat="server" 
                        Text='<%# Eval("ProductID") %>' />
                    <br />
                    ProductName:
                    <asp:TextBox ID="ProductNameTextBox" runat="server" 
                        Text='<%# Bind("ProductName") %>' />
                    <br />
                    QuantityPerUnit:
                    <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" 
                        Text='<%# Bind("QuantityPerUnit") %>' />
                    <br />
                     UnitPrice:
                    <asp:TextBox ID="UnitPriceTextBox" runat="server" 
                        Text='<%# Bind("UnitPrice") %>' />
                    <br />
                    UnitsInStock:
                    <asp:TextBox ID="UnitsInStockTextBox" runat="server" 
                        Text='<%# Bind("UnitsInStock") %>' />
                    <br />
                    
                    <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                        Text="Update" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Cancel" />
                </li>
            </EditItemTemplate>
            <EmptyDataTemplate>
                No data was returned.
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <li style="">ProductName:
                    <asp:TextBox ID="ProductNameTextBox" runat="server" 
                        Text='<%# Bind("ProductName") %>' />
                    <br />
                    QuantityPerUnit:
                    <asp:TextBox ID="QuantityPerUnitTextBox" runat="server" 
                        Text='<%# Bind("QuantityPerUnit") %>' />
                    <br />
                    UnitPrice:
                    <asp:TextBox ID="UnitPriceTextBox" runat="server" 
                        Text='<%# Bind("UnitPrice") %>' />
                    <br />UnitsInStock:
                    <asp:TextBox ID="UnitsInStockTextBox" runat="server" 
                        Text='<%# Bind("UnitsInStock") %>' />
                    <br />
                    <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                        Text="Insert" />
                    <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                        Text="Clear" />
                </li>
            </InsertItemTemplate>
            <ItemSeparatorTemplate>
<br />
            </ItemSeparatorTemplate>
            <ItemTemplate>
                <li style="background-color: #E0FFFF;color: #333333;">ProductID:
                    <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                    <br />
                    ProductName:
                    <asp:Label ID="ProductNameLabel" runat="server" 
                        Text='<%# Eval("ProductName") %>' />
                    <br />
                     QuantityPerUnit:
                    <asp:Label ID="QuantityPerUnitLabel" runat="server" 
                        Text='<%# Eval("QuantityPerUnit") %>' />
                           <br />
                    UnitPrice:
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    <br />
                    UnitsInStock:
                    <asp:Label ID="UnitsInStockLabel" runat="server" 
                        Text='<%# Eval("UnitsInStock") %>' />
                 
                   
                    <br />
                </li>
            </ItemTemplate>
            <LayoutTemplate>
                <ul ID="itemPlaceholderContainer" runat="server" 
                    style="font-family: Verdana, Arial, Helvetica, sans-serif;">
                    <li runat="server" id="itemPlaceholder" />
                </ul>
                <div style="text-align: center;background-color: #5D7B9D;font-family: Verdana, Arial, Helvetica, sans-serif;color: #FFFFFF;">
                </div>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <li style="background-color: #E2DED6;font-weight: bold;color: #333333;">ProductID:
                    <asp:Label ID="ProductIDLabel" runat="server" Text='<%# Eval("ProductID") %>' />
                    <br />
                    ProductName:
                    <asp:Label ID="ProductNameLabel" runat="server" 
                        Text='<%# Eval("ProductName") %>' />
                    <br />
                     QuantityPerUnit:
                    <asp:Label ID="QuantityPerUnitLabel" runat="server" 
                        Text='<%# Eval("QuantityPerUnit") %>' />
                    <br />
                    UnitPrice:
                    <asp:Label ID="UnitPriceLabel" runat="server" Text='<%# Eval("UnitPrice") %>' />
                    <br />
                    UnitsInStock:
                    <asp:Label ID="UnitsInStockLabel" runat="server" 
                        Text='<%# Eval("UnitsInStock") %>' />
                    <br />                   
                </li>
            </SelectedItemTemplate>

        </asp:ListView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
            ConnectionString="<%$ ConnectionStrings:northwndConnectionString %>" 
            SelectCommand="SELECT [ProductID], [ProductName], [QuantityPerUnit], [UnitPrice], [UnitsInStock] FROM [Alphabetical list of products]">
        </asp:SqlDataSource>
    
    </div>
    <asp:DataPager ID="DataPager1" runat="server" PagedControlID="ListView1">
        <Fields>
            <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                ShowNextPageButton="False" ShowPreviousPageButton="False" />
            <asp:NumericPagerField />
            <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                ShowNextPageButton="False" ShowPreviousPageButton="False" />
        </Fields>
    </asp:DataPager>
    </form>
</body>
</html>
