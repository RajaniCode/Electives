using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnleashedBlog.Controllers;
using UnleashedBlog.Models;
using UnleashedBlog.Tests.Factories;

namespace UnleashedBlog.Tests.Controllers
{

    [TestClass]
    public class ApplicationControllerTests
    {
        private ControllerFactory _controllerFactory;
        private ApplicationController _applicationController; 

        [TestInitialize]
        public void Initialize()
        {
            _controllerFactory = new ControllerFactory();
            _applicationController = _controllerFactory.GetApplicationController();
        }

        /// <summary>
        /// Verifies that ArchiveInfo (used by the ArchiveMenu) gets into view data
        /// </summary>
        [TestMethod]
        public void AddsArchiveInfoToViewData()
        {
            // Assert
            Assert.IsInstanceOfType(_applicationController.ViewData["ArchiveInfo"], typeof(IList<ArchiveInfo>));
        }
    }
}
