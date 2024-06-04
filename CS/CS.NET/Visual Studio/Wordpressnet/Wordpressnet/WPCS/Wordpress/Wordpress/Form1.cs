using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using CookComputing.XmlRpc;





namespace Wordpress
{
    public struct blogInfo
    {
        public string title;
        public string description;
    }
    

     public interface IgetCatList
 {
     [CookComputing.XmlRpc.XmlRpcMethod("metaWeblog.newPost")]
     string NewPage(int blogId, string strUserName, string strPassword, blogInfo content, int publish);
 }



    public partial class Form1 : Form
    {
        

      public XmlRpcClientProtocol clientProtocol;
      public IgetCatList categories;


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnPost_Click(object sender, EventArgs e)
        {
          
     blogInfo newBlogPost = default(blogInfo);
            
     newBlogPost.title = txtTitle.Text;
     newBlogPost.description = txtPost.Text;
    
     categories = (IgetCatList)XmlRpcProxyGen.Create(typeof(IgetCatList));
     clientProtocol = (XmlRpcClientProtocol)categories;
    
     clientProtocol.Url = "http://127.0.0.1/wpl/xmlrpc.php";
    
     string result = null;
     result = "";
    
     try {
         result = categories.NewPage(1, "shoban", "shoban", newBlogPost, 1);
         MessageBox.Show("Posted to Blog successfullly! Post ID : " + result);
         txtPost.Text = "";
         txtTitle.Text = "";
     }
     catch (Exception ex) {
         MessageBox.Show(ex.Message);
     }

        }
    }
}
