<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SomePage.aspx.cs" Inherits="ASPCS2008ViewState.SomePage" 
EnableViewState="true" ViewStateEncryptionMode="Always" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>
    <p>
        <span lang="en-us">Wellcome to Some Page! </span>
    </p>
    
    <br />
        
    <asp:Button ID="Button1" runat="server" Text="Click" onclick="Button1_Click" />
    
    <br />
    <br />
    
    <asp:Label ID="Label1" runat="server" Text="Button_Click"></asp:Label>
    
    <span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    </span>
   
    <br />
    <br />
    
    <p>
    <asp:Button ID="Button2" runat="server" Text="Go back" onclick="Button2_Click" />
    </p>
    <div>
    
    </div>
    
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
