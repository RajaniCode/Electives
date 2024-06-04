<%@ Page Language="VB" MasterPageFile="~/MasterPage.master" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" title="Untitled Page" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
  <br />
    <br />
    <div style="width: 100%; height: 154px; text-align: center">
        <asp:LinkButton ID="lbPage1" runat="server" PostBackUrl="Page1.aspx">Page 1</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="lbPage2" runat="server" PostBackUrl="Page2.aspx">Page 2</asp:LinkButton><br />
        <br />
        <asp:LinkButton ID="lbPage3" runat="server" PostBackUrl="Page3.aspx">Page 3</asp:LinkButton><br />
        <br />
        </div>
        
        </asp:Content>

