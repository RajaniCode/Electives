<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Modal._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    Are you sure you want to know the answer?.
    <asp:Button ID="btnYes" runat="server" Text="Yes!" />
    <br />
    <asp:Panel ID="pnlModal" runat="server" CssClass="modalPopup" Style="display: none;">
        Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque
        laudantium, totam rem aperiam, eaque ipsa quae ab illo inventore veritatis et quasi
        architecto beatae vitae dicta sunt explicabo. Nemo enim ipsam voluptatem quia voluptas
        sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione
        voluptatem sequi nesciunt. Neque porro quisquam est, qui dolorem ipsum quia dolor
        sit amet, consectetur, adipisci velit, sed quia non numquam eius modi tempora incidunt
        ut labore et dolore magnam aliquam quaerat voluptatem. Ut enim ad minima veniam,
        quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid
        ex ea commodi consequatur? Quis autem vel eum iure reprehenderit qui in ea voluptate
        velit esse quam nihil molestiae consequatur, vel illum qui dolorem eum fugiat quo
        voluptas nulla pariatur?
        <br />
        <asp:Button ID="btnClose" runat="server" Text="Close" />
    </asp:Panel>
    <asp:ModalPopupExtender TargetControlID="btnYes" ID="pnlModal_ModalPopupExtender"
        runat="server" DynamicServicePath="" Enabled="True" BackgroundCssClass="modalBackground"
        PopupControlID="pnlModal" CancelControlID="btnClose" DropShadow="true">
    </asp:ModalPopupExtender>
    </form>
</body>
</html>
