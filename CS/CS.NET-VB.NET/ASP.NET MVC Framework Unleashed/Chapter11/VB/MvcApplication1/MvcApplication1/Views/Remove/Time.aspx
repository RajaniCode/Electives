<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <h1><%= DateTime.Now.ToString("T") %></h1>
    
    <%= Html.ActionLink("Reload", "Time") %>
    <%= Html.ActionLink("Clear", "Clear") %>

</asp:Content>
