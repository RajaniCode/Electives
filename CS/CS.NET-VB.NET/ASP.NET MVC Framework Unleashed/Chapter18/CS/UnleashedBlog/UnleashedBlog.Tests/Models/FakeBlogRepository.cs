using System.Collections.Generic;
using System.Linq;
using UnleashedBlog.Models;

namespace UnleashedBlog.Tests.Models
{
    public class FakeBlogRepository : BlogRepositoryBase
    {
        private List<BlogEntry> _blogEntries = new List<BlogEntry>();

        protected override IQueryable<BlogEntry> QueryBlogEntries()
        {
            return _blogEntries.AsQueryable();
        }

        public override List<BlogEntry> ListBlogEntries()
        {
            return this.QueryBlogEntries().ToList();
        }

        public override void CreateBlogEntry(BlogEntry blogEntryToCreate)
        {
            _blogEntries.Add(blogEntryToCreate);
        }
    }
}
