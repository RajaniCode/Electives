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
    using System.IO.Compression;


    /// <summary>
    /// Implements custom pipeline component to decompress incoming compressed stream.
    /// </summary>
    /// <remarks>
    /// DeCompress class implements pipeline component that can be used in receive
    /// pipelines. The pipeline component decompress an already compressed stream.
    ///</remarks>
    [ComponentCategory(CategoryTypes.CATID_PipelineComponent)]
    [ComponentCategory(CategoryTypes.CATID_Decoder)]
    [ComponentCategory(CategoryTypes.CATID_Validate)]
    [System.Runtime.InteropServices.Guid("2897EB8E-9FCE-4485-91DC-8C568EAA0887")]
    public class DeCompress :
        IBaseComponent, 
        Microsoft.BizTalk.Component.Interop.IComponent,
        Microsoft.BizTalk.Component.Interop.IPersistPropertyBag,
        IComponentUI
    {

		static ResourceManager resManager = new ResourceManager("Microsoft.Samples.BizTalk.WingtipToys.PMComponents.CompressionResources", Assembly.GetExecutingAssembly());

		/// <summary>
    	/// Constructor initializes base class to allow custom names and description for component properies
	    /// </summary>
        public DeCompress()
        {
     	}

        #region IBaseComponent
        
        /// <summary>
        /// Name of the component.
        /// </summary>
        [Browsable(false)]
        public string Name
        {
            get {   return "Decompression Component";  }
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
			get { return "Decompresses incoming data using GZipStream."; }
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
                GZipStream strm = new GZipStream(bodyPart.GetOriginalDataStream(), CompressionMode.Decompress);
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
            classID = new System.Guid("2897EB8E-9FCE-4485-91DC-8C568EAA0887");
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
        public IEnumerator Validate(object projectSystem)
        {
			return null;
		}

        #endregion
    }
}