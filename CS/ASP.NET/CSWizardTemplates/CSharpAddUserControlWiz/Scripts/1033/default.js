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
		var strTarget = wizard.FindSymbol("ITEM_NAME");
		var strClassName = strTarget.split(".");
		var bValid = wizard.ValidateCLRIdentifier(strClassName[0]);
		if (!bValid)
		{
			wizard.ReportError();
			return VS_E_WIZARDBACKBUTTONPRESS;
		}
        oldSuppressUIValue = dte.SuppressUI;
		var strProjectName		= wizard.FindSymbol("PROJECT_NAME");
		var strSafeProjectName = CreateSafeName(strProjectName);
		wizard.AddSymbol("SAFE_PROJECT_NAME", strSafeProjectName);
				
		// add CreationDate() call    
    	CreationDate();
    	//
		
		SetTargetFullPath(selObj);
		var strProjectPath		= wizard.FindSymbol("TARGET_FULLPATH");
		var strTemplatePath		= wizard.FindSymbol("TEMPLATES_PATH");

		var strTpl = "";
		var strName = "";
		var InfFile = CreateInfFile();
		AddReferencesForControl(selProj);
		AddFilesToCSharpProject(selObj, strProjectName, strProjectPath, InfFile, true);
	}
	catch(e)
	{
		if( e.description.length > 0 )
			SetErrorInfo(e);
		return e.number;
	}
    finally
    {
   		dte.SuppressUI = oldSuppressUIValue;
   		if( InfFile )
			InfFile.Delete();
    }
}

function SetFileProperties(oFileItem, strFileName)
{
    if(strFileName == "UserControl.cs")
    {
        oFileItem.Properties("SubType").Value = "UserControl";
    }
}

