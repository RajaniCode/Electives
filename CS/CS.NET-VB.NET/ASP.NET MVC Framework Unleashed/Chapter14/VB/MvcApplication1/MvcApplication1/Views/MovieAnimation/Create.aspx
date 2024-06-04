<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Movie)" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

    <script type="text/javascript">

        function createBegin()
        {
            $("#movieForm").slideUp("slow");
        }

        function createComplete()
        {
            $("#movieForm").slideDown("slow");
        }

        function createSuccess(context)
        {
            $get("result").innerHTML = context.get_data();
        }
    
    </script>

    <div id="divLoading" style="display:none">
        <image src="../Content/Busy.gif" alt="posting form" />    
    </div>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Ajax.BeginForm(New AjaxOptions With {.OnSuccess = "createSuccess", .OnBegin = "createBegin", .OnComplete = "createComplete"})%>

        <fieldset id="movieForm">
            <legend>Create Movie</legend>
            <div id="result" style="color:red"></div>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title")%>
                <%= Html.ValidationMessage("Title", "*")%>
            </p>
            <p>
                <label for="Director">Director:</label>
                <%= Html.TextBox("Director")%>
                <%= Html.ValidationMessage("Director", "*")%>
            </p>
            <p>
                <label for="DateReleased">DateReleased:</label>
                <%= Html.TextBox("DateReleased")%>
                <%= Html.ValidationMessage("DateReleased", "*")%>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using%>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>
