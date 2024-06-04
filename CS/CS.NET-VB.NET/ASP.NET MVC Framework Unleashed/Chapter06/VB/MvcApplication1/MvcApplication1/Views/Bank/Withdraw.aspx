<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Withdraw</h2>   

    <% Using Html.BeginForm() %>

        <%= Html.AntiForgeryToken() %>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="Amount">Amount:</label>
                <%= Html.TextBox("Amount") %>
            </p>
            <p>
                <input type="submit" value="Withdraw" />
            </p>
        </fieldset>

    <% End Using %>

</asp:Content>

