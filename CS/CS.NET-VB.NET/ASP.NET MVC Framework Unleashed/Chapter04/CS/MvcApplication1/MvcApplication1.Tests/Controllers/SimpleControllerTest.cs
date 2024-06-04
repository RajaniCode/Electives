using System.IO;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MvcApplication1.MyViewEngines;

namespace MvcApplication1.Tests.Controllers
{
    [TestClass]
    public class SimpleControllerTest
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }


        [TestMethod]
        public void IndexView()
        {
            // Create simple view
            var viewPhysicalPath = testContextInstance.TestDir + @"\..\..\MvcApplication1\Views\Simple\Index.simple";
            var indexView = new SimpleView(viewPhysicalPath);

            // Create view context
            var viewContext = new ViewContext();

            // Create view data
            var viewData = new ViewDataDictionary();
            viewData["message"] = "Hello World!";
            viewContext.ViewData = viewData;

            // Render simple view
            var writer = new StringWriter();
            indexView.Render(viewContext, writer);

            // Assert
            StringAssert.Contains(writer.ToString(), "<h1>Hello World!</h1>");
        }
    }
}
