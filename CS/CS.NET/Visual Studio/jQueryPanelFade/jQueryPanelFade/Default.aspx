<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>jQuery ASP.NET Panel Cascading</title> 
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

    <script src="Scripts/jquery-1.3.2.js" type="text/javascript"></script>
    
   <script type="text/javascript">
       $(document).ready(function() {

           $("div.cpBody").hide();
           $("#btnHide").hide();
           var panelArray = $('div.cpBody').length;
           var temp = -1;

           $("#btnShow").click(function displayPanel() {
               if (temp < panelArray) {
                   $('div.cpBody').eq(++temp).fadeIn(2000, function() {
                       displayPanel();
                       if (temp == panelArray) {
                           $("#btnHide").show();
                           $("#btnShow").hide();
                       }
                   });
               }
           });


           $("#btnHide").click(function hidePanel() {
               if (temp >= 0) {
                   $('div.cpBody').eq(--temp).fadeOut(2000, function() {
                       hidePanel();
                   });
                   if (temp < 0) {
                       $("#btnHide").hide();
                       $("#btnShow").show();
                       temp = -1;
                   }
               }
           });

       });  
   </script>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height:auto">
        <div class="cpHeader">
            <asp:ImageButton ID="btnShow" ImageUrl="~/Images/Show.gif" runat="server" OnClientClick="return false;" />
            <asp:ImageButton ID="btnHide" ImageUrl="~/Images/Hide.gif" runat="server" OnClientClick="return false;" />             
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
