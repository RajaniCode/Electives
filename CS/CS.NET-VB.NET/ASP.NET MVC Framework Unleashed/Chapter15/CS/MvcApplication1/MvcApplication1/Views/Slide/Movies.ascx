<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcApplication1.Models.Movie>>" %>

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


