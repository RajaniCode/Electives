<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Guest>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

    <h1>Guest Book</h1>

    <% using (Ajax.BeginForm("Create", new AjaxOptions {UpdateTargetId="divMessages" }))
       { %>

        <div id="divMessages">
            <% Html.RenderPartial("GuestBook"); %>
        </div>
    
    <% } %>

</asp:Content>

