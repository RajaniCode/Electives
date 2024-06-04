<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Sample5.aspx.cs" Inherits="Sample5" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.1//EN" "http://www.w3.org/TR/xhtml11/DTD/xhtml11.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Keith Rull's Building a better ASP.NET AJAX UpdateProgress notification demo</title>
    <link href="stylessheets/ajaxstyle.css" rel="stylesheet" type="text/css" />
    <link href="stylessheets/sitestyle.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="siteScriptManager" runat="server" />
        <div>
            <a href="Default.aspx">&lt;&lt;Back to main</a>
            <br />
            <br />
            <asp:UpdatePanel ID="siteUpdatePanel" runat="server">
                <ContentTemplate>
                    <asp:Button ID="simulateButton" 
                                runat="server" 
                                OnClick="simulateButton_Click" 
                                Text="Simulate Long Running Operation" />
                    <br />
                    <asp:UpdateProgress ID="siteUpdateProgress" runat="server">
                        <ProgressTemplate>
                        
                            <div class="TransparentGrayBackground"></div>
                        
                            <div class="Sample5PageUpdateProgress">
                                <asp:Image  ID="ajaxLoadNotificationImage" 
                                            runat="server" 
                                            ImageUrl="~/images/ajax-loader.gif" 
                                            AlternateText="[image]" />
                                &nbsp;Loading...
                            </div>
                            
                                    
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <asp:Label ID="messageLabel" runat="server"></asp:Label>
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
