<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Movie)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Details</h2>

    <fieldset>
        <legend>Fields</legend>
        <p>
            Id:
            <%= Html.Encode(Model.Id) %>
        </p>
        <p>
            Title:
            <%= Html.Encode(Model.Title) %>
        </p>
        <p>
            Director:
            <%= Html.Encode(Model.Director) %>
        </p>
        <p>
            DateReleased:
            <%= Html.Encode(String.Format("{0:g}", Model.DateReleased)) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.Id})%> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

