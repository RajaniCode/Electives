<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<UnleashedBlog.Models.ArchiveInfo>>" %>

<div class="archiveMenuContainer">
    <h4>Archives</h4>
    <ul>
    <% foreach (var item in Model) { %>
        <li>
        <%= Html.ArchiveLink(item) %>
        </li>
    <% } %>
    </ul>
</div>