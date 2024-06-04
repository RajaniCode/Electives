<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="MultilineTextboxCharacterLimitation.aspx.cs" Inherits="MultilineTextboxCharacterLimitation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            var minCount = 5;
            var maxCount = 100;
            $("#<%=txtComments.ClientID%>").bind("cut copy paste", function (e) {
                e.preventDefault();
            });

            $("#<%=txtComments.ClientID%>").keypress(function (e) {
                var strCount = $("#<%=txtComments.ClientID%>").val().length;
                $("#<%=txtNumber.ClientID%>").val(strCount);
                if ((strCount < minCount) || (strCount > maxCount)) {
                    $("#message").text("Please enter characters in the range 5 - 100");

                    if (strCount > maxCount) {
                        e.preventDefault();
                    }
                }
                else {
                    $("#message").text("");
                }
            });
        });
    </script>
    <style type="text/css">
        .msg
        {
            color: #B3342C;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <fieldset style="width: 400px; height: 250px;">
            <table border="0" cellpadding="3" cellspacing="3">
                <tr>
                    <td>
                        Please enter your comments:
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox ID="txtComments" runat="server" TextMode="MultiLine" Rows="10" Width="300px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        Characters:
                        <asp:TextBox ID="txtNumber" runat="server" Width="30px" ReadOnly="true"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="message" class="msg">
                        </div>
                    </td>
                </tr>
            </table>
        </fieldset>
    </div>
</asp:Content>
