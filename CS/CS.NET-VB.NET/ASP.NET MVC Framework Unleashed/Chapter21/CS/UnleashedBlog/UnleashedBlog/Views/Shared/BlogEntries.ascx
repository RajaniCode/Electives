<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<Paging.PagedList<UnleashedBlog.Models.BlogEntry>>" %>

<% foreach (var entry in Model)
   { %>
    <% Html.RenderPartial("BlogEntry", entry); %>
<% } %>

<div id="pager">
    <%= Ajax.BlogPager(Model) %> 
    
</div>

    

