<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.Person>" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Edit Customer Information</h3>    
    <% Html.RenderPartial("_PersonDetail"); %>
   
    <div>
        <%: Html.ActionLink("Back", "SalesInfo", new { customerid = Model.PersonId })%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
