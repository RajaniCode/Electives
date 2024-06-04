<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Category>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
<script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

<script type="text/javascript">

    $(pageReady);

    function pageReady()
    {
        $("#categories a").click( selectLink );
    }

    function selectLink()
    {
        $("#categories a.selected").removeClass("selected");
        $(this).addClass("selected");
    }
    

</script>

<ul id="categories" style="display:inline">
<% foreach (var category in Model)
   { %>

    <li style="display:inline">
        <%= Ajax.ActionLink(category.Name, "Details", new {id=category.Id}, new AjaxOptions {UpdateTargetId="divDetails"}) %>
    </li>

<% } %>
</ul>

<hr />

<div id="divDetails"></div>

</asp:Content>

