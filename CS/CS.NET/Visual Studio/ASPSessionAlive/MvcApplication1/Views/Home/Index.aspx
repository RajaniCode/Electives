<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript" src="http://code.jquery.com/jquery-latest.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            setInterval(KeepSessionAlive, 10000);
        });

        function KeepSessionAlive() {            
            $.post("/Shared/KeepSessionAlive.ashx", null, function() {
                $("#result").append("<p>Session is alive and kicking!<p/>");
            });    
        }    
    </script>
    <h2>Will my session die?</h2>    
    <div id="result"></div>
</asp:Content>
