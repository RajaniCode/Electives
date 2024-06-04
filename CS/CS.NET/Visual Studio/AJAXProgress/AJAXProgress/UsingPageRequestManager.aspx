<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UsingPageRequestManager.aspx.cs" Inherits="UsingCSS" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Display Progress Using PageRequestManager</title>   
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
         <script type="text/javascript">
             // Get the instance of PageRequestManager.
             var prm = Sys.WebForms.PageRequestManager.getInstance();
             // Add initializeRequest and endRequest
             prm.add_initializeRequest(prm_InitializeRequest);
             prm.add_endRequest(prm_EndRequest);
             
             // Called when async postback begins
             function prm_InitializeRequest(sender, args) {
                 // get the divImage and set it to visible
                 var panelProg = $get('divImage');                 
                 panelProg.style.display = '';
                 // reset label text
                 var lbl = $get('<%= this.lblText.ClientID %>');
                 lbl.innerHTML = '';

                 // Disable button that caused a postback
                 $get(args._postBackElement.id).disabled = true;
             }

             // Called when async postback ends
             function prm_EndRequest(sender, args) {
                 // get the divImage and hide it again
                 var panelProg = $get('divImage');                 
                 panelProg.style.display = 'none';

                 // Enable button that caused a postback
                 $get(sender._postBackSettings.sourceElement.id).disabled = false;
             }
         </script>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblText" runat="server" Text=""></asp:Label>
                <div id="divImage" style="display:none">
                     <asp:Image ID="img1" runat="server" ImageUrl="~/images/progress.gif" /> 
                     Processing...
                </div>                
                <br />
                <asp:Button ID="btnInvoke" runat="server" Text="Click" 
                    onclick="btnInvoke_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
