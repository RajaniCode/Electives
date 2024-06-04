<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm("ProductArray", "Product"))
       { %>
    
        Product 1:
        <p>
        Id: <%= Html.TextBox("Id") %> 
        <br />
        Name:  <%= Html.TextBox("Name") %>
        </p>
        
        Product 2:
        <p>
        Id: <%= Html.TextBox("Id") %> 
        <br />
        Name:  <%= Html.TextBox("Name") %>
        </p>
    
        <input type="button" value="Submit" />
    
    
    <% } %>

</asp:Content>
