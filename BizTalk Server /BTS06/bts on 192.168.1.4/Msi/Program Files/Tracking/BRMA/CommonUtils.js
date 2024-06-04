<!-- Copyright (c) Microsoft Corporation.  All rights reserved. -->
<!--  --> 
<!-- THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, -->  
<!-- WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED -->  
<!-- WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. -->  
<!-- THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE -->  
<!-- AND INFORMATION REMAINS WITH THE USER. --> 
<!--  -->
var oHelpProvider; // Use this objet to override default help
var HelpTopic="";	// Use this topic with a default HelpProvider (when oHelpProvider in not provided)

// There is an IE bug when TAB-order and 1-st button click do not work unless control is focused
window.focus(); // Move focus to the IE window

function ShowPageHelp()
{
	ShowHelp(HelpTopic);
}

function ShowHelp(topic)
{
	if ("undefined" != typeof(oHelpProvider) && 
		null != oHelpProvider.object) 
	{
		oHelpProvider.ShowHelpTopic();
	}else{
		var oDefaultHelpProvider = document.Help;
		oDefaultHelpProvider.SetHelpTopic(topic);
		oDefaultHelpProvider.ShowHelpTopic();
	}
}

function divShow(sDivName)
{		
	eval(sDivName + ".style.display='block'");
}

function divHide(sDivName)
{
	eval(sDivName + ".style.display='none'");
}

function NavigateNoPopUpWindow(url)
{
	var oNavCtrl = document.CollapsibleCtrl;
	var eventStr = oNavCtrl.AddNavigateNoPopUpEvent(url);
	document.title += " "; // trigger TitleChange event
}

function PopUpWindow(url)
{
	var oNavCtrl = document.CollapsibleCtrl;
	var eventStr = oNavCtrl.AddPopUpEvent(url);
	document.title += " "; // trigger TitleChange event
}

function EnableSaveAs(enabled)
{
	var oNavCtrl = document.CollapsibleCtrl;
	var eventStr = oNavCtrl.AddSaveAsEnabledEvent(enabled);
	document.title += " "; // trigger TitleChange event
	document.all("SaveAsBtn").disabled = !enabled;
}

function ChangeTitle(title)
{
	document.title = title;
}

function alertErr(sErrMsg)
{
	var oNavCtrl = document.CollapsibleCtrl;
	oNavCtrl.ShowErrorMessage(sErrMsg);
}

function InitLocalizedColumnsNames()
{
	var oNavCtrl = document.CollapsibleCtrl;
	OpsHostColName = oNavCtrl.GetResourceString("OpsHost");
	OpsMBoxDBColName = oNavCtrl.GetResourceString("OpsMBoxDB");
	OpsMBoxSrvColName = oNavCtrl.GetResourceString("OpsMBoxSrv");
	OpsSvcTypeColName = oNavCtrl.GetResourceString("OpsSvcType");
	OpsSvcClassColName = oNavCtrl.GetResourceString("OpsSvcClass");
	OpsSvcClassGuidColName = oNavCtrl.GetResourceString("OpsSvcClassGuid")
	OpsSvcInstIdColName = oNavCtrl.GetResourceString("OpsSvcInstId");
	OpsMsgIdColName	= oNavCtrl.GetResourceString("OpsMsgId");
}

