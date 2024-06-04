using Conference.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Conference.Controllers
{
	public class SessionController : Controller
    {
		private ConferenceContext context = new ConferenceContext();
		//
        // GET: /Session/
        public ActionResult Index()
        {
			List<Session> sessions = context.Sessions.ToList();
			return View(sessions);
        }

		[ChildActionOnly()]
		public PartialViewResult _GetForSpeaker(Int32 speakerID)
		{
			List<Session> sessions = context.Sessions.Where(s => s.SpeakerID == speakerID).ToList();
			return PartialView(sessions);
		}

		public ActionResult Details(Int32 id)
		{
			Session session = context.Sessions.Find(id);
			if(session == null) return HttpNotFound();
			else return View(session);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost()]
		public ActionResult Create(Session session)
		{
			if(!ModelState.IsValid) {
				return View(session);
			}

			try {
				ConferenceContext context = new ConferenceContext();
				context.Sessions.Add(session);
				context.SaveChanges();
			} catch (Exception ex) {
				ModelState.AddModelError("Error", ex.Message);
				return View(session);
			}

			TempData["Message"] = "Created " + session.Title;

			return RedirectToAction("Index");
		}
    }
}
