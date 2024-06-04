//////////////////////////////////////////////////////////////////////////////////
// Copyright (c) Microsoft Corporation.  All rights reserved. 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
// AND INFORMATION REMAINS WITH THE USER.
/////////////////////////////////////////////////////////////////////////////

function ModifyLinkValue(itemType)
	{	
		var cmd = "EditMember"; 
				
		var links = document.getElementsByTagName("a");
		for(var i= 0; i<links.length; i++)
		{
			var oAttrs = links[i].attributes;
			if (oAttrs.getNamedItem("OnClick") != null)
			{
				if( oAttrs.getNamedItem("OnClick").value == "GoToLink(this);return false;")
				{
					if ("Agreement" == itemType)
						cmd = "EditAgreement";
					else if ("Partner" == itemType)
						cmd = "EditPartner";
					else if ("Group" == itemType)
						cmd = "OpenGroup";
					else if ("Member" == itemType)
					{
						var itemTable = links[i].parentNode.parentNode.parentNode.parentNode;
						var cols = itemTable.parentNode.parentNode.children;
						var memberType = cols[cols.length-1].innerText;
						if (memberType == L_MemberTypeGroup_Text)
							cmd = "OpenGroup";
						else
							cmd = "EditPartner";	
					}
											
					oAttrs.getNamedItem("OnClick").value = "JavaScript:KwTpmMenuHandler('" + cmd + "')";
					oAttrs.getNamedItem("href").value = "JavaScript:KwTpmMenuHandler('" + cmd + "')";
				}
			}
		}
	}


function Custom_AddListMenuItems(m, ctx)
{
	// provide a hook for customization of BAS drop-down menu
    if (typeof(BAS_Custom_AddListMenuItems) != "undefined") 
    {
        if (BAS_Custom_AddListMenuItems(m, ctx))           
            return true;
    }
    
	KwTpmAddListMenuItems(m, ctx);
	return true;
}

// KwTpm templates ID
var LISTTEMPLATE_MEMBERS					=	300;
var LISTTEMPLATE_MYPROFILES					=	301;
var LISTTEMPLATE_PARTNERGROUPS				=	302;
var LISTTEMPLATE_AGREEMENTS					=	303;
var LISTTEMPLATE_BIZTALKSERVERS				=	304;
var LISTTEMPLATE_BUSINESSPROCESSES			=	309;

// Menu text -All KwTpm list
var L_KwTpmViewItem_Text			= "Summary View";

// Menu text - Partners
var L_KwTpmJoinLeaveGroups_Text			= "Join / Leave Groups";

var L_KwTpmDeployPartner_Text	= "Deploy Partner";
var L_KwTpmUndeployPartner_Text	= "Undeploy Partner";

// Menu text - Partner Groups
var L_KwTpmAddRemoveMembers_Text			= "Add / Remove Members";
var L_KwTpmOpenGroup_Text			= "Open Group";

// Menu text - Agreements
var L_KwTpmDeactivateAgreement_Text		= "Deactivate Agreement";
var L_KwTpmActivateAgreement_Text		= "Activate Agreement";
var L_KwTpmNewAgreement_Text		= "New Agreement";

// Menu text - BiztalkServers
var L_KwTpmUnregisterBiztalkServer_Text	= "Unregister BizTalk Server";

// Member type
var L_MemberTypePartner_Text				=	"Partner";
var L_MemberTypeGroup_Text					=	"Group";

// Status:  This has to be localized as it is for Tpm Web Service and Sts WebService
var L_PartnerStatusDeployed_Text				=	"Deployed";
var L_PartnerStatusUndeployed_Text				=	"Undeployed";
var L_AgreementStatusActive_Text				=	"Active";
var	L_MyProfilesListTitle_Text					=	"My Profiles";

// error info
var L_ItemIdNotFound_Text				= "Current BizTalkServer ID cannot be retrieved.";
var L_XDocsLaunchError_Text				= "InfoPath failed to launch.  Please make sure you have a proper version of InfoPath installed.";
var L_XDocsOpenError_Text				= "InfoPath failed to open the document.";

//for Bam
var L_BrowserNotSupported_Text = "This browser is not supported. Internet Explorer 6.0 or above is required"; 

// variable control refresh
var bIsXDocsOpen = false;

// KwTpm handlers path
var KwTpmHandlerPath = "/BAS/handlers.aspx";
var KwTpmTpMgtPath = "/BAS/TpManagement.aspx";

// Host selection: Localizable strings
var L_OperationCancelled_Text = "Refresh operation canceled by user.";
var L_ContactingServer_Text = "Retrieving the list of BizTalk hosts from server...";
var L_EnterServerAndDBNames_Text = "You must enter a valid BizTalk Management Database Server Name and a valid BizTalk Management Database.";
var L_CannotDisplayHosts_Text = "Cannot display BizTalk Hosts.";
var L_ZeroHostFound_Text = "No BizTalk Host found";
var L_CannotConnectToTPMMgmtWS_Text = "An error occured while trying to connect to the TPM Management Web Service. Contact your administrator for more information.";
var L_CannotParseTPMMgmtWSResponse_Text = "The answer returned by the TPM Management Web Service could not be understood. Contact your administrator for more information.";
var L_RefreshPageAndTryAgain_Text = "An error occured while retrieving the list of BizTalk Hosts. Please refresh the page and try again";
var L_HostDropDownTooltip_Text = "The required fields above must be populated with valid information, before this drop-down can be used";

