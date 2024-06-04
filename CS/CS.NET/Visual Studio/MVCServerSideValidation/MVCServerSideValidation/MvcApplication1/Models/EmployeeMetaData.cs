using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{
    [MetadataType(typeof(EmployeeMetaData))]
    public partial class Employee
    {
    }

    public class EmployeeMetaData
    {
        [Required]
        [StringLength(10, ErrorMessage="Given name cannot be more than 10 characters")]
        public string GivenName { get; set; }

        [Required]
        public string Surname { get; set; }
    }
}
