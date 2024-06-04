//---------------------------------------------------------------------------------
// Microsoft.Samples.BizTalk.WoodgroveBank.Utilities.CustomerServiceHelper
// Helper functions for the end to end Service Oriented scenario orchestrations
//
// Copyright (c) Microsoft Corporation. All rights reserved.  
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, 
// EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES 
// OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE. 
//---------------------------------------------------------------------------------
//
using System;
using System.Text;

namespace Microsoft.Samples.BizTalk.WoodgroveBank.Utilities
{
	/// <summary>
	/// Utility and helper functions for the Service Oriented Scenario Sample
	/// </summary>
	public sealed class CustomerServiceHelper
	{

		/// <summary>
		/// Constructor - need to have this constructor as the mapper needs instances to call the methods.
		/// </summary>
		public CustomerServiceHelper()
		{
		}

		/// <summary>
		/// Return a unique ID (generated from a GUID) of a specified length as a string.
		/// If the specified length is > the length of GUID generated, it is appended with
		/// with the specified character.  The returned string is at least as long as the
		/// length of the GUID generated.
		/// </summary>
		/// <returns>
		/// string - newly generated unique id
		/// </returns>
		public static string NewUniqueIdAppendToLength(int totalLength, char appendWith)
		{
			string guid = System.Guid.NewGuid().ToString();
			StringBuilder sb = new StringBuilder(guid.Replace("-", ""));

			for (int i = sb.Length; i < totalLength; i++)
			{
				sb.Append(appendWith);
			}
			return sb.ToString();
		}

		/// <summary>
		///  Helper function for the mapper to compare 2 given values and return one of the 2 other given values based on 
		///  the comparison result.
		/// 
		/// </summary>
		/// <param name="comparand1">
		/// string - One of the values to be compared
		/// </param>
		/// <param name="comparand2">
		/// string - value to compare to comparand1
		/// </param>
		/// <param name="value1">
		/// string - first value
		/// </param>
		/// <param name="value2">
		/// string - second value
		/// </param>
		/// <returns></returns>

		public static string Compare2ValuesAndSelectFrom2Values(string comparand1, string comparand2, string value1, string value2)
		{
			return comparand1 == comparand2 ? value1 : value2;
		}

		/// <summary>
		/// Validate the account number.
		/// </summary>
		/// <param name="accountNumber">
		/// string containing the account number
		/// </param>
		/// <returns>
		/// true if the account number is valid. false otherwise.
		/// </returns>
		public static bool IsAccountNumberValid(string accountNumber)
		{
			if (null == accountNumber) throw new ArgumentNullException("accountNumber", "Account Number can not be null");
			const int ACCOUNT_NUM_LENGTH = 16;

			if (accountNumber.Length != ACCOUNT_NUM_LENGTH)
			{
				return false;
			}

			for (int i = 0; i < accountNumber.Length; i++)
			{
				if (!Char.IsDigit(accountNumber, i))
				{
					return false;
				}
			}

			return true;
		}

	}
}
