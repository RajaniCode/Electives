<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Product)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%=Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.")%>

    <% Using Html.BeginForm() %>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Name">Name:</label>
                <%= Html.TextBox("Name", Model.Name) %>
                <%= Html.ValidationMessage("Name", "*") %>
            </p>
            <p>
                <label for="Description">Description:</label>
                <%= Html.TextBox("Description", Model.Description) %>
                <%= Html.ValidationMessage("Description", "*") %>
            </p>
            <p>
                <label for="Price">Price:</label>
                <%= Html.TextBox("Price", String.Format("{0:F}", Model.Price)) %>
                <%= Html.ValidationMessage("Price", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% End Using %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

