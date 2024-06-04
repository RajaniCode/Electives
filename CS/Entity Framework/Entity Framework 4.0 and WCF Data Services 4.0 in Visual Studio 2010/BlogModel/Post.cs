using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogModel
{
    public class Post
    {
        
        public int ID
        {
            get;
            set;
        }

        public DateTime CreatedDate
        {
            get;
            set;
        }

        public DateTime ModifiedDate
        {
            get;
            set;
        }

        public string Title
        {
            get;
            set;
        }

        public string PostContent
        {
            get;
            set;
        }

        public Blog Blog
        {
            get;
            set;
        }

        public int BlogBlogID
        {
            get;
            set;
        }

        public Boolean Public
        {
            get;
            set;
        }

        public List<Tag> Tags
        {
            get { return _tags; }
            set { _tags = value; }
        }
        private List<Tag> _tags = new List<Tag>();
    }
}