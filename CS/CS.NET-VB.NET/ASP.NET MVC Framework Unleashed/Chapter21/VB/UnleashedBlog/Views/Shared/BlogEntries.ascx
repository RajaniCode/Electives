<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl(of UnleashedBlog.PagedList(Of UnleashedBlog.BlogEntry))" %>

<%  For Each entry In Model%>
    <%  Html.RenderPartial("BlogEntry", entry)%>
<%  Next entry%>

<div id="pager">
	<%=Ajax.BlogPager(Model)%> 
</div>



