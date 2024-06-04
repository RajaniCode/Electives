<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl(Of MvcMusicStore.Album)" %>

<script src="/Scripts/MicrosoftAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcAjax.js" type="text/javascript"></script>
<script src="/Scripts/MicrosoftMvcValidation.js" type="text/javascript"></script>

<p>
    <%:Html.LabelFor(Function(model) model.Title)%>
    <%:Html.TextBoxFor(Function(model) model.Title)%>
    <%:Html.ValidationMessageFor(Function(model) model.Title)%>
</p>            
<p>
    <%:Html.LabelFor(Function(model) model.Price)%>
    <%:Html.TextBoxFor(Function(model) model.Price)%>
    <%:Html.ValidationMessageFor(Function(model) model.Price)%>
</p>            
<p>
    <%:Html.LabelFor(Function(model) model.AlbumArtUrl)%>
    <%:Html.TextBoxFor(Function(model) model.AlbumArtUrl)%>
    <%:Html.ValidationMessageFor(Function(model) model.AlbumArtUrl)%>
</p>            
<p>
    <%:Html.LabelFor(Function(model) model.Artist)%>
    <%:Html.DropDownList("ArtistId", CType(ViewData("Artists"), SelectList))%>
</p>            
<p>
    <%:Html.LabelFor(Function(model) model.Genre)%>
    <%:Html.DropDownList("GenreId", CType(ViewData("Genres"), SelectList))%>
</p>