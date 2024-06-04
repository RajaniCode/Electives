<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <%= Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.") %>

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Customer Info</legend>         
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
        </fieldset>
        <fieldset>
        <legend>Customer Address</legend>                    
            <p>
                <label for="Address.Street">Street:</label>
                <%= Html.TextBox("Address.Street") %>
                <%= Html.ValidationMessage("Address.Street", "*") %>
            </p> 
            <p>
                <label for="Address.City">City:</label>
                <%= Html.TextBox("Address.City") %>
                <%= Html.ValidationMessage("Address.City", "*") %>
            </p>
            <p>
                <label for="Address.ZIP">ZIP:</label>
                <%= Html.TextBox("Address.ZIP") %>
                <%= Html.ValidationMessage("Address.ZIP", "*") %>
            </p>
        </fieldset>
        <p>
            <input type="submit" value="Create" />
        </p>

    <% End Using%>

</asp:Content>
