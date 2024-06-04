//---------------------------------------------------------------------
// File:      PartyResolutionComponent.cs
// 
// Summary:   
//
// Sample:    Litware scenario
//
//---------------------------------------------------------------------
// This file is part of the Microsoft BizTalk Server 2006 SDK
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft BizTalk
// Server 2006 release and/or on-line documentation. See these other
// materials for detailed information regarding Microsoft code samples.
//
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
// KIND, WHETHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR
// PURPOSE.
//---------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Management;
using Microsoft.Win32;
using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.ExplorerOM;

using Microsoft.Samples.BizTalk.Litware.Utilities;

namespace Microsoft.Samples.BizTalk.Litware.PartyResolutionComponent
{
	/// <summary>
	/// Uses evidence from inbound message to determine SourcePartyID
	/// </summary>
	/// <remarks>
	/// This sample assumes that inbound messages contain a promoted property called SourceOrg.
	/// Queries the BizTalk Managment database to do a party ailias lookup to determine
	/// SourcePartyID (SID).   Once SourcePartyID and PartyName have been determined, 
	/// set them into the context of the message.
	/// </remarks>
	
	[ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
	[ComponentCategory(CategoryTypes.CATID_Any)]
	[ComponentCategory(CategoryTypes.CATID_PartyResolver)]
	[System.Runtime.InteropServices.Guid("48BEC85A-20EE-40ad-BFD0-319B59A0DDBC")]
	public class PartyResolutionFromSourceOrg : 
		IBaseComponent, 
		Microsoft.BizTalk.Component.Interop.IComponent,
		Microsoft.BizTalk.Component.Interop.IPersistPropertyBag,
		IComponentUI
	{
		private string prependData  = null;
		private string appendData   = null;
		private IBaseMessage mBaseMessage;
		
		public PartyResolutionFromSourceOrg()
		{
		}
		
		#region IBaseComponent
        
		/// <summary>
		/// Name of the component.
		/// </summary>
		[Browsable(false)]
		public string Name
		{
			get {   return "CustomPartyResolution Pipeline Component";  }
		}
        
		/// <summary>
		/// Version of the component.
		/// </summary>
		[Browsable(false)]
		public string Version
		{
			get {   return "1.0";   }
		}
        
		/// <summary>
		/// Description of the component.
		/// </summary>
		[Browsable(false)]
		public string Description
		{
			get {   return "Uses evidence from inbound message to determine SourcePartyID"; }
		}
    
		#endregion
        
		#region IComponent

		/// <summary>
		/// Implements IComponent.Execute method.
		/// </summary>
		/// <param name="pc">Pipeline context</param>
		/// <param name="inmsg">Input message.</param>
		/// <returns>Processed input message with appended or prepended data.</returns>
		/// <remarks>
		/// IComponent.Execute method is used to initiate
		/// the processing of the message in pipeline component.
		/// </remarks>
		public IBaseMessage Execute(IPipelineContext pContext, IBaseMessage pInMsg)
		{
			if (null == pContext) throw new ArgumentNullException("pContext", "Pipeline context can not be null");
			if (null == pInMsg) throw new ArgumentNullException("pInMsg", "Input message can not be null");
			IBaseMessage outmsg = pInMsg;
			//replace the default Stream class with our custom PartyResolutionStream, which provides callback notification
			//when various stream events occur.
			//In this case, we're only interested in knowing when the entire stream has been read, so a callback function is only 
			//provided for the LastReadOccurred event, the other events are not being used.
			Stream ThisPartyResolutionStream = new Microsoft.Samples.BizTalk.Litware.PartyResolutionComponent.PartyResolutionStream(pInMsg.BodyPart.Data, null, null, new Microsoft.Samples.BizTalk.Litware.PartyResolutionComponent.PartyResolutionStream.LastReadOccurred(EndOfStream));

			//Specify use of our PartyResoultionStream as the BodyPart.Data
			outmsg.BodyPart.Data = ThisPartyResolutionStream;
			mBaseMessage = outmsg;

			return outmsg;
		}
		#endregion

		#region IPersistPropertyBag
    
		/// <summary>
		/// Gets class ID of component for usage from unmanaged code.
		/// </summary>
		/// <param name="classid">Class ID of the component.</param>
		public void GetClassID(out Guid classID)
		{
			classID = new System.Guid("48BEC85A-20EE-40ad-BFD0-319B59A0DDBC");
		}
        
		/// <summary>
		/// Not implemented.
		/// </summary>
		public void InitNew()
		{
		}
        
		/// <summary>
		/// Loads configuration property for component.
		/// </summary>
		/// <param name="pb">Configuration property bag.</param>
		/// <param name="errlog">Error status (not used in this code).</param>
		public void Load(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, Int32 errorLog)
		{
			string val = (string)ReadPropertyBag(propertyBag, "AppendData");
			if (val != null) appendData = val;

			val = (string)ReadPropertyBag(propertyBag, "PrependData");
			if (val != null) prependData = val;
		}
        
		/// <summary>
		/// Saves the current component configuration into the property bag.
		/// </summary>
		/// <param name="pb">Configuration property bag.</param>
		/// <param name="fClearDirty">Not used.</param>
		/// <param name="fSaveAllProperties">Not used.</param>
		public void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, Boolean clearDirty, Boolean saveAllProperties)
		{
			object val = (object)appendData;
			WritePropertyBag(propertyBag, "AppendData", val);
            
			val = (object)prependData;
			WritePropertyBag(propertyBag, "PrependData", val);
		}

		/// <summary>
		/// Reads property value from property bag.
		/// </summary>
		/// <param name="pb">Property bag.</param>
		/// <param name="propName">Name of property.</param>
		/// <returns>Value of the property.</returns>
		private static object ReadPropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, string propName)
		{
			object val = null;
			try
			{
				propertyBag.Read(propName, out val, 0);
			}

