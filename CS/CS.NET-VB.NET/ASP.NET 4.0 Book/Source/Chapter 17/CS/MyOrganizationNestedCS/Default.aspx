<%@ Page Language="C#" MasterPageFile="~/hrd.master" AutoEventWireup="true" CodeFile="Default.aspx.cs"
 Inherits="_Default" Title="Nested Master Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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


