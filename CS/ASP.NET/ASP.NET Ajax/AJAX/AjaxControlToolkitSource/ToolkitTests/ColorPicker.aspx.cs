// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Permissive License.
// See http://www.microsoft.com/resources/sharedsource/licensingbasics/sharedsourcelicenses.mspx.
// All other rights reserved.

using System;
using System.Web.UI;

public partial class Automated_ColorPicker : Page
{
    protected void Page_Init(object sender, EventArgs e)
    {
        ScriptManager scriptManager = ScriptManager.GetCurrent(this);
        scriptManager.EnableScriptLocalization = true;
        scriptManager.EnableScriptGlobalization = true;
    }
}