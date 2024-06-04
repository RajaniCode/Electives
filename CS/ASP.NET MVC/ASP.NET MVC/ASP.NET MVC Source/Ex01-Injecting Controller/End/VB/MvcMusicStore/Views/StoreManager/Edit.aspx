<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcMusicStore.StoreManagerViewModel)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    Edit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit</h2>

    <%
    Html.EnableClientValidation()
    %>

    <%
    Using Html.BeginForm()
    %>
        <%:Html.ValidationSummary(True)%>

        <fieldset>
            <legend>Edit Album</legend>

            <%:Html.EditorFor(Function(model) model.Album, New With {Key .Artists = Model.Artists, Key .Genres = Model.Genres})%>

            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>

    <%
    End Using
    %>

    <div>
        <%:Html.ActionLink("Back to List", "Index")%>
    </div>

</asp:Content>