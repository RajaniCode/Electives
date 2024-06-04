<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of MvcApplication1.Movie))" %>

<ul>
    <% For Each movie In Model%>
    
        <li>
            <%= movie.Title %>
            <%=Ajax.ActionLink("Delete", "Delete", New With {.id = movie.Id}, New AjaxOptions With {.HttpMethod = "DELETE", .Confirm = "Delete record?", .UpdateTargetId = "divMovies"})%>
        </li>
    
    <% Next%>

</ul>
