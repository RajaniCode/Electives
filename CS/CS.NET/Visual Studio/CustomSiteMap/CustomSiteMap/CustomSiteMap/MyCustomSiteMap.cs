using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace CustomSiteMap
{
    public class MyCustomSiteMap : StaticSiteMapProvider
    {
        private SiteMapNode parentNode
        {
            get;
            set;
        }

        private string ExcludedFolders
        {
            get
            {
                return "(App_Data)|(obj)";
            }
        }

        private string ExcludedFiles
        {
            get
            {
                return "";
            }
        }

        public override SiteMapNode BuildSiteMap()
        {
            lock (this)
            {
                parentNode = HttpContext.Current.Cache["SiteMap"] as SiteMapNode;
                if (parentNode == null)
                {                    
                    base.Clear();                    
                    parentNode = new SiteMapNode(this,
                                            HttpRuntime.AppDomainAppVirtualPath,
                                            HttpRuntime.AppDomainAppVirtualPath + "Default.aspx", 
                                            "Home");
                    
                    AddNode(parentNode);                    
                    AddFolders(parentNode);                    
                    HttpContext.Current.Cache.Insert("SiteMap", parentNode);
                }
                return parentNode;
            }
        }

        private void AddFolders(SiteMapNode parentNode)
        {
            var folders = from o in Directory.GetDirectories(HttpContext.Current.Server.MapPath(parentNode.Key))
                          let dir = new DirectoryInfo(o)
                          where !Regex.Match(dir.Name, ExcludedFolders).Success
                          select new
                          {
                              DirectoryName = dir.Name
                          };
            
            foreach (var item in folders)
            {
                string folderUrl = parentNode.Key + item.DirectoryName;
                SiteMapNode folderNode = new SiteMapNode(this, 
                                    folderUrl, 
                                    null, 
                                    item.DirectoryName, 
                                    item.DirectoryName);
                
                AddNode(folderNode, parentNode);
                AddFiles(folderNode);
            }
        }

        private void AddFiles(SiteMapNode folderNode)
        {
            var files = from o in Directory.GetFiles(HttpContext.Current.Server.MapPath(folderNode.Key))
                        let fileName = new FileInfo(o)                        
                        select new
                        {
                            FileName = fileName.Name                            
                        };
            
            foreach (var item in files)
            {
                SiteMapNode fileNode = new SiteMapNode(this, 
                                    item.FileName, 
                                    folderNode.Key + "/" + item.FileName,
                                    item.FileName);
                AddNode(fileNode, folderNode);
            }
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            return BuildSiteMap();
        }
    }
}
