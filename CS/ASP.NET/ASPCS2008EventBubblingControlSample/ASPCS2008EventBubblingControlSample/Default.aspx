<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008EventBubblingControlSample._Default" %>

<%@ Register TagPrefix="Custom" Namespace="ASPCS2008EventBubblingControlSample" Assembly = "ASPCS2008EventBubblingControlSample" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script language="C#" runat="server">

    private void ClickHandler(Object sender,EventArgs e)
    {
        MyControl.Label = "You clicked the <b> Click </b> button";
    }

    private void ResetHandler(Object sender,EventArgs e)
    {
        MyControl.Text1 = "0";
        MyControl.Text2 = "0";
    }     

    private void SubmitHandler(Object sender,EventArgs e)
    {
        if (Int32.Parse(MyControl.Text1) + Int32.Parse(MyControl.Text2) == MyControl.Number)
        {
            MyControl.Label = "<h2> You won a million dollars!!!! </h2>";
        }
        else
        {
            MyControl.Label = "Sorry, try again. The numbers you entered don't add up to" + " the hidden number.";
        }
    }     
   
</script>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <h1> The Mystery Sum Game </h1><br>
    <form id="form1" runat="server">
    <div>
        <Custom:EventBubbler id = "MyControl" OnClick = "ClickHandler" 
        OnReset = "ResetHandler" OnSubmit = "SubmitHandler" Number= "10" runat = server/> 
    </div>
    </form>
</body>
</html>
