using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Open_Source_Data.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About Real World Data";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "machinelearningking@gmail.com";

            return View();
        }
    }
}