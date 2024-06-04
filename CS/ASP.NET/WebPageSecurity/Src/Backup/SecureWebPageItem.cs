using System;
using System.Collections;

namespace Hyper.Web.Security
{

	/// <summary>
	/// The SecureWebPageItemComparer class implements the IComparer interface to compare
	/// </summary>
	public class SecureWebPageItemComparer : IComparer
	{
		/// <summary>
		/// Initialize an instance of this class.
		/// </summary>
		public SecureWebPageItemComparer()
		{
		}

		/// <summary>
		/// Compares the two objects as string and SecureWebPageItem or both SecureWebPageItem 
		/// by the Path property.
		/// </summary>
		/// <param name="x">First object to compare.</param>
		/// <param name="y">Second object to compare.</param>
		/// <returns></returns>
		public int Compare(object x, object y)
		{
			// Check the type of the parameters
			if (!(x is SecureWebPageItem) && !(x is string))
				// Throw an exception for the first argument
				throw new ArgumentException("Parameter must be a SecureWebPageItem or a String.", "x");
			else if (!(y is SecureWebPageItem) && !(y is string))
				// Throw an exception for the second argument
				throw new ArgumentException("Parameter must be a SecureWebPageItem or a String.", "y");

			// Initialize the path variables
			string xPath = string.Empty;
			string yPath = string.Empty;

			// Get the path for x
			if (x is SecureWebPageItem)
				xPath = ((SecureWebPageItem) x).Path;
			else
				xPath = (string) x;

			// Get the path for y
			if (y is SecureWebPageItem)
				yPath = ((SecureWebPageItem) y).Path;
			else
				yPath = (string) y;

			// Compare the paths, ignoring case
			return string.Compare(xPath, yPath, true);
		}
	}


	/// <summary>
	/// The SecureWebPageItem class represents entries in the <secureWebPages> configuration section.
	/// </summary>
	public class SecureWebPageItem
	{
		// Fields
		private bool ignore = false;
		private string path = string.Empty;

		/// <summary>
		/// Gets or sets a flag indicating whether or not to ignore security for this directory or file.
		/// </summary>
		public bool Ignore
		{
			get { return ignore; }
			set { ignore = value; }
		}

		/// <summary>
		/// Gets or sets the path of this directory or file.
		/// </summary>
		public string Path
		{
			get { return path; }
			set { path = value; }
		}

		/// <summary>
		/// Creates an instance of this class.
		/// </summary>
		public SecureWebPageItem()
		{
		}

		/// <summary>
		/// Creates an instance with initial values.
		/// </summary>
		/// <param name="Path">The relative path to the directory or file.</param>
		/// <param name="Ignore">A flag to ignore security for the directory or file.</param>
		public SecureWebPageItem(string Path, bool Ignore)
		{
			// Initialize the path and ignore flag
			path = Path;
			ignore = Ignore;
		}

		/// <summary>
		/// Creates an instance with an initial path value.
		/// </summary>
		/// <param name="Path">The relative path to the directory or file.</param>
		public SecureWebPageItem(string Path) : this(Path, false)
		{
		}

	}
}
