<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>College Registration System</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset>
			<legend>Personal Information of Student</legend>
			<br />
			<table width="50%" border="0" cellspacing="0" cellpadding="4">
			<tr>
			<td style="width: 195px">
			<p align="right">
			<label for="name">
				Name of Student
			</label>
			</p>
			</td>
			<td style="width: 226px">
			<input id="name" type="text" name="text1" size="12"/>
			</td>
			</tr>
			<tr>
			<td style="width: 195px">
			<p align="right">
			<label for="father">
				Name of Father</label></p>
			</td>
			<td style="width: 226px">
			<input id="father" type="text" name="text2" size="12"/>
			</td>
			</tr>
			<tr>
			<td style="width: 195px">
			<p align="right">
			<label for="add">
			Address</label></p>
			</td>
			<td style="width: 226px">
			&nbsp;<input id="ass" type="text" name="text3" style="width: 95px"/>
			</td>
			</tr>
			<tr>
				<td style="width: 195px">
				<p align="right">
					<label for="city">
					City</label></p>
				</td>
				<td style="width: 226px">
					<input id="city" type="text" name="text4" size="12"/>
				</td>
			</tr>
			</table>
			</fieldset>
			<fieldset>
			<legend>Academic background</legend>
			<br />
			<fieldset>
			<legend>Last Qualifying Exam Passed</legend>
			<br />
			<input id="BSc" type="radio" name="radio1" value="radiobutton"/>
			<label for="BSc">
			Bachelor of Computer Science (BSc)</label><br/>
			<input id="BCom" type="radio" name="radio1" value="radiobutton"/>
			<label for="BCom">
			Bachelor of Commerce (BCom)</label><br/>
			<input id="BA" type="radio" name="radio1" value="radiobutton"/>
			<label for="BA">
			Bachelor of Arts (BA)</label><br />
			<br />
			</fieldset>
			<fieldset>
			<legend>Percentage Obtained in Qualifying Exam</legend>
			<br />
			<br />
			<input id="belw60" type="radio" name="radio2" value="radiobutton"/>
			<label for="belw60">
			Below 60</label><br/>
			<input id="bw" type="radio" name="radio2" value="radiobutton"/>
			<label for="bw">
			Between 60 and 80</label><br/>
			<input id="abv80" type="radio" name="radio2" value="radiobutton"/>
			<label for="abv80">
			Above 80</label><br/>
			</fieldset>
			</fieldset>

    </div>
    </form>
</body>
</html>
