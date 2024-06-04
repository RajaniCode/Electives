<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable(Of ToyStore.Product))" %>

<asp:Content ID="indexTitle" ContentPlaceHolderID="TitleContent" runat="server">
    Home Page
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <p>
        <%=Html.ActionLink("Create New", "Create")%>
    </p>
    
    <table>
        <tr>
            <th></th>
            <th>
                Id
            </th>
            <th>
                Name
            </th>
            <th>
                Description
            </th>
            <th>
                Price
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%--<%=Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey})%>--%>
            </td>
            <td>
                <%=Html.Encode(item.Id)%>
            </td>
            <td>
                <%=Html.Encode(item.Name)%>
            </td>
            <td>
                <%=Html.Encode(item.Description)%>
            </td>
            <td>
                <%=Html.Encode(item.Price)%>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

