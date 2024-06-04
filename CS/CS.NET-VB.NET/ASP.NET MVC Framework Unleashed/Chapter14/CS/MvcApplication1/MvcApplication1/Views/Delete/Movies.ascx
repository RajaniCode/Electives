<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcApplication1.Models.Movie>>" %>

<ul>
    <% foreach (var movie in Model)
       { %>
    
        <li>
            <%= movie.Title %>
            <%= Ajax.ActionLink("Delete", "Delete", new {id=movie.Id}, new AjaxOptions {HttpMethod="DELETE", Confirm="Delete record?", UpdateTargetId="divMovies" })%>
        </li>
    
    <% } %>

</ul>
