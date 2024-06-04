<%@ Page Language="C#" AutoEventWireup="true"  CodeFile="Default.aspx.cs" Inherits="_Default"%>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Localize a DatePicker</title>
    <link href="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/themes/ui-lightness/jquery-ui.css" rel="stylesheet" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1.4.2/jquery.min.js"
    type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/jquery-ui.min.js"
    type="text/javascript"></script>
    <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8.1/i18n/jquery-ui-i18n.min.js"
    type="text/javascript"></script>
    <script type="text/javascript">
        $(function() {
        $.datepicker.setDefaults($.datepicker.regional['']);
        $("#datepicker").datepicker($.datepicker.regional['en']);
            $("#ddl").change(function() {
                $('#datepicker').datepicker('option', $.datepicker.regional[$(this).val()]);
            });
        });
	</script>
</head>
<body>
    <form id="form1" runat="server">
    <div>    
        <asp:Label ID="lblDate" runat="server" Text="Date: "></asp:Label>
        <asp:TextBox ID="datepicker" runat="server"></asp:TextBox>  
        
        <asp:DropDownList
            id="ddl"
            AppendDataBoundItems="true"            
            DataTextField="DisplayName"
            DataValueField="Name"
            DataSourceID="odsCulture" runat="server">
            <asp:ListItem Value="">Please select a Language</asp:ListItem>
        </asp:DropDownList>

        <asp:ObjectDataSource
            id="odsCulture"
            TypeName="System.Globalization.CultureInfo"
            SelectMethod="GetCultures"
            Runat="server">
            <SelectParameters>
             <asp:Parameter Name="types" DefaultValue="NeutralCultures" />
            </SelectParameters>
        </asp:ObjectDataSource>  
    </div>
    </form>
</body>
</html>
