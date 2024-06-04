<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MembershipUserCollection)" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <% Using Html.BeginForm()%>
    
        <%= Html.TextBox("Search") %>
        <input type="submit" value="Search" />
    
    <% End Using%>

    <ul>
        <% For Each User As MembershipUser In Model%>
        <li>
            <%= user.UserName%>
            <%=IIf(User.IsOnline, "[Online]", "[Offline]")%>
        </li>
        <% Next%>
    </ul>


</asp:Content>
