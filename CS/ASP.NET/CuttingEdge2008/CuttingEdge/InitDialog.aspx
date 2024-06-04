<%@ Page Language="C#" AutoEventWireup="true" CodeFile="InitDialog.aspx.cs" Inherits="InitDialogPage" EnableEventValidation="false" %>
<%@ Register Assembly="AjaxControlToolkit" TagPrefix="act" Namespace="AjaxControlToolkit" %>
 
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Testing Custom Modal Dialog Boxes</title>
     <style>
        .modalPopup 
        {
	        background-color:#ffffdd;
	        border-width:3px;
	        border-style:solid;
	        border-color:Gray;
	        padding:3px;
	        width:350px;
        }
        .modalBackground 
        {
	        background-color:Gray;
	        filter:alpha(opacity=70);
	        opacity:0.7;
        }    
    </style>    
</head>


<script type="text/javascript">
function ok(sender, e)
{
    $find('ModalPopupExtender1').hide();
    __doPostBack('editBox_OK', e); 
}

function cancel(sender, e)
{
    $find('ModalPopupExtender1').hide();
}

function pageLoad(sender, args) 
{
    $addHandler(document, "keydown", onKeyDown);
    $find("ModalPopupExtender1").add_showing(onModalShowing);
}


function onModalShowing(sender, args)
{
    $get("pnlEditCustomer").style.backgroundColor = "yellow";
}

function onKeyDown(args)
{
    if(args.keyCode == Sys.UI.Key.esc)
    {
        $find('ModalPopupExtender1').hide();
    }
} 
</script>


<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
    
        <table>
            <tr>
                <td valign="top">
                    <b>Customers</b><br />
                    <asp:DropDownList id="ddlCustomers" runat="server" 
                        DataSourceID="odsCustomers" 
                        DataTextField="CompanyName" 
                        DataValueField="ID" 
                        AutoPostBack="true" 
                        OnSelectedIndexChanged="ddlCustomers_SelectedIndexChanged" 
                        ondatabound="ddlCustomers_DataBound" />
                    <asp:ObjectDataSource ID="odsCustomers" runat="server"
                        TypeName="IntroAjax.CustomerManager"
                        SelectMethod="LoadAll">
                    </asp:ObjectDataSource>
                </td>
                <td valign="top">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <table>            
                                <tr>
                                    <td><b>Customer ID:</b></td>
                                    <td><asp:Label runat="server" id="lblCustomerID" /></td>
                                </tr>            
                                <tr>
                                    <td><b>Company Name:</b></td>
                                    <td><asp:Label runat="server" id="lblCompanyName" /></td>
                                </tr>
                                <tr>
                                    <td><b>Contact Name:</b></td>
                                    <td><asp:Label runat="server" id="lblContactName" /></td>
                                </tr>
                                <tr>
                                    <td><b>Country:</b></td>
                                    <td><asp:Label runat="server" id="lblCountry" /></td>
                                </tr>
                            </table>         
                        </ContentTemplate>     
                        <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ddlCustomers" EventName="SelectedIndexChanged" />
                            <asp:AsyncPostBackTrigger ControlID="editBox_OK" />
                        </Triggers>  
                    </asp:UpdatePanel>
               </td>
            </tr>
        </table>                    
    
        <hr />
    
        <p>
            <asp:Button runat="server" ID="hiddenTargetControlForModalPopup" style="display:none"/>


        <asp:UpdatePanel runat="server" ID="DialogBoxUpdatePanel" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Button runat="server" ID="btnEditText" Text="Edit text" OnClick="btnEditText_Click" />
            </ContentTemplate>
        </asp:UpdatePanel>

        </p> 
    
        <!-- Dialog box:: Edit customer info -->
        <asp:Panel ID="pnlEditCustomer" runat="server" CssClass="modalPopup" style="display:none">
            <div style="margin:10px">
            <asp:UpdatePanel runat="server" ID="ModalPanel1" RenderMode="Inline" UpdateMode="Conditional"> 
                <ContentTemplate>
                <table>            
                    <tr>
                        <td><b>Customer ID:</b></td>
                        <td>
                            <asp:Label runat="server" id="editCustomerID" />
                        </td>
                    </tr>            
                    <tr>
                        <td><b>Company Name:</b></td>
                        <td>
                                <asp:TextBox runat="server" id="editTxtCompanyName" /></td>
                    </tr>
                    <tr>
                        <td><b>Contact Name:</b></td>
                        <td>
                                <asp:TextBox runat="server" id="editTxtContactName" /></td>
                    </tr>
                    <tr>
                        <td><b>Country:</b></td>
                        <td>
                                <asp:TextBox runat="server" id="editTxtCountry" /></td>
                        </td>
                    </tr>
                </table>   
                <hr />
                <asp:Button ID="btnApply" runat="server" Text="Apply" width="50px" OnClick="btnApply_Click" />
                </ContentTemplate>
                </asp:UpdatePanel>              
                <asp:Button ID="editBox_OK" runat="server" Text="OK" width="50px" OnClick="editBox_OK_Click" />
                <asp:Button ID="editBox_Cancel" runat="server" Text="Cancel" width="50px"  />
            </div>
        </asp:Panel>
             
        
        
        <act:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  
            TargetControlID="hiddenTargetControlForModalPopup"
            PopupControlID="pnlEditCustomer"
            BackgroundCssClass="modalBackground"
            DropShadow="false"
            OkControlID="editBox_OK"
            OnOkScript="ok()"
            OnCancelScript="cancel()"
            CancelControlID="editBox_Cancel" /> 

<%-- 
      
         --%>
    </form>
</body>
</html>
