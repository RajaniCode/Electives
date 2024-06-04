<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create Product</h2>
    
    <% using (Html.BeginForm())
       { %>
    
        <label for="Name">Name:</label>
        <br /><%= Html.TextBox("Name") %>
    
        <br /><br />
        <label for="Price">Price:</label>
        <br /><%= Html.TextBox("Price") %>
    
        <br /><br />
        <input type="submit" value="Add Product" />
    
    <% } %>
    
   
</asp:Content>
