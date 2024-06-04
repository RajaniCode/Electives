<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage<IEnumerable<MsdnMvcWebGrid.Domain.Product>>" %>
<%@ Import Namespace="MsdnMvcWebGrid.Infrastructure" %>
<%@ Import Namespace="MsdnMvcWebGrid.Domain" %>
<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
    BasicStronglyTypedWebGridWebForms
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<h2>BasicStronglyTypedWebGridWebForms</h2>

    <%
        var grid = Html.Grid(Model);
    %>
    <%:grid.GetHtml(columns: grid.Columns(
            grid.Column("Name", format: item => Html.ActionLink(item.Name, "Details", "Product", new { id = item.ProductId }, null)),
            grid.Column("ListPrice", header: "List Price", format:item=>item.ListPrice.ToString("0.00"))
        )
    )
    %>
</asp:Content>
