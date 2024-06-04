<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
  <title>Design Patterns in ASP.NET</title>
  <link href="stylesheets/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <div class="heading">Design Patterns in ASP.NET</div>
  <form id="form1" runat="server">
  <div>

    <asp:Button ID="btn_CustList" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_CustList_Click" />
    Get customer list from CustomerModel<p />

    <asp:Button ID="btn_CustModel" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_CustModel_Click" />
    Get name for customer
    <asp:TextBox ID="txtID_CustModel" runat="server" Text="ALFKI" Columns="3" /> 
    from CustomerModel<p />

    <asp:Button ID="btn_CustDetails" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_CustDetails_Click" />
    Get details for customer
    <asp:TextBox ID="txtID_CustDetails" runat="server" Text="ALFKI" Columns="3" /> 
    from CustomerModel<p />

    <asp:Button ID="btn_ReposList" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_ReposList_Click" />
    Get customer list from customer Repository<p />

    <asp:Button ID="btn_ReposName" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_ReposName_Click" />
    Get name for customer 
    <asp:TextBox ID="txtID_ReposName" runat="server" Text="A" Columns="3" /> 
    from customer Repository<p />

    <asp:Button ID="btn_WSProxy" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_WSProxy_Click" />
    Get name for customer 
    <asp:TextBox ID="txtID_WSProxy" runat="server" Text="ALFKI" Columns="3" /> 
    from Web Service via Web Reference Proxy<p />

    <asp:Button ID="btn_WSAgent" runat="server" Text="&nbsp;&nbsp; &nbsp;" OnClick="btn_WSAgent_Click" />
    Get name for customer 
    <asp:TextBox ID="txtID_WSAgent" runat="server" Text="A" Columns="3" /> 
    from Web Service via Service Agent<p />
    
    Use Front Controller to display page 
    <asp:DropDownList ID="TransferList" runat="server" AutoPostBack="true" 
         OnSelectedIndexChanged="GoButton_Click">
      <asp:ListItem>> Select a destination...</asp:ListItem>
      <asp:ListItem>UseCaseController</asp:ListItem>
      <asp:ListItem>CustomerList</asp:ListItem>
      <asp:ListItem>CustomerDetails</asp:ListItem>
      <asp:ListItem>CityList</asp:ListItem>
      <asp:ListItem>SpecialCustomerList</asp:ListItem>
      <asp:ListItem>SpecialCustomerDetails</asp:ListItem>
      <asp:ListItem>SpecialCityList</asp:ListItem>
      <asp:ListItem>Publish-Subscribe</asp:ListItem>
      <asp:ListItem>Command-Observer</asp:ListItem>
      <asp:ListItem>TransferPage1.aspx</asp:ListItem>
      <asp:ListItem>TransferPage2.aspx</asp:ListItem>
      <asp:ListItem>TransferPage3.aspx</asp:ListItem>
      <asp:ListItem>TransferPage4.aspx</asp:ListItem>
      <asp:ListItem>TransferPage5.aspx</asp:ListItem>
    </asp:DropDownList>
    <noscript>
      <asp:Button ID="GoButton" runat="server" Text="Go" OnClick="GoButton_Click" />
    </noscript>
    <hr />
    <asp:Label ID="Label1" EnableViewState="false" runat="server" />
    <asp:GridView ID="GridView1" runat="server" EnableViewState="false" />
  </div>
  </form>
  <!--#include file="stylesheets\footer.inc" -->
  </body>
</html>
