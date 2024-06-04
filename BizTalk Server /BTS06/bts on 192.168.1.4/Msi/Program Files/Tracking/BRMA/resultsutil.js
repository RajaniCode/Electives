<!-- Copyright (c) Microsoft Corporation.  All rights reserved. -->
<!--  -->
<!-- THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, -->
<!-- WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED -->
<!-- WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. -->
<!-- THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE -->
<!-- AND INFORMATION REMAINS WITH THE USER. -->
<!--  -->
var PtConstants;

var admin=document.Admin;			

var SVC_INST_ID_COLUMN = "ServiceInstance/InstanceID";
var SVC_CLASS_ID_COLUMN = "Service/ServiceClassGUID";
var ACTIVITY_ID_COLUMN = "ServiceInstance/ActivityID";
var MSG_INST_ID_COLUMN = "MessageInstance/InstanceID";

var sSVF_COL_SVCINST_STATE="ServiceInstance/State";
var CompletedStateString="Completed";
var TerminatedStateString="Terminated"

var View = "";
var WQ=false;//work queue
var OperationsView=false;
var SvcInstDetailsView=false;

var OpsHostColName;
var OpsMBoxDBColName;
var OpsMBoxSrvColName;
var OpsSvcTypeColName;
var OpsSvcClassColName;
var OpsSvcClassGuidColName;		
var OpsSvcInstIdColName;
var OpsMsgIdColName;

var OrchestrationServiceClass = "226FC6B9-0416-47A4-A8E8-4721F1DB1A1B";
var OtherServiceClass = "";
var RoutingFailureServiceClass = "EAF8EEA9-366A-4cde-8DD3-57A4C39BF8E5";

var WmiServer = ".";

var g_sSelSvcInstID = "";
var g_sSelActivityID = "";
var g_sSelSvcID = "";
var g_sSelSvcClassID = "";
var g_sSelMsgInstID = "";

function SetPtableView()
{
	var pt = document.ptable1;
	pt.ActiveView.ColumnAxis.Label.visible = false;
	pt.ActiveView.RowAxis.Label.visible = false;
	pt.ActiveView.FilterAxis.Label.visible = false;
	pt.ActiveView.AllowAdditions = false;
	pt.ActiveView.AllowEdits = false;
	pt.ActiveView.AllowDeletions = false;
	pt.ActiveView.Label.Visible = false; // no title bar for the result list
	pt.AutoFit = true;
	pt.DisplayPropertyToolbox = false;
	pt.DisplayFieldList = false;
	pt.AllowFiltering = true;
	pt.DisplayToolbar = false;
	pt.DisplayAlerts = true;
	PtConstants = pt.Constants;
	
	var oNavCtrl = document.CollapsibleCtrl;
	View = oNavCtrl.ViewName;

	//prepare flags
	if("Operations.htm" == View)
		OperationsView=true;

	if("OperationsMsgs.htm" == View)
		OperationsView=true;
		
	if("SvcInstDetails.htm" == View )
		SvcInstDetailsView=true;

	WQ = (OperationsView || SvcInstDetailsView);
}


function DoPTLayoutForFindMsg()
{
	//do the regual layout first
	DoPivotTableLayout();
	
	//and then shrink the first 2 columns with the GUIDs
	var i, j;
	var minWidth1 = 73; // hardcoded min width for the first column
	var minWidth2 = 63; // hardcoded min width for the second column
	
	//var data = pt.HTMLData; // Just access it. This causes pivot table to initialize all the column sizes.
	//var data = pt.ActiveData; // Just access it. This causes pivot table to initialize all the column sizes.
	
	//now go through all the columns and resize them properly
	var pt = document.all("ptable1");
	
	var nColumns = pt.ActiveView.DataAxis.FieldSets.Count;
	if(nColumns > 2)
		nColumns = 2;//take just the first 2
	
	for(i=0; i<nColumns; i++)
	{
		var ptFieldSet = pt.ActiveView.DataAxis.FieldSets(i);
		for(j=0; j<ptFieldSet.Fields.Count; j++)
		{					
			var ptField = ptFieldSet.Fields(j);
			ptField.DetailAutoFit = false;
			if(i==0)
				ptField.DetailWidth = minWidth1;
			if(i==1)
				ptField.DetailWidth = minWidth2;
		}
	}
}

