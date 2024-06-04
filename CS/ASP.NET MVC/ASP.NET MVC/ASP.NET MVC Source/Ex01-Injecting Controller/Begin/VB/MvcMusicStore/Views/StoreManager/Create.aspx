<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcMusicStore.StoreManagerViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Create
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Create</h2>

    <%
    Html.EnableClientValidation()
    %>

    <%
    Using Html.BeginForm()
    %>
        <%:Html.ValidationSummary(True)%>

        <fieldset>
            <legend>Create Album</legend>
            <%:Html.EditorFor(Function(model) model.Album, New With {Key .Artists = Model.Artists, Key .Genres = Model.Genres})%>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <%
    End Using
    %>

    <div>
        <% Html.ActionLink("Back to Albums", "Index")%>
    </div>

</asp:Content>