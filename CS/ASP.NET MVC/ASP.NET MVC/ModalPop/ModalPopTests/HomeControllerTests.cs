using ModalPop.Controllers;
using ModalPop.Models;
using NUnit.Framework;
using MvcContrib.TestHelper;
using NUnit.Framework.SyntaxHelpers;

namespace ModalPopTests
{
    [TestFixture]
    public class HomeControllerTests
    {
        protected HomeController _homeController;

        [SetUp]
        public void Setup()
        {
            _homeController = new HomeController();    
        }

        [Test]
        public void Random_modal_popup_view_should_render_partial()
        {
            var result = _homeController.RandomPopupView();

            result.AssertPartialViewRendered().ForView("RandomModal").WithViewData<ModalModel>();
        }

        [Test]
        public void Random_modal_for_detail_view_of_grid_row_should_render_partial_with_detail_data()
        {
            var result = _homeController.RandomDetailsPopupView("45");

            result.AssertPartialViewRendered().ForView("RandomModal").WithViewData<ModalModel>();

            Assert.That(((ModalModel) result.ViewData.Model).SomeString,
                        Is.EqualTo("Looks like you clicked on row for record number 45"));
        }
    }
}