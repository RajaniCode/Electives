//
// Copyright (c) Microsoft Corporation. All rights reserved. 
//  
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
// THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
// AND INFORMATION REMAINS WITH THE USER. 
//
var newOrcFileName = "Action.odx";

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
         try
         {
            if( obj.ParentProjectItem )
               parent = obj.ParentProjectItem.Collection.parent;
            else
                  //
                  // obj is a top-level project
                  //
                  parent = null;
         }         
         catch(e)
         {
            parent = null;
         }
    }
    return parent;    
}

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

function GetUIReferencesNode(oProj)
{
        var L_strReferencesNode_Text = "References"; // This string needs to be localized
        var UIItemX = GetUIItem( oProj, L_strReferencesNode_Text);
        return UIItemX.UIHierarchyItems
}

function IsReferencesNodeExpanded(oProj)
{
	UIItem = GetUIReferencesNode(oProj);
	if(UIItem.Expanded == true)
		return true;
	return false;
}

function CollapseReferencesNode(oProj)
{
	UIItem = GetUIReferencesNode(oProj);
	UIItem.Expanded = false;
}

function AddReferences( proj, path )
{
	var refmanager = GetCSharpReferenceManager( proj );
	var bExpanded = IsReferencesNodeExpanded( proj );
			
	var oFSO = new ActiveXObject("Scripting.FileSystemObject");
	var folder = oFSO.GetFolder( path );
	
	if ( null == folder )
		return null;

	var files = new Enumerator( folder.files );
	
	if ( null == files )
		return null;			   
	//
	// Add all files
	for (; !files.atEnd(); files.moveNext())
	{
      refmanager.Add( files.item().path );
	}
	
	if(!bExpanded)
		CollapseReferencesNode( proj );
}

function GetCSharpReferenceManager(oProj)
{
	var VSProject = oProj.Object;
	var refmanager = VSProject.References;
	return refmanager;
}

function CreateActionFile( templatePath, templateName, templateNamespace, newNamespace )
{

	var fso, f, s;
	var ForReading = 1, ForWriting = 2;
	var templateFilePath = templatePath + "\\" + templateName;
	var newFilePath = templatePath + "\\" + newOrcFileName;	
	
	fso = new ActiveXObject("Scripting.FileSystemObject");
	//
	// Make sure that we have a clean slate
	if ( fso.FileExists( newFilePath ) )
		fso.DeleteFile( newFilePath, true );

	//
	// Have to copy the file in order to get the correct file type (utf-8)
	// Creating a new file as unicode or ansii (only options with fso)
	// doesn't work in the BTS ide - either the file can't be opened or compile fails
	fso.CopyFile( templateFilePath, newFilePath );
	//
	// Open the copied file and read all of the contents
	f = fso.OpenTextFile( newFilePath, ForReading );
	s='';
	s = f.ReadAll();		
	f.Close( );
	//
	// For some reason we're picking up the file format bytes
	// This isn't a problem on EN os/EN product installs but it is on JA os.
	// If the first char in the string isn't "#" drop the first
	// three bytes otherwise the BTS sees an incorrect file format	
	var i = 0;
	while( s.substr( i++, 2 ) != 'if' );
	s = "#" + s.substr( i-1 );
	//
	// 68626 - Map spaces to underscores in the namespace name
	re = / /g;
	newNamespace = newNamespace.replace( re, "_" );
	// Replace all instances of '"Template"', 'Template.' and ' Template '
	// with the namespace of the new project.  Looking specifically for these
	// instances of Template because there are other instances of this text we
	// don't want to change.
	re = /Template\./g;
	newContents = s.replace( re, newNamespace + "." );
	
	re = /\"Template\"/g;
	newContents = newContents.replace( re, "\"" + newNamespace + "\"" );
	
	re = /\bTemplate\b/g;
	newContents = newContents.replace( re, newNamespace );
	//
	// Write the new content to the existing file.  
	// Using the ForWriting will overwrite all existing content of the file
	// even if the new content is shorter than the old content (although
	// documentation is not entirely clear on this I added additional content
	// to the end of the action.odx file between the first read and this write.
	// this content was overwritten)
	f = fso.GetFile( newFilePath );
	ts = f.OpenAsTextStream( ForWriting, 0 );	
	ts.Write( newContents );
	ts.Close();
}

function CreateHwsProject(strProjectName, strProjectExt, strProjectPath, strTemplateFile)
{
	try
	{
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
		//
		// Does not look like AddFromTemplate actually copies any of the files
		// that are attached to the project.  We'll do that below.
		if (wizard.FindSymbol("WIZARD_TYPE") == vsWizardAddSubProject)  // vsWizardAddSubProject
		{
			var prjItem = oTarget.AddFromTemplate(strProjTemplate, strProjectPath + "\\" + strProjectNameWithExt);
			oProj = prjItem.SubProject;
		}
		else
		{
			oProj = oTarget.AddFromTemplate(strProjTemplate, strProjectPath, strProjectNameWithExt);
		}

		//
		// Now add all of the project files.
		var items = oProj.ProjectItems;
		
		if ( null == items )
			return null;
									
		var strProjTemplatePath = wizard.FindSymbol("TEMPLATES_PATH");
		var strProjTemplateDllPath = strProjTemplatePath + "\\..\\bin";
		var strProjectDllPath = strProjectPath + "\\bin";

		if (strProjTemplatePath != null)
		{
		   //
		   // Create the Action.odx file with the corrected namespace
		   CreateActionFile( strProjTemplatePath, "Template.odx", "Template", strProjectName );
		   //
		   // Add project files
		   items.AddFromFileCopy( strProjTemplatePath + "\\Hws_Activate.xsd" );
		   items.AddFromFileCopy( strProjTemplatePath + "\\Hws_Synchronize.xsd" );
		   items.AddFromFileCopy( strProjTemplatePath + "\\Hws_Task.xsd" );
		   items.AddFromFileCopy( strProjTemplatePath + "\\" + newOrcFileName );
			//
			// Copy and add dll references
			var oFSO = new ActiveXObject("Scripting.FileSystemObject");
			folder = oFSO.GetFolder( strProjTemplateDllPath );
			
			if ( null == folder )
			   return null;
			   
			folder.Copy( strProjectDllPath, true );
			
			AddReferences( oProj, strProjectDllPath );
		}
		else
		   return null;

		return oProj;
	}
	catch(e)
	{   
		throw e;
	}
}

function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
    try
    {
        oldSuppressUIValue = dte.SuppressUI;
        var bSilent = wizard.FindSymbol("SILENT_WIZARD");
        dte.SuppressUI = bSilent;

        var strProjectName = wizard.FindSymbol("PROJECT_NAME");
        var strProjectPath = wizard.FindSymbol("PROJECT_PATH");
        var strTemplatePath = wizard.FindSymbol("TEMPLATES_PATH");
        var strTemplateFile = strTemplatePath + "\\ProjectTemplate.btproj"; 

        var project = CreateHwsProject(strProjectName, ".btproj", strProjectPath, strTemplateFile);
        if( project )
        {
            strProjectName = project.Name;  //In case it got changed            
            project.Save();
        }
        
        return 0;
    }
    catch(e)
    {   
        switch(e.number)
        {
        case -2147024816 /* FILE_ALREADY_EXISTS */ :
            return -2147213313;
            
        case -2147467260 /* evaluation period expired */ :
            return -2147467260;

        default:
            SetErrorInfo(e);
            return e.number;
        }
    }
    finally
    {
        dte.SuppressUI = oldSuppressUIValue;
    }
}
