<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebFormConfirmButtonExtender.aspx.cs" Inherits="AJAXCS2008ConfirmButtonExtender.WebFormConfirmButtonExtender" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server">
    
protected void Page_Load(object sender, EventArgs e)
{
    ButtonExit.Attributes.Add("onclick", "return onclickButtonExit();");
}

protected void ButtonExit_Click(object sender, EventArgs e)
{
    string stringJScript = "";
    stringJScript += "var text = confirm(\'Are you sure you want to Exit?\');\n";
    stringJScript += "if (text){\n";
    stringJScript += " alert(\"You Clicked OK to Exit!\");\n";
    stringJScript += " close();\n";    
    stringJScript += "}\n";
    stringJScript += "else{\n";
    stringJScript += " alert(\"You Clicked Cancel!\");\n";
    stringJScript += "}\n";

    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", stringJScript, true);
}
    
protected void ButtonValidate_Click(object sender, EventArgs e)
{   
    if ((TextBoxEmail.Text.Trim() == "Please Enter Email ID Here") || (TextBoxEmail.Text.Trim() == string.Empty))
    {
        RFVTextBoxEmail.IsValid = false;
        return;
    }   
    
    // Build your alert script
    StringBuilder sbScript = new StringBuilder();
    sbScript.Append("<script language='JavaScript' type='text/javascript'>");
    sbScript.Append("alert('");
    sbScript.Append(TextBoxEmail.Text.Trim() + " is validated!");
    sbScript.Append("')");
    sbScript.Append("</");
    sbScript.Append("script>");

    // Make use ScriptManager to register the script
    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", sbScript.ToString(), false);

    TextBoxEmail.Text = string.Empty;
}

</script>  
    
<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ConfirmButtonExtender</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <%--<style type="text/css">
        body
        {
            background: #B4B4B4 url(images/body_bg.gif) repeat left top;
            font-family: Tahoma, Arial, sans-serif;
            font-size:75%;
        }

        .watermarked {
            height:20px;
            width:150px;
            padding:2px 0 0 2px;
            border:1px solid #BEBEBE;
            background-color:#F0F8FF;
            color:gray;
        }

        .modalBackground {
            background-color:Gray;
            filter:alpha(opacity=70);
            opacity:0.7;
        }
    </style>--%>
    
    <script type="text/javascript">
        
      function pageLoad() {
      }


      function onclickButtonExit() {
          if (confirm("Do you want to Exit?") == true)
              return true;
          else {
              alert("You Clicked Cancel!");
              return false;
          }
      }

      
      function onClientClickLinkButtonPrompt() {
          var text = prompt('Pass Email ID to TextBox', 'Please Type Email ID Here');

          if (text != null) {
              document.getElementById('TextBoxEmail').value = text;
              document.forms(0).submit();
          }
         else {
              alert('You Clicked Cancel!');
          }
      }

      function onClientCancelLinkButtonPrompt() {
          alert('You Clicked Cancel!');
      }

      function onClientCancelButtonValidate() {
          var TextBoxEmail = $get('TextBoxEmail');

          TextBoxEmail.value = ' ';

          var RFVTextBoxEmail = $get('RFVTextBoxEmail');

          ValidatorEnable(RFVTextBoxEmail, true);

          var TBWERFVBIDTextBoxEmail = $find('TBWERFVBIDTextBoxEmail');

          TBWERFVBIDTextBoxEmail._applyWatermark()

          var TBWEREVBIDTextBoxEmail = $find('TBWEREVBIDTextBoxEmail');

          TBWEREVBIDTextBoxEmail._applyWatermark()
      }
    
    </script>
