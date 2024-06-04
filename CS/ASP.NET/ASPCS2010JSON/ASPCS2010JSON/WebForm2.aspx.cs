using System;
using System.Collections.Generic;

namespace ASPCS2010JSON
{
    //public
    public class Employee
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public DateTime LoginTime { get; set; }
    }

    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Employee Emp = new Employee();
            Emp.Name = "Bill";
            Emp.Age = 30;
            Emp.LoginTime = DateTime.Now;

            //Serializing
            string SerializedClassString = JsonForGenericCollections<Employee>.JsonSerialize(Emp);
            //string LogTime = P.LoginTime.ToString("yyyy-MM-dd HH:mm:ss");
            //SerializedClassString = "{\"Age\":30,\"LastLoginTime\":\"" + LogTime + "\",\"Name\":\"Bill\"}";

            Response.Write(SerializedClassString + "<br /><br />");

            //Deserializing
            Employee DeserializedClass = JsonForGenericCollections<Employee>.JsonDeserialize(SerializedClassString);

            List<Employee> PersonList = new List<Employee>()
            {
                new Employee(){ Name= "Bill", Age = 30, LoginTime = DateTime.Now},
                new Employee(){ Name= "Lucy", Age = 27, LoginTime = DateTime.Now.AddHours(1D)}
            };

            string SerializedListString = JsonForGenericCollections<List<Employee>>.JsonSerialize(PersonList);

            Response.Write(SerializedListString + "<br /><br />");

            //Deserializing
            List<Employee> DeserializedList = JsonForGenericCollections<List<Employee>>.JsonDeserialize(SerializedListString);

            Dictionary<string, string> PersonDictionary = new Dictionary<string, string>();
            PersonDictionary.Add("Name", "Bill"); 
            PersonDictionary.Add("Age", "30");

            string SerializedDictionaryString = JsonForGenericCollections<Dictionary<string, string>>.JsonSerialize(PersonDictionary);

            Response.Write(SerializedDictionaryString);

            //Deserializing
            Dictionary<string, string> DeserializedDictionary = JsonForGenericCollections<Dictionary<string, string>>.JsonDeserialize(SerializedDictionaryString);
        }
    }
}
