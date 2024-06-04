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
function AddDefaultServerScriptToWizard(selProj)
{
	wizard.AddSymbol("DEFAULT_SERVER_SCRIPT", "JavaScript");
}

function AddDefaultClientScriptToWizard(selProj)
{
    var prjScriptLang = selProj.Properties("DefaultClientScript").Value;
    // 0 = JScript
    // 1 = VBScript
    if(prjScriptLang == 0)
    {
        wizard.AddSymbol("DEFAULT_CLIENT_SCRIPT", "JavaScript");
    }
    else
    {
        wizard.AddSymbol("DEFAULT_CLIENT_SCRIPT", "VBScript");
    }
}

function AddDefaultDefaultHTMLPageLayoutToWizard(selProj)
{
    var prjPageLayout = selProj.Properties("DefaultHTMLPageLayout").Value;
    // 0 = FlowLayout
    // 1 = GridLayout
    if(prjPageLayout == 0)
    {
        wizard.AddSymbol("DEFAULT_HTML_LAYOUT", "FlowLayout");
    }
    else
    {
        wizard.AddSymbol("DEFAULT_HTML_LAYOUT", "GridLayout");
    }
}

function OnFinish(selProj, selObj)
{
    var oldSuppressUIValue = true;
	try
	{
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
		
		// add the default project props for the aspx file before we
		// render it
		AddDefaultServerScriptToWizard(selProj);
		AddDefaultClientScriptToWizard(selProj);
		AddDefaultTargetSchemaToWizard(selProj);
		AddDefaultDefaultHTMLPageLayoutToWizard(selProj);
		// render our file
		AddFilesToCSharpProject(selObj, strProjectName, strProjectPath, InfFile, true);
		AddReferencesForWebForm(selProj);
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
    if(strFileName == "WebForm1.aspx")
    {
        oFileItem.Properties("SubType").Value = "Form";
    }
}

