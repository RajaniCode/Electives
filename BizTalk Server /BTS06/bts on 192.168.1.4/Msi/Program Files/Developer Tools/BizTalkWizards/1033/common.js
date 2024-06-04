/******************************************************************************
Copyright (c) Microsoft Corporation.  All rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
AND INFORMATION REMAINS WITH THE USER.
******************************************************************************/

var vsViewKindPrimary                     = "{00000000-0000-0000-0000-000000000000}";
var vsViewKindDebugging                   = "{7651A700-06E5-11D1-8EBD-00A0C90F26EA}";
var vsViewKindCode                        = "{7651A701-06E5-11D1-8EBD-00A0C90F26EA}";
var vsViewKindDesigner                    = "{7651A702-06E5-11D1-8EBD-00A0C90F26EA}";
var vsViewKindTextView                    = "{7651A703-06E5-11D1-8EBD-00A0C90F26EA}";

var GUID_ItemType_PhysicalFolder		  = "{6BB5F8EF-4483-11D3-8BCF-00C04F8EC28C}";
var GUID_ItemType_VirtualFolder			  =	"{6BB5F8F0-4483-11D3-8BCF-00C04F8EC28C}";
var GUID_ItemType_PhysicalFile			  = "{6BB5F8EE-4483-11D3-8BCF-00C04F8EC28C}";

var GUID_Deployment_TemplatePath          = "{54435603-DBB4-11D2-8724-00A0C9A8B90C}";

var gbExceptionThrown = false;

    var vsCMFunctionConstructor = 1;

	var vsCMAddPositionInvalid = -3;
	var vsCMAddPositionDefault = -2;
	var	vsCMAddPositionEnd = -1;
	var vsCMAddPositionStart = 0;
//
	var vsCMAccessPublic = 1;
	var vsCMAccessDefault = 32;
//
	var vsCMWhereInvalid = -1;
	var vsCMWhereDefault = 0;
	var vsCMWhereDeclaration = 1;
	var vsCMWhereDefinition = 2;
//
	var vsCMValidateFileExtNone = -1;
	var vsCMValidateFileExtCpp = 0;
	var vsCMValidateFileExtCppSource = 1;
	var vsCMValidateFileExtHtml = 2;
//
	var vsCMElementClass    = 1;
	var vsCMElementFunction = 2;
	var vsCMElementVariable = 3;
	var vsCMElementProperty = 4;
	var vsCMElementNamespace= 5;
	var vsCMElementInterface= 8;
	var vsCMElementStruct   = 11;	
	var vsCMElementUnion    = 12;
	var vsCMElementIDLCoClass=33;
	var vsCMElementVCBase   = 37;


// VS-specific HRESULT failure codes
//
	var OLE_E_PROMPTSAVECANCELLED = -2147221492;
	var VS_E_PROJECTALREADYEXISTS = -2147753952;
	var VS_E_PACKAGENOTLOADED = -2147753953;
	var VS_E_PROJECTNOTLOADED = -2147753954;
	var VS_E_SOLUTIONNOTOPEN = -2147753955;
	var VS_E_SOLUTIONALREADYOPEN = -2147753956;
	var VS_E_INCOMPATIBLEDOCDATA = -2147753962;
	var VS_E_UNSUPPORTEDFORMAT = -2147753963;
	var VS_E_WIZARDBACKBUTTONPRESS = -2147213313;
	var VS_E_WIZCANCEL = VS_E_WIZARDBACKBUTTONPRESS;

////////////////////////////////////////////////////////


/******************************************************************************
 Description: Sets the error info
  nErrNumber: Error code
  strErrDesc: Error description
******************************************************************************/
function SetErrorInfo(oErrorObj)
{
	var oWizard;
	try
	{
		oWizard = wizard;
	}
	catch(e)
	{
		oWizard = window.external;
	}

	try
	{
		var strErrorText = "";

		if(oErrorObj.description.length != 0)
		{
			strErrorText = oErrorObj.description;		
		}
		else
		{
			var strErrorDesc = GetRuntimeErrorDesc(oErrorObj.name);
			if (strErrorDesc.length != 0)
			{
				var L_strScriptRuntimeError_Text = " error occurred while running the script:\r\n\r\n";
				strErrorText = oErrorObj.name + L_strScriptRuntimeError_Text + strErrorDesc;
			}
		}

		oWizard.SetErrorInfo(strErrorText, oErrorObj.number & 0xFFFFFFFF);
	}
	catch(e)
	{
		var L_ErrSettingErrInfo_Text = "An error occurred while setting the error info.";
		oWizard.ReportError(L_ErrSettingErrInfo_Text);
	}
}


