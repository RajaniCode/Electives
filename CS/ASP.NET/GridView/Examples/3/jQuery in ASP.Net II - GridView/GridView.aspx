<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="GridView.aspx.cs" Inherits="GridView" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=GridView1.ClientID%> td").hover(
            function () {
                $(this).addClass("highlight");
            },
            function () {
                $(this).removeClass("highlight");
            });


            $("#<%=GridView1.ClientID %> tr").click(function () {
                $(this).find("td").each(function () {
                    $(this).remove(); // remove td
                });
                $(this).remove(); // remove tr
            });

            $("#<%=GridView1.ClientID %> th").click(function () {
                var count = $(this).closest("th").prevAll("th").length;
                $(this).parents("#<%=GridView1.ClientID %>").find("tr").each(function () {
                    $(this).find("td:eq(" + count + ")").remove();
                    $(this).find("th:eq(" + count + ")").remove();
                });
            });

            $("#<%=GridView1.ClientID%> tr").filter(":not(:has(table, th))").click(function (e) {
                var $cell = $(e.target).closest("td");
                $("#<%=GridView1.ClientID%> td").removeClass("highlight");
                $cell.addClass("highlight");
                $("#message").text('You have selected: ' + $cell.text());
            });
        });
    </script>
    <style type="text/css">
        .highlight
        {
            background-color: #34FF6D;
        }
        td
        {
            cursor: pointer;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div align="center">
        <fieldset style="width: 400px; height: 230px;">
            <table border="0" cellpadding="3" cellspacing="3">
                <tr>
                    <td colspan="2" class="header">
                        BOOK CATALOG
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:GridView ID="GridView1" runat="server">
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </fieldset>
        <br />
        <div id="message">
        </div>
    </div>
</asp:Content>
