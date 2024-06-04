<%@ Page Title="Book your bus" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Bus.aspx.cs" Inherits="Bus" %>

<%@ Register Assembly="GCheckout" Namespace="GCheckout.Checkout" TagPrefix="cc2" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style5
        {
            width: 34px;
        }
    .style6
    {
        height: 34px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Panel ID="Panel1" runat="server" Width="560px">
    <table style="width:100%">
        <%--<tr>
            <td>
                <asp:RadioButton ID="rbOneWay" runat="server" GroupName="trip" Text="One Way" />
            </td>
            <td>
                <asp:RadioButton ID="rbRoundTrip" runat="server" GroupName="trip" 
                    Text="Round Trip" />
            </td>
            <td>
                &nbsp;</td>
        </tr>--%>
        <tr>
            <td align="center" bgcolor="#7C0104" colspan="3" class="style6">
                <asp:Label ID="Label1" runat="server" Text="Select Bus Route" Font-Bold="True" Font-Size="Medium"
                    ForeColor="White"></asp:Label>
                &nbsp; &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="From: "></asp:Label>
                <asp:DropDownList ID="dlFrom" runat="server" BackColor="#FFFFDF">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="dlFrom"
                    ErrorMessage="RequiredFieldValidator" InitialValue="Select a City">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <asp:Label ID="Label3" runat="server" Text="To: "></asp:Label>
                <asp:DropDownList ID="dlTo" runat="server" BackColor="#FFFFDF">
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="dlTo"
                    ErrorMessage="RequiredFieldValidator" InitialValue="Select a City">*</asp:RequiredFieldValidator>
            </td>
            <td class="style5">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Depart on: "></asp:Label>
                <asp:TextBox ID="txtDepart" runat="server" BackColor="#FFFFDF"></asp:TextBox>
                <cc1:CalendarExtender ID="CalendarExtender1" TargetControlID="txtDepart" PopupPosition="BottomRight"
                    runat="server">
                </cc1:CalendarExtender>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDepart"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
            <td>
                <%--  <asp:Label ID="Label5" runat="server" Text="Return on: "></asp:Label>
                <asp:TextBox ID="txtReturn" runat="server"></asp:TextBox>--%>
                <asp:Label ID="Label5" runat="server" Text="No. of Passengers: "></asp:Label>
                <asp:DropDownList ID="dlPassengers" runat="server" BackColor="#FFFFDF">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                    <asp:ListItem>4</asp:ListItem>
                    <asp:ListItem>5</asp:ListItem>
                    <asp:ListItem>6</asp:ListItem>
                    <asp:ListItem>7</asp:ListItem>
                    <asp:ListItem>8</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="style5">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_Click" />
            </td>
            <td>
                &nbsp;
            </td>
            <td class="style5">
                &nbsp;
            </td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="gvBusDetails" runat="server" Width="99%" AutoGenerateColumns="False"
        OnSelectedIndexChanged="gvBusDetails_SelectedIndexChanged" BackColor="White"
        BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px" CellPadding="4">
        <Columns>
            <asp:BoundField DataField="From" HeaderText="From" />
            <asp:BoundField DataField="To" HeaderText="To" />
            <asp:BoundField DataField="SeatsAvailable" HeaderText="Seats Available" />
            <asp:BoundField DataField="Fare" HeaderText="Fares" />
            <asp:TemplateField>
                <ItemTemplate>
                    <cc2:GCheckoutButton ID="GCheckoutButton1" runat="server" CommandName="Select" />
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
    </asp:GridView>
    </asp:Panel>
    <br />
</asp:Content>
