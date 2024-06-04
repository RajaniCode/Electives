<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Import Namespace="System.Web.Services" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register
    Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server"  language="VB">
        <WebMethod()> _
   <System.Web.Script.Services.ScriptMethod()> _
        Public Shared Function getTeams(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
            Return New CascadingDropDownNameValue() {New CascadingDropDownNameValue("Oorja", "Oorja"), New CascadingDropDownNameValue("Lords of Might & Magic", "Lords of Might & Magic"), New CascadingDropDownNameValue("Master Minds", "Master Minds")}
        End Function
        <WebMethod()> _
        <System.Web.Script.Services.ScriptMethod()> _
        Public Shared Function getProjects(ByVal knownCategoryValues As String, ByVal category As String) As CascadingDropDownNameValue()
            If knownCategoryValues.Contains("Oorja") Then
                Return New CascadingDropDownNameValue() {New CascadingDropDownNameValue("ASP.NET BLACKBOOK", "Visual Studio 2010"), New CascadingDropDownNameValue("Visual Studio 2008", "Visual Studio 2008"), New CascadingDropDownNameValue("Microsoft Office 2007", "Microsft Office 2007"), New CascadingDropDownNameValue("Autodesk 3Ds Max 2008", "Autodesk 3Ds Max 2008"), New CascadingDropDownNameValue("Sony Sound Forge 9.0", "Sony Sound Forge 9.0")}
            ElseIf knownCategoryValues.Contains("Might & Magic") Then
                Return New CascadingDropDownNameValue() {New CascadingDropDownNameValue("Flash CS3",
                   "Flash CS3"), New CascadingDropDownNameValue("Dreamweaver CS3", "Dreamweaver CS3"),
                   New CascadingDropDownNameValue("Tally 9", "Tally 9"), New CascadingDropDownNameValue("InDesign CS3", "InDesign CS3"), New CascadingDropDownNameValue("Windows Vista with Office 2007", "Windows Vista with Office 2007")}
            ElseIf knownCategoryValues.Contains("Master Minds") Then
                Return New CascadingDropDownNameValue() {New CascadingDropDownNameValue("ASP.NET BLACKBOOK", "ASP.NET BLACKBOOK"), New CascadingDropDownNameValue("JDBC & Web Programming", "JDBC & Web Programming"), New CascadingDropDownNameValue("Struts 2.0", "Struts 2.0"), New CascadingDropDownNameValue("Java 6", "Java 6"), New CascadingDropDownNameValue("Java EE 5", "Java EE 5")}
            Else
                Return Nothing
            End If
        End Function

</script>
</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>

    Select the respective team to view its project details
	
		<div> 
Team&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp; 
Projects&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		<br />
		<asp:DropDownList ID="DropDownList1" runat="server" Width="200">
		</asp:DropDownList>
		<asp:DropDownList ID="DropDownList2" runat="server" Width="200">
		</asp:DropDownList><br /><br />
		<ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" 
 		  TargetControlID="DropDownList1" PromptText="Select a team" Category="team" 
 		  LoadingText="Loading Team" ServiceMethod="getTeams">
		</ajaxToolkit:CascadingDropDown>
		<ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server" 
 		  TargetControlID="DropDownList2" ParentControlID="DropDownList1" 
 		  PromptText="Select Projects" Category="projects" LoadingText="Loading Projects" 
 		  ServiceMethod="getProjects">
		</ajaxToolkit:CascadingDropDown>

    </div>
    </form>
</body>
</html>
