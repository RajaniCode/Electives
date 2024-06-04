//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.Common.SSOApplicationConfig
// Helper console application to set values of config parameters in the SSO config store.
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Collections.Specialized;
using Microsoft.BizTalk.SSOClient.Interop;

namespace Microsoft.Samples.BizTalk.Common.SSOApplicationConfig
{
	/// <summary>
	/// Summary description for SSOSetConfigValues.
	/// </summary>
	class SSOSetConfigValues
	{

		private enum ProgramOption
		{
			OPTION_GET = 0,
			OPTION_SET = 1
		} ;

		public static void Main(string[] args)
		{
            try
            {
                ProgramOption option;
                string ssoServer;
         		string ssoAppName;
		        string ssoIdentifierName;
                string[] configParameterNames;
                string[] configParameterValues;

                parseArguments( args, 
                                out option, 
                                out ssoServer, 
                                out ssoAppName, 
                                out ssoIdentifierName, 
                                out configParameterNames, 
                                out configParameterValues
                                );

                ConfigPropertyBag propBag = new ConfigPropertyBag();

                ISSOConfigStore ssoConfigStore = new ISSOConfigStore();
                
                switch (option)
                {
                    case ProgramOption.OPTION_GET:

                        // Getting the config values is supported only locally.
                        if (null != ssoServer)
                        {
                            Console.WriteLine(Resources.GetValuesOnlyLocalMessage);
                        }
                        else
                        {
                            // Read the entire property bag from the local sso, byepass the cache....
                            ssoConfigStore.GetConfigInfo(ssoAppName, ssoIdentifierName,
                                                   SSOFlag.SSO_FLAG_RUNTIME | SSOFlag.SSO_FLAG_REFRESH, propBag);

                            // Print only those that were wanted....
                            for (int i = 0; i < configParameterNames.Length; i++)
                            {
                                object propValue;
                                propBag.Read(configParameterNames[i], out propValue, 0);
                                Console.WriteLine("Property <{0}> = <{1}>", configParameterNames[i],
                                                null == propValue ? "--NO_VALUE_FOUND_FOR_PROPERTY--" : (String)propValue);
                            }                        
                        }
                        break;

                    case ProgramOption.OPTION_SET:

                        // Only those properties specified in the command line are set to the corresponding new values.
                        // Other properties retain their current values.
                        
                        // Validate the fields that are passed are defined in SSO and initliaze the property bag with
                        // 'VT_NULL's for all the defined fields...
                        validateAndInitializeFields(ssoAppName, configParameterNames, ssoServer, propBag);

                        // If a server name was given use it...
                        if (null != ssoServer)
                        {
                            IPropertyBag serverPropBag = (IPropertyBag)ssoConfigStore;
                            object ssoServerName = ssoServer;
                            serverPropBag.Write("CurrentSSOServer", ref ssoServerName);
                        }

                        // Modify the property bag with all the values of the specified properties ...
                        for (int i = 0; i < configParameterNames.Length; i ++)
                        {
                            object propVal = configParameterValues[i];
                            propBag.Write(configParameterNames[i], ref propVal);
                        }

                        // Write all the properties back....
                        ssoConfigStore.SetConfigInfo(ssoAppName, ssoIdentifierName, propBag);
                        break;

                    default:
                        throw new InternalSoftwareErrorException();
                }
            }

            catch (IncorrectUsageException usageEx)
            {
                Console.WriteLine(usageEx.Message);
                Console.WriteLine(Resources.UsageText);

                return;
            }

            catch (FieldNotInSSOAppException noSSOFieldEx)
            {
                Console.WriteLine(noSSOFieldEx.Message);
                return;
            }

            catch (System.Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex);
            }
		}

