<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of MvcApplication1.Product)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Delete
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Delete</h2>

 
    <% Using Html.BeginForm() %>
            <p>
            Are you sure you want to delete <%= Html.Encode(Model.Name) %>?
            
            </p>
            <p>
                <input type="submit" value="Delete" />
            </p>

    <% End Using %>


</asp:Content>
