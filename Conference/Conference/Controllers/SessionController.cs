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
        //
        // GET: /Session/

        public ActionResult Index()
        {
            ConferenceContext Context = new ConferenceContext();
            List<Session> Sessions = Context.Sessions.ToList();
            return View("Index", Sessions);
        }

        // GET: Session/Create
        [HttpGet()]
        public ActionResult Create()
        {
            return View();
        }

        // PSOT: Session/Create
        [HttpPost()]
        public ActionResult Create(Session Session)
        {
            if (!ModelState.IsValid)
            {
                return View(Session);
            }
            try
            {
                ConferenceContext Context = new ConferenceContext();
                Context.Sessions.Add(Session);
                Context.SaveChanges();
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("Error", ex.Message);
                return View(Session);
            }
            

            TempData["Message"] = "Created" + Session.Title;

            return RedirectToAction("Index");
        }
    }
}
