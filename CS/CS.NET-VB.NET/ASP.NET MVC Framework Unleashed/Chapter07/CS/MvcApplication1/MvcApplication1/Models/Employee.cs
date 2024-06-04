using System.Web.Mvc;

namespace MvcApplication1.Models
{
    [Bind(Exclude="Id")]
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
