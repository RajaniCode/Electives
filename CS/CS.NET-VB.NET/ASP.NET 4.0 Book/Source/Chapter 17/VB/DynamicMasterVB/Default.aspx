<%@ Page Title="" Language="VB" MasterPageFile="~/Master1.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<script runat="server" language="vb">
Sub Page_PreInit(ByVal sender As Object, ByVal e As EventArgs) _
		Handles Me.PreInit
		If Not Session("masterpage") Is Nothing Then
			Me.MasterPageFile = CType(Session("masterpage"), String)
		End If
	End Sub
	Protected Sub Button1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        label1.Text = "<b>Hello " & TextBox1.Text & "! Welcome to MyWebSite. 				  </b>"
	End Sub
</script>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<b>Enter Your Name: </b>
	<br />
	<asp:TextBox ID="TextBox1" runat="server" />
	<br />
	<br />
	<asp:Button ID="Button1" runat="server" Text="Enter" OnClick="Button1_Click" />
	<br />
	<asp:Label ID="label1" runat="server" />
</asp:Content>

