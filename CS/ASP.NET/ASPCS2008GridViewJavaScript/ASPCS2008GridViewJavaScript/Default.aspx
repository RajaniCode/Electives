<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ASPCS2008GridViewJavaScript._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Untitled Page</title>
    <script type="text/javascript" language="javascript">
function ColorRow(CheckBoxObj)
{   
    if (CheckBoxObj.checked == true) {
    CheckBoxObj.parentElement.parentElement.style.backgroundColor='#88AAFF';
    }
    else
    {
    CheckBoxObj.parentElement.parentElement.style.backgroundColor='#FFFFFF';
    }
}
 
function ShowHideField(DecisionControl, ToggleControl)
{   
    var DecisionValue = getRadioSelectedValue(DecisionControl);
   if (DecisionValue =='True') 
    {
        ToggleControl.style.visibility='visible';
    }
    else
    {
        ToggleControl.style.visibility='hidden';
    }     
}   

function getRadioSelectedValue(radioList){
var options = radioList.getElementsByTagName('input');
for(i=0;i<options.length;i++){
var opt = options[i];
if(opt.checked){
return opt.value;
}
}
}

</script>

</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:TemplateField >
                    <ItemTemplate>
                        <asp:CheckBox ID="CheckMark" runat="server"></asp:CheckBox>
                    </ItemTemplate>
                    
                </asp:TemplateField>
                <asp:TemplateField HeaderText="ProductId">
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("ProductId") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="ProductName">
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("ProductName") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="UnitPrice">
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("UnitPrice") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField >
                 <asp:TemplateField HeaderText="UnitsinStock">
                    <ItemTemplate>
                        <asp:Label  ID="TextUnitsInStock" runat="server" Text='<%# Bind("UnitsinStock") %>' ></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Discontinued">
                   
                    <ItemTemplate>
                        <asp:RadioButtonList ID="rblDiscontinued" Text ='<%# Bind("Discontinued") %>' runat="server" >
                            <asp:ListItem Value="True"  >Yes</asp:ListItem> 
                            <asp:ListItem Value="False" >No</asp:ListItem>
                        </asp:RadioButtonList>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Reason to discontinue?">
                    <ItemTemplate>
                        <asp:TextBox  ID="ReasonDiscontinue" runat="server" Text='<%# Bind("reason") %>' ></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>

