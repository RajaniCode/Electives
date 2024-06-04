<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsingUpdatePanelAnimation.aspx.cs" Inherits="UpdPnlAnimation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        function onUpdating() 
        {
            // get the divImage
            var panelProg = $get('divImage');
            // set it to visible
            panelProg.style.display = '';

            // hide label if visible      
            var lbl = $get('<%= this.lblText.ClientID %>');
            lbl.innerHTML = '';
        }

        function onUpdated() 
        {
            // get the divImage
            var panelProg = $get('divImage');
            // set it to invisible
            panelProg.style.display = 'none';
        }


    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <div id="divImage" style="display:none">
                     <asp:Image ID="img1" runat="server" ImageUrl="~/images/progress.gif" /> 
                     Processing...
                </div>                
                <br />
                <asp:Button ID="btnInvoke" runat="server" Text="Click" 
                    onclick="btnInvoke_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
        <cc1:UpdatePanelAnimationExtender ID="UpdatePanelAnimationExtender1"
        TargetControlID="UpdatePanel1" runat="server">
        <Animations>
            <OnUpdating>
               <Parallel duration="0">
                    <ScriptAction Script="onUpdating();" />
                    <EnableAction AnimationTarget="btnInvoke" Enabled="false" />                    
                </Parallel>
            </OnUpdating>
            <OnUpdated>
                <Parallel duration="0">
                    <ScriptAction Script="onUpdated();" /> 
                    <EnableAction AnimationTarget="btnInvoke" Enabled="true" />
                </Parallel>
            </OnUpdated>
        </Animations>
        </cc1:UpdatePanelAnimationExtender>        
    </div>
    </form>
</body>
</html>
