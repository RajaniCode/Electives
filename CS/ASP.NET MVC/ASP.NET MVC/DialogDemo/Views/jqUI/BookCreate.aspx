<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<DialogDemo.Models.Book>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	BookCreate
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

   <h2>Add Book</h2>
    <% Html.RenderPartial("_BookCreate"); %>
    <div>
        <%: Html.ActionLink("Back", "SalesInfo", new { customerid = Model.CustomerID })%>
    </div>

</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>

