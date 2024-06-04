<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Customer>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm()) {%>

        <fieldset>
            <legend>Register</legend>
            <p>
                <label for="FirstName">First Name:</label>
                <%= Html.TextBox("FirstName") %>
                <%= Html.ValidationMessage("FirstName", "*") %>
            </p>
            <p>
                <label for="LastName">Last Name:</label>
                <%= Html.TextBox("LastName") %>
                <%= Html.ValidationMessage("LastName", "*") %>
            </p>
            <p>
                <label for="Password">Password:</label>
                <%= Html.Password("Password") %>
                <%= Html.ValidationMessage("Password", "*") %>
            </p>
            <p>
                <label for="Password">Confirm Password:</label>
                <%= Html.Password("ConfirmPassword") %>
                <%= Html.ValidationMessage("ConfirmPassword", "*") %>
            </p>
            <p>
                <label for="Profile">Profile:</label>
                <%= Html.TextArea("Profile", new {cols=60, rows=10})%>
            </p>
            <p>
                <%= Html.CheckBox("ReceiveNewsletter") %>
                <label for="ReceiveNewsletter" style="display:inline">Receive Newsletter?</label>
            </p>
            <p>
                <input type="submit" value="Register" />
            </p>
        </fieldset>

    <% } %>

</asp:Content>

