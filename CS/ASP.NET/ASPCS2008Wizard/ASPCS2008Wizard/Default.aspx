<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008Wizard._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
     <asp:Wizard ID="Wizard1" runat="server" ActiveStepIndex="0" BackColor="#EFF3FB" BorderColor="#B5C7DE"
            BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" HeaderText="Cool Wizard control"
            OnActiveStepChanged="Wizard1_ActiveStepChanged" 
            OnFinishButtonClick="Wizard1_FinishButtonClick">
            <StepStyle Font-Size="0.8em" ForeColor="#333333" />
            <SideBarStyle BackColor="#507CD1" Font-Size="0.9em" VerticalAlign="Top" Width="150px"
                Wrap="False" />
            <NavigationButtonStyle BackColor="White" BorderColor="#507CD1" BorderStyle="Solid"
                BorderWidth="1px" Font-Names="Verdana" Font-Size="0.8em" ForeColor="#284E98" />
            <WizardSteps>
                <asp:WizardStep ID="step1" runat="server" Title="Account Details">
                    <table style="width: 100%">
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label1" runat="server" Text="User ID :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                                    Display="Dynamic" ErrorMessage="Please enter User ID"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label2" runat="server" Text="Password :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox2" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                                    Display="Dynamic" ErrorMessage="Please enter Password"></asp:RequiredFieldValidator>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="TextBox2"
                                    ControlToValidate="TextBox3" Display="Dynamic" ErrorMessage="Passwords do not match "></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label3" runat="server" Text="Confirm Password :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox3" runat="server" TextMode="Password"></asp:TextBox>
                                <br />
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="TextBox3"
                                    Display="Dynamic" ErrorMessage="Please enter password again"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap" style="height: 26px">
                                &nbsp;</td>
                            <td style="height: 26px">
                                &nbsp;&nbsp;
                            </td>
                        </tr>
                    </table>
                    <br />
                </asp:WizardStep>
                <asp:WizardStep ID="step2" runat="server" Title="Contact Information">
                    <table style="width: 100%">
                        <tr>
                            <td nowrap="nowrap">
                                &nbsp;<asp:Label ID="Label4" runat="server" Text="Email :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="TextBox4"
                                    Display="Dynamic" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox4"
                                    Display="Dynamic" ErrorMessage="Invalid email format" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label6" runat="server" Text="Telephone Number :"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="TextBox5"
                                    Display="Dynamic" ErrorMessage="Please enter email"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox5"
                                    Display="Dynamic" ErrorMessage="Invalid tel. no." ValidationExpression="((\(\d{3}\) ?)|(\d{3}-))?\d{3}-\d{4}"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                            </td>
                            <td>
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
                <asp:WizardStep ID="step3" runat="server" Title="Confirmation">
                    <table style="width: 100%">
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="User ID :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Email :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td nowrap="nowrap">
                                <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Telephone Number :"></asp:Label>
                            </td>
                            <td>
                                <asp:Label ID="Label11" runat="server" Font-Bold="True" Text="Label"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:WizardStep>
            </WizardSteps>
            <SideBarButtonStyle BackColor="#507CD1" Font-Names="Verdana" ForeColor="White" />
            <HeaderStyle BackColor="#284E98" BorderColor="#EFF3FB" BorderStyle="Solid" BorderWidth="2px"
                Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
        </asp:Wizard>
        <br />
        <asp:Label ID="Label12" runat="server" EnableViewState="False" Font-Size="Large"  ForeColor="Red">
        </asp:Label>
            
    </div>
    </form>
</body>
</html>
