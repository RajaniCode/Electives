<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <style type="text/css">
        table tr { cursor: pointer; }
        table { margin-top: 10px; }
    </style>

    <script type="text/javascript">
        $().ready(function() {
            $("#LaunchModal").click(function() {
                $.get(
                    "Home/RandomPopupView",
                    function(htmlResult) {
                        $("#RandomModal").remove(); //In case this is the second time they've requested the dialog.
                        $("#container").append(htmlResult);
                        $("#RandomModal").dialog();
                    }
                );
                return false; //To keep the default behavior of the anchor tag from occuring.
            });

            $("table tr").click(function() {
                $.post(
                    "Home/RandomDetailsPopupView",
                    { recnum: $(this).attr("recnum") },
                    function(htmlResult) {
                        $("#RandomModal").remove(); 
                        $("#container").append(htmlResult);
                        $("#RandomModal").dialog();
                    }
               );
            });
        });
    </script>

    <div id="container">
        <h2>
            <%= Html.Encode(ViewData["Message"]) %></h2>
        <a href="" id="LaunchModal">Launch Modal!</a>
        <br />
        <table>
            <tr recnum="1">
                <td>
                    Column 1
                </td>
                <td>
                    Column 2
                </td>
                <td>
                    Column 3
                </td>
                <td>
                    Column 4
                </td>
            </tr>
            <tr recnum="2">
                <td>
                    Column 1
                </td>
                <td>
                    Column 2
                </td>
                <td>
                    Column 3
                </td>
                <td>
                    Column 4
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