//pivot table layout functions
function DoPivotTableLayout()
{
	try
	{
		var pt = document.all("ptable1");
		var newFormatStr = document.all("CollapsibleCtrl").GetLocalDateTimeFormatWithMilliseconds();
		UpdateDateTimeFormatInPivotTable(pt, newFormatStr);
		UpdateWidthInPivotTable(pt);
	}
	catch(e)
	{
	}
}
		
function UpdateDateTimeFormatInPivotTable(pt, newFormatStr)
{
	var i, j;
	var field;
	var ptField;
	var fieldType;
	//var data = pt.HTMLData; // Just access it. This causes pivot table to initialize all the column sizes.
	//var data = pt.ActiveData; // Just access it. This causes pivot table to initialize all the column sizes.

	//alert(pt.ActiveView.DataAxis.FieldSets.Count);
	for(i=0; i<pt.ActiveView.DataAxis.FieldSets.Count; i++)
	{
		var ptFieldSet = pt.ActiveView.DataAxis.FieldSets(i);

		for(j=0; j<ptFieldSet.Fields.Count; j++)
		{					
			ptField = ptFieldSet.Fields(j);
			//ptField.DetailFont.Name = "MS Shell Dlg";
			fieldType = ptField.DataType;
			//alert(ptField.Name);
			//alert("fieldType=" + fieldType);
				
			//alert("ptField.DetailAutoFit=" + ptField.DetailAutoFit);
			//alert("ptField.DetailWidth=" + ptField.DetailWidth);

			if(fieldType == 135 || fieldType == 7)
			{
				//alert(ptField.NumberFormat);
				//alert(ptField.Name);
				//alert("fieldType=" + fieldType);
				ptField.NumberFormat = newFormatStr; //"yyyy/MM/d hh:mm:ss.000";
				//alert(ptField.NumberFormat);	
			}
		}
	}
}

function UpdateWidthInPivotTable(pt)
{
	var i, j;
	var maxWidth = 400; // hardcoded maximum width
	
	//var data = pt.HTMLData; // Just access it. This causes pivot table to initialize all the column sizes.
	//var data = pt.ActiveData; // Just access it. This causes pivot table to initialize all the column sizes.
	
	//now go through all the columns and resize them properly
	for(i=0; i<pt.ActiveView.DataAxis.FieldSets.Count; i++)
	{
		var ptFieldSet = pt.ActiveView.DataAxis.FieldSets(i);
		for(j=0; j<ptFieldSet.Fields.Count; j++)
		{					
			var ptField = ptFieldSet.Fields(j);
			var needUpdate = ptField.DetailWidth > maxWidth;

			if(needUpdate)
			{
				ptField.DetailAutoFit = false;
				ptField.DetailWidth = maxWidth;
			}
		}
	}
}

function RemovePivotTableColumn(pt, columnName)
{
	var i;
	for(i=0; i<pt.ActiveView.DataAxis.FieldSets.Count; i++)
	{
		var ptFieldSet = pt.ActiveView.DataAxis.FieldSets(i);
		if(ptFieldSet.Caption == columnName)
		{
			pt.ActiveView.DataAxis.RemoveFieldSet(i);
		}
	}
}

function sFormatString(sFormat, aArgs)	// Used for localization
{
	var nArg;
	var sFind;
	var sReplace;

	for (nArg=0; nArg<aArgs.length; nArg++)
	{
		sFind = nArg + 1;
		sFind = "%" + sFind;
		sReplace = aArgs[nArg];
		sFormat = sFormat.replace(sFind, sReplace);
	}
	return sFormat;
}

function GetFieldValue(sColName, nRow)
{
	var pt = document.ptable1;
	var sFieldVal = "";

	try
	{
		var strType = GetTypeName(pt.selection);
		if("PivotDetailRange" == strType)
		{
			var PivotCell = pt.selection.Cell;
			var rs = PivotCell.Recordset;
			rs.AbsolutePosition = nRow + 1;
			sFieldVal = rs(sColName).Value;
		}
	}
	catch(e)
	{sFieldVal = "";}
	return sFieldVal;
}

