<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of MvcApplication1.Movie))" %>

<table>

<%  For Each item In Model%>

    <tr>
        <td>
            <%= Html.Encode(item.Title) %>
        </td>
        <td>
            <%= Html.Encode(item.Director) %>
        </td>
    </tr>

<% Next%>

</table>

