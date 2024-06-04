//---------------------------------------------------------------------
// File: Adapter.cs
// 
// Summary: A sample pipeline component which demonstrates how to create an
// HWS FactRetriever
//
// Sample: FactRetriever to retrieve data from Microsoft Active Directory 
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
using Microsoft.BizTalk.Hws.Runtime;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.DirectoryServices;

namespace Microsoft.HWS.FactRetrievers
{
	/// <summary>
	/// This class implements the IFactRetriever interface and is used to retrieve user 
	/// information from Active Directory.
	/// </summary>
	public class ADAdapter: IFactRetriever
	{

		#region Helper Classes
		/// <summary>
		/// This class is used to hold property specific information about each
		/// of the properties that the ADAdapter exposes.
		/// </summary>
		class ADProperty
		{
			public string			strPropertyName;		// property name
			public string			strADPropertyName;		// name in AD
			public string			strDisplayName;			// property display name
			public string			strDescription;			// property description
			public bool				fMultiValue;			// is the property multivalued
			public bool				fEnumerable;         	// is the property enumerable
			public bool				fDL;					// is the property a DL
			public FactPropertyType factPropertyType;		// FactProperty for schema retrieval
			public Guid				guidProperty;			// GUID for property

			// constructor
			public ADProperty(
				string PropertyName, 
				string ADPropertyName,
				string DisplayName,
				string Description,
				FactPropertyType PropertyType,
				Guid propGUID,
				bool MultiValue,
				bool Enumerable,
				bool isDL
				)
			{
				strPropertyName = PropertyName;
				strADPropertyName = ADPropertyName;
				strDisplayName = DisplayName;
				strDescription = Description;            
				factPropertyType = PropertyType;
				guidProperty = propGUID;         
				fMultiValue = MultiValue;       
				fEnumerable = Enumerable;         
				fDL = isDL;
			}
		}

		
		/// <summary>
		/// This class is used to hold object specific information about the 
		/// user object that is exposed by the adapter
		/// </summary>
		class ADClass
		{
			public string			strClassName;	// name of the object
			public HybridDictionary properties;		// list of the properties exposed by the object
            
			// constructor
			public ADClass(string ClassName, HybridDictionary props)
			{
				strClassName = ClassName;
				properties = props;
			}
		}
		#endregion

			
		#region member variables
		bool						isInitialized = false;			// initialization flag
		DirectoryEntry				entry;							// directory entry

		// static member variables used to initialize the adapter
		static bool					SchemaInitialized;				// schema initialization flag
		static FactObjectSchema		[] AdapterSchema;				// schema definition
		static HybridDictionary		ADClasses;						// objects exposed by the adapter
		static string				strDomain;						// domain portion of connection information
		static string				strDCComponent;					// DC component portion of connection information
		static bool					isDomainAD;						// is the domain specified
		#endregion

