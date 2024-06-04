<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/ViewMasterPage.Master"
    Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Controllers.TwitterViewData>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">    
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <% foreach (var item in Model)
       {  %>
    <a href="<%: item.AuthorUri %>" target="_blank">
        <%: item.AuthorName %></a>
    <p>
        <%= item.Content %></p>
    <img src="<%: item.Link %>" alt="Twitter Logo" /><br />
    <br />
    <% } %>
</asp:Content>
