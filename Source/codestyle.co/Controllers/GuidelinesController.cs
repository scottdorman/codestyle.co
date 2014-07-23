using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace codestyle.co.Controllers
{
    public class GuidelinesController : Controller
    {
        // GET: Guidelines
        public ActionResult Index(string id)
        {
            ViewBag.Language = id;
            var model = ControllerUtilities.GetContents(id);
            if (model != null)
            {
                ViewBag.Title = "Guidelines for " + (string)model["title"];
                return View(model);
            }

            ViewBag.Title = "Not found";
            return View("NotFound");
        }
    }
}