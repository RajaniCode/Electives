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
  <center>  <h3>MultiHandler Slider Control</h3></center>
    <div>
    <table>
       <tr>
                <td style="width:250px;float:left;">
                    <h3>One Handle</h3>
                    <br />
                    A single-handled slider :
                        <asp:HyperLink
                            ID="lnkSlider"
                            runat="server"                            
                            Text="Slider" />                
                    </td>
                <td style="width:205px;">
                    <table>
                        <tr>
                            <td style="width:140px;">
                                <asp:TextBox ID="sliderOne" runat="server" AutoPostBack="true" Text="0"/>
                                <ajaxToolkit:MultiHandleSliderExtender ID="multiHandleSliderExtenderOne" runat="server"
                                    BehaviorID="multiHandleSliderExtenderOne"
                                    TargetControlID="sliderOne"
                                    Minimum="-100"
                                    Maximum="100"
                                    Steps="5"
                                    Length="140"
                                    BoundControlID="lblSliderOne"
                                    ToolTipText="{0}">            
                                </ajaxToolkit:MultiHandleSliderExtender>
                            </td>
                            <td style="width:15px"></td>
                            <td style="width:auto">
                                <asp:Label ID="lblSliderOne" runat="server" style="text-align:right" Text="0" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <div style="padding-top:25px;text-align:center">
                                    <asp:UpdatePanel ID="updatePanelOne" runat="server" UpdateMode="Conditional">
                                        <ContentTemplate>
                                            <asp:Label ID="lblUpdateDate" runat="server" style="font-size:80%;" Text="Move Slider" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="sliderOne" EventName="TextChanged" />
                                        </Triggers>
                                    </asp:UpdatePanel>
                                </div>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
  
            <tr>
                <td style="height:175px;width:205px;" valign="top">
                    <br />
                    <h3>Two Handles - Vertical</h3>
                    <br />
                     This vertical slider has multiple handles and uses drag and hover effects. It also
                     supports animation. Clicking on the outer rail will move the closest handle.
                </td>
                <td style="height:175px;width:205px;" valign="top">    
                    <table>
                        <tr valign="middle">
                            <td>
                                <asp:TextBox ID="multiHandle2_1_BoundControl" runat="server" Width="30" Text="25" /> 
                            </td>
                            <td valign="top"> 
                                <asp:TextBox ID="sliderTwo" runat="server" Style="display:none;" />
                                <ajaxToolkit:MultiHandleSliderExtender ID="multiHandleSliderExtenderTwo" runat="server"
                                    BehaviorID="multiHandleSliderExtenderTwo"
                                    TargetControlID="sliderTwo"
                                    Minimum="0"
                                    Maximum="100"
                                    Length="175"
                                    TooltipText="{0}"
                                    Orientation="Vertical"
                                    EnableHandleAnimation="true"
                                    EnableKeyboard="false"
                                    EnableMouseWheel="false"
                                    ShowHandleDragStyle="true"
                                    ShowHandleHoverStyle="true">
                                    <MultiHandleSliderTargets>
                                        <ajaxToolkit:MultiHandleSliderTarget ControlID="multiHandle2_1_BoundControl" />
                                        <ajaxToolkit:MultiHandleSliderTarget ControlID="multiHandle2_2_BoundControl" />
                                    </MultiHandleSliderTargets>            
                                </ajaxToolkit:MultiHandleSliderExtender>
                            </td>
                            <td style="padding-left:21px">
                                <asp:TextBox ID="multiHandle2_2_BoundControl" runat="server" Width="30" Text="75" />
                            </td>
                        </tr>
                    </table>
               </td>
            </tr>
                  
            <tr>
                <td colspan="2" style="height:130px;" valign="middle">
                    <h3>Three Handles - Horizontal</h3><br />
                    This slider has three handles, showing that you can declare as many handles as fit 
                    your needs. It also demonstrates visibly distinguishing the inner range from the outer rail.
                </td>
            </tr>
            <tr valign="top">
                <td>
                    <asp:TextBox ID="multiHandle3_1_BoundControl" runat="server" Text="25" Style="display:none;" />
                    <asp:TextBox ID="multiHandle3_2_BoundControl" runat="server" Text="50" Style="display:none;" />
                    <asp:TextBox ID="multiHandle3_3_BoundControl" runat="server" Text="75" Style="display:none;" />
                    <asp:TextBox ID="sliderThree" runat="server" Style="display:none;" />
                    <ajaxToolkit:MultiHandleSliderExtender ID="multiSliderExtenderThree" runat="server"
                        BehaviorID="multiSliderExtenderThree"
                        TargetControlID="sliderThree"
                        Minimum="0"
                        Maximum="100"
                        Length="450"
                        EnableHandleAnimation="true"
                        EnableKeyboard="false"
                        EnableMouseWheel="false"
                        ShowInnerRail="true"
                        ShowHandleDragStyle="true"
                        ShowHandleHoverStyle="true">
                        <MultiHandleSliderTargets>
                            <ajaxToolkit:MultiHandleSliderTarget ControlID="multiHandle3_1_BoundControl" />
                            <ajaxToolkit:MultiHandleSliderTarget ControlID="multiHandle3_2_BoundControl" />
                            <ajaxToolkit:MultiHandleSliderTarget ControlID="multiHandle3_3_BoundControl" />
                        </MultiHandleSliderTargets>            
                    </ajaxToolkit:MultiHandleSliderExtender>
                </td>
            </tr>
           
            
        </table>
    </div>
    </form>
</body>
</html>
