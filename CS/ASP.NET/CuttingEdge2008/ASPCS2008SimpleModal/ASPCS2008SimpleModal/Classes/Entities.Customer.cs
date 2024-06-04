using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections.ObjectModel;
using System.Threading;
using System.ComponentModel;


namespace ASPCS2008SimpleModal
{
    public class CustomerCommands
    {
        public static string cmdLoadAll = "SELECT * FROM customers";
        public static string cmdLoad = "SELECT * FROM customers WHERE customerid=@id";
        public static string cmdLoadInitial = "SELECT * FROM customers WHERE companyname LIKE @initial + '%'";
        public static string cmdLoadSouthAmerica = "SELECT * FROM customers WHERE country IN ('Mexico', 'Brazil', 'Argentina', 'Venezuela')";
        public static string cmdOrdersAll = "SELECT orderid, orderdate FROM orders WHERE customerid=@id";

        public static string cmdUpdate = "UPDATE customers SET contactname=@contactname WHERE customerid=@id";
    }

    // CLASS Customer: holds information about the customer
    public class Customer
    {
        private string _companyname, _contactname, _contacttitle, _id;
        private string _street, _postalcode, _city, _country, _phone, _region, _fax;

        public Customer()
        {
        }

        #region PROPERTIES

        // ID
        [DataObjectField(true)]
        public string ID
        {
            get { return _id; }
            set { _id = value; }
        }

        // CompanyName
        [DataObjectField(false)]
        public string CompanyName
        {
            get { return _companyname; }
            set { _companyname = value; }
        }

        // ContactName
        [DataObjectField(false)]
        public string ContactName
        {
            get { return _contactname; }
            set { _contactname = value; }
        }

        // ContactTitle
        public string ContactTitle
        {
            get { return _contacttitle; }
            set { _contacttitle = value; }
        }

        // Street
        public string Street
        {
            get { return _street; }
            set { _street = value; }
        }

        // PostalCode
        public string PostalCode
        {
            get { return _postalcode; }
            set { _postalcode = value; }
        }

        // City
        public string City
        {
            get { return _city; }
            set { _city = value; }
        }

        // Country
        [DataObjectField(false)]
        public string Country
        {
            get { return _country; }
            set { _country = value; }
        }

        // Phone
        public string Phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        // Fax
        public string Fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        // Region
        public string Region
        {
            get { return _region; }
            set { _region = value; }
        }

        // Tag (for the special case pattern to distinguish class types without checking type info)
        public virtual string Tag
        {
            get { return "Customer"; }
        }
        #endregion  
    }

    // CLASS InvalidCustomer: represents an invalid customer instance
    public sealed class InvalidCustomer : Customer
    {
        public static readonly InvalidCustomer Instance = new InvalidCustomer(); 
        
        public override string Tag
        {
	        get { return "InvalidCustomer"; }
        }
    }



    // CLASS CustomerCollection: collection of Customer objects
    public class CustomerCollection : Collection<Customer>
    {
    }


    // CLASS CustomerManager: data-mapper class for the customer entity
    public class CustomerManager
    {
        public static string ConnectionString
        {
            get { return ConfigurationManager.ConnectionStrings["NorthwindConnectionString"].ConnectionString; }
        }

        #region METHOD: Load
        public static Customer Load(string id)
        {
            if (String.IsNullOrEmpty(id))
                return InvalidCustomer.Instance;   

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(CustomerCommands.cmdLoad, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                Customer cust = HelperMethods.GetCustomer(reader);
                reader.Close();
                conn.Close();

                return cust;
            }
        }
        #endregion


        #region METHOD: LoadAll
        public static CustomerCollection LoadAll()
        {
            CustomerCollection coll = new CustomerCollection();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(CustomerCommands.cmdLoadAll, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                HelperMethods.FillCustomerList(coll, reader);
                reader.Close();
                conn.Close();
            }

            return coll;
        }
       #endregion


        #region METHOD: LoadByInitial
        public static CustomerCollection LoadByInitial()
        {
            return LoadByInitial(null);
        }
        public static CustomerCollection LoadByInitial(string query)
        {
            Thread.Sleep(3000);

            if (String.IsNullOrEmpty(query))
                return CustomerManager.LoadAll();


            CustomerCollection coll = new CustomerCollection();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(CustomerCommands.cmdLoadInitial, conn);
                cmd.Parameters.AddWithValue("@initial", query);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                HelperMethods.FillCustomerList(coll, reader);
                reader.Close();
                conn.Close();
            }

            return coll;
        }
        #endregion


        #region METHOD: LoadFromSouthAmerica
        public static CustomerCollection LoadFromSouthAmerica()
        {
            CustomerCollection coll = new CustomerCollection();

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(CustomerCommands.cmdLoadSouthAmerica, conn);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                HelperMethods.FillCustomerList(coll, reader);
                reader.Close();
                conn.Close();
            }

            return coll;
        }
        #endregion


        #region METHOD: Save (only ContactName !!!)
        public static Customer Save(Customer cust)
        {
            if (cust == null)
                return InvalidCustomer.Instance;

            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(CustomerCommands.cmdUpdate, conn);
                cmd.Parameters.AddWithValue("@id", cust.ID);
                cmd.Parameters.AddWithValue("@contactname", cust.ContactName);

                conn.Open();
                cmd.ExecuteNonQuery(); 
                conn.Close();
            }
                return cust;

        }
        #endregion


        #region METHOD: FindOrdersByCustomerAsMarkup
        public static string FindOrdersByCustomerAsMarkup(string id)
        {
            using (SqlConnection conn = new SqlConnection(ConnectionString))
            {
                SqlCommand cmd = new SqlCommand(CustomerCommands.cmdOrdersAll, conn);
                cmd.Parameters.AddWithValue("@id", id);

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();
                string markup = HelperMethods.ComposeOrdersAsGrid(reader);
                reader.Close();
                conn.Close();

                return markup;
            }
        }
        #endregion    
    }
}
