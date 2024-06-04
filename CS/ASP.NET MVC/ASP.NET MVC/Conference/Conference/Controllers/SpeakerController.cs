using Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
    public class SpeakerController : Controller
    {
        public ActionResult Index()
        {
            return View((new ConferenceContext()).Speakers.ToList());
        }

		public ActionResult Details(Int32 id)
		{
			ConferenceContext context = new ConferenceContext();
			Speaker speaker = context.Speakers.Find(id);
			return View(speaker);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost()]
		public ActionResult Create(Speaker speaker)
		{
			if(!ModelState.IsValid) return View(speaker);

			try {
				ConferenceContext context = new ConferenceContext();
				context.Speakers.Add(speaker);
				context.SaveChanges();
			} catch (Exception ex) {
				ModelState.AddModelError("Error", ex.Message);
				return View(speaker);
			}

			TempData["Message"] = "Created " + speaker.Name;
			return RedirectToAction("Index");
		}
	}
}
