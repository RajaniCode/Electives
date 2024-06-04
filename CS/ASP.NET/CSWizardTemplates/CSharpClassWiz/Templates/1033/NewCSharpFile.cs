#region File Info
///
///[!output SAFE_NAMESPACE_NAME].[!output SAFE_CLASS_NAME]
///Property of <Your Company Name>
///Template Created by Muneeb R. Baig
///
///Created by <YOUR NAME HERE>
///On [!output CREATION_DATE]
///
#endregion File Info
#region File History
///$Revision: 												$
///$History:												$
///
///
#endregion File History


[!if !ADD_CLASS_MERGE]
using System;

namespace [!output CLASS_NAMESPACE]
{
[!endif]
	/// <summary>
	/// [!output COMMENT]
	/// </summary>
[!if ABSTRACT]
	[!output ACCESS_STRING] abstract class [!output CLASS_NAME][!output BASE_INTERFACE_NAME_STRING]
[!else]
[!if SEALED]
	[!output ACCESS_STRING] sealed class [!output CLASS_NAME][!output BASE_INTERFACE_NAME_STRING]
[!else]
	[!output ACCESS_STRING] class [!output CLASS_NAME][!output BASE_INTERFACE_NAME_STRING]
[!endif]
[!endif]
	{
		[!output ACCESS_STRING] [!output CLASS_NAME]()
		{
			// 
			// TODO: Add constructor logic here
			//
		}
		
		#region [!output SAFE_CLASS_NAME]  Member Methods
        
        // add member methods here
        
        #endregion
        
        #region [!output SAFE_CLASS_NAME]  Properties and Fields
        
        // add member properties and associated fields here
        
        #endregion Properties and Fields
	}
	
[!if !ADD_CLASS_MERGE]
}
[!endif]