		#region GUIDs for the properties
		private const string		User_NamGuid = "{4F04E8ED-4BB2-4746-9118-0FD4C08F9522}";
		private const string		TitleGuid = "{5F04E8ED-4BB2-4746-9118-0FD4C08F9522}";
		private const string		Friendly_NameGuid = "{CA0DB691-18C1-4CB9-8B20-175DDF8FAF12}";
		private const string		Office_NumberGuid = "{BE39D074-65F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		Telephone_NumberGuid = "{CE39D074-65F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		DepartmentGuid = "{CE39D074-75F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		CompanyGuid = "{DE39D074-65F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		Email_AddressGuid = "{DE49D074-65F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		GroupsGuid = "{EE39D074-65F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		ManagerGuid = "{FE39D074-65F8-4E71-A072-1FC5A9A3C0D2}";		
		private const string		Direct_ReportsGuid = "{DD39D074-65F8-4E71-A072-1FC5A9A3C0D2}";	
		private const string		UserObjectGuid = "{2CFE0BFC-E577-44A2-8549-CEB9536FED92}";
		#endregion

		#region public methods
		/// <summary>
		/// Constructor
		/// </summary> 
		public ADAdapter()
		{
			// check to see if the schema is initialized
			if (!SchemaInitialized)
			{
				HybridDictionary ObjectSchema;
				AdapterSchema = new FactObjectSchema[1];
			
				// initialize the schema information
				HybridDictionary properties = new HybridDictionary(8);
				properties.Add("User_Name", new ADProperty("User_Name", "sAMAccountName", "User Name", "windows login name.", FactPropertyType.UserID, new Guid(User_NamGuid), false, false, false));
				properties.Add("Friendly_Name", new ADProperty("Friendly_Name", "cn", "Friendly Name", "Friendly User Name.", FactPropertyType.String, new Guid(Friendly_NameGuid ), false, false, false));
				properties.Add("Title", new ADProperty("Title", "title", "Title", "Title.", FactPropertyType.String, new Guid(TitleGuid ), false, false, false));
				properties.Add("Office_Number", new ADProperty("Office_Number", "physicalDeliveryOfficeName", "Office Number", "Office Number.", FactPropertyType.String, new Guid(Office_NumberGuid ), false, false, false));
				properties.Add("Telephone_Number", new ADProperty("Telephone_Number", "telephoneNumber", "Telephone Number", "Telephone Number.", FactPropertyType.String, new Guid(Telephone_NumberGuid ), false, false, false));
				properties.Add("Department", new ADProperty("Department", "department", "Department", "Department.", FactPropertyType.String, new Guid(DepartmentGuid ), false, false, false));
				properties.Add("Company", new ADProperty("Company", "company", "Company", "Company.", FactPropertyType.String, new Guid(CompanyGuid ), false, false, false));
				properties.Add("Email_Address", new ADProperty("Email_Address", "mail", "Email Address", "Email Address.", FactPropertyType.String, new Guid(Email_AddressGuid ), false, false, false));
				properties.Add("Groups", new ADProperty("Groups", "memberOf", "Groups", "Groups.", FactPropertyType.String, new Guid(ManagerGuid), true, false, true));
				properties.Add("Manager", new ADProperty("Manager", "manager", "Manager", "Manager.", FactPropertyType.String, new Guid(GroupsGuid), false, false, true));
				properties.Add("Direct_Reports", new ADProperty("Direct_Reports", "directReports", "Direct Reports", "Direct Reports.", FactPropertyType.String, new Guid(Direct_ReportsGuid), true, false, true));

				ADClass userClass = new ADClass("UserObject", properties);

				ADClasses = new HybridDictionary(1);
				ADClasses.Add(userClass.strClassName, userClass);

				ObjectSchema = new HybridDictionary(4);
	            
				IDictionaryEnumerator ADPropsEnumerator = properties.GetEnumerator();
				while ( ADPropsEnumerator.MoveNext() )
				{
					ADProperty prop = (ADProperty)(ADPropsEnumerator.Value);	               
					ObjectSchema.Add(prop.strPropertyName, new FactPropertySchema(prop.factPropertyType, prop.strPropertyName, prop.strDisplayName, prop.strDescription, prop.fMultiValue, prop.fEnumerable, prop.guidProperty));
				}

				AdapterSchema[0] = new FactObjectSchema(ObjectSchema, "UserObject", "User_Name", "User Name" , "contains user information", new Guid(UserObjectGuid  ));
	            
				// set flag so we only have to do this once
				SchemaInitialized = true;
			}
		}

		
		/// <summary>
		/// destructor
		/// </summary> 
		~ ADAdapter()
		{
			// call cleanup to release resources
			CleanUp();
		}

		/// <summary>
		/// implement the dispose method so that resources can be cleaned up
		/// </summary>
		public void Dispose()
		{
			CleanUp();

			GC.SuppressFinalize(this);
		}
		
		/// <summary>
		/// initialization method to accept and process connection information
		/// </summary>
		/// <param name="ConnectionInfo"> Conection information </param>
		public void Initialize(string ConnectionInfo)
		{
			// validate parameters
			if (ConnectionInfo == null || ConnectionInfo.Length == 0)
				throw new ArgumentException("ConnectionInfo");

			// process connection information
			try 
			{
				string[] connectionInfos = ConnectionInfo.Split(';');
				if(connectionInfos.Length > 1)
				{
					strDomain = (string)(connectionInfos.GetValue(0));

					string [] dcInfo = connectionInfos[1].Split(',');

					if (dcInfo[0].ToLower().IndexOf(strDomain.ToLower()) < 1)
						throw new ArgumentException("the domain specified is not the same as the DC specified.", "ConnectionInfo");

					strDCComponent = (string)(connectionInfos.GetValue(1));
					isDomainAD = true;
				}
				else
				{
					strDCComponent = (string)(connectionInfos.GetValue(0));
					isDomainAD = false;
				}

				entry = new DirectoryEntry("LDAP://OU=UserAccounts," + strDCComponent);

				// set initialization flag
				isInitialized = true;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		
		/// <summary>
		/// retrieves the schema exposed by the adapter
		/// </summary>
		/// <returns> schema information</returns>
		public FactObjectSchema [] RetrieveSchema()
		{
			// check that the object is initialized
			if (!isInitialized)
				throw new Exception("adapter not initialized.");

			return AdapterSchema;
		}

		/// <summary>
		/// retrieves the enumerated values for the object and property specified
		/// if it is enumerable
		/// </summary>
		/// <param name="objectID"> object to enumerate </param>
		/// <param name="propertyID"> property to enumerate </param>
		/// <returns> the enumerated values for the object and property specified </returns>
		public FactProperty EnumProperty(string objectID, string propertyID)
		{
			// check that the object is initialized
			if (!isInitialized)
				throw new Exception("adapter not initialized.");

			// The LDAP does not support any type of DISTINCT search capability (as in the case of TSQL).
			// One method to enumerate possible properties such as "Title" or "Department" is to create a query
			// to retrieve all possible values (duplicates will be included in the result set) and dump this data 
			// into a dataset or leverage ADO.NET to query against the in memory dataset or do your own in memory
			// analysis of the data to remove duplicates.  However, for a large set of users, it would not be 
			// feasible to retrieve information over the wire about all users from AD just to enumerate their 
			// possible values.  For data stores which support the DISTINCT search functionality like TSQL, 
			// this would not be the case since a distinct data set can be more efficiently obtained on the data 
			// server before transferring it across the wire.  Enumeration of properties is not used in the
			// runtime evaluation of HWS Constraints (only used in the design time environment to make it easier
			// for the admin to create constraints, although not required since the admin can fill in the values
			// on their own instead of selecting from a set of choices). 

			return null;
		}

		
		/// <summary>
		/// retrieves the objects of the specified type that satisfy the constraints
		/// </summary>
		/// <param name="objectID"> object to search for </param>
		/// <param name="constraints"> set of constraints on the search </param>
		/// <returns> set of FactObjects that satisfy the constraints </returns>
		public FactObject [] GetObjects(string objectID, PropVal [] constraints)
		{
			// check that the object is initialized
			if (!isInitialized)
				throw new Exception("adapter not initialized.");
         
			// validate parameters
			if (ADClasses[objectID] == null)
				throw new ArgumentException("invalid object.", objectID);

			if (objectID.CompareTo("UserObject") != 0)
				throw new ArgumentException("invalid object.", objectID);

			// call helper method
			return GetUserObjects(constraints, ((ADClass)(ADClasses[objectID])).properties);
		}

		/// <summary>
		/// retrieves the object that corresponds to the instanceID
		/// </summary>
		/// <param name="objectID"> object to search for </param>
		/// <param name="instanceID"> the instance identifier for the object </param>
		/// <returns> the FactObject that corresponds to the instanceID </returns>
		public FactObject GetObject(string objectID, object instanceID)
		{
			// check that the object is initialized
			if (!isInitialized)
				throw new Exception("adapter not initialized.");

			// validate parameters
			if (ADClasses[objectID] == null)
				throw new ArgumentException("invalid object.", objectID);
	         
			if (instanceID == null)
				throw new ArgumentNullException("InstanceID");

			if (objectID.CompareTo("UserObject") != 0)
				throw new ArgumentException("invalid object.", objectID);

			// call helper method
			return GetUserObject(instanceID, ((ADClass)(ADClasses[objectID])).properties);
		}

		/// <summary>
		/// retrieves the object property that corresponds to the instanceID
		/// </summary>
		/// <param name="objectID"> object to search for </param>
		/// <param name="propertyID"> the property to search for </param>
		/// <param name="instanceID"> the instance identifier for the object </param>
		/// <returns> the FactProperty that corresponds to the instanceID </returns>
		public FactProperty GetProperty(string objectID, string propertyID, object instanceID)
		{			
			// check that the object is initialized
			if (!isInitialized)
				throw new Exception("adapter not initialized.");

			// validate parameters
			if (ADClasses[objectID] == null)
				throw new ArgumentException("invalid object.", objectID);

			if (instanceID == null)
				throw new ArgumentNullException("instanceID");

			if (objectID.CompareTo("UserObject") != 0)
				throw new ArgumentException("invalid object.", objectID);

			if (!(((ADClass)(ADClasses[objectID])).properties.Contains(propertyID)))
				throw new ArgumentException("invalid property.", propertyID);

			// call helper method
			return GetUserProperty(propertyID,instanceID, ((ADClass)(ADClasses[objectID])).properties);			
		}

		/// <summary>
		/// retrieves the object information of the specified type that satisfy the constraints
		/// </summary>
		/// <param name="objectID"> object to search for </param>
		/// <param name="constraints"> set of constraints on the search </param>
		/// <returns> set of FactInfos that satisfy the constraints </returns>
		public FactInfo [] GetObjectInfo(string objectID, PropVal [] constraints)
		{
			// check that the object is initialized
			if (!isInitialized)
				throw new Exception("adapter not initialized.");
         
			// validate parameters
			if (ADClasses[objectID] == null)
				throw new ArgumentException("invalid object.", objectID);

			if (objectID.CompareTo("UserObject") != 0)
				throw new ArgumentException("invalid object.", objectID);

			// call helper method
			return GetUserInfo(constraints, ((ADClass)(ADClasses[objectID])).properties);
		}
		
		#endregion

		#region private methods
		/// <summary>
		/// helper method to clean up resources
		/// </summary>
		private void CleanUp()
		{
			if (entry != null)
			{
				entry.Dispose();
				entry = null;
			}
		}

		/// <summary>
		/// retrieves a single FactObject for the specified object 
		/// </summary>
		/// <param name="instanceID"> instance identifier for the object </param>
		/// <param name="ADProperties"> list of property information for the object </param>
		/// <returns> a single FactObject that corresponds to the instanceID </returns>
		private FactObject GetUserObject(object instanceID, HybridDictionary ADProperties)
		{
			FactObject retObj = null;
			HybridDictionary properties;

			try
			{
				//strip the domain name from instanceID to get the userName
				string userName = (string)instanceID;
				int index = userName.LastIndexOf('\\');
				if(index > -1)
				{
					userName = userName.Substring(index+1);
				}

				//setting up the filters
				DirectorySearcher searcher = new DirectorySearcher(entry);
				searcher.Filter = "(sAMAccountName=" + userName + ")";

				//setting up what properties to load
				IDictionaryEnumerator ADPropsEnumerator = ADProperties.GetEnumerator();
				while ( ADPropsEnumerator.MoveNext() )
				{
					searcher.PropertiesToLoad.Add(((ADProperty)(ADPropsEnumerator.Value)).strADPropertyName);
				}

				SearchResult resEnt = searcher.FindOne();

				if (resEnt != null)
				{
					properties = new HybridDictionary();

					ADPropsEnumerator.Reset();
					while ( ADPropsEnumerator.MoveNext() )
					{
						ADProperty prop = (ADProperty)(ADPropsEnumerator.Value);
						ResultPropertyValueCollection valcol = resEnt.Properties[prop.strADPropertyName];

						//fill the properties from the result
						properties.Add(prop.strPropertyName, GetKBPropertyFromADProperty(prop, valcol));
					}

					retObj = new FactObject(properties, @"User_Name", "Friendly_Name");
				}
			}			
			catch(Exception e)
			{
				throw e;
			}

			return retObj;
		}

		
		/// <summary>
		/// retrieves a set of FactObjects that satisfies the constraints
		/// </summary>
		/// <param name="constraints"> set of constraints to search for </param>
		/// <param name="ADProperties"> list of property information for the object </param>
		/// <returns> a set of FactObjects that corresponds to the constraints </returns>
		private FactObject [] GetUserObjects(PropVal [] constraints, HybridDictionary ADProperties)
		{
			try
			{
				ArrayList retList = new ArrayList();

				//setting up the filters
				string strFilter = GetADFilterFromConstraints(constraints, ADProperties);

				DirectorySearcher searcher = new DirectorySearcher(entry);
				searcher.Filter = strFilter;
	            
				//setting up what properties to load
				IDictionaryEnumerator ADPropsEnumerator = ADProperties.GetEnumerator();
				while ( ADPropsEnumerator.MoveNext() )
				{
					searcher.PropertiesToLoad.Add(((ADProperty)(ADPropsEnumerator.Value)).strADPropertyName);
				}

				SearchResultCollection resCollection = searcher.FindAll();

				if (resCollection != null)
				{
					for(int i=0; i<resCollection.Count; i++)
					{
						SearchResult resEnt = resCollection[i];
						HybridDictionary properties = new HybridDictionary();

						ADPropsEnumerator.Reset();
						while(ADPropsEnumerator.MoveNext())
						{
							ADProperty prop = (ADProperty)(ADPropsEnumerator.Value);
							ResultPropertyValueCollection valcol = resEnt.Properties[prop.strADPropertyName];

							//fill the properties from the result
							properties.Add(prop.strPropertyName, GetKBPropertyFromADProperty(prop, valcol));
						}

						retList.Add(new FactObject(properties, @"User_Name", "Friendly_Name"));
					}

					return (FactObject [] )(retList.ToArray(typeof(FactObject)));;
				}
			}			
			catch(Exception e)
			{
				throw e;
			}

			return null;
		}

		
		/// <summary>
		/// retrieves a set of FactInfo that satisfies the constraints
		/// </summary>
		/// <param name="constraints"> set of constraints to search for </param>
		/// <param name="ADProperties"> list of property information for the object </param>
		/// <returns> a set of FactInfo that corresponds to the constraints </returns>
		private FactInfo [] GetUserInfo(PropVal [] constraints, HybridDictionary ADProperties)
		{
			try
			{
				ArrayList retList = null;
				FactInfo [] retArray = null;

				//setting up the filters
				string strFilter = GetADFilterFromConstraints(constraints, ADProperties);

				DirectorySearcher searcher = new DirectorySearcher(entry);
				searcher.Filter = strFilter;
	            
				searcher.PropertiesToLoad.Add("sAMAccountName");
				searcher.PropertiesToLoad.Add("cn");


				SearchResultCollection resCollection = searcher.FindAll();

				if (resCollection != null)
				{ 
					retList = new ArrayList();
					retArray = new FactInfo[resCollection.Count];
					for(int i=0; i<resCollection.Count; i++)
					{
						SearchResult resEnt = resCollection[i];
						retArray[i] = new FactInfo(strDomain + @"\" + resEnt.Properties["sAMAccountName"][0], resEnt.Properties["cn"][0]);
					}					

					return retArray;
				}
			}			
			catch(Exception e)
			{
				throw e;
			}

			return null;
		}

		private FactProperty GetUserProperty(string propertyID, object instanceID, HybridDictionary ADProperties)
		{
			FactProperty retProperty = null;
			string userName;

			try
			{
				ADProperty property = (ADProperty)(ADProperties[propertyID]);

				//strip the domain name from instanceID to get the userName
				userName = (string)instanceID;
				int index = userName.LastIndexOf('\\');
				if(index > -1)
				{
					userName = userName.Substring(index+1);
				}

				//setting up the filters
				DirectorySearcher searcher = new DirectorySearcher(entry);
				searcher.Filter = "(sAMAccountName=" + userName + ")";

				//setting up what properties to load
				searcher.PropertiesToLoad.Add(property.strADPropertyName);

				SearchResult resEnt = searcher.FindOne();
				if (resEnt != null)
				{
					ResultPropertyValueCollection valcol = resEnt.Properties[property.strADPropertyName];

					//fill the properties from the result
					retProperty = GetKBPropertyFromADProperty(property, valcol);
				}
			}			
			catch(Exception e)
			{
				throw e;
			}

			return retProperty;
		}

		
		/// <summary>
		/// helper method to retrieve property information from results of query
		/// </summary>
		/// <param name="property"> AD property to retrieve </param>
		/// <param name="valcol"> set of proerty information  </param>
		/// <returns> single FactProperty that corresponds to the results </returns>
		private FactProperty GetKBPropertyFromADProperty(ADProperty property, ResultPropertyValueCollection valcol)
		{
			if(null == valcol || valcol.Count==0)
				return null;

			//fill the properties from the result
			if(property.fMultiValue)
			{
				ArrayList valList = new ArrayList();
				foreach(object val in valcol)
				{
					string strUserIDVal = (string)val;

					if(property.fDL)
					{
						//this is a DL type, strip off the DC format information
						if(strUserIDVal.Length > 3)
						{
							strUserIDVal = strUserIDVal.Substring(3);

							string[] DLArray = strUserIDVal.Split('=');
							strUserIDVal = DLArray[0];
							int indexLastComma = strUserIDVal.LastIndexOf(',');
							strUserIDVal = strUserIDVal.Substring(0, indexLastComma);
						}
					}

					if((FactPropertyType.UserID == property.factPropertyType) && (isDomainAD))
					{
						strUserIDVal = strDomain + "\\" + strUserIDVal; 
					}

					valList.Add(strUserIDVal);                 
				}

				return new FactProperty(valList);
			}
			else
			{
				string strUserIDVal = (string)(valcol[0]);

				if(property.fDL)
				{
					//this is a DL type, strip off the DC format information
					if(strUserIDVal.Length > 3)
					{
						strUserIDVal = strUserIDVal.Substring(3);

						string[] DLArray = strUserIDVal.Split('=');
						strUserIDVal = DLArray[0];
						int indexLastComma = strUserIDVal.LastIndexOf(',');
						strUserIDVal = strUserIDVal.Substring(0, indexLastComma);
					}
				}

				if((FactPropertyType.UserID == property.factPropertyType) && (isDomainAD))
				{
					strUserIDVal = strDomain + "\\" + strUserIDVal;
				}

				return new FactProperty(strUserIDVal);
			}
		}

		
		/// <summary>
		/// forms an AD query string from the constraints supplied
		/// </summary>
		/// <param name="constraints"></param>
		/// <param name="ADProperties"> set of property information </param>
		/// <returns> an AD query filter string </returns>
		private string GetADFilterFromConstraints(PropVal [] constraints, HybridDictionary ADProperties)
		{
			//setting up the filters
			string strFilter = "(&";
			string strNewClause = "";
			int i;

			if (constraints == null)
				return @"objectClass=user";

			foreach(PropVal clause in constraints)
			{
				ADProperty prop = ((ADProperty)(ADProperties[clause.PropertyID]));

				switch(clause.Operator)
				{
					case FactOperator.Equal:
						strNewClause = FormClause("=", clause, prop, ((clause.PropertyValue).GetValue(0)).ToString());
						break;

					case FactOperator.NotEqual:
						strNewClause = FormClause("=", clause, prop, ((clause.PropertyValue).GetValue(0)).ToString());
						break;

					case FactOperator.GreaterThan:
						strNewClause = FormClause(">", clause, prop, ((clause.PropertyValue).GetValue(0)).ToString());
						break;
	                  
					case FactOperator.LessThan:
						strNewClause = FormClause("<", clause, prop, ((clause.PropertyValue).GetValue(0)).ToString());
						break;
	                  
					case FactOperator.Intersection:
						strNewClause = @"(|";

						for (i = 0; i < clause.PropertyValue.Length; i++)
						{
							strNewClause += FormClause("=", clause, prop, ((clause.PropertyValue).GetValue(i)).ToString());
						}

						strNewClause += ")";
						break;

					case FactOperator.Exclusion:
						strNewClause = @"(!(|";

						for (i = 0; i < clause.PropertyValue.Length; i++)
						{
							strNewClause += FormClause("=", clause, prop, ((clause.PropertyValue).GetValue(i)).ToString());
						}

						strNewClause += "))";
						break;

					default:
						throw new Exception("invalid operator type");
				}

				strFilter = strFilter + strNewClause;
			}

			return strFilter + ")";
		}

		
		/// <summary>
		/// formulates an AD query clause
		/// </summary>
		/// <param name="op"> operator </param>
		/// <param name="clause"> clause </param>
		/// <param name="prop"> property information </param>
		/// <param name="val"> value </param>
		/// <returns> a single AD query clause </returns>
		private string FormClause(string op, PropVal clause, ADProperty prop, string val)
		{
				        
				
			if((FactPropertyType.UserID == prop.factPropertyType) && (isDomainAD))
			{
				//strip the domain name from val to get the userName
				int index = val.LastIndexOf('\\');
				if(index > -1)
				{
					val = val.Substring(index+1);
				}
			}

			string strNewClause;

			if(prop.fDL)
			{
				strNewClause = "(" + prop.strADPropertyName + op;

				string strDLClause = "(|" + strNewClause + 
					"CN=" + val + ",OU=Distribution Lists," + strDCComponent + ")" + strNewClause + 
					"CN=" + val + ",CN=Users," + strDCComponent + ")";

				strNewClause = strDLClause;
			}
			else
			{
				strNewClause = "(" + prop.strADPropertyName + op + val;
			}

			//handle the not equal and exclusion
			if((clause.Operator == FactOperator.NotEqual) || (clause.Operator == FactOperator.Exclusion))
			{
				strNewClause = "(!" + strNewClause + ")";
			}

			strNewClause += ")";
			return strNewClause;
				
		}
		#endregion
	}
}
