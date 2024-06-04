<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleModal.aspx.cs"
    Inherits="SimpleModal" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="act" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script type="text/javascript">
/*
function yes()
{
    alert("I strongly agree");
}
function no()
{
    alert("I strongly disagree");
} */
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Extenders: Modal Popup</title>
    <style>
    .modalPopup 
    {
	    background-color:#ffffdd;
	    border-width:3px;
	    border-style:solid;
	    border-color:Gray;
	    padding:3px;
	    width:250px;
    }
    .modalBackground 
    {
	    background-color:Gray;
	    filter:alpha(opacity=70);
	    opacity:0.7;
    }    
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="pageAbstract">
            <p>
                The example in this page demonstrates the use of modal popups. You define a popup as a panel and add 
                an extender to the page to transform it into a pop-up form.
            </p>
        </div>
        
        <asp:ScriptManager id="ScriptManager1" runat="server" /> 
        
        <div id="pageContent">
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
            incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
            exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
            irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
            pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
            deserunt mollit anim id est laborum.</p>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
            incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
            exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
            irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
            pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
            deserunt mollit anim id est laborum.</p>
            <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor
            incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud
            exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute
            irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla
            pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia
            deserunt mollit anim id est laborum.</p><br />
            
            <asp:LinkButton ID="LinkButton1" runat="server" Text="Share Your Thoughts" /> 
            <asp:Panel ID="Panel1" runat="server" CssClass="modalPopup" style="display:none">
                    <div style="margin:10px">
                    Take note of this message and tell us if you strongly agree.<br /><br />
                    <asp:Button ID="Button1" runat="server" Text="Yes" width="40px"  />
                    <asp:Button ID="Button2" runat="server" Text="No"  width="40px" />
                    </div>
            </asp:Panel>
        </div>

           
        <act:ModalPopupExtender ID="ModalPopupExtender1" runat="server"
                    TargetControlID="LinkButton1"
                    PopupControlID="Panel1"
                    PopupDragHandleControlID="Panel1"
                    BackgroundCssClass="modalBackground"
                    DropShadow="true"
                    OkControlID="Button1"
                    CancelControlID="Button2" />
   
    </form>
</body>
</html>
