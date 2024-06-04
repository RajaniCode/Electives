<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
        void RevisePro(Object s, EventArgs e)
        {
            Profile.SName = txtStudentName.Text;
            Profile.Cname = txtCourseName.Text;
            Profile.Rno = txtRollno.Text;
        }

</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>Welcome</b> <%= Profile.SName %> 
		<br />
		<b>Roll number</b> <%= Profile.Rno %>
		<br />
		<b>Course undertaken by u</b> <%= Profile.Cname %>
		<hr />
		<b>Student Name:<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp; </span></b>
		&nbsp;<asp:TextBox ID="txtStudentName" Runat="Server" />
		<br />
		<br />
		<b>Roll number:</b>
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:TextBox ID="txtRollno" Runat="Server" style="margin-left: 5px" />
		<br />
		<br />
		<b>Course Name:</b>
		<asp:TextBox ID="txtCourseName" Runat="Server" style="margin-left: 26px" />
		<br />
		<br />
		<br />
		<asp:Button ID="Button1" Text="Revise Profile" 	OnClick="RevisePro" runat="server" />

    </div>
    </form>
</body>
</html>
