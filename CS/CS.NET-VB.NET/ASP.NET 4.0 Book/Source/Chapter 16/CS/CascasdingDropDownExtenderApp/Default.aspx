<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Import Namespace="System.Web.Services" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script runat="server"  language="C#">
	 [WebMethod]   
	[System.Web.Script.Services.ScriptMethod]
    
	public static CascadingDropDownNameValue[] getTeams(string knownCategoryValues, string category)
	{
		return new CascadingDropDownNameValue[] 
		{
			new CascadingDropDownNameValue("Oorja", "Oorja"),
			new CascadingDropDownNameValue("Lords of Might & Magic", "Lords of Might  & Magic"),
			new CascadingDropDownNameValue("Master Minds", "Master Minds")
		};
	}
    [WebMethod] 
	[System.Web.Script.Services.ScriptMethod]                  
	public static CascadingDropDownNameValue[] getProjects(string knownCategoryValues,string category)
	{
		if(knownCategoryValues.Contains("Oorja"))
		{
		return new CascadingDropDownNameValue[]{
		new CascadingDropDownNameValue("Visual Studio 2005", "Visual Studio 2005"),
		new CascadingDropDownNameValue("Visual Studio 2008", "Visual Studio 2008"),
		new CascadingDropDownNameValue("Microsoft Office 2007", "Microsft Office 2007"),
		new CascadingDropDownNameValue("Autodesk 3Ds Max 2008", "Autodesk 3Ds Max 2008"),
		new CascadingDropDownNameValue("Sony Sound Forge 9.0", "Sony Sound Forge 9.0") 
		}; 
		}
		else if (knownCategoryValues.Contains("Might & Magic"))
		{
		return new CascadingDropDownNameValue[]
		{
			new CascadingDropDownNameValue("Flash CS3", "Flash CS3"),
			new CascadingDropDownNameValue("Dreamweaver CS3", "Dreamweaver CS3"),
			new CascadingDropDownNameValue("Tally 9", "Tally 9"),
			new CascadingDropDownNameValue("InDesign CS3", "InDesign CS3"),
			new CascadingDropDownNameValue("Windows Vista with Office 2007", "Windows Vista with Office 2007")
		};
		}
		else if (knownCategoryValues.Contains("Master Minds"))
		{ 
		return new CascadingDropDownNameValue[]
		{
			new CascadingDropDownNameValue("ASP.NETBlackBook","ASP.NETBlackBook"),
			new CascadingDropDownNameValue("JDBC & Web Programming", "JDBC & Web Programming"),
			new CascadingDropDownNameValue("Struts 2.0", "Struts 2.0"),
			new CascadingDropDownNameValue("Java 6", "Java 6"),
			new CascadingDropDownNameValue("Java EE 5", "Java EE 5")                   
		};
		}
		else
		{
			return null;
		}      
	} 
	</script>

</head>
<body>
    <form id="form1" runat="server">
    
   <h3> Select the respective team to view its project details</h3>
		
        <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
        </ajaxToolkit:ToolkitScriptManager>
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
		<ajaxToolkit:CascadingDropDown ID="CascadingDropDown1" runat="server" TargetControlID="DropDownList1" PromptText="Select a team" Category="team" 
 		  LoadingText="Loading Team" ServiceMethod="getTeams">
		</ajaxToolkit:CascadingDropDown>
		<ajaxToolkit:CascadingDropDown ID="CascadingDropDown2" runat="server"  TargetControlID="DropDownList2" ParentControlID="DropDownList1" 
 		  PromptText="Select Projects" Category="projects" LoadingText="Loading Projects" ServiceMethod="getProjects">
		</ajaxToolkit:CascadingDropDown>

    </div>
    </form>
</body>
</html>
