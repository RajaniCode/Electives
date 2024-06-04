<%@ Control Language="VB" Inherits="System.Web.Mvc.ViewUserControl(Of IEnumerable (Of MvcApplication1.Guest))" %>

<label for="Name">Your Name:</label>
<br /><%= Html.TextBox("Name")%>
<%= Html.ValidationMessage("Name") %>

<br /><br />

<label for="Message">Message:</label>
<br /><%= Html.TextArea("Message")%>
<%= Html.ValidationMessage("Message") %>

<br /><br />

<input type="submit" value="Add Message" />

<hr />

<%  For Each item In Model%>
    <div>
        <h3><%= Html.Encode(item.Name) %></h3>
        
        <%= Html.Encode(item.Message) %>
    </div>
<% Next%>

