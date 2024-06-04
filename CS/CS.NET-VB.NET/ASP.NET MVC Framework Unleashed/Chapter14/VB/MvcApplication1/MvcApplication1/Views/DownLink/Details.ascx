<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of MvcApplication1.Product))" %>

<ul>
<%  For Each product In Model%>

    <li>
        <%= product.Name %> - <%= product.Price.ToString("c") %>
    </li>

<% Next%>
</ul>