/******************************************************************************
         Description: Returns a description for the exception type given
 strRuntimeErrorName: The name of the type of exception occurred
 *****************************************************************************/
function GetRuntimeErrorDesc(strRuntimeErrorName)
{
	var L_strDesc_Text = "";
	switch(strRuntimeErrorName)
	{
		case "ConversionError":
			var L_ConversionError1_Text = "This error occurs whenever there is an attempt to convert";
			var L_ConversionError2_Text = "an object into something to which it cannot be converted.";
			L_strDesc_Text = L_ConversionError1_Text + "\r\n" + L_ConversionError2_Text;
			break;
		case "RangeError":
			var L_RangeError1_Text = "This error occurs when a function is supplied with an argument";
			var L_RangeError2_Text = "that has exceeded its allowable range. For example, this error occurs";
			var L_RangeError3_Text = "if you attempt to construct an Array object with a length that is not";
			var L_RangeError4_Text = "a valid positive integer.";
			L_strDesc_Text = L_RangeError1_Text + "\r\n" + L_RangeError2_Text + "\r\n" + L_RangeError3_Text + "\r\n" + L_RangeError4_Text;
			break;
		case "ReferenceError":
			var L_ReferenceError1_Text = "This error occurs when an invalid reference has been detected.";
			var L_ReferenceError2_Text = "This error will occur, for example, if an expected reference is null.";
			L_strDesc_Text = L_ReferenceError1_Text + "\r\n" + L_ReferenceError2_Text;
			break;
		case "RegExpError":
			var L_RegExpError1_Text = "This error occurs when a compilation error occurs with a regular";
			var L_RegExpError2_Text = "expression. Once the regular expression is compiled, however, this error";
			var L_RegExpError3_Text = "cannot occur. This example will occur, for example, when a regular";
			var L_RegExpError4_Text = "expression is declared with a pattern that has an invalid syntax, or flags";
			var L_RegExpError5_Text = "other than i, g, or m, or if it contains the same flag more than once.";
			L_strDesc_Text = L_RegExpError1_Text + "\r\n" + L_RegExpError2_Text + "\r\n" + L_RegExpError3_Text + "\r\n" + L_RegExpError4_Text + "\r\n" + L_RegExpError5_Text;
			break;
		case "SyntaxError":
			var L_SyntaxError1_Text = "This error occurs when source text is parsed and that source text does not";
			var L_SyntaxError2_Text = "follow correct syntax. This error will occur, for example, if the eval";
			var L_SyntaxError3_Text = "function is called with an argument that is not valid program text.";
			L_strDesc_Text = L_SyntaxError1_Text + "\r\n" + L_SyntaxError2_Text + "\r\n" + L_SyntaxError3_Text;
			break;
		case "TypeError":
			var L_TypeError1_Text = "This error occurs whenever the actual type of an operand does not match the";
			var L_TypeError2_Text = "expected type. An example of when this error occurs is a function call made on";
			var L_TypeError3_Text = "something that is not an object or does not support the call.";
			L_strDesc_Text = L_TypeError1_Text + "\r\n" + L_TypeError2_Text + "\r\n" + L_TypeError3_Text;
			break;
		case "URIError":
			var L_URIError1_Text = "This error occurs when an illegal Uniform Resource Indicator (URI) is detected.";
			var L_URIError2_Text = "For example, this is error occurs when an illegal character is found in a string";
			var L_URIError3_Text = "being encoded or decoded.";
			L_strDesc_Text = L_URIError1_Text + "\r\n" + L_URIError2_Text + "\r\n" + L_URIError3_Text;
			break;
		default:
			break;
	}
	return L_strDesc_Text;
}

