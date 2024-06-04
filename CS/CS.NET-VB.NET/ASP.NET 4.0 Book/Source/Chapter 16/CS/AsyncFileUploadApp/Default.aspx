<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title><script type="text/javascript">
                       function fillCell(row, cellNumber, text) {
                           var cell = row.insertCell(cellNumber);
                           cell.innerHTML = text;
                           cell.style.borderBottom = cell.style.borderRight = "solid 1px #aaaaff";
                       }
                       function addToClientTable(name, text) {
                           var table = document.getElementById("<%= clientSide.ClientID %>");
                           var row = table.insertRow(0);
                           fillCell(row, 0, name);
                           fillCell(row, 1, text);
                       }

                       function uploadError(sender, args) {
                           addToClientTable(args.get_fileName(), "<span style='color:red;'>" + args.get_errorMessage() + "</span>");
                       }
                       function uploadComplete(sender, args) {
                           var contentType = args.get_contentType();
                           var text = args.get_length() + " bytes";
                           if (contentType.length > 0) {
                               text += ", '" + contentType + "'";
                           }
                           addToClientTable(args.get_fileName(), text);
                       }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
       <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true">
        </ajaxToolkit:ToolkitScriptManager>
        <h3>Click the Browse button to Upload the File</h3>
      <ajaxToolkit:AsyncFileUpload
            OnClientUploadError="uploadError" OnClientUploadComplete="uploadComplete" 
            runat="server" ID="AsyncFileUpload1" Width="400px" UploaderStyle="Traditional" 
            UploadingBackColor="Pink" ThrobberID="myThrobber"
             />&nbsp;<asp:Label runat="server" ID="myThrobber" style="display:none;" ></asp:Label>
        <div><strong>The Server-side events:</strong></div>
        <asp:Label runat="server" Text="&nbsp;" ID="uploadResult" />
        <br /><br />
        <div><strong>The Client-side events:</strong></div>
        <table style="border-collapse: collapse; border-left: solid 1px #aaaaff; border-top: solid 1px #aaaaff;" runat="server" cellpadding="3" id="clientSide" />
  
    </div>
    </form>
</body>
</html>
