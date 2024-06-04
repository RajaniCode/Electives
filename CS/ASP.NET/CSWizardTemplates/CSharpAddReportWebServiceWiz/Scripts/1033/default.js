////////////////////////////////////////////////////////
//
// Copyright (c) Crystal Decisions, Inc. All rights reserved.
//
//
//  Script for the VC# report web service wizard
//

var L_RptWebServWizError_ErrorAddingRefs ="Error in adding references for the new report web service: ";


/////////////////////////////////////////////////


function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
    try
    {

        oldSuppressUIValue = dte.SuppressUI;
        dte.SuppressUI = true;

        var strItemName = wizard.FindSymbol("ITEM_NAME");

        var strItemRoot = TrimExtension( strItemName );
        wizard.AddSymbol("ITEM_ROOT", strItemRoot);

        var strTemplatePath = wizard.FindSymbol( "TEMPLATES_PATH" );

        AddNamespaceName( selObj );

        var strItemClassName = CreateLegalIdentifier( strItemRoot );
        wizard.AddSymbol("SAFE_REPORT_CLASS_NAME", strItemClassName );

        var strWebServiceSuffix = "Service";
        var strWebServiceClassName = strItemClassName + strWebServiceSuffix;
        wizard.AddSymbol("SAFE_CLASS_NAME", strWebServiceClassName );

        var strTemplateFile;

        strTemplateFile = strTemplatePath + "\\ReportWebService.asmx";
        var item = AddFileToVSProject( strItemRoot + strWebServiceSuffix + ".asmx",
                selProj, selObj, strTemplateFile );

        strTemplateFile = strTemplatePath + "\\ReportWebService.asmx.cs";
        AddFileToVSProject( strItemRoot + strWebServiceSuffix + ".asmx.cs",
                selProj, item.ProjectItems, strTemplateFile );

        AddReferencesForWebService( selProj );
        AddReferencesForReportWebService( selProj );

    }
    catch(e)
    {
        if(e.number == -2147221492)         //OLE_E_PROMPTSAVECANCELLED (0x8004000CL)
            return 0;
        else if(e.number == -2147024816)    //FILE_ALREADY_EXISTS (0x80070050)
            return 8191;
        else
            wizard.ReportError(e.description);
    }
    finally
    {
        dte.SuppressUI = oldSuppressUIValue;
    }
}


function AddNamespaceName( oSelObjCollection )
{
    var parent = oSelObjCollection.Parent;
    var kind = parent.Kind;
    var strNameSpace = "";

    if ( kind == GUID_ItemType_PhysicalFolder || kind == GUID_ItemType_VirtualFolder )
    {
        strNameSpace = parent.Properties("DefaultNamespace").Value;
    }
    else
    {
        strNameSpace = parent.Properties("RootNamespace").Value;
    }
    wizard.AddSymbol("SAFE_NAMESPACE_NAME", strNameSpace);
}


function SetFileProperties(oFileItem, strFileName)
{
    if(strFileName == "ReportWebService.asmx")
    {
        oFileItem.Properties("SubType").Value = "Form";
    }
}


function AddReferencesForReportWebService( oProj )
{
    try
    {
        var refmanager = GetCSharpReferenceManager(oProj);
        var bExpanded = IsReferencesNodeExpanded(oProj)
        refmanager.Add("System.Xml");
        refmanager.Add("CrystalDecisions.Shared");
        refmanager.Add("CrystalDecisions.CrystalReports.Engine");
        refmanager.Add("CrystalDecisions.ReportSource");
        refmanager.Add("CrystalDecisions.Web");
        if(!bExpanded)
            CollapseReferencesNode(oProj);
    }
    catch(e)
    {
        wizard.ReportError( L_RptWebServWizError_ErrorAddingRefs + e.description);
    }
}


function AddFileToVSProject(strItemName, selProj, selObj, strTemplateFile)
{

    var strLegalItemName = strItemName.split(".");
    wizard.AddSymbol("SAFE_ITEM_NAME", CreateLegalIdentifier(strLegalItemName[0]));

    var isReferenceExpanded;
    
    if(selProj != null) 
        isReferenceExpanded = IsReferencesNodeExpanded(selProj); // DRL: Adjusted to CSharp Common.js

    var folder = selObj.Parent;

    var strURL = folder.Properties("URL").Value;

    if (strURL.length > 0) //if a web project
        var strProjectPath = folder.Properties("LocalPath");
    else
        var strProjectPath = folder.Properties("FullPath");

    var strItemFile = strProjectPath + strItemName;

    var fsoTemporaryFolder = 2;

    fso = new ActiveXObject("Scripting.FileSystemObject");
    var tFolder = fso.GetSpecialFolder(fsoTemporaryFolder);
    var strTempName = fso.GetTempName();
    var strTempFile = tFolder.Drive + "\\" + tFolder.Name + "\\" + strTempName;
    SafeDeleteFile(fso, strTempFile);
    wizard.RenderTemplate(strTemplateFile, strTempFile, false);
    var item = folder.ProjectItems.AddFromTemplate(strTempFile, strItemName );
    SafeDeleteFile(fso, strTempFile);

    return item;
}


function SafeDeleteFile( fso, strFilespec )
{
    if (fso.FileExists(strFilespec))
    {
        var tmpFile = fso.GetFile(strFilespec);
        tmpFile.Delete();
    }
}


function CreateLegalIdentifier(strName)
{
    var nLen = strName.length;
    var strLegalName = "";
    var cChar = strName.charAt(0);
    switch(cChar)
    {
        case "0":
        case "1":
        case "2":
        case "3":
        case "4":
        case "5":
        case "6":
        case "7":
        case "8":
        case "9":
            strLegalName += "_";
            break;
    }
    for (nCntr = 0; nCntr < nLen; nCntr++)
    {
        cChar = strName.charAt(nCntr);
        switch(cChar)
        {
            case " ":
            case "~":
            case "&":
            case "'":
            case "#":
            case "!":
            case "@":
            case "$":
            case "%":
            case "^":
            case "(":
            case ")":
            case "-":
            case "+":
            case "=":
            case "{":
            case "}":
            case "[":
            case "]":
            case ";":
            case ",":
            case "`":
                strLegalName += "_";
                break;
            default:
                strLegalName += cChar;
                break;
        }
    }
    return strLegalName;
}


function TrimExtension(fileName)
{
    var index = fileName.lastIndexOf(".");
    if(index >= 0)
    {
        fileName = fileName.substr(0, index);
    }
    return fileName; 
}