function caselist_SelectionChange()
{
	if(!OperationsView && !SvcInstDetailsView)
		return;
		
	var nRow = GetFirstSelectedRow();
	if (nRow >= 0)
	{
		var oOpsCtrl = document.OperationsCtrl;
		var oNavCtrl = document.CollapsibleCtrl;
		var sSelMsgInstID = GetFieldValue(MSG_INST_ID_COLUMN, nRow);

		if(!oOpsCtrl.NeedUpdateMsgDetails(sSelMsgInstID))
			return;
			
		window.status = oNavCtrl.GetWebPageResourceString("str_ResultListWindowStatusUpdatingMessageProperties"); 
		var success = LoadServiceDetails(nRow);
		if(success)
		{
			document.OperationsCtrl.ShowMsgDetails(sSelMsgInstID);
		}
		window.status = ""; 
	}
}

//pivot table event handler
function caselist_BeforeContextMenu(x, y, Menu, Cancel)
{
	g_sSelSvcInstID = ""; g_sSelMsgInstID = ""; g_sSelActivityID = "";
	g_sSelSvcID=""; g_sSelSvcClassID="";
	
	Menu.Value = buildContextMenu();
}

//build context menu for Aggreagation and QB
function buildContextMenu()
{
	try
	{
		var oNavCtrl = document.CollapsibleCtrl;
		var nRow = GetFirstSelectedRow();
		var nSelectedRowCount = GetSelectedRowCount();
	
		var bCanAddSortContextMenu  = CheckIfCanSortPTable();
		
		var serviceClassId;
		var IsCompleted = false;
	
		var SuspendEnabled = false;
		var ResumeEnabled = false;
		var ResumeInDebugEnabled = false;
		var DisableSaveAllMessages = false;
		var DisableSaveMessage = false;
		var DisableMessageFlow = false;
	
		var oOpsCtrl;
	
		if(nRow>=0 && !WQ)
		{
			var activityId = GetFieldValue(ACTIVITY_ID_COLUMN, nRow);
			var instId = GetFieldValue(SVC_INST_ID_COLUMN, nRow);
			var oNavigationControl = document.CollapsibleCtrl;
			var State = oNavigationControl.GetServiceState(instId, activityId);
			IsCompleted = (State != 1); // for reporting views
		}
		
	
		if(WQ && nRow >= 0 && nSelectedRowCount > 1) // multiselect on Ops view
		{
			SuspendEnabled = true;
			ResumeEnabled = true;
			ResumeInDebugEnabled = false;
		}
		
		if (nRow >= 0)
		{
			g_sSelSvcInstID = GetFieldValue(SVC_INST_ID_COLUMN, nRow);
			g_sSelActivityID = GetFieldValue(ACTIVITY_ID_COLUMN, nRow);
			g_sSelMsgInstID = GetFieldValue(MSG_INST_ID_COLUMN, nRow);
			g_sSelSvcID = GetFieldValue(OpsSvcTypeColName, nRow);
			g_sSelSvcClassID = GetFieldValue(SVC_CLASS_ID_COLUMN, nRow);
		}
		
		var IsOrchestration = ( 0 == oNavCtrl.CompareGuidStrings(g_sSelSvcClassID, OrchestrationServiceClass));
		var IsInternalService = ( 0 == oNavCtrl.CompareGuidStrings(g_sSelSvcClassID, OtherServiceClass));
		var IsRoutingFailureReport = ( 0 == oNavCtrl.CompareGuidStrings(g_sSelSvcClassID, RoutingFailureServiceClass));
	
		if(OperationsView && nRow >= 0 && 1 == nSelectedRowCount) // single select on Services/Messages Ops view
		{
			oOpsCtrl = document.OperationsCtrl;
			
			var PendingOpColName = oOpsCtrl.GetPendingOpColName();
			var InstStatusColName = oOpsCtrl.GetInstStatusColName();
			var PendingOp = GetFieldValue(PendingOpColName, nRow);
			var InstStatus = GetFieldValue(InstStatusColName, nRow);
	
			SuspendEnabled = oOpsCtrl.SuspendOpEnabled(PendingOp, InstStatus);
			ResumeEnabled = oOpsCtrl.ResumeOpEnabled(PendingOp, InstStatus);
			// No multi-select, only for orchestrations
			ResumeInDebugEnabled = ( IsOrchestration && oOpsCtrl.ResumeInDbgOpEnabled(PendingOp, InstStatus));
			
			// Disable some other context menu items that do not apply to internal services
			if(IsInternalService || IsRoutingFailureReport)
			{
				DisableSaveAllMessages = true;
				DisableSaveMessage = true;
				DisableMessageFlow = true;
			}
		}
			
		var MENU_INIT_SIZE = 1;
		var nMenuSize = MENU_INIT_SIZE;
		if ( WQ && (g_sSelMsgInstID.length > 0) && (g_sSelSvcInstID.length > 0) && (nSelectedRowCount == 1) )
		{
			nMenuSize += 1; // Message Details
		}
	
		if ((g_sSelSvcInstID.length > 0) && (nSelectedRowCount == 1))
		{
			
			if(!SvcInstDetailsView && !IsCompleted ) // don't suggest this view when it is already the current view
				nMenuSize += 1; // Service Instance Details
	
			if(!DisableMessageFlow)
			{
				nMenuSize += 1; // Message Flow
			}
	
	
			if(IsOrchestration)
				nMenuSize += 1; // TDV
				
			
			if(!DisableSaveAllMessages)
			{
				nMenuSize += 2; // Separator, SaveAllMessages
			}
		}
	
		if ( WQ && (g_sSelMsgInstID.length > 0) && (g_sSelSvcInstID.length > 0) && (nSelectedRowCount == 1 ) && !DisableSaveMessage)
		{
				nMenuSize += 1; // Save Message
		}
	
		// Suspend/Resume/ResumeInBP/Terminate for operatins views
		if ( WQ && (g_sSelSvcInstID.length > 0) && (nSelectedRowCount >= 1) )
		{
			if(nMenuSize > MENU_INIT_SIZE)
				nMenuSize++; // separator
				
			if(SuspendEnabled)
				nMenuSize += 1;
				
			if(ResumeEnabled)
				nMenuSize += 1;
				
			if(ResumeInDebugEnabled)
				nMenuSize += 1;
	
			nMenuSize += 1; // always allow terminate
		}
		
		LoadTrackingData4CtxMenu(nRow, nSelectedRowCount);
		
		oNavCtrl.CtxMenuPluginResetEnum();
		var nPlugins=0;
	
		while( oNavCtrl.CtxMenuPluginGetNext(View)) // todo: finish parameters
		{ 
			nPlugins++;
		}	
		if(nMenuSize > MENU_INIT_SIZE && nPlugins > 0) // add separator before plugins
			nMenuSize++;
	
		nMenuSize += nPlugins;
		
		if (nMenuSize > MENU_INIT_SIZE) // add separator after plugins
			nMenuSize++;
			
		if (bCanAddSortContextMenu) // not empty, add "sorting Acs/Desc" + separator + "Field List" + "export to Excell"
			nMenuSize += 5;
			
		var sarrNewMenu = new Array(nMenuSize);
		var i = 0;
		
		if ( WQ && (g_sSelMsgInstID.length > 0) && (g_sSelSvcInstID.length > 0) && (nSelectedRowCount == 1) )
		{
			sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_MESSAGE_DETAILS_VIEW_CONTEXT_MENU"), "mnuMsgProperties");
		}
	
		if ((g_sSelSvcInstID.length > 0) && (nSelectedRowCount == 1) )
		{
			// No Service details in the HAT anymore
			//if(!SvcInstDetailsView && !IsCompleted) // don't suggest this view when it is already the current view
			//	sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SERVICE_INST_DETAILS_VIEW_CTXT_MENU"), "mnuSvcInstDetails");
		
			if(!DisableMessageFlow)
			{
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SVCINFO"), "mnuServiceInfo"); // message flow
			}
			
			if(IsOrchestration)
			{
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_TECHDETAILS"), "mnuTechDetails");
			}
			
			if(!DisableSaveAllMessages)
			{
				sarrNewMenu[i++] = null;
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SAVEALLMSGINST"), "mnuSaveAllMsgInst4Service");
			}
		}
	
		if ( WQ && (g_sSelMsgInstID.length > 0) && (g_sSelSvcInstID.length > 0) && !DisableSaveMessage)
		{
			if(nSelectedRowCount == 1)
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SAVE_SINGLE_SELECTED_MESSAGE"), "mnuSaveMsgInst");
			else
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SAVE_MULTIPLE_SELECTED_MESSAGES"), "mnuSaveMsgInst");
		}			
		
		if ( WQ && (g_sSelSvcInstID.length > 0) && (nSelectedRowCount >= 1) )
		{
			if (i > 0)
				sarrNewMenu[i++] = null;
				
			if(SuspendEnabled)
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SUSPEND_INST"), "mnuSuspendInst");
				
			if(ResumeEnabled)
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_RESUME_INST"), "mnuResumeInst");
				
			if(ResumeInDebugEnabled)
				sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_RESUMEBP_INST"), "mnuResumeBPInst");
				
			sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_TERMINATE_INST"), "mnuTerminateInst");
		}
		
		if(nMenuSize > MENU_INIT_SIZE && nPlugins > 0 && i>0) // add separator before plugins
			sarrNewMenu[i++] = null;
	
		oNavCtrl.CtxMenuPluginResetEnum();
		while(oNavCtrl.CtxMenuPluginGetNext(View)) // todo: finish parameters
		{ 
			var pluginIdx = oNavCtrl.CtxMenuPluginGetCurrentIdx();
			sarrNewMenu[i++] = new Array(oNavCtrl.CtxMenuPluginGetCurrentName(), "plugin" + pluginIdx);
		}			
	
		if (nMenuSize > MENU_INIT_SIZE && i>0)
			sarrNewMenu[i++] = null;
			
		if (bCanAddSortContextMenu) // not empty, add sorting context menu items + "Field List"
		{
			sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SortAscending"), PtConstants.plCommandSortAsc);				
			sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_SortDescending"), PtConstants.plCommandSortDesc);				
			sarrNewMenu[i++] = null;
			sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_ExportToExcel"), PtConstants.plCommandExport);				
			sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_FieldList"), PtConstants.plCommandChooser);
			
		}
	
		sarrNewMenu[i++] = new Array(oNavCtrl.GetWebPageResourceString("STR_COPY"), PtConstants.plCommandCopy);
		
		return sarrNewMenu;
	}
	catch(e)
	{
		alertErr(e.description);
		var sarrNewMenu = new Array(0);
		return sarrNewMenu
	}
}

