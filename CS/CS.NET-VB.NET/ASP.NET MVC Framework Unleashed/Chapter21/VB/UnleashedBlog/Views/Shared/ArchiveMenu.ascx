<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable(Of UnleashedBlog.ArchiveInfo))" %>

<div class="archiveMenuContainer">
	<h4>Archives</h4>
	<ul>
<%
	   For Each item In Model
%>
		<li>
		<%=Html.ArchiveLink(item)%>
		</li>
<%
	   Next item
%>
	</ul>
</div>