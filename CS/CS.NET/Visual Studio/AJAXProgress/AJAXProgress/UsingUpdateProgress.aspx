<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="UsingUpdateProgress.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="updProgress"
        AssociatedUpdatePanelID="UpdatePanel1"
        runat="server">
            <ProgressTemplate>            
            <img alt="progress" src="images/progress.gif"/>
               Processing...            
            </ProgressTemplate>
        </asp:UpdateProgress>
        
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <br />
                <asp:Button ID="btnInvoke" runat="server" Text="Click" 
                    onclick="btnInvoke_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>         
    </div>
    </form>
</body>
</html>
