<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%--<%@ Register TagPrefix="mobile" Namespace="System.Web.UI.MobileControls" Assembly="System.Web.Mobile" %>--%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<body>
	<mobile:Form id="Form1" runat="server">
    <strong>
		Enter Credit Hours
		<br />
		</strong>
		<em>(Only Numeric Values)
		<br />
		<br />
		</em>
		<mobile:Panel ID="Panel1" Runat="server">
		<mobile:Label ID="Label3" Runat="server">
		Course 1 Credit Hours
		</mobile:Label>
		<mobile:TextBox ID="TextBox1" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="Label4" Runat="server">
		Course 2 Credit Hours
		</mobile:Label>
		<mobile:TextBox ID="TextBox2" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="Label5" Runat="server">
		Course 3 Credit Hours
		</mobile:Label>
		<mobile:TextBox ID="TextBox3" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="Label6" Runat="server">
		Course 4 Credit Hours
		</mobile:Label>
		<mobile:TextBox ID="TextBox4" Runat="server">
		</mobile:TextBox>
		</mobile:Panel>
		<br />
		Enter Grades obtained
		<br />
		(Only grades A,B,C,D and&nbsp;E&nbsp;are allowed)
		<br /><br />
		<mobile:Panel ID="Panel2" Runat="server">
		<mobile:Label ID="Label7" Runat="server">
		Course 1 Grade
		</mobile:Label>
		<mobile:TextBox ID="TextBox5" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="Label8" Runat="server">
		Course 2 Grade
		</mobile:Label>
		<mobile:TextBox ID="TextBox6" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="Label9" Runat="server">
		Course 3 Grade
		</mobile:Label>
		<mobile:TextBox ID="TextBox7" Runat="server">
		</mobile:TextBox>
		<mobile:Label ID="Label10" Runat="server">
		Course 4 Grade
		</mobile:Label>
		<mobile:TextBox ID="TextBox8" Runat="server">
		</mobile:TextBox>
		</mobile:Panel>
		<br />
		&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; 
		<mobile:Command ID="Command1" Runat="server" OnClick="Command1_Click">
		Calculate
		</mobile:Command>
		</mobile:form>
		<br />
		<br />
		<mobile:form id="Form2" runat="server">
		<mobile:Label ID="Label2" Runat="server">
		Your GPA Score Is
		</mobile:Label>
		<mobile:Label ID="Label1" Runat="server">
		</mobile:Label>
		&nbsp;
		<br />
		<mobile:Command ID="Command2" Runat="server" OnClick="Command2_Click">
		ReturnToGPACalc
		</mobile:Command>
	</mobile:Form>
</body>
</html>

