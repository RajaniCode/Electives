<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TransferPage1.aspx.cs" Inherits="TransferPage1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
  <title>The Use-Case-Controller Pattern</title>
  <link href="stylesheets/style.css" rel="stylesheet" type="text/css" />
</head>
<body>
  <div id="pageHeaderElement" runat="server" class="heading" />
  <form id="form1" runat="server">
  <div>
    <asp:Button ID="btn_Back" runat="server" Text="< Back" OnClick="btn_Back_Click" />
    <asp:Button ID="btn_Next" runat="server" Text="Next >" OnClick="btn_Next_Click" />
    <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" OnClick="btn_Cancel_Click" />
    <p />
    Actual URL is: <asp:Label ID="lblActualPath" runat="server" />
    <p />
    <asp:PlaceHolder ID="viewPlaceHolder" runat="server" EnableViewState="false" />
  </div>
  </form>
  <!--#include file="stylesheets\footer.inc" -->
</body>
</html>