function LoadServiceDetails(nRow)
{
	if( WQ )
	{
		// Result list only contains message list and information about service this message belongs to is not cached yet
		// Need to resolve service that this message belogs to and load it into the memory
		var MsgBoxDbName = GetFieldValue(OpsMBoxDBColName, nRow);
		var MsgBoxSrvName = GetFieldValue(OpsMBoxSrvColName, nRow);
		var HostName = GetFieldValue(OpsHostColName, nRow);
		var sSelSvcInstID = GetFieldValue(SVC_INST_ID_COLUMN, nRow);

		var success = document.OperationsCtrl.LoadSvcInst(sSelSvcInstID, MsgBoxDbName, MsgBoxSrvName, HostName);
		return success;
	}
}

function OnMsgProperties(nRow)
{
	var oNavCtrl = document.CollapsibleCtrl;
	window.status = oNavCtrl.GetWebPageResourceString("str_ResultListWindowStatusUpdatingMessageProperties"); 
	var success = LoadServiceDetails(nRow);
	
	if(success)
	{
		document.OperationsCtrl.ShowMessageDetails(g_sSelMsgInstID);
	}
	
	window.status = ""; 
	return success;
}

function OnSvcInstDetails(nRow)
{
	try
	{
		var qs=constructQuery();
		var MsgBoxDbName = GetFieldValue(OpsMBoxDBColName, nRow);
		var MsgBoxSrvName = GetFieldValue(OpsMBoxSrvColName, nRow);
		var HostName = GetFieldValue(OpsHostColName, nRow);
		PopUpWindow("SvcInstDetails.htm?"+qs+"&MsgBoxDb=" + MsgBoxDbName + "&MBoxSrv=" + MsgBoxSrvName + "&Host=" + HostName);
	}catch(e){
		alertErr(e.description);
	}
}