/******************************************************************************
 Description: Creates the Templates.inf file.
              Templates.inf is created based on TemplatesInf.txt and contains
			  a list of file names to be created by the wizard.
******************************************************************************/
function CreateInfFile()
{
	try
	{
		var oFSO, TemplatesFolder, TemplateFiles, strTemplate;
		oFSO = new ActiveXObject("Scripting.FileSystemObject");

		var TemporaryFolder = 2;
		var oFolder = oFSO.GetSpecialFolder(TemporaryFolder);

		var strTempFolder = oFSO.GetAbsolutePathName(oFolder.Path);
		var strWizTempFile = strTempFolder + "\\" + oFSO.GetTempName();

		var strTemplatePath = wizard.FindSymbol("TEMPLATES_PATH");
		var strInfFile = strTemplatePath + "\\Templates.inf";
		wizard.RenderTemplate(strInfFile, strWizTempFile);

		var oWizTempFile = oFSO.GetFile(strWizTempFile);
		return oWizTempFile;

	}
	catch(e)
	{   
		throw e;
	}
}

/******************************************************************************
 Description: Returns a unique file name
strDirectory: Directory to look for file name in
 strFileName: File name to check.  If unique, same file name is returned.  If 
              not unique, a number from 1-9999999 will be appended.  If not 
			  passed in, a unique file name is returned via GetTempName.
******************************************************************************/
function GetUniqueFileName(strDirectory, strFileName)
{
	try
	{
		oFSO = new ActiveXObject("Scripting.FileSystemObject");
		if (!strFileName)
			return oFSO.GetTempName();

		if (strDirectory.length && strDirectory.charAt(strDirectory.length-1) != "\\")
			strDirectory += "\\";

		var strFullPath = strDirectory + strFileName;
		var strName = strFileName.substring(0, strFileName.lastIndexOf("."));
		var strExt = strFileName.substr(strFileName.lastIndexOf("."));

		var nCntr = 0;
		while (oFSO.FileExists(strFullPath))
		{
			nCntr++;
			strFullPath = strDirectory + strName + nCntr + strExt;
		}
		if (nCntr)
			return strName + nCntr + strExt;
		else
			return strFileName;
	}
	catch(e)
	{   
		throw e;
	}
}


/******************************************************************************
 Description: Deletes the file given
        oFSO: File System Object
     strFile: Name of the file to be deleted
******************************************************************************/
function DeleteFile(oFSO, strFile)
{
	try
	{
		if (oFSO.FileExists(strFile))
		{
			var oFile = oFSO.GetFile(strFile);
			oFile.Delete();
		}
	}
	catch(e)
	{   
		throw e;
	}
}

/******************************************************************************
Description: Returns the highest dispid from members of the given interface & 
             all its bases
  oInterface: Interface object
******************************************************************************/
function GetMaxID(oInterface)
{
	var currentMax = 0;
	try
	{
		var funcs = oInterface.Functions;
		if(funcs!=null)
		{
			var nTotal = funcs.Count;
			var nCntr;
			for (nCntr = 1; nCntr <= nTotal; nCntr++)
			{
				var id = funcs(nCntr).Attributes("id");
				if(id!=null)
				{
					var idval = parseInt(id.Value);
					if(idval>currentMax)
						currentMax = idval;
				}
			}
		}
//REMOVE remove this and use Children collection above, if it's implemented
		funcs = oInterface.Variables;
		if(funcs!=null)
		{
			var nTotal = funcs.Count;
			var nCntr;
			for (nCntr = 1; nCntr <= nTotal; nCntr++)
			{
				var id = funcs(nCntr).Attributes("id");
				if(id!=null)
				{
					var idval = parseInt(id.Value);
					if(idval>currentMax)
						currentMax = idval;
				}
			}
		}
		var nextBases = oInterface.Bases;
		var nTotal = nextBases.Count;
		var nCntr;
		for (nCntr = 1; nCntr <= nTotal; nCntr++)
		{
			var nextObject = nextBases(nCntr).Class;
			if(nextObject!=null && nextObject.Name != "IDispatch")
			{
				var idval = GetMaxID(nextObject);
				if(idval>currentMax)
						currentMax = idval;
			}
		}
		return currentMax;
	}
	catch(e)
	{   
		throw e;
	}
}


