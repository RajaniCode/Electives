<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Movie))" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

    <h2>Movies</h2>

    <div id="divMovies">
        <% Html.RenderPartial("Movies")%>
    </div>
    
</asp:Content>

