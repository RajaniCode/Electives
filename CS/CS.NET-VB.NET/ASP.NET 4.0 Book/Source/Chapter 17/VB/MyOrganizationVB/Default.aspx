<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 Enter your name in the text box<br />
	<br />
	<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox><br />
	<br />
	<asp:Button ID="Button1" runat="server" BackColor="Black" Font-Bold="True" 
            Font-Size="Small" ForeColor="White" Text="Click to Submit" 			   
 	  OnClick="Button1_Click" />
	<br /><br />
	<asp:Label ID="Label1" runat="server" CssClass="title" Text="Label" Visible="False" 			  
 	  Width="132px"></asp:Label>
</asp:Content>