function OnTechDetails(nRow)
{
	try
	{
		var qs=constructQuery();
		PopUpWindow("techdetails.aspx?"+qs);
	}catch(e){
		alertErr(e.description);
	}
}
	
function OnServiceInfo(nRow)
{
	try
	{
		var qs=constructQuery();
		PopUpWindow("toa.aspx?"+qs);
	}catch(e){
		alertErr(e.description);
	}
}

function constructQuery()
{
	var oNavCtrl = document.CollapsibleCtrl;

	var SqlSrv, SqlDB, MgmtDb, MgmtSrv;

	var DataType = oNavCtrl.ViewType; 

	if(DataType == "1") // Live
	{
		SqlSrv = oNavCtrl.LiveSqlServer;
		SqlDB = oNavCtrl.LiveSqlDatabase;
		MgmtDb = oNavCtrl.MgmtDatabase;
		MgmtSrv = oNavCtrl.MgmtServer;
	}else{
		SqlSrv = oNavCtrl.SqlServer;
		SqlDB = oNavCtrl.SQLDatabase;
		MgmtDb = "";
		MgmtSrv = "";
	}
	
	var forceLiveModeParam;
	if ( WQ )
	{
		forceLiveModeParam = "&ForceLive=1";
	}
	else
	{
		forceLiveModeParam = "&ForceLive=0";
	}

	var qs="DataType="+DataType+"&MgmtSrv=" + MgmtSrv + "&MgmtDb=" + MgmtDb+"&SqlSrv=" + SqlSrv +"&SqlDB=" + SqlDB + "&inst=" + escape(g_sSelSvcInstID)+ "&activity=" + escape(g_sSelActivityID) + "&messageId=" + g_sSelMsgInstID + forceLiveModeParam;
	return qs;
}

