<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
	void ReviseProfile(Object s, EventArgs e) 
	{
		Profile.StudentName = txtStudentName.Text;
		Profile.CourseName = txtCourseName.Text;
		Profile.Rollno = txtRollno.Text;
	}
</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>Welcome</b> <%= Profile.StudentName %> 
		<br />
		<b>Roll number</b> <%= Profile.Rollno %>
		<br />
		<b>Course undertaken by you</b> <%= Profile.CourseName %>
		<hr />
		<b>Student Name:<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp; </span></b>
		&nbsp;<asp:TextBox ID="txtStudentName" runat="Server" />
		<br />
		<br />
		<b>Roll number:</b>
		<span lang="en-us">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </span>
		<asp:TextBox ID="txtRollno" runat="Server" style="margin-left: 5px" />
		<br />
		<br />
		<b>Course Name:</b>
		<asp:TextBox ID="txtCourseName" runat="Server" style="margin-left: 26px" />
		<br />
		<br />
		<br />
		<asp:Button ID="Button1" Text="Refresh Profile" OnClick="ReviseProfile" runat="server" />
		</div>
           
    </form>
</body>
</html>
