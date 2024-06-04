<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="ImplicitLocalizationCS._Default" Culture="auto" UICulture="auto"%>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
  <title>Implicit Localization</title>
    <h2>
        asp.net 4.0 black book</h2>
    <p>
        &nbsp;
        <div>
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
 			  BorderColor="White"
			BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" 
 			  Height="190px"
			NextPrevFormat="FullMonth" Width="254px">
			<SelectedDayStyle BackColor="#333399" ForeColor="White" />
			<TodayDayStyle BackColor="#CCCCCC" />
			<OtherMonthDayStyle ForeColor="#999999" />
			<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
 			  VerticalAlign="Bottom" />
			<DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
			<TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
			Font-Size="12pt" ForeColor="#333399" />
			</asp:Calendar>
            </div>
            <div>
            <br />
			<br />
			&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
 			&nbsp; &nbsp; &nbsp;&nbsp;
			<table style="width: 383px; height: 193px; background-color: #99ffff">
			<tr>
				<td colspan="2" style="width: 100px; background-color: white">
				&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
 				&nbsp; &nbsp; &nbsp;
				&nbsp; &nbsp;<span style="text-decoration: 
 				  underline"><strong>I<span>mplicitLocalization</span>
				</strong></span>
				</td>
			</tr>
			<tr>
				<td style="width: 75px; height: 18px; background-color: white">
				&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; <strong>English</strong>
				</td>
				<td style="width: 100px; height: 18px; background-color: white">
				&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
				<asp:Label ID="Label1" runat="server" Font-Bold="True" 
 				  meta:resourcekey="Label1Resource1"
				Text="English"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="width: 75px; background-color: white">
				<span style="background-color: 
 				  White"><strong>French</strong>&nbsp; </span>
				</td>
				<td style="width: 100px; background-color: White">
				<strong>&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; 
 				  &nbsp;&nbsp; &nbsp; &nbsp;</strong><asp:Label
				ID="Label2" runat="server" Font-Bold="True" 
 				  meta:resourcekey="Label2Resource1"
				Text="French"></asp:Label>
				</td>
			</tr>
			<tr>
				<td style="width: 75px; background-color: white">
				&nbsp; &nbsp; &nbsp; &nbsp;&nbsp; <strong>German</strong>
				</td>
				<td style="width: 100px; background-color: white">
				&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
				<asp:Label ID="Label3" runat="server" Font-Bold="True" 
 				  meta:resourcekey="Label3Resource1"
				Text="German"></asp:Label>
				</td>
			</tr>
			</table>

            </div>
        </p>
    </asp:Content>
