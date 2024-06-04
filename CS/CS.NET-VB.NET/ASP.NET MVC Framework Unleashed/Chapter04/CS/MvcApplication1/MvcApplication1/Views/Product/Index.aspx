<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MvcApplication1.Models.Product>>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table>

    <% foreach (var item in Model) { %>
        <tr>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:c}", item.Price)) %>
            </td>
        </tr>
    <% } %>

    </table>

</asp:Content>

