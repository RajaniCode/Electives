<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<List<Product>>" %>
<%@ Import Namespace="MvcApplication1.Models" %>

<div style="border:solid 3px black">
<h2>Featured Products</h2>
<ul>
    <% foreach (var product in Model)
       { %>
        
        <li><%= product.Name %></li>

    <% } %>
</ul>
</div>