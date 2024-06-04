using System;
using System.Configuration;
using System.Web;

namespace Hyper.Web.Security
{
	/// <summary>
	/// The SecureWebPageModule class hooks the application's BeginRequest event
	/// in order to request the current page securely if specified in the 
	/// configuration file.
	/// </summary>
	public class SecureWebPageModule : IHttpModule
	{
		/// <summary>
		/// Initializes an instance of this class.
		/// </summary>
		public SecureWebPageModule()
		{
		}

		/// <summary>
		/// Disposes of any resources used.
		/// </summary>
		public void Dispose()
		{
			// No resources were used.
		}

		/// <summary>
		/// Initializes the module by hooking the application's BeginRequest event.
		/// </summary>
		/// <param name="Application">The HttpApplication this module is bound to.</param>
		public void Init(HttpApplication Application)
		{
			// Add a reference to the private Application_BeginRequest handler to the
			// application's BeginRequest event
			Application.BeginRequest += (new EventHandler(this.Application_BeginRequest));
		}


		/// <summary>
		/// Handle the application's BeginRequest event by requesting the current
		/// page securely, if specified.
		/// </summary>
		/// <param name="source">The source of the event.</param>
		/// <param name="e">EventArgs passed in.</param>
		private void Application_BeginRequest(Object source, EventArgs e) 
		{
			// Get the settings for the secureWebPages section
			SecureWebPageSettings Settings = (SecureWebPageSettings)ConfigurationSettings.GetConfig("secureWebPages");

			if (Settings != null && Settings.Enabled)
			{
				// Cast the source as an HttpApplication instance
				HttpApplication Application = (HttpApplication)source;

				// Get the relative file path of the current request from the application root
				string RelativeFilePath = Application.Request.Url.AbsolutePath.Remove(0, Application.Request.ApplicationPath.Length).ToLower();
				if (!RelativeFilePath.StartsWith("/"))
					// Add a leading "/"
					RelativeFilePath = "/" + RelativeFilePath;

				// Intialize the flags
				bool MakeSecure = false;
				bool Ignore = false;

				// Determine if there is a matching file path for the current request
				int i = Settings.SecureFiles.IndexOf(RelativeFilePath);
				if (i >= 0)
				{
					MakeSecure = true;
					Ignore = Settings.SecureFiles[i].Ignore;
				}

				// Try to find a matching directory path, if no file was found
				i = 0;
				while (!MakeSecure && i < Settings.SecureDirectories.Count)
				{
					MakeSecure = (RelativeFilePath.StartsWith(Settings.SecureDirectories[i].Path.ToLower()));
					Ignore = Settings.SecureDirectories[i].Ignore;
					i++;
				}

				// Test for the ignore flag
				if (!Ignore)
				{
					// Request a secure/unsecure page as needed
					if (MakeSecure)
						SSLHelper.RequestSecurePage();
					else
						SSLHelper.RequestUnsecurePage();
				}
			}
		}
	}
}
