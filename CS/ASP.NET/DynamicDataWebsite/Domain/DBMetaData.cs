using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Domain
{
    [MetadataType(typeof(ContactMetadata))]
    [DisplayColumn("LastName", "LastName")]
    public partial class Contact
    {
        private string _newEmail;

        partial void OnEmailChanging(string value)
        {
            this._newEmail = value;
        }

        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if (action == System.Data.Linq.ChangeAction.Insert)
            {
                using (DBDataContext db = new DBDataContext())
                {
                    var email = from c in db.Contacts
                                where c.Email == this._newEmail
                                select c.Email;

                    if (email.Count() > 0)
                    {
                        throw new ValidationException("Email addresses must be unique.");
                    }
                }
            }
        }
    }

    public class ContactMetadata
    {
        [DisplayName("Email Address")]
        [Required]
        [RegularExpression(@"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$",
            ErrorMessage = "A valid email address is required.")]
        [StringLength(150,
            ErrorMessage = "Your email address is too long.")]
        [UIHint("Email")]
        public object Email { get; set; }

        //[UIHint("Url", null, "EnableTest", "false")]
        //public object Url { get; set; }

        [UIHint("Url")]
        public object Url { get; set; }

        [Range(10, 20, ErrorMessage = "Font size must be a value from 10 to 20.")]
        public object PreferredFontSize { get; set; }

        [DisplayFormat(DataFormatString = "{0:g}")]
        public object CreatedOn { get; set; }

        [ScaffoldColumn(false)]
        public object ConcurrencyID { get; set; }
    }

    [ScaffoldTable(false)]
    public partial class aspnet_Applications { }
}
