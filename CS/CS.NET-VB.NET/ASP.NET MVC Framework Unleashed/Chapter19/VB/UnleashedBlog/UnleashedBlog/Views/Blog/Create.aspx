<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of UnleashedBlog.BlogEntry)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Author">Author:</label>
                <%= Html.TextBox("Author") %>
                <%= Html.ValidationMessage("Author", "*") %>
            </p>
            <p>
                <label for="Description">Description:</label>
                <%= Html.TextBox("Description") %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
                <label for="DateModified">DateModified:</label>
                <%= Html.TextBox("DateModified") %>
                <%= Html.ValidationMessage("DateModified", "*") %>
            </p>
            <p>
                <label for="DatePublished">DatePublished:</label>
                <%= Html.TextBox("DatePublished") %>
                <%= Html.ValidationMessage("DatePublished", "*") %>
            </p>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name") %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="Text">Text:</label>
                <%= Html.TextBox("Text") %>
                <%= Html.ValidationMessage("Text", "*") %>
            </p>
            <p>
                <label for="Title">Title:</label>
                <%= Html.TextBox("Title") %>
                <%= Html.ValidationMessage("Title", "*") %>
            </p>
            <p>
                <input type="submit" value="Create" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

