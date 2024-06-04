<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Show Hide ASP.NET Panels in Different Ways</title>
     <script type='text/javascript' 
        src='http://jqueryjs.googlecode.com/files/jquery-1.3.2.min.js'>
    </script>
    
    <script type="text/javascript">
        $(function() {
            $("#Link1").click(function(evt) {
                evt.preventDefault();
                $('#panelText').slideToggle('slow');
            });

            $("#Link2").click(function(evt) {
                evt.preventDefault();
                $('#panelText').toggle('fast');
            });

            $("#Link3").click(function(evt) {
                evt.preventDefault();
                $("#panelText").animate({
                    height: 'toggle', margin: 'toggle', opacity: 'toggle'
                }, 500);
            });

            $("#Link4").click(function(evt) {
                evt.preventDefault();
                if ($('#panelText').is(":hidden")) {
                    $("#panelText").slideDown("fast");
                } else {
                    $("#panelText").slideUp("fast");
                }
            });

            $('#Link5').click(function(ev) {
                ev.preventDefault();
                $('#panelText').toggle('slow');
                $('#Link5')
                .text(($('#Link5').text() == 'Display Text'
                ? 'Hide Text' : 'Display Text'))

            });
        });
    </script>  
  
    
    <style type="text/css">
    .panel{
        display:none;
    }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <asp:HyperLink ID="Link1" runat="server" NavigateUrl="#">Using slideToggle
    </asp:HyperLink><br />
    <asp:HyperLink ID="Link2" runat="server" NavigateUrl="#">Using Toggle
    </asp:HyperLink><br />
    <asp:HyperLink ID="Link3" runat="server" NavigateUrl="#">Using Animate
    </asp:HyperLink><br />
    <asp:HyperLink ID="Link4" runat="server" NavigateUrl="#">Using slideUp and slideDown
    </asp:HyperLink><br />
    <asp:HyperLink ID="Link5" runat="server" NavigateUrl="#">Display Text
    </asp:HyperLink>

    <asp:Panel ID="panelText" runat="server" CssClass="panel">
       Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nunc 
       turpis nunc, placerat ac, bibendum non, pellentesque nec, odio. 
       Nulla fringilla aliquet nibh. Donec placerat, massa id commodo 
       ornare, justo lectus faucibus leo, in aliquam nisl quam varius 
       velit. Maecenas ullamcorper. Aliquam lectus metus, scelerisque 
       ac, scelerisque vitae, sodales eu, metus. Sed varius nisi sit 
       amet turpis. Mauris a arcu iaculis risus sodales dignissim. 
       Aliquam ac risus. Donec turpis. Sed sit amet mi. Nam sem nunc, 
       suscipit quis, cursus non, facilisis nec, diam. Donec nec mi 
       semper urna interdum ultrices. Sed tellus. Sed sodales, quam 
       sit amet dignissim ornare, orci velit blandit augue, ut pretium 
       diam pede eget felis. Maecenas turpis justo, dapibus non, 
       scelerisque et, consequat id, est. Mauris ornare. Donec 
       posuere ligula et nulla. Quisque sollicitudin libero vitae 
       dolor.Curabitur elementum venenatis lectus. Class aptent taciti
        sociosqu ad litora torquent per conubia nostra, per inceptos 
        himenaeos. Cum sociis natoque penatibus et magnis dis parturient 
        montes, nascetur ridiculus mus. Nam velit. Quisque eros nisi, 
        congue id, aliquam ac, interdum in, velit. Duis cursus tellus 
        molestie libero. Cras scelerisque pellentesque nisl. Phasellus
       adipiscing pretium mi. Curabitur faucibus nisl sit amet ante.
       Pellentesque lacinia erat a nisi molestie lacinia. In erat 
       metus, tincidunt id, consequat nec, blandit bibendum, quam.
        Nunc a tortor.
    </asp:Panel>  
</form>
</body>
</html>
