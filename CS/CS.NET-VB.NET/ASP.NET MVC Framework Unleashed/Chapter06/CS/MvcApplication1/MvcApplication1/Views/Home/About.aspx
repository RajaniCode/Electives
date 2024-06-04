<%@ Page Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="aboutContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>About</h2>
    <p>

    <a href="<%= Url.Action("Delete") %>"><img src="../../Content/Delete.png" alt="Delete" style="border:0px" /></a>

    


    </p>
</asp:Content>