function KwTpmFrmValidateAndSubmit(cmd, fUI)
{
	if (this.fPreviewMode)
	{
		var L_cantSave_Text = "This form cannot be saved when previewing this page.";
		window.alert(L_cantSave_Text);
		return;
	}
	if (this.FValidate(fUI)){
		this.FPostProcess();

		var query = "";
		var elmIds = document.getElementsByName("ID");
		var itemId = "";
		var i;
		for (i = 0; i < elmIds.length; i++)
			// make sure this is the ID input
			if ("onetidIOHidden" == elmIds[i].id)
				itemId = elmIds[i].value;
		
		if (itemId == "")
		{
			alert(L_ItemIdNotFound_Text);
		}
		else	// now get the fields value in the form and hand it off  
		{
			query += "&ID=" + itemId;			
			var ifld;
			var fld;
			if (this.form == null)
				this.form = document[this.stName];
			for (ifld = 0; ifld < this.ifldMax; ifld++)
			{
				query += "&";				
				fld = frm.rgfld[ifld];
				var fieldData = fld.frm.FieldPost(fld);
				var st = fieldData.value;
				query += fld.stName + "=" + escapeProperly(st);
				
			}
			KwTpmToolBarHandler(cmd, "?Cmd=" + cmd + query);
		}
	}
}

// add KwTpm-specific menu items in addition to default ones
function KwTpmAddListMenuItems(m, ctx)
{
	// from itemTable, <TR><TD><Table ItemId="1"/></TD><TD>Partner></TD></TR>
	var cols = itemTable.parentNode.parentNode.children;
	var memberType = "";
	var status = "";

	if (ctx.listTemplate != LISTTEMPLATE_BUSINESSPROCESSES)
		memberType = cols[cols.length-1].innerText;
		
	// "Open Group" needs be first	
	if (memberType == L_MemberTypeGroup_Text)
    {
		// open group
        CAMOpt(m, L_KwTpmOpenGroup_Text, "KwTpmMenuHandler('OpenGroup')", ctx.imagesPath + "BAS/opengroup.gif");                 
	}
    
	// view item
    strDisplayText = L_KwTpmViewItem_Text;
    strAction = "STSNavigate('" + ctx.displayFormUrl+"?ID="+ currentItemID + "&Source=" +
                GetSource() + "')";
    strImagePath = "";
    CAMOpt(m, strDisplayText, strAction, strImagePath);
    
    // edit item
    strDisplayText = L_EditItem_Text;
    
    if (ctx.listTemplate != LISTTEMPLATE_BUSINESSPROCESSES)
    {
		if (ctx.listTemplate == LISTTEMPLATE_MEMBERS)
		{
			if (memberType == L_MemberTypeGroup_Text)
				strAction = "KwTpmMenuHandler('EditGroup')";
			else
				strAction = "KwTpmMenuHandler('EditPartner')";
		}
			
		else if (ctx.listTemplate == LISTTEMPLATE_MYPROFILES)
				strAction = "KwTpmMenuHandler('EditPartner')";
				
		else if (ctx.listTemplate == LISTTEMPLATE_PARTNERGROUPS)
				strAction = "KwTpmMenuHandler('EditGroup')";
			
		else if (ctx.listTemplate == LISTTEMPLATE_AGREEMENTS)
			strAction = "KwTpmMenuHandler('EditAgreement')";	
			
		// Now it's only 'BiztalkServers' left: use default form page but
		// "Save and Close" on the 'NewForm.aspx' and 'editForm.aspx' are taken over
		else  
			strAction = "STSNavigate('" + ctx.editFormUrl+"?ID="+ currentItemID + "&Source=" +
					GetSource() + "')";
		strImagePath = ctx.imagesPath + "edititem.gif";
		CAMOpt(m, strDisplayText, strAction, strImagePath);
	}
    
    // delete item
    if (ctx.listTemplate != LISTTEMPLATE_BUSINESSPROCESSES 
		&& ctx.listTemplate != LISTTEMPLATE_BIZTALKSERVERS)
    {
		if (currentItemID.indexOf(".0.") < 0)
		{
			strDisplayText = L_DeleteItem_Text;
			if (ctx.listTemplate == LISTTEMPLATE_AGREEMENTS)
				strAction = "KwTpmMenuHandler('DeleteAgreement')";
			// all the cases for partners and groups	
			else if (memberType == L_MemberTypeGroup_Text)
				strAction = "KwTpmMenuHandler('DeleteGroup')";	
			else
				strAction = "KwTpmMenuHandler('DeletePartner')";
				
			strImagePath = ctx.imagesPath + "delitem.gif";
			CAMOpt(m, strDisplayText, strAction, strImagePath);
		}
	}
	
	if (memberType == L_MemberTypePartner_Text)
    	{
	    	// this is similar to how the list title is calculated (copied from portal_ function)
		var listUrl = unescapeProperly(ctx.listUrlDir);
		var idx1=0;
		var listTitle = "";
		idx1 =listUrl.lastIndexOf("/")
		if (idx1 > 0) 
		{    
			listTitle = listUrl.substr(idx1+1);
		}
		
	        // join / leave group
	        if ((ctx.listTemplate != LISTTEMPLATE_MYPROFILES) && !KwTpmIsSelfPartner(itemTable))
	        {
	        	CAMOpt(m, L_KwTpmJoinLeaveGroups_Text, "KwTpmMenuHandler('JoinLeaveGroup')", ctx.imagesPath + "BAS/joinleavegroups.gif");
	        }
        
		// deploy / undeploy partner
		if (listTitle != L_MyProfilesListTitle_Text)
		{
			status = cols[cols.length-2].innerText;
			if (L_PartnerStatusDeployed_Text == status)
				CAMOpt(m, L_KwTpmUndeployPartner_Text, "KwTpmMenuHandler('UndeployPartner')", ctx.imagesPath + "BAS/undeploypartner.gif");
			else if (L_PartnerStatusUndeployed_Text == status)
				CAMOpt(m, L_KwTpmDeployPartner_Text, "KwTpmMenuHandler('DeployPartner')", ctx.imagesPath + "BAS/deploypartner.gif");
		}   
			// New Agreement
		CAMOpt(m, L_KwTpmNewAgreement_Text, "KwTpmMenuHandler('NewAgreement')", ctx.imagesPath + "BAS/newagreement.gif");
    }
    
    if (memberType == L_MemberTypeGroup_Text)
    {
 		// add remove memebers
        CAMOpt(m, L_KwTpmAddRemoveMembers_Text, "KwTpmMenuHandler('AddRemoveMember')", ctx.imagesPath + "BAS/addremovemembers.gif");
 
        // join / leave group
        CAMOpt(m, L_KwTpmJoinLeaveGroups_Text, "KwTpmMenuHandler('JoinLeaveGroup')", ctx.imagesPath + "BAS/joinleavegroups.gif");
       
		// New Agreement
        CAMOpt(m, L_KwTpmNewAgreement_Text, "KwTpmMenuHandler('NewAgreement')", ctx.imagesPath + "BAS/newagreement.gif");
    }

    if (ctx.listTemplate == LISTTEMPLATE_AGREEMENTS)
    {
		//  status column is the last col
		status = cols[cols.length-1].innerText;
		if (L_AgreementStatusActive_Text == status)
			CAMOpt(m, L_KwTpmDeactivateAgreement_Text, "KwTpmMenuHandler('DeactivateAgreement')", ctx.imagesPath + "BAS/deactivateagreement.gif");
		else
			CAMOpt(m, L_KwTpmActivateAgreement_Text, "KwTpmMenuHandler('ActivateAgreement')", ctx.imagesPath + "BAS/activateagreement.gif");
        
    }
    
    if (ctx.listTemplate == LISTTEMPLATE_BIZTALKSERVERS)
    {
        // register biztalkserver
        CAMOpt(m, L_KwTpmUnregisterBiztalkServer_Text, "KwTpmMenuHandler('UnregisterBiztalkServer')", ctx.imagesPath + "BAS/unregisterbiztalkserver.gif");
    }
    
    // Alert Me 
    strDisplayText = L_Subscribe_Text;
    strAction = "STSNavigate('" + ctx.HttpRoot + "/_layouts/" + L_Language_Text + "/SubNew.aspx?List=" + ctx.listName + "&ID=" + currentItemID + "')"; ;
    strImagePath = "";
    CAMOpt(m, strDisplayText, strAction, strImagePath);
    
    // Moderate Item
    if (ctx.isModerated == true &&
        ctx.listBaseType != BASETYPE_SURVEY)
    {
        strDisplayText = L_ModerateItem_Text;
        strAction = "STSNavigate('" + ctx.editFormUrl+"?ID="+ currentItemID + "&ChangeApproval=TRUE&Source=" +
                    GetSource() + "')";
        strImagePath = "";
        CAMOpt(m, strDisplayText, strAction, strImagePath);
    }
    return;
}