//		function OnCopyQuery()
//		{
//			window.clipboardData.setData("Text", document.ptable1.CommandText);
//		}

function CheckIfCanSortPTable()
{
	var bCanSort = false;
	try
	{
		var strType = GetTypeName(document.ptable1.selection);
		if("PivotDetailRange" == strType || "PivotFields" == strType)
			bCanSort = true;
	}
	catch(e)
	{
	}

	return bCanSort;
}

function GetSelectedRowCount()
{
	var nCount = 0;
	
	try
	{
		var sel = document.ptable1.selection;
		nCount = sel.BottomRight.Row - sel.TopLeft.Row + 1;
	}
	catch(e)
	{
	}
	
	return nCount;
}

function GetFirstSelectedRow()
{
	var nStartRow = 0;
	
	try
	{
		var sel = document.ptable1.selection;
		nStartRow = sel.TopLeft.Row;
	}
	catch(e)
	{
	}
	
	return nStartRow;
}

function GetSelectedRow()
{
	var nRow = -1;
	
	try
	{
		var sel = document.ptable1.selection;
		if (sel.TopLeft.Row == sel.BottomRight.Row)
			nRow = sel.TopLeft.Row;
	}
	catch(e)
	{
	}
	
	return nRow;
}


//pivot table event handler
/*		function caselist_CommandExecute(vCommand, fSucceeded)
{
	var nRow = GetFirstSelectedRow();
	var nSelectedRowCount = GetSelectedRowCount();

	if (vCommand == "mnuCopyQuery")
		OnCopyQuery();
	else if (nRow >= 0)
	{
		//todo: remove setTimeout, just call
		window.setTimeout("ExecuteCommand(\"" + vCommand + "\", " + nRow + "," + nSelectedRowCount + ")", 300, "jscript");
	}
}
*/
function ExecuteCommand(vCommand, nRow, nRowCount)
{
	switch(vCommand)
	{
		case "mnuMsgProperties":
			OnMsgProperties(nRow);
			break;
		case "mnuSvcInstDetails":
			OnSvcInstDetails(nRow);
			break;
		case "mnuTechDetails":
			OnTechDetails(nRow);
			break;
		case "mnuServiceInfo":
			OnServiceInfo(nRow);
			break;
		case "mnuSuspendInst":
			OnSuspendInst(nRow, nRowCount);
			break;
		case "mnuResumeInst":
			OnResumeInst(nRow, nRowCount);
			break;
		case "mnuResumeBPInst":
			OnResumeBPInst(nRow, nRowCount);
			break;
		case "mnuTerminateInst":
			OnTerminateInst(nRow, nRowCount);
			break;
		case "mnuSaveAllMsgInst4Service":
			onSaveAllMsgInst4Service(nRow, nRowCount);
			break;
		case "mnuSaveMsgInst":
			onSaveMsgInst(nRow, nRowCount);
			break;
	}
	if(vCommand.length >6 && vCommand.substr(0,6) == "plugin")
	{
		onPlugin(vCommand.substr(6), nRow, nRowCount);
	}
}

