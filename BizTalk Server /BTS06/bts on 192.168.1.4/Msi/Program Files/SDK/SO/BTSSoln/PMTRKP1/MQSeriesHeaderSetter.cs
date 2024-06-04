//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTrackerPipelineComponents
// Pipeline components to handle messages from/to the Payment Tracking System.
// 
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Resources;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Globalization;

using Microsoft.BizTalk.Message.Interop;
using Microsoft.BizTalk.Component.Interop;
using Microsoft.BizTalk.Component;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.PaymentTrackerPipelineComponents
{
	[ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
	[ComponentCategory(CategoryTypes.CATID_Any)]
	
	[Guid("13435D03-B7E8-4b16-ACE3-0DB893E026C0")]

	/// <summary>
	/// Pipeline component to set the MQSeries header properties specific to the interactions
	/// with the Payment Tracking System.
	/// </summary>
	public class MQSeriesHeaderSetter  :	IBaseComponent,
										Microsoft.BizTalk.Component.Interop.IComponent,
										Microsoft.BizTalk.Component.Interop.IComponentUI,
										Microsoft.BizTalk.Component.Interop.IPersistPropertyBag
	{
		private static	ResourceManager resManager = new ResourceManager(typeof(MQSeriesHeaderSetter));
		private const string PIPELINE_COMPONENT_CLASS_GUID = "13435D03-B7E8-4b16-ACE3-0DB893E026C0";

		public MQSeriesHeaderSetter()
		{
		}
		
		#region IComponent members

		/// <summary>
		/// Execute method of the pipeline component.
		/// </summary>
		/// <param name="pc"> Pipeline context</param>
		/// <param name="pInMsg">input message.</param>
		/// <returns>
		/// The message after assigning the MQSeries context properties.
		/// </returns>
		public IBaseMessage Execute (IPipelineContext pContext, IBaseMessage pInMsg)
		{
			if (null == pContext) throw new ArgumentNullException("pContext", "Pipeline context can not be null");

			if (null == pInMsg) throw new ArgumentNullException("pInMsg", "Input message can not be null");

			// Format of the Data is in the Format parameter of the MQCIH Structure
			pInMsg.Context.Write(
				"MQCIH_Format", 
				"http://schemas.microsoft.com/BizTalk/2003/mqs-properties",
				"MQSTR   "
				);

			// The MQ Messge itself will contain the MQCIH structure followed by the data.

			pInMsg.Context.Write(
				"MQMD_Format",
				"http://schemas.microsoft.com/BizTalk/2003/mqs-properties",
				"MQCICS  "
				);

			return pInMsg;
		}

		#endregion

		#region IBaseComponent members
        
		/// <summary>
		/// Name of the component.
		/// </summary>

		public string Name
		{
			get {   return resManager.GetString("Name", CultureInfo.CurrentCulture );  }
		}
        
		/// <summary>
		/// Version of the component.
		/// </summary>
		
		public string Version
		{
			get {   return "1.0";   }
		}
        
		/// <summary>
		/// Description of the component.
		/// </summary>
		public string Description
		{
			get 
			{
				return (resManager.GetString("Description", CultureInfo.CurrentCulture));  
			}
		}

		#endregion

		#region IComponentUI
		/// <summary>
		/// Validate the pipeline component's properties.  This method is called from the pipeline designer.
		/// Since there are no custom properties for this method, this will return null.
		/// </summary>
		/// <param name="projectSystem"></param>
		/// <returns> 
		/// IEnumerator interface representing errors in validation or null 
		/// if there are no errors.
		/// </returns>
		public IEnumerator Validate (object projectSystem )
		{
			return null;
		}


		/// <summary>
		/// Icon - return the Icon for the pipeline component so it can be displayed
		/// in the tool box.
		/// </summary>
		[Browsable(false)]
		public IntPtr Icon
		{
			get 
			{
                return (IntPtr)null;
			}
		}

		#endregion
		#region IPersistPropertyBag

		/// <summary>
		/// Return the class id of the disassembler component.
		/// </summary>
		/// <param name="classId"></param>
		public void GetClassID(out Guid classID)
		{
			classID = new System.Guid(PIPELINE_COMPONENT_CLASS_GUID);
		}


		/// <summary>
		///  The Load method is part of the IPersistPropertyBag interface and is called from the 
		///  pipeline designer at design time and from the pipeline at run time.  Since there are no
		///  other properties in this pipeline component, this method is empty.
		/// </summary>
		/// <param name="propertyBag"></param>
		/// <param name="errorlog"></param>
		/// 
		public void Load(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, int errorLog)
		{
		}

		/// <summary>
		/// The save method is part of the IPersistPropertyBag interface and is called from the
		/// pipeline designer at design time and from the pipeline at run time.  Since there are
		/// no other properties in this pipeline component, this method is empty.
		/// </summary>
		/// <param name="propertyBag"></param>
		/// <param name="isClearDirty"></param>
		/// <param name="isSaveAllProperties"></param>
		/// 
		public void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, bool clearDirty, bool saveAllProperties)
		{
		}

		/// <summary>
		/// InitNew method
		/// </summary>
		public void InitNew()
		{
		}

		#endregion
	}
}
