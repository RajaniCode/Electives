<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<MvcApplication1.Models.Movie>" %>
<tr>
    <td><%= Model.Title %></td>
    <td><%= Model.Director %></td>
    <td><%= Model.DateReleased.ToString("D") %></td>    
</tr>