//prepare all info on selected rows (handles special WQ case)
function GetSelectedInstances(nStartRow, nRowCount)
{
	var nRow;
	var admin=document.Admin;			
	var oNavCtrl = document.CollapsibleCtrl;
	
	var svcgrp = admin.CreateServiceInstanceGroup(oNavCtrl.SqlServer, oNavCtrl.SQLDatabase, WmiServer);

	for (nRow = nStartRow; nRow < nStartRow + nRowCount; nRow++)
	{
		if(WQ)
		{
			var sGrp = oNavCtrl.GetViewParameter("group");
			var sAppType = GetFieldValue(OpsHostColName, nRow);
			var sInstID = GetFieldValue(OpsSvcInstIdColName, nRow);
			var ServiceID = GetFieldValue(OpsSvcTypeColName, nRow);
			var ServiceClassID = GetFieldValue(OpsSvcClassGuidColName, nRow);
			var sMsgID = GetFieldValue(OpsMsgIdColName, nRow);
			var sMBoxSrv = GetFieldValue(OpsMBoxSrvColName, nRow);
			var sMBoxDb = GetFieldValue(OpsMBoxDBColName, nRow);

			var idx = svcgrp.AddWQ(sGrp, sAppType, sInstID, ServiceID, ServiceClassID, sMsgID, sMBoxSrv, sMBoxDb);				
		}
		else
		{
			sGrp = oNavCtrl.GetViewParameter("group");
			sAppType = oNavCtrl.GetViewParameter("AppType");
			sInstID = GetFieldValue(SVC_INST_ID_COLUMN, nRow);
			svcgrp.Add(sGrp, sAppType, sInstID);
		}
	}
	
	return svcgrp;
}

function OnSuspendInst(nStartRow, nRowCount)
{
	var svcgrp = GetSelectedInstances(nStartRow, nRowCount)
	svcgrp.SuspendInstances();
}

function OnResumeInst(nStartRow, nRowCount)
{
	var svcgrp = GetSelectedInstances(nStartRow, nRowCount)
	svcgrp.ResumeInstances();
}

function OnResumeBPInst(nStartRow, nRowCount)
{
	var svcgrp = GetSelectedInstances(nStartRow, nRowCount)
	svcgrp.ResumeDebugInstances();
}

function OnTerminateInst(nStartRow, nRowCount)
{
	var svcgrp = GetSelectedInstances(nStartRow, nRowCount)
	svcgrp.TerminateInstances();
}

