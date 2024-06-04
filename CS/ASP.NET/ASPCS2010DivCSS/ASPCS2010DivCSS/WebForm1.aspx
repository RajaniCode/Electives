<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ASPCS2010DivCSS.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Single Column Div Layout CSS Styles Code</title>
    <link type="text/css" rel="Stylesheet" href="Styles/StyleSheet1.css" />
</head>
<body>
    <form id="form1" runat="server">
    <div id="outer-container">
        <div id="header">
            <h1>{ Header }</h1>
        </div>
        <div style="clear: both">
        </div>

        <div id="top-Nav">
            <h1>{ Top Navigation }</h1>
        </div>
        <div style="clear: both">
        </div>

        <div id="content-container">
            <h1>{ Content }</h1>
        </div>
        <div style="clear: both">
        </div>

        <div id="footer">
            <h1>{ Footer }</h1>
        </div>
    </div>
    </form>
</body>
</html>
