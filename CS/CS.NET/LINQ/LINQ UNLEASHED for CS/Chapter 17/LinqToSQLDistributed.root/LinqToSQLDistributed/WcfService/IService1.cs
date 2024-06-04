using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.Linq;
using System.Data.Linq.Mapping;


namespace WcfService
{
  // NOTE: If you change the interface name "IService1" here, you must also update the reference to "IService1" in App.config.
  [ServiceContract]
  public interface IService1
  {
    [OperationContract]
    List<Customer> GetCustomers();
    [OperationContract]
    void UpdateCustomer(Customer orignal, Customer modified);
  }

  public class Northwind : DataContext
  {
    private static readonly string connectionString = 
      "Data Source=BUTLER;Initial Catalog=Northwind;Integrated Security=True";

    public Northwind(): base(connectionString){}
  }


  [DataContract]
  [Table(Name="Customers")]
  public class Customer
  {
    [DataMember]
    [Column(IsPrimaryKey=true)]
    public string CustomerID{ get; set; }

    [DataMember]
    [Column]
    public string CompanyName{ get; set; }

    [DataMember]
    [Column]
    public string ContactName{ get; set; }
    
    [DataMember]
    [Column]
    public string ContactTitle{ get; set; }

    [DataMember]
    [Column]
    public string Address{ get; set; }
    
    [DataMember]
    [Column]
    public string City{ get; set; }
    
    [DataMember]
    [Column]
    public string Region{ get; set; }
    
    [DataMember]
    [Column]
    public string PostalCode{ get; set; }
    
    [DataMember]
    [Column]
    public string Country{ get; set; }
    
    [DataMember]
    [Column]
    public string Phone{ get; set; }
    
    [DataMember]
    [Column]
    public string Fax{ get; set; }
  }
}
