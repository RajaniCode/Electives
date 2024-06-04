<!-- _lcid="1033" _version="11.0.5529" _dal="1" -->
<!-- _LocalBinding -->
<%@ Page language="C#" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=11.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<html dir="ltr" xmlns:o="urn:schemas-microsoft-com:office:office">
<HEAD>
    <META Name="GENERATOR" Content="Microsoft SharePoint">
    <META Name="ProgId" Content="SharePoint.WebPartPage.Document">
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
    <META HTTP-EQUIV="Expires" content="0">
     
     <Title ID=onetidTitle><SharePoint:ListProperty Property="Title" runat="server"/></Title>
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
<link type="text/xml" rel='alternate' href="_vti_bin/spdisco.aspx" />
<script language='javascript' src='/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/BAS/BAS.js'></script>
</HEAD>
<BODY marginwidth=0 marginheight=0 scroll="yes">
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
    <tr> <td colspan=3 class="ms-titleareaframe"> <div class="ms-titleareaframe"> <table width=100% border=0 class="ms-titleareaframe" cellpadding=0 cellspacing=0> <tr> <td style="padding-bottom: 0px"> <table style="padding-top: 0px;padding-left: 2px" cellpadding=0 cellspacing=0 border=0> <tr> <td align=center nowrap style="padding-top: 4px" width="108" height="46"> <img ID=onetidtpweb1 src="/_layouts/images/generic.gif" alt="Icon" height="49" width="49"> </td> <td><IMG SRC="/_layouts/images/blank.gif" width=22 height=1 alt=""></td> <td nowrap width="100%" style="padding-top: 0px"> <table cellpadding=0 cellspacing=0> <tr> <td nowrap class="ms-titlearea"> <SharePoint:ProjectProperty Property="Title" runat="server"/> </td> </tr> <tr> <td ID=onetidPageTitle class="ms-pagetitle"><SharePoint:ListProperty Property="Title" runat="server"/><!-- --></td> </tr> </table> </td> <td align=right valign=top> <table cellpadding=0 cellspacing=0 height=100%> <tr> <SharePoint:ViewSearchForm ID="L_SearchView" Prompt="Search this view" Go="Go"  runat="server"/> </tr> <tr style="padding-right:1px"><td colspan=5 nowrap style="padding-bottom: 3px; padding-top: 1px; vertical-align: bottom" align=right class="ms-vb"> <span class='ms-SPLink'> <span class='ms-HoverCellInActive' onmouseover="this.className='ms-HoverCellActive'"; onmouseout="this.className='ms-HoverCellInActive'">  </span> </span>  &nbsp; </td></tr> </table> </td> </tr> </table> <table cellpadding=0 cellspacing=0 border=0 width=100%> <tr> <td class="ms-titlearealine" height=1 colspan=5><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td> </tr> </table> </td> </tr> </table> </div> </td> </tr>
    <!-- Navigation -->
