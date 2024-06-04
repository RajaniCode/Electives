<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
  <h2>  Click on the calender button to open the calender</h2>
			
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>

			<div>
			<asp:UpdatePanel ID="UpdatePanel1" runat="server">
			<ContentTemplate>
			<asp:TextBox ID="MyDate" runat="server" Width="150px"></asp:TextBox>
			&nbsp;
			<ajaxToolkit:CalendarExtender ID="CalendarExtender1" runat="server" 
 			  TargetControlID="MyDate" Format="MMMM d, yyyy" PopupButtonID="Image1" />
			<img id="Image1" runat="server" src="~/images/Calendar.png" alt=""/>

			</ContentTemplate>
			</asp:UpdatePanel>

  </div>
  
    </form>
</body>
</html>
