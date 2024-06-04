using System.ComponentModel.DataAnnotations;

namespace MvcApplication1.Models
{

    [MetadataType(typeof(CustomerMetaData))]
    public partial class Customer
    {
    }


    public partial class CustomerMetaData
    {
        [Required(ErrorMessage="First name is required.")]
        [StringLength(10, ErrorMessage="First name is too long.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage="Last name is required.")]
        [StringLength(10, ErrorMessage="Last name is too long.")]
        public string LastName { get; set; }

        [Required(ErrorMessage="Email is required.")]
        [RegularExpression(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$", ErrorMessage="Invalid email address.")]
        public string Email { get; set; }

        [StringLength(500, ErrorMessage="Notes are too long.")]
        public string Notes { get; set; }
    }

}