<TR> <TD id="webpartpagenavbar" valign=top height=100% class=ms-nav> <TABLE style="padding-top: 8px" class=ms-navframe CELLPADDING=0 CELLSPACING=0 BORDER=0 width=100%> <TR> <TD valign=top width=4px><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD> <TD valign=top ID=onetidSelectView class=ms-viewselect> <TABLE style="margin-left: 3px" width=115px cellpadding=0 cellspacing=2 BORDER=0> <TR><TD width=100% ID="L_SelectView">Select a View</TD></TR> <TR><TD class="ms-navline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD></TR> </TABLE> <SharePoint:ViewSelector runat="server"/> &nbsp; </TD> <TD style="padding-right: 2px;" class=ms-verticaldots>&nbsp;</TD> </TR> </TABLE> <TABLE style="padding-top: 8px" class=ms-navframe CELLPADDING=0 CELLSPACING=0 BORDER=0 width=100%> <TR> <TD valign=top width=4px><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></TD> <TD valign=top ID=onetidSelectView class=ms-viewselect> <SharePoint:RelatedTasks runat="server"/> &nbsp; </TD> <TD style="padding-right: 2px;" class=ms-verticaldots>&nbsp;</TD> </TR> </TABLE> 
   <table height=100% border=0 cellpadding=2 cellspacing=0 class=ms-navframe>
    <tr>
     <td valign=top id="onetidWatermark" class="ms-navwatermark" style="padding-top: 4px;padding-right: 0px;">
      <!--[if gte vml 1]><v:shapetype id="_x0000_t136"
      coordsize="21600,21600" o:spt="136" adj="10800" path="m@7,l@8,m@5,21600l@6,21600e">
      <v:formulas>
       <v:f eqn="sum #0 0 10800"/>
       <v:f eqn="prod #0 2 1"/>
       <v:f eqn="sum 21600 0 @1"/>
       <v:f eqn="sum 0 0 @2"/>
       <v:f eqn="sum 21600 0 @3"/>
       <v:f eqn="if @0 @3 0"/>
       <v:f eqn="if @0 21600 @1"/>
       <v:f eqn="if @0 0 @2"/>
       <v:f eqn="if @0 @4 21600"/>
       <v:f eqn="mid @5 @6"/>
       <v:f eqn="mid @8 @5"/>
       <v:f eqn="mid @7 @8"/>
       <v:f eqn="mid @6 @7"/>
       <v:f eqn="sum @6 0 @5"/>
      </v:formulas>
      <v:path textpathok="t" o:connecttype="custom" o:connectlocs="@9,0;@10,10800;@11,21600;@12,10800"
      o:connectangles="270,180,90,0"/>
      <v:textpath on="t" fitshape="t"/>
      <v:handles>
       <v:h position="#0,bottomRight" xrange="6629,14971"/>
      </v:handles>
      <o:lock v:ext="edit" text="t" shapetype="t"/>
      </v:shapetype>
      <v:shape id="navWatermark" type="#_x0000_t136" style='width:139pt;
       height:17.25pt;rotation:-90' fillcolor="#cbdbf8;" stroked="f">
      <v:textpath style='font-family:"Arial";font-size:18pt;font-weight:bold;
       v-text-spacing:2;v-text-spacing-mode:tightening' string="Quick Launch"/>
      </v:shape><![endif]-->
      <script>
       if (browseris.ie5up && document.all("navWatermark") && document.all("onetidWatermark")) { 
        document.all("navWatermark").fillcolor=document.all("onetidWatermark").currentStyle.color;
       } 
     </script>
     </td>
     <td valign=top style="padding-top: 0px;padding-right: 0px;padding-left: 0px"> 
      <TABLE CELLPADDING=1 cellspacing=0 BORDER=0 width=126px style="margin-right: 3px">
     <!-- Business Activity Services start -->
   <TR><TD class="ms-viewselect"><TABLE style="margin-left: 3px" width=115px cellpadding=0 cellspacing=2 BORDER=0> <TR><TD width=100% ><SPAN>Trading Partner Management Tools</SPAN></TD></TR></TABLE></TD></TR>
<TR><TD class="ms-navline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1></TD></TR>
 <tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('1');javascript:return false;">My Profiles</A></td> </tr> </table> </td> </tr></table></td> </tr>
 <tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('2');javascript:return false;">Partner Profiles</A></td> </tr> </table> </td> </tr></table></td> </tr>
 <tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('3');javascript:return false;">Partner Groups</A></td> </tr> </table> </td> </tr></table></td> </tr>
 <tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('4');javascript:return false;">Agreements</A></td> </tr> </table> </td> </tr></table></td> </tr>
  <tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('5');javascript:return false;">BizTalk Servers</A></td> </tr> </table> </td> </tr></table></td> </tr>
 
   <TR><TD style="padding-top:12px;padding-left:0px;padding-right:0px"><img width=1px src='/_layouts/images/blank.gif' ID='100' alt='Icon' border=0></TD></TR>
       
    <TR><TD class="ms-viewselect"><TABLE style="margin-left: 3px" width=115px cellpadding=0 cellspacing=2 BORDER=0> <TR><TD width=100% ><SPAN>Business Process Management</SPAN></TD></TR></TABLE></TD></TR>
<TR><TD class="ms-navline"><IMG SRC="/_layouts/images/blank.gif" width=1 height=1></TD></TR>
 <tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('6');javascript:return false;">Business Processes</A></td> </tr> </table> </td> </tr></table></td> </tr>
<tr> <td style="padding-left: 8px;padding-bottom: 2px" width=100%> <table border=0 cellpadding=0 cellspacing=0 width=100%><tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> <img src="/_layouts/images/rect.gif">&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('7');javascript:return false;">Shared Links</A></td> </tr> </table> </td> </tr></table></td> </tr>

      <!-- Business Activity Services end -->
       <TR><TD style="padding-left:0px;padding-right:0px"><img width=1px src='/_layouts/images/blank.gif' ID='100' alt='Icon' border=0></TD></TR>
      </table>
     </td>
    </tr>
   </table>
</TD>
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
    <SCRIPT language='javascript'>
		ModifyLinkValue("Member");
    </SCRIPT>
    </form>
    </TABLE>
</BODY>
</HTML>
