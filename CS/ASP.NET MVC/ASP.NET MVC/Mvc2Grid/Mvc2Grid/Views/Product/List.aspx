<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IQueryable<Mvc2Grid.ProductViewModel>>" %>
<%@ Import Namespace="Mvc2Grid" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	List
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>List of Product</h2>
    <%=Html.DataGrid<ProductViewModel>() %>
    <div>
        <%=Html.PageLink((int)ViewData["CurrentPage"],
            (int)ViewData["TotalPages"],
            p => Url.Action("List",
                new { page = p,
                    sort = (string)ViewData["SortItem"] }))%>
    </div>
</asp:Content>

