<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

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
    <div>
    
    <h2>  Click on the calendar button to open the calendar</h2>
			
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

    </div>
    </form>
</body>
</html>
