<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTML File Upload Example</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="mainForm" runat="server">
        <div>
            <div id="header">
                <h1>
                    ASP.NET 4.0 Black Book
                </h1>
            </div>
            <div id="sidebar">
                <div id="nav">
                    &nbsp;
                </div>
            </div>
            <div id="content">
                <div class="itemContent">
                    <br />
                    <asp:Label ID="Label1" runat="server" Text="File Upload example"></asp:Label><br />
                    <br />
                    Select file:&nbsp;
                    <input id="File1" type="file" runat="server" /><br />
                    <br />
                    Save as (File name with valid extension):
                    <input id="FileName" type="text" runat="server" /><br />
                    <br />
                    <input id="Submit1" type="submit" value="Submit" runat="server" onserverclick="Submit1_ServerClick"/>
                    <input id="Reset1" type="reset" value="Reset" />
                    <br />
                    <br />
                    <span id="messagearea" runat="server"></span>
                </div>
                <div id="footer">
                    <p class="left">
                        All content copyright &copy; Kogent Solutions Inc.</p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>

