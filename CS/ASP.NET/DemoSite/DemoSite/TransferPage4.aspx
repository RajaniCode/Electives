<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransferPage4.aspx.cs" Inherits="TransferPage4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>The Publish-Subscribe Pattern</title>
  <link href="stylesheets/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <div class="heading">Build a Car using the Publish-Subscribe Pattern</div>
  <form id="form1" runat="server">
  <div>
    Motor Car Name: 
    <asp:DropDownList ID="lstCarName" runat="server">
      <asp:ListItem Text="SuperRoadster" />
      <asp:ListItem Text="SportsCoupe" />
      <asp:ListItem Text="MassiveWagon" />
    </asp:DropDownList>
    <p />
    <asp:CheckBox ID="chk_Transport" runat="server" Checked="true" Text="Notify Transport Department"/><br />
    <asp:CheckBox ID="chk_Sales" runat="server" Checked="true" Text="Notify Sales Department"/><br />
    <asp:CheckBox ID="chk_Parts" runat="server" Checked="true" Text="Notify Parts Department"/><p />
    <p />
    <asp:Label ID="lblResults" runat="server" EnableViewState="false" />
    <p />
    <asp:Button ID="btn_Build" runat="server" Text="Build Car" OnClick="btn_Build_Click" />
    <asp:Button ID="btn_Close" runat="server" Text="Close" OnClick="btn_Close_Click" />
    <p />
    Actual URL is: <asp:Label ID="lblActualPath" runat="server" />
  </div>
  </form>
  <!--#include file="stylesheets\footer.inc" -->
</body>
</html>
