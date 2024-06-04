<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.Person>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	PersonDetail
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h3>Edit Customer Information</h3>    
    <% Html.RenderPartial("_PersonDetail"); %>
   
    <div>
        <%: Html.ActionLink("Back", "SalesInfo", new { customerid = Model.PersonId })%>
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
