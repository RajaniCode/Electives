using System;
using System.Text.RegularExpressions;
using System.Web.Mvc;
using Paging;
using UnleashedBlog.Models.EntityFramework;
using System.Collections.Generic;

namespace UnleashedBlog.Models
{
    public class BlogService : BlogServiceBase
    {

        public BlogService(ModelStateDictionary modelState)
            : base(modelState, new EntityFrameworkBlogRepository()) { }

        public BlogService(ModelStateDictionary modelState, BlogRepositoryBase blogRepository)
            : base(modelState, blogRepository) { }



        public override BlogEntry GetBlogEntry(int year, int month, int day, string name)
        {
            return _blogRepository.GetBlogEntry(year, month, day, name);
        }

        public override BlogEntry GetBlogEntry(int id)
        {
            return _blogRepository.GetBlogEntry(id);
        }

        public override PagedList<BlogEntry> ListBlogEntries(int? page)
        {
            return _blogRepository.ListBlogEntries(page, null, null, null);
        }


        public override PagedList<BlogEntry> ListBlogEntries(int? page, int? year, int? month, int? day)
        {
            return _blogRepository.ListBlogEntries(page, year, month, day);
        }


        public override bool CreateBlogEntry(BlogEntry blogEntryToCreate)
        {
            // validation
            if (blogEntryToCreate.Title.Trim().Length == 0)
                _modelState.AddModelError("Title", "Title is required.");
            if (blogEntryToCreate.Title.Length > 500)
                _modelState.AddModelError("Title", "Title is too long.");
            if (blogEntryToCreate.Text.Trim().Length == 0)
                _modelState.AddModelError("Text", "Text is required.");
            if (blogEntryToCreate.Author.Trim().Length == 0)
                _modelState.AddModelError("Author", "Author is required.");
            if (blogEntryToCreate.Description.Trim().Length == 0)
                _modelState.AddModelError("Description", "Description is required.");
            if (_modelState.IsValid == false)
                return false;

            // Business Rules
            if (String.IsNullOrEmpty(blogEntryToCreate.Name))
                blogEntryToCreate.Name = blogEntryToCreate.Title;
            blogEntryToCreate.Name = blogEntryToCreate.Name.Replace(" ", "-");
            blogEntryToCreate.Name = Regex.Replace(blogEntryToCreate.Name, "[\"$&+,/:;=?@]", string.Empty);

            if (blogEntryToCreate.DatePublished == DateTime.MinValue)
                blogEntryToCreate.DatePublished = DateTime.Now;

            // Data access
            _blogRepository.CreateBlogEntry(blogEntryToCreate);
            return true;
        }

        // Comment Methods

        public override bool CreateComment(Comment commentToCreate)
        {
            // Validation
            if (commentToCreate.Title.Trim().Length == 0)
                _modelState.AddModelError("Title", "Title is required.");
            if (commentToCreate.Name.Trim().Length == 0)
                _modelState.AddModelError("Name", "Name is required.");
            if (commentToCreate.Text.Trim().Length == 0)
                _modelState.AddModelError("Text", "Comment is required.");
            if (_modelState.IsValid == false)
                return false;

            // Business rules
            if (commentToCreate.DatePublished == DateTime.MinValue)
                commentToCreate.DatePublished = DateTime.Now;

            // Data access
            _blogRepository.CreateComment(commentToCreate);
            return true;
        }


        // Archive Info methods
        public override IList<ArchiveInfo> ListBlogEntriesByMonth()
        {
            return (IList<ArchiveInfo>)_blogRepository.ListBlogEntriesByMonth();
        }

    }
}