var KwTpmLayoutsUrl = "";

function GetKwTpmLayoutsUrl(cmd)
{
	var url = "";
	switch (cmd)
	{

		case 'JoinLeaveGroup':
		case 'AddRemoveMember':
		case 'DeployPartner':
			url = KwTpmTpMgtPath;
			break	
		default:
			url = KwTpmHandlerPath;
			break;				
	}
	return url;
}

function KwTpmMemberTypeIconHandler(memberType, query)
{
	var cmd = "";
	if (L_MemberTypeGroup_Text == memberType)
		cmd = "OpenGroup";
	else	
		cmd = "EditPartner";
		
	query += "&Cmd=" + cmd;
	KwTpmToolBarHandler(cmd, query);
}

function KwTpmMenuHandler(cmd)
{
	var url = L_Menu_BaseUrl + "/_layouts/" + L_Menu_LCID + GetKwTpmLayoutsUrl(cmd) + "?Cmd=" + cmd + "&List=" + currentCtx.listName + 
						"&ID=" + currentItemID + "&NextUsing=" + GetSource();
						
	KwTpmButtonsHandler(cmd, url)
}

function KwTpmToolBarHandler(cmd, query)
{
	var nextUsing = document.location.href;
	if ("DeletePartner" == cmd || "DeleteGroup" == cmd || "DeleteAgreement" == cmd 
	|| "UnregisterBiztalkServer" == cmd || "JoinLeaveGroup" == cmd)
	{
		// make sure it will not redirect to the deleted item page
		nextUsing = GetKwTpmSource(nextUsing);
	}
	query += "&NextUsing=" + nextUsing;
	var url = L_Menu_BaseUrl + "/_layouts/" + L_Menu_LCID + GetKwTpmLayoutsUrl(cmd) + query;	
	KwTpmButtonsHandler(cmd, url);
}

