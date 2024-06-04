<!-- _lcid="1033" _version="11.0.5529" _dal="1" -->
<!-- _LocalBinding -->
<%@ Page language="C#" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage,Microsoft.SharePoint,Version=11.0.0.0,Culture=neutral,PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> <%@ Import Namespace="Microsoft.SharePoint" %> <%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<html dir="ltr" xmlns:v="urn:schemas-microsoft-com:vml" xmlns:o="urn:schemas-microsoft-com:office:office">
<HEAD>
    <META Name="GENERATOR" Content="Microsoft SharePoint">
    <META Name="ProgId" Content="SharePoint.WebPartPage.Document">
    <META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
    <META Name="CollaborationServer" Content="SharePoint Team Web Site">
    <META HTTP-EQUIV="Expires" content="0">
     
     <Title ID=onetidTitle>Home - <SharePoint:ProjectProperty Property="Title" runat="server"/></Title>
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
<style>
v\:*         { behavior: url(#default#VML) }
o\:*         { behavior: url(#default#VML) }
.shape       { behavior: url(#default#VML) }
</style>
<link type="text/xml" rel='alternate' href="_vti_bin/spdisco.aspx" />
<script language='javascript' src='/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/BAS/BAS.js'></script>
</HEAD>
<body marginwidth="0" marginheight="0" scroll="yes">
<script>
var navBarHelpOverrideKey = "wssmain";
</script>
<table class="ms-main" cellpadding="0" cellspacing="0" border="0" width="100%" height="100%">
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
  <!-- Title -->
    <tr> <td colspan=3 class="ms-titleareaframe"> <div class="ms-titleareaframe"> <table width=100% border=0 class="ms-titleareaframe" cellpadding=0 cellspacing=0> <tr> <td style="padding-bottom: 0px"> <table style="padding-top: 0px;padding-left: 2px" cellpadding=0 cellspacing=0 border=0> <tr> <td align=center nowrap style="padding-top: 4px" width="132" height="46"> <img ID=onetidtpweb1 src="/_layouts/images/BAS/home.gif" alt="Icon" height="49" width="49"> </td> <td><IMG SRC="/_layouts/images/blank.gif" width=22 height=1 alt=""></td> <td nowrap width="100%" style="padding-top: 0px"> <table cellpadding=0 cellspacing=0> <tr> <td nowrap class="ms-titlearea"> <SharePoint:ProjectProperty Property="Title" runat="server"/> </td> </tr> <tr> <td ID=onetidPageTitle class="ms-pagetitle">Home<!-- --></td> </tr> </table> </td> <td align=right valign=top> <table cellpadding=0 cellspacing=0 height=100%> <tr> <SharePoint:ViewSearchForm ID="L_SearchView" Prompt="Search this site" Go="Go" Action="searchresults.aspx" runat="server"/> </tr> <tr style="padding-right:1px"><td colspan=5 nowrap style="padding-bottom: 3px; padding-top: 1px; vertical-align: bottom" align=right class="ms-vb"> <span class='ms-SPLink'> <span class='ms-HoverCellInActive' onmouseover="this.className='ms-HoverCellActive'"; onmouseout="this.className='ms-HoverCellInActive'"> <WebPartPages:SettingsLink runat="server"/> </span> </span> <WebPartPages:AuthenticationButton runat="server"/> &nbsp; </td></tr> </table> </td> </tr> </table> <table cellpadding=0 cellspacing=0 border=0 width=100%> <tr> <td class="ms-titlearealine" height=1 colspan=5><IMG SRC="/_layouts/images/blank.gif" width=1 height=1 alt=""></td> </tr> </table> </td> </tr> </table> </div> </td> </tr>
  <tr valign=top height=100%>
  <!-- Navigation -->
<TD id="webpartpagenavbar" widthchange="175" height=100% class=ms-nav>
   <table height=100% border=0 cellpadding=2 cellspacing=0 class=ms-navframe>
    <tr>
     <td valign=top id="onetidWatermark" class="ms-navwatermark" style="padding-top: 4px;padding-right: 0px;" dir="ltr">
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
     <td valign=top style="padding-top: 8px;padding-right: 0px;padding-left: 0px"> 
      <TABLE CELLPADDING=1 cellspacing=0 BORDER=0 width=126px style="margin-right: 3px">
      <!-- Business Activity Services start -->
   <TR><TD class="ms-navheader"><A HREF="_layouts/<%=System.Threading.Thread.CurrentThread.CurrentCulture.LCID%>/viewlsts.aspx?BaseType=1">Business Documents</A></TD></TR>
    <TR><TD style="height: 6px"><!--webbot bot="Navigation" S-Btn-Nobr="FALSE" S-Type="sequence" S-Rendering="html" S-Orientation="Vertical" B-Include-Home="FALSE" B-Include-Up="FALSE" U-Page="sid:1004" S-Bar-Pfx="<table border=0 cellpadding=4 cellspacing=0>" S-Bar-Sfx="</table>" S-Btn-Nml="<tr><td><table border=0 cellpadding=0 cellspacing=0><tr><td><img src='_layouts/images/blank.gif' ID='100' alt='Icon' border=0>&amp;nbsp;</td><td valign=top><a ID=onetleftnavbar#LABEL_ID# href='#URL#'>#LABEL#</td></tr></table></td></tr>" S-Target TAG="BODY" startspan --><SharePoint:Navigation LinkBarId="1004" runat="server"/><!--webbot bot="Navigation" endspan --></TD></TR>
    <TR><TD class="ms-navheader"><A style="font-weight:bold">Trading Partner Management Tools</A></TD></TR>
    
     <tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('1');javascript:return false;">My Profiles</A></td> </tr> </table> </td> </tr>
  <tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('2');javascript:return false;">Partner Profiles</A></td> </tr> </table> </td> </tr>
   <tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('3');javascript:return false;">Partner Groups</A></td> </tr> </table> </td> </tr>
    <tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('4');javascript:return false;">Agreements</A></td> </tr> </table> </td> </tr>
     <tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('5');javascript:return false;">BizTalk Servers</A></td> </tr> </table> </td> </tr>

    <TR><TD class="ms-navheader"><A style="font-weight:bold">Business Process Management</A></TD></TR>
<tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('6');javascript:return false;">Business Processes</A></td> </tr> </table> </td> </tr>
<tr> <td width=100% class="ms-unselectednav" colspan=2> <table cellpadding=0 cellspacing=0 border=0> <tr> <td valign=top> &nbsp;&nbsp;&nbsp;&nbsp; </td> <td><A HREF="JavaScript:" OnClick="JavaScript:QuickLaunch('7');javascript:return false;">Shared Links</A></td> </tr> </table> </td> </tr>
  <!-- Business Activity Services end -->
         <TR><TD style="padding-left:0px;padding-right:0px"><img width=1px src='/_layouts/images/blank.gif' ID='100' alt='Icon' border=0></TD></TR>
      </table>
     </td>
    </tr>
   </table>
  </TD>
  <!-- Contents -->
  <td><IMG SRC="/_layouts/images/blank.gif" width=5 height=1 alt=""></td>
  <td class="ms-bodyareaframe" valign="top" style="width:100%">
<form runat="server">
    <table style="margin-top: 4px" cellpadding="3" cellspacing="0" border="0" width="100%">
      <tr>
        <td class="ms-descriptiontext" valign="top" colspan=4>
          <SharePoint:ProjectProperty Property="Description" runat="server"/>
        </td>
      </tr>
      <tr>
        <!-- Middle column -->
        <td valign="top" width="70%">
	<WebPartPages:WebPartZone runat="server" FrameType="TitleBarOnly" ID="Left" Title="loc:Left" />
        &nbsp;
        </td>
        <td>&nbsp;</td>
        <!-- Right column -->
        <td valign="top" width="30%">
			<WebPartPages:WebPartZone runat="server" FrameType="TitleBarOnly" ID="Right" Title="loc:Right" />
                &nbsp;
        </td>
        <td>&nbsp;</td>
      </tr>
    </table>
    &nbsp;
    <!-- FooterBanner closes the TD, TR, TABLE, BODY, And HTML regions opened above --> 
&nbsp;
</form>
  <!-- Close the TD, TR, TABLE, BODY, And HTML from Header --></td>
  </tr>
</table>
</body>
</html>
