using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookDetailMVCApp.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            
            BookDetailMVCApp.Models.ClassBook bs = new BookDetailMVCApp.Models.ClassBook();
            bs.BName = "Black Book ASP.NET";
            bs.BEdition = "2010";
            bs.BPrice = "800";
            bs.BISBN = "111-2222";
            bs.publisher = "Kogent Learning Solutions";

            return View(bs);
        }


    }
}
