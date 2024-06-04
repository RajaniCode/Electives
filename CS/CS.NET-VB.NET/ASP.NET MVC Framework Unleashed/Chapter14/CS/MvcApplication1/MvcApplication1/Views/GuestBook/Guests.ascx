<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcApplication1.Models.Guest>>" %>

<% foreach (var item in Model) { %>
    <div>
        <h3><%= Html.Encode(item.Name) %></h3>
        
        <%= Html.Encode(item.Message) %>
    </div>
<% } %>


