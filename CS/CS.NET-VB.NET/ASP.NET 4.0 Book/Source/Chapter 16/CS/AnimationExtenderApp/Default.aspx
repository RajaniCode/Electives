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
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
    <asp:Button ID="Button1" runat="server" Text="Button" />
		<ajaxToolkit:AnimationExtender ID="AnimationExtender1" runat="server" 
		  TargetControlID="Button1">
		<Animations>
		<OnMouseOver>
			<Color Duration=".2" StartValue="#FFFFFF" EndValue="#FF0000" 
 			  Property="style" PropertyKey="color" />     
		</OnMouseOver>
		<OnMouseOut>
		<Color Duration=".2" EndValue="#FFFFFF" StartValue="#FF0000" 
 		  Property="style" PropertyKey="color" />                            
		</OnMouseOut>
		</Animations>
		</ajaxToolkit:AnimationExtender>
		<asp:Panel ID="Panel1" runat="server" Enabled="true">This is a very basic example 
 		  of AnimationExtender</asp:Panel>
		<ajaxToolkit:AnimationExtender ID="AnimationExtender2" runat="server" 
 		  TargetControlID="Panel1">
			<Animations>
				<OnHoverOver>
					<FadeIn Duration=".2" Fps="20" />
				</OnHoverOver>
				<OnHoverOut>
					<FadeOut Duration=".5" Fps="30" />
				</OnHoverOut>
			</Animations>
		</ajaxToolkit:AnimationExtender>

    </div>
    </form>
</body>
</html>
