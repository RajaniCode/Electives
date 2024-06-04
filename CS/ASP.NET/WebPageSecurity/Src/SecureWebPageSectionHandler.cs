using System;
using System.Collections.Specialized;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Xml;

namespace Hyper.Web.Security
{
	/// <summary>
	/// The exception thrown for any errors while reading the secureWebPages 
	/// section of a configuration file.
	/// </summary>
	public class SecureWebPageSectionException : System.Configuration.ConfigurationException
	{
		/// <summary>
		/// Intializes an instance of this exception.
		/// </summary>
		public SecureWebPageSectionException()
		{
		}

		/// <summary>
		/// Initializes an instance of this exception with specified parameters.
		/// </summary>
		/// <param name="Message">The message to display to the client when the exception is thrown.</param>
		/// <param name="Node">The XmlNode that contains the error.</param>
		public SecureWebPageSectionException(string Message, XmlNode Node) : base(Message, Node)
		{
		}
	}


	/// <summary>
	/// SecureWebPageSectionHandler reads any <secureWebPages> section from a configuration file.
	/// </summary>
	public class SecureWebPageSectionHandler : IConfigurationSectionHandler
	{
		/// <summary>
		/// Initializes an instance of this class.
		/// </summary>
		public SecureWebPageSectionHandler()
		{
		}

		/// <summary>
		/// Parses the XML configuration section and returns the settings.
		/// </summary>
		/// <param name="parent">
		///		The configuration settings in a corresponding parent 
		///		configuration section.
		/// </param>
		/// <param name="configContext">
		///		An HttpConfigurationContext when Create is called from the ASP.NET 
		///		configuration system. Otherwise, this parameter is reserved and is 
		///		a null reference (Nothing in Visual Basic).
		/// </param>
		/// <param name="section">
		///		The XmlNode that contains the configuration information from the 
		///		configuration file. Provides direct access to the XML contents of 
		///		the configuration section.
		/// </param>
		/// <returns></returns>
		public object Create(object parent, object configContext, XmlNode section)
		{
			// Create a SecureWebPageSettings object for the settings in this section
			SecureWebPageSettings Settings = new SecureWebPageSettings();

			// Get the enabled attribute
			if (section.Attributes["enabled"] != null)
			{
				Settings.Enabled = (section.Attributes["enabled"].Value.ToLower() != "false");
			}

			// Traverse the child nodes
			SecureWebPageCollection SecurePathList;
			string Path;
			bool Ignore;
			foreach (XmlNode Item in section.ChildNodes)
			{
				if (Item.NodeType == System.Xml.XmlNodeType.Comment)
					// Skip comment nodes (thanks to dcbrower on CodeProject for pointing this out)
					continue;
				else if (Item.Name.ToLower() == "directory")
					// This is a directory path node
					SecurePathList = Settings.SecureDirectories;
				else if (Item.Name.ToLower() == "file")
					// This is a file path node
					SecurePathList = Settings.SecureFiles;
				else
					// Throw an exception for this unrecognized node
					throw new SecureWebPageSectionException(string.Format("'{0}' is not an acceptable setting.", Item.Name), Item);
			
				// Get the path attribute value
				if (Item.Attributes["path"] != null && Item.Attributes["path"].Value.Trim().Length > 0)
				{
					// Get the value of the path attribute
					Path = Item.Attributes["path"].Value.Trim();

					// Add leading and trailing "/" characters where needed
					if (Path.Length > 1)
					{
						if (!Path.StartsWith("/"))
							Path = "/" + Path;
						if (SecurePathList == Settings.SecureDirectories && !Path.EndsWith("/"))
							Path += "/";
					}

					// Check for an ignore attribute
					if (Item.Attributes["ignore"] != null)
						Ignore = (Item.Attributes["ignore"].Value.Trim().ToLower() == "true");
					else
						Ignore = false;

					// Add the item to the collection
					SecurePathList.Add(new SecureWebPageItem(Path, Ignore));
				}
				else
					// Throw an exception for the missing Path attribute
					throw new SecureWebPageSectionException("'path' attribute not found.", Item);
			}

			// Return the settings
			return Settings;
		}
	}
}
