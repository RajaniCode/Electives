<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008HiddenField._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">

  protected void HiddenField1_ValueChanged(Object sender, EventArgs e)
  {
      Label1.Text = "The value of the HiddenField control is " + HiddenField1.Value + ".";
  }

</script>

<html  >
<head runat="server">
    <title>HiddenField Example</title>
    
    <script type="text/javascript">
    
        function PageLoad() 
        {
            form1.HiddenField1.value = form1.TextBox1.value;
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server" >
    <ContentTemplate >

        <h3>HiddenField Example</h3>

        Please enter a value and click the submit button.<br/>

        <asp:TextBox  ID="TextBox1" runat="server"/>
            
        <br/>  

        <input name="input1" type="submit" value="Submit" onclick="PageLoad()" />            
        
        <br/>
                   
        <asp:Label ID="Label1" runat="server"/>    
        
        <asp:HiddenField ID="HiddenField1" runat="server" OnValueChanged="HiddenField1_ValueChanged" />
            
    </ContentTemplate>
    </asp:UpdatePanel>
    </form>
    </body>
</html>
