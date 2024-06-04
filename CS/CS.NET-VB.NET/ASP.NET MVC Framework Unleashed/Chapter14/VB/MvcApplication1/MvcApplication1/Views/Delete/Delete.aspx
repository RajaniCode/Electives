<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Movie)" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

    <% Using Html.BeginForm()%>
    
        Are you sure that you want to delete <%= Model.Title %>?
        
        <br /><br />
        
        <input type="submit" value="Delete" />
    
    <% End Using%>

</asp:Content>
