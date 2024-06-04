<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   
<title>GridView Add, Edit, Delete </title>
    <link href="CSS/CSS.css" rel="Stylesheet" type="text/css" /> 
    <script src="scripts/jquery-1.3.2.min.js" type="text/javascript"></script>
    <script src="scripts/jquery.blockUI.js" type="text/javascript"></script>
    <script type = "text/javascript">
    function BlockUI(elementID) {
        var prm = Sys.WebForms.PageRequestManager.getInstance();
        prm.add_beginRequest(function () {
            $("#" + elementID).block({ message: '<table align = "center"><tr><td>' +
     '<img src="images/loadingAnim.gif"/></td></tr></table>',
                css: {},
                overlayCSS: { backgroundColor: '#000000', opacity: 0.6
                }
            });
        });
        prm.add_endRequest(function () {
            $("#" + elementID).unblock();
        });
    }
    $(document).ready(function () {

        BlockUI("dvgv");
        $.blockUI.defaults.css = {};
    });
    function Hidepopup() {
        $find("popup").hide();
        return false;
    }
</script> 


</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
</asp:ScriptManager>
<div id = "dvgv" style ="padding:10px;width:750px" align="center" >
<asp:UpdatePanel ID="UpdatePanel1" runat="server">
<ContentTemplate>
  
    <asp:GridView ID="gv" runat="server"
OnPageIndexChanging="pageddata" 
           OnRowCancelingEdit="Canceldata" AllowPaging="True" 
AutoGenerateColumns="false" PageSize="10" CellPadding="4" ForeColor="#333333"
GridLines="None" onrowdeleting="Deletedata">
<FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
<RowStyle BackColor="#EFF3FB" />
<Columns>

<asp:BoundField DataField = "empid" HeaderText = "Emp ID" HtmlEncode = "true" />
<asp:BoundField DataField = "empname" HeaderText = "Emp Name"  HtmlEncode = "true" />
<asp:BoundField DataField = "empcity" HeaderText = "Emp City"  HtmlEncode = "true"/> 
<asp:BoundField DataField = "empsalary"  HeaderText = "Emp Salary" HtmlEncode = "true"/> 

   <asp:TemplateField ItemStyle-Width = "30px"  >
   <ItemTemplate>
       <asp:LinkButton ID="lnkEdit" runat="server" Text = "Edit" OnClick="Edit" ></asp:LinkButton>
    </ItemTemplate>
    </asp:TemplateField>
   <asp:CommandField ShowDeleteButton="true"    ControlStyle-ForeColor="Blue" />
</Columns>

<PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
<SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
<HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
<EditRowStyle BackColor="#2461BF" />
<AlternatingRowStyle BackColor="White" />

</asp:GridView>
<br />
<br />


<asp:Button ID="btninsert" runat="server" Text="Insert" onclick="insertinXML" />


<asp:Panel ID="pnlAddEdit" runat="server" CssClass="modalPopup" style = "display:none">
<asp:Label Font-Bold = "true" ID = "Label4" runat = "server" Text = "Customer Details" ></asp:Label>
<br />
<table align = "center">
<tr>
<td>
<asp:Label ID = "Label1" runat = "server" Text = "EmpId" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtempID"  runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label ID = "Label2" runat = "server" Text = "EmpName" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtName" runat="server"></asp:TextBox>    
</td>
</tr>
<tr>
<td>
<asp:Label ID = "Label3" runat = "server" Text = "EmpCity" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtCity" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Label ID = "Label5" runat = "server" Text = "EmpSalary" ></asp:Label>
</td>
<td>
<asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
</td>
</tr>
<tr>
<td>
<asp:Button ID="btnSave" runat="server" Text="Add" OnClick = "Save" />
</td>
<td>
<asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick = "Update" />
</td>
<td>
<asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClientClick = "return Hidepopup()"/>
</td>
</tr>
</table>
</asp:Panel>


<cc1:ModalPopupExtender ID="popup" runat="server" DropShadow="false"
PopupControlID="pnlAddEdit" TargetControlID = "btnInsert"
BackgroundCssClass="modalBackground">
</cc1:ModalPopupExtender>
</ContentTemplate> 
<Triggers>
<asp:AsyncPostBackTrigger ControlID = "gv" />
<asp:AsyncPostBackTrigger ControlID = "btnSave" />
</Triggers> 
</asp:UpdatePanel> 
</div>
    </form>
</body>
</html>
