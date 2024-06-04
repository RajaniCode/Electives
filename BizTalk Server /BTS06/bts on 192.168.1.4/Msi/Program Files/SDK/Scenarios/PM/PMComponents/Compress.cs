//---------------------------------------------------------------------
// File: CompressMsg.cs
// 
// Summary: A Sample of how to write a compression pipeline component.
//
// Sample: Compression Pipeline Component
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

namespace Microsoft.Samples.BizTalk.WingtipToys.PMComponents
{
    using System;
    using System.Resources;
    using System.Drawing;
    using System.Collections;
    using System.Reflection;
    using System.ComponentModel;
    using System.Text;
    using System.IO;
    using Microsoft.BizTalk.Message.Interop;
    using Microsoft.BizTalk.Component.Interop;


    /// <summary>
    /// Implements custom pipeline component to compress data in streaming fashion.
    /// </summary>
    /// <remarks>
	/// Compress class implements pipeline component that can be used in 
    /// send pipelines. The pipeline component gets a data stream, compresses it
    /// and passes it on.
    ///</remarks>
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Encoder)]
    [ComponentCategory(CategoryTypes.CATID_Validate)]
    [System.Runtime.InteropServices.Guid("697F197C-2BE9-4396-9240-2C67E6A0050B")]
    public class Compress :
        IBaseComponent, 
        Microsoft.BizTalk.Component.Interop.IComponent,
        Microsoft.BizTalk.Component.Interop.IPersistPropertyBag,
        IComponentUI
    {

		static ResourceManager resManager = new ResourceManager("Microsoft.Samples.BizTalk.WingtipToys.PMComponents.CompressionResources", Assembly.GetExecutingAssembly());

		/// <summary>
        /// Constructor initializes base class to allow custom names and description for component properies
        /// </summary>
	    public Compress()
	    {
	    }


        #region IBaseComponent
        
        /// <summary>
        /// Name of the component.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get {   return "Compression Component";  }
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
			get { return "Compresses outgoing data using GZipStream."; }
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

			IBaseMessagePart bodyPart = pInMsg.BodyPart;
            if (bodyPart!=null)
            {
                Stream strm = new CompressionStream(bodyPart.GetOriginalDataStream(), resManager);
                bodyPart.Data = strm;
				pContext.ResourceTracker.AddResource(strm);
            }
            
            return pInMsg;
        }
        #endregion

        #region IPersistPropertyBag
    
        /// <summary>
        /// Gets class ID of component for usage from unmanaged code.
        /// </summary>
        /// <param name="classid">Class ID of the component.</param>
        public void GetClassID(out Guid classID)
        {
            classID = new System.Guid("697F197C-2BE9-4396-9240-2C67E6A0050B");
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
        }
        
        /// <summary>
        /// Saves the current component configuration into the property bag.
        /// </summary>
        /// <param name="pb">Configuration property bag.</param>
        /// <param name="fClearDirty">Not used.</param>
        /// <param name="fSaveAllProperties">Not used.</param>
        public void Save(Microsoft.BizTalk.Component.Interop.IPropertyBag propertyBag, Boolean clearDirty, Boolean saveAllProperties)
        {
        }
        #endregion

        #region IComponentUI

        /// <summary>
        /// Component icon to use in BizTalk Editor.
        /// </summary>
        [Browsable(false)]
        public IntPtr Icon
        {
            get
	        {
                return ((Bitmap)resManager.GetObject("CompressMsgBitmap")).GetHicon();
            }
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
        public IEnumerator Validate(object projectSystem )
        {
			return null;
        }

        #endregion
    }
}