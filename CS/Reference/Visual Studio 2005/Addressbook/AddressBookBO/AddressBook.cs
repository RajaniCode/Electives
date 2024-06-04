using System;
using System.Collections;
using System.Data;
using AddressBookDatabase;
using AddressBookBO;
namespace AddressBookBO
{
	
	

	/// <summary>
	/// This is the main address class which will have
	/// buisness logic for the addressbook. This class represents
	/// a single entity.
	/// </summary>
	public class AddressBook
	{	
		//private properties declaration for
		// address book
		private int intAddressid;
		private string strName;
		private string strAddress;
		private string strPhoneNumber;
		// getting a reference to the database class
		private addressBookDB objaddressBookDB;
		
		
		public AddressBook()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		
		// Addressid is the autoincrement field so there
		// will no set property for the same
		public int  addressId
		{
			get
			{
				return intAddressid;
			}
			set
			{
				intAddressid = value;
			}
		}

		// Set and Get properties for 
		// Name , Address  and PhoneNumber
		public string Name
		{
			set
			{
				// Validation if there is no Name provided 
				// throw a exception Name is a compulsory field
				if (value.Length == 0)
				{
					throw new Exception("Name is a compulsory field");
				}
				strName = value;
			}
			get
			{
				return strName;
			}
		}
		public string Address
		{
			set
			{
				// Validation if there is no Address provided
				// throw a exception Address is compulsory field
				if (value.Length == 0)
				{
					throw new Exception("Address is compulsory field");
				}

				strAddress = value;
			}
			get
			{
				return strAddress;
			}
		}
		public string PhoneNumber
		{
			set
			{
				strPhoneNumber = value;
			}
			get
			{
				return strPhoneNumber;
			}
		}
		/// <summary>
		/// This method adds address to database
		/// </summary>
		public void addAddress()
		{
			try
			{
				addressBookDB objaddressBookDB = new addressBookDB();
				objaddressBookDB.addAddress(intAddressid,strName,strAddress,strPhoneNumber);
			}
			catch(Exception ex)
			{
				throw ex;
			}
		}
	}

	
	

	/// <summary>
	/// This is a collection class of AddressBook type class.
	/// </summary>

	public class AddressBooks : CollectionBase
	{	
		// getting a reference to the database class
		private addressBookDB objaddressBookDB = new addressBookDB();
		public void addAddress()
		{
			
		}
		/// <summary>
		/// This applies a indexer to the collection class
		/// So that we can get a item by index
		/// </summary>
		public AddressBook this[int Index]
		{
			get
			{
				return (AddressBook) List[Index];
			}
		}
			/// <summary>
			/// This method loads all addresses from database
			/// </summary>
			public void loadAddress()
			{
				IDataReader objDatareader = null;

				try
				{
					// clear the list items before we start filling data
					List.Clear();
					// get the addresses from the database component
					// addressBookDB
					objDatareader = objaddressBookDB.GetAddresses();
					// loop through the datareader and load the
					// collection of addressbooks
					while (objDatareader.Read())
					{
						AddressBook objAddressBook ;
						objAddressBook = new AddressBook();
						
						objAddressBook.addressId = (int)objDatareader["Addressid"];
						objAddressBook.Address = objDatareader["Address"].ToString();
						objAddressBook.Name = objDatareader["Name"].ToString();
						objAddressBook.PhoneNumber = objDatareader["PhoneNumber"].ToString();
						
						List.Add(objAddressBook);

					}
					// finally close the object
					objDatareader.Close();
					
				}
				catch
				{
				}
				
			}
		/// <summary>
		/// This method loads addresses by addressid.
		/// addressid represents 
		/// </summary>
		public void loadAddress(int intAddressid)
		{
			IDataReader objDatareader = null;

			try
			{
					
				// get the addresses from the database component
				// addressBookDB
				objDatareader = objaddressBookDB.GetAddresses(intAddressid);
				// loop through the datareader and load the
				// address 
				while (objDatareader.Read())
				{
					AddressBook objAddressBook ;
					objAddressBook = new AddressBook();
					// set the value
					objAddressBook.addressId = (int)objDatareader["Addressid"];
					objAddressBook.Address = objDatareader["Address"].ToString();
					objAddressBook.Name = objDatareader["Name"].ToString();
					objAddressBook.PhoneNumber = objDatareader["PhoneNumber"].ToString();
					// add the object to the collection
					List.Add(objAddressBook);
				}
				// finally close the object
				objDatareader.Close();
					
			}
			catch
			{
			}
				
		}
		
	}

}
