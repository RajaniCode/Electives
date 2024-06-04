using System.Linq;

namespace UnleashedBlog.Models.EntityFramework
{
    /// <summary>
    /// An implementation of the BlogRepository for the Microsoft Entity Framework.
    /// </summary>
    public class EntityFrameworkBlogRepository : BlogRepositoryBase
    {
        private BlogDBEntities _entities = new BlogDBEntities();

        //___________________________________
        // Blog entry methods
        //___________________________________



        /// <summary>
        /// Converts from an application Blog Entry 
        /// to an Entity Framework BlogEntryEntity.
        /// </summary>
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


        /// <summary>
        /// Returns blog entries from database
        /// converting from Microsot Entity Framework blog entry entities
        /// to application blog entries.
        /// </summary>
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
                        Title = e.Title,
                        CommentCount = (from c in _entities.CommentEntitySet 
                                        where c.BlogEntryId == e.Id 
                                        select c).Count()
                   };
        }



        /// <summary>
        /// Adds a blog entry to the database.
        /// </summary>
        public override void CreateBlogEntry(BlogEntry blogEntryToCreate)
        {
            var entity = ConvertBlogEntryToBlogEntryEntity(blogEntryToCreate);

            _entities.AddToBlogEntryEntitySet(entity);
            _entities.SaveChanges();
        }

        //__________________________
        // Comment methods
        //___________________________


        /// <summary>
        /// Converts an application Comment to a Microsoft Entity Framework
        /// Comment entity.
        /// </summary>
        private CommentEntity ConvertCommentToCommentEntity(Comment comment)
        {
            var entity = new CommentEntity();

            entity.Id = comment.Id;
            entity.BlogEntryId = comment.BlogEntryId;
            entity.DatePublished = comment.DatePublished;
            entity.Email = comment.Email;
            entity.Name = comment.Name;
            entity.Text = comment.Text;
            entity.Title = comment.Title;
            entity.Url = comment.Url;
            return entity;
        }


        /// <summary>
        /// Retrieves comments from the database converting
        /// instances of the Comment Entity class to instances
        /// of the Comment class
        /// </summary>
        protected override IQueryable<Comment> QueryComments()
        {
            return from c in _entities.CommentEntitySet
                   select new Comment
                   {
                       Id = c.Id,
                       BlogEntryId = c.BlogEntryId,
                       DatePublished = c.DatePublished,
                       Email = c.Email,
                       Name = c.Name,
                       Text = c.Text,
                       Title = c.Title,
                       Url = c.Url
                   };
        }

        /// <summary>
        /// Adds a new comment to the database
        /// </summary>
        public override void CreateComment(Comment commentToCreate)
        {
            var entity = ConvertCommentToCommentEntity(commentToCreate);

            _entities.AddToCommentEntitySet(entity);
            _entities.SaveChanges();
        }

    }
}
