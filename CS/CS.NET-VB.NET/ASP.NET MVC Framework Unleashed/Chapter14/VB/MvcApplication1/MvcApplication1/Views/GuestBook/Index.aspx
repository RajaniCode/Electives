<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage(Of IEnumerable (Of MvcApplication1.Guest))" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <script src="../../Scripts/MicrosoftAjax.debug.js" type="text/javascript"></script>
    <script src="../../Scripts/MicrosoftMvcAjax.debug.js" type="text/javascript"></script>

    <h1>Guest Book</h1>

    <% Using Ajax.BeginForm("Create", New AjaxOptions With {.UpdateTargetId = "divMessages"})%>
    
        <label for="Name">Your Name:</label>
        <br /><%= Html.TextBox("Name")%>
        
        <br /><br />
        
        <label for="Message">Message:</label>
        <br /><%= Html.TextArea("Message")%>
    
        <br /><br />
        
        <input type="submit" value="Add Message" />
    
    <% End Using%>

    <div id="divMessages">
        <% Html.RenderPartial("Guests")%>
    </div>

</asp:Content>

