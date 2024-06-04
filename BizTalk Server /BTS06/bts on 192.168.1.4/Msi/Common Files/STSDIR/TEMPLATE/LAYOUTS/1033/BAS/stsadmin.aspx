<%@ Import Namespace= "Microsoft.SharePoint.ApplicationPages" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SP" Namespace="Microsoft.SharePoint" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Page Language="c#" Inherits="Microsoft.BizTalk.KwTpm.StsAdmin" CodeBehind="StsAdmin.aspx.cs" AutoEventWireup="false" %>
<HTML dir="ltr">
	<HEAD>
		<Title id="onetidTitle">
			<%=Microsoft.BizTalk.KwTpm.StsAdmin.PageTitle %>
		</Title>
		<% SPSite spServer = SPControl.GetContextSite(Context); SPWeb spWeb = SPControl.GetContextWeb(Context); %>
		<META Name="GENERATOR" Content="Microsoft SharePoint">
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<META HTTP-EQUIV="Expires" content="0">
		<script src="../owsbrows.js"></script>
		<SharePoint:CssLink DefaultUrl="../styles/ows.css" runat="server" id="CssLink1" />
		<SharePoint:Theme runat="server" id="Theme1" />
		<script><!--
if (browseris.mac && !browseris.ie5up)
{
    var ms_maccssfpfixup = "../styles/owsmac.css";
    document.write("<link rel='stylesheet' Type='text/css' href='../" + ms_maccssfpfixup + "'>");
}
//--></script>
		<script src="../ows.js"></script>
		<SCRIPT language='javascript' src='/_layouts/<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>/BAS/BAS.js'></SCRIPT>
		<script Language="javascript">

var L_Menu_LCID = "<%=System.Threading.Thread.CurrentThread.CurrentUICulture.LCID%>";
var L_Menu_BaseUrl = "<%=SPControl.GetContextWeb(Context).Url%>";

