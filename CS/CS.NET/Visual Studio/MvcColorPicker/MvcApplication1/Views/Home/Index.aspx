<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <script language="javascript" type="text/javascript" src="http://code.jquery.com/jquery-1.4a2.js"></script>
    <script language="javascript" type="text/javascript">
        $(function() {
            $("#Colors").hide();
            $("#SelectColor").click(function() {
                $.get("/Color/FetchColors", null, function(data) {
                    $("#Colors").html(eval(data));
                });
                $("#Colors").toggle();
            });

            $("td").live("mouseover", (function() {
                $("#Sample").css("background-color", $(this).css("background-color"));
                $(this).css("cursor", "pointer");
            }));

            $("td").live("click", function() {
                $("#SelectedColor").val($(this).attr("bgcolor"));
            });
        });  
    </script>     
    <input type="text" id="SelectedColor" name="SelectedColor" readonly="readonly" />
    <img src="/Content/Images/cp_button.png" alt="Pick a color" align="absmiddle" id="SelectColor" />
    <span id="Sample">&nbsp;&nbsp;&nbsp;&nbsp;</span><br /><br />
    <div id="Colors"></div>  
</asp:Content>
