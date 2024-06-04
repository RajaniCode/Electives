<%@ Page Language="c#" Inherits="Microsoft.BizTalk.KwTpm.StsError" CodeBehind="StsError.aspx.cs" AutoEventWireup="false" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SP" Namespace="Microsoft.SharePoint" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<HTML dir="ltr">
	<HEAD>
		<Title id="onetidTitle"><%=Microsoft.BizTalk.KwTpm.StsError.PageTitle %></Title>
		<META Name="GENERATOR" Content="Microsoft SharePoint">
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<META HTTP-EQUIV="Expires" content="0">
		<script src="../owsbrows.js"></script>
		<SharePoint:CssLink DefaultUrl="../styles/ows.css" runat="server" id="CssLink1" />
		<script><!--
if (browseris.mac && !browseris.ie5up)
{
    var ms_maccssfpfixup = "../styles/owsmac.css";
    document.write("<link rel='stylesheet' Type='text/css' href='" + ms_maccssfpfixup + "'>");
}
//--></script>
		<script src="../ows.js"></script>
	</HEAD>
	<BODY marginwidth="0" marginheight="0" scroll="yes">
		<TABLE class="ms-main" CELLPADDING="0" CELLSPACING="0" BORDER="0" WIDTH="100%" HEIGHT="100%">
			<!-- Banner -->
			<TR>
				<TD COLSPAN="3" WIDTH="100%">
					<!--Top bar-->
					<table class="ms-bannerframe" border="0" cellspacing="0" cellpadding="0" width="100%">
						<tr>
							<td nowrap valign="middle"><img ID="onetidHeadbnnr0" alt="Logo" src="../../images/logo.gif"></td>
							<td class="ms-banner" width="99%" nowrap ID="HBN100" valign="middle">
								<!--webbot Bot="Navigation" startspan-->
								<SharePoint:Navigation LinkBarId="1002" runat="server" ID="Navigation1" />
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
				<td colspan="3">
					<table width="100%" border="0" class="ms-titleareaframe" cellpadding="0">
						<tr>
							<td>
								<table cellpadding="0" cellspacing="0" border="0">
									<tr>
										<td align="center" nowrap width="105" height="46">
											<img ID="onetidtpweb1" src="../../images/error.gif" alt="Icon"></td>
										<td width="27">&nbsp;</td>
										<td nowrap>
											<table cellpadding="0" cellspacing="0">
												<tr>
													<td nowrap class="ms-titlearea">&nbsp;
													</td>
												</tr>
												<tr>
													<td ID="onetidPageTitle" class="ms-pagetitle"><asp:Label id="LabelError" runat="Server" /></td>
												</tr>
											</table>
										</td>
										<td>&nbsp;</td>
									</tr>
								</table>
								<table cellpadding="0" cellspacing="0" border="0" width="100%">
									<tr>
										<td height="2" colspan="5"><img src="../../images/blank.gif"></td>
									</tr>
									<tr>
										<td class="ms-sectionline" height="2" colspan="5"><img src="../../images/blank.gif"></td>
									</tr>
									<tr>
										<td height="2" colspan="5"><img src="../../images/blank.gif"></td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</td>
			</tr>
			<!-- Navigation -->
			<TR valign="top">
				<TD height="100%" class="ms-nav">
					<TABLE height="100%" class="ms-navframe" CELLPADDING="0" CELLSPACING="0" BORDER="0" width="126">
						<TR valign="top">
							<TD width="99%">&nbsp;</TD>
							<TD class="ms-verticaldots">&nbsp;</TD>
						</TR>
					</TABLE>
				</TD>
				<!-- Contents -->
				<td align="left"><IMG SRC="../../images/blank.gif" width="10" height="1"></td>
				<TD valign="top" style="width:100%">
					<P align="left">
						<asp:Label id="LabelMessage" runat="server" CssClass="ms-descriptiontext" />
					</P>
					<P><asp:HyperLink id="HLinkAdditionalHelp" runat="server" CssClass="ms-descriptiontext" /></P>
					<P>
						<!-- FooterBanner closes the TD, TR, TABLE, BODY, And HTML regions opened above --> 
						&nbsp; 
						<!-- Close the TD, TR, TABLE, BODY, And HTML from Header --></P>
				</TD>
			</TR>
		</TABLE>
	</BODY>
</HTML>
