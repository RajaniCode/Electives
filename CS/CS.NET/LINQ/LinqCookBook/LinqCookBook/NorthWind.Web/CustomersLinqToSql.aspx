<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CustomersLinqToSql.aspx.cs" Inherits="NorthWind.Web.CustomersLinqToSql" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList  AutoPostBack="true" ID="titles" runat="server">
            <asp:ListItem Text="All" Value="" />
            <asp:ListItem Text="Owner" Value="Owner" />
            <asp:ListItem Text="Sales Agent" Value="Sales Agent" />
        </asp:DropDownList>
        <br />
        <asp:ListView ID="custlistview" DataSourceID="custsource" runat="server">
            <LayoutTemplate>
                <table>
                    <tr>
                        <td colspan="3">
                            <asp:DataPager ID="DataPager1" runat="server" PageSize="5">
                                <Fields>
                                    <asp:NumericPagerField  ButtonCount="5" />
                                </Fields>
                            </asp:DataPager>
                        </td>
                    </tr>
                    <tr>
                        <td>Company</td>
                        <td>Contact Name</td>
                        <td>Contact Title</td>
                    </tr>
                    <tr id="itemPlaceHolder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <td><%# Eval("CompanyName") %></td>
                    <td><%# Eval("ContactName") %></td>
                    <td><%# Eval("ContactTitle") %></td>
                </tr>
            </ItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="custsource" runat="server"
         EnablePaging="true" StartRowIndexParameterName="start" MaximumRowsParameterName="max"
          SelectCountMethod="GetCustomersByContactTitleCount"
         SelectMethod="GetCustomersByContactTitle" TypeName="NorthWind.Business.LS.Customer">
            <SelectParameters>
                <asp:ControlParameter Name="contacttitle" ControlID="titles" />
            </SelectParameters>
         </asp:ObjectDataSource>
            <asp:ObjectDataSource ID="ObjectDataSource1" runat="server">
            </asp:ObjectDataSource>
            <br />
            
    </div>
    </form>
</body>
</html>
