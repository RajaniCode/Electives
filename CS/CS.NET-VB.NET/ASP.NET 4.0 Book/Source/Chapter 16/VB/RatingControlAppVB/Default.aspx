<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
   <title>Rating Control</title> 
	<style type="text/css">
	.rateStar
	{
		white-space:nowrap;
		margin:1em;
		height:14px;
	}
	.rateItem 
	{
		font-size: 0pt;
		width: 13px;
		height: 12px;
		margin: 0px;
		padding: 0px;
		display: block;
		background-repeat: no-repeat;
		cursor:pointer;
	}
	.FillStar
	{
		background-image: url(images/FilledStar.png);
	}
	.EmptyStar 
	{
		background-image: url(images/EmptyStar.png);
	}
	.SaveStar
	{
		background-image: url(images/SavedStar.png);
	}
	</style>

</head>
<body>
    <form id="form1" runat="server">
    <ajaxToolkit:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </ajaxToolkit:ToolkitScriptManager>
    
    Click on the stars to rate the books mentioned below<br />
		<asp:Label ID="Label1" runat="server" Text="- Visual Studio 2010 Black Book"></asp:Label>
		<ajaxToolkit:Rating ID="Rating1" runat="server" CurrentRating="2" MaxRating="8" 
 		  CssClass="rateStar" StarCssClass="rateItem" WaitingStarCssClass="SaveStar" 
 		  FilledStarCssClass="FillStar" EmptyStarCssClass="EmptyStar" 
 		  AutoPostBack="true">
		</ajaxToolkit:Rating>
		<br />
		<div>
		<asp:Label ID="Label2" runat="server" Text="- ASP.NET 4.0 BlackBook"></asp:Label>
		<ajaxToolkit:Rating ID="Rating2" runat="server" CurrentRating="2" MaxRating="8" 
		CssClass="rateStar" StarCssClass="rateItem" WaitingStarCssClass="SaveStar" 
		FilledStarCssClass="FillStar" EmptyStarCssClass="EmptyStar" AutoPostBack="true">
		</ajaxToolkit:Rating>

    </div>
    </form>
   
</body>
</html>
