<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server"> 
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
   
    <div>
   <h3> Please fill the textboxes and click the submit button to see the use of NoBot 
		control</h3><br />      
		<br />
		<asp:Label ID="Label1" runat="server" Text="Enter your name"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
		&nbsp;&nbsp;
		<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
		<br /><br /><asp:Label ID="Label2" runat="server" Text="Enter application 
 		  number"></asp:Label>
		&nbsp;<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
		<br /><br /><asp:Button ID="Button1" runat="server" Text="Submit" 
            onclick="Button1_Click" />
		<br /><br />
		<asp:Label ID="Label3" runat="server" Width="500px" BackColor="#CCFFCC" Font-Size="Larger"></asp:Label>
		
		<ajaxToolkit:NoBot ID="NoBot1" runat="server" ResponseMinimumDelaySeconds="8" 
            CutoffMaximumInstances="10" CutoffWindowSeconds="60" 
            ongeneratechallengeandresponse="NoBot1_GenerateChallengeAndResponse" />
         </div>    
    </form>
</body>
</html>