			catch(ArgumentException)
			{
				return val;
			}
			return val;
		}

		/// <summary>
		/// Writes property values into a property bag.
		/// </summary>
		/// <param name="pb">Property bag.</param>
		/// <param name="propName">Name of property.</param>
		/// <param name="val">Value of property.</param>
		private static void WritePropertyBag(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, string propName, object val)
		{
			propertyBag.Write(propName, ref val);
		}
     



		#endregion

		#region IComponentUI

		/// <summary>
		/// Component icon to use in BizTalk Editor.
		/// </summary>
		[Browsable(false)]
		public IntPtr Icon
		{
			get {   return IntPtr.Zero; }
		}

		/// <summary>
		/// The Validate method is called by the BizTalk Editor during the build 
		/// of a BizTalk project.
		/// </summary>
		/// <param name="obj">Project system.</param>
		/// <returns>
		/// A list of error and/or warning messages encounter during validation
		/// of this component.
		/// </returns>
		public IEnumerator Validate(object projectSystem)
		{
			return null;
		}

		#endregion

		/// <summary>
		/// Given a OrganizationName, look up the party details from the BTS
		/// Management Database
		/// </summary>
		/// <param name="organizationName">The value of the OrganizationName Alias for the Party</param>
		/// <returns>PartyDetails structure populated with SID and PartyName of the party specified by OrganizationName
		///			  If the party does not exist, returns "" for the PartyName and the Guest SID ("s-1-5-7") for the SID
		///	</returns>
		private static PartyDetails GetSIDFromOrganizationName(string organizationName)
		{
			string partnerName = null;
			string partnerSID = null;

			PartnerHelper.GetPartyByAlias("Organization", "OrganizationName", organizationName, out partnerName, out partnerSID);

			return new PartyDetails(partnerName, partnerSID);
		}


		/// <summary>
		/// this function is used as the callback function for the EndOfStream delegate provided in PartyResolutionStream class
		/// This function gets called after the entire stream of the message has been read, guaranteeing that all promoted properties
		/// from the message have been populated to the message context.
		/// </summary>
		internal void EndOfStream()
		{
			string SourceOrgAlias;
			PartyDetails ThisParty;

			//obtain the SourceOrg string from the message
			SourceOrgAlias = (string)mBaseMessage.Context.Read("SoldToName", "http://Microsoft.Samples.BizTalk.Litware.Schemas.PropertySchema");

			if (SourceOrgAlias != null)
			{
				//assumption: the SourceOrg alias is ALWAYS an OrganizationName
				// if you want to use other alias types (such as DUNS number, whatever), change the code below
				// to call GetSourcePartyIDFromAlias() instead, and specify the alias qualifier (DUNS, etc.)

				ThisParty = GetSIDFromOrganizationName(SourceOrgAlias);
				mBaseMessage.Context.Write("SourcePartyID", "http://schemas.microsoft.com/BizTalk/2003/system-properties", ThisParty.SID);
				mBaseMessage.Context.Write("PartyName", "http://schemas.microsoft.com/BizTalk/2003/messagetracking-properties", ThisParty.PartyName);
			}
		}

		/// <summary>
		/// Stores the details about a particular BTS Party
		/// SID = the SourcePartyID for a Party
		/// PartyName = the name of a Party
		/// </summary>
		internal struct PartyDetails
		{
			internal string SID;
			internal string PartyName;

			internal PartyDetails(string partnerName, string partnerSID)
			{
				this.PartyName = partnerName;
				this.SID = partnerSID;
			}
		}
	}
}


