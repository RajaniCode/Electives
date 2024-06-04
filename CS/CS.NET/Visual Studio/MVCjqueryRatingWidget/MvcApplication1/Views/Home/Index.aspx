<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    MVC Ratings System
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript" src="../../Scripts/jquery-1.4a2.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            $("img").mouseover(function() {
                giveRating($(this), "FilledStar.png");
                $(this).css("cursor", "pointer");
            });

            $("img").mouseout(function() {
                giveRating($(this), "EmptyStar.png");
            });

            $("img").click(function() {
                $("img").unbind("mouseout mouseover click");

                // call ajax methods to update database
                var url = "/Rating/PostRating?rating=" + parseInt($(this).attr("id"));
                $.post(url, null, function(data) {
                    $("#result").text(data);
                });
            });
        });

        function giveRating(img, image) {            
            img.attr("src", "/Content/Images/" + image)
               .prevAll("img").attr("src", "/Content/Images/" + image);
        }
    </script>        
    <p>
        <img src="../../Content/Images/EmptyStar.png" alt="Star Rating" align="middle" id="1" />
        <img src="../../Content/Images/EmptyStar.png" alt="Star Rating" align="middle" id="2" />
        <img src="../../Content/Images/EmptyStar.png" alt="Star Rating" align="middle" id="3" />
        <img src="../../Content/Images/EmptyStar.png" alt="Star Rating" align="middle" id="4" />
        <img src="../../Content/Images/EmptyStar.png" alt="Star Rating" align="middle" id="5" />
    </p>
    <div id="result"></div>
</asp:Content>
