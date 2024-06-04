<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Movie>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery.tablesorter.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            $("#movieTable").tablesorter();
        }

    </script>

    <table id="movieTable">
    <thead style="cursor:hand">
        <tr>
            <th>
                Id
            </th>
            <th>
                Title
            </th>
            <th>
                Director
            </th>
            <th>
                DateReleased
            </th>
        </tr>
    </thead>
    <tbody>
    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
            <td>
                <%= Html.Encode(item.Director) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DateReleased)) %>
            </td>
        </tr>
    
    <% } %>
    </tbody>
    </table>

</asp:Content>

