<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2010PostBack.Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<script runat="server" type="text/C#">
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Code to create text file
        string s = funcParam.Value;
    }
</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>How postback works in ASP.NET</title>

    <script type="text/javascript">
        function CreateFile() {
            //get filename from the user
            var fileName = prompt('Type the name of the file you want to create:', '');
            //if the user clicks on OK and if they have entered something
            if ((fileName) && (fileName != "")) {
                //save the filename to the hidden form field 'funcParam'
                document.forms['form1'].elements['funcParam'].value = fileName;
                //call the postback function with the right ID
                __doPostBack('LinkButton1', '');
            }
        }    
    </script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <a href="javascript:CreateFile();">Create Text File</a>
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"></asp:LinkButton>
        <input type="hidden" runat="server" id="funcParam" />          
    </div>
    </form>
</body>
</html>
