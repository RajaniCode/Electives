<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Page Curls</title>
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"
    type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"
    type="text/javascript"></script>
    <script type="text/javascript" src="Scripts/turn.js"></script>
    <link rel="stylesheet" type="text/css" href="CSS/turn.css" />
    <style type="text/css">
    div{
        width: 80%;
        text-align:justify;
    }
    </style>
    <script type="text/javascript">
        $(document).ready(function() {
        var opts = {
            side: 'right',
            directory: 'imgs',
            startingWidth: 200,
            startingHeight:180,
            autoCurl: true             
        };
        $('#target').fold(opts);
    });
    </script>
</head>
<body>
<form id="form1" runat="server">
    <div>
      <h1>Join US</h1>
      <br/>
      <asp:Panel ID="Panel1" runat="server">      
        Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce in tincidunt sem. 
        Suspendisse a nulla nec tellus commodo porta quis sit amet turpis. Ut condimentum, 
        felis vitae convallis vestibulum, odio urna pharetra tellus, in commodo urna sem 
        eu augue. Donec ornare nisi ut ligula molestie volutpat lacinia diam luctus. 
        Maecenas lorem est, scelerisque ac egestas ac, egestas vel felis. Praesent 
        hendrerit elit nec nunc porttitor ullamcorper. Cras dictum, augue id rutrum 
        ornare, urna magna commodo justo, ac pharetra massa nisi quis sem. Sed sollicitudin
        lobortis nunc, vitae cursus enim venenatis nec. Mauris pulvinar, lorem vitae 
        imperdiet euismod, risus nunc rutrum purus, vel vulputate ante nulla vitae justo. 
        Suspendisse non turpis luctus velit scelerisque elementum. Nulla cursus, mauris 
        nec venenatis condimentum, neque enim aliquet est, non varius est ipsum a eros.
       </asp:Panel>
       <asp:Image ID="target" runat="server" ImageUrl="imgs/Subscribe.png" />
    </div>        
</form>
</body>
</html>
