<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPAJAXCS2008UpdateProgress._Default" %>

<%@ Import Namespace="System.Threading"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
protected void ButtonTime_Click(object sender, EventArgs e)
{
    Thread.Sleep(5000);
}
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml">

<head id="Head1" runat="server">
    <title>UpdateProgress</title>
    <%--<link href="StyleSheet.css" rel="stylesheet" type="text/css" />--%>
   <style type="text/css">
       .Centre
        {
	        background-color:Transparent;
	        color:#fff;
	        width: 150px;
	        text-align: center;
	        vertical-align: middle;
	        position: absolute;
	        bottom: 50%;
	        left: 45%;
        }
       .TransparentSilverBackground 
        {
	        position: fixed;
	        top: 0;
	        left: 0;
        	
	        background-color: Silver;
	        /* filter:alpha(opacity=70); */
	        /* opacity:0.7; */
        	
	        /* opacity:0.50; */ /* firefox, opera, safari, chrome */
            -ms-filter:"progid:DXImageTransform.Microsoft.Alpha(opacity=30)"; /* IE 8 */
	        /* filter:alpha(opacity=50); */ /* IE 4, 5, 6 and 7 */
            /* zoom:1 /* so the element "hasLayout" */
            /* or, to trigger "hasLayout" set a width or height */

	        height: 100%;
	        width: 100%;
	        min-height: 100%;
	        min-width: 100%
        	
        }
    </style>
</head>

<body>
<form id="form1" runat="server">
<asp:ScriptManager ID="ScriptManager1" runat="server" />

    <asp:UpdatePanel ID="UpdatePanelButtonTime" runat="server">
        <ContentTemplate>

             <%= DateTime.Now.ToString("T") %>

            <asp:Button
                id="ButtonTime"
                Text="Update"
                Runat="server" 
                OnClick="ButtonTime_Click"/>

        </ContentTemplate>
    </asp:UpdatePanel>


    <asp:UpdateProgress ID="UpdateProgressUpdatePanelButtonTime" runat="server">
            <ProgressTemplate>
              <div class="TransparentSilverBackground">              
              <div class="Centre">
              <asp:Image ID="ajaxLoadNotificationImage" runat="server" ImageUrl="~/images/ajax-loader.gif" />
              </div>
              </div>
                                                    
               <%-- <iframe frameborder="0" 
                    src="about:blank"
                    style="border:0px;
                    position:absolute;
                    z-index:9;
                    left:0px;
                    top:0px;
                    width:expression(this.offsetParent.scrollWidth);
                    height:expression(this.offsetParent.scrollHeight);
                    filter:progid:DXImageTransform.Microsoft.Alpha(Opacity=75, FinishOpacity=0, Style=0, StartX=0, FinishX=100, StartY=0, FinishY=100);">
                </iframe>

            <div style=
                "position:absolute;
                z-index:10;
                left:expression((this.offsetParent.clientWidth/2)-(this.clientWidth/2)+this.offsetParent.scrollLeft);
                top:expression((this.offsetParent.clientHeight/2)-(this.clientHeight/2)+this.offsetParent.scrollTop);">
                <br />
                <asp:Image
                    id="ImageUpdateProgressUpdatePanelButtonTime"
                    ImageUrl="~/images/ajax-loader.gif"
                    Runat="server"/>   
            </div>--%>

           </ProgressTemplate>
    </asp:UpdateProgress>  

</form>
</body>
</html>
