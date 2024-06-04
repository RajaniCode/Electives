<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008Delay._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
    
        <style type="text/css">      
       #graybackground-div
       {
           position:absolute;
           top:0px;
           left:0px;
           overflow:hidden;
           width:100%;
           height:100%;
           background-color:#808080;
           opacity:0.5;
           filter:alpha(opacity=50);
           z-index:10;
           display:none;           
       }
        #message-div
        {
            position: absolute;
            top: 50%;
            left: 50%;
            margin-left: -250px;
            margin-top: -150px;
            background-color: #0066FF;
            filter: progid:DXImageTransform.Microsoft.Gradient(GradientType=0,StartColorStr='#0066FF',EndColorStr='#CCFFFF');
            width: 500px;
            height: 300px;
            border: 2px solid #FF6600;
            font-family: Arial;
            text-align: center;
            color: #FFFFFF;
            font-size: 18px;
            z-index: 20;
            display: none;
        } 
        #message-div div
        {
            padding:70px;
            background: url(../Images/LoaderBar.gif) no-repeat;
        }  
    </style>
    
    <link href="Styles/Styles.css"rel="stylesheet" type="text/css" />
    
    <script type="text/javascript">
        function ClientSideClick(myButton) {
            // Client side validation
            if (typeof (Page_ClientValidate) == 'function') {
                if (Page_ClientValidate() == false)
                { return false; }
            }
            //make sure the button is not of type "submit" but "button"
            if (myButton.getAttribute('type') == 'button') {
                // diable the button
                // myButton.disabled = true;
                // myButton.className = "btn-inactive";
                // myButton.value = "processing...";

                // document.getElementById("Button1").className = "btn-inactive";

                //display gray background and message
                document.getElementById("graybackground-div").style.display = "block";
                document.getElementById("message-div").style.display = "block";
            }
            return true;
        }
        function Message() {

            alert("This is another control");

        }    
    </script>
    
</head>
<body>
    <form id="form1" runat="server">
    
    <div>    
        <asp:Button ID="btnClick" runat="server" CssClass="btn-active" 
        Text="Button" OnClientClick="Message();" Width="120px" />    
        <br />
        <br />   
        <asp:Button ID="btnSubmit" runat="server" CssClass="btn-active"  
        Text="Submit Data" OnClientClick="ClientSideClick(this);"
        UseSubmitBehavior="False" OnClick="btnSubmit_Click" Width="120px" />     
    </div>
    
    <div id="graybackground-div">	    
	</div>
	
	<div id="message-div">        
        <div>Processing data, please wait...</div> 
	</div>
    </form>
</body>
</html>
