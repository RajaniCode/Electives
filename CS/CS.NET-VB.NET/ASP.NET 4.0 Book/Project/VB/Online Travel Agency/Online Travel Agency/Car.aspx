<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage.master" CodeBehind="Car.aspx.vb" Inherits="Online_Travel_Agency.WebForm7" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
    .style4
    {
        height: 34px;
    }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" Width="560px">
        <table style="width: 100%; height: 69px;">
            <tr>
                <td align="center" bgcolor="#7C0104" colspan="3" class="style4">
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" 
                        Text="Book Your Car" Font-Size="Medium"></asp:Label>                        
                </td>
            </tr>
            <tr>
            <td colspan="3"><marquee direction="right">  <asp:Image ID="Image1" runat="server" Height="35px" ImageUrl="~/Resources/blackporche.gif"
            Width="50px" /></marquee></td>
            
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Rental Type:"></asp:Label>
                </td>
                <td>
                    <asp:RadioButton ID="rbfullDay" runat="server" GroupName="booking" Text="Full Day (8 Hrs and 80 Kms)"  Checked="True" />
                </td>
                <td>
                    <asp:RadioButton ID="rbHalfDay" runat="server" GroupName="booking" Text="Half Day (4 Hrs and 40 Kms)" />
                </td>
            </tr>
        </table>
        <hr style="color: #7C0104" />
        <table style="width: 100%; height: 99px;">
            <tr>
                <td>
                    <asp:RadioButton ID="rbDelhi" runat="server" Text="Delhi" GroupName="City" Checked="True" />
                </td>
                <td>
                    <asp:RadioButton ID="rbBanglore" runat="server" Text="Banglore" GroupName="City" />
                </td>
                <td>
                    <asp:RadioButton ID="rbJaipur" runat="server" Text="Jaipur" GroupName="City" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RadioButton ID="rbMumbai" runat="server" Text="Mumbai" GroupName="City" />
                </td>
                <td>
                    <asp:RadioButton ID="rbKolkata" runat="server" Text="Kolkata" GroupName="City" />
                </td>
                <td>
                    <asp:RadioButton ID="rbChennai" runat="server" Text="Chennai" GroupName="City" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
        &nbsp;
        <br />
        <br />
        <asp:GridView ID="gvCarDetails" runat="server" OnSelectedIndexChanged="gvCarDetails_SelectedIndexChanged"
            Width="99%" BackColor="White" BorderColor="#CC9966" BorderStyle="None" BorderWidth="1px"
            CellPadding="4">
            <Columns>
                <asp:ButtonField ButtonType="Button" CommandName="Select" Text="Book" />
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
        <br />
        <center>
        <asp:Image ID="Image3" runat="server" Height="304px" ImageUrl="~/Resources/travel-benefits.gif"
            Width="373px" BorderColor="#7C0104" BorderWidth="4px" /></center>
            
    </asp:Panel>
</asp:Content>
