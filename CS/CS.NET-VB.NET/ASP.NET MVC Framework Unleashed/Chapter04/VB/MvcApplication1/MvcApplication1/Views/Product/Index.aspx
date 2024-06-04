<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Product))" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <table>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:c}", item.Price)) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

