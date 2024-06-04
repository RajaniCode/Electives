<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Movie>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <% using (Html.BeginForm())
       { %>
    
        Are you sure that you want to delete <%= Model.Title %>?
        
        <br /><br />
        
        <input type="submit" value="Delete" />
    
    <% } %>

</asp:Content>
