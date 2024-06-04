<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>The Details View</h2>
   
    <% Html.RenderPartial("Featured", ViewData["featured"]); %>


</asp:Content>