/******************************************************************************
 Description: Generates a C++ friendly name
     strName: The old, unfriendly name
******************************************************************************/
function CreateSafeName(strName)
{
	try
	{
		var nLen = strName.length;
		var strSafeName = "";
		
		for (nCntr = 0; nCntr < nLen; nCntr++)
		{
			var cChar = strName.charAt(nCntr);
			if ((cChar >= 'A' && cChar <= 'Z') || (cChar >= 'a' && cChar <= 'z') || 
					(cChar == '_') || (cChar >= '0' && cChar <= '9'))
			{
				// valid character, so add it
				strSafeName += cChar;
			}
			// otherwize, we skip it
		}
		if (strSafeName=="")
		{
			// if it's empty, we add My
			strSafeName = "My";
		}
		else if (strSafeName.charAt(0) >= '0' && strSafeName.charAt(0) <= '9')
		{
			// if it starts with a digit, we prepend My
			strSafeName = "My" + strSafeName;
		}
		return strSafeName;
	}
	catch(e)
	{   
		throw e;
	}
}


/******************************************************************************
 Description: Called from the wizards html script when 'Finish' is clicked. This
              function in turn calls the wizard control's Finish().
    document: HTML document object
******************************************************************************/
function OnWizFinish(document)
{
	document.body.style.cursor='wait';
	try
	{
		window.external.Finish(document, "ok"); 
	}
	catch(e)
	{
		document.body.style.cursor='default';
		if (e.description.length != 0)
			SetErrorInfo(e.description, e.number);
		return e.number;
	}
}

/******************************************************************************
 Description: Returns a Function object based on the given name
      oClass: Class object
 strFuncName: Name of the function
       oProj: Selected project
******************************************************************************/
function GetMemberFunction(oClass, strFuncName, oProj)
{
	try
	{
		var oFunctions;
		if (oClass)
			oFunctions = oClass.Functions;
		else
		{
			if (!oProj)
				return false;
			oFunctions = oProj.CodeModel.Functions;
		}

		for (var nCntr = 1; nCntr <= oFunctions.Count; nCntr++)
		{
			if (oFunctions(nCntr).Name == strFuncName)
				return oFunctions(nCntr);
		}
		return false;
	}
	catch(e)
	{   
		throw e;
	}
}


/*****************************************************************************
  The following section contains functions that are used by CSharp Projects
  and CSharp Additems. If you like to add a new function that is CSharp
  specific, please add it beyond this point of this file.

                            - CSHARP SECTION -
******************************************************************************/


function CreateProject(strProjectName, strProjectExt, strProjectPath, strTemplateFile, namespaceProperty)
{
	try
	{

		// Make sure user sees ui.
//		dte.SuppressUI = false;

		var strProjTemplate = strTemplateFile;

		var Solution = dte.Solution;
		var strSolutionName = "";
		if (wizard.FindSymbol("CLOSE_SOLUTION"))
		{
			Solution.Close();
			strSolutionName = wizard.FindSymbol("VS_SOLUTION_NAME");
			if (strSolutionName.length)
			{
				var strSolutionPath = strProjectPath.substr(0, strProjectPath.length - strProjectName.length);
				Solution.Create(strSolutionPath, strSolutionName);
			}
		}

		var strProjectNameWithExt = strProjectName + strProjectExt;
		var oTarget = wizard.FindSymbol("TARGET");
		var oProj;
		if (wizard.FindSymbol("WIZARD_TYPE") == vsWizardAddSubProject)  // vsWizardAddSubProject
		{
 	        var nPos = strProjectPath.search("http://");
 	        var prjItem;
 	        if(nPos == 0)
                prjItem = oTarget.AddFromTemplate(strProjTemplate, strProjectPath + "/" + strProjectNameWithExt);    
            else
				prjItem = oTarget.AddFromTemplate(strProjTemplate, strProjectPath + "\\" + strProjectNameWithExt);
			oProj = prjItem.SubProject;
		}
		else
		{
			oProj = oTarget.AddFromTemplate(strProjTemplate, strProjectPath, strProjectNameWithExt);
		}

//		var strNameSpace = "";
//		strNameSpace = oProj.Properties(namespaceProperty).Value;
//		wizard.AddSymbol("SAFE_NAMESPACE_NAME",  strNameSpace);

		return oProj;
	}
	catch(e)
	{   
		throw e;
	}
}
/******************************************************************************
    Description: Creates a BTS project
 strProjectName: Project Name
 strProjectPath: The path that the project will be created in
******************************************************************************/
function CreateBTSProject(strProjectName, strProjectPath, strTemplateFileName)
{
	var strProjectExt = ".btproj";
	var strTemplateFile = strTemplateFileName + strProjectExt;
	return CreateProject(strProjectName, strProjectExt, strProjectPath, strTemplateFile, "DefaultNamespace");
}
/******************************************************************************
     Description: Creates a C# project
  strProjectName: Project Name
  strProjectPath: The path that the project will be created in
 strTemplateFile: Project template file e.g. "defualt.csproj"
******************************************************************************/
function CreateCSharpProject(strProjectName, strProjectPath, strTemplateFile)
{
	var strProjectExt = ".csproj";
	var strTemplateFile = strTemplateFileName + strProjectExt;
	return CreateProject(strProjectName, strProjectExt, strProjectPath, strTemplateFile, "RootNamespace");
}