function GetKwTpmSource(srcUrl)
{
	// this returns the defaultview Url of the list
	var index = srcUrl.indexOf("DispForm.aspx?");
	
	if (index < 0)
		index = srcUrl.indexOf("EditForm.aspx?");	
	
	if (index > 0)
		srcUrl = srcUrl.substring(0, index);
	return srcUrl;	
}

function KwTpmIsSelfPartner(item)
{
	try
	{
		// extract the Url of the partner icon - We will deduce the partner's type from the icon
		var iconUrl = item.parentNode.parentNode.children[0].getElementsByTagName('IMG')[0].src;
		return iconUrl.search(/myprofile.gif$/) != -1;
	}
	catch (e)
	{
		return false;
	}
}

// all the user actions comes down to this function
function KwTpmButtonsHandler(cmd, url)
{	
	switch (cmd)
	{
		case 'NewMember':	
		case 'EditMember':
		case 'NewPartner':	
		case 'NewGroup':
		case 'EditPartner':	
		case 'EditGroup':
		case 'NewAgreement':
		case 'EditAgreement':
	
			KwTpmOpenItem(cmd, url);
			break;			
			
		case 'DeleteMember':		
		case 'DeletePartner':
		case 'DeleteGroup':
		case 'DeleteAgreement':
		case 'UnregisterBiztalkServer':
			KwTpmDeleteItem(url);
			break;	
		
		// group
		case 'OpenGroup':
		// partner
		case 'JoinLeaveGroup':
		case 'AddRemoveMember':
		case 'DeployPartner':
		case 'UndeployPartner':
	
		// biztalkserver		
		case 'RegisterBiztalkServer':	// 'from Save and Close'
		case 'UpdateBiztalkServer':		// 'from Save and Close'
				
		// agreement	
		case 'DeactivateAgreement':
		case 'ActivateAgreement':
		
		// business process
		case 'RetrieveBusinessProcesses':
			KwTpmManageItem(url);
			break	
		default:
			alert("Unknown button"); // IE BUGBUG			
			window.location.href = window.location;
			break;				
	}
}

function KwTpmOpenClickedItem(cmd)
{
	alert(cmd);
}

function KwTpmDeleteItem(url)
{
	if (confirm(L_STSDelConfirm_Text))
	{
		if(document.all.__VIEWSTATE != null)
			document.all.__VIEWSTATE.removeNode(true);
		SubmitFormPost(url);
	}	
}

function KwTpmManageItem(url)
{
	if(document.all.__VIEWSTATE != null)
		document.all.__VIEWSTATE.removeNode(true);
	SubmitFormPost(url);
}

// this variable is used for InfoPath refresh
var sourceUrl = window.location.href;

function KwTpmAcquireXMLDom()
{
	var oXmlDom = null;
	try
	{
		try
		{
			oXmlDom = new ActiveXObject("Msxml2.DOMDocument.5.0");
		}
		catch(exc)
		{	
			try
			{
				oXmlDom = new ActiveXObject("Msxml2.DOMDocument.4.0");
			}
			catch(x)
			{
				try
				{
					oXmlDom = new ActiveXObject("Msxml2.DOMDocument");
				}
				catch(exec)
				{
					oXmlDom = new ActiveXObject("MSXML.DOMDocument");
				}
			}
		}	
		 return oXmlDom;
	}
	catch (ex)
	{
		alert (ex.message);
		return null;
	}
}

function KwTpmAcquireXMLHTTP()
{
	var oXmlHttp = null;
	try
	{
		try
		{
			oXmlHttp = new ActiveXObject("MSXML2.XMLHTTP.5.0");
		}
		catch(exc)
		{	
			try
			{
				oXmlHttp = new ActiveXObject("MSXML2.XMLHTTP.4.0");
			}
			catch(x)
			{
				oXmlHttp = new ActiveXObject("Microsoft.XMLHTTP");
			}
		}	
		 return oXmlHttp;
	}
	catch (ex)
	{
		alert (ex.message);
		return null;
	}
}

function KwTpmOpenItem(cmd, url)
{
	var xdocs = null;
	var bSucceed = false;	
	var bLoad = false;
	var oXmlDom = KwTpmAcquireXMLDom();
	
	try
	{
		if (oXmlDom != null)
		{
			oXmlDom.async = false;
			bLoad = oXmlDom.load(url);
		}
	}
	catch (ex)
	{
		alert (ex.message);
		return;
	}
		
	if (!bLoad || oXmlDom.documentElement == null || oXmlDom.xml.length == 0)
	{
		window.location.href = url;
		return;
	}

	try
	{
		xdocs = new ActiveXObject("SharePoint.OpenXMLDocuments.1");
	}
	catch (e)
	{
		alert(L_XDocsLaunchError_Text);
	}
	try
	{
		if (xdocs != null)
		{
			bSucceed = xdocs.CreateNewDocument(url, url);
		}
	}
	catch (e)
	{
		alert(L_XDocsOpenError_Text);
	}	
	
	if (bSucceed)
	{
		if(cmd == "PrepareAgreement")
		{
			var index = url.indexOf("&NextUsing=");
			sourceUrl = url.substring(index + 11);
			window.onfocus = KwTpmRefreshOnFocusPrepare;
		}
		else 
		{
			window.onfocus = KwTpmRefreshOnFocus;	
		}
		bIsXDocsOpen = true;
	}
}

