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
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace [!output SAFE_NAMESPACE_NAME]
{
	/// <summary>
	/// Summary description for [!output SAFE_CLASS_NAME].
	/// </summary>
	public class [!output SAFE_CLASS_NAME] : System.Windows.Forms.UserControl
	{
		/// <summary> 
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public [!output SAFE_CLASS_NAME]()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call

		}

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
		}
		#endregion
		
		#region [!output SAFE_CLASS_NAME]  Member Methods
        
        // add member methods here
        
        #endregion
        
        #region [!output SAFE_CLASS_NAME]  Properties and Fields
        
        // add member properties and associated fields here
        
        #endregion Properties and Fields
	}
}
