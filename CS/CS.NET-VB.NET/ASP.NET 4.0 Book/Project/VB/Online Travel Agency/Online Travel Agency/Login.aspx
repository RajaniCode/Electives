<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage2.master" CodeBehind="Login.aspx.vb" Inherits="Online_Travel_Agency.WebForm10" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <asp:Login ID="Login1" runat="server" BackColor="#FFFBD6" BorderColor="#FFDFAD" 
        BorderPadding="4" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
        Font-Size="X-Small" ForeColor="#333333" Height="102px" Width="615px" 
                     CreateUserText="Register Here" CreateUserUrl="~/RegisterUser.aspx" 
                     DestinationPageUrl="~/Home_User.aspx" PasswordRecoveryText="Recover Your Password" 
                     PasswordRecoveryUrl="~/RecoverPassword.aspx" 
        TextLayout="TextOnTop">
        <TextBoxStyle Font-Size="0.8em" />
        <LoginButtonStyle BackColor="White" BorderColor="#CC9966" BorderStyle="Solid" 
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" />
                     <LayoutTemplate>
                        <%-- <table border="0" cellpadding="4" cellspacing="0" 
                             style="border-collapse:collapse;">
                             <tr>--%>
                              <%--   <td>--%>
                                     <table border="0" cellpadding="0" style="height:150px;width:100%;">
                                         <tr>
                                             <td align="center" colspan="2" 
                                                 
                                                 style="color:White;background-color:#7C0104; font-size:large;font-weight:bold;">
                                                 Log In</td>
                                         </tr>
                                         <tr>
                                             <td align="right">
                                                 &nbsp;</td>
                                             <td>
                                                 &nbsp;</td>
                                         </tr>
                                         <tr>
                                             <td align="right">
                                                 <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User Name:</asp:Label>
                                             </td>
                                             <td>
                                                 <asp:TextBox ID="UserName" runat="server" Font-Size="X-Small" Height="18px" 
                                                     Width="177px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                                     ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                                     ForeColor="Red" ToolTip="User Name is required." ValidationGroup="Login1">*</asp:RequiredFieldValidator>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="right">
                                                 <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                                             </td>
                                             <td align="left">
                                                 <asp:TextBox ID="Password" runat="server" Font-Size="0.8em" TextMode="Password" 
                                                     Width="176px" Height="18px"></asp:TextBox>
                                                 <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                                     ControlToValidate="Password" ErrorMessage="Password is required." 
                                                     ToolTip="Password is required." ValidationGroup="Login1" ForeColor="Red">*</asp:RequiredFieldValidator>
                                             </td>
                                         </tr>
                                         <tr>
                                         <td> </td>
                                             <td align="left">
                                                 <asp:CheckBox ID="RememberMe" runat="server" Text="Remember me next time." />
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="center" colspan="2" style="color:Red;">
                                                 <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                             </td>
                                         </tr>
                                         <tr>
                                             <td align="center" colspan="2">
                                                 <asp:Button ID="LoginButton" runat="server" BackColor="#FFFBFF" 
                                                     BorderColor="#CC9966" BorderStyle="Solid" BorderWidth="1px" CommandName="Login" 
                                                     Font-Names="Verdana" Font-Size="0.8em" ForeColor="#990000" Height="23px" 
                                                     Text="Log In" ValidationGroup="Login1" Width="57px" />
                                             </td>
                                         </tr>
                                         <tr>
                                             <td colspan="2">
                                                 <asp:HyperLink ID="CreateUserLink" runat="server" 
                                                     NavigateUrl="~/RegisterUser.aspx">Register Here</asp:HyperLink>
                                                 <br />
                                                 <asp:HyperLink ID="PasswordRecoveryLink" runat="server" 
                                                     NavigateUrl="~/RecoverPassword.aspx">Recover Your Password</asp:HyperLink>
                                             </td>
                                         </tr>
                                     </table>
                                 <%--</td>
                             </tr>
                         </table>--%>
                     </LayoutTemplate>
        <InstructionTextStyle Font-Italic="True" ForeColor="Black" />
        <TitleTextStyle BackColor="#990000" Font-Bold="True" Font-Size="0.9em" 
            ForeColor="White" />
    </asp:Login>
</asp:Content>