function KwTpmRefreshOnFocus()
{
	if(bIsXDocsOpen)
	{
		window.location.href = window.location;
		bIsXDocsOpens = false;
	}
}

function KwTpmRefreshOnFocusPrepare()
{
	if(bIsXDocsOpen)
	{
		window.onfocus = KwTpmRefreshOnFocus2;
	}
}

function KwTpmRefreshOnFocus2()
{
	if(bIsXDocsOpen)
	{
		window.location.href = sourceUrl;
		bIsXDocsOpen = false;
	}
}

function QuickLaunch(quickLaunchItem)
{
	window.location.href = L_Menu_BaseUrl + "/_layouts/" + L_Menu_LCID + "/BAS/StsRedirect.aspx?QuickLaunch=" + quickLaunchItem;
}

//---------------------------------------------------------------------
// Handles a click on the "Refresh" button
//---------------------------------------------------------------------
function RefreshHostsLists()
{
	if ((document.BizTalkHostsMgr !== undefined) && (document.BizTalkHostsMgr != null))
	{
		document.BizTalkHostsMgr.KwTpmRefresh();
	}
}

//---------------------------------------------------------------------
// Represents the results of a Web Service call into one self contained object
//---------------------------------------------------------------------
function BizTalkHosts()
{
	this.ReceiveHosts = new Array();
	this.SendHosts = new Array();
	this.FriendlyError = "";
}

//---------------------------------------------------------------------
// Object to handle the update/retrieval of BizTalk hosts
//---------------------------------------------------------------------
function KwTpmBTSHostsMgr()
{
	this._sTPMgmtWSNamespace="http://www.microsoft.com/BizTalk/KwTpm";

	// SOAP Request
	this._sGetBizTalkHostsSOAP =
		"<?xml version=\"1.0\" encoding=\"utf-8\"?>"+ 
		"<soap:Envelope xmlns:soap=\"http://schemas.xmlsoap.org/soap/envelope/\" "+
		               "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" "+
		               "xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\">"+
		    "<soap:Body>"+
		        "<GetHostsForBizTalkRegistration xmlns=" + StAttrQuote(this._sTPMgmtWSNamespace) + ">"+
		            "<sqlServer></sqlServer>"+
		            "<bizTalkMgmtDbName></bizTalkMgmtDbName>"+
		        "</GetHostsForBizTalkRegistration>"+
		    "</soap:Body>"+
		"</soap:Envelope>";

	// Web Service URL
	this._sTPMgmtWSUrl = window.location.protocol + "//" + window.location.host + "/TPMgmtWS/TPMgmtWS.asmx";

	// Non localizable strings used only internally
	this._sErrorLevel = "error";
	this._sMessageDIV = "HelpErrorSummary";
	this._sRefreshButtonId = "diidIORefreshHostsList";

	// Initialize field
	this._refreshButton = document.getElementById(this._sRefreshButtonId);
	this._serverName = this._GetElementByName(frm.stFieldPrefix + "Server");
	this._dbName = this._GetElementByName(frm.stFieldPrefix + "Database");
	this._receiveHostDrop = frm.FindField("OutboxReceiveLocHost");
	this._paramSvcHostDrop = frm.FindField("ParamSvcHost");
	this._inFlightRequest = null;
	this._currentServerName = this._serverName.value;
	this._currentDBName = this._dbName.value;
	
	// Hook up events
	this._serverName.onpropertychange = KwTpmOnPropertyChanged;
	this._dbName.onpropertychange = KwTpmOnPropertyChanged;
	document.onstop = KwTpmOnStop;

	// Attempt tp populate the lists
	this._InternalRefresh(false);
}

// "Public" methods
KwTpmBTSHostsMgr.prototype.OnStop = KwTpmOnStop;
KwTpmBTSHostsMgr.prototype.OnPropertyChanged = KwTpmOnPropertyChanged;
KwTpmBTSHostsMgr.prototype.KwTpmRefresh = KwTpmRefresh;

// "Private" methods
KwTpmBTSHostsMgr.prototype._KwTpmDidInputChange = _KwTpmDidInputChange;
KwTpmBTSHostsMgr.prototype._InternalRefresh = _KwTpmInternalRefresh;
KwTpmBTSHostsMgr.prototype._HandleWSResults = _KwTpmHandleWSResults;
KwTpmBTSHostsMgr.prototype._GetBizTalkHosts = _KwTpmGetBizTalkHosts;
KwTpmBTSHostsMgr.prototype._HttpRequestCallback = _KwTpmHttpRequestCallback;
KwTpmBTSHostsMgr.prototype._AttemptSOAPFaultParsing = _KwTpmAttemptSOAPFaultParsing;
KwTpmBTSHostsMgr.prototype._GetElementByName = _KwTpmGetElementByName;
KwTpmBTSHostsMgr.prototype._RestoreFocus = _KwTpmRestoreFocus;
KwTpmBTSHostsMgr.prototype._DisplayMsg = _KwTpmDisplayMsg;


