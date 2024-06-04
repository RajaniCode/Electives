using System;
namespace UnleashedBlog.Models
{
    public class BlogEntry
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime? DateModified { get; set; }
        public DateTime DatePublished { get; set; } 
        public string Name { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }

    }
}