        private static void validateAndInitializeFields(
                    string ssoAppName, 
                    string[] configParameterNames, 
                    string ssoServer, 
                    IPropertyBag propBag)
        {
            // Verify that the fields that are given are indeed fields defined in SSO. Since SetConfigInfo
            // doesn't throw an exception when passed a field that is not defined, we need to do this ourselves

            // Get the fields defined in the application.
            ISSOMapper ssoMapper = new ISSOMapper();

            // If a server name was given use it...
            if (null != ssoServer)
            {
                IPropertyBag serverPropBag = (IPropertyBag)ssoMapper;
                object ssoServerName = ssoServer;
                serverPropBag.Write("CurrentSSOServer", ref ssoServerName);
            }

            string[] ssoAppFields;
            int[] ssoAppFlags;
            ssoMapper.GetFieldInfo(ssoAppName, out ssoAppFields, out ssoAppFlags);

            // Each one of the passed fields should exist in SSO... otherwise error...
            foreach (string thisField in configParameterNames)
            {
                bool found = false;
                for (int j = 0; j < ssoAppFields.Length; j++)
                {
                    if (thisField == ssoAppFields[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    throw new FieldNotInSSOAppException(thisField, ssoAppName);
                }
            }

            // Initialize the property bag with a System.DBNULL.Value for all the fields in the config.  DBNULL is marshalled into a
            // 'VT_NULL' when calling into the unmanaged code, and SSO interprets VT_NULL as -'don't change the current value of the
            // field.

            object propValue = System.DBNull.Value;

            foreach (string thisField in ssoAppFields)
            {
                propBag.Write(thisField, ref propValue);
            }
        }

        /// <summary>
        /// Parse the command line arguments passed and return the values through the output parameters...
        /// </summary>
        /// <param name="args"> command line arguments passed to the program...</param>
        /// <param name="option">Program option - get or set</param>
        /// <param name="ssoServer">Sso server to use.  The server name is optional in the command line.  if given in 
        /// the command line, its value is here. Otherwise set to null. 
        /// </param>
        /// <param name="ssoAppName">sso config application name</param>
        /// <param name="ssoIdentifierName">identifier for the config properties</param>
        /// <param name="configParameterNames">array of config property names...</param>
        /// <param name="configParameterValues">array of the corresponding values...</param>
 
        private static void parseArguments(string[] args, 
                    out ProgramOption option,
                    out string ssoServer,
                    out string ssoAppName,
                    out string ssoIdentifierName,
                    out string[] configParameterNames,
                    out string[] configParameterValues 
            )
		{
			IncorrectUsageException usageException = new IncorrectUsageException();
 
            // command line parameters for reference here... the usage string is in the resources...
            // the use of server name is optional....
            // "To set values --> BTSScnSSOApplicationConfig -set <SSO Config Store App Name> <SSO Identifier Name> [{-server <SSO Server Name>}] <Config Parameter Name 1> <Config Parameter Value 1> <Config Parameter Name 2> <Config Parameter Value 2> ...",
            // "To get values --> BTSScnSSOApplicationConfig -get <SSO Config Store App Name> <SSO Identifier Name> [{-server <SSO Server Name>}] <Config Parameter Name 1> <Config Parameter Name 2> ..."

            // Need at least 3 arguments here -> option, sso config store app name, sso identifier name...
			if (args.Length < 3)
			{
				throw usageException;
			}

            // Server name...
           
            bool serverNameGiven = false;
            ssoServer = null;
            
            if ( args.Length >= 4)
            {
                serverNameGiven = (String.Compare(args[3], "-server", 
                                StringComparison.OrdinalIgnoreCase) == 0); 
            }
            
            if (serverNameGiven)
            {    
                if (args.Length >= 5)       // If -server option is used, server name must be given also...
                {
                    ssoServer = args[4];
                }
                else
                {
                    throw usageException;
                }
            }

			ssoAppName = args[1];		// sso config store application name
			ssoIdentifierName = args[2]; // Name of the identifier used to identify the collection of properties

            if (String.Compare(args[0], "-get", StringComparison.OrdinalIgnoreCase) == 0)
            {
                option = ProgramOption.OPTION_GET;
            }
            else if (String.Compare(args[0], "-set", StringComparison.OrdinalIgnoreCase) == 0)
            {
                option = ProgramOption.OPTION_SET;
            }
            else
            {
                throw usageException;
            }

            int minRequiredArgs;
            int startParamIndex;

			switch (option)
			{
                case ProgramOption.OPTION_GET:


                    if (serverNameGiven)
                    {
                        // At least 6 arguments - option, sso config app name, identifier name, -server, sso server name, first parameter name
                        minRequiredArgs = 6;
                    }
                    else
                    {
                        // At least 4 arguments - option, sso config app name, identifier name, first parameter name
                        minRequiredArgs = 4;
                    }

                    if (args.Length < minRequiredArgs)
					{
						throw usageException;
					}

                    // Copy the config parameters to get, including the first parameter (at position minRequiredArgs -1) in the args list ...
                    // The paramteters start after the 'minimum required arguments' in the args array...

                    startParamIndex = minRequiredArgs - 1;
                    configParameterNames = new string[args.Length - startParamIndex];

                    for (int i = 0; i < configParameterNames.Length; i++)
                    {
                        configParameterNames[i] = args[i + startParamIndex];
                    }

                    // No config Parameter values to set, since we are only getting
                    configParameterValues = null;   

					break;

                case ProgramOption.OPTION_SET:


                    if (serverNameGiven)
                    {
                        // At least 7 arguments - option, sso config app name, identifier name, -server, sso server name, first parameter name, first parameter value
                        minRequiredArgs = 7;
                    }
                    else
                    {
                        // At least 5 arguments - option, sso config app name, identifier name, first parameter name, first parameter value
                        minRequiredArgs = 5;
                    }

                    // We should at least have 'minRequiredArgs' number of arguments.
                    // Anything more will must be in paris of {config property name, config proprty value}
                    if (args.Length < minRequiredArgs || (args.Length >= minRequiredArgs && ((args.Length - minRequiredArgs ) & 1) == 1))
                    {
                        throw usageException;
                    }

                    // Copy the config parameters and values to set, including the first parameter and value...
                    // the config parameters, values start after the 'minimum required' number of arguments in the args array...
                    startParamIndex = minRequiredArgs - 2;
                    configParameterNames = new string[(args.Length - startParamIndex) / 2];
                    configParameterValues = new string[(args.Length - startParamIndex) / 2];

                    for (int i = 0; i < configParameterNames.Length; i++)
                    {
                        configParameterNames[i] = args[i * 2 + startParamIndex];
                        configParameterValues[i] = args[i * 2 + startParamIndex + 1];
                    }
					break;

				default:
					throw new InternalSoftwareErrorException();
			}
		}
	}

	/// <summary>
	/// Simple class to deal with incorrect usage of the program/incorrect command line arguments...
	/// </summary>
	internal class IncorrectUsageException : ApplicationException
	{
		internal IncorrectUsageException()
			: base(Resources.IncorrectUsageExceptionMessage)
		{
		}
	}

	internal class InternalSoftwareErrorException : ApplicationException
	{
		internal InternalSoftwareErrorException()
			: base(Resources.InternalSoftwareErrorExceptionMessage)
		{ 
		}
	}

    internal class FieldNotInSSOAppException : ApplicationException
    {
        private string fieldName;
        private string ssoAppName;

        internal FieldNotInSSOAppException(string fieldName, string ssoAppName) 
            : base (Resources.FieldNotInSSOAppExceptionMessage)

        {
            this.fieldName = fieldName;
            this.ssoAppName = ssoAppName;
        }
        public override string Message
        {
            get
            {
                return base.Message + " SSO App: " + this.ssoAppName + " " + "Field: " + this.fieldName ;
            }
        }
    }
}
