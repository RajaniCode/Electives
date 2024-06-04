<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title> 
    <style type="text/css">
        .divNoBorder
        {
            background-color:White;
            font-family:"Lucida Sans Unicode", "Lucida Grande", Verdana, Arial; 
	        font-size:12px; 
	        color:#000000;
            width:510px; 
            margin-left:auto;
            margin-right:auto;
            padding:10px;
        }    
    </style>
    
     <script src="http://ajax.microsoft.com/ajax/jquery/jquery-1.4.2.js" 
     type="text/javascript"></script> 
     
     <script type="text/javascript">
        $(function() {
            var $divSlide = $("div.slide");
            $divSlide.hide().eq(0).show();
            var panelCnt = $divSlide.length;

            setInterval(panelSlider, 3000);

            function panelSlider() {
                $divSlide.eq(($divSlide.length++) % panelCnt)
                .slideUp("slow", function() {
                    $divSlide.eq(($divSlide.length) % panelCnt)
                        .slideDown("slow");
                });
            }
        });
     </script>
     
</head>
<body>
<form id="form1" runat="server">
    <div class="divNoBorder">
        <h2>Slide Show with Panels. 
        Each Panel is Visible for 3 seconds.</h2>
        <br /><br />
         <asp:Panel ID="panelOne" runat="server" class='slide'>
            Panel 1 Content Panel 1 Content Panel 1 Content
            Panel 1 Content Panel 1 Content Panel 1 Content
            Panel 1 Content Panel 1 Content Panel 1 Content
            Panel 1 Content Panel 1 Content Panel 1 Content            
        </asp:Panel>
        <asp:Panel ID="panelTwo" runat="server" class='slide'>
            Panel 2 Content Panel 2 Content Panel 2 Content
            Panel 2 Content Panel 2 Content Panel 2 Content
            Panel 2 Content Panel 2 Content Panel 2 Content
            Panel 2 Content Panel 2 Content Panel 2 Content
        </asp:Panel>
        <asp:Panel ID="panelThree" runat="server" class='slide'>
           Panel 3 Content Panel 3 Content Panel 3 Content
           Panel 3 Content Panel 3 Content Panel 3 Content
           Panel 3 Content Panel 3 Content Panel 3 Content
           Panel 3 Content Panel 3 Content Panel 3 Content           
           Panel 3 Content Panel 3 Content Panel 3 Content
        </asp:Panel>
        <asp:Panel ID="panelFour" runat="server" class='slide'>
             Panel 4 Content Panel 4 Content Panel 4 Content
             Panel 4 Content Panel 4 Content Panel 4 Content
        </asp:Panel>
        <asp:Panel ID="panelFive" runat="server" class='slide'>
            Panel 5 Content  Panel 5 Content  Panel 5 Content
        </asp:Panel>
    </div>
    </form>
</body>
</html>
