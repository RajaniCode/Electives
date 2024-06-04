<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="MvcMusicStore.MyBasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Browse Albums
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div>
<%=Me.MessageService.Message%>
<br />
<img alt="<%:Me.MessageService.Message%>"src="<%:Me.MessageService.ImageUrl%>" />
</div>

    <div class="genre">
        <p><strong><%:Model.Genre.Name%>:</strong> <%:Model.Genre.Description%></p>

        <ul id="album-list">
            <%
            For Each album In Model.Albums
            %>

            <li>
                <a href="<%:Url.Action("Details", New With {Key .id = album.AlbumId})%>">
                    <img alt="<%:album.Title%>" src="<%:album.AlbumArtUrl%>" />
                    <span><%:album.Title%></span>
                </a>
            </li>

            <%
            Next album
            %>
        </ul>

    </div>

</asp:Content>