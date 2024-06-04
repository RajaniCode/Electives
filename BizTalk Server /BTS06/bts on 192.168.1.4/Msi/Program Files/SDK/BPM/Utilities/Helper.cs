//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
// Helper classes
//  
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Xml;
using System.Diagnostics;
using System.Configuration.Install;
using System.ComponentModel;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
{
    /// <summary>
    /// Creates the event log source for the ErrorHandler.
    /// Run InstallUtil against this assembly to install.
    /// </summary>
    [RunInstaller(true)]
    public class MyEventLogInstaller : Installer
    {
        private EventLogInstaller myEventLogInstaller;

        public MyEventLogInstaller()
        {
            // Create an instance of an EventLogInstaller.
            myEventLogInstaller = new EventLogInstaller();

            // Set the Source name of the event log.
            myEventLogInstaller.Source = ErrorHandler.Source;

            // Add myEventLogInstaller to the Installer collection.
            Installers.Add(myEventLogInstaller);
        }
    }

    /// <summary>
	/// Helper methods
	/// </summary>
	public sealed class HelperMethods
	{
        const int MaxTruncatedLength = 255;

        private HelperMethods() {}

		/// <summary>
		/// Inserts the orderDoc as an XML string into the OriginalMsg node of SQLHistoryInsert schema
		/// </summary>
		/// <param name="orderDoc">xml to be inserted</param>
		/// <param name="historyInsertDoc">SQLHistoryInsert schema message that gets orderDoc inserted into</param>
		/// <returns>historyInsertDoc with orderDoc inserted as a string to the OriginalMsg node</returns>
        public static XmlDocument InsertOrderBody( XmlDocument orderDoc, XmlDocument historyInsertDoc )
		{
			// Validate parameters
            if (null == orderDoc)
            {
                throw new ArgumentNullException("orderDoc");
            }

            if (null == historyInsertDoc)
            {
                throw new ArgumentNullException("historyInsertDoc");
            }

            XmlNode root = historyInsertDoc.FirstChild;

			//Create a new attribute.
			//string ns = root.GetNamespaceOfPrefix("ns0");
			XmlNode attr = historyInsertDoc.CreateNode(XmlNodeType.Attribute, "OriginalMsg", root.NamespaceURI);
			attr.Value = orderDoc.OuterXml;

			try
			{
                XmlNode destnode = historyInsertDoc.SelectSingleNode("/*[local-name()='HistoryInsert']/*[local-name()='sync']/*[local-name()='after']/*[local-name()='OrderLog']");
                //Add the attribute to the document.
				destnode.Attributes.SetNamedItem(attr);
			}
			catch(Exception ex)
			{
				// couldn't find node
                string message = "Couldn't create node for message body";
                throw new ArgumentException(message, "historyInsertDoc", ex);
			}

			return historyInsertDoc;
		}

        /// <summary>
        /// Truncates a string to MaxTruncatedLength characters
        /// </summary>
        /// <param name="message">string to truncate</param>
        /// <returns>truncated string</returns>
        public static string Truncate(string message)
        {
            string truncatedMsg = message;
            if (!string.IsNullOrEmpty(message) && message.Length > MaxTruncatedLength)
            {
                truncatedMsg = message.Substring(0, MaxTruncatedLength);
            }

            return truncatedMsg;
        }

        /// <summary>
        /// Determines whether or not the message is larger than 255 characters
        /// </summary>
        /// <param name="message">message to evaluate</param>
        /// <returns>the message if it's greater than 255 characters otherwise an empty string</returns>
        public static string GetIfLarge(string message)
        {
            string largeMessage = string.Empty;
            if (!string.IsNullOrEmpty(message) && message.Length > 255)
            {
                largeMessage = message;
            }
            return largeMessage;
        }
	}

	/// <summary>
	/// Static class that helps with event log entries
	/// </summary>
    public sealed class ErrorHandler
	{
		public const string Source = "SouthridgeVideo";

        private ErrorHandler() { }

        /// <summary>
        /// Post an error to the event log
        /// </summary>
        /// <param name="error">Error to post</param>
        public static void PostError( string error )
		{
			EventLog.WriteEntry( Source, error, EventLogEntryType.Error );
		}
		
		/// <summary>
		/// Post a warning to the event log
		/// </summary>
		/// <param name="warning">Warning to post</param>
        public static void PostWarning( string warning )
		{
			EventLog.WriteEntry( Source, warning, EventLogEntryType.Warning );
		}
	}
}
