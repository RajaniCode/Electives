using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Data.Services.Client;
using BlogManager.BlogService;

namespace BlogManager
{
    public partial class MainPage : UserControl
    {
        DataServiceCollection<Blog> blogs;
        long totalPostCount;
        BlogContext svc;

        public MainPage()
        {
            InitializeComponent();

            svc = new BlogContext(new Uri("/BlogService.svc", UriKind.Relative));

            blogs = new DataServiceCollection<Blog>(svc);
            this.LayoutRoot.DataContext = blogs;
            
            blogs.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(blogs_LoadCompleted);
            var q = svc.Blogs;
            blogs.LoadAsync(q);            
        }

        void blogs_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                if (blogs.Count > 0)
                {
                    cboBlogs.SelectedIndex = 0;
                }
            }
        }

        private void cboBlogs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Blog curBlog = this.cboBlogs.SelectedItem as Blog;
            this.grdPosts.DataContext = curBlog;

            var q = (from p in svc.Posts.IncludeTotalCount()
                     where p.BlogBlogID == curBlog.ID
                     select p) as DataServiceQuery<Post>;

            curBlog.Posts.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(Posts_LoadCompleted);
            curBlog.Posts.LoadAsync(q);

        }

        void Posts_LoadCompleted(object sender, LoadCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Blog curBlog = cboBlogs.SelectedItem as Blog;
                totalPostCount = e.QueryOperationResponse.TotalCount;
                string postsCount = string.Format("Displaying {0} of {1} posts",
                    curBlog.Posts.Count, totalPostCount);
                this.lblCount.Content = postsCount;

                curBlog.Posts.LoadCompleted -= Posts_LoadCompleted;
            }
        }

        private void btnMorePosts_Click(object sender, RoutedEventArgs e)
        {
            Blog curBlog = cboBlogs.SelectedItem as Blog;
            curBlog.Posts.LoadCompleted += new EventHandler<LoadCompletedEventArgs>(Posts_LoadCompleted);
            curBlog.Posts.LoadNextPartialSetAsync();
        }

        private void btnSave_Click_1(object sender, RoutedEventArgs e)
        {
            svc.BeginSaveChanges(SaveChangesOptions.Batch, OnChangesSaved, svc);
        }

        private void OnChangesSaved(IAsyncResult result)
        {
            var q = result.AsyncState as BlogContext;
            try
            {
                // Complete the save changes operation
                q.EndSaveChanges(result);
            }
            catch (Exception ex)
            {
                // Display the error from the response.
                MessageBox.Show(ex.Message);
            }
        }

    }
}
