/******************************************************************************
Copyright (c) Microsoft Corporation.  All rights reserved.

THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED 
WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
THE ENTIRE RISK OF USE OR RESULTS IN CONNECTION WITH THE USE OF THIS CODE 
AND INFORMATION REMAINS WITH THE USER.
******************************************************************************/

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
        var strTemplateFile = strTemplatePath + "\\BTSApp.btproj"; 

        var project = CreateProject(strProjectName, ".btproj", strProjectPath, strTemplateFile);
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
