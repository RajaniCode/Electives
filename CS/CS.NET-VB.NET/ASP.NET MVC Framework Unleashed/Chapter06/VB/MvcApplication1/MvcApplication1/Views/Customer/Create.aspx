<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Customer)" %>
<%@ Import Namespace="MvcApplication1" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Using Html.BeginForm()%>

        <fieldset>
            <legend>Fields</legend>
            <p>
                <label for="FirstName">FirstName:</label>
                <%= Html.TextBox("FirstName") %>
            </p>
            <p>
                <label for="Id">LastName:</label>
                <%= Html.TextBox("LastName") %>
            </p>
            <p>
                <%= Html.SubmitButton("Create Customer") %>
            </p>
        </fieldset>

    <% End Using %>

</asp:Content>

