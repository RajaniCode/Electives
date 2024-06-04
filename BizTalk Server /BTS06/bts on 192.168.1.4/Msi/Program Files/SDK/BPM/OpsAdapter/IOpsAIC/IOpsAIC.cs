//---------------------------------------------------------------------
// File: IOpsAIC.cs
// 
// Summary: This class defines the interface for components that are called
//          by the OPS adapter.
//
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

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Adapters.OpsAdapter
{
    /// <summary>
    /// Interface needed for OpsAdapter
    /// </summary>
    public interface IOpsAIC
    {
        void Initialize(string config);
        void Execute(byte[] message);
    }
}