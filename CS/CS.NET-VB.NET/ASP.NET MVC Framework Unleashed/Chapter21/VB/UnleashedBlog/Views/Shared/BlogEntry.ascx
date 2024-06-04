<%@ Control Language="vb" Inherits="System.Web.Mvc.ViewUserControl(Of UnleashedBlog.BlogEntry)" %>


<div class="blogEntryContainer">

	<h2 class="blogEntryDatePublished"><%=Model.DatePublished.ToString("D")%></h2>
	<h3 class="blogEntryTitle"><%=Html.BlogLink(Model)%></h3>

	<div class="blogEntryText">
		<%=Model.Text%>
	</div>

	<div class="blogEntryFooter">
		Posted by <%=Model.Author%> at <%=Model.DatePublished.ToString("t")%>
		with <%=Model.CommentCount%> comments.
	</div>

</div>
