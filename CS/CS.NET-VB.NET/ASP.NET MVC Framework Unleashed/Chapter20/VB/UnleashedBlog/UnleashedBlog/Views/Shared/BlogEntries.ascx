<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of UnleashedBlog.PagedList (Of UnleashedBlog.BlogEntry))" %>

<%  For Each entry In Model%>

    <div class="blogEntryContainer">
    
        <h2 class="blogEntryDatePublished"><%= entry.DatePublished.ToString("D") %></h2>
        <h3 class="blogEntryTitle"><%= Html.BlogLink(entry) %></h3>
    
        <div class="blogEntryText">
            <%= entry.Text %>
        </div>
    
        <div class="blogEntryFooter">
            Posted by <%= entry.Author %> at <%= entry.DatePublished.ToString("t") %>
        </div>
    
    </div>

<% Next%>

<div id="pager">
    <%= Ajax.BlogPager(Model) %> 
    
</div>

