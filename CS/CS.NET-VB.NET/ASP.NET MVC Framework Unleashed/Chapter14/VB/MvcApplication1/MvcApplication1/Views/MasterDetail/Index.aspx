<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Category))" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

<ul style="display:inline">
<%  For Each category In Model%>

    <li style="display:inline">
        <%=Ajax.ActionLink(category.Name, "Details", New With {.id = category.Id}, New AjaxOptions With {.UpdateTargetId = "divDetails"})%>
    </li>

<% Next%>
</ul>

<hr />

<div id="divDetails"></div>

</asp:Content>
