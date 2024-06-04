using System;

namespace ASPCS2010JSON
{
    //public
    public class Customer
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Customer Cust = new Customer();
            Cust.Name = "Bill";
            Cust.Age = 30;

            //Serializing simple object Person
            string SerializedClassString = Json.JsonSerialize<Customer>(Cust);

            //Disable DivX browser plugin
            Response.Write(SerializedClassString);

            //Deserializing
            Customer DeserializedClass = Json.JsonDeserialize<Customer>(SerializedClassString);

            //Deserializing
            string DeserializedClassString = "{\"Age\":30,\"Name\":\"Bill\"}";
            DeserializedClass = Json.JsonDeserialize<Customer>(DeserializedClassString);
        }
    }
}