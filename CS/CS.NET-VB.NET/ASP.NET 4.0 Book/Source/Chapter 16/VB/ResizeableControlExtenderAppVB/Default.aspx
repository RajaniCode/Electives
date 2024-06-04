<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <title>ResizableControlExtender</title>
	<style type="text/css">
	.handling
	{
		width:15px;
		height:15px;
		background-color:Lime;
		display:block;
		cursor:crosshair;
	}
	.resizing
	{
		padding:4px;
		border-style:solid;
		border-width:4px;
		border-color:Green;
		
		line-height:normal;
	}
	</style>


</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    <h3>Drag the Image using the Square shown at the bottom right corner of the image</h3>
           
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
			<div>
			<asp:Panel ID="Panel1" runat="server" Height="200px" 
 			  style="width:200px;height:100px;">
			<asp:Image runat="server" ImageUrl="~/images/Tulips.jpg" ID="Image1" 
 			  Width="100%" Height="100%" />
			</asp:Panel>
			<ajaxToolkit:ResizableControlExtender ID="ResizableControlExtender1" 
 			  runat="server" TargetControlID="Panel1" HandleCssClass="handling" 
 			  ResizableCssClass="resizing" MaximumHeight="500" MinimumHeight="50" 
 			  MaximumWidth="500" MinimumWidth="50" HandleOffsetX="5" 
 			  HandleOffsetY="5">
			</ajaxToolkit:ResizableControlExtender>
			</div>


    </div>
    </form>
</body>
</html>
