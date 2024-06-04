<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
    Private Sub ReviseProfile(ByVal s As Object, ByVal e As EventArgs)
	Profile.StudentName = txtStudentName.Text
	Profile.DOB.Day = txtDay.Text
	Profile.DOB.Month = txtMonth.Text
	Profile.DOB.Year = txtYear.Text
	End Sub
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <b>Welcome</b> <%=Profile.StudentName%><br />
		&nbsp;<b>Date of Birth:</b> <%=Profile.DOB.Day%> <%=Profile.DOB.Month%> 	
		<%=Profile.DOB.Year%><br />
		&nbsp;<hr />
		<b>
		<br />
		Student Name:</b>
		<asp:TextBox ID="txtStudentName"  runat="server" />
		<br />
		<br />&nbsp;<br />
		<b>Date:</b>
		<asp:TextBox ID="txtDay" runat="server" style="margin-left: 30px" />
		<br />
		<br />
		<b>Month:</b>
		<asp:TextBox ID="txtMonth"  runat="server" style="margin-left: 20px" />
		<br />
		<br />
		<b>Year:</b>
		<asp:TextBox ID="txtYear" runat="server" style="margin-left: 33px" />
		<br />
		<br />
		<asp:Button ID="Button1" Text="Revise Profile" 	OnClick="ReviseProfile" runat="server" />

    </div>
    </form>
</body>
</html>
