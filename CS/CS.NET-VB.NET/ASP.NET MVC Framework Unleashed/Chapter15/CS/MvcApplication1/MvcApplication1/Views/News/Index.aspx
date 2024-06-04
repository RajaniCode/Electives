<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            window.setInterval(refreshNews, 3000);
        }

        function refreshNews()
        {
            $("#divNews").load("/News/Refresh");
        }

    </script>

    <h2>Index</h2>

    <div id="divNews"></div>


</asp:Content>
