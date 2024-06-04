function InvokePop(fname)
{
        val = document.getElementById(fname).value;
        // to handle in IE 7.0           
        if (window.showModalDialog) 
        {       
            retVal = window.showModalDialog("PopupWin.aspx?Control1=" + fname + "&ControlVal=" + val ,'Show Popup Window',"dialogHeight:90px,dialogWidth:250px,resizable:yes,center:yes,");
            document.getElementById(fname).value = retVal;
        } 
        // to handle in Firefox
        else 
        {      
            retVal = window.open("PopupWin.aspx?Control1="+fname + "&ControlVal=" + val,'Show Popup Window','height=90,width=250,resizable=yes,modal=yes');
            retVal.focus();            
        }          
}

function ReverseString()
{
         var originalString = document.getElementById('txtReverse').value;
         var reversedString = Reverse(originalString);
         RetrieveControl();
         // to handle in IE 7.0
         if (window.showModalDialog)
         {              
              window.returnValue = reversedString;
              window.close();
         }
         // to handle in Firefox
         else
         {
              if ((window.opener != null) && (!window.opener.closed)) 
              {               
                // Access the control.        
                window.opener.document.getElementById(ctr[1]).value = reversedString; 
              }
              window.close();
         }
}

function Reverse(str)
{
   var revStr = ""; 
   for (i=str.length - 1 ; i > - 1 ; i--)
   { 
      revStr += str.substr(i,1); 
   } 
   return revStr;
}

function RetrieveControl()
{
        //Retrieve the query string 
        queryStr = window.location.search.substring(1); 
        // Seperate the control and its value
        ctrlArray = queryStr.split("&"); 
        ctrl1 = ctrlArray[0]; 
        //Retrieve the control passed via querystring 
        ctr = ctrl1.split("=");
}
