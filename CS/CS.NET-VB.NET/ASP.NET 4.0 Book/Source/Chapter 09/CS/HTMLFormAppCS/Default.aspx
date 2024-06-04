<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>HTML Form Example</title>
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
                    <asp:Label ID="Label1" runat="server" Text="HTML Form example">
                    </asp:Label>
                    <br />
                    <br />
                    User Name:<input id="Text1" type="text" runat="server" />
                    <br />
                    <br />
                    Age: &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <input id="Text2" type="text" runat="server" />
                    <br />
                    <br />
                    Date of birth:<input id="Text3" type="text" runat="server" />
                    <br />
                    <br />
                    <input id="Submit1" type="submit" runat="server" value="Submit" onserverclick="Submit1_ServerClick" />&nbsp;
                    <br />
                    <br />
                    User Name : <span id="span1" runat ="server"></span>
                    <br />
                    <br />
                    Age: <span id="span2" runat ="server"></span>
                    <br />
                    <br />
                    Date of birth: <span id="span3" runat ="server"></span>                   
                    
                </div>
                <div id="footer">
                    &nbsp;
                    <p class="left">
                        All content copyright &copy; Kogent Solutions Inc.
                    </p>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
