<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<title></title>
   <script runat="server">
	<System.Web.Services.WebMethod()> _
	<System.Web.Script.Services.ScriptMethod()> _
	Public Shared Function GetImages() As AjaxControlToolkit.Slide()
           Return New AjaxControlToolkit.Slide() {New AjaxControlToolkit.Slide("images/Blue Hills.jpg", "Blue Hills", "Go Blue"), New AjaxControlToolkit.Slide("images/Sunset.jpg", "Setting Sun", "Sunset"), New AjaxControlToolkit.Slide("images/winter.jpg", "winter", "Wintery..."), New AjaxControlToolkit.Slide("images/Water lilies.jpg", "Water lilies", "Flower"), New AjaxControlToolkit.Slide("images/VerticalPicture.jpg", "Hills", "Hill")}
	End Function
	</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
		<asp:Label ID="Label1" runat="server" BackColor="LightPink" ></asp:Label>
		<asp:Image ID="Image1" runat="server" Height="450px" Width="600px" 
 		  ImageUrl="~/images/Blue Hills.jpg" />
		<asp:Label ID="Label2" runat="server" BackColor="Magenta" ></asp:Label><br />    
		<asp:Button ID="Button1" runat="server" Text="Back" />
		<asp:Button ID="Button2" runat="server" Text="Play" />
		<asp:Button ID="Button3" runat="server" Text="Next" /><br />
		<ajaxToolkit:SlideShowExtender ID="SlideShowExtender1" runat="server" TargetControlID="Image1" AutoPlay="true" Loop="true" PreviousButtonID="Button1" 
 		  PlayButtonID="Button2" PlayButtonText="Play" StopButtonText="Pause" 
 		  NextButtonID="Button3" SlideShowServiceMethod="GetImages" 
 		  ImageTitleLabelID="Label1" ImageDescriptionLabelID="Label2">
		</ajaxToolkit:SlideShowExtender>
		</ContentTemplate>        
		</asp:UpdatePanel>

    </div>
    </form>
</body>
</html>
