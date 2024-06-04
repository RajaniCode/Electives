<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Movie>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

    <script type="text/javascript">

        function createSuccess(context)
        {
            alert( context.get_data());
        }
    
    </script>

    <div id="divLoading" style="display:none">
        <image src="../Content/Busy.gif" alt="posting form" />    
    </div>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Ajax.BeginForm(new AjaxOptions {OnSuccess="createSuccess", LoadingElementId="divLoading"}))
       {%>

        <fieldset>
            <legend>Create Movie</legend>
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

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

