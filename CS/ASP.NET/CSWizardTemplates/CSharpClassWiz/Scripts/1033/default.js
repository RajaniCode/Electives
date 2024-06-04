// (c) Microsoft Corporation
// created by Michael Groeger
function CreationDate()
{
       var Months = new Array("JAN","FEB","MAR","APR","MAY","JUN",
                "JUL","AUG","SEP","OCT","NOV","DEC");
    var myDate = new Date();
    var currentDate = 
    myDate.getFullYear()
    +Months[myDate.getMonth()]    
    +myDate.getDate();
    
    wizard.AddSymbol("CREATION_DATE",currentDate);
}

function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
	try
	{
		var bMerge = wizard.FindSymbol("ADD_CLASS_MERGE");	
		if(bMerge) 
		{
			var strNamespace = wizard.FindSymbol("CLASS_NAMESPACE");
			var strClass = wizard.FindSymbol("CLASS_NAME");
			var strFileName = wizard.FindSymbol("FILENAME");
			var oFCM = selProj.ProjectItems.Item(strFileName).FileCodeModel;
			var oNS;
			try
			{
				oNS = oFCM.CodeElements.Item(strNamespace);
			}
			catch (e)
			{
				oNS = oFCM.AddNamespace(strNamespace);
			}
			var strTemplatePath = wizard.FindSymbol("TEMPLATES_PATH");
			var strTemplate = strTemplatePath + "\\" + "NewCSharpFile.cs";
			strClass = wizard.RenderTemplateToString(strTemplate);
			var epNS = oNS.StartPoint.CreateEditPoint();
			epNS.LineDown(2);
			epNS.Insert(strClass);	
			
			// add CreationDate() call    
	    	CreationDate();
	    	//
		
		}
		else 
		{		
			oldSuppressUIValue = dte.SuppressUI;
			var strProjectName 	= wizard.FindSymbol("PROJECT_NAME");
			var strSafeProjectName 	= CreateSafeName(strProjectName);
			wizard.AddSymbol("SAFE_PROJECT_NAME", strSafeProjectName);
			
			// add CreationDate() call    
	    	CreationDate();
	    	//
		
			var projItems = selProj.ProjectItems;
			SetTargetFullPath(projItems);
			var strProjectPath	= wizard.FindSymbol("TARGET_FULLPATH");

			var strTpl = "";
			var strName = "";
			
			var InfFile = CreateInfFile();
			AddFilesToCSharpProject(projItems, strProjectName, strProjectPath, InfFile, true);
			InfFile.Delete();
		}
	}
	catch(e)
	{
		wizard.ReportError(e.description);
	}
    finally
    {
   		dte.SuppressUI = oldSuppressUIValue;
    }
}


function GetCSharpTargetName(strName, strProjectName)
{
	var strTarget = strName;

	if (strName == "NewCSharpClass.cs")
		strTarget = wizard.FindSymbol("FILENAME");

	return strTarget; 
}

function DoOpenFile(strName)
{
	var bOpen = false;
    
	if (strName == wizard.FindSymbol("FILENAME"))
		bOpen = true;

	return bOpen; 
}

function SetFileProperties(oFileItem, strFileName)
{
}
