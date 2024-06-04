<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="loginHead" ContentPlaceHolderID="head" runat="server">
    <title>Log On</title>
</asp:Content>

<asp:Content ID="loginContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Log On</h2>
    <p>
        Please enter your username and password. <%= Html.ActionLink("Register", "Register")%> if you don't have an account.
    </p>
    <%= Html.ValidationSummary() %>
    
    <%  Using Html.BeginForm() %>
         <div>
            <fieldset>
                <legend>Account Information</legend>
                <p>
                    <label for="username">Username:</label>
                    <%= Html.TextBox("username") %>
                    <%= Html.ValidationMessage("username") %>
                </p>
                <p>
                    <label for="password">Password:</label>
                    <%= Html.Password("password") %>
                    <%= Html.ValidationMessage("password") %>
                </p>
                <p>
                    <%= Html.CheckBox("rememberMe") %> <label class="inline" for="rememberMe">Remember me?</label>
                </p>
                <p>
                    <input type="submit" value="Log On" />
                </p>
            </fieldset>
        </div>
    <% End Using %>
</asp:Content>
