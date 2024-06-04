    using System.Web.Mvc;
    using EFMvcApplication.Models;

    namespace EFMvcApplication.Controllers
    {
        public class ProductCountController : Controller
        {
            private IRepository _repository;

            public ProductCountController()
            {
                _repository = new Repository(new ToyStoreDBEntities());
            }

            //
            // GET: /ProductCount/

            public int Index()
            {
                return _repository.GetProductCount();
            }

        }
    }
