 <%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl" %>

<%:Html.ActionLink("Cart (" & ViewData("CartCount") & ")", "Index", "ShoppingCart", New With {Key .id = "cart-status"})%>