function KwTpmOnStop()
{
	var hostMgr = document.BizTalkHostsMgr;
	if (hostMgr != null)
	{
		if (hostMgr._inFlightRequest != null)
		{
			try
			{
				hostMgr._inFlightRequest.abort();
			}
			catch(e)
			{
			}

			var hosts = new BizTalkHosts();
			hosts.FriendlyError = L_OperationCancelled_Text;
			hostMgr._HandleWSResults(hosts);
			hostMgr._inFlightRequest = null;
		}
	}
}

function KwTpmOnPropertyChanged()
{
	var sPropertyName = window.event.propertyName;
	if (sPropertyName == "value")
	{
		var hostMgr = document.BizTalkHostsMgr;
		if (hostMgr._inFlightRequest == null)
		{
			var enable = hostMgr._KwTpmDidInputChange();
			if (!hostMgr._receiveHostDrop.IsEmpty())
			{
				hostMgr._receiveHostDrop.Enable(enable);
			}
			if (!hostMgr._paramSvcHostDrop.IsEmpty())
			{
				hostMgr._paramSvcHostDrop.Enable(enable);
			}
		}
	}
}

function _KwTpmDidInputChange()
{
	var hostMgr = document.BizTalkHostsMgr;
	var newServerName = TrimSpaces(hostMgr._serverName.value).toUpperCase();
	var newDbName = TrimSpaces(hostMgr._dbName.value);

	return ((newServerName != "") && (newDbName != "")) && 
		    ((TrimSpaces(hostMgr._currentServerName).toUpperCase() == newServerName) &&
		      (TrimSpaces(hostMgr._currentDBName) == newDbName));
}

function KwTpmRefresh()
{
	this._InternalRefresh(true);	
}

function _KwTpmInternalRefresh(fDisplayError)
{
	if (this._inFlightRequest == null)
	{	
		var serverName = this._serverName.value;
		var dbName = this._dbName.value;

		// Disable controls
		this._receiveHostDrop.Enable(false);
		this._paramSvcHostDrop.Enable(false);
			
		// Refresh if possible
		if ((serverName != "") && (dbName != ""))
		{
			this._DisplayMsg(L_ContactingServer_Text);
			this._GetBizTalkHosts(this._sTPMgmtWSUrl, serverName, dbName);
		}
		else
		{
			if (fDisplayError)
			{
				this._DisplayMsg(L_CannotDisplayHosts_Text, L_EnterServerAndDBNames_Text, this._sErrorLevel);
			}
		}
	}
}

function _KwTpmHandleWSResults(hosts)
{
	var hostMgr = document.BizTalkHostsMgr;

	// Update the drop downs
	hostMgr._receiveHostDrop.SetOptions(hosts.ReceiveHosts);
	hostMgr._paramSvcHostDrop.SetOptions(hosts.SendHosts);
	hostMgr._receiveHostDrop.Enable(hosts.ReceiveHosts.length > 0);
	hostMgr._paramSvcHostDrop.Enable(hosts.SendHosts.length > 0);
	hostMgr._RestoreFocus(hosts.ReceiveHosts.length > 0, hosts.SendHosts.length > 0);

	if ((hosts.FriendlyError === undefined) || (hosts.FriendlyError == ""))
	{
		// Remember the connection string for which we refreshed
		this._currentServerName =  this._serverName.value;
		this._currentDBName = this._dbName.value;

		// Completed without error
		hostMgr._DisplayMsg();
	}
	else
	{
		this._DisplayMsg(L_CannotDisplayHosts_Text, hosts.FriendlyError, this._sErrorLevel);
	}
}

function _KwTpmGetBizTalkHosts(url, sqlServerName, mgmtDbName)
{
	var xmlhttp = KwTpmAcquireXMLHTTP();
	var oXmlDom = KwTpmAcquireXMLDom();
	var hosts = new BizTalkHosts();
	
	if ((xmlhttp != null) && (oXmlDom != null))
	{
		oXmlDom.async = false;
		oXmlDom.loadXML(this._sGetBizTalkHostsSOAP);
		oXmlDom.setProperty("SelectionNamespaces", "xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ws='"+ this._sTPMgmtWSNamespace +"'");
		var oSqlServerNode = oXmlDom.selectSingleNode("//soap:Envelope/soap:Body/ws:GetHostsForBizTalkRegistration/ws:sqlServer");
		var oSqlDbNode =  oXmlDom.selectSingleNode("//soap:Envelope/soap:Body/ws:GetHostsForBizTalkRegistration/ws:bizTalkMgmtDbName");
		if ((oSqlServerNode != null) && (oSqlDbNode != null))
		{
			try
			{
				// This will encode entities as appropriate
				oSqlServerNode.text=sqlServerName;
				oSqlDbNode.text=mgmtDbName;

				this._inFlightRequest = xmlhttp;
				xmlhttp.onreadystatechange = this._HttpRequestCallback;
				xmlhttp.Open('POST', url, true);
				xmlhttp.setRequestHeader("Content-Type", 'text/xml; charset="UTF-8"');
				xmlhttp.setRequestHeader("SOAPAction", this._sTPMgmtWSNamespace + "/GetHostsForBizTalkRegistration");
				xmlhttp.Send(oXmlDom.xml);
			}
			catch(e)
			{
				this._inFlightRequest = null;
				hosts.FriendlyError = L_CannotConnectToTPMMgmtWS_Text;
				this._HandleWSResults(hosts);
			}
		}
		else
		{
			hosts.FriendlyError = L_RefreshPageAndTryAgain_Text;
			this._HandleWSResults(hosts);
		}
	}
	else
	{
		hosts.FriendlyError = L_BrowserNotSupported_Text;
		this._HandleWSResults(hosts);
	}
}

