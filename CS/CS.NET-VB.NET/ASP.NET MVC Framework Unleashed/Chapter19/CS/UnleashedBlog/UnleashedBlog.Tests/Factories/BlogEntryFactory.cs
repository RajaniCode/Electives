using System;
using UnleashedBlog.Models;

namespace UnleashedBlog.Tests
{
    public class BlogEntryFactory
    {

        public static BlogEntry Get()
        {
            var blogEntry = new BlogEntry();
            blogEntry.Title = "Test Entry";
            blogEntry.Name = "Test Entry";
            blogEntry.Text = "Blog text";
            blogEntry.DatePublished = new DateTime(2010, 12, 25);
            return blogEntry;
        }

        public static BlogEntry GetWithDatePublished(DateTime datePublished)
        {
            var blogEntry = Get();
            blogEntry.DatePublished = datePublished;
            return blogEntry;
        }

        public static BlogEntry GetWithTitle(string title)
        {
            var blogEntry = Get();
            blogEntry.Title = title;
            return blogEntry;
        }


        public static BlogEntry GetWithName(string name)
        {
            var blogEntry = Get();
            blogEntry.Name = name;
            return blogEntry;
        }


        public static BlogEntry GetWithText(string text)
        {
            var blogEntry = Get();
            blogEntry.Text = text;
            return blogEntry;
        }


    }
}
