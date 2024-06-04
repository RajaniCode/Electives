<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>UI Effect with ASP.NET Panel</title>
    
    <style type="text/css">
        .cpHeader
        {
            color: white;
            background-color: #719DDB;
            font: bold 11px auto "Trebuchet MS", Verdana;
            font-size: 12px;
            cursor: pointer;
            width:450px;
            height:18px;
            padding: 4px;    
            text-align:center;        
        }
        .cpBody
        {
            background-color: #DCE4F9;
            font: normal 11px auto Verdana, Arial;
            border: 1px gray;                
            width:450px;
            padding: 4px;
            padding-top: 7px;
        }       
    </style>


    <script src="Scripts/jquery-1.3.min.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        $(document).ready(function() {
            var pan = $(".cpBody").hide();
            var showNext = 0;
            $("#btnShow").click(function() {
                if (showNext < pan.length) {
                    $(pan[showNext++]).slideDown();
                }
            });

            $("#btnHide").click(function() {
                if (showNext > 0) {
                    $(pan[showNext - 1]).slideUp();
                    showNext--;
                }
            });

        });
    
    </script>
</head>
<body>
<form id="form1" runat="server">
<div>
    <div class="cpHeader">
        <asp:ImageButton ID="btnShow" ImageUrl="~/Images/Show.gif" runat="server" OnClientClick="return false;" />
        <asp:ImageButton ID="btnHide" ImageUrl="~/Images/Hide.gif" runat="server" OnClientClick="return false;"  />             
    </div>    

    <asp:Panel ID="Panel1" runat="server" class='cpBody'>
        <asp:Label ID="Label1" runat="server" Text="Label">Panel 1 Content</asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" class='cpBody'>
        <asp:Label ID="Label2" runat="server" Text="Label">Panel 2 Content</asp:Label>
    </asp:Panel>
    <asp:Panel ID="Panel3" runat="server" class='cpBody'>
        <asp:Label ID="Label3" runat="server" Text="Label">Panel 3 Content</asp:Label>
    </asp:Panel>
</div>
</form>
</body>
</html>
