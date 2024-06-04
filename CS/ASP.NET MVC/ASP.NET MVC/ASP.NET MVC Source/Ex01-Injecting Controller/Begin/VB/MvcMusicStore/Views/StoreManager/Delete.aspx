<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcMusicStore.Album)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete Confirmation</h2>

    <p>
        Are you sure you want to delete the album titles
        <strong><%:Model.Title%></strong>
    </p>

    <div>
    <%
    Using Html.BeginForm()
    %>
        <input type="submit" value="Delete" /> |
        <%:Html.ActionLink("Back to List", "Index")%>
    <%
    End Using
    %>
    </div>


</asp:Content>