using MultiLanguageApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiLanguageApplication.Controllers
{
    public class HomeController : MyBaseController
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(RegistrationModel r)
        {
            return View(r);
        }

        public ActionResult ChangeLanguage(string lang)
        {
            new SiteLanguage().setLanguage(lang);
            return RedirectToAction("Index", "Home");
        }
    }
}