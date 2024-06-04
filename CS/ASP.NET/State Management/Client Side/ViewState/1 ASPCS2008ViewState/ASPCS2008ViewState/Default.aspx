<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008ViewState._Default" 
EnableViewState="true" ViewStateEncryptionMode="Always" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server" >

    private int Counter
    {
        get
        {
            object Instance = ViewState["Counter"];
            return (Instance == null) ? 0 : (int)Instance;
        }
        set
        {
            ViewState["Counter"] = value;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Counter++;
        TextBox1.Text = Counter.ToString();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("SomePage.aspx");
    }  
    
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" >
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate>
   
    <div>
    
        <asp:Button ID="Button1" runat="server" Text="Click" onclick="Button1_Click" />
        <br />
        <br />
        <span lang="en-us">
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        </span>
        <br />
        <asp:Button ID="Button2" runat="server" Text="Go Some Page" 
            onclick="Button2_Click" />
        <br />
        <br />
    
    </div>
    
     </ContentTemplate>
     </asp:UpdatePanel>
    </form>
</body>
</html>

<%--Check this: http://social.msdn.microsoft.com/Forums/en-US/iewebdevelopment/thread/a5a75d76-a810-4a30-9c71-7141f1287c89--%>