<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.Book>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BookEdit
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Edit Book Information</h2>
    <% Html.RenderPartial("_BookEdit"); %>
    <div>
        <%: Html.ActionLink("Back", "SalesInfo", new { customerid = Model.CustomerID })%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">
<style type="text/css"> 
div.nonAjax
{
    display: block !important;
    margin: 15px 0 15px 30px;
}
</style>

</asp:Content>
