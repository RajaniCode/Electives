<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Movie))" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h1><%= DateTime.Now.ToString("T") %></h1>
    
    <ul>
    <% For Each movie In Model%>
    
    <li><%= movie.Title%></li>
    
    <% Next%>
    </ul>

</asp:Content>

