<%@ Page Title="" Language="C#" AutoEventWireup="true" CodeFile="Administrator.aspx.cs" MaintainScrollPositionOnPostback="true" Inherits="Administrator" %>

<%--MasterPageFile="~/MasterPage.master"--%>
<%--<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>--%>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <title></title>
    <style type="text/css">
        .page
        {
            width: 900px;
            background-color: #fff;
            margin: 20px auto 0px auto;
            border: 1px solid #496077;
        }
        .footer
        {
            background-color: #7C0104;
            color: White;
            padding: 8px 0px 0px 0px;
            margin: 0px auto;
            text-align: Left;
            line-height: normal;
            height: 20px;
            width: 896px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="page1">
         <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />
    
        <table style="width: 100%">
            <tr>
                <td class="style5" align="left" valign="top" colspan="2">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Resources/Logo.gif" Width="99%" Height="113px" />
                </td>
            </tr>
            <tr>
                <td align="left" valign="top" bgcolor="#7C0104">
                    <asp:Menu ID="Menu1" runat="server" Font-Size="Medium" ForeColor="White" Height="35px" Font-Bold="True" Font-Italic="False" Font-Names="Times New Roman" Orientation="Horizontal" EnableViewState="False" IncludeStyleBlock="False">
                        <StaticMenuStyle BackColor="#7C0104" HorizontalPadding="10px" />
                        <StaticSelectedStyle BackColor="#7A674C" ForeColor="Black" />
                        <StaticMenuItemStyle HorizontalPadding="5px" VerticalPadding="2px" />
                        <StaticHoverStyle BackColor="#7A674C" ForeColor="Black" />
                        <Items>
                            <asp:MenuItem Text="Home" Value="Home" NavigateUrl="~/Home_User.aspx" SeparatorImageUrl="~/Resources/Menu Seperator.gif"></asp:MenuItem>
                            <asp:MenuItem Text="Car" Value="New Item" NavigateUrl="~/Car.aspx" SeparatorImageUrl="~/Resources/Menu Seperator.gif"></asp:MenuItem>
                            <asp:MenuItem Text="Bus" Value="New Item" NavigateUrl="~/Bus.aspx" SeparatorImageUrl="~/Resources/Menu Seperator.gif"></asp:MenuItem>
                            <asp:MenuItem Text="Train" Value="New Item" NavigateUrl="~/Train.aspx" SeparatorImageUrl="~/Resources/Menu Seperator.gif"></asp:MenuItem>
                            <asp:MenuItem Text="Feedback" Value="New Item" NavigateUrl="~/Feedback.aspx" SeparatorImageUrl="~/Resources/Menu Seperator.gif"></asp:MenuItem>
                        </Items>
                    </asp:Menu>
                </td>
                <td valign="top" bgcolor="#7C0104">
                    <asp:LoginName ID="LoginName1" runat="server" Font-Bold="True" ForeColor="White"   FormatString="Welcome, {0}" />
                    <asp:LoginStatus ID="LoginStatus1" runat="server" LogoutAction="Redirect" LogoutPageUrl="~/Home_User.aspx" />
                </td>
            </tr>
            </table>
         <table>
<tr>
<td>
    <asp:Button ID="Btncardetails" runat="server" onclick="Btncardetails_Click" 
        Text="Car Details" />
    </td>
<td><asp:Button ID="BtnBusDetails" runat="server" Text="Bus Details" 
        onclick="BtnBusDetails_Click"/></td>
<td><asp:Button ID="BtnTrainDetails" runat="server" Text="Train Details" 
        onclick="BtnTrainDetails_Click" /></td>
        <td>
          <asp:Button ID="btnfeedback" runat="server" Text="Feedback" 
                onclick="btnfeedback_Click" />
        </td>
</tr>
</table>
<br />
<table id="Tablefeedback" runat="server">
<tr>
<td><asp:GridView runat="server" ID="gvfeedback" AutoGenerateColumns="False" 
        CellPadding="4" ForeColor="#333333" GridLines="None" Width="400px" 
        onrowdeleting="gvfeedback_RowDeleting" BorderColor="#7C0104" 
        BorderWidth="3px" RowHeaderColumn="Feedback">
    <AlternatingRowStyle BackColor="White" />
    <Columns>
        <asp:CommandField HeaderText="Delete" ShowCancelButton="False" 
            ShowDeleteButton="True" >
        <ControlStyle ForeColor="#4F4FFF" />
        </asp:CommandField>
        <asp:BoundField DataField="Name" HeaderText="Name" />
        <asp:BoundField DataField="EMail" HeaderText="EMail" />
        <asp:BoundField DataField="Feedback" HeaderText="Feedback" >
        <ItemStyle HorizontalAlign="Left" />
        </asp:BoundField>
    </Columns>
    <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
    <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" 
        Width="300px" Wrap="False" />
    <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
    <RowStyle BackColor="#FFFBD6" ForeColor="#333333" Width="300px" Wrap="False" />
    <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
    <SortedAscendingCellStyle BackColor="#FDF5AC" />
    <SortedAscendingHeaderStyle BackColor="#4D0000" />
    <SortedDescendingCellStyle BackColor="#FCF6C0" />
    <SortedDescendingHeaderStyle BackColor="#820000" />
</asp:GridView>
 </td>
</tr>

</table>

<table id="Traintable" runat="server">
<tr style="width:auto">
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>

<tr style="width:auto">

<td colspan ="4"> 
    <asp:GridView runat="server" ID="gvTrainDetails" 
            AllowPaging="True" AutoGenerateColumns="False" 
            OnPageIndexChanging="gvTrainDetails_PageIndexChanging" 
            OnRowCancelingEdit="gvTrainDetails_RowCancelingEdit" 
            OnRowDeleting="gvTrainDetails_RowDeleting" 
            OnRowEditing="gvTrainDetails_RowEditing" 
            OnRowUpdating="gvTrainDetails_RowUpdating" 
            OnSelectedIndexChanging="gvTrainDetails_SelectedIndexChanging" 
        BorderColor="#7C0104" BorderWidth="3px" CellPadding="4" ForeColor="#333333" 
        GridLines="None">
                                        <AlternatingRowStyle BackColor="White" />
                                        <Columns>
                                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" 
                                                ShowHeader="True">
                                              <ControlStyle ForeColor="#4F4FFF" />
        </asp:CommandField>
                                                
                                                <asp:BoundField DataField="TrainID" HeaderText="TrainID" ReadOnly ="true" />
                                            <asp:BoundField DataField="DepartStation" HeaderText="Departure" />
                                            <asp:BoundField DataField="ArrivalStation" HeaderText="ArrivalStation" />
                                            <asp:BoundField DataField="DepartureDate" HeaderText="DepartureDate" />
                                            <asp:BoundField DataField="SleeperClass" HeaderText="SleeperClass" />
                                            <asp:BoundField DataField="ACFirstClass" HeaderText="ACFirstClass" />
                                            <asp:BoundField DataField="2Tier" HeaderText="2Tier" />
                                            <asp:BoundField DataField="3Tier" HeaderText="3Tier" />
                                            <asp:BoundField DataField="SleeperClassFare" HeaderText="SleeperClassFare" />
                                            <asp:BoundField DataField="ACFirstClassFare" HeaderText="ACFirstClassFare" />
                                            <asp:BoundField DataField="2TierFare" HeaderText="2TierFare" />
                                            <asp:BoundField DataField="3TierFare" HeaderText="3TierFare" />
                                            <asp:BoundField DataField="DepartureTime" HeaderText="DepartureTime" />
                                        </Columns>
                                        <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                                        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                                        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                                        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                                        <SortedAscendingCellStyle BackColor="#FDF5AC" />
                                        <SortedAscendingHeaderStyle BackColor="#4D0000" />
                                        <SortedDescendingCellStyle BackColor="#FCF6C0" />
                                        <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>
</td>

</tr>
<tr style="width:auto">
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr style="width:auto">
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
<tr>
<td><asp:Label ID="Label15" runat="server" Text="Departure Station">
</asp:Label></td><td><asp:TextBox ID="txtDepartStation" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtDepartStation"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label16" runat="server" Text="Arrival Station"></asp:Label></td><td><asp:TextBox ID="txtArriveStation" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtArriveStation"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr>
                                                        <tr><td><asp:Label ID="Label17" runat="server" Text="Depart Date"></asp:Label></td>
                                                        <td><asp:TextBox ID="txtDepartDate" runat="server"></asp:TextBox>
                                                        <ajaxToolkit:CalendarExtender ID="txtDepartDate_CalendarExtender" runat="server" Enabled="True" 
                                                        TargetControlID="txtDepartDate">
                                                        </ajaxToolkit:CalendarExtender>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ControlToValidate="txtDepartDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator>
                                                    <asp:RangeValidator ID="RangeValidator2" runat="server" 
                                                        ControlToValidate="txtDepartDate" ValidationGroup="Train"></asp:RangeValidator></td></tr><tr><td><asp:Label ID="Label18" runat="server" Text="Sleeper Class Seats"></asp:Label></td><td><asp:TextBox ID="txtSleeperClassSeats" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txtSleeperClassSeats_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Numbers" TargetControlID="txtSleeperClassSeats"></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtSleeperClassSeats"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label19" runat="server" Text="AC First Class Seats"></asp:Label></td><td><asp:TextBox ID="txtACclassSeats" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txtACclassSeats_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Numbers" TargetControlID="txtACclassSeats"></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ControlToValidate="txtACclassSeats"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label20" runat="server" Text="2 Tier Seats"></asp:Label></td><td><asp:TextBox ID="txt2TierSeats" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txt2TierSeats_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Numbers" TargetControlID="txt2TierSeats"></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ControlToValidate="txt2TierSeats"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label21" runat="server" Text="3 Tier Seats"></asp:Label></td><td><asp:TextBox ID="txt3TierSeats" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txt3TierSeats_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Numbers" TargetControlID="txt3TierSeats"></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ControlToValidate="txt3TierSeats"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label22" runat="server" Text="Sleeper Class Fare"></asp:Label></td><td><asp:TextBox ID="txtSleeperFare" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txtSleeperFare_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtSleeperFare"
                                                        ValidChars="."></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ControlToValidate="txtSleeperFare"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label23" runat="server" Text="AC First Class Fare"></asp:Label></td><td><asp:TextBox ID="txtACFare" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txtACFare_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtACFare" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ControlToValidate="txtACFare"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label24" runat="server" Text="2 Tier Fare"></asp:Label></td><td><asp:TextBox ID="txt2TierFare" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txt2TierFare_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Custom, Numbers" TargetControlID="txt2TierFare" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ControlToValidate="txt2TierFare"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label25" runat="server" Text="3 Tier Fare"></asp:Label></td><td><asp:TextBox ID="txt3TierFare" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txt3TierFare_FilteredTextBoxExtender" runat="server"
                                                        Enabled="True" FilterType="Custom, Numbers" TargetControlID="txt3TierFare" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ControlToValidate="txt3TierFare"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label26" runat="server" Text="Depart Time"></asp:Label></td><td><asp:TextBox ID="txtDepartTime" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ControlToValidate="txtDepartTime"
                                                        ErrorMessage="RequiredFieldValidator" ValidationGroup="Train">*</asp:RequiredFieldValidator>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtDepartTime"
                                                        ErrorMessage="Invalid Time" ValidationExpression="\d{2}:\d{2}"
                                                        ValidationGroup="Train"></asp:RegularExpressionValidator></td></tr><tr><td>&#160;&#160;</td><td>&#160;&#160;</td></tr><tr><td>&#160;&#160;</td><td>
    <asp:Button ID="btnAddTrain" runat="server" Height="26px" OnClick="btnAddTrain_Click"
                                                        Text="Add Train Details" 
        Width="112px" ValidationGroup="Train" />
    <asp:Button ID="btnResetTrainDetails" runat="server" OnClick="btnResetTrainDetails_Click"
                                                        Text="Reset" 
        CausesValidation="False" Height="28px" style="margin-bottom: 0px" 
        Width="86px" /></td></tr>
                                           
                
       
    <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                                           
                
       
</table>
        <%--Train table Ends Here--%>
        
   
                    
<table id="TableBusDetails" runat="server" width="100%">
<tr style="width:auto">
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
 <tr style="width:auto">
  <td colspan="4" >

<asp:GridView ID="gvBusDetails" runat="server" AutoGenerateColumns="False" width="50%"
          CellPadding="4" AllowPaging="True" 
          onselectedindexchanged="gvBusDetails_SelectedIndexChanged" 
          onpageindexchanging="gvBusDetails_PageIndexChanging"  
          onrowcancelingedit="gvBusDetails_RowCancelingEdit" 
          onrowdeleting="gvBusDetails_RowDeleting" onrowediting="gvBusDetails_RowEditing" 
          onrowupdating="gvBusDetails_RowUpdating" ForeColor="#333333" 
          GridLines="None" BorderWidth="3px" BorderColor="#7C0104">
    <AlternatingRowStyle BackColor="White" />
    <Columns><asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CausesValidation="False" >
      <ControlStyle ForeColor="#4F4FFF" />
        </asp:CommandField>
    <asp:BoundField DataField="BusId" HeaderText="BusId" ReadOnly="True" SortExpression="BusId" />
                 <asp:BoundField DataField="BFrom" HeaderText="From" />
                 <asp:BoundField DataField="BTo" HeaderText="To"  />
                 <asp:BoundField DataField="BDate" HeaderText="Date" />
                 <asp:BoundField DataField="SeatsAvailable" HeaderText="SeatsAvailable" />
                 <asp:BoundField DataField="Fare" HeaderText="Fare" />
                
                 </Columns>
                  <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                   <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
                   <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
                   <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
                   <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
                   <SortedAscendingCellStyle BackColor="#FDF5AC" />
                   <SortedAscendingHeaderStyle BackColor="#4D0000" />
                    <SortedDescendingCellStyle BackColor="#FCF6C0" />
                    <SortedDescendingHeaderStyle BackColor="#820000" />
                 </asp:GridView>
          </td>
  
  </tr>    

 <tr style="width:auto">
  <td colspan="4" >

      &nbsp;</td>
  
  </tr>    

<tr><td><asp:Label ID="Label8" runat="server" Text="From"></asp:Label></td>
<td><asp:TextBox ID="txtFrom" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtFrom"  ErrorMessage="RequiredFieldValidator" 

ValidationGroup="Bus">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label9" runat="server" Text="To"></asp:Label></td><td><asp:TextBox ID="txtTo" 

runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtTo"
                                                        ErrorMessage="RequiredFieldValidator" 

ValidationGroup="Bus">*</asp:RequiredFieldValidator></td></tr>
<tr><td><asp:Label ID="Label10" runat="server" Text="Date"></asp:Label></td>
<td><asp:TextBox ID="txtDate" runat="server"></asp:TextBox>
<ajaxToolkit:CalendarExtender ID="txtDate_CalendarExtender" runat="server" Enabled="True" TargetControlID="txtDate"></ajaxToolkit:CalendarExtender>
<asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ControlToValidate="txtDate" ErrorMessage="RequiredFieldValidator" ValidationGroup="Bus">*</asp:RequiredFieldValidator>
<asp:RangeValidator ID="RangeValidator1" runat="server" Type="Date" ControlToValidate="txtDate" ErrorMessage="RangeValidator" ValidationGroup="Bus">Date is not valid</asp:RangeValidator></td></tr><tr><td><asp:Label ID="Label11" runat="server" Text="Seats Available"></asp:Label></td>
<td><asp:TextBox ID="txtSeatsAvailable" runat="server"></asp:TextBox>
<ajaxToolkit:FilteredTextBoxExtender ID="txtSeatsAvailable_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="txtSeatsAvailable"></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtSeatsAvailable" ErrorMessage="RequiredFieldValidator" ValidationGroup="Bus">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label12" runat="server" Text="Fare"></asp:Label></td>
<td><asp:TextBox ID="txtFare" runat="server"></asp:TextBox>
<ajaxToolkit:FilteredTextBoxExtender ID="txtFare_FilteredTextBoxExtender" runat="server"  Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtFare" ValidChars=".">
</ajaxToolkit:FilteredTextBoxExtender>
<asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtFare" ErrorMessage="RequiredFieldValidator" ValidationGroup="Bus">*</asp:RequiredFieldValidator></td></tr><tr><td>&#160;&#160;</td>
<td><asp:Button ID="btnAddBusDetails" runat="server" Height="24px" 
        OnClick="btnAddBusDetails_Click"    Text="Add Bus Details" Width="113px" 
        ValidationGroup="Bus" />
<asp:Button ID="btnResetBusDetails" runat="server" 
        OnClick="btnResetBusDetails_Click" Text="Reset" CausesValidation="False" 
        Height="25px" Width="89px" /></td></tr>

                  <tr><td>&nbsp;</td><td>&nbsp;</td></tr>
                  </table>
        
        <%-----Bus Table Ends here--------------------%>

        <table id="TableCarDetails" runat="server" width="100%">
        <tr style="width:auto">
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
<td>&nbsp;</td>
</tr>
        <tr style="width:auto">
        <td colspan="4">
        
        <asp:GridView ID="gvCarDetails" runat="server" CellPadding="4" DataKeyNames="CarId" 
                AutoGenerateColumns="False" AllowPaging="True" ForeColor="#333333" 
                GridLines="None" BorderColor="#7C0104" BorderWidth="3px" 
                onpageindexchanging="gvCarDetails_PageIndexChanging" 
                onrowcancelingedit="gvCarDetails_RowCancelingEdit" 
                onrowdeleting="gvCarDetails_RowDeleting" onrowediting="gvCarDetails_RowEditing" 
                onrowupdating="gvCarDetails_RowUpdating">
            <AlternatingRowStyle BackColor="White" />
        <Columns>
        <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" CausesValidation="False" >
          <ControlStyle ForeColor="#4F4FFF" />
        </asp:CommandField>
        <asp:BoundField DataField="CarId" HeaderText="CarId" InsertVisible="False" ReadOnly="True" SortExpression="CarId" />
        <asp:BoundField DataField="CarModel" HeaderText="CarModel" SortExpression="CarModel" />
        <asp:BoundField DataField="FullDayRent" HeaderText="FullDayRent" SortExpression="FullDayRent" />
        <asp:BoundField DataField="HalfDayRent" HeaderText="HalfDayRent" SortExpression="HalfDayRent" />
        <asp:BoundField DataField="Price_ExtraKM" HeaderText="Price_ExtraKM" SortExpression="Price_ExtraKM" />
        <asp:BoundField DataField="Price_ExtraHour" HeaderText="Price_ExtraHour" SortExpression="Price_ExtraHour" />
        <asp:BoundField DataField="CarCapacity" HeaderText="CarCapacity" SortExpression="CarCapacity" />
        <asp:BoundField DataField="City" HeaderText="City" SortExpression="City" />
        </Columns>
        <FooterStyle BackColor="#990000" ForeColor="White" Font-Bold="True" />
        <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
        <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
        <SortedAscendingCellStyle BackColor="#FDF5AC" />
        <SortedAscendingHeaderStyle BackColor="#4D0000" />
        <SortedDescendingCellStyle BackColor="#FCF6C0" />
        <SortedDescendingHeaderStyle BackColor="#820000" />
        </asp:GridView>        
        
        </td>
        </tr>

        
        <tr style="width:auto">
        <td colspan="4">
        
            &nbsp;</td>
        </tr>

        
<tr><td><asp:Label ID="Label1" runat="server" Text="Car Model"></asp:Label></td><td><asp:TextBox ID="txtCarModel" runat="server"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ControlToValidate="txtCarModel" ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label2" runat="server" Text="Full Day Rent"></asp:Label></td><td><asp:TextBox ID="txtFullDayRent" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txtFullDayRent_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtFullDayRent"  ValidChars="."></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
        ControlToValidate="txtFullDayRent" ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label3" runat="server" Text="Half Day Rent"></asp:Label></td><td><asp:TextBox ID="txtHalfDayRent" runat="server"></asp:TextBox>
<ajaxToolkit:FilteredTextBoxExtender ID="txtHalfDayRent_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Custom, Numbers" TargetControlID="txtHalfDayRent" ValidChars="."></ajaxToolkit:FilteredTextBoxExtender><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
        ControlToValidate="txtHalfDayRent" ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label4" runat="server" Text="Price Per Extra KM"></asp:Label></td><td><asp:TextBox ID="txtExtraKM" runat="server"></asp:TextBox>
<ajaxToolkit:FilteredTextBoxExtender ID="txtExtraKM_FilteredTextBoxExtender" runat="server" Enabled="True" ValidChars="." TargetControlID="txtExtraKM" FilterType="Custom, Numbers"></ajaxToolkit:FilteredTextBoxExtender>
<asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
        ControlToValidate="txtExtraKM" ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label5" runat="server" Text="Price Per Extra Hour"></asp:Label></td><td><asp:TextBox ID="txtExtraHour" runat="server"></asp:TextBox><ajaxToolkit:FilteredTextBoxExtender ID="txtExtraHour_FilteredTextBoxExtender" runat="server"  Enabled="True" ValidChars="." TargetControlID="txtExtraHour" FilterType="Custom, 
Numbers"></ajaxToolkit:FilteredTextBoxExtender>
<asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
        ControlToValidate="txtExtraHour" ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label6" runat="server" Text="Capacity"></asp:Label></td><td><asp:TextBox ID="txtCapacity" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
        ControlToValidate="txtCapacity" ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td><asp:Label ID="Label27" runat="server" Text="City"></asp:Label></td><td><asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
<asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
        ControlToValidate="txtCity"  ErrorMessage="RequiredFieldValidator" 
        ValidationGroup="car">*</asp:RequiredFieldValidator></td></tr><tr><td>&nbsp;</td><td>&#160;&#160;
</td></tr><tr><td>&#160;&#160;</td><td><asp:Button ID="btnAdd" runat="server" Text="Add Car Details" OnClick="btnAdd_Click" 
        Height="23px" Width="105px" ValidationGroup="car" /><asp:Button ID="btnReset" runat="server" Text="Reset" OnClick="btnReset_Click" 
        CausesValidation="False" Height="26px" Width="78px" /></td></tr>

</table>
<br /> 

        
        <%-----Car Table Ends here--------------------%>
<table width="100%">

<tr>

<td colspan="4" class="footer" align="left">
  <center>Copyright © Kogent Learning Solutions Inc. 2010 </center>
</td>
</tr>
</table> 
   
        </div>
    </form>
</body>
</html>

