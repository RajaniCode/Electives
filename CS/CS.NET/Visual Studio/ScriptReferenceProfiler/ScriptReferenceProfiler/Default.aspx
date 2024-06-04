<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="ScriptReferenceProfiler" Namespace="ScriptReferenceProfiler"
    TagPrefix="cc2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How to improve Ajax performance</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
            <CompositeScript>
                <Scripts>
                    <asp:ScriptReference Name="MicrosoftAjax.js" />
                    <asp:ScriptReference Name="MicrosoftAjaxWebForms.js" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Common.Common.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Common.DateTime.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Compat.Timer.Timer.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Animation.Animations.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.ExtenderBase.BaseScripts.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Animation.AnimationBehavior.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.PopupExtender.PopupBehavior.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Common.Threading.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.Calendar.CalendarBehavior.js" Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                    <asp:ScriptReference Name="AjaxControlToolkit.FilteredTextBox.FilteredTextBoxBehavior.js"
                        Assembly="AjaxControlToolkit, Version=3.0.20820.16598, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" />
                </Scripts>
            </CompositeScript>
        </asp:ScriptManager>
        <br />
        <br />
        <asp:Label ID="lblDate" runat="server" Text="Date"></asp:Label>
        <asp:TextBox ID="txtDate" runat="server"></asp:TextBox><br />
        <br />
        <cc1:CalendarExtender ID="CalendarExtendertxtDate" runat="server" Format="dd/MM/yyyy"
            TargetControlID="txtDate">
        </cc1:CalendarExtender>
        <asp:Label ID="lblMobileNo" runat="server" Text="Mobile No"></asp:Label>
        <asp:TextBox ID="txtMobileNo" runat="server"></asp:TextBox>
        <cc1:FilteredTextBoxExtender ID="FilteredTextBoxExtenderMobileNo" runat="server"
            TargetControlID="txtMobileNo" FilterType="Numbers">
        </cc1:FilteredTextBoxExtender>
    </div>
    </form>
</body>
</html>
