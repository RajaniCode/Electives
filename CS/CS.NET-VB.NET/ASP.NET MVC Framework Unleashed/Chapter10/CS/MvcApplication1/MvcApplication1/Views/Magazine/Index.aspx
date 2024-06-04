<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>Welcome to the home page of our website!</h1>
    
    <% Html.RenderPartial("News"); %>


</asp:Content>
