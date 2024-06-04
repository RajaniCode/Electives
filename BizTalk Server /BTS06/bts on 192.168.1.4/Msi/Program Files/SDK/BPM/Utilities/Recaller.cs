//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
// Recaller calls method on an object by string name
//  
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;
using System.Reflection;
using System.Globalization;

namespace Microsoft.Samples.BizTalk.SouthridgeVideo.Utilities
{
    /// <summary>
    /// Calls methods on classes using reflection
    /// </summary>
    public sealed class Recaller
    {
        private Recaller() { }

        /// <summary>
        /// Invokes a method on a type or instance of an object
        /// </summary>
        /// <param name="t">type of object to invoke method on</param>
        /// <param name="obj">object to use for invocation.  Can be null</param>
        /// <param name="methodName">Method to invoke of type or on object</param>
        /// <param name="args">arguments to method</param>
        /// <returns>return methods return value</returns>
        /// <remarks>To call a static method, set obj to null</remarks>
        public static object Invoke(Type type, object obj, string methodName, Array args)
        {
            Debug.Assert(obj != null ? obj.GetType() == type : true, "Type type and typeof obj type don't match!");
            if (null == type)
            {
                throw new ArgumentNullException("type");
            }

            // Constructor
            if (string.IsNullOrEmpty(methodName))
            {
                return type.InvokeMember(null,
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.CreateInstance,
                    null,
                    null,
                    (object[])args,
                    CultureInfo.InvariantCulture);
            }
            // Static method
            else if (null == obj)
            {
                return type.InvokeMember(methodName,
                    BindingFlags.Public | BindingFlags.Static | BindingFlags.InvokeMethod,
                    null,
                    null,
                    (object[])args,
                    CultureInfo.InvariantCulture);
            }
            // Instance method
            else
            {
                return type.InvokeMember(methodName,
                    BindingFlags.Public | BindingFlags.Instance | BindingFlags.InvokeMethod,
                    null,
                    obj,
                    (object[])args,
                    CultureInfo.InvariantCulture);
            }
        }

        /// <summary>
        /// Determines whether an exception is an application exception
        /// </summary>
        /// <param name="e">exception to check</param>
        /// <returns>true if application exception</returns>
        public static bool IsApplicationException(Exception ex)
        {
            if (null == ex)
            {
                throw new ArgumentNullException("ex");
            }

            Exception exBase = ex.GetBaseException();
            Type type = exBase.GetType();
            return type.IsSubclassOf(typeof(ApplicationException));
        }
    }
}
