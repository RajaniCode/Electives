<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            $("a[href^='http']").append(" [external]");
        }
    
    </script>


    <h2>Resources</h2>

    <ul>
        <li>
        <a href="http://www.ASP.net/mvc">Official ASP.NET MVC website</a>
        </li>
        <li>
        <a href="/articles">Articles</a>
        </li>
        <li>
        <a href="/videos">Videos</a>
        </li>
    </ul>


</asp:Content>
