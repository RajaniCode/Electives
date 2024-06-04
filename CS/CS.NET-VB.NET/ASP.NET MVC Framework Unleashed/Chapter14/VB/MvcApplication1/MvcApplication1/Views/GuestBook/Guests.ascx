<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of MvcApplication1.Guest))" %>
<%  For Each item In Model%>
    <div>
        <h3><%= Html.Encode(item.Name) %></h3>
        
        <%= Html.Encode(item.Message) %>
    </div>
<% Next%>
