<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="StaticIDPage.aspx.cs" Inherits="StaticIDPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<script type="text/javascript" language="javascript">
    document.writeln('<%=txtCustomerName.ClientID %>' + '<br/>');
    document.writeln('<%=txtAddress.ClientID %>' + '<br/>');
    document.writeln('<%=txtContactNo.ClientID %>' + '<br/>');
    document.writeln('<%=txtCity.ClientID %>' + '<br/>');
    document.writeln('<%=txtCountry.ClientID %>' + '<br/>');
    function GetValue() {
        var txtCustName = document.getElementById('<%=txtCustomerName.ClientID %>');
        alert(txtCustName.value);
    }
</script>
    <table>
        <tr>
            <td class="style1">
            <asp:Label ID="lblCustomerName" runat="server" Text="Customer Name"></asp:Label></td>
            <td>
            <asp:TextBox ID="txtCustomerName" runat="server" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Label ID="lblAddress" runat="server" Text="Address"></asp:Label></td>
            <td>
            <asp:TextBox ID="txtAddress" runat="server" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Label ID="lblContactNo" runat="server" Text="Contact No."></asp:Label></td>
            <td>
            <asp:TextBox ID="txtContactNo" runat="server" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Label ID="lblCity" runat="server" Text="Customer City"></asp:Label></td>
            <td>
            <asp:TextBox ID="txtCity" runat="server" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1">
            <asp:Label ID="tblCountry" runat="server" Text="Country"></asp:Label></td>
            <td>
            <asp:TextBox ID="txtCountry" runat="server" ClientIDMode="Static"></asp:TextBox></td>
        </tr>
        <tr>
            <td class="style1">
                <asp:Button ID="btnSendData" runat="server" Text="Submit Customer" onclientclick="GetValue()"/>
            </td>
        </tr>
    </table>
</asp:Content>

