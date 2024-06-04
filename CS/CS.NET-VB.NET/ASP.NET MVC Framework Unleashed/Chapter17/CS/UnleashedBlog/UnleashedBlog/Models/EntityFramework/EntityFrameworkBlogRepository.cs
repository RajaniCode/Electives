using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UnleashedBlog.Models.EntityFramework
{
    public class EntityFrameworkBlogRepository : BlogRepositoryBase
    {
        private BlogDBEntities _entities = new BlogDBEntities();

        private BlogEntryEntity ConvertBlogEntryToBlogEntryEntity(BlogEntry entry)
        {
            var entity = new BlogEntryEntity();

            entity.Id = entry.Id;
            entity.Author = entry.Author;
            entity.Description = entry.Description;
            entity.Name = entry.Name;
            entity.DatePublished = entry.DatePublished;
            entity.Text = entry.Text;
            entity.Title = entry.Title;
            return entity;
        }

        protected override IQueryable<BlogEntry> QueryBlogEntries()
        {
            return from e in _entities.BlogEntryEntitySet
                   select new BlogEntry 
                   { 
                        Id = e.Id,
                        Author = e.Author,
                        Description = e.Description,
                        Name = e.Name, 
                        DateModified = e.DateModified,
                        DatePublished = e.DatePublished,
                        Text = e.Text,
                        Title = e.Title
                   };
        }
        
        public override List<BlogEntry> ListBlogEntries()
        {
            return QueryBlogEntries().ToList();            
        }

        public override void CreateBlogEntry(BlogEntry blogEntryToCreate)
        {
            var entity = ConvertBlogEntryToBlogEntryEntity(blogEntryToCreate);

            _entities.AddToBlogEntryEntitySet(entity);
            _entities.SaveChanges();
        }

    }
}
