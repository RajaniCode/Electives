<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Controllers.ProductsVDM>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

<ul style="display:inline">
<% foreach (var category in Model.Categories)
   { %>

    <li style="display:inline">
        <%= Ajax.ActionLink(category.Name, "Details", new {id=category.Id}, new AjaxOptions {UpdateTargetId="divDetails"}) %>
    </li>

<% } %>
</ul>

<hr />

<div id="divDetails">
    <% Html.RenderPartial("Details", Model.Products); %>
</div>


</asp:Content>

