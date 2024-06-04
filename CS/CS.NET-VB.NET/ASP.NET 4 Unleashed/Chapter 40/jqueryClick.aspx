<%@ Page Language="C#" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript" src="./Scripts/jquery-1.4.1.js"></script>
<script type="text/javascript" src="./Scripts/jqueryClick.js"></script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>

    <style type="text/css">
    .redClass
    {
        color: Red;
    }
    
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <p><span id="clickSpan">This is the span that we will click.</span></p>
        <p><span id="colorSpan">This will turn red when we click on it.</span></p>
    </div>
    </form>
</body>
</html>
