<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit"    Namespace="AjaxControlToolkit"    TagPrefix="ajaxToolkit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .seadragon
        {
            width: 470px;
            height: 400px;
            background-color: black;
            border: 1px solid black;
            color: white; 
        }
        .overlay
        {
            background-color: white;
            opacity: 0.7;
            filter: alpha(opacity=70);
            border: 1px solid red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    <div>
      <center>
    <h3>ZOOMING THE IMAGE</h3>
              <ajaxToolkit:Seadragon ID="Seadragon2" CssClass="seadragon" runat="server" SourceUrl="dzc_output.xml">
            <ControlsCollection>
                <ajaxToolkit:SeadragonControl runat="server" Anchor="TOP_RIGHT">                    
                </ajaxToolkit:SeadragonControl>
            </ControlsCollection>
            <OverlaysCollection>
                <ajaxToolkit:SeadragonScalableOverlay runat="server" Rect-Height="0.24"
                    Rect-Width="0.26" CssClass="overlay" 
                    Rect-Point-X="0.14" Rect-Point-Y="0.06">
                </ajaxToolkit:SeadragonScalableOverlay>
            </OverlaysCollection>
        </ajaxToolkit:Seadragon>
        </center>
    </div>
    </form>
</body>
</html>
