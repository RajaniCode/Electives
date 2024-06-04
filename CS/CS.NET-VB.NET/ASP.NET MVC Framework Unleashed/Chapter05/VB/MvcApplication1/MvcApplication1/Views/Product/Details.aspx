<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Product)" %>

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
            Name:
            <%= Html.Encode(Model.Name) %>
        </p>
        <p>
            Description:
            <%= Html.Encode(Model.Description) %>
        </p>
        <p>
            Price:
            <%= Html.Encode(String.Format("{0:F}", Model.Price)) %>
        </p>
    </fieldset>
    <p>

        <%=Html.ActionLink("Edit", "Edit", New With {.id = Model.Id})%> |
        <%=Html.ActionLink("Back to List", "Index") %>
    </p>

</asp:Content>