function onSaveAllMsgInst4Service(nStartRow, nRowCount)
{
	try
	{
		var admin=document.Admin;			
		var oNavCtrl = document.CollapsibleCtrl;

		nRow = nStartRow;
		sInstID = GetFieldValue(SVC_INST_ID_COLUMN, nRow);
		sActivityID = GetFieldValue(ACTIVITY_ID_COLUMN, nRow);
		
		var result;
		var DataType = oNavCtrl.ViewType;
		if(WQ)
		{
			//wq is supposed to be live by definition
			DataType = "1";//override
			result=admin.SaveAllMessagesToFile(oNavCtrl.LiveSqlServer, oNavCtrl.LiveSQLDatabase, WmiServer, oNavCtrl.MgmtServer, oNavCtrl.MgmtDatabase, sInstID, sActivityID, DataType);
		}
		else
		{
			result=admin.SaveAllMessagesToFile(oNavCtrl.SqlServer, oNavCtrl.SQLDatabase, WmiServer, oNavCtrl.MgmtServer, oNavCtrl.MgmtDatabase, sInstID, sActivityID, DataType);
		}

		if(result != "")
		{
			var oPerm 	  = new Object();
			oPerm.Message ="";
			oPerm.Title = oNavCtrl.GetWebPageResourceString("str_BRMAName");
			oPerm.HtmlTable=result;
			var strRet	= window.showModalDialog("ConfirmForm.htm",oPerm,"dialogLeft:100px;dialogTop:100px;dialogWidth:640px;dialogHeight:250px;status:no;resizable:yes;scroll:yes");			
		}
	}catch(e){
		alertErr(e.description);
	}
}

function onSaveMsgInst(nStartRow, nRowCount)
{
	try
	{
		var svcgrp = GetSelectedInstances(nStartRow, nRowCount)

		var admin=document.Admin;			
		var oNavCtrl = document.CollapsibleCtrl;

		var result=svcgrp.SaveMessagesToFile(WmiServer, oNavCtrl.MgmtServer, oNavCtrl.MgmtDatabase);
		if(result!="")
		{
			var oPerm 	  = new Object();
			oPerm.Message ="";
			oPerm.Title = oNavCtrl.GetWebPageResourceString("str_BRMAName");
			oPerm.HtmlTable=result;
			var strRet	= window.showModalDialog("ConfirmForm.htm",oPerm,"dialogLeft:100px;dialogTop:100px;dialogWidth:640px;dialogHeight:250px;status:no;resizable:yes;scroll:yes");			
		}
	}catch(e){
		alertErr(e.description);
	}
}

function onPlugin(pluginIdx, nStartRow, nRowCount)
{
	var oNavCtrl = document.CollapsibleCtrl;
	oNavCtrl.CtxtMenuItemPluginExecute(pluginIdx, View);
	document.title += " "; // trigger TitleChange event so that HAT will verify all the pending notifications.
}

function LoadTrackingData4CtxMenu(nStartRow, nRowCount)
{
	var oNavCtrl = document.CollapsibleCtrl;
	var pt = document.ptable1;
	var strType = GetTypeName(pt.selection);
	var cellIdx = 0;

	oNavCtrl.CtxMenuItemsReset();
	if("PivotDetailRange" == strType)
	{
		var PivotCell = pt.selection.Cell;
		var rs = PivotCell.Recordset;
		var columnCount = rs.Fields.Count;
		
		// load values
		for (nRow = nStartRow; nRow < nStartRow + nRowCount; nRow++)
		{
			rs.AbsolutePosition = nRow + 1;
			for(cellIdx=0; cellIdx < columnCount; cellIdx++)
			{
				oNavCtrl.CtxMenuItemAddProperty(rs(cellIdx).Name, rs(cellIdx).Value);
			}
			oNavCtrl.CtxMenuItemAdd();
		}
	}
}

function ResetPTableBeforeExectingQuery()
{
	try
	{
		//hide pivot table...
		divHide("PivotTable");
		var pt = document.ptable1;

		// release any data PTable holded
		if (pt.DataSource != null)
		{
			var oNavCtrl = document.CollapsibleCtrl;
			pt.DataSource = oNavCtrl.EmptyRecordSet;
		}
	}catch(e){
		alertErr(e.description);
	}
}
