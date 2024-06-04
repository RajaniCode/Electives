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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
       See the rounders corners panel that containing the Name and Address field.
     <br />Enter the requried fields and click Go<br />
		<div>
			<asp:Panel ID="Panel1" runat="server" Width="200">
			<div style="padding-left:10px">Enter Name</div>
			<div style="padding-left:10px">
			<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		</div>
		<div style="padding-left:10px">Enter Address</div>
		<div style="padding-left:10px">
			<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
		</div><br />
		<div>
			<center><asp:Button ID="Button1" runat="server" Text="Go" onclick="Button1_Click" /></center>
		</div>
		</asp:Panel>
		<div>
			<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
		</div>
		<ajaxToolkit:RoundedCornersExtender ID="RoundedCornersExtender1" runat="server" 
 		  TargetControlID="Panel1" Radius="25" BorderColor="Blue" 
 		  BehaviorID="RoundedCornersBehavior1" Corners="All"  >
		</ajaxToolkit:RoundedCornersExtender>
		</div>
		</div>
    </div>
    </form>
</body>
</html>
