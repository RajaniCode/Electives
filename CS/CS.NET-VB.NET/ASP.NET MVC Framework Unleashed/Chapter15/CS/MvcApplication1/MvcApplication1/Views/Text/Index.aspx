<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Movie>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script type="text/javascript">

        $(pageReady);

        function pageReady()
        {
            $("input:text").css("background-color", "yellow");
        }
    
    </script>


    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Create Movie</legend>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title") %>
            </p>
            <p>
                <label for="Director">Director:</label>
                <%= Html.TextBox("Director") %>
            </p>
            <p>
                <label for="DateReleased">DateReleased:</label>
                <%= Html.TextBox("DateReleased") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

