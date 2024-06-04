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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace [!output SAFE_NAMESPACE_NAME]
{
	/// <summary>
	/// Summary description for [!output SAFE_CLASS_NAME].
	/// </summary>
	public class [!output SAFE_CLASS_NAME] : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public [!output SAFE_CLASS_NAME]()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.Size = new System.Drawing.Size(300,300);
			this.Text = "[!output SAFE_CLASS_NAME]";
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
