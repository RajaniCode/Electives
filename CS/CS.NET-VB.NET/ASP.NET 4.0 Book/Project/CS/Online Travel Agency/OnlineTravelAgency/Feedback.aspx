<%@ Page Title="Feedback" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Feedback.aspx.cs" Inherits="Feedback" %>
    <%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit.HTMLEditor"
    TagPrefix="HTMLEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
    .style4
    {
        height: 34px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td align="center" bgcolor="#7C0104" colspan="2" class="style4">
                <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Give your Feedback"
                    ForeColor="White" Font-Size="Medium"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Your Name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtName" runat="server" Width="195px" BackColor="#FFFFDF"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label3" runat="server" Text="Your E-Mail"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtEMail" runat="server" Width="192px" BackColor="#FFFFDF"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEMail"
                    ErrorMessage="RequiredFieldValidator">*</asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="RegularExpressionValidator"
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="txtEMail">E-Mail Id is not valid.</asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label4" runat="server" Text="Your Feedback"></asp:Label>
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="2" >
               <%--  <ajaxToolkit:ToolkitScriptManager runat="Server" EnablePartialRendering="true" ID="ScriptManager1" />--%>
    <asp:UpdatePanel ID="updatePanel1" runat="server">
            <ContentTemplate>
                <HTMLEditor:Editor runat="server" Id="editor" Height="300px" AutoFocus="true" Width="100%" />
                
                 <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ErrorMessage="RequiredFieldValidator" ControlToValidate="editor">*</asp:RequiredFieldValidator>
            </ContentTemplate>
        </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" Height="27px" Width="81px"
                    OnClick="btnSubmit_Click" PostBackUrl="~/Feedback.aspx" />
            </td>
        </tr>
         <tr>
            <td align="center" bgcolor="#7C0104" colspan="2" class="style4">
                <asp:Label ID="Label5" runat="server" Font-Bold="True" 
                    Text="Received Feedback" Font-Size="Medium"
                    ForeColor="White"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <asp:DataList ID="dlFeedback" runat="server" BackColor="White" 
        BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
        ForeColor="Black" GridLines="Vertical" RepeatColumns="3" 
        RepeatDirection="Horizontal">       

        <AlternatingItemStyle BackColor="#4682B3" />
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <ItemStyle BackColor="#F7F7DE" />
        <ItemTemplate>
            Name:
            <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            <br />
            E-Mail:
            <asp:Label ID="EMailLabel" runat="server" Text='<%# Eval("EMail") %>' />
            <br />
            <br />
            <asp:Label ID="FeedbackLabel" runat="server" Text='<%# Eval("Feedback") %>' />
            <br />          
            <hr></hr>
            <br />
        </ItemTemplate>
        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
    </asp:DataList>   
    <br />
</asp:Content>
