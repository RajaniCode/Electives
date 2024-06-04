<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/Site.Master" Inherits="System.Web.Mvc.ViewPage" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<%  Using Html.BeginForm()%>

 Where did you hear about our product?
 
 <ul>
    <li>
    <input name="source" type="checkbox" value="newspaper" /> newspaper 
    </li>
    <li>
    <input name="source" type="checkbox" value="magazine" /> magazine 
    </li>
    <li>
    <input name="source" type="checkbox" value="websiter" /> website 
    </li>
 </ul>
 
 <input type="submit" value="Submit Survey" />
 
<% End Using%> 
 
</asp:Content>
