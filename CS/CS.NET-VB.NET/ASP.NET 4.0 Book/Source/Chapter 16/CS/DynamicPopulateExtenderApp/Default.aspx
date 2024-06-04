<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server">
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod]
    public static string GetHtml(string contextKey)
    {
        
        System.Threading.Thread.Sleep(250);

        string value = (contextKey == "U") ?
            DateTime.UtcNow.ToString() :
            String.Format("{0:" + contextKey + "}", DateTime.Now);
        return String.Format("<span style='font-family:courier new;font-weight:bold;'>{0}</span>", value);
    }
</script>
 <script  type="text/javascript">
     function updateDateKey(value) {
         var behavior = $find('dp1');
         if (behavior) {
             behavior.populate(value);
         }
     }   
  
 </script>
</head>
<body onload="updateDateKey('G')">
    <form id="form1" runat="server">
    <div>
    <p><ajaxToolkit:ToolkitScriptManager runat="server"></ajaxToolkit:ToolkitScriptManager>
        </p>
        <p>Click the date/time format Button:</p>

            <label for="r0"><input type="radio" name="rbFormat" id="r0" value='G'
                onclick="updateDateKey(this.value);" checked="checked" />Normal</label><br />
            <label for="r1"><input type="radio" name="rbFormat" id="r1" value='d'
                onclick="updateDateKey(this.value);" />Short Date</label><br />
            <label for="r2"><input type="radio" name="rbFormat" id="r2" value='D'
                onclick="updateDateKey(this.value);" />Long Date</label><br />
            <label for="r3"><input type="radio" name="rbFormat" id="r3" value='U'
                onclick="updateDateKey(this.value);" />UTC Date/Time</label><br />
                 <ajaxToolkit:DynamicPopulateExtender ID="dp" BehaviorID="dp1" runat="server"
            TargetControlID="Panel1"
            ClearContentsDuringUpdate="true"
            PopulateTriggerControlID="Label1"
            ServiceMethod="GetHtml"/>
            <br />
            <br />
             <h3> The current date/time in selected formatted is displayed.</h3>
            <asp:Panel ID="Panel1" runat="server" CssClass="dynamicPopulate_Normal" />
        
    </div>
    </form>
</body>
</html>
