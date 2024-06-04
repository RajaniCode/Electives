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
    Select the Book from the list given below by moving the mouse over the drop down 
		menu<br />
	---------------------------------------------------------------------------------<br />
		
		<div>        
           
		<asp:TextBox ID="TextBox1" runat="server" 
		Text="Select the Book Name from this menu" Width="383px"></asp:TextBox>
		<asp:Panel ID="Panel1" runat="server" BorderWidth="2" BackColor="#FFCCCC" 
		BorderColor="Aqua">
		<asp:LinkButton ID="LinkButton1" runat="server">Visual Studio 2010 Black Book</asp:LinkButton><br />
		<asp:LinkButton ID="LinkButton3" runat="server" >ASP.NET in Simple Steps</asp:LinkButton><br />
		<asp:LinkButton ID="LinkButton4" runat="server" >VB.NET in  Simple Steps</asp:LinkButton><br />
		<asp:LinkButton ID="LinkButton5" runat="server" >C#.NET in Simple Steps</asp:LinkButton>               
		</asp:Panel>           
		<ajaxToolkit:DropDownExtender ID="DropDownExtender1" runat="server" 
 		  TargetControlID="TextBox1" DropDownControlID="Panel1">
		</ajaxToolkit:DropDownExtender>
		<asp:UpdatePanel ID="up1" runat="server"></asp:UpdatePanel>
		
    </div>
    </form>
</body>
</html>
