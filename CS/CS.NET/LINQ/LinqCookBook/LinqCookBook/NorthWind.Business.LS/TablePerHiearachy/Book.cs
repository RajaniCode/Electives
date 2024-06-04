using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq.Mapping;

namespace NorthWind.Business.LS.TablePerHiearachy
{
    public enum BookType
    {
        Technical=1,
        Certification = 2,
        Cooking = 3,
        Novel = 4
    }
    [Table]
    [InheritanceMapping(Code=BookType.Novel,Type=typeof(Novel),IsDefault=true)]
    [InheritanceMapping(Code = BookType.Cooking, Type = typeof(CookingBook))]
    [InheritanceMapping(Code = BookType.Technical, Type = typeof(TecnnicalBook))]
    [InheritanceMapping(Code = BookType.Certification, Type = typeof(CertificationBook))]
    public abstract class Book
    {
        [Column(IsPrimaryKey=true,IsDbGenerated=true)]
        public int BookId { get; set; }

        [Column]
        public string Title { get; set; }

        [Column(IsDiscriminator=true)]
        public int Type { get; set; }
    }

    public class TecnnicalBook:Book
    {
        [Column]
        public string Technology { get; set; }
    }

    public class CertificationBook : TecnnicalBook
    {
        [Column]
        public string Exam { get; set; }
    }
    public class CookingBook:Book
    {
        [Column]
        public bool ReceipesAvailable { get; set; }
    }
    public class Novel:Book
    {
        [Column]
        public bool TrueStory { get; set; }
    }
}
