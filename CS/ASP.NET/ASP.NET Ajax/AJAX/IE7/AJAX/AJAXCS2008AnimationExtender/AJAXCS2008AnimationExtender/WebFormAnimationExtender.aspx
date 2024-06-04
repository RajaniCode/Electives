<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormAnimationExtender.aspx.cs" Inherits="AJAXCS2008AnimationExtender.WebFormAnimationExtender" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>AnimationExtender</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
    
      function pageLoad() {
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ajaxToolkit:ToolkitScriptManager runat="server" ID="ScriptManager1"  />
            <br />
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnInfo" runat="server" OnClientClick="return false;" Text="Click Here"/>
      
        
        <!-- "Wire frame" div used to transition from the button to the info panel -->
        <div id="flyout" style="display: none; overflow: hidden; z-index: 2; background-color: #FFFFFF; border: solid 1px #D0D0D0;"></div>
        
        <!-- Info panel to be displayed as a flyout when the button is clicked -->
        <div id="info" style="display: none; width: 250px; z-index: 2; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0); font-size: 12px; border: solid 1px #CCCCCC; background-color: #FFFFFF; padding: 5px;">
            <div id="btnCloseParent" style="float: right; opacity: 0; filter: progid:DXImageTransform.Microsoft.Alpha(opacity=0);">
                <asp:LinkButton id="btnClose" runat="server" OnClientClick="return false;" Text="X" ToolTip="Close"
                    Style="background-color: #666666; color: #FFFFFF; text-align: center; font-weight: bold; text-decoration: none; border: outset thin #FFFFFF; padding: 5px;" />
            </div>
            <div>
                <p>
                    Once you get the general idea of the animation's markup, you'll want to play a bit.  All of
                    the animations are created from simple, reusable building blocks that you can compose together.
                    Before long you'll be creating dazzling visuals.  By grouping steps together and specifying
                    them to be run either in sequence or in parallel, you'll achieve almost anything you can
                    imagine, without writing a single line of code!
                </p>
                <br />
                <p>
                    The XML defining the animations is very easy to learn and write, such as this example's
                    <asp:LinkButton id="lnkShow" OnClientClick="return false;" runat="server">show</asp:LinkButton> and
                    <asp:LinkButton OnClientClick="return false;" id="lnkClose" runat="server">close</asp:LinkButton>
                    markup.
                </p>
            </div>
        </div>
        
     
        
        <ajaxToolkit:AnimationExtender id="OpenAnimation" runat="server" TargetControlID="btnInfo">
            <Animations>
                <OnClick>
                    <Sequence>
                        <%-- Disable the button so it can't be clicked again --%>
                        <EnableAction Enabled="false" />
                        
                        <%-- Position the wire frame on top of the button and show it --%>
                        <ScriptAction Script="Cover($get('ctl00_SampleContent_btnInfo'), $get('flyout'));" />
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="block"/>
                        
                        <%-- Move the wire frame from the button's bounds to the info panel's bounds --%>
                        <Parallel AnimationTarget="flyout" Duration=".3" Fps="25">
                            <Move Horizontal="150" Vertical="-50" />
                            <Resize Width="260" Height="280" />
                            <Color PropertyKey="backgroundColor" StartValue="#AAAAAA" EndValue="#FFFFFF" />
                        </Parallel>
                        
                        <%-- Move the info panel on top of the wire frame, fade it in, and hide the frame --%>
                        <ScriptAction Script="Cover($get('flyout'), $get('info'), true);" />
                        <StyleAction AnimationTarget="info" Attribute="display" Value="block"/>
                        <FadeIn AnimationTarget="info" Duration=".2"/>
                        <StyleAction AnimationTarget="flyout" Attribute="display" Value="none"/>
                        
                        <%-- Flash the text/border red and fade in the "close" button --%>
                        <Parallel AnimationTarget="info" Duration=".5">
                            <Color PropertyKey="color" StartValue="#666666" EndValue="#FF0000" />
                            <Color PropertyKey="borderColor" StartValue="#666666" EndValue="#FF0000" />
                        </Parallel>
                        <Parallel AnimationTarget="info" Duration=".5">
                            <Color PropertyKey="color" StartValue="#FF0000" EndValue="#666666" />
                            <Color PropertyKey="borderColor" StartValue="#FF0000" EndValue="#666666" />
                            <FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" />
                        </Parallel>
                    </Sequence>
                </OnClick>
            </Animations>
        </ajaxToolkit:AnimationExtender>
        <ajaxToolkit:AnimationExtender id="CloseAnimation" runat="server" TargetControlID="btnClose">
            <Animations>
                <OnClick>
                    <Sequence AnimationTarget="info">
                        <%--  Shrink the info panel out of view --%>
                        <StyleAction Attribute="overflow" Value="hidden"/>
                        <Parallel Duration=".3" Fps="15">
                            <Scale ScaleFactor="0.05" Center="true" ScaleFont="true" FontUnit="px" />
                            <FadeOut />
                        </Parallel>
                        
                        <%--  Reset the sample so it can be played again --%>
                        <StyleAction Attribute="display" Value="none"/>
                        <StyleAction Attribute="width" Value="250px"/>
                        <StyleAction Attribute="height" Value=""/>
                        <StyleAction Attribute="fontSize" Value="12px"/>
                        <OpacityAction AnimationTarget="btnCloseParent" Opacity="0" />
                        
                        <%--  Enable the button so it can be played again --%>
                        <EnableAction AnimationTarget="btnInfo" Enabled="true" />
                    </Sequence>
                </OnClick>
                <OnMouseOver>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FFFFFF" EndValue="#FF0000" />
                </OnMouseOver>
                <OnMouseOut>
                    <Color Duration=".2" PropertyKey="color" StartValue="#FF0000" EndValue="#FFFFFF" />
                </OnMouseOut>
             </Animations>
        </ajaxToolkit:AnimationExtender>
        
        <asp:Panel ID="xmlShow" runat="server" style="display: none; z-index: 3; background-color:#DDD; border: thin solid navy;">
            <pre style="margin: 5px">&lt;ajaxToolkit:AnimationExtender id="OpenAnimation" runat="server" TargetControlID="btnInfo"&gt;
&lt;Animations&gt;
    &lt;OnClick&gt;
        &lt;Sequence&gt;
           <em>&lt;%-- Disable the button --%&gt;</em>
            &lt;EnableAction Enabled="false" /&gt; 
           <em>&lt;%-- Show the flyout --%&gt;</em>
            &lt;Parallel AnimationTarget="flyout" Duration=".3" Fps="25"&gt;
                &lt;Move Horizontal="150" Vertical="-50" /&gt;
                &lt;Resize Height="260" Width="280" /&gt;
                &lt;Color AnimationTarget="flyout" PropertyKey="backgroundColor"
                        StartValue="#AAAAAA" EndValue="#FFFFFF" /&gt;
            &lt;/Parallel&gt;
          <em>&lt;%-- Fade in the text --%&gt; </em>
            &lt;FadeIn AnimationTarget="info" Duration=".2"/&gt;
          <em>&lt;%-- Cycle the text and border color to red and back --%&gt;</em>
            &lt;Parallel AnimationTarget="info" Duration=".5"&gt;
                &lt;Color PropertyKey="color"
                        StartValue="#666666" EndValue="#FF0000" /&gt;
                &lt;Color PropertyKey="borderColor"
                        StartValue="#666666" EndValue="#FF0000" /&gt;
            &lt;/Parallel&gt;
            &lt;Parallel AnimationTarget="info" Duration=".5"&gt;
                &lt;Color PropertyKey="color"
                        StartValue="#FF0000" EndValue="#666666" /&gt;
                &lt;Color PropertyKey="borderColor"
                        StartValue="#FF0000" EndValue="#666666" /&gt;
                &lt;FadeIn AnimationTarget="btnCloseParent" MaximumOpacity=".9" /&gt;
            &lt;/Parallel&gt;
        &lt;/Sequence&gt;
    &lt;/OnClick&gt;
&lt;/Animations&gt;
&lt;/ajaxToolkit:AnimationExtender&gt;</pre>
        </asp:Panel>
        
        <asp:Panel ID="xmlClose" runat="server" style="display: none; z-index: 3; background-color: #DDD; border: thin solid navy;">
            <pre style="margin: 5px">&lt;ajaxToolkit:AnimationExtender id="CloseAnimation" runat="server" TargetControlID="btnClose"&gt;
&lt;Animations&gt;
    &lt;OnClick&gt;
        &lt;Sequence AnimationTarget="info"&gt;
          <em>&lt;%-- Scale the flyout down to 5% to make it disappear --%&gt;</em>
            &lt;Parallel Duration=".3" Fps="15"&gt;
                &lt;Scale ScaleFactor="0.05" Center="true"
                        ScaleFont="true" FontUnit="px" /&gt;
                &lt;FadeOut /&gt;
            &lt;/Parallel&gt;
          <em>&lt;%-- Reset the styles on the info box --%&gt;</em>
            &lt;StyleAction Attribute="display" Value="none"/&gt;
            &lt;StyleAction Attribute="width" Value="250px"/&gt;
            &lt;StyleAction Attribute="height" Value=""/&gt;
            &lt;StyleAction Attribute="fontSize" Value="12px"/&gt;
          <em>&lt;%-- Re-enable the button --%&gt;</em>
            &lt;EnableAction Enabled="true"
                    AnimationTarget="btnInfo" /&gt;
        &lt;/Sequence&gt;
    &lt;/OnClick&gt;
&lt;/Animations&gt;
&lt;/ajaxToolkit:AnimationExtender&gt;
        </pre>
        </asp:Panel>
        
        <ajaxToolkit:HoverMenuExtender ID="hm2" runat="server" TargetControlID="lnkShow" PopupControlID="xmlShow" PopupPosition="Bottom" />
        <ajaxToolkit:HoverMenuExtender ID="hm1" runat="server" TargetControlID="lnkClose" PopupControlID="xmlClose" PopupPosition="Bottom" />
    </div>
    </form>
</body>
</html>
