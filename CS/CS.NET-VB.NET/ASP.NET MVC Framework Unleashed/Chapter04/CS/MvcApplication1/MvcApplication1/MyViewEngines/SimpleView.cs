using System.IO;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace MvcApplication1.MyViewEngines
{
    public class SimpleView : IView
    {
        private string _viewPhysicalPath;

        public SimpleView(string viewPhysicalPath)
        {
            _viewPhysicalPath = viewPhysicalPath;
        }
        
        #region IView Members

        public void Render(ViewContext viewContext, TextWriter writer)
        {
            // Load file
            string rawContents = File.ReadAllText(_viewPhysicalPath);

            // Perform replacements
            string parsedContents = Parse(rawContents, viewContext.ViewData);

            // Write results to HttpContext
            writer.Write(parsedContents);
        }

        #endregion

        public string Parse(string contents, ViewDataDictionary viewData)
        {
            return Regex.Replace(contents, "\\{(.+)\\}",m => GetMatch(m, viewData));
        }

        protected virtual string GetMatch(Match m, ViewDataDictionary viewData)
        {
            if (m.Success)
            {
                string key = m.Result("$1");
                if (viewData.ContainsKey(key))
                {
                    return viewData[key].ToString();
                }
            }
            return string.Empty;
        }
    
    }
}
