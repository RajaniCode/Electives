<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Movie>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            $("tr:odd").css("background-color", "#eeeeee");
        }
    
    </script>

    <table>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.Director) %>
            </td>
        </tr>
    
    <% } %>

    </table>


</asp:Content>

