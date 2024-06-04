<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Movie>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

        
    <h1><%= DateTime.Now.ToString("T") %></h1>
    
    <ul>
    <% foreach (var movie in Model)
       {%>
    
    <li><%= movie.Title%></li>
    
    <% } %>
    </ul>

</asp:Content>

