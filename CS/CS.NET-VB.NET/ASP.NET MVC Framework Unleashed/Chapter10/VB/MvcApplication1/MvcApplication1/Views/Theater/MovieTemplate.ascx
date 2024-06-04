<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of MvcApplication1.Movie)" %>

<tr>
    <td><%= Model.Title %></td>
    <td><%= Model.Director %></td>
    <td><%= Model.DateReleased.ToString("D") %></td>    
</tr>
