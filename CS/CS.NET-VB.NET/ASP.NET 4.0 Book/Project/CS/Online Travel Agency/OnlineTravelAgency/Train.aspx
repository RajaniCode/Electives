<%@ Page Title="Book your Train" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Train.aspx.cs" Inherits="Train" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GCheckout" Namespace="GCheckout.Checkout" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style7
        {
            height: 30px;
        }
    .style8
    {
        width: 24px;
    }
    .style9
    {
        width: 30px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Width="560px">
    <table style="width: 100%;">
        <tr>
            <td align="center" bgcolor="#7C0104" colspan="3" class="style7">
                <asp:Label ID="Label6" runat="server" Text="Select Train Route" Font-Bold="True"
                    Font-Size="Medium" ForeColor="White"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="From: "></asp:Label>
                <asp:DropDownList ID="dlFrom" runat="server" BackColor="#FFFFDF" Height="24px" 
                    Width="112px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dlFrom"
                    ErrorMessage="RequiredFieldValidator" InitialValue="Select Station">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label2" runat="server" Text="To: "></asp:Label>
                <asp:DropDownList ID="dlTo" runat="server" BackColor="#FFFFDF" Height="22px" 
                    Width="131px">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dlTo"
                    ErrorMessage="RequiredFieldValidator" InitialValue="Select Station">*</asp:RequiredFieldValidator>
            </td>
            <td class="style9">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Class: "></asp:Label>
                <asp:DropDownList ID="dlClass" runat="server" BackColor="#FFFFDF">
                    <asp:ListItem>Sleeper Class</asp:ListItem>
                    <asp:ListItem>AC First Class</asp:ListItem>
                    <asp:ListItem>2 Tier</asp:ListItem>
                    <asp:ListItem>3 Tier</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Departure Date: "></asp:Label>
                <asp:TextBox ID="txtDate" runat="server" BackColor="#FFFFDF"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" runat="server" PopupPosition="BottomRight"
                    TargetControlID="txtDate">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
            <td class="style9">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label5" runat="server" Text="Passengers: "></asp:Label>
                <asp:DropDownList ID="dlpassengers" runat="server" BackColor="#FFFFDF" 
                    onselectedindexchanged="dlpassengers_SelectedIndexChanged">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;
            </td>
            <td class="style9">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSearch" runat="server" Height="29px" Text="Search Train" Width="98px"
                    OnClick="btnSearch_Click" />
                &nbsp;&nbsp;
            </td>
            <td class="style9">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td class="style9">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:GridView ID="gvTrainDetails" runat="server" OnSelectedIndexChanged="gvTrainDetails_SelectedIndexChanged"
        Width="565px" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
        CellPadding="4">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <cc2:GCheckoutButton ID="GCheckoutButton1" runat="server" CommandName="Select" Size="Small"
                        Width="100px" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="#FFFFCC" ForeColor="#330099" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="#FFFFCC" />
        <PagerStyle BackColor="#FFFFCC" ForeColor="#330099" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#330099" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="#663399" />
        <SortedAscendingCellStyle BackColor="#FEFCEB" />
        <SortedAscendingHeaderStyle BackColor="#AF0101" />
        <SortedDescendingCellStyle BackColor="#F6F0C0" />
        <SortedDescendingHeaderStyle BackColor="#7E0000" />
    </asp:GridView>        </asp:Panel>
    <br />
    <br />
    <asp:Image ID="Image2" runat="server" Height="172px" ImageUrl="~/Resources/travel-benefits.gif"
        Width="203px" />
    &nbsp;&nbsp;<asp:Image ID="Image3" runat="server" Height="170px" ImageUrl="~/Resources/travel-benefits.gif"
        Width="192px" />

    <br />
</asp:Content>
