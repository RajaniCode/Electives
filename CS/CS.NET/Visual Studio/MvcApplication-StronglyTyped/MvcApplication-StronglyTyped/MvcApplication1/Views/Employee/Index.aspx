<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication1.Models.Employee>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Index</h2>

    <%= Html.ValidationSummary("Edit was unsuccessful. Please correct the errors and try again.") %>

    <% using (Html.BeginForm())
       {%>
     <fieldset>
            <legend>Employee</legend>
            <p>
                <%= Html.LabelFor(o => o.GivenName) %>
                <%= Html.EditorFor(o => o.GivenName) %>
                <%= Html.ValidationMessage("GivenName", "*") %>
            </p>
            <p>
                <%= Html.LabelFor(o => o.Surname) %>
                <%= Html.EditorFor(o => o.Surname) %> 
                <%= Html.ValidationMessage("Surname", "*") %>
            </p>
            <p>
                <%= Html.LabelFor(o => o.DateOfBirth) %>
                <%= Html.EditorFor(o => o.DateOfBirth)%>           
                <%= Html.ValidationMessage("DateOfBirth", "*") %>
            </p>
            <p>
                <%= Html.LabelFor(o => o.Permanent) %>
                <%= Html.EditorFor(o => o.Permanent) %> 
                <%= Html.ValidationMessage("Permanent", "*") %>
            </p>
            <p>
                <%= Html.LabelFor(o => o.Salary) %>
                <%= Html.EditorFor(o => o.Salary)%>
                <%= Html.ValidationMessage("Salary", "*") %>
            </p>
            <p>
                <input type="submit" value="Save" />
            </p>
        </fieldset>
        <% } %>
    <div>
        <%=Html.ActionLink("Back to List", "Index") %>
    </div>
</asp:Content>

