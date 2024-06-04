<%@ Page Title="" Language="vb" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of UnleashedBlog.BlogEntry)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Details
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%  Html.RenderPartial("BlogEntry")%>

	<div class="commentsContainer">
<%  For Each comment In Model.Comments%>
		<div class="commentContainer">
		<h3><%=Html.Encode(comment.Title)%></h3>
		<div class="commentHeader">
		Posted by <%=Html.NameLink(comment)%>
		on <%=comment.DatePublished.ToString("D")%>
		</div>
		<div class="commentText">
			<%=Html.Encode(comment.Text)%>
		</div>
		</div>
<%  Next%>
	</div>

	<fieldset>
	<legend>Add Your Comment</legend>
	<%=Html.ValidationSummary("Create was unsuccessful. Please correct the errors and try again.")%>

<%  Using Html.BeginForm("Create", "Comment")%>

		<%=Html.Hidden("Comment.BlogEntryId", Model.Id)%>
		<p>    
			<label for="Comment.Title">Title:</label>
			<br /><%=Html.TextBox("Comment.Title", "RE: " & Model.Title)%>  
		</p>
		<p>
			<label for="Comment.Name">Name:</label>
			<br /><%=Html.TextBox("Comment.Name")%>  
		</p>
		<p>        
			<label for="Comment.Email">Email:</label>
			<br /><%=Html.TextBox("Comment.Email")%>  
		</p>
		<p>
			<label for="Url">URL:</label>
			<br /><%=Html.TextBox("Comment.Url", String.Empty, New With {Key .size = 50})%>  
			<%=Html.ValidationMessage("Comment.Url", "*")%>
		</p>
		<p>
			<label for="Comment.Text">Comment:</label>
			<br /><%=Html.TextArea("Comment.Text", New With {Key .cols = 60, Key .rows = 5})%>  
		</p>
		<p>
			<input type="submit" value="Add Comment" />
		</p>
<%  End Using%>
	</fieldset>

</asp:Content>
