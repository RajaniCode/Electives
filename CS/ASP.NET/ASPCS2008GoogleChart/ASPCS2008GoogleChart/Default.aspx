<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <img src=<%#strChart  %>  />
        
        
        <asp:Label runat="Server" ID="lblSt" ></asp:Label>
        <asp:Button runat="server" ID="btnUp" Text="getPrs" />
        
    </div>
    
    <script language="javascript"> 
    
        
        //var valueArray = new Array(0,1,4,4,6,11,14,17,23,28,33,36,43,59,65);
        var valueArray = new Array(30,50,20);
        var maxValue = 70; 
        var simpleEncoding = 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789';
 
        var postVals = simpleEncode(valueArray,maxValue);
        document.write(postVals);
         
        function simpleEncode(valueArray,maxValue) {

        var chartData = ['s:'];
          for (var i = 0; i < valueArray.length; i++) {
            var currentValue = valueArray[i];
            if (!isNaN(currentValue) && currentValue >= 0) {
            chartData.push(simpleEncoding.charAt(Math.round((simpleEncoding.length-1) * currentValue / maxValue)));
            }
              else {
              chartData.push('_');
              }
          }
        return chartData.join('');
        }    
        
        
    </script>
    
    
    
    </form>
    
</body>
</html>
