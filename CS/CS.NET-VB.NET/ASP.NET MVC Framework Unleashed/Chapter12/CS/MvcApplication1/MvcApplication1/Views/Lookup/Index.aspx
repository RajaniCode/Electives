<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MembershipUserCollection>" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% using (Html.BeginForm())
       { %>
    
        <%= Html.TextBox("Search") %>
        <input type="submit" value="Search" />
    
    <% } %>

    <ul>
        <% foreach (MembershipUser user in Model)
           { %>
        <li>
            <%= user.UserName%>
            <%= user.IsOnline ? "[Online]" : "[Offline]"%>
        </li>
        <% } %>
    </ul>


</asp:Content>
