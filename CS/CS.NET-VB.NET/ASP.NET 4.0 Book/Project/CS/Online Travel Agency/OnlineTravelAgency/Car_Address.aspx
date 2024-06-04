<%@ Page Title="Book your Car" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="Car_Address.aspx.cs" Inherits="Car_Address" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<%@ Register Assembly="GCheckout" Namespace="GCheckout.Checkout" TagPrefix="cc2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style7
        {
            width: 117px;
        }
        .style10
        {
            height: 34px;
        }
        .style11
        {
            height: 35px;
        }
        .style12
        {
            height: 29px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 564px">
        <tr>
            <td align="center" bgcolor="#7C0104" colspan="3" class="style12">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="Rental Details of the Car"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style7" rowspan="4">
                &nbsp;</td>
            <td class="style10" colspan="2">
                <asp:Label ID="lblRent" runat="server" Text="Rs. " Font-Bold="True" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <br />
                <asp:Label ID="lblCarModel" runat="server" Text="Car Model: "></asp:Label>
            </td>
            <td class="style11">
                <asp:Label ID="lblExtraKM" runat="server" Text="Extra KM Charges: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="lblCarCapacity" runat="server" Text="Car Capacity: "></asp:Label>
            </td>
            <td class="style11">
                <asp:Label ID="lblExtraHour" runat="server" Text="Extra Hour Charges: "></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style11">
                <asp:Label ID="lblPurpose" runat="server" Text="Purpose: "></asp:Label>
            </td>
            <td class="style11">
                &nbsp;
            </td>
        </tr>
    </table>
    <asp:Label ID="Label6" runat="server" Font-Size="Smaller" Text="*Other extra charges: Toll charges and Road taxes to be paid locally. All extra charges will be payable in cash to the driver directly."></asp:Label>
    <br />
    <hr style="width: 570px" />
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td align="center" bgcolor="#7C0104" colspan="3" class="style12">
                        <asp:Label ID="Label14" runat="server" Font-Bold="True" ForeColor="White" Text="Pickup Details"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label8" runat="server" Text="Pickup Date: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPickupDate" runat="server"></asp:TextBox>
                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtPickupDate">
                        </cc1:CalendarExtender>
                        <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="txtPickupDate"
                            ErrorMessage="RangeValidator"></asp:RangeValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label9" runat="server" Text="Pickup Time: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlHours" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>01</asp:ListItem>
                            <asp:ListItem>02</asp:ListItem>
                            <asp:ListItem>03</asp:ListItem>
                            <asp:ListItem>04</asp:ListItem>
                            <asp:ListItem>05</asp:ListItem>
                            <asp:ListItem>06</asp:ListItem>
                            <asp:ListItem>07</asp:ListItem>
                            <asp:ListItem>08</asp:ListItem>
                            <asp:ListItem>09</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                            <asp:ListItem>11</asp:ListItem>
                            <asp:ListItem>12</asp:ListItem>
                            <asp:ListItem>13</asp:ListItem>
                            <asp:ListItem>14</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>16</asp:ListItem>
                            <asp:ListItem>17</asp:ListItem>
                            <asp:ListItem>18</asp:ListItem>
                            <asp:ListItem>19</asp:ListItem>
                            <asp:ListItem>20</asp:ListItem>
                            <asp:ListItem>21</asp:ListItem>
                            <asp:ListItem>22</asp:ListItem>
                            <asp:ListItem>23</asp:ListItem>
                        </asp:DropDownList>
                        &nbsp;<asp:DropDownList ID="dlMinutes" runat="server">
                            <asp:ListItem>00</asp:ListItem>
                            <asp:ListItem>15</asp:ListItem>
                            <asp:ListItem>30</asp:ListItem>
                            <asp:ListItem>45</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label10" runat="server" Text="No. of Passengers: "></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="dlPassengers" runat="server">
                            <asp:ListItem>1</asp:ListItem>
                            <asp:ListItem>2</asp:ListItem>
                            <asp:ListItem>3</asp:ListItem>
                            <asp:ListItem>4</asp:ListItem>
                            <asp:ListItem>5</asp:ListItem>
                            <asp:ListItem>6</asp:ListItem>
                            <asp:ListItem>7</asp:ListItem>
                            <asp:ListItem>8</asp:ListItem>
                            <asp:ListItem>9</asp:ListItem>
                            <asp:ListItem>10</asp:ListItem>
                        </asp:DropDownList>
                        <asp:RangeValidator ID="RangeValidator2" runat="server" ControlToValidate="dlPassengers"
                            ErrorMessage="RangeValidator"></asp:RangeValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label11" runat="server" Text="Pickup Address: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPAddress" runat="server" Height="58px" TextMode="MultiLine" Width="231px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtPAddress"
                            ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label12" runat="server" Text="Dropoff Address: "></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDAddress" runat="server" Height="58px" TextMode="MultiLine" Width="234px"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDAddress">*</asp:RequiredFieldValidator>
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID="cbConfirm" runat="server" Text="Confirm that your Pickup and drop off address is correct."
                            ValidationGroup="12" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td>
                        <cc2:GCheckoutButton ID="GCheckoutButton1" runat="server" OnClick="GCheckoutButton1_Click" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br />
</asp:Content>
