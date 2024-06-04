<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of MvcApplication1.Product))" %>

<div style="border:solid 3px black">
<h2>Featured Products</h2>
<ul>
    <% For Each product In Model%>
        
        <li><%= product.Name %></li>

    <% Next%>
</ul>
</div>