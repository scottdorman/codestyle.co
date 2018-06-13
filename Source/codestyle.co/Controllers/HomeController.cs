using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace codestyle.co.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = ControllerUtilities.GetTableOfContents();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Title = "About";
            return View();
        }
    }
}