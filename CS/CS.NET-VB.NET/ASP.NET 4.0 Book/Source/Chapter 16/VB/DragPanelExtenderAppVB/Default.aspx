<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
	.dragCursor
	{
		text-align:center;
		cursor:move;
		font-weight:bold;
	}
	</style>
</head>
<body>
    <form id="form1" runat="server">
   
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
    <div style="height: 300px; width: 250px; padding: 5px;">
                <asp:Panel ID="Panel1" runat="server" Width="250px">
                     <asp:Panel ID="Panel2" runat="server" Width="40%" Height="20%" BorderWidth="1px" BorderStyle="Solid" 
                        BorderColor="black">
                            Drag This Panel
                    </asp:Panel>     
                </asp:Panel>
            </div>        
        </div>
    
        <ajaxToolkit:DragPanelExtender ID="Panel1_DragPanelExtender" BehaviorID="DragP1" runat="server" 
            DragHandleID="Panel1" Enabled="True" TargetControlID="Panel1">
        </ajaxToolkit:DragPanelExtender>
        <script type="text/javascript" language="javascript">

            function pageLoad() {
                // call the savePanelPosition when the panel is moved
                $find('DragP1').add_move(savePanelPosition);
                var elem = $get("<%=HiddenField1.ClientID%>");
                if (elem.value != "0") {
                    var temp = new Array();
                    temp = elem.value.split(';');
                    // set the position of the panel manually with the retrieve value
                    $find('<%=Panel1_DragPanelExtender.BehaviorID%>').set_location(new Sys.UI.Point(parseInt(temp[0]), parseInt(temp[1])));
                }
            }

            function savePanelPosition() {
                var elem = $find('DragP1').get_element();
                var loc = $common.getLocation(elem);
                var elem1 = $get("<%=HiddenField1.ClientID%>");
                // store the value in the hidden field
                elem1.value = loc.x + ';' + loc.y;
            }
                   
        </script> 
        
    <asp:Button ID="Button1" runat="server" Text="Button"/>
    <asp:HiddenField ID="HiddenField1" runat="server" Value="0" />
    
    
    
    
    
    </form>
</body>
</html>