/******************************************************************************
     Description: 
           oProj: Project object
******************************************************************************/
function GetUIReferencesNode(oProj)
{
        var L_strReferencesNode_Text = "References"; // This string needs to be localized
        var UIItemX = GetUIItem( oProj, L_strReferencesNode_Text);
        return UIItemX.UIHierarchyItems
}

/******************************************************************************
     Description: Returns the parent of the input hierarchy item. The parent 
                  may be a folder, or a superproject or the solution.
           oProj: Project object
******************************************************************************/
function getParent(obj)
{
    var parent = obj.Collection.parent;
    //
    // is obj a project ?
    //
    if( parent == dte )
    {
        //
        // is obj a sub-project ?
        //
        if( IsSubProject(obj) )
        {                
            parent = obj.ParentProjectItem.Collection.parent;
        }
        else
        {
            //
            // obj is a top-level project
            //
            parent = null;
        }
    }
    return parent;    
}

function IsSubProject(oProj)
{
    try
    {
        var Parent = oProj.ParentProjectItem;
        if(Parent)
            return true;
        return false;
    }
    catch(e)
    {
        return false;
    }
}

/******************************************************************************
 Description: Gets the UIHierarchyItem for the projectitem, sName. If 
              sName is empty, returns the UIHierarchyItem for the project.
       oProj: Project object
       sName: Project item name
******************************************************************************/
function GetUIItem( oProj, sName )
{
	if( sName != "" )
	{
		sSaveName = sName;
		sName = oProj.Name + "\\" + sSaveName;
	}
	else
	{
		sName = oProj.Name;
	}

	var parent = getParent( oProj );

	while( parent != null )
	{
		sSaveName = sName;
		sName = parent.Name + "\\" + sSaveName;
		parent = getParent( parent );

	}

	//
	// we have arrived at the top of the soltuion explorer hierarchy - return the sName index into the solution's UIHierarchyItem collection
	//
	var strSolutionName = dte.Solution.Properties("Name");
	var vsHierObject = dte.Windows.Item(vsWindowKindSolutionExplorer).Object;   
	return vsHierObject.GetItem( strSolutionName + "\\" + sName );
}

