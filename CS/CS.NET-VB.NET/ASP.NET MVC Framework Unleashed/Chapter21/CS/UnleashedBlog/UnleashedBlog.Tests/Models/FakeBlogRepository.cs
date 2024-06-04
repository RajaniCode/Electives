using System.Collections.Generic;
using System.Linq;
using UnleashedBlog.Models;

namespace UnleashedBlog.Tests.Models
{
    /// <summary>
    /// This is the fake blog repository used during testing. The
    /// fake blog repository stores data items in memory.
    /// </summary>
    public class FakeBlogRepository : BlogRepositoryBase
    {
        private List<BlogEntry> _blogEntries = new List<BlogEntry>();
        private List<Comment> _comments = new List<Comment>();

        // Blog Entry methods

        protected override IQueryable<BlogEntry> QueryBlogEntries()
        {
            return from e in _blogEntries.AsQueryable()
                   select new BlogEntry
                       {
                           Id = e.Id,
                           Author = e.Author,
                           Description = e.Description,
                           Name = e.Name,
                           DateModified = e.DateModified,
                           DatePublished = e.DatePublished,
                           Text = e.Text,
                           Title = e.Title,
                           CommentCount = (from c in _comments.AsQueryable()
                                           where c.BlogEntryId == e.Id
                                           select c).Count()

                       };
        }

        
        public override void CreateBlogEntry(BlogEntry blogEntryToCreate)
        {
            _blogEntries.Add(blogEntryToCreate);
        }

        // Comment methods

        protected override IQueryable<Comment> QueryComments()
        {
            return _comments.AsQueryable();
        }

        public override void CreateComment(Comment commentToCreate)
        {
            _comments.Add(commentToCreate);
        }

    
    }
}
