<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Customer>>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                FirstName
            </th>
            <th>
                LastName
            </th>
            <th>
                Email
            </th>
            <th>
                Notes
            </th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td>
                <%= Html.ActionLink("Edit", "Edit", new { id=item.Id }) %> |
                <%= Html.ActionLink("Details", "Details", new { id=item.Id })%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.FirstName) %>
            </td>
            <td>
                <%= Html.Encode(item.LastName) %>
            </td>
            <td>
                <%= Html.Encode(item.Email) %>
            </td>
            <td>
                <%= Html.Encode(item.Notes) %>
            </td>
        </tr>
    
    <% } %>

    </table>

    <p>
        <%= Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