function _KwTpmHttpRequestCallback()
{
	var xmlHttp = document.BizTalkHostsMgr._inFlightRequest;
	var hostMgr = document.BizTalkHostsMgr;
	
	if ((hostMgr != null) && (xmlHttp != null))
	{
		switch (xmlHttp.readyState)
		{
			case 0: // UNINITIALIZED
			case 1: // LOADING
			case 2: // LOADED
			case 3: // INTERACTIVE
				break;
				
			case 4: // COMPLETED
				var hosts = new BizTalkHosts();
				
				switch (xmlHttp.status)
			  	{
					case 200:
						{
							var oReceiveHostNodes = null;
							var oSendHostNodes = null;
							try
							{
								xmlHttp.responseXML.setProperty("SelectionNamespaces", "xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ws='"+ hostMgr._sTPMgmtWSNamespace +"'");
								oSendHostNodes = xmlHttp.responseXML.selectNodes("//soap:Envelope/soap:Body/ws:GetHostsForBizTalkRegistrationResponse/ws:HostsList/ws:ParameterServicesSendHost/ws:Name");
								oReceiveHostNodes= xmlHttp.responseXML.selectNodes("//soap:Envelope/soap:Body/ws:GetHostsForBizTalkRegistrationResponse/ws:HostsList/ws:OutboxReceiveLocationHost/ws:Name");
							}
							catch (e)
							{
								hosts.FriendlyError = L_CannotParseTPMMgmtWSResponse_Text;
								hostMgr._HandleWSResults(hosts);
								hostMgr._inFlightRequest = null;
								return;
							}

							// Package the result - Send Hosts
							if ((oSendHostNodes != null) && (oSendHostNodes.length > 0))
							{
								for (index=0; index < oSendHostNodes.length; index++)
								{
									hosts.SendHosts[index] = oSendHostNodes[index].text;
								}
							}

							// Package the result - Receive Hosts
							if ((oReceiveHostNodes != null) && (oReceiveHostNodes.length > 0))
							{
								for (index=0; index < oReceiveHostNodes.length; index++)
								{
									hosts.ReceiveHosts[index] = oReceiveHostNodes[index].text;
								}
							}
							
							hostMgr._HandleWSResults(hosts);
						}
						break;

					default:
						{
							hosts.FriendlyError = hostMgr._AttemptSOAPFaultParsing(xmlHttp);
							hostMgr._HandleWSResults(hosts);
						}
						break;
			  	}
				hostMgr._inFlightRequest = null;
				break;
				
			default:
				break;
		}
	}
}

function _KwTpmAttemptSOAPFaultParsing(xmlHttp)
{
	try
	{
		// Do our best to find an useful error message, but if we cannot, return a generic message
		var SOAPFaultDom = xmlHttp.responseXml;
		
		SOAPFaultDom.setProperty("SelectionNamespaces", "xmlns:soap='http://schemas.xmlsoap.org/soap/envelope/' xmlns:ws='"+ this._sTPMgmtWSNamespace +"'");
		var oErrDetailNode =  SOAPFaultDom.selectSingleNode("//soap:Envelope/soap:Body/soap:Fault/detail/ws:ErrorInfo");
		if (oErrDetailNode == null)
		{
			oErrDetailNode =  SOAPFaultDom.selectSingleNode("//soap:Envelope/soap:Body/soap:Fault/faultstring");
		}
		return oErrDetailNode.text;
	}
	catch(e)
	{
		return L_CannotConnectToTPMMgmtWS_Text;
	}
}

function _KwTpmGetElementByName(name)
{
	try
	{
		var items = document.getElementsByName(name);
		return (items != null) && (items.length > 0) ? items[0] : null;
	}
	catch(e)
	{
		return null;
	}
}

function _KwTpmRestoreFocus(receiveHostsNotEmpty, sendHostsNotEmpty)
{
	// Focus the first list that has items - Ignore failure
	if (receiveHostsNotEmpty || sendHostsNotEmpty)
	{
		try
		{
			if (receiveHostsNotEmpty)
			{
				this._receiveHostDrop.FieldFocus();
			}
			else
			{
				if (sendHostsNotEmpty)
				{
					this._paramSvcHostDrop.FieldFocus();
				}
			}
		}
		catch (e) { }
	}
}

function _KwTpmDisplayMsg(sMessage, sReason, level)
{	
	var oDIV = document.getElementById(this._sMessageDIV);
	if (oDIV != null)
	{
		oDIV.innerHTML = "";

		if (sMessage !== undefined)
		{
			var sMsg  = STSHtmlEncode(sMessage);
			sMsg += sReason !== undefined ? " " +  STSHtmlEncode(sReason) : "";
			sMsg += "<BR><BR>";
			oDIV.innerHTML = sMsg;
			switch (level)
			{
				case this._sErrorLevel:
					oDIV.style.color='red';
					break;
				default:
					oDIV.style.color='black';
					break;
			}
		}
		else
		{
			oDIV.style.color='black';
			oDIV.innerHTML = "<BR><BR>";
		}
	}
}

