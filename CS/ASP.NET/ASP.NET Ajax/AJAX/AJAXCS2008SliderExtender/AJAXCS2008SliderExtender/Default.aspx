<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="AJAXCS2008SliderExtender._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script type="text/javascript">

        function setColor()
        {    
        var slider1 = $get('slider1');    
        var redColor = slider1.value;
               
        var slider2 = $get('slider2');    
        var greenColor = slider2.value;
            
        var slider3 = $get('slider3');
        var blueColor = slider3.value; 
        
        var panel = $get('Panel1');
        var hexColor = toHex(redColor) + toHex(greenColor) + toHex(blueColor); 
        panel.style.backgroundColor = '#' + hexColor;
        var hexCode = $get('txtHexCode');
        hexCode.value = '#' + hexColor;
        }

        function toHex(dec) {
            // create list of hex characters
            var hexCharacters = "0123456789ABCDEF"
            // if number is out of range return limit
            if (dec < 0)
                return "00"
            if (dec > 255)
                return "FF"
            // decimal equivalent of first hex character in converted number
            var i = Math.floor(dec / 16)
            // decimal equivalent of second hex character in converted number
            var j = dec % 16
            // return hexadecimal equivalent
            return hexCharacters.charAt(i) + hexCharacters.charAt(j)
        }

        

    </script>

</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" />
    <div>
    
    <table border="0" cellpadding="5" cellspacing="0">
        <tr>
            <td>
                <ajaxToolkit:SliderExtender ID="SliderExtender1" BoundControlID="slider1_display"
                    Decimals="0" Minimum="0" Maximum="255" runat="server" TargetControlID="slider1"
                    EnableHandleAnimation="true"  TooltipText="{0}" />
                    
                <asp:TextBox ID="slider1" runat="server">
                </asp:TextBox>
                
                <asp:Label ID="slider1_display" runat="server">
                </asp:Label>
                
                <br />
                <br />
                
                <ajaxToolkit:SliderExtender ID="SliderExtender2" runat="server" BoundControlID="slider2_display"
                    Decimals="0" Maximum="255" Minimum="0" TargetControlID="slider2" 
                    EnableHandleAnimation="true"  TooltipText="{0}" />
                    
                <asp:TextBox ID="slider2" runat="server">
                </asp:TextBox>
                
                <asp:Label ID="slider2_display" runat="server">
                </asp:Label>
                <br />
                <br />
                
                <ajaxToolkit:SliderExtender ID="SliderExtender3" runat="server" BoundControlID="slider3_display"
                    Decimals="0" Maximum="255" Minimum="0" TargetControlID="slider3" 
                    EnableHandleAnimation="true"  TooltipText="{0}" />
                    
                <asp:TextBox ID="slider3" runat="server">
                </asp:TextBox>
                
                <asp:Label ID="slider3_display" runat="server">
                </asp:Label>
                
                <br />
                <br />
                
                <asp:Panel ID="Panel1" runat="server" Height="50px" Width="50px" Style="border: solid 1px #c0c0c0">
                </asp:Panel>
                
                <asp:TextBox ID="txtHexCode" runat="server" Style="text-transform: uppercase">
                </asp:TextBox>
                
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
