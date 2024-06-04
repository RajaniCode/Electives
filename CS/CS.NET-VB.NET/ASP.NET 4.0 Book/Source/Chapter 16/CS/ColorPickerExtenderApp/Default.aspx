<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     
</head>
<body>
    <form id="form1" runat="server">
   <h3>Color Picker Control</h3> <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
     <em>(Click the text box to show the color picker)</em><asp:TextBox runat="server" ID="Color1" MaxLength="6" AutoCompleteType="None" /><br />
        <ajaxToolkit:ColorPickerExtender ID="defaultCPE" runat="server" OnClientColorSelectionChanged="colorChanged" TargetControlID="Color1" />
        <div style="font-size: 90%">
    
        <script type="text/javascript">
            function colorChanged(sender) {
                sender.get_element().style.color = "#" + sender.get_selectedColor();
            }
        </script>
        
   


    <br />

  <em>(Click the image button to show the color picker)</em>    <asp:TextBox runat="server" ID="Color2" AutoCompleteType="None" MaxLength="6" style="float:left" />
        <asp:ImageButton runat="Server" ID="Image1" style="float:left;margin:0 3px" ImageUrl="~/images/cp_button.png" AlternateText="Click to show color picker" />
        <asp:Panel ID="Sample1" style="width:18px;height:18px;border:1px solid #000;margin:0 3px;float:left" runat="server" />
        <ajaxToolkit:ColorPickerExtender ID="buttonCPE" runat="server"
            TargetControlID="Color2" PopupButtonID="Image1" SampleControlID="Sample1" SelectedColor="33ffcc" />
            <br />
            <br />
        <br style="clear:both" />
        <div style="font-size: 90%">
            </div>
    </form>
</body>
</html>
