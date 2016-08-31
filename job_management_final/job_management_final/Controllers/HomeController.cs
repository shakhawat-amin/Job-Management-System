using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace job_management_final.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.theMessage = "having truble? send message us please";

            return View();
        }
        [HttpPost]
        public ActionResult Contact(String message)
        {
            ViewBag.theMessage = "your got message" + " \"" + message + "\"  ...... " + "thank you for your response :)";

            return View();
        }
        public ActionResult Serial(String letterCase)
        {
            var serial = "ASP.NET MVC5 ATM1";
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }

            //return Content(serial);
            return new HttpStatusCodeResult(404);
        }
        public ActionResult TopTrend()
        {
            return View();
        }

    }
}