/******************************************************************************
 description: returns true if this path is a root web project
		strProjectPath: path to the web proj
******************************************************************************/
function ProjectIsARootWeb(strProjectPath)
{
    // Returns true if strProjectPath is a root web. Is does this by counting
    // the forward slashes. Web roots are of the form: http://server. Assuming
    // no trailing slash, a web root will have 2 forward slashes, non webroots will
    // have 3 or more slashes. 
    var nCntr = 0;
    var cSlashes = 0;
    var nLen = strProjectPath.length - 1;   // Ignore last character
    for (nCntr = 0; nCntr < nLen; nCntr++)
    {
        // Count the forward slashes
        if(strProjectPath.charAt(nCntr) == "/")
            cSlashes++;
    }
    
    if(cSlashes == 2)
        return true;
    return false;
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function IsReferencesNodeExpanded(oProj)
{
	UIItem = GetUIReferencesNode(oProj);
	if(UIItem.Expanded == true)
		return true;
	return false;
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function CollapseReferencesNode(oProj)
{
	UIItem = GetUIReferencesNode(oProj);
	UIItem.Expanded = false;
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function GetCSharpReferenceManager(oProj)
{
	var VSProject = oProj.Object;
	var refmanager = VSProject.References;
	return refmanager;
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForClass(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Data");
	refmanager.Add("System.XML");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForComponent(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForInstaller(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Management");
	refmanager.Add("System.Configuration.Install");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForControl(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Data");
	refmanager.Add("System.Drawing");
	refmanager.Add("System.Windows.Forms");
	refmanager.Add("System.XML");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForWinForm(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Data");
	refmanager.Add("System.Drawing");
	refmanager.Add("System.Windows.Forms");
	refmanager.Add("System.XML");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForWinService(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Data");
	refmanager.Add("System.ServiceProcess");
	refmanager.Add("System.XML");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForWebService(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Data");
	refmanager.Add("System.Web");
	refmanager.Add("System.Web.Services");
	refmanager.Add("System.XML");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForWebForm(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Drawing");
	refmanager.Add("System.Data");
	refmanager.Add("System.Web");
	refmanager.Add("System.XML");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
******************************************************************************/
function AddReferencesForWebControl(oProj)
{
	var refmanager = GetCSharpReferenceManager(oProj);
	var bExpanded = IsReferencesNodeExpanded(oProj)
	refmanager.Add("System");
	refmanager.Add("System.Drawing");
	refmanager.Add("System.Web");
	if(!bExpanded)
		CollapseReferencesNode(oProj);
}

/******************************************************************************
 Description: 
       oProj: Project object
    itemName:
******************************************************************************/
function SetStartupPage(oProj, itemName)
{
	var configs = new Enumerator(oProj.ConfigurationManager);
	for(;!configs.atEnd();configs.moveNext())
	{
		configs.item().Properties("StartPage").Value = itemName;
	}
}

/******************************************************************************
    Description: Adds all the files to the project based on the Templates.inf file.
          oProj: Project object
 strProjectName: Project name
 strProjectPath: Project path
        InfFile: Templates.inf file object
    AddItemFile: Wether the wizard is invoked from the Add Item Dialog or not
******************************************************************************/
function AddFilesToCSharpProject(oProj, strProjectName, strProjectPath, InfFile, AddItemFile)
{
	try
	{
		dte.SuppressUI = false;
		var projItems;
		if(AddItemFile)
	  	    projItems = oProj;
		else
	  	    projItems = oProj.ProjectItems;

		var strTemplatePath = wizard.FindSymbol("TEMPLATES_PATH");

		var strTpl = "";
		var strName = "";

		// if( Not a web project )
		if(strProjectPath.charAt(strProjectPath.length - 1) != "\\")
		    strProjectPath += "\\";	

		var strTextStream = InfFile.OpenAsTextStream(1, -2);
		while (!strTextStream.AtEndOfStream)
		{
			strTpl = strTextStream.ReadLine();
			if (strTpl != "")
			{
				strName = strTpl;
				var strTarget = "";
				var strFile = "";
				if(!AddItemFile)
				{
					strTarget = GetCSharpTargetName(strName, strProjectName);
				}
				else
				{
					strTarget = wizard.FindSymbol("ITEM_NAME");
				}

				var fso;
				fso = new ActiveXObject("Scripting.FileSystemObject");
				var TemporaryFolder = 2;
				var tfolder = fso.GetSpecialFolder(TemporaryFolder);
				var strTempFolder = fso.GetAbsolutePathName(tfolder.Path);

				var strFile = strTempFolder + "\\" + fso.GetTempName();

				var strClassName = strTarget.split(".");
				wizard.AddSymbol("SAFE_CLASS_NAME", strClassName[0]);
	    			wizard.AddSymbol("SAFE_ITEM_NAME", strClassName[0]);

				var strTemplate = strTemplatePath + "\\" + strTpl;
				var bCopyOnly = false;
				var strExt = strTpl.substr(strTpl.lastIndexOf("."));
				if(strExt==".bmp" || strExt==".ico" || strExt==".gif" || strExt==".rtf" || strExt==".css")
					bCopyOnly = true;
				wizard.RenderTemplate(strTemplate, strFile, bCopyOnly, true);

				var projfile = projItems.AddFromTemplate(strFile, strTarget);
				SafeDeleteFile(fso, strFile);
				
				if(projfile)
					SetFileProperties(projfile, strName);

				var bOpen = false;
				if(AddItemFile)
					bOpen = true;
				else if (DoOpenFile(strTarget))
					bOpen = true;

				if(bOpen)
				{
					var window = projfile.Open(vsViewKindPrimary);
					window.visible = true;
				}
			}
		}
		strTextStream.Close();
	}
	catch(e)
	{
		strTextStream.Close();
		throw e;
 	}
}

/******************************************************************************
    Description: Adds a designer file to the project.
          oProj: Project object
 strProjectName: Project name
 strProjectPath: Project path
strDesignerFile: Designer file name
    AddItemFile: Wether the wizard is invoked from the Add Item Dialog or not
******************************************************************************/
function AddDesignerFileToCSharpWebProject(oProj, strProjectName, strProjectPath, strDesignerFile, AddItemFile)
{
	dte.SuppressUI = false;
	var projItems;
	if(AddItemFile)
		projItems = oProj;
	else
		projItems = oProj.ProjectItems;

	var strTemplatePath = wizard.FindSymbol("TEMPLATES_PATH");

	var strTpl = "";
	var strName = "";

	if (strDesignerFile != "")
	{
		strName = strDesignerFile;
		var strTarget;
		if(!AddItemFile)
		{
			strTarget = GetCSharpTargetName(strName, strProjectName);
		}
		else
		{
			strTarget = wizard.FindSymbol("ITEM_NAME");
		}
		var strClassName = strTarget.split(".");
		wizard.AddSymbol("SAFE_CLASS_NAME", strClassName[0]);
		wizard.AddSymbol("SAFE_ITEM_NAME", strClassName[0]);

		var strTemplate = strTemplatePath + "\\" + strDesignerFile;
		var projfile = projItems.AddFromTemplate(strTemplate, strTarget);
		if(projfile)
			SetFileProperties(projfile, strName);

		var bOpen = false;
		if(AddItemFile)
			bOpen = true;
		else if (DoOpenFile(strTarget))
			bOpen = true;

		if(bOpen)
		{
			var window = projfile.Open(vsViewKindPrimary);
			if(window)
				window.visible = true;
		}
	}
}

/******************************************************************************
 Description: Validate the value of the wizard combo control as a CSharp type.
     oObject: The wizard editable combo control
******************************************************************************/
function ValidateWizComboCSharpType(oObject, strName)
{
	var bValid;
	if(typeof(strName) == "undefined")
		strName = oObject.id;
	if (oObject.ListIndex > -1)
	{
		bValid = true;
	}
	else if(""==oObject.value)
	{
		L_ValidateCSharpTypeEEmpty_Text = " cannot be empty.";
		window.external.ReportError(strName + L_ValidateCSharpTypeEEmpty_Text);
		bValid = false;
	}
	else if ( !window.external.ValidateCLRIdentifier(oObject.value) )
	{
		L_ValidateCSharpType_E_INVALID_TEXT = "Invalid ";
		L_PERIOD_TEXT = ".";
		window.external.ReportError(L_ValidateCSharpType_E_INVALID_TEXT + strName + L_PERIOD_TEXT);	
		bValid = false;
	}
	else
		bValid = true;
	return bValid;
}

/******************************************************************************
 Description: Validate the value of the control as a valid CSharp name.
     oObject: The reference to control
     strName: Control name used by message
******************************************************************************/
function ValidateCSharpName(oObject, strName)
{
	var bValid;
	if(typeof(strName) == "undefined")
		strName = oObject.id;

	if(""==oObject.value)
	{
		L_ValidateCSharpNameEEmpty_Text = " cannot be empty.";
		window.external.ReportError(strName + L_ValidateCSharpNameEEmpty_Text);
		bValid = false;
	}
	else if ( !window.external.ValidateCLRIdentifier(oObject.value) )
	{
		L_ValidateCSharpName_E_INVALID_TEXT = "Invalid ";
		L_PERIOD_TEXT = ".";
		window.external.ReportError(L_ValidateCSharpName_E_INVALID_TEXT + strName + L_PERIOD_TEXT);	
		bValid = false;
	}
	else
		bValid = true;
	return bValid;
}

/******************************************************************************
 Description: Gets the current selected project items from the selection 
                 object if it was passed from Solution Explorer.
     oObject: The wizard context object
******************************************************************************/
function SetTargetFullPath(oObject)
{
	var parent = oObject.Parent;
	var kind = parent.Kind;
	var strFilePath = "";
	var strNameSpace = "";
	if(kind == GUID_ItemType_PhysicalFolder || kind == GUID_ItemType_VirtualFolder)
	{
		strFilePath = parent.FileNames(1);
		strNameSpace = parent.Properties("DefaultNamespace").Value;
	}
	else
	{
		strFilePath = 	wizard.FindSymbol("PROJECT_PATH");
		strNameSpace = parent.Properties("RootNamespace").Value;
	}
	wizard.AddSymbol("SAFE_NAMESPACE_NAME",  strNameSpace);
	wizard.AddSymbol("TARGET_FULLPATH",  strFilePath);
}

/******************************************************************************
 Description: Strip spaces from a string
       strin: The string (is in/out param)
******************************************************************************/
function TrimStr(str)
{
	var nLength = str.length;
	var nStartIndex = 0;
	var nEndIndex = nLength-1;

	while (nStartIndex < nLength && (str.charAt(nStartIndex) == ' ' || str.charAt(nStartIndex) == '\t'))
		nStartIndex++;
		
	while (nEndIndex > nStartIndex && (str.charAt(nEndIndex) == ' ' || str.charAt(nEndIndex) == '\t'))
		nEndIndex--;
	
	return str.substring(nStartIndex, nEndIndex+1);
}

/******************************************************************************
 Description: Open the file that contains the TextPoint, then move the cursor to the 
			  TextPoint.
         oTP: The reference to TextPoint
******************************************************************************/
function ShowTextPoint(oTP)
{
	try
	{
		oTP.Parent.Parent.ProjectItem.Open(vsViewKindCode).Visible = true;
		var oSel = oTP.Parent.Selection;
		oSel.MoveToPoint(oTP);
		oSel.ActivePoint.TryToShow(vsPaneShowHow.vsPaneShowAsIs);
	}
	catch(e)
	{
		throw(e);
	}
}

/******************************************************************************
 Description: Add the default target schema. 
         
******************************************************************************/
function AddDefaultTargetSchemaToWizard(selProj)
{
    var prjTargetSchema = selProj.Properties("DefaultTargetSchema").Value;
    // 0 = IE3/Nav4
    // 1 = IE5
    // 2 = Nav4
    if(prjTargetSchema == 0)
    {
        wizard.AddSymbol("DEFAULT_TARGET_SCHEMA", "http://schemas.microsoft.com/intellisense/ie3-2nav3-0");
    }
    else if( prjTargetSchema == 2)
    {
        wizard.AddSymbol("DEFAULT_TARGET_SCHEMA", "http://schemas.microsoft.com/intellisense/nav4-0");
    }
    else
    {
        wizard.AddSymbol("DEFAULT_TARGET_SCHEMA", "http://schemas.microsoft.com/intellisense/ie5");
    }
}

/******************************************************************************
 Description: Delete file using file system object. 
******************************************************************************/
function SafeDeleteFile( fso, strFilespec )
{
	if (fso.FileExists(strFilespec))
	{
		var tmpFile = fso.GetFile(strFilespec);
		tmpFile.Delete();
	}
}

// check if file exists in project already
function DoesFileExistInProj(oProj, sName )
{
    try
    {
        return oProj.ProjectItems.Item(sName);

    }	
    catch(e)
    {
        return null;
    }
}
