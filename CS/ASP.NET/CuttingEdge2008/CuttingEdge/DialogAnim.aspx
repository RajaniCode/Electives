<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DialogAnim.aspx.cs" Inherits="DialogAnim" %>
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
       
function pageLoad(sender, args) 
{
    $addHandler(document, "keydown", OnKeyPress);
    $find("ModalPopupExtender1").add_showing(onModalShowing);
}

function onModalShowing(sender, args)
{
    $get("pnlViewCustomer").style.backgroundColor = "yellow";
    
    $get("Country").innerHTML = $get("lblCountry").innerHTML;
}

function OnKeyPress(args)
{
    if(args.keyCode == Sys.UI.Key.esc)
    {
        $find("ModalPopupExtender1").hide();
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
                        OnDataBound="ddlCustomers_DataBound" />
                    <asp:ObjectDataSource ID="odsCustomers" runat="server"
                        TypeName="IntroAjax.CustomerManager"
                        SelectMethod="LoadAll">
                    </asp:ObjectDataSource>
                </td>
                <td valign="top">
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
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
                        </Triggers>  
                    </asp:UpdatePanel>
               </td>
            </tr>
        </table>                    
    
        <hr />
    
        <asp:Button runat="server" ID="btnViewMore" Text="More" />
    
        <!-- Dialog box:: Customer info -->
        <asp:Panel ID="pnlViewCustomer" runat="server" CssClass="modalPopup" style="display:none;"> 
            <div style="margin:10px">
                <h1>The service is not available in <span id="Country"></span>.</h1>
                <asp:Button runat="server" ID="viewBox_OK" Text="OK" />
            </div>
        </asp:Panel> 
              
 
        <act:ModalPopupExtender ID="ModalPopupExtender1" runat="server"  
            TargetControlID="btnViewMore" Drag ="true" RepositionMode="RepositionOnWindowResize"
            PopupDragHandleControlID="pnlViewCustomer"  
            PopupControlID="pnlViewCustomer"
            BackgroundCssClass="modalBackground"
            DropShadow="false"
            OkControlID="viewBox_OK">
        </act:ModalPopupExtender> 
       
        <act:AnimationExtender ID="openAnimation" runat="server" TargetControlID="btnViewMore">
            <Animations>
                <OnClick>
                    <Parallel AnimationTarget="pnlViewCustomer" Duration=".3" Fps="25">
                        <FadeIn />
                    </Parallel>
                </OnClick>
            </Animations>
         </act:AnimationExtender>           
    </form>
</body>
</html>
