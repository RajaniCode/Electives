using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CurrencyExchange.net.webservicex.www;



namespace CurrencyExchange.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public string getConversionRate(string CurrencyFrom, string CurrencyTo)
        {
            CurrencyConvertor curConvertor = new CurrencyConvertor();
            double rate = curConvertor.ConversionRate((Currency)Enum.Parse(typeof(Currency), CurrencyFrom), (Currency)Enum.Parse(typeof(Currency), CurrencyTo)); 
            return rate.ToString(); 
        }
    }
}


