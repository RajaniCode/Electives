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


using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;

namespace [!output SAFE_NAMESPACE_NAME]
{
	public class [!output SAFE_CLASS_NAME] : System.ServiceProcess.ServiceBase
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public [!output SAFE_CLASS_NAME]()
		{
			// This call is required by the Windows.Forms Component Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitComponent call
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			this.ServiceName = "[!output SAFE_CLASS_NAME]";
		}
		#endregion

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing ) 
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		/// <summary>
		/// Set things in motion so your service can do its work.
		/// </summary>
		protected override void OnStart(string[] args)
		{
			// TODO: Add code here to start your service.
		}
 
		/// <summary>
		/// Stop this service.
		/// </summary>
		protected override void OnStop()
		{
			// TODO: Add code here to perform any tear-down necessary to stop your service.
		}
		
		#region [!output SAFE_CLASS_NAME]  Member Methods
        
        // add member methods here
        
        #endregion
        
        #region [!output SAFE_CLASS_NAME]  Properties and Fields
        
        // add member properties and associated fields here
        
        #endregion Properties and Fields
	}
}
