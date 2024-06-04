<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="FocusOnEnterKey.aspx.cs" Inherits="FocusOnEnterKey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $('input:text:first').focus();
            $('input:text').bind("keydown", function (e) {
                if (e.which == 13) { //Enter key
                    e.preventDefault(); //to skip default behavior of the enter key
                    var nextIndex = $('input:text').index(this) + 1;
                    var control = $('input:text')[nextIndex];
                    if (typeof control == 'object') {
                        control.focus();
                    }
                    else {
                        // we reached at last control, return focus to first input control.
                        $('input:text:first').focus();
                    }
                }
            });           
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <fieldset style="width: 400px; height: 150px;">
            <table cellpadding="3" cellspacing="3" border="0">
                <tr>
                    <td>
                        <asp:Label ID="lblName" Text="Name: " runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtName" Width="200px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="lblAddress" Text="Address: " runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAddress" Width="200px" runat="server"></asp:TextBox>
                    </td>
                </tr>              
                <tr>
                    <td>
                        <asp:Label ID="lblEmail" Text="Email: " runat="server"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtEmail" Width="200px" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td>
                        <asp:Button ID="btnSubmit" Text="Submit" runat="server" />
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
