<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
    <script runat="server">
	protected override void OnLoad(EventArgs e)
	{
		base.OnLoad(e);
		Label1.Text = DateTime.Now.ToString();
		System.Threading.Thread.Sleep(1645);
	}
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    Click on the Go Button to see the animation of UpdatePanel<br />
	
		<div style="background-color: Aqua; padding-left: 10px; padding: 10px; width: 
 		  200px"
		id="UpdatePanelContainer">
		<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
		<asp:Label ID="Label1" runat="server" Text=""></asp:Label>
		<input type="submit" value="Go" />
		</ContentTemplate>
		</asp:UpdatePanel>
		<ajaxToolkit:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1" 
 		  runat="server"
		TargetControlID="UpdatePanel1">
		<Animations>
		<OnUpdating>
		<Sequence duration="0.30" fps="25">
		<FadeOut AnimationTarget="UpdatePanelContainer" minimumOpacity="0.2" />
		</Sequence>
		</OnUpdating>
		<OnUpdated>
		<Sequence>
			<FadeIn AnimationTarget="UpdatePanelContainer" minimumOpacity="0.2" />
		</Sequence>
		</OnUpdated>
		</Animations>
		</ajaxToolkit:UpdatePanelAnimationExtender>

    </div>
    </form>
</body>
</html>
