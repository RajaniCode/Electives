<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 158px;
        }
        .style2
        {
            width: 198px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ScriptManager1" runat="server" EnablePartialRendering="true" /> 
    <asp:UpdatePanel ID="UpdatePanelButtonTime" runat="server">
    <ContentTemplate>
    <div style="height: 153px; width: 304px">
    
        <table style="width: 99%; height: 150px;">
            <tr>
                <td class="style2">
                    <asp:Label ID="Label1" runat="server" Text="Column1"></asp:Label>
                </td>
                <td class="style1">
                
                
                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                
                    
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Label ID="Label2" runat="server" Text="Column2"></asp:Label>
                </td>
                <td class="style1">
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    <asp:Button ID="ButtonPrevious" runat="server" onclick="ButtonPrevious_Click" Text="Previous" Width="50%" />
                </td>
                <td class="style1">
                    <asp:Button ID="ButtonNext" runat="server" onclick="ButtonNext_Click" Text="Next" Width="50%"  />
                </td>
            </tr>
        </table>
    
    </div>
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