</head>
<body>
    <form id="form1" runat="server">  
    <br/>
    <br/>
    <asp:ScriptManager ID="ScriptManager1" runat="server" />        

        <asp:UpdatePanel ID="UpdatePanelButtonValidate" runat="server">
            <ContentTemplate>                   
                <asp:TextBox ID="TextBoxEmail" 
                    runat="server"
                    Width="289px"
                    ValidationGroup="ValidationGroupTextBoxEmail" >
                </asp:TextBox>
                
                <ajaxToolkit:TextBoxWatermarkExtender ID="TBWERFVTextBoxEmail" 
                    BehaviorID ="TBWERFVBIDTextBoxEmail"  
                    runat="server" 
                    TargetControlID="TextBoxEmail" 
                    WatermarkText="Please Enter Email ID Here" 
                    WatermarkCssClass="watermarked" />

                <asp:RequiredFieldValidator ID="RFVTextBoxEmail" 
                    ValidationGroup="ValidationGroupTextBoxEmail"
                    runat="server" 
                    ErrorMessage="Please Enter Email ID" 
                    ControlToValidate="TextBoxEmail" 
                    Display="None" />

                <ajaxToolkit:ValidatorCalloutExtender ID="VCERFVTextBoxEmail" 
                    runat="server" 
                    TargetControlID="RFVTextBoxEmail"/>                        

                <ajaxToolkit:TextBoxWatermarkExtender ID="TBWEREVTextBoxEmail" 
                    BehaviorID="TBWEREVBIDTextBoxEmail" 
                    runat="server" 
                    TargetControlID="TextBoxEmail"  
                    WatermarkText="Please Enter Email ID Here" 
                    WatermarkCssClass="watermarked" />

                <asp:RegularExpressionValidator ID="REVTextBoxEmail"
                    ValidationGroup="ValidationGroupTextBoxEmail" 
                    runat="server" 
                    ControlToValidate="TextBoxEmail" 
                    ErrorMessage="Please Enter Valid Email ID" 
                    Display ="None"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">
                </asp:RegularExpressionValidator>

                <ajaxToolkit:ValidatorCalloutExtender ID="VCEREVTextBoxEmail" 
                    runat="server" 
                    TargetControlID="REVTextBoxEmail"/>        
      
                <asp:Button ID="ButtonValidate"
                    OnClick="ButtonValidate_Click" 
                    runat="server" 
                    Text="Validate" 
                    ValidationGroup="ValidationGroupTextBoxEmail" />
                    
                <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtenderButtonValidate" 
                    runat="server" 
                    DisplayModalPopupID="ModalPopupExtenderButtonValidate" 
                    OnClientCancel="onClientCancelButtonValidate"                    
                    TargetControlID="ButtonValidate" />
               
                <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderButtonValidate" runat="server" 
                    BackgroundCssClass="modalBackground" 
                    CancelControlID="ButtonCancelButtonValidate" 
                    OkControlID="ButtonOkButtonValidate" 
                    PopupControlID="PanelButtonValidate" 
                    TargetControlID="ButtonValidate" />
                    
                <asp:Panel ID="PanelButtonValidate" 
                    runat="server" 
                    Style="display: none; 
                    width: 200px; 
                    background-color: White;
                    border-width: 2px; 
                    border-color: Black; 
                    border-style: solid; 
                    padding: 20px;">
                    Are you sure you want to validate?
                    <div style="text-align:right;" >
                        <br />
                        <asp:Button ID="ButtonOkButtonValidate" runat="server" Text="OK"  ValidationGroup="ValidationGroupTextBoxEmail"/>
                        <asp:Button ID="ButtonCancelButtonValidate" runat="server" Text="Cancel" ValidationGroup="ValidationGroupTextBoxEmail" />
                    </div>
                </asp:Panel>
                                     
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:UpdatePanel ID="UpdatePanelLinkButtonPrompt" runat="server">
            <ContentTemplate>  
            
            <asp:LinkButton ID="LinkButtonPrompt" runat="server" OnClientClick="onClientClickLinkButtonPrompt()">Click Me</asp:LinkButton>

            <ajaxToolkit:ConfirmButtonExtender ID="ConfirmButtonExtenderLinkButtonPrompt" 
                        runat="server" 
                        TargetControlID="LinkButtonPrompt"
                        ConfirmText="Do you want to pass Email ID?"                         
                        OnClientCancel="onClientCancelLinkButtonPrompt" />
                        
            </ContentTemplate>
        </asp:UpdatePanel>
        
        <asp:UpdatePanel ID="UpdatePanelButtonExit" runat="server">
            <ContentTemplate>  
                <br/>
                <br/>
                <asp:Button ID="ButtonExit" runat="server" OnClick="ButtonExit_Click" Text="Exit" />                
            </ContentTemplate>
        </asp:UpdatePanel>
       
    </form>
</body>
</html>
