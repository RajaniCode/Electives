<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<DialogDemo.Models.Book>>" %>
    <div id="bookInfo">
    <div id="bookResult" class="resultMsg"><%: (null == TempData["message"] ? "" : TempData["message"].ToString()) %></div>
    <table>
        <tr>
            <th>
                Book Id
            </th>
            <th>
                Title
            </th>
            <th>
                Author
            </th>
            <th>
                Published
            </th>
            <th>
                Price
            </th>
            <th class="tedit">Edit</th>
            <th class="tedit">Delete</th>
        </tr>

    <% foreach (var item in Model) { %>
    
        <tr>
            <td style="text-align: center;">
                <%: item.BookId %>
            </td>
            <td>
                <%: item.Title %>
            </td>
            <td>
                <%: item.Author %>
            </td>
            <td style="text-align: center">
                <%: item.PublicationYear %>
            </td>
            <td style="text-align: right">
                <%: item.Price %>
            </td>
            <td class="tedit">
                <%: Html.ActionLink("Edit", "BookEdit", new { bookid = item.BookId, customerid = item.CustomerID }, new { @class="abookModal", title = "Edit Book" } )%> 
            </td>
            <td class="tedit">
                <%: Html.ActionLink("Delete", "BookDelete", new { bookid = item.BookId, customerid = item.CustomerID }, new { @class = "deleteButton", title = "\"" + item.Title + "\"" })%>
            </td>
        </tr>
    
    <% } %>
    </table>
    <p>
        <%: Html.ActionLink("Add Book", "BookCreate", null, new { @class = "abookCreate", title = "Add Book" })%>
    </p>
    </div>

