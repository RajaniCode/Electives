<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="ID">ID:</label>
                <%= Html.TextBox("ID", Model.ID) %>
                <%= Html.ValidationMessage("ID", "*") %>
            </p>
            <p>
                <label for="GivenName">GivenName:</label>
                <%= Html.TextBox("GivenName", Model.GivenName) %>
                <%= Html.ValidationMessage("GivenName", "*") %>
            </p>
            <p>
                <label for="Surname">Surname:</label>
                <%= Html.TextBox("Surname", Model.Surname) %>
                <%= Html.ValidationMessage("Surname", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <% } %>

    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>

</asp:Content>

