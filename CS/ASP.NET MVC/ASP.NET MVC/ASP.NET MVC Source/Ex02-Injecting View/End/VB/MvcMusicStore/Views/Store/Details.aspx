<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcMusicStore.Album)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <div id="album-details">
        <h3>
            <%:Model.Title%>
        </h3>
        <img alt="<%:Model.Title%>" src="<%:Model.AlbumArtUrl%>" />
        <p>
            <em>Genre:</em>
            <%:Model.Genre.Name%>
        </p>
        <p>
            <em>Artist:</em>
            <%:Model.Artist.Name%>
        </p>
        <p>
            <em>Price:</em>
            <%:String.Format("{0:F}", Model.Price)%>
        </p>
        <p class="button">
            <%:Html.ActionLink("Add to cart", "AddToCart", "ShoppingCart", New With {Key .id = Model.AlbumId}, "")%>
        </p>
    </div>

</asp:Content>