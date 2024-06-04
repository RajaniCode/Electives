<!-- _lcid="1033" _version="11.0.5529" _dal="1" -->
<!-- _LocalBinding -->
<%@ Page language="C#"    Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=11.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<html dir="ltr">
<HEAD>
    <META Name="GENERATOR" Content="Microsoft SharePoint">
    <META Name="ProgId" Content="SharePoint.WebPartPage.Document">
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
    <META HTTP-EQUIV="Expires" content="0">
     
     <Title ID=onetidTitle><SharePoint:ListProperty Property="Title" runat="server"/> Explorer View</Title>
<script src="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/owsbrows.js"></script>
<Link REL="stylesheet" Type="text/css" HREF="/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/styles/ows.css">
    <!--mstheme--><SharePoint:Theme runat="server"/>
    <META Name="Microsoft Theme" Content="default">
    <META Name="Microsoft Border" Content="none">
<script><!--
if (browseris.mac && !browseris.ie5up)
{
    var ms_maccssfpfixup = "/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/styles/owsmac.css";
    document.write("<link rel='stylesheet' Type='text/css' href='" + ms_maccssfpfixup + "'>");
}
//--></script>
    <STYLE>
    .ms-httpFolder {behavior: url("#default#httpFolder");}
    </STYLE>
</HEAD>
<BODY onload="navtoframe()" marginwidth=0 marginheight=0 scroll="yes">
    <TABLE class="ms-main" CELLPADDING=0 CELLSPACING=0 BORDER=0 WIDTH="100%" HEIGHT="100%">
    <form runat="server">
    <!-- Banner -->
<TR> 
  <TD COLSPAN=3 WIDTH=100%>
  <!--Top bar-->
  <table class="ms-bannerframe" border="0" cellspacing="0" cellpadding="0" width="100%">
   <tr>
    <td nowrap valign="middle"><img ID=onetidHeadbnnr0 alt="Logo" src="/_layouts/images/logo.gif"></td>
      <td class=ms-banner width=99% nowrap ID="HBN100" valign="middle">
       <!--webbot bot="Navigation" 
                S-Type="sequence" 
                S-Orientation="horizontal" 
                S-Rendering="html" 
                S-Btn-Nml="<a ID='onettopnavbar#LABEL_ID#' href='#URL#' accesskey='J'>#LABEL#</a>"
                S-Btn-Sel="<a ID='onettopnavbar#LABEL_ID#' href='#URL#' accesskey='J'>#LABEL#</a>"
                S-Btn-Sep="&amp;nbsp;&amp;nbsp;&amp;nbsp;"
                B-Include-Home="FALSE" 
                B-Include-Up="FALSE" 
                S-Btn-Nobr="FALSE" 
                U-Page="sid:1002"
                S-Target startspan -->
<SharePoint:Navigation LinkBarId="1002" runat="server"/>
<!--webbot bot="Navigation" endspan -->
     </td>
    <td class=ms-banner>&nbsp;&nbsp;</td>
    <td nowrap class=ms-banner style="padding-right: 7px">
        <SharePoint:PortalConnection runat="server" />
    </td>
   </tr>
  </table>
  </TD> 
 </TR>
    <tr> <td colspan=3 class="ms-titleareaframe"> <div class="ms-titleareaframe"> <table width=100% border=0 class="ms-titleareaframe" cellpadding=0 cellspacing=0> <tr> <td style="padding-bottom: 0px"> <table style="padding-top: 0px;padding-left: 2px" cellpadding=0 cellspacing=0 border=0> <tr> <td align=center nowrap style="padding-top: 4px" width="108" height="46"> <img ID=onetidtpweb1 src="/_layouts/images/dlicon.gif" alt="Icon" height="49" width="49"> </td> <td><IMG SRC="/_layouts/images/blank.gif" width=22 height=1 alt=""></td> <td nowrap width="100%" style="padding-top: 0px"> <table cellpadding=0 cellspacing=0> <tr> <td nowrap class="ms-titlearea"> <SharePoint:ProjectProperty Property="Title" runat="server"/> </td> </tr> <tr> <td ID=onetidPageTitle class="ms-pagetitle"><SharePoint:ListProperty Property="Title" runat="server"/><!-- --></td> </tr> </table> </td>  </tr> </table> <table cellpadding=0 cellspacing=0 border=0 width=100%> <tr> <td class="ms-titlearealine" height=1 colspan=5><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td> </tr> </table> </td> </tr> </table> </div> </td> </tr>
    <!-- Navigation -->
<TR> <TD valign=top height=100% class=ms-nav> <TABLE style="padding-top: 8px" class=ms-navframe CELLPADDING=0 CELLSPACING=0 BORDER=0 width=100%> <TR> <TD valign=top width=4px><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD> <TD valign=top ID=onetidSelectView class=ms-viewselect> <TABLE style="margin-left: 3px" width=115px cellpadding=0 cellspacing=2 BORDER=0> <TR><TD width=100% ID="L_SelectView">Select a View</TD></TR> <TR><TD class="ms-navline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD></TR> </TABLE> <SharePoint:ViewSelector runat="server"/> &nbsp; </TD> <TD style="padding-right: 2px;" class=ms-verticaldots>&nbsp;</TD> </TR> </TABLE> <TABLE style="padding-top: 8px" class=ms-navframe CELLPADDING=0 CELLSPACING=0 BORDER=0 width=100% height=100%> <TR> <TD valign=top width=4px><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD> <TD valign=top ID=onetidSelectView class=ms-viewselect> <SharePoint:RelatedTasks runat="server"/> &nbsp; </TD> <TD style="padding-right: 2px;" class=ms-verticaldots>&nbsp;</TD> </TR> </TABLE> </TD>
    <!-- Contents -->
    <TD><IMG SRC="/_layouts/images/blank.gif" width=3 height=1 alt=""></TD> <TD width="100%" height="100%"><PlaceHolder id="MSO_ContentDiv" runat="server"> <table cellpadding=2 cellspacing=0><tr><td><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td></tr></table><table cellpadding="4" cellspacing="0" border="0" class="ms-bodyareaframe" width="100%"><tr valign=top><td width="100%" style="padding-top: 3px;padding-right: 10px">
  <TABLE width=100% cellpadding=2 cellspacing=0 border=0>
   <tr>
    <td valign=top class="ms-descriptiontext" style="padding-bottom: 10px"><SharePoint:ListProperty Property="Description" runat="server"/></td>
   </tr>
  </TABLE>
		<WebPartPages:WebPartZone runat="server" FrameType="None" ID="Main" Title="loc:Main" />
        <!-- FooterBanner closes the TD, TR, TABLE, BODY, And HTML regions opened above -->
&nbsp;
    </td></tr></table></PlaceHolder></TD></TR>
    </form>
    </TABLE>
</BODY>
</HTML>
