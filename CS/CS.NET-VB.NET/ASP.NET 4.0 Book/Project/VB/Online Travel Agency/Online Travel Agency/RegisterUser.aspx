<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/MasterPage2.master" CodeBehind="RegisterUser.aspx.vb" Inherits="Online_Travel_Agency.WebForm8" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <style type="text/css">
        .style1
        {
            width: 413px;
            height: 437px;
        }
        .style8
        {
            width: 131px;
        }
        .style9
        {
            height: 27px;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div class="style1">
        <asp:CreateUserWizard ID="CreateUserWizard1" 
                    ContinueDestinationPageUrl="~/Home_User.aspx" 
            DisplaySideBar="True" FinishDestinationPageUrl="~/Home_User.aspx" 
                    runat="server" BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" 
                    BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" 
            Width="425px" 
            oncreateduser="CreateUserWizard1_CreatedUser">
                <SideBarStyle BackColor="#5D7B9D" Font-Size="0.9em" 
                    VerticalAlign="Top" Wrap="True" BorderWidth="0px" />
                <SideBarButtonStyle Font-Names="Verdana" ForeColor="White" 
                    BorderStyle="Dotted" BorderWidth="0px" />
                <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                    ForeColor="#284775" />
                <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                    ForeColor="#284775" />
                <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" 
                    Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
                <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" 
                    BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" 
                    ForeColor="#284775" />
        <StepNavigationTemplate>
            <asp:Button ID="StepPreviousButton" runat="server" CausesValidation="False" 
                CommandName="MovePrevious" Text="Previous" />
            <asp:Button ID="StepNextButton" runat="server" CommandName="MoveNext" 
                Text="Next" />
        </StepNavigationTemplate>
                <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <StepStyle BorderWidth="0px" />
        <WizardSteps>
        <asp:WizardStep ID="CreateUserWizardStep0" runat="server" 
                Title="Step 1">
                 <ContentTemplate>
                     <table border="0">
                         <tr>
                             <td align="center" colspan="2" bgcolor="#507CD1">
                                 Enter Your Personal Information</td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 <asp:Label ID="FirstNameLabel" runat="server" AssociatedControlID="FirstName">First 
                                 Name:</asp:Label>
                             </td>
                             <td class="style6">
                                 <asp:TextBox ID="FirstName" runat="server"></asp:TextBox>
                                 <cc1:FilteredTextBoxExtender ID="FirstName_FilteredTextBoxExtender" 
                                     runat="server" Enabled="True"  
                                     TargetControlID="FirstName" FilterType="Custom, LowercaseLetters, UppercaseLetters">
                                 </cc1:FilteredTextBoxExtender>
                                 <asp:RequiredFieldValidator ID="FirstNameRequired" runat="server" 
                                     ControlToValidate="FirstName" ErrorMessage="First Name is required." 
                                     ToolTip="First Name is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 <asp:Label ID="LastNameLabel" runat="server" AssociatedControlID="LastName">Last 
                                 Name:</asp:Label>
                             </td>
                             <td class="style6">
                                 <asp:TextBox ID="LastName" runat="server"></asp:TextBox>
                                 <cc1:FilteredTextBoxExtender ID="LastName_FilteredTextBoxExtender" 
                                     runat="server" Enabled="True" 
                                     FilterType="Custom, UppercaseLetters, LowercaseLetters" 
                                     TargetControlID="LastName">
                                 </cc1:FilteredTextBoxExtender>
                                 <asp:RequiredFieldValidator ID="LastNameRequired" runat="server" 
                                     ControlToValidate="LastName" ErrorMessage="Last Name is required." 
                                     ToolTip="Last Name is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 Mobile No:</td>
                             <td class="style6">
                                 <asp:TextBox ID="Number" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="ContactNumberRequired" runat="server" 
                                     ControlToValidate="Number" ErrorMessage="ContactNo. is required." 
                                     ToolTip="ContactNo. is required.">*</asp:RequiredFieldValidator>
                                 <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                     ControlToValidate="Number" ErrorMessage="Invalid Contact No" 
                                     ToolTip="Invalid Contact No" ValidationExpression="^[0-9]\d{2,4}\d{6,8}$">*</asp:RegularExpressionValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 <asp:Label ID="AddressLabel" runat="server" AssociatedControlID="Address">Address:</asp:Label>
                             </td>
                             <td class="style6">
                                 <asp:TextBox ID="Address" runat="server" TextMode="MultiLine" Width="149px" style="overflow:hidden" ></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="AddressRequired" runat="server" 
                                     ControlToValidate="Address" ErrorMessage="Address is required." 
                                     ToolTip="Address is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 <asp:Label ID="CityLabel" runat="server" AssociatedControlID="City">City:</asp:Label>
                             </td>
                             <td class="style6">
                                 <asp:TextBox ID="City" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="CityRequired" runat="server" 
                                     ControlToValidate="City" ErrorMessage="City is required." 
                                     ToolTip="City is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 <asp:Label ID="StateLabel" runat="server" AssociatedControlID="State">State:</asp:Label>
                             </td>
                             <td class="style6">
                                 <asp:TextBox ID="State" runat="server"></asp:TextBox>
                                 <asp:RequiredFieldValidator ID="StateRequired" runat="server" 
                                     ControlToValidate="State" ErrorMessage="State is required." 
                                     ToolTip="State is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 <asp:Label ID="ZipLabel" runat="server" AssociatedControlID="Zip">Zip:</asp:Label>
                             </td>
                             <td class="style6">
                                 <asp:TextBox ID="Zip" runat="server"></asp:TextBox>
                                 <cc1:FilteredTextBoxExtender ID="Zip_FilteredTextBoxExtender" runat="server" Enabled="True" FilterType="Numbers" TargetControlID="Zip">
                                 </cc1:FilteredTextBoxExtender>
                                 <asp:RequiredFieldValidator ID="ZipRequired" runat="server" 
                                     ControlToValidate="Zip" ErrorMessage="Zip is required." 
                                     ToolTip="Zip is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 Nationality</td>
                             <td class="style6">
                                 <asp:TextBox ID="Nationality" runat="server">Indian</asp:TextBox>
                                 <asp:RequiredFieldValidator ID="NationalityRequired" runat="server" 
                                     ControlToValidate="Nationality" ErrorMessage="Nationality is required." 
                                     ToolTip="Nationality is required.">*</asp:RequiredFieldValidator>
                             </td>
                         </tr>
                         <tr>
                             <td align="right" class="style8">
                                 Sex</td>
                             <td class="style6">
                                 <asp:DropDownList ID="Sex" runat="server">
                                     <asp:ListItem>F</asp:ListItem>
                                     <asp:ListItem>M</asp:ListItem>
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td align="center" colspan="2" style="color:Red;">
                                 <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                             </td>
                         </tr>
                     </table>
                 </ContentTemplate>
            </asp:WizardStep>
            
            <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server" 
                Title="Step 2">
                <ContentTemplate>
                    <table border="0">
                       <tr>
                            
                            <td align="center" colspan="2" bgcolor="#507CD1">
                                Enter User Account Details</td>
                            
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">User 
                                Name:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" 
                                    ControlToValidate="UserName" ErrorMessage="User Name is required." 
                                    ToolTip="User Name is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" 
                                    ControlToValidate="Password" ErrorMessage="Password is required." 
                                    ToolTip="Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="ConfirmPasswordLabel" runat="server" 
                                    AssociatedControlID="ConfirmPassword">Confirm Password:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" 
                                    ControlToValidate="ConfirmPassword" 
                                    ErrorMessage="Confirm Password is required." 
                                    ToolTip="Confirm Password is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" class="style9">
                                <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                            </td>
                            <td class="style9">
                                <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="EmailRequired" runat="server" 
                                    ControlToValidate="Email" ErrorMessage="E-mail is required." 
                                    ToolTip="E-mail is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                                    ErrorMessage="RegularExpressionValidator" ControlToValidate="Email" 
                                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">E-mail Id is not valid</asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Security 
                                Question:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" 
                                    ControlToValidate="Question" ErrorMessage="Security question is required." 
                                    ToolTip="Security question is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Security 
                                Answer:</asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" 
                                    ControlToValidate="Answer" ErrorMessage="Security answer is required." 
                                    ToolTip="Security answer is required." ValidationGroup="CreateUserWizard1">*</asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:CompareValidator ID="PasswordCompare" runat="server" 
                                    ControlToCompare="Password" ControlToValidate="ConfirmPassword" 
                                    Display="Dynamic" 
                                    ErrorMessage="The Password and Confirmation Password must match." 
                                    ValidationGroup="CreateUserWizard1"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2" style="color:Red;">
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                            </td>
                        </tr>
                    </table> <asp:SqlDataSource ID="InsertExtraInfo" runat="server" ConnectionString="<%$ ConnectionStrings:Travel %>"
    InsertCommand="INSERT INTO [UserInfo] ([UserId], [UserName], [FirstName], [LastName], [ContactNumber], [Address], [City], [State], [Zip], [Nationality], [Sex]) VALUES (@UserId, @UserName, @FirstName, @LastName, @Number, @Address, @City, @State, @Zip, @Nationality, @Sex)"
    ProviderName="<%$ ConnectionStrings:Travel.ProviderName %>">
    <InsertParameters>
        <asp:ControlParameter Name="UserName" Type="String" ControlID="UserName" PropertyName="Text" />
        <asp:ControlParameter Name="FirstName" Type="String" ControlID="FirstName" PropertyName="Text" />
        <asp:ControlParameter Name="LastName" Type="String" ControlID="LastName" PropertyName="Text" />
        <asp:ControlParameter Name="Number" Type="String" ControlID="Number" PropertyName="Text" />
        <asp:ControlParameter Name="Address" Type="String" ControlID="Address" PropertyName="Text" />
        
        <asp:ControlParameter Name="City" Type="String" ControlID="City" PropertyName="Text" />
        <asp:ControlParameter Name="State" Type="String" ControlID="State" PropertyName="Text" />
        <asp:ControlParameter Name="Zip" Type="String" ControlID="Zip" PropertyName="Text" />
        <asp:ControlParameter Name="Nationality" Type="String" ControlID="Nationality" PropertyName="Text" />
        <asp:ControlParameter Name="Sex" Type="String" ControlID="Sex" PropertyName="Text" />
    </InsertParameters>
</asp:SqlDataSource>
                </ContentTemplate>
            </asp:CreateUserWizardStep>
            <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server" Title="Finish" >
            </asp:CompleteWizardStep>
        </WizardSteps>
    </asp:CreateUserWizard>
    </div>
</asp:Content>
