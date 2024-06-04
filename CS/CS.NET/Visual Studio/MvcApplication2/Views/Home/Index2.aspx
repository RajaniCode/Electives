<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<MvcApplication2.Models.Car>" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index2
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <form method="post" action="/Home/PostCars">
        <%: Html.AntiForgeryToken("Cars") %>
        <%: Html.ListBox("Cars") %>
        <input type="submit" value="Post Data" />
    </form>
    
    <p>
        <%: Html.ActionLink("Create New", "Create") %>
    </p>

</asp:Content>

