<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ControlStateVSViewState._Default"
 Trace="true" EnableViewState="false" %>

<%@ Register TagPrefix="aspSample" Namespace="ASPCS2008ControlStateVSViewState" Assembly="ASPCS2008ControlStateVSViewState" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>IndexButton test page</title>
  </head>
  <body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" ></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
    
        Click the button:
        <aspSample:IndexButton Text="IndexButton" 
            ID="IndexButton1" runat="server"/>
      <br />
      <br />
      The index stored in control state:<br />
      <asp:Label ID="Label1" Runat="server" Text="Label">
      </asp:Label>
        <span lang="en-us">&nbsp;</span><br />
        <br />
      <br />
      The index stored in view state:
        <br />
      <asp:Label ID="Label2" Runat="server" Text="Label">
      </asp:Label>
      <br />
      
    </ContentTemplate>    
    </asp:UpdatePanel>
    </form>
  </body>

</html>