//---------------------------------------------------------------------
// Implements the Choice Field which takes its values from the KwTpmWeb Service
//---------------------------------------------------------------------
function ChoiceTextField(frm, stName, stDisplay, stValue)
{
	// Non localizable strings used only internally
	this._sNoHost = "";

	// Initialize field
	this.stDisplay= stDisplay;
	this.stName = stName;
	this.stValue = stValue;
	this._dropDown = null;

	frm.AddField(this, stName, stDisplay, stValue);

	this.cchMaxLength = "";
	this.cchDisplaySize = "";	
}

// "Public" methods
ChoiceTextField.prototype.BuildUI = FrmEmitDropDownUI;
ChoiceTextField.prototype.FieldFocus = ChoiceTextFieldFocus;
ChoiceTextField.prototype.FValidate = ChoiceTextFieldFValidate;
ChoiceTextField.prototype.ClearOptions = ChoiceTextFieldClearOptions;
ChoiceTextField.prototype.SetOptions = ChoiceTextFieldSetOptions;
ChoiceTextField.prototype.Enable = ChoiceTextFieldEnable;
ChoiceTextField.prototype.OnSelectionChange = ChoiceTextFieldSelChange;
ChoiceTextField.prototype.IsEmpty = ChoiceTextFieldIsEmpty;

// "Private" methods
ChoiceTextField.prototype._EnsureTooltip = _ChoiceTextFieldEnsureTooltip;


function FrmEmitDropDownUI()
{
	var sElemName = frm.stFieldPrefix + fld.stName;
	var sIMEMode = this.IMEMode ? " style=\"ime-mode:" + this.IMEMode + "\" " : "";
	var st = "<TABLE CELLPADDING=0 CELLSPACING=1><TR><TD class=ms-RadioText VALIGN=TOP>";
	st += "<SELECT TITLE=" + StAttrQuote(this.stDisplay) + " ID=" + StAttrQuote(sElemName)  + " NAME=" + StAttrQuote(sElemName) + " " + FormTabIndex() + " " + sIMEMode + ">";

	// Display the current host name, if any and add the "Refresh" item
	if ((fld.stValue != null) && (fld.stValue != ""))
	{
		st += "<OPTION SIZE=1 VALUE=" + StAttrQuote(fld.stValue) + ">" + STSHtmlEncode(fld.stValue) + "</OPTION>";
	}
	else
	{
		st += "<OPTION SIZE=1 VALUE=" + StAttrQuote(this._sNoHost) + ">" + STSHtmlEncode(L_ZeroHostFound_Text) + "</OPTION>";
	}
	st += "</SELECT></TD></TR></TABLE>";

	this.frm.BuildFieldUI(this, st);
	
	// Disable appropriate controls
	this._dropDown = document.getElementById(sElemName);
	this._dropDown.disabled = true;

	// Be notified of selection changes
	this._dropDown.onchange = this.OnSelectionChange;
}

function ChoiceTextFieldFocus()
{
	if (this._dropDown.options.length == 0)
		return false;
	
	if (!this._dropDown.options.disabled)
	{
		this._dropDown.focus();
		return true;
	}
	return false;	
}

function ChoiceTextFieldFValidate()
{
	var sValue = GetSelectedValue(this._dropDown);
	
	if ((this.fRequired && sValue == "") || (this._dropDown.disabled))
	{
		this.stError = StBuildParam(L_FieldRequired_Text, this.stDisplay);
		return false;
	}
	return true;
}

function ChoiceTextFieldClearOptions()
{
	for (index=this._dropDown.options.length - 1; index >=0; index--)
	{
		this._dropDown.options.remove(index);
	}
}

function ChoiceTextFieldSetOptions(rgOptions)
{
	this.ClearOptions();
	if ((rgOptions != null) && (rgOptions.length > 0))
	{
		for (index=0; index < rgOptions.length; index++)
		{
			var oElem = document.createElement("OPTION");
			oElem.text = rgOptions[index];
			oElem.value = rgOptions[index];
			oElem.selected = (rgOptions[index] == this.stValue);
			this._dropDown.options.add(oElem);
		}
	}
	else
	{
		var oElem = document.createElement("OPTION");
		oElem.text = STSHtmlEncode(L_ZeroHostFound_Text);
		oElem.value = this._sNoHost;
		this._dropDown.options.add(oElem);
	}
	
	this._EnsureTooltip();
}

function ChoiceTextFieldEnable(fEnable)
{
	this._dropDown.disabled = fEnable ? false : true;
	this._EnsureTooltip();
}

function ChoiceTextFieldSelChange()
{
	var rgParts = window.event.srcElement.id.split("#");
	var fld = frm.FindField(rgParts[rgParts.length - 1]);
	if (fld != null)
	{
		fld.stValue = window.event.srcElement.value;
	}
}

function ChoiceTextFieldIsEmpty()
{
	var isEmpty = false;
	if ((this._dropDown != null) && (this._dropDown.options.length == 1))
	{
		isEmpty = this._dropDown.options[0].value == this._sNoHost;
	}

	return isEmpty;
}

function _ChoiceTextFieldEnsureTooltip()
{
	if (this._dropDown.disabled)
	{
		this._dropDown.title = L_HostDropDownTooltip_Text;		
	}
	else
	{
		this._dropDown.title = this.stDisplay;
	}
}
