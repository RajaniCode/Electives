<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <form method="get">
        <input type="button" id="GetTweets" value="Get Tweets" />
    </form>
    <div id="showTweets"></div>

    <script type="text/javascript" language="javascript" src="../../Scripts/jquery-1.4.2.js"></script>
    <script type="text/javascript" language="javascript" src="../../Scripts/jquery-jtemplates.js"></script>

    <script type="text/javascript" language="javascript">
        $(function() {
            $("#GetTweets").click(function(e) {
                e.preventDefault();                
                var url = "http://search.twitter.com/search.json?q=&ands=worldcup&rpp=5&callback=?";
                $.getJSON(url, function (tweets) {
                    $("#showTweets").setTemplateURL("/Templates/Tweets.htm").processTemplate(tweets);                
                });
            });
        });
    </script>
</asp:Content>
