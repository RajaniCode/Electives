<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1>The Index View</h1>
    
    <% Html.RenderPartial("Featured", ViewData("featured"))%>

</asp:Content>

