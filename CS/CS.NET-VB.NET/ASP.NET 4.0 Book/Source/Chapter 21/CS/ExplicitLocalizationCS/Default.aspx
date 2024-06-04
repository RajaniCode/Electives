<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" culture="auto" meta:resourcekey="PageResource1" uiculture="auto" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Displaying Explicit Localization</title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 191px;
        }
        .style2
        {
            width: 285px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
        <asp:Calendar ID="Calendar1" runat="server" BackColor="White" 
 			  BorderColor="White"
			BorderWidth="1px" Font-Names="Verdana" Font-Size="9pt" ForeColor="Black" 
 			  Height="190px"
			NextPrevFormat="FullMonth" Width="254px" meta:resourcekey="Calendar1Resource1">
			<SelectedDayStyle BackColor="#333399" ForeColor="White" />
			<TodayDayStyle BackColor="#CCCCCC" />
			<OtherMonthDayStyle ForeColor="#999999" />
			<NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
 			  VerticalAlign="Bottom" />
			<DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
			<TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" Font-Bold="True"
			Font-Size="12pt" ForeColor="#333399" />
			</asp:Calendar>
                </td>
                <td>
        <asp:Label ID="Label1" runat="server" Text="<%$ Resources:Default, msg %>" 
                        meta:resourcekey="Label1Resource1"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    &nbsp;</td>
            </tr>
        </table>
        <br />
        <br />
    </div>
    </form>
</body>
</html>
