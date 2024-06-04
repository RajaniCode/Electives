<%@ Page Title="" Language="VB" MasterPageFile="~/Views/Shared/BookMasterPage.Master" Inherits="System.Web.Mvc.ViewPage(Of BookDetailMVCAppVB.ClassBook)" %>

<asp:Content ID="Content1" ContentPlaceHolderID="TitleContent" runat="server">
	Index
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Book Information</h2>
    <h3>Black Book ASP.NET </h3>
      <table border="2">
    
    <tr>
    <td align="center" style="background-color:Silver">BookName</td>
    <td><%=Model.BName %></td>
    
    </tr>
    <tr>
    <td align="center" style="background-color:Silver">Edition</td>
    <td><%=Model.BEdition %></td>    
    </tr>

     <tr>
    <td align="center" style="background-color:Silver">Price</td>
    <td><%=Model.BPrice %></td>
    
    </tr>

 <tr>
    <td align="center" style="background-color:Silver">ISBN number</td>
    <td><%=Model.BISBN %></td>
    
    </tr>

 <tr>
    <td align="center" style="background-color:Silver">PublisherName</td>
    <td><%=Model.publisher %></td>
    
    </tr>
       
    </table>

</asp:Content>
