<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Movie))" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        function beginFetch()
        {
            $("#divMovies").slideUp("slow");
        }

        function completeFetch()
        {
            $("#divMovies").slideDown("slow");        
        }
    
    </script>

    <%=Ajax.ActionLink("Refresh Movies", "Refresh", New AjaxOptions With {.OnBegin = "beginFetch", .OnComplete = "completeFetch", .UpdateTargetId = "divMovies"})%>


    <div id="divMovies">
        <% Html.RenderPartial("Movies")%>
    </div>


</asp:Content>
