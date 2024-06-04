<%@ Page Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="indexContent" ContentPlaceHolderID="MainContent" runat="server">
    <p>
        To learn more about this website, click the following link: 
        <%= Html.ActionLink("About this Website", "About" ) %> 
    </p>
</asp:Content>
