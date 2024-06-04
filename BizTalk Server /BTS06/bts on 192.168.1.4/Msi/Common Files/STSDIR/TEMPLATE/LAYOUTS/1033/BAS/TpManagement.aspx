<%@ Page Language="c#" Inherits="Microsoft.BizTalk.KwTpm.TpManagement" CodeBehind="TpManagement.aspx.cs" AutoEventWireup="false" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=11.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="KwTpm" Namespace="Microsoft.BizTalk.KwTpm" Assembly="Microsoft.BizTalk.KwTpm.StsHandlers" %>
<%@ Import Namespace="Microsoft.SharePoint.ApplicationPages" %>
<HTML dir="ltr">
	<HEAD>
		<Title id="onetidTitle">
			<%=Microsoft.BizTalk.KwTpm.TpManagement.PageTitle %>
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
		<script Language="javascript">

function Submit()
{
//TODO: add error handling
	document.forms.userfrm.isSubmitCtrl.value = true;
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
														<td ID="onetidPageTitle" class="ms-pagetitle">
															<asp:Label ID="titleLabel" Runat="server"></asp:Label></td>
														<td>:&nbsp;
														</td>
														<td class="ms-toolbar">
															<a ID="itemLink" Runat="server"></a>
														</td>
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
					<TABLE height="100%" class="ms-navframe" CELLPADDING="0" CELLSPACING="4" border="0" width="133">
						<tr valign="top">
							<td width="100%">&nbsp;</td>
							<td class="ms-verticaldots">&nbsp;</td>
						</tr>
					</TABLE>
				</TD>
				<td class="ms-bodyareaframe" valign="top" width="100%">
					<table cellpadding="2" cellspacing="0">
						<tr>
							<td><IMG SRC="../../images/blank.gif" width="1" height="1"></td>
						</tr>
					</table>
					<table border="0" width="100%" cellspacing="4" cellpadding="0">
						<form name="userfrm" id="userfrm" action="TpManagement.aspx" method="post" runat="server">
							<SharePoint:FormDigest id="frmDgst" runat="server" />
							<!-- Page description-->
							<TBODY>
								<TR>
									<TD class="ms-descriptiontext" ID="DescriptionText">
										<asp:Label ID="descLabel" Runat="server"></asp:Label>
									</TD>
								</TR>
								<TR>
									<td>
										<SPAN id="spnError" runat="Server" Visible="False">
											<table border="0" cellspacing="0" cellpadding="0">
												<tr>
													<td><IMG src="../images/warn_lg.gif"></td>
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
									<TD ID="AddUserTextTDID1">
										<!-- <TABLE  class="ms-toolbar" style="MARGIN-LEFT: 3px" cellpadding="2" cellspacing="0" border="0" id="onetidGrpsTB"> -->
										<Table id="toolbarTable" runat="server" class="ms-toolbar" style="MARGIN-LEFT: 3px" cellpadding="2"
											cellspacing="0" border="0">
											<TR>
												<td class="ms-toolbar">
													<table cellpadding="1" cellspacing="0" border="0">
														<tr>
															<td class="ms-toolbar" nowrap>
																<a tabindex="2" accesskey="S" ID="idSubmit" class="ms-toolbar" href="javascript:" onclick="javascript:Submit();javascript:return false;">
																	<asp:Image runat="server" ID="submitImg" ImageUrl="../../images/BAS/submit.gif" BorderWidth="0"
																		Width="16" Height="16" />
																</a>
															</td>
															<td nowrap>
																<a class="ms-toolbar" tabindex="2" accesskey="S" href="javascript:" onclick="javascript:Submit();javascript:return false;">
																	<asp:Label id="submitLabel" runat="Server" />
																</a>
															</td>
														</tr>
													</table>
												</td>
												<TD width="99%" class="ms-toolbar" align="right" nowrap id="align01"><IMG SRC="../../images/blank.gif" width="1" height="1"></TD>
											</TR>
										</Table>
									</TD>
								</TR>
								<SPAN id="spnUsers" runat="server">
									<TR>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD>
											<KwTpm:StsBtSvrsDataGrid id="biztalkserversDataGrid" runat="server" AutoGenerateColumns="false" AllowSorting="true"
												OnSortCommand="Datagrid_SortData" OnPageIndexChanged="Datagrid_PageData" AllowPaging="True" PageSize="50" SortField="Name"
												PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" PagerStyle-NextPageText="Next"
												PagerStyle-PrevPageText="Prev" PagerStyle-CssClass="ms-propertysheet" BorderWidth="0">
												<Columns>
													<asp:TemplateColumn runat="server" SortExpression="Membership" HeaderStyle-Wrap="false" HeaderStyle-CssClass="ms-vh">
														<ItemTemplate runat="server">
															<asp:RadioButton TabIndex="1" OnDataBinding="CheckMembership" runat="server" ID="Checkbox3" />
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:HyperLinkColumn DataTextField="Name" DataNavigateUrlField="Name" SortExpression="Name" HeaderStyle-Width="90%"
														HeaderStyle-CssClass="ms-vh" ItemStyle-CssClass="ms-propertysheet" />
													<asp:BoundColumn DataField="Membership" Visible="False" />
												</Columns>
											</KwTpm:StsBtSvrsDataGrid>
										</TD>
									</TR>
									<TR>
										<TD>
											<KwTpm:StsParentGroupsDatagrid id="groupsDataGrid" runat="server" AutoGenerateColumns="false" AllowSorting="true"
												OnSortCommand="Datagrid_SortData" OnPageIndexChanged="Datagrid_PageData" AllowPaging="True" PageSize="50" SortField="Name"
												PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" PagerStyle-NextPageText="Next"
												PagerStyle-PrevPageText="Prev" PagerStyle-CssClass="ms-propertysheet" BorderWidth="0">
												<Columns>
													<asp:TemplateColumn runat="server" SortExpression="Membership" HeaderStyle-Wrap="false" HeaderStyle-CssClass="ms-vh">
														<ItemTemplate runat="server">
															<asp:CheckBox TabIndex="1" OnDataBinding="CheckMembership" runat="server" ID="Checkbox2" NAME="Checkbox2" />
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:HyperLinkColumn  DataTextField="Name" DataNavigateUrlField="Name" SortExpression="Name" HeaderStyle-Width="42%"
														HeaderStyle-CssClass="ms-vh" ItemStyle-CssClass="ms-propertysheet" />
													<asp:BoundColumn DataField="Description" SortExpression="Description" HeaderStyle-Width="56%" HeaderStyle-CssClass="ms-vh"
														ItemStyle-CssClass="ms-propertysheet" />
													<asp:BoundColumn HeaderText="Membership" DataField="Membership" Visible="False" />
												</Columns>
											</KwTpm:StsParentGroupsDatagrid>
										</TD>
									</TR>
									<TR>
										<TD>
											<KwTpm:StsMembersDatagrid id="membersDataGrid" runat="server" AutoGenerateColumns="false" AllowSorting="true"
												OnSortCommand="Datagrid_SortData" OnPageIndexChanged="Datagrid_PageData" AllowPaging="True" PageSize="50" SortField="MemberType"
												PagerStyle-Mode="NumericPages" PagerStyle-HorizontalAlign="Right" PagerStyle-NextPageText="Next"
												PagerStyle-PrevPageText="Prev" PagerStyle-CssClass="ms-propertysheet" BorderWidth="0">
												<Columns>
													<asp:TemplateColumn runat="server" SortExpression="Membership" HeaderStyle-Wrap="false" HeaderStyle-CssClass="ms-vh">
														<ItemTemplate runat="server">
															<asp:CheckBox TabIndex="1" OnDataBinding="CheckMembership" runat="server" ID="Checkbox1" NAME="Checkbox2" />
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn SortExpression="Image" HeaderStyle-Wrap="false" HeaderStyle-CssClass="ms-vh" ItemStyle-CssClass="ms-propertysheet">
														<ItemTemplate>
															<asp:HyperLink runat=server Text = '<%#DataBinder.Eval(Container.DataItem, 
																	"Name")%>' NavigateUrl= '<%#DataBinder.Eval(Container.DataItem, 
																	"Url")%>' ImageUrl= '<%#DataBinder.Eval(Container.DataItem, 
																	"Image")%>' ID="Hyperlink1"/>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:TemplateColumn SortExpression="Name" HeaderStyle-Width="40%" HeaderStyle-CssClass="ms-vh" ItemStyle-CssClass="ms-propertysheet">
														<ItemTemplate>
															<asp:HyperLink runat=server Text = '<%#DataBinder.Eval(Container.DataItem, 
																	"Name")%>' NavigateUrl= '<%#DataBinder.Eval(Container.DataItem, 
																	"Url")%>' ID="MemberNameLink"/>
														</ItemTemplate>
													</asp:TemplateColumn>
													<asp:BoundColumn DataField="Description" SortExpression="Description" HeaderStyle-Width="55%" HeaderStyle-CssClass="ms-vh"
														ItemStyle-CssClass="ms-propertysheet" />
													<asp:BoundColumn DataField="MemberType" SortExpression="MemberType" HeaderStyle-CssClass="ms-vh"
														ItemStyle-CssClass="ms-propertysheet" Visible="False" />
													<asp:BoundColumn HeaderText="Membership" DataField="Membership" Visible="False" />
												</Columns>
											</KwTpm:StsMembersDatagrid>
										</TD>
									</TR>
								</SPAN>
								<!-- KwBusiness -->
								<input type="hidden" name="isSubmitCtrl" id="isSubmitCtrl" value="false" runat="server">
								<input type="hidden" name="itemTitle" id="itemTitle" runat="server">
								<input type="hidden" name="cmdCtrl" id="cmdCtrl" runat="server">
						</form>
					</table>
				</td>
			</tr>
			</TBODY></table>
	</body>
</HTML>
