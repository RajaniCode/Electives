using System.Collections.Generic;
using System.Linq;

namespace UnleashedBlog.Models
{
    public abstract class BlogRepositoryBase
    {
        // Blog Entry Methods
        public abstract List<BlogEntry> ListBlogEntries();
        public abstract void CreateBlogEntry(BlogEntry blogEntryToCreate);
        protected abstract IQueryable<BlogEntry> QueryBlogEntries();

        public virtual List<BlogEntry> ListBlogEntries(int? year, int? month, int? day, string name)
        {
            var query = this.QueryBlogEntries();
            if (year.HasValue)
                query = query.Where(e => e.DatePublished.Year == year.Value);
            if (month.HasValue)
                query = query.Where(e => e.DatePublished.Month == month.Value);
            if (day.HasValue)
                query = query.Where(e => e.DatePublished.Day == day.Value);
            if (!string.IsNullOrEmpty(name))
                query = query.Where(e => e.Name == name);
            return query.ToList();
        }

    }
}
