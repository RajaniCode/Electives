<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcApplication1.Models.Product>>" %>

<ul>
<% foreach (var product in Model)
   { %>

    <li>
        <%= product.Name %> -- <%= product.Price.ToString("c") %>
    </li>

<% } %>
</ul>
