<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            $("#myMenu a").hover(highlight, lowlight);
        }

        function highlight()
        {
            $(this).css("background-color", "yellow");
        }

        function lowlight()
        {
            $(this).css("background-color", "");
        }
    
    </script>

    <ul id="myMenu">
        <li>
            <%= Html.ActionLink("Home", "Home") %>        
        </li>
        <li>
            <%= Html.ActionLink("Products", "Products") %>        
        </li>
        <li>
            <%= Html.ActionLink("Products", "Services") %>                
        </li>
    </ul>



</asp:Content>
