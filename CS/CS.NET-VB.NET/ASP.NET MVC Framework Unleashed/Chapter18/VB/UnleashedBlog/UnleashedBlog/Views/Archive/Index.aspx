<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of UnleashedBlog.BlogEntry))" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
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
                Author
            </th>
            <th>
                Description
            </th>
            <th>
                DateModified
            </th>
            <th>
                DatePublished
            </th>
            <th>
                Name
            </th>
            <th>
                Text
            </th>
            <th>
                Title
            </th>
        </tr>

    <% For Each item In Model%>
    
        <tr>
            <td>
                <%--<%=Html.ActionLink("Edit", "Edit", New With {.id = item.PrimaryKey})%> |
                <%=Html.ActionLink("Details", "Details", New With {.id = item.PrimaryKey})%>--%>
            </td>
            <td>
                <%= Html.Encode(item.Id) %>
            </td>
            <td>
                <%= Html.Encode(item.Author) %>
            </td>
            <td>
                <%= Html.Encode(item.Description) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DateModified)) %>
            </td>
            <td>
                <%= Html.Encode(String.Format("{0:g}", item.DatePublished)) %>
            </td>
            <td>
                <%= Html.Encode(item.Name) %>
            </td>
            <td>
                <%= Html.Encode(item.Text) %>
            </td>
            <td>
                <%= Html.Encode(item.Title) %>
            </td>
        </tr>
    
    <% Next%>

    </table>

</asp:Content>

