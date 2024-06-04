<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            $.ajaxSetup({cache:false});
            window.setInterval(refreshMovies, 3000);
        }

        function refreshMovies()
        {
            $.getJSON("/Movie/Refresh", showMovies);
        }
        
        function showMovies(movies)
        {
            var frag = "<ul>";
            for (var i = 0; i < movies.length; i++)
            {
                frag += "<li>" + movies[i].Title + " - " + movies[i].Director + "</li>";
            }
            frag += "</ul>";


            $("#divMovies").html(frag);
        }
    
    </script>

    <h2>Movies</h2>

    <div id="divMovies"></div>

</asp:Content>
