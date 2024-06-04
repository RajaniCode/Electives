<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" EnablePaging="True" 
            SelectCountMethod="GetCustomerCount" SelectMethod="GetCustomers" 
            TypeName="WebApplication1.Data.Customer" 
            EnableViewState="False">
            <UpdateParameters>
                <asp:Parameter Name="CustomerID" Type="String" />
                <asp:Parameter Name="CompanyName" Type="String" />
                <asp:Parameter Name="ContactName" Type="String" />
                <asp:Parameter Name="ContactTitle" Type="String" />
                <asp:Parameter Name="Address" Type="String" />
                <asp:Parameter Name="City" Type="String" />
                <asp:Parameter Name="Region" Type="String" />
                <asp:Parameter Name="PostalCode" Type="Int32" />
                <asp:Parameter Name="Country" Type="String" />
                <asp:Parameter Name="Phone" Type="String" />
                <asp:Parameter Name="Fax" Type="String" />
            </UpdateParameters>
        </asp:ObjectDataSource>
       
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
            <ItemTemplate>
                <tr style="background-color:#DCDCDC;color: #000000;">
                    <td>
                        <asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyNameLabel" runat="server" 
                            Text='<%# Eval("CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContactNameLabel" runat="server" 
                            Text='<%# Eval("ContactName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContactTitleLabel" runat="server" 
                            Text='<%# Eval("ContactTitle") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RegionLabel" runat="server" Text='<%# Eval("Region") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PostalCodeLabel" runat="server" 
                            Text='<%# Eval("PostalCode") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FaxLabel" runat="server" Text='<%# Eval("Fax") %>' />
                    </td>
                </tr>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <tr style="background-color:#FFF8DC;">
                    <td>
                        <asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyNameLabel" runat="server" 
                            Text='<%# Eval("CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContactNameLabel" runat="server" 
                            Text='<%# Eval("ContactName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContactTitleLabel" runat="server" 
                            Text='<%# Eval("ContactTitle") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RegionLabel" runat="server" Text='<%# Eval("Region") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PostalCodeLabel" runat="server" 
                            Text='<%# Eval("PostalCode") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FaxLabel" runat="server" Text='<%# Eval("Fax") %>' />
                    </td>
                </tr>
            </AlternatingItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" 
                    style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>
                            No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" 
                            Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="CustomerIDTextBox" runat="server" 
                            Text='<%# Bind("CustomerID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyNameTextBox" runat="server" 
                            Text='<%# Bind("CompanyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ContactNameTextBox" runat="server" 
                            Text='<%# Bind("ContactName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ContactTitleTextBox" runat="server" 
                            Text='<%# Bind("ContactTitle") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PostalCodeTextBox" runat="server" 
                            Text='<%# Bind("PostalCode") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' />
                    </td>
                </tr>
            </InsertItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table ID="itemPlaceholderContainer" runat="server" border="1" 
                                style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color:#DCDCDC;color: #000000;">
                                    <th runat="server">
                                        CustomerID</th>
                                    <th runat="server">
                                        CompanyName</th>
                                    <th runat="server">
                                        ContactName</th>
                                    <th runat="server">
                                        ContactTitle</th>
                                    <th runat="server">
                                        Address</th>
                                    <th runat="server">
                                        City</th>
                                    <th runat="server">
                                        Region</th>
                                    <th runat="server">
                                        PostalCode</th>
                                    <th runat="server">
                                        Country</th>
                                    <th runat="server">
                                        Phone</th>
                                    <th runat="server">
                                        Fax</th>
                                </tr>
                                <tr ID="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" 
                            style="text-align: center;background-color: #CCCCCC;font-family: Verdana, Arial, Helvetica, sans-serif;color: #000000;">
                            <asp:DataPager ID="DataPager1" runat="server">
                                <Fields>
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowFirstPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                    <asp:NumericPagerField />
                                    <asp:NextPreviousPagerField ButtonType="Button" ShowLastPageButton="True" 
                                        ShowNextPageButton="False" ShowPreviousPageButton="False" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                </table>
            </LayoutTemplate>
            <EditItemTemplate>
                <tr style="background-color:#008A8C;color: #FFFFFF;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" 
                            Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" 
                            Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="CustomerIDTextBox" runat="server" 
                            Text='<%# Bind("CustomerID") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CompanyNameTextBox" runat="server" 
                            Text='<%# Bind("CompanyName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ContactNameTextBox" runat="server" 
                            Text='<%# Bind("ContactName") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="ContactTitleTextBox" runat="server" 
                            Text='<%# Bind("ContactTitle") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="AddressTextBox" runat="server" Text='<%# Bind("Address") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CityTextBox" runat="server" Text='<%# Bind("City") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="RegionTextBox" runat="server" Text='<%# Bind("Region") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PostalCodeTextBox" runat="server" 
                            Text='<%# Bind("PostalCode") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="CountryTextBox" runat="server" Text='<%# Bind("Country") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="PhoneTextBox" runat="server" Text='<%# Bind("Phone") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="FaxTextBox" runat="server" Text='<%# Bind("Fax") %>' />
                    </td>
                </tr>
            </EditItemTemplate>
            <SelectedItemTemplate>
                <tr style="background-color:#008A8C;font-weight: bold;color: #FFFFFF;">
                    <td>
                        <asp:Label ID="CustomerIDLabel" runat="server" 
                            Text='<%# Eval("CustomerID") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CompanyNameLabel" runat="server" 
                            Text='<%# Eval("CompanyName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContactNameLabel" runat="server" 
                            Text='<%# Eval("ContactName") %>' />
                    </td>
                    <td>
                        <asp:Label ID="ContactTitleLabel" runat="server" 
                            Text='<%# Eval("ContactTitle") %>' />
                    </td>
                    <td>
                        <asp:Label ID="AddressLabel" runat="server" Text='<%# Eval("Address") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CityLabel" runat="server" Text='<%# Eval("City") %>' />
                    </td>
                    <td>
                        <asp:Label ID="RegionLabel" runat="server" Text='<%# Eval("Region") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PostalCodeLabel" runat="server" 
                            Text='<%# Eval("PostalCode") %>' />
                    </td>
                    <td>
                        <asp:Label ID="CountryLabel" runat="server" Text='<%# Eval("Country") %>' />
                    </td>
                    <td>
                        <asp:Label ID="PhoneLabel" runat="server" Text='<%# Eval("Phone") %>' />
                    </td>
                    <td>
                        <asp:Label ID="FaxLabel" runat="server" Text='<%# Eval("Fax") %>' />
                    </td>
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
       
    </div>
    </form>
</body>
</html>
