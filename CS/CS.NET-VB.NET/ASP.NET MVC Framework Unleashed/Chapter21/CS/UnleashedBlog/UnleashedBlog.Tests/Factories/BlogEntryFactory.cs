using System;
using UnleashedBlog.Models;

namespace UnleashedBlog.Tests
{

    /// <summary>
    /// The BlogEntry Factory creates blog entries. Because we might
    /// change the properties of a blog entry, creating blog entries
    /// at one central location makes our tests easier to change.
    /// </summary>
    public class BlogEntryFactory
    {

        public static BlogEntry Get()
        {
            var blogEntry = new BlogEntry();
            blogEntry.Title = "Test Entry";
            blogEntry.Name = "Test Entry";
            blogEntry.Text = "Blog text";
            blogEntry.DatePublished = new DateTime(2010, 12, 25);
            blogEntry.Author = "Stephen";
            blogEntry.Description = "The Description";
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

        public static BlogEntry GetWithAuthor(string author)
        {
            var blogEntry = Get();
            blogEntry.Author = author;
            return blogEntry;
        }

        public static BlogEntry GetWithDescription(string description)
        {
            var blogEntry = Get();
            blogEntry.Description = description;
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
