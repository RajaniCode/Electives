<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	personInfo
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>personInfo</h2>

    <fieldset>
        <legend>Fields</legend>
        
        <div class="display-label">PersonId</div>
        <div class="display-field"><%: Model.PersonId %></div>
        
        <div class="display-label">FirstName</div>
        <div class="display-field"><%: Model.FirstName %></div>
        
        <div class="display-label">LastName</div>
        <div class="display-field"><%: Model.LastName %></div>
        
    </fieldset>
    <p>
        <%: Html.ActionLink("Edit", "Edit", new { /* id=Model.PrimaryKey */ }) %> |
        <%: Html.ActionLink("Back", "Index") %>
    </p>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