function Submit(cmd)
{
	document.forms.userfrm.action = "stsadmin.aspx?Cmd=" + cmd;
	document.forms["userfrm"].submit();
}
		</script>
	</HEAD>
	<body marginheight="0" marginwidth="0" scroll="yes">
		<table border="0" width="100%" height="100%" cellpadding="0" cellspacing="0" class="ms-main">
			<TR>
				<TD COLSPAN="3" WIDTH="100%">
					<!--Top bar-->
					<table class="ms-bannerframe" border="0" cellspacing="0" cellpadding="0" width="100%">
						<tr>
							<td nowrap valign="middle"><img ID="onetidHeadbnnr0" alt="Logo" src="../../images/logo.gif"></td>
							<td class="ms-banner" width="99%" nowrap ID="HBN100" valign="middle">
								<!--webbot Bot="Navigation" startspan-->
								<SharePoint:Navigation LinkBarId="1002" runat="server" id="Navigation1" />
							</td>
							<td class="ms-banner">&nbsp;&nbsp;</td>
							<td nowrap class="ms-banner">
								<SharePoint:PortalConnection runat="server" id="PortalConnection1" />
							</td>
						</tr>
					</table>
				</TD>
			</TR>
			<tr>
				<td colspan="3" class="ms-titleareaframe">
					<div class="ms-titleareaframe">
						<table width="100%" border="0" class="ms-titleareaframe" cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<table style="PADDING-LEFT: 2px;PADDING-TOP: 2px" cellpadding="0" cellspacing="0" border="0">
										<tr>
											<td align="center" nowrap width="105" height="46">
												<img ID="onetidtpweb1" src="../../images/settings.gif" alt="Icon"><!-- _locID@alt="onetidtpweb" _locComment="{StringCategory=ALT}" -->
											</td>
											<td><img width="22" border="0" src="../../images/blank.gif"></td>
											<td nowrap width="100%">
												<table cellpadding="0" cellspacing="0">
													<tr>
														<td nowrap class="ms-titlearea">
															<SharePoint:ProjectProperty Property="Title" runat="server" id="ProjectProperty1" />
														</td>
													</tr>
													<tr>
														<td ID="onetidPageTitle" class="ms-pagetitle"><!-- _locID_Text="KwBusinessIdGroupMgtPageTitle" _locComment="{StringCategory=HTX}" -->
															<asp:Label ID="titleLabel" Runat="server">Tpm Admininistration</asp:Label></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
									<table cellpadding="0" cellspacing="0" border="0" width="100%">
										<tr>
											<td height="2" colspan="5"><img src="../../images/blank.gif"></td>
										</tr>
										<tr>
											<td class="ms-titlearealine" height="2" colspan="5"><img src="../../images/blank.gif"></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</div>
				</td>
			</tr>
			<tr valign="top">
				<TD height="100%" class="ms-nav">
					<table height="100%" border="0" cellpadding="0" cellspacing="0" class="ms-navframe">
						<tr>
							<td valign="top" id="onetidWatermark" class="ms-navwatermark"><!--[if gte vml 1]><V:SHAPETYPE id=_x0000_t136 
            path="m@7,l@8,m@5,21600l@6,21600e" adj="10800" o:spt="136" 
            coordsize="21600,21600"><V:FORMULAS><V:F eqn="sum #0 0 10800" /><V:F 
            eqn="prod #0 2 1" /><V:F eqn="sum 21600 0 @1" /><V:F 
            eqn="sum 0 0 @2" /><V:F eqn="sum 21600 0 @3" /><V:F eqn="if @0 @3 0" 
            /><V:F eqn="if @0 21600 @1" /><V:F eqn="if @0 0 @2" /><V:F 
            eqn="if @0 @4 21600" /><V:F eqn="mid @5 @6" /><V:F eqn="mid @8 @5" 
            /><V:F eqn="mid @7 @8" /><V:F eqn="mid @6 @7" /><V:F 
            eqn="sum @6 0 @5" /></V:FORMULAS><V:PATH 
            o:connectangles="270,180,90,0" 
            o:connectlocs="@9,0;@10,10800;@11,21600;@12,10800" 
            o:connecttype="custom" textpathok="t" /><V:TEXTPATH fitshape="t" 
            on="t" /><V:HANDLES><V:H xrange="6629,14971" 
            position="#0,bottomRight" /></V:HANDLES><O:LOCK shapetype="t" 
            text="t" v:ext="edit" /></V:SHAPETYPE><V:SHAPE id=navWatermark 
            style="WIDTH: 139pt; HEIGHT: 17.25pt; rotation: -90" stroked="f" 
            fillcolor="#cbdbf8;" type="#_x0000_t136"><V:TEXTPATH 
            style="FONT-WEIGHT: bold; FONT-SIZE: 18pt; FONT-FAMILY: 'Arial'; v-text-spacing: 2; v-text-spacing-mode: tightening" 
            string="Quick Launch" /></V:SHAPE><![endif]-->
								<script>
       if (browseris.ie5up && document.all("navWatermark") && document.all("onetidWatermark")) { 
        document.all("navWatermark").fillcolor=document.all("onetidWatermark").currentStyle.color;
       } 
								</script>
							</td>
							<td valign="top"> <!-- this one modified by KWBusiness  -->
								<TABLE CELLPADDING="1" cellspacing="0" BORDER="0" width="126" style="MARGIN-RIGHT: 3px">
									<!-- KwBusiness start -->
									<TR>
										<TD class="ms-viewselect"><TABLE style="MARGIN-LEFT: 3px" width="115" cellpadding="0" cellspacing="2" BORDER="0">
												<TR>
													<TD width="100%"><SPAN><asp:Label ID="QuickLaunchTpmToolsSectionLabel" Runat="server">Trading Partner Management Tools</asp:Label>
														</SPAN></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="ms-navline"><IMG SRC="/_layouts/images/blank.gif" width="1" height="1"></TD>
									</TR>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=1"><asp:Label ID="QuickLaunchMyProfilesLinkLabel" Runat="server">My Profiles</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=2"><asp:Label ID="QuickLaunchPartnerProfilesLinkLabel" Runat="server">Partner Profiles</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=3"><asp:Label ID="QuickLaunchPartnerGroupsLinkLabel" Runat="server">Partner Groups</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=4"><asp:Label ID="QuickLaunchAgreementsLinkLabel" Runat="server">Agreements</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=5"><asp:Label ID="QuickLaunchBizTalkServersLinkLabel" Runat="server">BizTalk Servers</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<TR>
										<TD><img width="1" src='/_layouts/images/blank.gif' ID='100' alt='Icon' border="0"></TD>
									</TR>
									<TR>
										<TD class="ms-viewselect"><TABLE style="MARGIN-LEFT: 3px" width="115" cellpadding="0" cellspacing="2" BORDER="0">
												<TR>
													<TD width="100%"><SPAN><asp:Label ID="QuickLaunchBpMgmtSectionLabel" Runat="server">Business Process Management</asp:Label>
														</SPAN></TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD class="ms-navline"><IMG SRC="/_layouts/images/blank.gif" width="1" height="1"></TD>
									</TR>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=6"><asp:Label ID="QuickLaunchBizProcsLinkLabel" Runat="server">Business Processes</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<tr>
										<td width="100%">
											<table border="0" cellpadding="0" cellspacing="0" width="100%">
												<tr>
													<td width="100%" class="ms-unselectednav" colspan="2">
														<table cellpadding="0" cellspacing="0" border="0">
															<tr>
																<td valign="top">
																	<img src="/_layouts/images/rect.gif">&nbsp;
																</td>
																<td><A HREF="StsRedirect.aspx?QuickLaunch=7"><asp:Label ID="QuickLaunchSharedLinksLinkLabel" Runat="server">Shared Links</asp:Label></A></td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
									</tr>
									<!-- KwBusiness end -->
									<TR>
										<TD><img width="1" src='/_layouts/images/blank.gif' ID='100' alt='Icon' border="0"></TD>
									</TR>
								</TABLE>
							</td>
						</tr>
					</table>
				</TD>
				<td class="ms-bodyareaframe" valign="top" width="100%">
					<table cellpadding="2" cellspacing="0">
						<tr>
							<td><IMG SRC="../../images/blank.gif" width="1" height="1"></td>
						</tr>
					</table>
					<table border="0" width="100%" cellspacing="4" cellpadding="0">
						<form name="userfrm" id="userfrm" action="stsadmin.aspx" method="post" runat="server">
							<SharePoint:FormDigest id="frmDgst" runat="server" />
							<!-- Page description-->
							<TBODY>
								<TR>
									<TD class="ms-descriptiontext" ID="DescriptionText">
										<asp:Label ID="AdminPageDescriptionLabel" Runat="server">Use this page to repair and synchronize the WSS web portal and BizTalk server with the Trading Partner Management database.</asp:Label>
									</TD>
								</TR>
								<TR>
									<td>
										<SPAN id="spnError" runat="Server" Visible="False">
											<table border="0" cellspacing="0" cellpadding="0">
												<tr>
													<td><IMG src="../../images/warn_lg.gif"></td>
													<td>&nbsp;</td>
													<TD class="err" id="ErrorMessage">
														<asp:Label id="lblErr" runat="Server" />
													</TD>
												</tr>
											</table>
										</SPAN>
									</td>
								</TR>
								<TR>
								</TR>
							</TBODY>
					</table>
					<TABLE cellpadding="0" cellspacing="4" border="0">
						<!-- Repair -->
						<TR height="1">
							<TD colSpan="2"></TD>
						</TR>
						<TR height="10">
							<TD class="ms-sectionheader" colSpan="2">
								<asp:Label ID="AdminPageRepairSectionLabel" Runat="server">Repair</asp:Label>
							</TD>
							<TD>
							</TD>
						</TR>
						<tr>
							<TD class="ms-sectionline" colSpan="2" height="1"><IMG height="1" SRC="ONET_IMAGES_URL(blank.gif)" width="1"></TD>
						</tr>
						<TR>
							<TD><IMG src="../../images/ListSet.gif" height="24" width="34"></TD>
							<TD valign="top" class="ms-descriptiontext">
								<asp:Label ID="AdminPageRepairDescriptionLabel" Runat="server">Use this link to synchronize the BizTalk server database with the Trading Partner Management database.</asp:Label>
							</TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
							<TD class="ms-propertysheet">
								<table width="100%" border="0">
									<tr>
										<td class="ms-descriptiontext">
											<IMG height="7" src="../../images/rect.gif" width="6">&nbsp; <A id="user" accesskey=R href="JavaScript:" onclick="javascript:Submit('Repair');javascript:return false;">
												<asp:Label ID="AdminPageRepairLinkLabel" Runat="server">Repair</asp:Label></A></ASP:PLACEHOLDER></td>
									</tr>
								</table>
							</TD>
						</TR>
						<!-- Re-sync -->
						<TR height="10">
							<TD colSpan="2"></TD>
						</TR>
						<TR height="10">
							<TD class="ms-sectionheader" colSpan="2"><asp:Label ID="AdminPageReSyncSectionLabel" Runat="server">Re-sync</asp:Label></TD>
						</TR>
						<TR>
							<TD class="ms-sectionline" colSpan="2" height="1"><IMG height="1" SRC="ONET_IMAGES_URL(blank.gif)" width="1"></TD>
						</TR>
						<TR>
							<TD><IMG height="24" src="../../images/Content.gif" width="34"></TD>
							<TD class="ms-descriptiontext" valign="top">
								<asp:Label ID="AdminPageReSyncDescriptionLabel" Runat="server">Use this link to synchronize the WSS web portal with the Trading Partner Management database.</asp:Label>
							</TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
							<TD class="ms-propertysheet">
								<table width="100%" border="0">
									<tr>
										<td class="ms-descriptiontext">
											<IMG src="../../images/rect.gif">&nbsp; <A id="projectsettings" accesskey=S href="JavaScript:" onclick="javascript:Submit('Resync');javascript:return false;">
												<asp:Label ID="AdminPageReSyncLinkLabel" Runat="server">Re-sync</asp:Label></A>
										</td>
									</tr>
								</table>
							</TD>
						</TR>
					</TABLE>
				</td>
			</tr>
			</FORM>
		</table>
		</TD></TR></TABLE>
	</body>
</HTML>
