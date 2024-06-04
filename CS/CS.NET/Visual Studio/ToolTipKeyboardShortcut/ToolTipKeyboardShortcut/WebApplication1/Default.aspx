<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" >
<head>
    <title></title>
    <script language="javascript" type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.3.2/jquery.min.js"></script>
    <script type="text/javascript" language="javascript">
        $(document).ready(function() {
            $(this).keydown(function(e) {
                var evt = e || window.event;
                if (evt.shiftKey) {
                    findHelp(evt).fadeIn("slow");
                }
            });

            $(this).keyup(function(e) {
                var evt = e || window.event;
                if (evt.shiftKey) {
                    findHelp(evt).hide("fast");
                }
            });
        });

        function findHelp(e) {
            var key = (e.keyCode ? e.keyCode : e.charCode);
            return $("div[title=" + String.fromCharCode(key) + "]");
        }            
    </script>  
</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                    Given Name
                </td>
                <td>
                    <input type="text" maxlength="10" id="txtGivenName" />
                </td>
                <td>
                    <div id="givenName" style="display:none;" title="G">
                       <img src="info.png" alt="Info" width="16" height="16" />
                        Please supply your given name</div>            
                </td>
            </tr>
            <tr>
                <td>
                    Surname
                </td>
                <td>
                    <input type="text" maxlength="20" id="txtSurname" />
                </td>
                <td>
                    <div id="surname" style="display:none;" title="S">
                        <img src="info.png" alt="Info" width="16" height="16" /> 
                        Please supply your surname.  This can only be <b>20</b> characters long</div>        
                </td>
            </tr>
        </table>        
    </form>
</body>
</html>
