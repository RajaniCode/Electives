<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<UnleashedBlog.Models.BlogEntry>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">



    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Create Post</legend>
            
            <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

            <p>
                <label for="Title">Title:</label>
                <br /><%= Html.TextBox("Title", String.Empty, new {size=60})%>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <label for="Author">Author:</label>
                <br /><%= Html.TextBox("Author") %>
                <%= Html.ValidationMessage("Author", "*") %>
            </p>
            <p>
                <label for="Description">Description:</label>
                <br /><%= Html.TextArea("Description", string.Empty, new { cols = 60, rows = 2 })%>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
                <label for="Text">Text:</label>
                <br /><%= Html.TextArea("Text", string.Empty, new {cols=60, rows=15})%>
                <%= Html.ValidationMessage("Text", "*") %>
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

