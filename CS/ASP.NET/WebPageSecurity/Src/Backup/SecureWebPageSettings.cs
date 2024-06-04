using System;
using System.Collections.Specialized;

namespace Hyper.Web.Security
{
	/// <summary>
	/// SecureWebPageSettings contains the settings of a secureWebPages configuration section.
	/// </summary>
	public class SecureWebPageSettings
	{
		// Fields
		private bool enabled = true;
		private SecureWebPageCollection secureDirectories;
		private SecureWebPageCollection secureFiles;


		/// <summary>
		/// Gets a flag indicating whether the secure web page settings are enabled or not.
		/// </summary>
		public bool Enabled
		{
			get { return enabled; }
			set { enabled = value; }
		}

		/// <summary>
		/// Gets the collection of directories read from the configuration section.
		/// </summary>
		public SecureWebPageCollection SecureDirectories
		{
			get { return secureDirectories; }
		}

		/// <summary>
		/// Gets the collection of files read from the configuration section.
		/// </summary>
		public SecureWebPageCollection SecureFiles
		{
			get { return secureFiles; }
		}

		/// <summary>
		/// The default constructor creates the needed lists.
		/// </summary>
		public SecureWebPageSettings()
		{
			// Create the collections
			secureDirectories = new SecureWebPageCollection();
			secureFiles = new SecureWebPageCollection();
		}
	}
}
