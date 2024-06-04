<%@ Page Title="" Language="C#" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Upload File</h2>

    <form method="post" enctype="multipart/form-data" action="<%= Url.Action("Create") %>">
        <input name="upload" type="file" />
        <input type="submit" value="Upload File" />
    </form>

</asp:Content>
