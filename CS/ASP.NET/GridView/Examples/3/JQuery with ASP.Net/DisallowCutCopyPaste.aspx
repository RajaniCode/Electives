<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="DisallowCutCopyPaste.aspx.cs" Inherits="DisallowCutCopyPaste" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=txtPwd.ClientID%>').bind('cut copy paste',
function (e) {
    e.preventDefault();
    alert("Cut / Copy / Paste are not allowed in this field");
});
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <fieldset style="width: 400px; height: 120px;">
            <table cellpadding="3" cellspacing="3" border="0">
                <tr>
                    <td colspan="2" class="header">
                        Login
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblUserName" Text="User Name:" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtUserName" Width="200px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblPwd" Text="Password:" runat="server" />
                    </td>
                    <td>
                        <asp:TextBox ID="txtPwd" Width="200px" runat="server" TextMode="Password"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnLogin" runat="server" Text="Submit" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
