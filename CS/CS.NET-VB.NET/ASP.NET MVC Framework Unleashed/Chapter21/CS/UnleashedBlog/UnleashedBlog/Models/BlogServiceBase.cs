using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Paging;

namespace UnleashedBlog.Models
{
    public abstract class BlogServiceBase
    {
        protected ModelStateDictionary _modelState;
        protected BlogRepositoryBase _blogRepository;

        public BlogServiceBase(ModelStateDictionary modelState, BlogRepositoryBase blogRepository)
        {
            _modelState = modelState;
            _blogRepository = blogRepository;
        }

        // Blog entry methods
        public abstract BlogEntry GetBlogEntry(int year, int month, int day, string name);
        public abstract BlogEntry GetBlogEntry(int id);
        public abstract PagedList<BlogEntry> ListBlogEntries(int? page);
        public abstract PagedList<BlogEntry> ListBlogEntries(int? page, int? year, int? month, int? day);
        public abstract bool CreateBlogEntry(BlogEntry blogEntryToCreate);

        // Comment methods
        public abstract bool CreateComment(Comment commentToCreate);

        // Archive Info method
        public abstract IList<ArchiveInfo> ListBlogEntriesByMonth();

    }
}
