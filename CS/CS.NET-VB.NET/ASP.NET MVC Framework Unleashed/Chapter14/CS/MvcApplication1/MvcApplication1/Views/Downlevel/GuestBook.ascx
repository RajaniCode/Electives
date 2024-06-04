<%@ Control Language="C#" Inherits="System.Web.Mvc.ViewUserControl<IEnumerable<MvcApplication1.Models.Guest>>" %>

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

<% foreach (var item in Model) { %>
    <div>
        <h3><%= Html.Encode(item.Name) %></h3>
        
        <%= Html.Encode(item.Message) %>
    </div>
<% } %>

