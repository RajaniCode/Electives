using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codeFirstSample.Models
{
    [Table("Reviews")] // Table name
    public class Review
    {
        [Key]
        public int ReviewID { get; set; }

        [ForeignKey("Book")]
        public int BookID { get; set; }
        public string ReviewText { get; set; }

        // This will keep track of the book this review belong too
        public virtual Book Book { get; set; }
    }
}