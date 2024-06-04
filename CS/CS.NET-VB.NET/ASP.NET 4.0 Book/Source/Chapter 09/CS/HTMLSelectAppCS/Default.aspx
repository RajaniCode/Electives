<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>HTMLSelect Example</title>
	<link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
<form id="mainForm" runat="server">
	<div>
		<div id="header">
		<h1>
		ASP.NET 4.0 Black Book</h1>
		</div>
		<div id="sidebar">
		<div id="nav">
		&nbsp;
		</div>
		</div>
		<div id="content">
		<div class="itemContent">
		<br />
		<asp:Label ID="Label1" runat="server" Text="HTMLSelect example"></asp:Label><br />
		<br />
		Please select day:
		<select id="Select1" name="select1" runat="server">
			<option selected="selected" value="Monday">Monday</option>
			<option value="Tuesday">Tuesday</option>
			<option value="Wednesday">Wednesday</option>
			<option value="Thursday">Thursday</option>
			<option value="Friday">Friday</option>
			<option value="Saturday">Saturday</option>
			<option value="Sunday">Sunday</option>
			<option></option>
		</select>
		<br />
		Please select month:<br />
		<select id="Select2" name="select1" multiple="True" size="5" style="width: 129px"
		runat="server">
		<option selected="selected" value="January">January</option>
		<option value="February">February</option>
		<option value="March">March</option>
		<option value="April">April</option>
		<option value="May">May</option>
		<option value="June">June</option>
		<option value="July">July</option>
		<option value="August">August</option>
		<option value="September">September</option>
		<option value="October">October</option>
		<option value="November">November</option>
		<option value="December">December</option>
		</select>
		<br />
		<br />
		<input id="Submit1" type="submit" value="Submit" runat="server" onserverclick="Submit1_ServerClick" />
		<br /><br />
		<span id="span1" runat="server"></span>
		<br />
		<span id="span2" runat="server"></span>
		</div>
		<div id="footer">
		<p class="left">
		All content copyright &copy; Kogent Solutions Inc.</p>
		</div>
		</div>
		</div>
	</form>
</body>
</html>

